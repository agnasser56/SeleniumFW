using System;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
namespace BATDemoFramework
{
    public class RegisterPage2
    {
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement txtEmail;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement txtPassword;
        [FindsBy(How = How.Id, Using = "confirmPassword")]
        private IWebElement txtConfirmPassword;
        [FindsBy(How = How.CssSelector, Using = "input[type='submit']")]
        private IWebElement btnInput;
        public void FillForm(DataRow dr)
        {
            txtEmail.SendKeys(dr["Email"].ToString());
            txtPassword.SendKeys(dr["Password"].ToString());
            txtConfirmPassword.SendKeys(dr["ConfirmPassword"].ToString());
            btnInput.Click();
            
            

        }
    }
}