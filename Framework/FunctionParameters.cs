using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
namespace SeleniumFramework
{

    public class FunctionParameters
    {
        //Input parameters for Functions
        public string RowNo;
        public string Function_Name;
        public string SheetName;
        public string ClassName;
        public string SuiteFlag;
        public string LastLoginID;
        public string SuiteMode;
        //runtime data
        public DataRow testData;

        //Needed for processing and parallesim.
        public IWebDriver WebDriver;
        public Browser WebBrowser;
        public string navigator;

        //Loggin the test results
        public string ExpectedResult;
        public string TestCaseID;
        public DateTime StartTime;
        public DateTime EndTime;
        public string Duration;
        public string Result;
        public string Message;
        public string TestCaseDescription;
        public List<Command> LoginCommandList;
        public enum TestResult { Passed, Failed, Error, Inconclosive };
        
        public string masterRecID;

        public FunctionParameters()
        {
            Function_Name = "Main";
            StartTime = DateTime.Now;

        }
        public FunctionParameters(DataRow dr)
        {
            try
            {
                this.RowNo = dr["TestDataSheetRowNo"].ToString();
                this.Function_Name = dr["Function_Name"].ToString();
                this.SheetName = dr["TestDataSheetName"].ToString();
                this.ClassName = "";
                this.SuiteFlag = dr["SuiteFlag"].ToString();
                this.WebBrowser = new Browser(dr["BrowserType"].ToString());                
                this.WebDriver = WebBrowser.WebDriver;
                GlobalVars.Test.Browser = this.WebDriver;
                this.navigator = dr["BrowserType"].ToString();
                try { this.testData = DataManager.GetExcelDataTable("select * from [" + dr["TestDataSheetName"].ToString() + "$] where RowID=" + dr["TestDataSheetRowNo"].ToString()).Rows[0]; }
                catch (Exception ex) { }


                this.ExpectedResult = dr["ExpectedResult"].ToString();
                this.TestCaseID = dr["TestCaseID"].ToString();
                this.StartTime = DateTime.Now;
                this.Result = TestResult.Failed.ToString();
                this.SuiteMode = "NO";
                this.TestCaseDescription = dr["TestCaseDescription"].ToString();
            }
            catch(Exception ex) { }

        }

        public FunctionParameters(DataRow dr, IWebDriver webDriver, Browser br, string LastLoginId)
        {
            try
            {
                this.RowNo = dr["TestDataSheetRowNo"].ToString();
                this.Function_Name = dr["Function_Name"].ToString();
                this.SheetName = dr["TestDataSheetName"].ToString();
                this.ClassName = "";
                this.SuiteFlag = dr["SuiteFlag"].ToString();
                this.WebBrowser = br; 
                this.WebDriver = webDriver;
                this.navigator = dr["BrowserType"].ToString();
                this.LastLoginID = LastLoginId;
                this.ExpectedResult = dr["ExpectedResult"].ToString();
                this.TestCaseID = dr["TestCaseID"].ToString();
                this.StartTime = DateTime.Now;
                this.Result = TestResult.Failed.ToString();
                this.SuiteMode = "YES";
            }
            catch (Exception ex) { }

        }
        //public FunctionParameters(DataRow dr,IWebDriver webDriver)
        //{
        //    try
        //    {
        //        this.RowNo = dr["TestDataSheetRowNo"].ToString();
        //        this.ExpectedResult = dr["ExpectedResult"].ToString();
        //        this.Function_Name = dr["Function_Name"].ToString();
        //        this.SheetName = dr["TestDataSheetName"].ToString();
        //        this.ClassName = "";
        //        this.WebDriver = webDriver;
        //        this.navigator = dr["BrowserType"].ToString();
        //    }
        //    catch (Exception ex) { }

        //}
    }
   
}
