using OpenQA.Selenium;
using System.Configuration;
using System.Web;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Diagnostics;
using OpenQA.Selenium.Remote;

namespace SeleniumFramework
{
    public class Browser
    {

        //private string baseUrl = "https://192.168.41.22/EMC.UI/login.aspx";
        //string s = ConfigurationManager.AppSettings["URL"];
        private string baseUrl = ConfigurationManager.AppSettings["URL"];


        //private  IWebDriver webDriver = new ChromeDriver();
        private IWebDriver webDriver;
        private IWebDriver webDriver1;
        private IWebDriver webDriver2;
        private IWebDriver webDriver3;
        //private  IWebDriver webDriver = new FirefoxDriver();

        public Browser(string browserType)
        {
            Initialize(browserType);
        }

        public IWebDriver GetDriver()
        {
            return WebDriver;
        }

        public void Initialize(string browserType)
        {
            try
            {

                switch (browserType)
                {
                    case "Chrome":
                        //DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
                        //ChromeOptions opts = new ChromeOptions();

                        //Process.Start("cmd.exe", "/C java - jar selenium - server - standalone - 2.44.0.jar - role hub");
                        // opts.BinaryLocation = Environment.CurrentDirectory+"\\"+ ConfigurationManager.AppSettings["ChromeDriverBinaryPath"];
                        //capabilities.s
                         webDriver1= new ChromeDriver();
                        //webDriver1 = new RemoteWebDriver()
                        //webDriver1 = new RemoteWebDriver(new System.Uri(ConfigurationManager.AppSettings["HubUri"]), DesiredCapabilities.Chrome());
                        webDriver1.Manage().Window.Maximize();
                        webDriver = webDriver1;
                        break;
                    case "Firefox":                        
                        DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
                        capabilities.SetCapability("marionette", true);
                        webDriver2 = new RemoteWebDriver(new System.Uri(ConfigurationManager.AppSettings["HubUri"]), capabilities);                        
                        webDriver2.Manage().Window.Maximize();
                        webDriver = webDriver2;
                        break;
                    case "InternetExplorer":
                        webDriver3 = new RemoteWebDriver(new System.Uri(ConfigurationManager.AppSettings["HubUri"]), DesiredCapabilities.InternetExplorer());
                        webDriver3.Manage().Window.Maximize();
                        webDriver = webDriver3;
                        break;
                    default:
                        webDriver = webDriver2;
                        break;
                }
            }
            catch (Exception ex) { Console.Write(ex.Message); }

            Goto("");
            webDriver.ExplicitWait(10);
            //webDriver.SwitchTo().Frame("main");
           // webDriver.Manage().Window.Maximize();

        }

        public string Title
        {
            get { return webDriver.Title; }
        }


        public int DefaultTimeout
        {
            get
            {
                string res = "0";

                if (ConfigurationManager.AppSettings["Browser.DefaultTimeout"] != "")
                    res = ConfigurationManager.AppSettings["Browser.DefaultTimeout"];

                return int.Parse(res);
            }
        }

        public ISearchContext Driver
        {
            get { return webDriver; }
        }

        public IWebDriver WebDriver
        {
            get { return webDriver; }
        }


        public void Goto(string url)
        {
            webDriver.Url = baseUrl + url;
        }

        public void Close()
        {
            try
            {
                webDriver.Quit();
            }
            catch { }
        }
    }
}