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
    public class ManageHospitalUsers
    {
        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "span", Priority = 0)]
        [FindsBy(How = How.Id, Using = "lblResultMessage", Priority = 1)]
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


      

        public void AddNewHospitalUser(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebBrowser.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                clsSequenceVerify sFill = new clsSequenceVerify();
                CommandList = Common.LoadCommandList(fn); 
                sFill.Init_WebControlList(fn.WebDriver, CommandList, false, fn.SuiteMode);
                CommandList = sFill.SequenceVerify();
                OverallResult = Common.CheckOverallResult(CommandList,fn);
                //DataManager.ExcuteQuery("Update [TBL_EMC2_USERS]  set USER_PASSWORD='KawlZg4weOh+MJfTgi5Q1w==' where USER_EMAIL_Address = 'siali@elm.sa'");

            }
            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
        }

        public void ViewHospitalUser(FunctionParameters fn)
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


        public void EditHospitalUser(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebBrowser.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                clsSequenceVerify sFill = new clsSequenceVerify();
                CommandList = Common.LoadCommandList(fn); 
                sFill.Init_WebControlList(fn.WebDriver, CommandList, false, fn.SuiteMode);
                CommandList = sFill.SequenceVerify();
                OverallResult = Common.CheckOverallResult(CommandList, fn);

            }
            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
        }

        public void DeleteHospitalUser(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebBrowser.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                clsSequenceVerify sFill = new clsSequenceVerify();
                CommandList = Common.LoadCommandList(fn); 
                sFill.Init_WebControlList(fn.WebDriver, CommandList, false, fn.SuiteMode);
                CommandList = sFill.SequenceVerify();
                HandleConfirmationDialogBox(fn, "OK");
                OverallResult = Common.CheckOverallResult(CommandList, fn);

            }
            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
        }

        public void ActivateHospitalUser(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebBrowser.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                clsSequenceVerify sFill = new clsSequenceVerify();
                CommandList = Common.LoadCommandList(fn); 
                sFill.Init_WebControlList(fn.WebDriver, CommandList, false, fn.SuiteMode);
                CommandList = sFill.SequenceVerify();
                OverallResult = Common.CheckOverallResult(CommandList, fn);

            }
            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
        }

        public void DeactivateHospitalUser(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebBrowser.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                clsSequenceVerify sFill = new clsSequenceVerify();
                CommandList = Common.LoadCommandList(fn); 
                sFill.Init_WebControlList(fn.WebDriver, CommandList, false, fn.SuiteMode);
                CommandList = sFill.SequenceVerify();
                OverallResult = Common.CheckOverallResult(CommandList, fn);

            }
            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
        }

        public void ResetHospitalUserPassword(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebBrowser.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                clsSequenceVerify sFill = new clsSequenceVerify();
                CommandList = Common.LoadCommandList(fn); 
                sFill.Init_WebControlList(fn.WebDriver, CommandList, false, fn.SuiteMode);
                CommandList = sFill.SequenceVerify();
                OverallResult = Common.CheckOverallResult(CommandList, fn);

                //Reset the password
                //DataManager.ExcuteQuery("update [TBL_EMC2_USERS]  set USER_PASSWORD='KawlZg4weOh+MJfTgi5Q1w==' where USER_EMAIL_Address = 'siali@elm.sa'");

            }
            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
        }

        public void GoTo(Browser bro)
        {
            bro.WebDriver.Url = "https://192.168.41.22/EMC.UI/Hospitals/HospitalList.aspx";
            bro.WebDriver.Navigate();
        }

        public bool CheckSuccess()
        {
            bool res = false;
            try {
                if (chkAddSuccess.Text.Contains("successfully"))
                    res = true;
                
            }
            catch (Exception ex) { 
             }
            return res;
        }

        public bool CheckOverall()
        {
            return OverallResult;
        }

       


    }
}
