using System;
using System.Data;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.IO;
using OpenQA.Selenium.Support.UI;
namespace SeleniumFramework
{
    public class AnnouncementsManagement
    {
       
        public enum ActionType { Edit, Delete, Enable,Disable,View };

        [FindsBy(How = How.Id, Using = "drpStatus")]
        private IWebElement ddlDrpStatus;

        [FindsBy(How = How.Id, Using = "drpPaging")]
        private IWebElement ddlDrpPaging;

        [FindsBy(How = How.Id, Using = "btnShow")]
        private IWebElement btnBtnShow;

        [FindsBy(How = How.Id, Using = "gdvAnnouncements")]
        private IWebElement gdvAnnouncements;


        [FindsBy(How = How.Id, Using = "lnkBtn")]
        private IWebElement btnAddNewAnnouncement;

        [FindsBy(How = How.Id, Using = "txtAnnouncementArabicTitle")]
        private IWebElement txtAnnouncementArabicTitle;

        [FindsBy(How = How.Id, Using = "txtAnnouncementArabicText")]
        private IWebElement txtAnnouncementArabicText;

        [FindsBy(How = How.Id, Using = "txtAnnouncementEnglishTitle")]
        private IWebElement txtAnnouncementEnglishTitle;

        [FindsBy(How = How.Id, Using = "txtAnnouncementEnglishText")]
        private IWebElement txtAnnouncementEnglishText;

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_calendarAnnouncementPublishingDate_txtDate")]
        private IWebElement txtGregorianPublishingDate;

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_calendarAnnouncementExpirationDate_txtDate")]
        private IWebElement txtGregorianAnnouncementExpirationDate;

        [FindsBy(How = How.Id, Using = "cbPopup")]
        private IWebElement chkCbPopup;

        [FindsBy(How = How.Id, Using = "btnSave")]
        private IWebElement btnSave;

        [FindsBy(How = How.Id, Using = "lblSuccess")]
        private IWebElement chkAddSuccess;


        #region Navigation
        public void GoTo(Browser bro)
        {
            bro.WebDriver.Url = " https://192.168.41.22/EMC.UI/Announcements/AnnouncementList.aspx";
            bro.WebDriver.Navigate();
        }      

        #endregion

        public void AddNewAnnouncement(FunctionParameters fn)
        {
            try
            {
                
                    if (fn.testData == null)
                    {

                        fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                    }
                
                btnAddNewAnnouncement.Click();
                ProcessAddNewAnnouncement(fn.testData);
                FillAddNewAnnouncement(fn.WebBrowser, fn.testData);
                
                //Update sheet with new values
                DataManager.UpdateExcelSheet(fn.testData.Table, fn.SheetName, "RowID=" + fn.RowNo);

            }
            catch (Exception ex) { }
        }

        public void EditAnnouncement(FunctionParameters fn)
        {
            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                ClearFieldsPage1(fn);
                FillAddNewAnnouncement(fn.WebBrowser, fn.testData);
                //Update sheet with new values
                DataManager.UpdateExcelSheet(fn.testData.Table, fn.SheetName, "RowID=" + fn.RowNo);
            }
            catch (Exception ex) { }
        }
        public void DeleteAnnouncement(FunctionParameters fn)
        {
            try
            {

                fn.WebDriver.SwitchTo().Alert();
                fn.WebDriver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
        }
        public void SearchAnnouncement(FunctionParameters fn, ActionType act)
        {
            try
            {
                string pagerXpath = "//*[@id='"+ gdvAnnouncements .GetAttribute("id")+ "']/tbody/tr[@class='pager']/td/table/tbody/tr/td";
                bool found = false;
                IWebElement elementToSearch;
               if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }

                WebDriverWait wait = new WebDriverWait(fn.WebBrowser.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                SelectElement ddlDrpStatusSelector = new SelectElement(ddlDrpStatus);
                ddlDrpStatusSelector.SelectByText(fn.testData["Status"].ToString());

                SelectElement ddlDrpPagingSelector = new SelectElement(ddlDrpPaging);
                ddlDrpPagingSelector.SelectByText(fn.testData["PageSize"].ToString());

                string xpathExpressionToFind = "";
                xpathExpressionToFind = "//td/a[text()[contains(.,'" + fn.testData["AnnouncementEnglishTitle"].ToString() + "')]]";
                string xpathExpressionToClick = "";
                
                xpathExpressionToClick = "//*[@id='"+gdvAnnouncements.GetAttribute("id")+"']/tbody//td/a[text() [contains(.,'" + fn.testData["AnnouncementEnglishTitle"].ToString() + "')]]/../..//";

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(gdvAnnouncements.GetAttribute("id"))));
                if (gdvAnnouncements.Displayed)
                {
                   
                        switch (act)
                        {
                            case ActionType.Edit:
                                {
                                    if (gdvAnnouncements.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id = 'imgBtnEdit']";
                                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathExpressionToClick)));
                                        gdvAnnouncements.FindElement(By.XPath(xpathExpressionToClick)).Click();
                                        
                                    }
                                    break;
                                }
                            case ActionType.Delete:
                                {
                                    if (gdvAnnouncements.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id='imgBtnDelete']";

                                        gdvAnnouncements.FindElement(By.XPath(xpathExpressionToClick)).Click();
                                        
                                    }
                                    break;
                                }
                            case ActionType.Disable:
                                {
                                    if (gdvAnnouncements.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id = 'imgBtnActive']";
                                        gdvAnnouncements.FindElement(By.XPath(xpathExpressionToClick)).Click();
                                        
                                    }
                                    break;
                                }
                            case ActionType.Enable:
                                {
                                    if (gdvAnnouncements.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id='imgBtnActive']";
                                        gdvAnnouncements.FindElement(By.XPath(xpathExpressionToClick)).Click();
                                        
                                    }
                                    break;
                                }
                            case ActionType.View:
                                {
                                    break;
                                }
                        }
                       
                    }

            }
            catch (Exception ex) { fn.Message = ex.Message; }
        }

        public void SearchAnnouncementWithPager(FunctionParameters fn, ActionType act)
        {
            try
            {
                string pagerXpath = "//*[@id='" + gdvAnnouncements.GetAttribute("id") + "']/tbody/tr[@class='pager']/td/table/tbody/tr/td";
                bool found = false;
                IWebElement elementToSearch;
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }

                WebDriverWait wait = new WebDriverWait(fn.WebBrowser.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                SelectElement ddlDrpStatusSelector = new SelectElement(ddlDrpStatus);
                ddlDrpStatusSelector.SelectByText(fn.testData["Status"].ToString());

                SelectElement ddlDrpPagingSelector = new SelectElement(ddlDrpPaging);
                ddlDrpPagingSelector.SelectByText(fn.testData["PageSize"].ToString());

                string xpathExpressionToFind = "";
                xpathExpressionToFind = "//td/a[text()[contains(.,'" + fn.testData["AnnouncementEnglishTitle"].ToString() + "')]]";
                string xpathExpressionToClick = "";

                xpathExpressionToClick = "//*[@id='" + gdvAnnouncements.GetAttribute("id") + "']/tbody//td/a[text() [contains(.,'" + fn.testData["AnnouncementEnglishTitle"].ToString() + "')]]/../..//";

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(gdvAnnouncements.GetAttribute("id"))));
                if (gdvAnnouncements.Displayed)
                {
                    ReadOnlyCollection<IWebElement> pagerElements = fn.WebDriver.FindElements(By.XPath(pagerXpath));
                    for (int i = 0; i < pagerElements.Count; i++)
                    {
                        try
                        {
                            elementToSearch = gdvAnnouncements.FindElement(By.XPath(xpathExpressionToFind));
                            found = true;
                        }
                        catch (Exception ex)
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(pagerXpath + "[" + i + 1 + "]/a")));
                            pagerElements[i + 1].Click();
                        }
                    }
                    if (found)
                    {
                        switch (act)
                        {
                            case ActionType.Edit:
                                {
                                    if (gdvAnnouncements.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id = 'imgBtnEdit']";
                                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathExpressionToClick)));
                                        gdvAnnouncements.FindElement(By.XPath(xpathExpressionToClick)).Click();

                                    }
                                    break;
                                }
                            case ActionType.Delete:
                                {
                                    if (gdvAnnouncements.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id='imgBtnDelete']";

                                        gdvAnnouncements.FindElement(By.XPath(xpathExpressionToClick)).Click();

                                    }
                                    break;
                                }
                            case ActionType.Disable:
                                {
                                    if (gdvAnnouncements.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id = 'imgBtnActive']";
                                        gdvAnnouncements.FindElement(By.XPath(xpathExpressionToClick)).Click();

                                    }
                                    break;
                                }
                            case ActionType.Enable:
                                {
                                    if (gdvAnnouncements.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id='imgBtnActive']";
                                        gdvAnnouncements.FindElement(By.XPath(xpathExpressionToClick)).Click();

                                    }
                                    break;
                                }
                            case ActionType.View:
                                {
                                    if (gdvAnnouncements.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id='imgBtnClientCertificates']";
                                        gdvAnnouncements.FindElement(By.XPath(xpathExpressionToClick)).Click();

                                    }
                                    break;
                                }
                        }

                    }


                }


            }
            catch (Exception ex) { fn.Message = ex.Message; }
        }


        private void ProcessAddNewAnnouncement(DataRow dr)
        {
            try
            {
                //In case column is Auto, auto generate value
                dr["AnnouncementArabicTitle"] = (dr["AnnouncementArabicTitle"].ToString().ToLower() == "auto" ? "اعلان هام "+Faker.Name.ArabicName() : dr["AnnouncementArabicTitle"]);
                dr["AnnouncementArabicText"] = (dr["AnnouncementArabicText"].ToString().ToLower() == "auto" ? "اعلان هام " + Faker.Name.ArabicName() : dr["AnnouncementArabicText"]);
                dr["AnnouncementEnglishTitle"] = (dr["AnnouncementEnglishTitle"].ToString().ToLower() == "auto" ?"Important Announcement "+ Faker.Name.First() : dr["AnnouncementEnglishTitle"]);
                dr["AnnouncementEnglishText"] = (dr["AnnouncementEnglishText"].ToString().ToLower() == "auto" ? "Important Announcement " + Faker.Name.First() : dr["AnnouncementEnglishText"]);
                dr["PublishingDate"] = (dr["PublishingDate"].ToString().ToLower() == "auto" ?DateTime.Now.ToString("dd/MM/yyyy") : dr["PublishingDate"]);
                dr["AnnouncementExpirationDate"] = (dr["AnnouncementExpirationDate"].ToString().ToLower() == "auto" ? DateTime.Now.AddDays(10).ToString("dd/MM/yyyy") : dr["AnnouncementExpirationDate"]);

            }
            catch (Exception ex) { }
        }
        
       
        
        public void FillAddNewAnnouncement(Browser bro, DataRow dr)
        {
            try
            {
                //Default waiting 
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                txtAnnouncementArabicTitle.SendKeys(dr["AnnouncementArabicTitle"].ToString());
                txtAnnouncementArabicText.SendKeys(dr["AnnouncementArabicText"].ToString());
                txtAnnouncementEnglishTitle.SendKeys(dr["AnnouncementEnglishTitle"].ToString());
                txtAnnouncementEnglishText.SendKeys(dr["AnnouncementEnglishText"].ToString());
                txtGregorianPublishingDate.SendKeys(dr["PublishingDate"].ToString());
                txtGregorianAnnouncementExpirationDate.SendKeys(dr["AnnouncementExpirationDate"].ToString());
                chkCbPopup.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnSave")));
                btnSave.Click();              

            }
            catch (Exception ex) { }
        }
       

       
        private void ClearFieldsPage1(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(txtAnnouncementArabicText));

                txtAnnouncementArabicText.Clear();
                txtAnnouncementArabicTitle.Clear();
                txtAnnouncementEnglishTitle.Clear();
                txtAnnouncementEnglishText.Clear();
                txtGregorianPublishingDate.Clear();
                txtGregorianAnnouncementExpirationDate.Clear();
               
               
            }
            catch (Exception ex) { }
        }


        public bool CheckAddAnnouncement(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

       

        public bool CheckEditAnnouncement(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

        public bool CheckEnableAnnouncement(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }



        public bool CheckDisbleAnnouncement(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

        public bool CheckDeleteAnnouncement(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }



        public bool CheckSearchAnnouncement(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }
        public bool CheckViewAnnouncement(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(gdvAnnouncements.GetAttribute("id"))));
                return true;
            }
            catch (Exception ex) { return false; }
            
        }




    }


}