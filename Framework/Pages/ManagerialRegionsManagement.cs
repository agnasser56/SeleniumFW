using System;
using System.Data;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.IO;
using OpenQA.Selenium.Support.UI;
namespace SeleniumFramework
{
    public class ManagerialRegionsManagement
    {
       
        public enum ActionType { Edit, Delete, Enable,Disable,View };

       

        [FindsBy(How = How.Id, Using = "gdvList")]
        private IWebElement gdvManagerialRegions;


        [FindsBy(How = How.Id, Using = "lblControl")]
        private IWebElement btnAddNewManagerialRegion;

        [FindsBy(How = How.Id, Using = "txtArabicManagerial")]
        private IWebElement txtArabicManagerial;

        [FindsBy(How = How.Id, Using = "txtEnglishManagerial")]
        private IWebElement txtEnglishManagerial;

        [FindsBy(How = How.Id, Using = "dropParents")]
        private IWebElement ddlParents;

        [FindsBy(How = How.Id, Using = "btnSave")]
        private IWebElement btnBtnSave;
        
        [FindsBy(How = How.Id, Using = "lblResultMessage")]
        private IWebElement chkAddSuccess;

        [FindsBy(How = How.Id, Using = "lblSuccess")]
        private IWebElement chkDeleteSuccess;


        #region Navigation
        public void GoTo(Browser bro)
        {
            bro.WebDriver.Url = "https://192.168.41.22/EMC.UI/Lookups/ManagerialRegions.aspx";
            bro.WebDriver.Navigate();
        }      

        #endregion

        public void AddNewManagerialRegion(FunctionParameters fn)
        {
            try
            {
                
                    if (fn.testData == null)
                    {

                        fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                    }
                
                btnAddNewManagerialRegion.Click();
                ProcessAddNewManagerialRegions(fn.testData);
                FillAddNewManagerialRegions(fn.WebBrowser, fn.testData);
                //Update sheet with new values
                DataManager.UpdateExcelSheet(fn.testData.Table, fn.SheetName, "RowID=" + fn.RowNo);
            }
            catch (Exception ex) { }
        }

        public void EditManagerialRegions(FunctionParameters fn)
        {
            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                ClearFieldsPage1(fn);
                FillAddNewManagerialRegions(fn.WebBrowser, fn.testData);
            }
            catch (Exception ex) { }
        }
        public void DeleteManagerialRegions(FunctionParameters fn)
        {
            try
            {
                //Default waiting 
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.AlertIsPresent());
                fn.WebDriver.SwitchTo().Alert();
                fn.WebDriver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
        }
        public void SearchManagerialRegions(FunctionParameters fn, ActionType act)
        {
            try
            {
                //Default waiting 
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                
               if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }              

                string xpathExpressionToFind = "";
                
                xpathExpressionToFind = "//td/div[text()[contains(.,'" + fn.testData["EnglishManagerialRegion"].ToString() + "')]]";
                string xpathExpressionToClick = "";
                
                xpathExpressionToClick = "//*[@id='"+gdvManagerialRegions.GetAttribute("id")+"']/tbody//td/div[text() [contains(.,'" + fn.testData["EnglishManagerialRegion"].ToString() + "')]]/../..//";

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(gdvManagerialRegions.GetAttribute("id"))));
                if (gdvManagerialRegions.Displayed)
                {
                   
                        switch (act)
                        {
                            case ActionType.Edit:
                                {
                                    if (gdvManagerialRegions.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id = 'imgBtnEdit']";
                                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathExpressionToClick)));
                                        gdvManagerialRegions.FindElement(By.XPath(xpathExpressionToClick)).Click();
                                        
                                    }
                                    break;
                                }
                            case ActionType.Delete:
                                {
                                    if (gdvManagerialRegions.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id='imgBtnDelete']";

                                        gdvManagerialRegions.FindElement(By.XPath(xpathExpressionToClick)).Click();
                                        
                                    }
                                    break;
                                }
                            case ActionType.Disable:
                                {
                                    if (gdvManagerialRegions.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id = 'imgBtnActive']";
                                        gdvManagerialRegions.FindElement(By.XPath(xpathExpressionToClick)).Click();
                                        
                                    }
                                    break;
                                }
                            case ActionType.Enable:
                                {
                                    if (gdvManagerialRegions.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id='imgBtnActive']";
                                        gdvManagerialRegions.FindElement(By.XPath(xpathExpressionToClick)).Click();
                                        
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


        private void ProcessAddNewManagerialRegions(DataRow dr)
        {
            try
            {
                //In case column is Auto, auto generate value
                //dr["ArabicManagerialRegion"] = (dr["ArabicManagerialRegion"].ToString().ToLower() == "auto" ? "اوتو "+Faker.Address.SaudiArabicRegions() : dr["ArabicManagerialRegion"]);
                dr["EnglishManagerialRegion"] = (dr["EnglishManagerialRegion"].ToString().ToLower() == "auto" ? "Auto" + Faker.Address.SaudiCitis() : dr["EnglishManagerialRegion"]);
               
            }
            catch (Exception ex) { }
        }
        
       
        
        public void FillAddNewManagerialRegions(Browser bro, DataRow dr)
        {
            try
            {                
                //Default waiting 
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                txtArabicManagerial.SendKeys(dr["ArabicManagerialRegion"].ToString());
                txtEnglishManagerial.SendKeys(dr["EnglishManagerialRegion"].ToString());
                SelectElement ddlParentsSelector = new SelectElement(ddlParents);
                ddlParentsSelector.SelectByText(dr["DropParents"].ToString());
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnSave")));
                btnBtnSave.Click();
           
            }
            catch (Exception ex) { }
        }
       

       
        private void ClearFieldsPage1(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(txtArabicManagerial));

                txtArabicManagerial.Clear();
                txtEnglishManagerial.Clear();
               
            }
            catch (Exception ex) { }
        }


        public bool CheckAddManagerialRegions(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

       

        public bool CheckEditManagerialRegions(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

        public bool CheckEnableManagerialRegions(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }



        public bool CheckDisbleManagerialRegions(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

        public bool CheckDeleteManagerialRegions(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkDeleteSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkDeleteSuccess, fn.ExpectedResult);
        }



        public bool CheckSearchManagerialRegions(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }
        public bool CheckViewManagerialRegions(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(gdvManagerialRegions.GetAttribute("id"))));
                return true;
            }
            catch (Exception ex) { return false; }
            
        }




    }


}