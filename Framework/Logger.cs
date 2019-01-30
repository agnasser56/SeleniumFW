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
        public static string FilePath="";


        public static void CreateLogFile()
        {
             FilePath = GlobalVars.Environment.LoggerFilePath + "\\Log_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss")+".txt";
            // checking the Log Main Folder
            if (!System.IO.Directory.Exists(GlobalVars.Environment.LoggerFilePath))
                System.IO.Directory.CreateDirectory(GlobalVars.Environment.LoggerFilePath);            
        }
        public static void Log(string issue)
        {
            logText += "\n" + "["+ DateTime.Now.ToString("dd-MM-yyy") +"]["+ DateTime.Now.ToString("HH:mm:ss") + "]-----------------------\n" + issue;
        }

        public static void LogError(string issue)
        {
            logText = "\n" + "[" + DateTime.Now.ToString("dd-MM-yyyy") + "][" + DateTime.Now.ToString("HH:mm:ss") + "] [ERROR] ---- \n" + issue;
            var objFile = System.IO.File.AppendText(FilePath);
            objFile.WriteLine(logText);
            logText = "";
            objFile.Close();
        }

        public static void LogError(Exception ex)
        {
            logText = "\n" + "[" + DateTime.Now.ToString("dd-MM-yyyy") + "][" + DateTime.Now.ToString("HH:mm:ss") + "] [ERROR] ---- \n" + ex.Message + " || " + ex.Message;
            var objFile = System.IO.File.AppendText(FilePath);
            objFile.WriteLine(logText);
            logText = "";
            objFile.Close();
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
