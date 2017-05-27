using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using Finisar.SQLite;
using System.Data ;
using System.Data.Common ;

namespace DAL
{
   public class SQLiteHelper
     {
       private static string connString;
         public static void Connect(string Dbname)
         {
             connString = String.Format("Data Source={0};New=False;Version=3", Dbname);
             try 
             {
                 using (SQLiteConnection conn = new SQLiteConnection(connString))
                 {
                     conn.Open ();
                 }
             }
            catch {}
             }
 
         public  static SQLiteConnection GetSQLiteConnection ()
         {
             return new SQLiteConnection(connString);
         }
 
         private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, string cmdText, params object[] p)
         {
            if (conn.State != ConnectionState.Open)
                 conn.Open();
             cmd.Parameters.Clear();
             cmd.Connection = conn;
             cmd.CommandText = cmdText;
             cmd.CommandType = CommandType.Text;
             cmd.CommandTimeout = 30;
             if (p != null)
             {
                 //foreach (object parm in p)
                 //   cmd.Parameters.AddWithValue(string.Empty, parm);
                 for (int i = 0; i < p.Length; i++)
                     cmd.Parameters[i].Value = p[i];
             }
         }
 
         // returns the number of rows affected
         public static int ExecuteNonQuery(string cmdText, params object[] p)
         {
             SQLiteCommand command = new SQLiteCommand();
             using (SQLiteConnection connection = GetSQLiteConnection())
             {
                 PrepareCommand(command, connection, cmdText, p);
                 return command.ExecuteNonQuery();
             }
         }

         //New update Dr.Yousef
        // returns a collection of table
        public static DataSet ExecuteDataset(string cmdText, ref  SQLiteDataAdapter adapter,ref SQLiteConnection connection, params object[] p)
         {
             DataSet ds = new DataSet();
             SQLiteCommand command = new SQLiteCommand();
             SQLiteDataAdapter da;
             connection = GetSQLiteConnection();
             PrepareCommand(command, connection, cmdText, p);
             da = new SQLiteDataAdapter(command);
             SQLiteCommandBuilder oBuilder = new SQLiteCommandBuilder(da);
             da.Fill(ds);
            adapter = da;
            return ds;
        }
        
         //public static DataRow ExecuteDataRow(string cmdText, params object[] p)
         //{
         //    DataSet ds = ExecuteDataset(cmdText, p);
         //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
         //        return ds.Tables[0].Rows[0];
         //    return null;
         //}

        
         // return SqlDataReader object
         public static SQLiteDataReader ExecuteReader(string cmdText, params object[] p)
         {
             SQLiteCommand command = new SQLiteCommand();
             SQLiteConnection connection = GetSQLiteConnection();
             try
             {
                 PrepareCommand(command, connection, cmdText, p);
                 SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                 return reader;
             }
             catch
             {
                 connection.Close();
                 throw;
             }
         }

         // return the result set of the first row and first column, ignoring the other rows or columns
         public static object ExecuteScalar(string cmdText, params object[] p)
         {
             SQLiteCommand cmd = new SQLiteCommand();
             using (SQLiteConnection connection = GetSQLiteConnection())
             {
                 PrepareCommand(cmd, connection, cmdText, p);
                 return cmd.ExecuteScalar();
             }
         }

         public static DataSet ExecutePager(ref int recordCount, int pageIndex, int pageSize, string cmdText, string countText, params object[] p)
         {
             if (recordCount < 0)
                 recordCount = int.Parse(ExecuteScalar(countText, p).ToString());
             DataSet ds = new DataSet();
             SQLiteCommand command = new SQLiteCommand();
             using (SQLiteConnection connection = GetSQLiteConnection())
             {
                 PrepareCommand(command, connection, cmdText, p);
                 SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                 da.Fill(ds, (pageIndex - 1) * pageSize, pageSize, "result");
             }
             return ds;
         }

     }

}
