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
    public class StepReporter
    {
        
        public static void SaveLog(string FileName,string ReportData)
        {
            string path = Environment.CurrentDirectory;
            string FullFileName = path + "\\DetailStepReports\\" + FileName ;
            using (StreamWriter newTask = new StreamWriter(FullFileName, false))
            {
                newTask.WriteLine(ReportData);
            }
           
        }


    }

}
