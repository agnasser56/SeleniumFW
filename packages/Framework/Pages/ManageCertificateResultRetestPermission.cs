using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Data;
using System.IO;

namespace SeleniumFramework
{
    public class ManageCertificateResultRetestPermission
    {
        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "span", Priority = 0)]
        [FindsBy(How = How.Id, Using = "lblSuccess", Priority = 1)]
        private IWebElement chkAddSuccess;
        public static List<Command> CommandList;
        public static bool OverallResult;

        public bool HandleConfirmationDialogBox(FunctionParameters fn, String Option)
        {
            bool presentFlag = false;
            //Option = OK /  Cancel
            try
            {

                // Check the presence of alert
                IAlert alert = fn.WebDriver.SwitchTo().Alert();
                // Alert present; set the flag
                presentFlag = true;
                // if present consume the alert
                if (Option == "OK")
                    alert.Accept();
                else if (Option == "Cancel")
                    alert.Dismiss();

            }
            catch (NoAlertPresentException ex)
            {
                // Alert not present
                Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n");
            }

            return presentFlag;

        }


       

        public void Add(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebBrowser.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                clsSequenceVerify sFill = new clsSequenceVerify();
              CommandList = Common.LoadCommandList(fn); 
                sFill.Init_WebControlList(fn.WebDriver, CommandList, false, fn.SuiteMode);
                CommandList = sFill.SequenceVerify();
                OverallResult = Common.CheckOverallResult(CommandList,fn);

            }
            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
        }

      
        public void Delete(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebBrowser.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                clsSequenceVerify sFill = new clsSequenceVerify();
              CommandList = Common.LoadCommandList(fn); 
                sFill.Init_WebControlList(fn.WebDriver, CommandList, false, fn.SuiteMode);
                CommandList = sFill.SequenceVerify();
                OverallResult = Common.CheckOverallResult(CommandList,fn);
                HandleConfirmationDialogBox(fn, "OK");

            }
            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
        }


        public void GoTo(Browser bro)
        {
            bro.WebDriver.Url = "https://192.168.41.22/EMC.UI/CertificateResult/CerResultRetestPermissionList.aspx";
            bro.WebDriver.Navigate();
        }

        public bool CheckSuccess()
        {
            if (chkAddSuccess.Text.Contains("successfully"))
                return true;
            else return false;
        }

        public bool CheckOverall()
        {
            return OverallResult;
        }

     

    }
}
