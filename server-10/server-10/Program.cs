using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Data;
using Finisar.SQLite;

namespace Sqlite_server
{
    class ObjectServer
    {
        public static string name = "";
        public static DataSet DataSet=new DataSet ();
        public static SQLiteConnection conn = new SQLiteConnection();

        private static void ProcessClientRequests(Object argument)
        {
            TcpClient client = (TcpClient)argument;
            try
            {
                StreamReader reader = new StreamReader(client.GetStream());
                StreamWriter writer = new StreamWriter(client.GetStream());
                String s = String.Empty;

                while (!(s = reader.ReadLine()).Equals("Exit"))
                {
                    string[] dataArray;

                    // Message parts are divided by ":"  Break the string into an array accordingly.
                    dataArray = s.Split(':');
                    // dataArray(0) is the command.
                    Console.WriteLine(dataArray[0].ToString());
                    switch (dataArray[0])
                    {
                       case "Open_Ds":
                            {
                               
                                    Console.WriteLine(dataArray[0].ToString());
                                    Console.WriteLine("From client -> " + s);
                                    name = dataArray[1].ToString() + ":" + dataArray[2].ToString();
                                    Console.WriteLine(dataArray[1].ToString() + ":" + dataArray[2].ToString());
                                    Serialize(getDataset("", name), client.GetStream());
                                    client.GetStream().Flush();
                                
                                break;
                            }
                        case "COL":
                            {
                                //Console.WriteLine(dataArray[0].ToString());
                                //Console.WriteLine("From client -> " + s);
                                break;
                            }
                        case "Crt":
                            {
                                try
                                {
                                    Console.WriteLine(dataArray[0].ToString());
                                    Console.WriteLine("From client -> " + s);

                                    createTable(dataArray[1]);
                                    client.GetStream().Flush();
                                }
                                catch (Exception ex) {

                                }
                                break;
                            }

                        case "Del":
                            {
                                Console.WriteLine(dataArray[0].ToString());
                                Console.WriteLine("From client -> " + s);

                                createTable(dataArray[1]);
                                client.GetStream().Flush();
                                break;
                            }
                        
                        //New update Dr.Yousef
                        case "Sql":
                            {
                                Console.WriteLine(dataArray[0].ToString());
                                Console.WriteLine("From client -> " + s);
                                //Get Dataset
                                DataSet = getDataset(dataArray[1], name);
                                //add primary key
                                DataColumn[] keyColumns = new DataColumn[1];
                                keyColumns[0] = DataSet.Tables[0].Columns[0];
                                DataSet.Tables[0].PrimaryKey = keyColumns;
                                //Send Dataset
                                Serialize(getDataset(dataArray[1], name), client.GetStream());
                                client.GetStream().Flush();
                                break;
                            }
                        //New update Dr.Yousef
                        case "Update":
                            {
                                try
                                {
                                    Console.WriteLine(dataArray[0].ToString());
                                    Console.WriteLine("From client -> " + s);
                                    DataSet = Deserialize(client.GetStream());
                                    if (conn.State != ConnectionState.Open)
                                        conn.Open();
                                    adapter.Update(DataSet.Tables[0]);
                                }
                                catch(Exception ex)
                                {
                                
                                }
                                break;   
                            }

                        //New update Dr.Yousef
                        case "Delete_table":
                            {
                                Console.WriteLine(dataArray[0].ToString());
                                Console.WriteLine("From client -> " + s);
                                DAL.SQLiteHelper.ExecuteNonQuery(dataArray[1], null);
                                //DataSet = Deserialize(client.GetStream());
                                //if (conn.State != ConnectionState.Open)
                                //    conn.Open();
                                //adapter.Update(DataSet.Tables[0]);
                                break;   
                            }

                        case "DB":
                            {
                                string fileName = "";
                                fileName = Path.ChangeExtension(@"D:\" + dataArray[1].ToString(), ".db");
                                FileInfo fi = new FileInfo(fileName);
                                FileStream fs = fi.Create();
                                fs.Flush(); fs.Close();
                                //  Console.WriteLine(dataArray[0].ToString());
                                Console.WriteLine("From client -> " + s);
                                //  Serialize(getDataset(dataArray[1]), client.GetStream());
                                //  client.GetStream().Flush();

                                //  System.Data.SQLite.SQLiteConnection.CreateFile(dataArray[1].ToString()+":"+ dataArray[2].ToString());





                                break;


                            }
                        case "c":
                            {
                                Console.WriteLine("From client -> connection close");
                                reader.Close();
                                writer.Close();
                                client.Close();

                                break;

                            }

                        default:
                            {
                                Console.WriteLine("From client -> " + s);
                                writer.WriteLine("From server -> " + s);
                                writer.Flush();
                                break;
                            }
                    } // end switch
                } // end while
                reader.Close();
                writer.Close();
                client.Close();
                Console.WriteLine("Client connection closed!");
            }
            catch (IOException)
            {
                Console.WriteLine("Problem with client communication. Exiting thread.");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Incoming string was null! Client may have terminated prematurly.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown exception occured.");
                Console.WriteLine(e);
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }
        } // end ProcessClientRequests()

        //New update Dr.Yousef
        static SQLiteDataAdapter adapter=null;
        private static DataSet getDataset(string sql, string name)
        {
         if (sql == "")
            {
                DAL.SQLiteHelper.Connect(name);
                sql = "SELECT name FROM sqlite_master " +
                     "WHERE type = 'table'" +
                     "ORDER BY 1";
             }
            DataSet ds = DAL.SQLiteHelper.ExecuteDataset(sql, ref adapter, ref conn, null);
            return ds;
       }

        private static void createTable(string sql)
        {
            DAL.SQLiteHelper.Connect(name);

            DAL.SQLiteHelper.ExecuteNonQuery(sql, null);
        }

        private static void deleteTable(string sql)
        {
            DAL.SQLiteHelper.Connect(name);
            DAL.SQLiteHelper.ExecuteNonQuery(sql, null);
        }

        public static void Serialize(DataSet ds, Stream stream)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(stream, ds);
        }

        public static DataSet Deserialize(Stream stream)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            return (DataSet)serializer.Deserialize(stream);
        }

        private static void ShowServerNetworkConfig()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                Console.WriteLine(adapter.Description);
                Console.WriteLine("\tAdapter Name: " + adapter.Name);
                Console.WriteLine("\tMAC Address: " + adapter.GetPhysicalAddress());
                IPInterfaceProperties ip_properties = adapter.GetIPProperties();
                UnicastIPAddressInformationCollection addresses = ip_properties.UnicastAddresses;
                foreach (UnicastIPAddressInformation address in addresses)
                {
                    Console.WriteLine("\tIP Address: " + address.Address);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        } // end ShowServerNetworkConfig()


        static void Main(string[] args)
        {
            TcpListener listener = null;
            try
            {
                ShowServerNetworkConfig();
                listener = new TcpListener(IPAddress.Any, 8080);
                listener.Start();
                Console.WriteLine("Sqlite Databae Server started...");
                while (true)
                {
                    Console.WriteLine("Waiting for incoming client connections...");
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Accepted new client connection...");
                    Thread t = new Thread(ProcessClientRequests);
                    t.Start(client);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                }
            }
        }
    }

}
