using System;
using OpenQA.Selenium.Support.UI;
using System.Data;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace SeleniumFramework
{
    public class clsLogin2
    {
        
        public static List<Command> CommandList;
        public static bool OverallResult;


        public string GetCurrentLoginID(FunctionParameters fn)
        {
            DataTable dt = new DataTable();
            string query;
            string LastLoginID = "";


            query = "select top 1 LoginRowId from[<SheetName>$]  where[<SheetName>$].RowId = <ROWID>";
            query = query.Replace("<SheetName>", fn.SheetName);
            query = query.Replace("<ROWID>", fn.RowNo);

            dt = DataManager.GetExcelDataTable(query);

            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    LastLoginID = r["LoginRowId"].ToString();
                }
            }
            return LastLoginID;
        }


        public void LoadLoginData(FunctionParameters fn)
        {
            DataTable dt = new DataTable();            
            string query;
            
            
            query = "Select * from[Login$] where[Login$].RowID = 0 or[Login$].RowID = (select top 1 LoginRowId from[<SheetName>$]  where[<SheetName>$].RowId = <ROWID>) order by [Login$].RowID asc";            
            query = query.Replace("<SheetName>", fn.SheetName);
            query = query.Replace("<ROWID>", fn.RowNo);
            
            dt = DataManager.GetExcelDataTable(query);
            
            if (dt != null )
            {
                CommandList = DataManager.GetCommandList( dt);
            }
        }

        void performLogin(FunctionParameters fn)
        {
            WebDriverWait wait = new WebDriverWait(fn.WebBrowser.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
            clsSequenceVerify sFill = new clsSequenceVerify();
            LoadLoginData(fn);
            sFill.Init_WebControlList(fn.WebDriver, CommandList, false, fn.SuiteMode);
            CommandList = sFill.SequenceVerify();
            fn.LoginCommandList = CommandList;
            //OverallResult = Common.CheckOverallResult(CommandList,fn);
        }

        public void Login(FunctionParameters fn)
        {
            if (fn.SuiteMode == "YES")
            {
                if (fn.LastLoginID != GetCurrentLoginID(fn))
                {
                    if (fn.LastLoginID != "0") LogOut(fn);

                    performLogin(fn);

                }
            }
            else
                {
                  performLogin(fn);
                 }

        }

       

        public void LogOut(FunctionParameters fn)
        {
            fn.WebDriver.FindElement(By.Id("LoginStatus1")).Click();
        }

        public void Goto()
        {
            //Pages.TopNavigation.LogIn();
        }

        }
       
    }
