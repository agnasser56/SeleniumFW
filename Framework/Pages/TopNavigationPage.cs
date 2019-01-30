
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumFramework
{
    public class TopNavigationPage
    {
        [FindsBy(How = How.LinkText, Using = "About")]
        private IWebElement aboutLink;

        [FindsBy(How = How.XPath, Using = " //*[@id='accordion']/h2[1]/div/a")]
        private IWebElement lnkHomePage;

        [FindsBy(How = How.Id , Using = "lnkForgotPassword")]
        private IWebElement lnkForgotYourPasswordPage;

        [FindsBy(How = How.LinkText, Using = "Contact")]
        private IWebElement contactLink;

        [FindsBy(How = How.LinkText, Using = "Register")]
        private IWebElement registerLink;

        public void GoToPortal()
        {
            
        }

        [FindsBy(How = How.CssSelector, Using = "#login > a")]
        private IWebElement emailLink;
        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "img")]
        [FindsBy(How = How.XPath, Using = "//img [@src='../images/logout_en.png']")]
        private IWebElement logOutLink;

       
        [FindsBy(How = How.LinkText, Using = "Log in")]
        private IWebElement logInLink;


        
        public void About()
        {
            aboutLink.Click();
        }

       
       
        public void Home()
        {
            lnkHomePage.Click();
        }
        public bool HomeExist()
        {
            return lnkHomePage.Exists();
        }

      

        public void Contact()
        {
            contactLink.Click();
        }

        public void Register()
        {
            registerLink.Click();
        }

       

        public void LogOut(Browser bro)
        {
            
            if (logOutLink.Exists())
                logOutLink.Click();

            
            try
            {

                // Check the presence of alert
                IAlert alert = bro.WebDriver.SwitchTo().Alert();
                
                // if present consume the alert
                alert.Accept();

            }
            catch (NoAlertPresentException ex)
            {
                // Alert not present
                //ex.printStackTrace();
            }

            

        }
    

        public void LogIn()
        {
            logInLink.Click();
        }

        public bool IsLoggedIn()
        {
            return emailLink.Exists();
        }

        public void ManageAccount()
        {
            emailLink.Click();
        }
    }
}