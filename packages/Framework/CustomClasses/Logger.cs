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
    public class Logger
    {

        public static string logText = "";
        public static string logCommandsDataSet = "";
        public static void Log(string issue)
        {
            logText += "\n" + "----------------------------------------------------------------------------\n" + issue;
        }

        public static void LogCommand(string CommandDataSet)
        {
            logCommandsDataSet += "\n" + "----------------------------------------------------------------------------\n" + CommandDataSet;
        }

        public static void SaveLog()
        {
            File.WriteAllText("Log.txt",logText );
            File.WriteAllText("CommandsLog.txt", logCommandsDataSet);
        }

        public static void SaveLog(string FileName)
        {
            File.WriteAllText(FileName, logText);
            File.WriteAllText("CommandsLog.txt", logCommandsDataSet);
        }


    }

}
