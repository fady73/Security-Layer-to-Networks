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
    public partial class frmMain : Form
    {
        StreamReader reader;
        StreamWriter writer;
        NetworkStream stream;
        public string query=null;
        public static string ss = "";

        string database_name = ""; //New update Dr.Yousef
        private int rowIndex = 0; //New update Dr.Yousef

        int iii ;
        public frmMain()
        {
            InitializeComponent();
        }

        //New update Dr.Yousef
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database_name = "";
            openDB();
        }

        //New update Dr.Yousef
        private void openDB(){
            //Send
          //  string database_name = "";
            //المفروض قاعدة البيانات من ناحية السيرفر
            string value = "";
            try
            {
                if (database_name == "")
                {
                    if (Tmp.InputBox("Open Database", "Database name:", ref value) == DialogResult.OK)
                        database_name = value;
                    else
                        MessageBox.Show("No database was selected");
                }
                // MessageBox.Show(database_name);
                writer.WriteLine("Open_Ds:" + database_name);
                writer.Flush();

                //recive
                DataSet ds = Deserialize(stream);

                WriteToStatusBar(ds.Tables[0].Rows.Count.ToString());
                tablecombobox.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    tablecombobox.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                if (ds.Tables[0].Rows.Count != 0)
                    btnDelete.Enabled = true;
                tablecombobox.SelectedIndex = 0;
            }
            catch (IndexOutOfRangeException f) { }
            catch (Exception ex) { }
           }

        private void ConnectTo(string ServerName, int Port)
        {
            TcpClient client;
            try
            {
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
            stream = baseStream;
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            String s = String.Empty;

            //s = txttoSend.Text;// Console.ReadLine();
            ////Console.WriteLine();
            //string[] dataArray;
            //// Message parts are divided by ":"  Break the string into an array accordingly.
            //dataArray = s.Split(':');
            //// dataArray(0) is the command.
            //switch (dataArray[0])
            //{
            //    case "Getlists":
            //        {
            //            //writer.WriteLine(s);
            //            //writer.Flush();
            //            //WriteSurrealistDataToConsole(DeserializeSurrealists(client.GetStream()));
            //            //Console.WriteLine();
            //            break;
            //        }
            //    case "Ds":
            //        {
            //            //Send
            //            writer.WriteLine(s);
            //            writer.Flush();

            //            //recive
            //            ds = Deserialize(stream);
            //            WriteToStatusBar(ds.Tables[0].Rows.Count.ToString());
            //            dataGridView1.DataSource = ds.Tables[0];
            //            break;
            //        }
            //    case "Sql":
            //        {
            //            writer.WriteLine(s);
            //            writer.Flush();

            //            ds = Deserialize(stream);
            //            WriteToStatusBar(ds.Tables[0].Rows.Count.ToString());
            //            dataGridView1.DataSource = ds.Tables[0];
            //            break;
            //        }
            //    case "Exit":
            //        {
            //            writer.WriteLine(s);
            //            writer.Flush();
            //            break;
            //        }
            //    default:
            //        {
            //            writer.WriteLine(s);
            //            writer.Flush();
            //            String server_string = reader.ReadLine();
            //            WriteToStatusBar(server_string);
            //            break;
            //        }
            //}
            //// }
            //reader.Close();
            //writer.Close();
            ////   client.Close();
        }

        private void WriteToStatusBar(string Message)
        {
           StatusBar.Text = Message;
        }

        public static void Serialize(DataSet ds, NetworkStream Stream)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(Stream, ds);
        }

        public static DataSet Deserialize(NetworkStream stream)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            return (DataSet)serializer.Deserialize(stream);
        }

        private void tlstrpbtnconnect_Click(object sender, EventArgs e)
        {
           ConnectTo("127.0.0.1", 8080);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tlStpbtnnew_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            new_database.Visible = true;
            label6.Visible = true;
            button3.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (query != null)
                query += ",";
            query += txtcolumnname.Text+" "+ typecombo.Text;
            if (chkprimary.Checked)
                query += " primary key";
            txtcolumnname.Text = null; typecombo.Text = null;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (query == null)
                MessageBox.Show("enter name and type");
            else
            {
                string result = "create table " + txttablename.Text + "(" + query + ");";
                query = null;
                writer.WriteLine("Crt:" + result);
                writer.Flush();
            }
        }
     
        private void tablecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string t = "select * from " + tablecombobox.Text + ";";
                writer.WriteLine("Sql:" + t);
                writer.Flush();

                DataSet ds = Deserialize(stream);
                WriteToStatusBar(ds.Tables[0].Rows.Count.ToString());
                userDataGridView.DataSource = ds.Tables[0];
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString());
            }
        }

        //new Dr. Yousef
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure you wanna delete this Table?", "Warning",
                   MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                string d = "drop table " + tablecombobox.Text + ";";
                writer.WriteLine("Delete_table:" + d);
                writer.Flush();
                btnRefresh.PerformClick();
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string s = rchtxtQuery.Text;
            writer.WriteLine("Sql:" + s+";");
            writer.Flush();
            DataSet ds = Deserialize(stream);
            tabControl1.SelectTab(0);
            WriteToStatusBar(ds.Tables[0].Rows.Count.ToString());
            userDataGridView.DataSource = ds.Tables[0];


        }

        //new Dr. Yousef 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
          iii= userDataGridView.ColumnCount-1;
           DataTable dt = userDataGridView.DataSource as DataTable;
           writer.WriteLine("Update:");
           writer.Flush();
           DataSet dss = new DataSet();
           DataTable dtCopy = dt.Copy();
           dss.Tables.Add(dtCopy);
           Serialize(dss, stream); 
        }

        private void tlStrpClose_Click(object sender, EventArgs e)
        {
            writer.WriteLine("c:");
            writer.Flush();

        }

        private void closeDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            writer.WriteLine("COL:");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writer.WriteLine("DB:" + new_database.Text);
            writer.Flush();
            button2.Visible = false;
            new_database.Visible = false;
            label6.Visible = false;
            button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new_database.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            label6.Visible = false;
        }

        //new Dr. Yousef
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            openDB();
        }

        //new Dr. Yousef
        // Delete row from datagridview by right click
        //1-select a row in datagridview on right clcik
        private void userDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.userDataGridView.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.userDataGridView.CurrentCell = this.userDataGridView.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.userDataGridView, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
        //new Dr. Yousef
        //2-Right click and delete row from datagridview and update and refresh data
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure you wanna delete this Record?", "Warning",
                MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!this.userDataGridView.Rows[this.rowIndex].IsNewRow)
                {
                    this.userDataGridView.Rows.RemoveAt(this.rowIndex);
                    btnUpdate.PerformClick();
                    btnRefresh.PerformClick();
                }
            }
        }
       
    }
}
