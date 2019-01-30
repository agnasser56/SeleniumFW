using System;
using System.Data;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.IO;
using OpenQA.Selenium.Support.UI;
namespace SeleniumFramework
{
    public class RestrictionWarningManagement
    {
       
        public enum ActionType { Edit, Delete, Enable,Disable,View };

        [FindsBy(How = How.Id, Using = "drpType")]
        private IWebElement ddlType;
        
        [FindsBy(How = How.Id, Using = "drpStatus")]
        private IWebElement ddlStatus;
        
        [FindsBy(How = How.Id, Using = "drpPaging")]
        private IWebElement ddlPaging;
        
        [FindsBy(How = How.Id, Using = "txtARRWName")]
        private IWebElement txtARRWName;

        [FindsBy(How = How.Id, Using = "txtARRWDescription")]
        private IWebElement txtARRWDescription;

        [FindsBy(How = How.Id, Using = "txtENRWName")]
        private IWebElement txtENRWName;

        [FindsBy(How = How.Id, Using = "txtENRWDescription")]
        private IWebElement txtENRWDescription;

        [FindsBy(How = How.Id, Using = "btnSave")]
        private IWebElement btnBtnSave;

        [FindsBy(How = How.Id, Using = "gdvRW")]
        private IWebElement gdvRestrictionWarnings;

        

        [FindsBy(How = How.Id, Using = "lnkBtnAddNewRW")]
        private IWebElement btnAddNewRestrictionWarning;

        [FindsBy(How = How.Id, Using = "lblSuccess")]
        private IWebElement chkAddSuccess;



        #region Navigation
        public void GoTo(Browser bro)
        {
            bro.WebDriver.Url = " https://192.168.41.22/EMC.UI/RestrictionWarning/RestrictionWarningList.aspx";
            bro.WebDriver.Navigate();
        }      

        #endregion

        public void AddNewRestrictionWarning(FunctionParameters fn)
        {
            try
            {

                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }

                btnAddNewRestrictionWarning.Click();
                ProcessAddNewRestrictionWarning(fn.testData);
                FillAddNewRestrictionWarning(fn.WebBrowser, fn.testData);

                
                //Update sheet with new values
                DataManager.UpdateExcelSheet(fn.testData.Table, fn.SheetName, "RowID=" + fn.RowNo);
            }
            catch (Exception ex) { }
        }

        public void EditRestrictionWarning(FunctionParameters fn)
        {
            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                ClearFieldsPage1(fn);
                FillAddNewRestrictionWarning(fn.WebBrowser, fn.testData);
            }
            catch (Exception ex) { }
        }
        public void DeleteRestrictionWarning(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.AlertIsPresent());

                fn.WebDriver.SwitchTo().Alert();
                fn.WebDriver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
        }
        public void SearchRestrictionWarning(FunctionParameters fn, ActionType act)
        {
            try
            {
               if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }

                WebDriverWait wait = new WebDriverWait(fn.WebBrowser.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));

                SelectElement ddlTypeSelector = new SelectElement(ddlType);
                ddlTypeSelector.SelectByText(fn.testData["Type"].ToString());

                SelectElement ddlDrpStatusSelector = new SelectElement(ddlStatus);
                ddlDrpStatusSelector.SelectByText(fn.testData["Status"].ToString());

                SelectElement ddlDrpPagingSelector = new SelectElement(ddlPaging);
                ddlDrpPagingSelector.SelectByText(fn.testData["PageSize"].ToString());

                string xpathExpressionToFind = "";
                xpathExpressionToFind = "//td/a[text()[contains(.,'" + fn.testData["EnWName"].ToString() + "')]]";

                string xpathExpressionToClick = "";                                          
                xpathExpressionToClick = "//*[@id='"+gdvRestrictionWarnings.GetAttribute("id")+"']/tbody//td/a[text() [contains(.,'" + fn.testData["EnWName"].ToString() + "')]]/../..//";

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(gdvRestrictionWarnings.GetAttribute("id"))));
                if (gdvRestrictionWarnings.Displayed)
                {
                   
                        switch (act)
                        {
                            case ActionType.Edit:
                                {
                                    if (gdvRestrictionWarnings.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id = 'imgBtnEdit']";
                                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathExpressionToClick)));
                                        gdvRestrictionWarnings.FindElement(By.XPath(xpathExpressionToClick)).Click();
                                        
                                    }
                                    break;
                                }
                            case ActionType.Delete:
                                {
                                    if (gdvRestrictionWarnings.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id='imgBtnDelete']";

                                        gdvRestrictionWarnings.FindElement(By.XPath(xpathExpressionToClick)).Click();
                                        
                                    }
                                    break;
                                }
                            case ActionType.Disable:
                                {
                                    if (gdvRestrictionWarnings.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id = 'imgBtnActive']";
                                        gdvRestrictionWarnings.FindElement(By.XPath(xpathExpressionToClick)).Click();
                                        
                                    }
                                    break;
                                }
                            case ActionType.Enable:
                                {
                                    if (gdvRestrictionWarnings.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                    {
                                        xpathExpressionToClick += "a[@id='imgBtnActive']";
                                        gdvRestrictionWarnings.FindElement(By.XPath(xpathExpressionToClick)).Click();
                                        
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

     
        private void ProcessAddNewRestrictionWarning(DataRow dr)
        {
            try
            {
                //In case column is Auto, auto generate value
                dr["ArabicWName"] = (dr["ArabicWName"].ToString().ToLower() == "auto" ? "قيد  "+Faker.Name.ArabicName() : dr["ArabicWName"]);
                dr["ArabicWDescription"] = (dr["ArabicWDescription"].ToString().ToLower() == "auto" ? "قيد " + Faker.Name.ArabicName() : dr["ArabicWDescription"]);
                dr["EnWName"] = (dr["EnWName"].ToString().ToLower() == "auto" ?"Important RestrictionWarning "+ Faker.Name.First() : dr["EnWName"]);
                dr["EnWDescription"] = (dr["EnWDescription"].ToString().ToLower() == "auto" ? "Important RestrictionWarning " + Faker.Name.First() : dr["EnWDescription"]);
            
            }
            catch (Exception ex) { }
        }
        
       
        
        public void FillAddNewRestrictionWarning(Browser bro, DataRow dr)
        {
            try
            {
                //Default waiting 
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                SelectElement ddlTypeSelector = new SelectElement(ddlType);
                ddlTypeSelector.SelectByText(dr["Type"].ToString());               
                txtARRWName.SendKeys(dr["ArabicWName"].ToString());
                txtARRWDescription.SendKeys(dr["ArabicWDescription"].ToString());
                txtENRWName.SendKeys(dr["EnWName"].ToString());
                txtENRWDescription.SendKeys(dr["EnWDescription"].ToString());
                btnBtnSave.Click();
                
            }
            catch (Exception ex) { }
        }
       

       
        private void ClearFieldsPage1(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(txtARRWName));

                txtARRWName.Clear();
                txtARRWDescription.Clear();
                txtENRWName.Clear();
                txtENRWDescription.Clear();
                
            }
            catch (Exception ex) { }
        }


        public bool CheckAddRestrictionWarning(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

       

        public bool CheckEditRestrictionWarning(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

        public bool CheckEnableRestrictionWarning(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }



        public bool CheckDisbleRestrictionWarning(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

        public bool CheckDeleteRestrictionWarning(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }



        public bool CheckSearchRestrictionWarning(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }
        public bool CheckViewRestrictionWarning(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(gdvRestrictionWarnings.GetAttribute("id"))));
                return true;
            }
            catch (Exception ex) { return false; }
            
        }




    }


}