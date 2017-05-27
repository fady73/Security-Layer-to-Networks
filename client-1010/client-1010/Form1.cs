using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using asdNet;

namespace client_1010
{
    public partial class Form1 : Form
    {
        static DataSet ds=new DataSet ();
        public delegate void MyDelegate(string Message);
       
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectTo(string ServerName,int Port )
        {
            TcpClient client;
            try {
                WriteToStatusBar(string.Format("Attempting to connect to server at IP address: {0} port: {1}", ServerName, Port));
		        client = new TcpClient(ServerName, Port);
		        WriteToStatusBar("Connection successful!");
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create client Socket: " + e.Message);
            }
            var baseStream = client.GetStream();
           // var stream = new SecureStream(baseStream,false);
           // MessageBox.Show (stream.SymmetricAlgorithm.ToString());
            var stream = baseStream;
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
 		    String s = String.Empty;
		   
            s =txttoSend.Text;// Console.ReadLine();
 			//Console.WriteLine();
            string[] dataArray;
            // Message parts are divided by ":"  Break the string into an array accordingly.
            dataArray = s.Split(':');
            // dataArray(0) is the command.
            switch (dataArray[0])
            {
                case "Getlists":
                    {
                    //writer.WriteLine(s);
                    //writer.Flush();
                    //WriteSurrealistDataToConsole(DeserializeSurrealists(client.GetStream()));
                    //Console.WriteLine();
                     break;
				}
                case "Ds":
                    {
                        //Send
                        writer.WriteLine(s);
                        writer.Flush();
                        
                        //recive
                        ds = Deserialize(stream);
                        WriteToStatusBar(ds.Tables[0].Rows.Count.ToString ());
                        dataGridView1.DataSource = ds.Tables[0];
                        break;
                    }
                case "Sql":
                    {
                        writer.WriteLine(s);
                        writer.Flush();

                        ds = Deserialize(stream);
                        WriteToStatusBar(ds.Tables[0].Rows.Count.ToString());
                        dataGridView1.DataSource = ds.Tables[0];
                        break;
                    }
 		        case "Exit" : {
				    writer.WriteLine(s);
 				    writer.Flush();
 				    break;
				 }
			   default: {
				    writer.WriteLine(s);
 				    writer.Flush();
                    String server_string = reader.ReadLine();
                    WriteToStatusBar(server_string);
                    break;
				 }
			 }
		// }
 	    reader.Close();
 	    writer.Close();
 	 //   client.Close();
      }
   

        public static void Serialize(DataSet ds, NetworkStream stream)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(stream, ds);
        }

        public static DataSet Deserialize(NetworkStream stream)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            return (DataSet)serializer.Deserialize(stream);
        }

        private void btnConnect_Click(object sender, System.EventArgs e)
        {
            DisableFields();
            DoNetworkingConnection();
        }

        private void DoNetworkingConnection()
        {
            ConnectTo(txtIp.Text,System.Convert.ToInt32(txtPort.Text));

            //Thread MyThread = null;
            //try
            //{
            //  MyThread = new Thread (() =>ConnectTo(txtIp.Text,System.Convert.ToInt32(txtPort.Text)));
            // }
            //catch (Exception e)
            //{
            //    WriteToStatusBar("Failed to create thread with error: " + e.Message);
            //    return;
            //}
            //try
            //{
            //    MyThread.Start();
            //}
            //catch (Exception e)
            //{
            //    WriteToStatusBar("The thread failed to start with error: " + e.Message);
            //}
        }

        private void DisableFields()
        {
            txtPort.Enabled = false;
            txtIp.Enabled = false;
            txttoSend.Enabled = false;
            txttoRecive.Enabled = false;
            btnConnect.Enabled = false;
          }

        private void EnableFields()
        {
            txtPort.Enabled = true;
            txtIp.Enabled = true;
            txttoSend.Enabled = true;
            txttoRecive.Enabled = true;
            btnConnect.Enabled = true;
        }

        private void WriteToStatusBar(string Message)
        {
            if (this.statusStrip1.InvokeRequired)
                this.Invoke(new MyDelegate (WriteToStatusBar));
                EnableFields();
                StatusBar.Text = Message;
        }
    }
}
