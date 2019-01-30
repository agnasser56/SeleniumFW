using System;
using System.Data;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.IO;
using OpenQA.Selenium.Support.UI;
namespace SeleniumFramework
{
    public class RolesManagement
    {

        public enum ActionType { Edit, Delete, Enable, Disable, View };


        [FindsBy(How = How.Id, Using = "lbAddRolecontrol")]
        private IWebElement btnAddRole;


        [FindsBy(How = How.Id, Using = "txtRoleName")]
        private IWebElement txtTxtRoleName;

        [FindsBy(How = How.Id, Using = "dropUserType")]
        private IWebElement ddlUserType;

        [FindsBy(How = How.Id, Using = "BtnCancel")]
        private IWebElement btnBtnCancel;

        [FindsBy(How = How.Id, Using = "BtnAddRole")]
        private IWebElement btnAddNewRole;




        [FindsBy(How = How.Id, Using = "drpStatus")]
        private IWebElement ddlDrpStatus;

        [FindsBy(How = How.Id, Using = "drpPaging")]
        private IWebElement ddlDrpPaging;

        [FindsBy(How = How.Id, Using = "btnShow")]
        private IWebElement btnBtnShow;

        [FindsBy(How = How.Id, Using = "GvRoles")]
        private IWebElement gdvRoles;


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

        [FindsBy(How = How.Id, Using = "lblSuccessMsg")]
        private IWebElement chkAddSuccess;


        #region Navigation
        public void GoTo(Browser bro)
        {
            bro.WebDriver.Url = " https://192.168.41.22/EMC.UI/Roles/RolesList.aspx";
            bro.WebDriver.Navigate();
        }

        #endregion

        public void AddNewRole(FunctionParameters fn)
        {
            try
            {

                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                btnAddRole.Click();
                ProcessAddNewRole(fn.testData);
                FillAddNewRole(fn.WebBrowser, fn.testData);
                Common.ExplicitWait(3);
                //Update sheet with new values
                DataManager.UpdateExcelSheet(fn.testData.Table, fn.SheetName,"RowID="+fn.RowNo);
            }
            catch (Exception ex) { }
        }

        private void ProcessAddNewRole(DataRow dr)
        {
            try
            {
                //In case column is Auto, auto generate value
                dr["NewRoleName"] = (dr["NewRoleName"].ToString().ToLower() == "auto" ? "Auto" + Faker.Name.First() : dr["NewRoleName"]);
                dr["OldRoleName"] = dr["NewRoleName"];

            }
            catch (Exception ex) { }
        }

        public void DeleteRole(FunctionParameters fn)
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
        public void SearchRole(FunctionParameters fn, ActionType act)
        {
            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                WebDriverWait wait = new WebDriverWait(fn.WebBrowser.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                string xpathExpressionToParentRow = "";
                string xpathExpressionToFind = "";
                string xpathExpressionToEdit = "";

                string xpathExpressionToSelect = "";
                string xpathExpressionToSave = "";

                xpathExpressionToFind = "//td/span[text()[contains(.,'" + fn.testData["OldRoleName"].ToString() + "')]]";
                string xpathExpressionToClick = "";


                xpathExpressionToParentRow = "//*[@id='" + gdvRoles.GetAttribute("id") + "']/tbody//td/span[text() [contains(.,'" + fn.testData["OldRoleName"].ToString() + "')]]//..//..//";

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(gdvRoles.GetAttribute("id"))));
                if (gdvRoles.Displayed)
                {

                    switch (act)
                    {
                        case ActionType.Edit:
                            {
                                if (gdvRoles.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                {
                                    xpathExpressionToClick = xpathExpressionToParentRow + "a[@id = 'btnEdit']";
                                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathExpressionToClick)));
                                    gdvRoles.FindElement(By.XPath(xpathExpressionToClick)).SendKeys(Keys.Return);

                                    
                                    xpathExpressionToEdit = "//*[@id='"+gdvRoles.GetAttribute("id")+"']/tbody//td/input[@value [contains(.,'"+ fn.testData["OldRoleName"].ToString() + "')]]";
                                    gdvRoles.FindElement(By.XPath(xpathExpressionToEdit)).Clear();
                                    gdvRoles.FindElement(By.XPath(xpathExpressionToEdit)).SendKeys(fn.testData["NewRoleName"].ToString());
                                    
                                    xpathExpressionToSelect = "//*[@id='" + gdvRoles.GetAttribute("id") + "']/tbody//td/select/option[text() [contains(.,'" + fn.testData["OldUserType"].ToString() + "')]]//..";
                                    SelectElement roleSelector = new SelectElement(gdvRoles.FindElement(By.XPath(xpathExpressionToSelect)));
                                    roleSelector.SelectByText(fn.testData["NewUserType"].ToString());
                                
                                    xpathExpressionToSave = xpathExpressionToEdit + "//..//../td/a[@id = 'btnSave']";
                                    gdvRoles.FindElement(By.XPath(xpathExpressionToSave)).Click();

                                }
                                break;
                            }
                        case ActionType.Delete:
                            {
                                
                                if (gdvRoles.FindElement(By.XPath(xpathExpressionToFind)).Exists())
                                {
                                    xpathExpressionToClick = xpathExpressionToParentRow + "a[@id='btnDelete']";

                                    gdvRoles.FindElement(By.XPath(xpathExpressionToClick)).Click();

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
        
        public void FillAddNewRole(Browser bro, DataRow dr)
        {
            try
            {
                //Default waiting 
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                txtTxtRoleName.SendKeys(dr["NewRoleName"].ToString());
                SelectElement ddlUserTypeSelector = new SelectElement(ddlUserType);
                ddlUserTypeSelector.SelectByText(dr["NewUserType"].ToString());

                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("BtnAddRole")));
                btnAddNewRole.Click();
            }
            catch (Exception ex) { }
        }
        
        public bool CheckAddRole(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }



        public bool CheckEditRole(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

        public bool CheckEnableRole(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }



        public bool CheckDisbleRole(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

        public bool CheckDeleteRole(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }
        public bool CheckSearchRole(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

        public bool CheckViewRole(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(gdvRoles.GetAttribute("id"))));
                return true;
            }
            catch (Exception ex) { return false; }

        }




    }


}