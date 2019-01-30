using System;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
namespace SeleniumFramework
{
    public class clsLogin
    {
        
        [FindsBy(How = How.Id, Using = "txtUserName")]
        private IWebElement txtTxtUserName;

        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement txtTxtPassword;

        [FindsBy(How = How.Id, Using = "btnLogin")]
        private IWebElement btnLogin;

        [FindsBy(How = How.Id, Using = "LoginStatus1")]
        private IWebElement btnLogout;

        
        public void LoginUser(FunctionParameters fncParams)
        {
            //Default waiting 
            WebDriverWait wait = new WebDriverWait(fncParams.WebDriver, TimeSpan.FromSeconds(fncParams.WebBrowser.DefaultTimeout));
            DataTable dt = new DataTable();
            dt = DataManager.GetExcelDataTable("select top 1 * from [Login$] where RowID in (select top 1 LoginID from ["+fncParams.SheetName+"$] where RowID="+fncParams.RowNo+")");
            FillForm(dt.Rows[0]);
        }

        public void FillForm(DataRow dr)
        {
              txtTxtUserName.SendKeys(dr["UserName"].ToString());
              txtTxtPassword.SendKeys(dr["Password"].ToString());
                txtTxtPassword.SendKeys(Keys.Return);
            //btnBtnLogin.Click();           
        }
        public void LogOut(FunctionParameters fncParams)
        {
            try
            {

                WebDriverWait wait = new WebDriverWait(fncParams.WebDriver, TimeSpan.FromSeconds(fncParams.WebBrowser.DefaultTimeout));

                btnLogout.Click();
            }
            catch (Exception ex) { }
        }
    }
}