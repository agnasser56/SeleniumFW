using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace SeleniumFramework
{
    public class DataManager
    {
        //public static string SelectMax(string fieldName, string TableName)
        //{

        //}
        public static int log_id = 1;
        public static int user_id = 1;
        public static DateTime login_time;
        public static DateTime logout_time;


        public static void BulkCopy(DataTable table)
        {
            using (var bulkCopy = new SqlBulkCopy(ConfigurationManager.AppSettings["Destination.ConnectionString"], SqlBulkCopyOptions.KeepIdentity))
            {
                // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                foreach (DataColumn col in table.Columns)
                {
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }
                bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.DestinationTableName = ConfigurationManager.AppSettings["DestinationTableName"];
                bulkCopy.WriteToServer(table);
            }
        }

        public static string getDayOfWeekArabic(DateTime dt)
        {
            if (dt.DayOfWeek.ToString().ToLower() == "friday")
                return "الجمعه";
            if (dt.DayOfWeek.ToString().ToLower() == "saturday")
                return "السبت";

            if (dt.DayOfWeek.ToString().ToLower() == "sunday")
                return "الاحد";
            if (dt.DayOfWeek.ToString().ToLower() == "monday")
                return "الاثنين";
            if (dt.DayOfWeek.ToString().ToLower() == "tuesday")
                return "الثلاثاء";
            if (dt.DayOfWeek.ToString().ToLower() == "wednesday")
                return "الاربعاء";
            if (dt.DayOfWeek.ToString().ToLower() == "thursday")
                return "الخميس";
            else return "";

        }
        public static string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["Main.ConnectionString"];
        }
        
             public static string GetExcelConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyExcelConn"].ConnectionString;
        }
        public static int ExcuteQueryTransaction(string SP_Name)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["Main.ConnectionString"]);
            try
            {
                SqlCommand cmd = new SqlCommand(SP_Name, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = conn.BeginTransaction();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        public static string SelectMaxCheck(string departement, DateTime date)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["Main.ConnectionString"]);
            try
            {
                conn.Open();
                SqlCommand cmd;
                //old code
                //cmd = new SqlCommand("set dateformat dmy;SELECT ISNULL(MAX(id),0)+1 FROM CHECK_INCOMES where check_type_id='" + departement + "' and cast(date as smalldatetime)>='"+date.ToString("dd/MM/yyyy")+"'", conn);

                //new modification 26/3/2012
                cmd = new SqlCommand("set dateformat dmy;SELECT ISNULL(MAX(id),0)+1 FROM CHECK_INCOMES where check_type_id='" + departement + "' and convert(varchar,date,103)='" + date.ToString("dd/MM/yyyy") + "' "
                                + " and (SELECT ISNULL(MAX(id),0)+1 FROM CHECK_INCOMES where check_type_id = '" + departement + "' and convert(varchar,date,103)= '" + date.ToString("dd/MM/yyyy") + "') not in(SELECT id FROM CHECK_INCOMES where check_type_id='" + departement + "' and convert(varchar,date,103)='" + date.ToString("dd/MM/yyyy") + "') ", conn);

                object maxVal = cmd.ExecuteScalar();
                conn.Close();
                return maxVal.ToString();
            }
            catch
            {
                return null;
            }
        }

        public static string SelectMaxInvoice(string store_id, DateTime trans_date)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["Main.ConnectionString"]);
            try
            {
                conn.Open();
                SqlCommand cmd;

                cmd = new SqlCommand("set dateformat dmy;SELECT ISNULL(MAX(id),0)+1 FROM tinvoice where store_id='" + store_id + "' and cast(transaction_date as smalldatetime)>='" + trans_date.ToString("dd/MM/yyyy") + "'", conn);

                object maxVal = cmd.ExecuteScalar();
                conn.Close();
                return maxVal.ToString();
            }
            catch
            {
                return null;
            }
        }

        public static string SelectMax(string FieldName, string TableName)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["Main.ConnectionString"]);
            try
            {
                conn.Open();
                SqlCommand cmd;
                if (TableName == "tPInvoice" || TableName.ToLower() == "tinvoice" || TableName == "tCReturn" || TableName == "tItem" || TableName == "tItemData" || TableName == "tUnit")
                {
                    //select isnull(max(cast(invoice_id as int)),0) from tPinvoice
                    cmd = new SqlCommand("set dateformat dmy;select isnull(max(cast(" + FieldName + " as int)),0)+1 FROM " + TableName, conn);
                }
                else
                {
                    cmd = new SqlCommand("set dateformat dmy;SELECT ISNULL(MAX(" + FieldName + "),0)+1 FROM " + TableName, conn);
                }
                object maxVal = cmd.ExecuteScalar();
                conn.Close();
                return maxVal.ToString();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex.InnerException);
                return null;
            }
        }

        public static int ExcuteQuery(string Query)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["Main.ConnectionString"]);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch(Exception ex)
            {
                conn.Close();
                return -1;
            }
            finally
            {
                conn.Close();
              

            }
           
        }

        public static void ExcuteExcelQuery(string Query)
        {

            OleDbConnection conn = new OleDbConnection();
            if (ConfigurationManager.ConnectionStrings["MyExcelConn"] != null)
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyExcelConn"].ConnectionString;
            OleDbCommand cmd;
            try
            {
                conn.Open();
                cmd = new OleDbCommand(Query, conn);
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public static object GetDBValue(string Query)
        {
            object res;
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["Main.ConnectionString"]);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);
               res = cmd.ExecuteScalar();
            }
            catch
            {
                conn.Close();
                return null;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public static string GetInvoiceForReturn(string returnID)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["Main.ConnectionString"]);
            string result = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select invoice_id from tCReturn where return_id='" + returnID + "'", conn);
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                conn.Close();
                return result;
            }
            finally
            {
                //return result;
                conn.Close();

            }

        }
        public static string GetInvoiceID(string check_date, int check_type_id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["Main.ConnectionString"]);
            string result = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("set dateformat dmy;select isnull(max(id),0)+1 from check_incomes where cast(date as smalldatetime)=cast( " + check_date + " as smalldatetime )and check_type_id=" + check_type_id, conn);
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                conn.Close();
                return result;
            }
            finally
            {
                conn.Close();

            }
            return result;
        }

        public static DataTable GetDataTable(string query)
        {
            
            SqlConnection conn = new SqlConnection();
            if (ConfigurationManager.ConnectionStrings["MySqlConn"] != null)
                 conn.ConnectionString = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
            DataTable dt = new DataTable();
            SqlCommand cmd;
            try
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
               
                return dt;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
   

        public static DataTable GetExcelDataTable(string query)
        {
           
            OleDbConnection conn = new OleDbConnection();
            if (ConfigurationManager.ConnectionStrings["MyExcelConn"] != null)
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyExcelConn"].ConnectionString;
            DataTable dt = new DataTable();
            OleDbCommand cmd;
            try
            {
                conn.Open();
                cmd = new OleDbCommand(query, conn);
                dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                
                return dt;
            }
            catch (Exception ex)
            {
                
                Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n");
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

     

        public static List<Command> GetCommandList(DataTable Hdt, DataTable dt)
        {
            List<Command> CommandList;
            CommandList = new List<Command>();
            for (int x = 0; x < Hdt.Columns.Count; x++)
            {
               CommandList.Add(new Command() { CommandName = Hdt.Rows[0].ItemArray[x].ToString(), CommandData = dt.Rows[0].ItemArray[x].ToString() });
            
            }

            return CommandList;
            
        }

        public static List<Command> GetCommandList( DataTable dt)
        {
            List<Command> CommandList;
            CommandList = new List<Command>();
            for (int x = 1; x < dt.Columns.Count; x++)
            {
                
                CommandList.Add(new Command() { CommandName = dt.Rows[0].ItemArray[x].ToString(), CommandData = dt.Rows[1].ItemArray[x].ToString(), ColumnName = dt.Columns[x].ToString() });

            }

            return CommandList;

        }

        public static string getParentPath(FunctionParameters fn)
        {
            DataTable dt = new DataTable();
            string parent_xpath = "";

            dt = DataManager.GetExcelDataTable("select top 1 * from [PageParents$] where SheetName = " + fn.SheetName);
            if (dt != null)
            {
                DataRow r = dt.Rows[0];
                parent_xpath = r["Parent_Xpath"].ToString();
            }
            return parent_xpath;
        }



        public static string GetExcelDataTableForTest(string query)
        {
            string str = "";
            OleDbConnection conn = new OleDbConnection();
            if (ConfigurationManager.ConnectionStrings["MyExcelConn"] != null)
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyExcelConn"].ConnectionString;
            DataTable dt = new DataTable();
            OleDbCommand cmd;
            try
            {
                conn.Open();
                cmd = new OleDbCommand(query, conn);
                dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));

                return str;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void UpdateExcelSheet(DataTable dt, string sheetName, string condition)
        {
            OleDbConnection conn = new OleDbConnection();
            if (ConfigurationManager.ConnectionStrings["MyExcelConn"] != null)
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyExcelConn"].ConnectionString;
            string query = "Update [" + sheetName + "$] set ";
            string columnsToUpdate = "";
            OleDbCommand cmd;
            try
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    columnsToUpdate += dc.Caption + " = '" + dt.Rows[0][dc.ColumnName].ToString() + "'";
                    if (dt.Columns.IndexOf(dc) != dt.Columns.Count - 1)
                        columnsToUpdate += ",";
                }

                conn.Open();
                query += columnsToUpdate;
                query += " where " + condition;
                cmd = new OleDbCommand(query, conn);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }


        public static string GetExcelValue(string query)
        {

            OleDbConnection conn = new OleDbConnection();
            if (ConfigurationManager.ConnectionStrings["MyExcelConn"] != null)
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyExcelConn"].ConnectionString;
            string res = "";
            DataTable dt = new DataTable();
            OleDbCommand cmd;
            try
            {
                conn.Open();
                cmd = new OleDbCommand(query, conn);
                res = cmd.ExecuteScalar().ToString();
                

                return res;
            }
            catch (Exception ex)
            {
                //File.WriteAllText("Log.txt",ex.Message);
                Console.WriteLine( ex.Message);
                //Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.StackTrace);
                return "";
            }
            finally
            {
                conn.Close();
            }
        }


        public static string InsertExecutionRecord(string pSQL)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            string res = "";

            try
            {

                conn = new OleDbConnection();
                if (ConfigurationManager.ConnectionStrings["LogDBSqlConn"] != null)
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["LogDBSqlConn"].ConnectionString;

                conn.Open();

                cmd = new OleDbCommand(pSQL, conn);

                var result = cmd.ExecuteScalar();


                conn.Close();

                if (result != null)
                    res = result.ToString();

                return res;
            }
            catch (Exception ex) { Logger.LogError(ex); return res; }
            finally { conn.Close(); }
        }

        public static void UpdateExecutionRecord(string pSQL)
        {
            OleDbConnection conn = null;
            OleDbCommand cmd = null;

            try
            {

                conn = new OleDbConnection();
                if (ConfigurationManager.ConnectionStrings["LogDBSqlConn"] != null)
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["LogDBSqlConn"].ConnectionString;

                conn.Open();

                cmd = new OleDbCommand(pSQL, conn);

                cmd.ExecuteNonQuery();


                conn.Close();

                return;
            }
            catch (Exception ex) { Logger.LogError(ex); return; }
            finally { conn.Close(); }
        }

        public static Dictionary<string, string> GetDictionaryFromDataTable(DataTable tblData)
        {
            Dictionary<string, string> dicData = new Dictionary<string, string>();

            try
            {
                if (tblData != null)
                {
                    foreach (DataRow row in tblData.Rows)
                    {
                        if (row["Name"].ToString().Trim() != "" && row["Value"].ToString().Trim() != "")
                            dicData.Add(row["Name"].ToString().Trim(), row["Value"].ToString().Trim());
                    }
                }
                return dicData;
            }
            catch (Exception)
            {
                return dicData;
            }
        }

    }
}
