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
    public class QCAccountManagement
    {

        public enum ActionType { Edit, Delete,Disable ,Enable};


        [FindsBy(How = How.Id, Using = "drpStatus")]
        private IWebElement ddlDrpStatus;

        [FindsBy(How = How.Id, Using = "drpPaging")]
        private IWebElement ddlDrpPaging;

        [FindsBy(How = How.Id, Using = "gdvQCs")]
        private IWebElement GdvQCs;


        [FindsBy(How = How.Id, Using = "lnkBtn")]
        private IWebElement btnAddNewQCAccount;

        [FindsBy(How = How.Id, Using = "txtQCArName")]
        private IWebElement txtQCArName;

        [FindsBy(How = How.Id, Using = "txtQCShArName")]
        private IWebElement txtQCShArName;

        [FindsBy(How = How.Id, Using = "txtQCEnName")]
        private IWebElement txtQCEnName;

        [FindsBy(How = How.Id, Using = "txtQCEnShName")]
        private IWebElement txtQCEnShName;

        [FindsBy(How = How.Id, Using = "txtQCMOINum")]
        private IWebElement txtQCMOINum;

        [FindsBy(How = How.Id, Using = "txtQCCCNum")]
        private IWebElement txtQCCCNum;

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_gmdQCCGrg_txtDate")]
        private IWebElement txtCRGregorianIssueDate;

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_gmdQCCCHijri_txtDate")]
        private IWebElement txtCRHijriIssueDate;

        [FindsBy(How = How.Id, Using = "dropRegion")]
        private IWebElement ddlDropRegion;

        [FindsBy(How = How.Id, Using = "dropCity")]
        private IWebElement ddlDropCity;

        [FindsBy(How = How.XPath, Using = "(//span[text()[contains(.,'Next')]]/..)[1]")]
        private IWebElement btnNextPage1;

        [FindsBy(How = How.XPath, Using = "(//span[text()[contains(.,'Next')]]/..)[2]")]
        private IWebElement btnNextPage2;

        [FindsBy(How = How.XPath, Using = "(//span[text()[contains(.,'Next')]]/..)[3]")]
        private IWebElement btnNextPage3;

        [FindsBy(How = How.XPath, Using = "(//span[text()[contains(.,'Next')]]/..)[4]")]
        private IWebElement btnNextPage4;

        [FindsBy(How = How.XPath, Using = "//span[text()[contains(.,'Next')]]/..")]
        private IWebElement btnNext;


        [FindsBy(How = How.Id, Using = "txtQCAddress")]
        private IWebElement txtQCAddress;

        [FindsBy(How = How.Id, Using = "txtQCEmail")]
        private IWebElement txtQCEmail;

        [FindsBy(How = How.Id, Using = "txtQCPhoneNum")]
        private IWebElement txtQCPhoneNum;

        [FindsBy(How = How.Id, Using = "txtQCFaxNum")]
        private IWebElement txtQCFaxNum;

        [FindsBy(How = How.Id, Using = "txtWebSite")]
        private IWebElement txtWebSite;

        [FindsBy(How = How.Id, Using = "txtSMSCAlertNum")]
        private IWebElement txtSMSCAlertNum;

        [FindsBy(How = How.Id, Using = "txtAlertEmail")]
        private IWebElement txtAlertEmail;

        [FindsBy(How = How.XPath, Using = "//span[text()[contains(.,'Next')]]/..")]
        private IWebElement btnNext2;

        [FindsBy(How = How.Id, Using = "txtContactName")]
        private IWebElement txtContactName;

        [FindsBy(How = How.Id, Using = "txtContactMobile")]
        private IWebElement txtContactMobile;

        [FindsBy(How = How.Id, Using = "txtContactPhone")]
        private IWebElement txtContactPhone;

        [FindsBy(How = How.Id, Using = "txtContactJobTitle")]
        private IWebElement txtContactJobTitle;

        [FindsBy(How = How.Id, Using = "txtContactManagerName")]
        private IWebElement txtContactManagerName;

        [FindsBy(How = How.Id, Using = "txtContactManagerMobile")]
        private IWebElement txtContactManagerMobile;

        [FindsBy(How = How.Id, Using = "txtContactManagerPhone")]
        private IWebElement txtContactManagerPhone;

        [FindsBy(How = How.Id, Using = "txtContactManagerEmail")]
        private IWebElement txtContactManagerEmail;

        [FindsBy(How = How.Id, Using = "txtManagerName")]
        private IWebElement txtManagerName;

        [FindsBy(How = How.Id, Using = "txtManagerMobile")]
        private IWebElement txtManagerMobile;

        [FindsBy(How = How.Id, Using = "txtManagerPhone")]
        private IWebElement txtManagerPhone;

        [FindsBy(How = How.XPath, Using = "//span[text()[contains(.,'Next')]]/..")]
        private IWebElement btnNext3;

        [FindsBy(How = How.Id, Using = "HosList")]
        private IWebElement ddlHosList;

        [FindsBy(How = How.Id, Using = "btnAddHospital")]
        private IWebElement btnAddHospital;

        [FindsBy(How = How.Id, Using = "btnRemoveHospital")]
        private IWebElement btnRemoveHospital;

        [FindsBy(How = How.Id, Using = "Allowed")]
        private IWebElement ddlAllowed;
               

        [FindsBy(How = How.Id, Using = "lnkbtnsave")]
        private IWebElement btnsave;

        [FindsByAll]
        [FindsBy(How = How.TagName,Using = "span",Priority = 0)]
        [FindsBy(How = How.Id, Using = "lblSuccess", Priority = 1)]
        private IWebElement chkAddSuccess;


        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "span", Priority = 0)]
        [FindsBy(How = How.Id, Using = "lblSuccess", Priority = 1)]
        private IWebElement chkEditSuccess;
        
        //Search Account

        [FindsBy(How = How.Id, Using = "MOIValidator")]
        private IWebElement chkMOIValidator;

        public void DisplayListOfQCAccounts(FunctionParameters fn)
        {
            DataTable dt = new DataTable();
            dt = DataManager.GetExcelDataTable("select top 1 * from [QCAccountManagement$] where RowID=" + fn.RowNo);
            FillDisplayListForm(fn.WebBrowser, dt.Rows[0]);
        }

        public void FillDisplayListForm(Browser bro, DataRow dr)
        {
            WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));

            SelectElement ddlDrpStatusSelector = new SelectElement(ddlDrpStatus);
            SelectElement ddlDrpPagingSelector = new SelectElement(ddlDrpPaging);

            ddlDrpStatusSelector.SelectByText(dr["AccountStatus"].ToString());
            //wait.Until(ExpectedConditions.ElementIsVisible(By.Name("ctl00$ContentPlaceHolder1$drpPaging")));
            ddlDrpPagingSelector.SelectByText(dr["PageSize"].ToString());
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("gdvQCs")));

        }
        
        #region CheckPoints
        public bool CheckAddNewQCAccountSuccess(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "AddNewQCAccount";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
            
        }
        public bool CheckEditQCAccountSuccess(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "EditQCAccount";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);            
         }
        
        public bool CheckDeleteQCAccountSuccess(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "DeleteQCAccount";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
            
        }

        public bool CheckDeleteQCAccountInUse(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "DeleteQCAccountInUse";
                fn.ExpectedResult = "Account could not be deleted because it is still being used";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
                       
        }

        public bool CheckDisableQCAccountSuccess(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "DisableQCAccount";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);           
            
        }

        public bool CheckEnableQCAccountSuccess(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "EnableQCAccount";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);

        }


        public bool CheckAddNewQCAccount_MOIAlreadyExist(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "AddNewQCAccount_MOIAlreadyExist";
                fn.ExpectedResult = "already exist";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
            
        }

        public bool CheckAddNewQCAccount_InvalidMOI(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "AddNewQCAccount_InvalidMOI";
                fn.ExpectedResult = "Invalid MOI number";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
            
        }

        public bool CheckListQCAccount()
        {
            if (GdvQCs.Exists())
            {
                if (GdvQCs.Displayed)
                    return true;
                else
                    return false;
            }
            else return false;
        }
        #endregion

        public void EditQCAccount(FunctionParameters fn)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DataManager.GetExcelDataTable("select top 1 * from ["+fn.SheetName+"$] where RowID=" + fn.RowNo);
                FillEditQCAccountPage1(fn.WebBrowser, dt.Rows[0]);
                FillEditQCAccountPage2(fn.WebBrowser, dt.Rows[0]);
                FillEditQCAccountPage3(fn.WebBrowser, dt.Rows[0]);
                FillEditQCAccountPage4(fn.WebBrowser, dt.Rows[0]);
                //Update sheet with new values
                DataManager.UpdateExcelSheet(fn.testData.Table, fn.SheetName, "RowID=" + fn.RowNo);
            }
            catch (Exception ex) {  Logger.Log(ex.Message); }
        }

        public void SearchQCAccount(FunctionParameters fn)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DataManager.GetExcelDataTable("select top 1 * from [QCAccountManagement$] where RowID=" + fn.RowNo);
                SelectElement ddlDrpStatusSelector = new SelectElement(ddlDrpStatus);
                ddlDrpStatusSelector.SelectByText(dt.Rows[0]["AccountStatus"].ToString());
                SelectElement ddlDrpPagingSelector = new SelectElement(ddlDrpPaging);
                ddlDrpPagingSelector.SelectByText(dt.Rows[0]["PageSize"].ToString());

                if (GdvQCs.Displayed)
                {
                    if (GdvQCs.FindElement(By.XPath("//td[text()[contains(.,'" + dt.Rows[0]["QCMOINum"].ToString() + "')]]")).Displayed)
                    {

                        GdvQCs.FindElement(By.XPath("//*[@id='gdvQCs']/tbody//td[text() [contains(.,'" + dt.Rows[0]["QCMOINum"].ToString() + "')]]/..//a[@id='imgBtnEdit']")).Click();
                    }
                }
            }
            catch (Exception ex) { }
        }

        public void SearchQCAccount(FunctionParameters fn,ActionType act)
        {
            try
            {

                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
               

                SelectElement ddlDrpStatusSelector = new SelectElement(ddlDrpStatus);
                ddlDrpStatusSelector.SelectByText(fn.testData["AccountStatus"].ToString());


                By byVal = By.XPath("//select/option[text()='" + fn.testData["PageSize"].ToString() + "']");
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(byVal));

                SelectElement ddlDrpPagingSelector = new SelectElement(ddlDrpPaging);
                ddlDrpPagingSelector.SelectByText(fn.testData["PageSize"].ToString());
                string xpathToParentRow = "";
                xpathToParentRow = "//td[text()[contains(.,'" + fn.testData["QCMOINum"].ToString() + "')]]";

                if (GdvQCs.Displayed)
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpathToParentRow)));
                    switch (act)
                    {
                        case ActionType.Edit:
                            {
                                if (GdvQCs.FindElement(By.XPath("//td[text()[contains(.,'" + fn.testData["QCMOINum"].ToString() + "')]]")).Displayed)
                                {

                                    GdvQCs.FindElement(By.XPath("//*[@id='gdvQCs']/tbody//td[text() [contains(.,'" + fn.testData["QCMOINum"].ToString() + "')]]/..//a[@id='imgBtnEdit']")).Click();
                                }
                                break;
                            }
                        case ActionType.Delete:
                            {
                                if (GdvQCs.FindElement(By.XPath("//td[text()[contains(.,'" + fn.testData["QCMOINum"].ToString() + "')]]")).Displayed)
                                {

                                    GdvQCs.FindElement(By.XPath("//*[@id='gdvQCs']/tbody//td[text() [contains(.,'" + fn.testData["QCMOINum"].ToString() + "')]]/..//a[@id='imgBtnDelete']")).Click();
                                }
                                break;
                            }
                        case ActionType.Enable:
                            {
                                if (GdvQCs.FindElement(By.XPath("//td[text()[contains(.,'" + fn.testData["QCMOINum"].ToString() + "')]]")).Displayed)
                                {
                                    wait.Until(ExpectedConditions.ElementToBeClickable(GdvQCs.FindElement(By.XPath("//*[@id='gdvQCs']/tbody//td[text() [contains(.,'" + fn.testData["QCMOINum"].ToString() + "')]]/..//a[@id='imgBtnActive']"))));                                    
                                    GdvQCs.FindElement(By.XPath("//*[@id='gdvQCs']/tbody//td[text() [contains(.,'" + fn.testData["QCMOINum"].ToString() + "')]]/..//a[@id='imgBtnActive']")).Click();
                                }
                                break;
                            }
                        case ActionType.Disable:
                            {
                                if (GdvQCs.FindElement(By.XPath("//td[text()[contains(.,'" + fn.testData["QCMOINum"].ToString() + "')]]")).Displayed)
                                {

                                    GdvQCs.FindElement(By.XPath("//*[@id='gdvQCs']/tbody//td[text() [contains(.,'" + fn.testData["QCMOINum"].ToString() + "')]]/..//a[@id='imgBtnActive']")).Click();
                                }
                                break;
                            }
                    }
                    
                }
            }
            catch (Exception ex) { }
        }

        public void AddNewQCAccount(FunctionParameters fn)
        {
            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }

                btnAddNewQCAccount.Click();

                ProcessAddNewQCAccountPage1(fn.testData);
                FillAddNewQCAccountPage1(fn.WebBrowser, fn.testData);

                ProcessAddNewQCAccountPage2(fn.testData);
                FillAddNewQCAccountPage2(fn.WebBrowser, fn.testData);

                ProcessAddNewQCAccountPage3(fn.testData);
                FillAddNewQCAccountPage3(fn.WebBrowser, fn.testData);
                FillAddnewQCAccountPage4(fn.WebBrowser, fn.testData);

                //Update sheet with new values
                DataManager.UpdateExcelSheet(fn.testData.Table, fn.SheetName, "RowID=" + fn.RowNo);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
        }


        public void DeleteQCAccount(FunctionParameters fn)
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

        private void ProcessAddNewQCAccountPage1(DataRow dr)
        {
            try
            {
                //In case column is Auto, auto generate value
                dr["QCArName"] = (dr["QCArName"].ToString().ToLower() == "auto" ? "اوتو " + Faker.Name.ArabicName() : dr["QCArName"]);
                dr["QCShArName"] = (dr["QCShArName"].ToString().ToLower() == "auto" ? "اوتو " + Faker.Name.ArabicName() : dr["QCShArName"]);
                dr["QCEnName"] = (dr["QCEnName"].ToString().ToLower() == "auto" ? "Auto " + Faker.Name.First() : dr["QCEnName"]);
                dr["QCEnShName"] = (dr["QCEnShName"].ToString().ToLower() == "auto" ? "Auto " + Faker.Name.First() : dr["QCEnShName"]);
                dr["QCCCNum"] = (dr["QCCCNum"].ToString().ToLower() == "auto" ? Faker.RandomNumber.Next(10000,99999): dr["QCCCNum"]);
                dr["GregorianIssueDate"] = (dr["GregorianIssueDate"].ToString().ToLower() == "auto" ? DateTime.Now.ToString("dd/MM/yyyy") : dr["GregorianIssueDate"]);
                dr["HijriIssueDate"] = (dr["HijriIssueDate"].ToString().ToLower() == "auto" ? DBOperations.GetTodayHijriDate() : dr["HijriIssueDate"]);
               
            }
            catch (Exception ex) { }
        }

        private void ProcessAddNewQCAccountPage2(DataRow dr)
        {
                try
                {
                    //In case column is Auto, auto generate value
                    dr["QCAddress"] = (dr["QCAddress"].ToString().ToLower() == "auto" ?  Faker.Address.SaudiCitis() : dr["QCAddress"]);
                    dr["QCEmail"] = (dr["QCEmail"].ToString().ToLower() == "auto" ?  Faker.Internet.Email() : dr["QCEmail"]);
                    dr["QCPhoneNum"] = (dr["QCPhoneNum"].ToString().ToLower() == "auto" ?  Faker.Phone.Number("011#######") : dr["QCPhoneNum"]);
                    dr["QCFaxNum"] = (dr["QCFaxNum"].ToString().ToLower() == "auto" ? Faker.Phone.Number("011#######") : dr["QCFaxNum"]);
                    dr["WebSite"] = (dr["WebSite"].ToString().ToLower() == "auto" ?  Faker.Internet.Url(): dr["WebSite"]);
                    dr["SMSCAlertNum"] = (dr["SMSCAlertNum"].ToString().ToLower() == "auto" ? Faker.Phone.Number("9665########") : dr["SMSCAlertNum"]);
                    dr["AlertEmail"] = (dr["AlertEmail"].ToString().ToLower() == "auto" ? Faker.Internet.Email() : dr["AlertEmail"]);
                    
                }
                catch (Exception ex) { }
                
           
        }

        private void ProcessAddNewQCAccountPage3(DataRow dr)
        {
            try
            {
                try
                {
                    //In case column is Auto, auto generate value
                    dr["ContactName"] = (dr["ContactName"].ToString().ToLower() == "auto" ? Faker.Name.First() : dr["ContactName"]);
                    dr["ContactMobile"] = (dr["ContactMobile"].ToString().ToLower() == "auto" ? Faker.Phone.Number("9665########") : dr["ContactMobile"]);
                    dr["ContactPhone"] = (dr["ContactPhone"].ToString().ToLower() == "auto" ? Faker.Phone.Number("011#######") : dr["ContactPhone"]);
                    dr["ContactJobTitle"] = (dr["ContactJobTitle"].ToString().ToLower() == "auto" ? Faker.Name.FullName() : dr["ContactJobTitle"]);
                    dr["ContactManagerName"] = (dr["ContactManagerName"].ToString().ToLower() == "auto" ? Faker.Name.FullName() : dr["ContactManagerName"]);
                    dr["ContactManagerMobile"] = (dr["ContactManagerMobile"].ToString().ToLower() == "auto" ? Faker.Phone.Number("9665########") : dr["ContactManagerMobile"]);
                    dr["ContactManagerPhone"] = (dr["ContactManagerPhone"].ToString().ToLower() == "auto" ? Faker.Phone.Number("011#######") : dr["ContactManagerPhone"]);
                    dr["ContactManagerEmail"] = (dr["ContactManagerEmail"].ToString().ToLower() == "auto" ? Faker.Internet.Email() : dr["ContactManagerEmail"]);
                    dr["ManagerName"] = (dr["ManagerName"].ToString().ToLower() == "auto" ? Faker.Name.FullName() : dr["ManagerName"]);
                    dr["ManagerMobile"] = (dr["ManagerMobile"].ToString().ToLower() == "auto" ? Faker.Phone.Number("9665########") : dr["ManagerMobile"]);
                    dr["ManagerPhone"] = (dr["ManagerPhone"].ToString().ToLower() == "auto" ? Faker.Phone.Number("011#######") : dr["ManagerPhone"]);

                }
                catch (Exception ex) { }

            }
            catch (Exception ex) { }
            
        }

        private void ClearFields()
        {
            ClearPage1Fields();
            ClearPage2Fields();
            ClearPage3Fields();
        }

        private void ClearPage3Fields()
        {
            try
            {
                txtContactName.Clear();
                txtContactMobile.Clear();
                txtContactPhone.Clear();
                txtContactJobTitle.Clear();
                txtContactManagerName.Clear();
                txtContactManagerMobile.Clear();
                txtContactManagerPhone.Clear();
                txtContactManagerEmail.Clear();
                txtManagerName.Clear();
                txtManagerMobile.Clear();
                txtManagerPhone.Clear();
            }
            catch (Exception ex) { File.AppendAllText("Log.txt", ex.Message); }
        }

        private void ClearPage2Fields()
        {
            try
            {
               
                txtQCAddress.Clear();
                txtQCEmail.Clear();
                txtQCPhoneNum.Clear();
                txtQCFaxNum.Clear();
                txtWebSite.Clear();
                txtSMSCAlertNum.Clear();
                txtAlertEmail.Clear();

            }
            catch (Exception ex) { File.AppendAllText("Log.txt", ex.Message); }
        }

        private void ClearPage1Fields()
        {
            try
            {
                txtQCArName.Clear();
                txtQCShArName.Clear();
                txtQCEnName.Clear();
                txtQCEnShName.Clear();
                txtQCCCNum.Clear();
                txtCRGregorianIssueDate.Clear();
                txtCRHijriIssueDate.Clear();
                
            }
            catch (Exception ex) { File.AppendAllText("Log.txt", ex.Message); }
        }

        public void FillAddNewQCAccountPage1(Browser bro, DataRow dr)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("ctl00$ContentPlaceHolder1$txtQCArName")));

                txtQCArName.SendKeys(dr["QCArName"].ToString());
                txtQCShArName.SendKeys(dr["QCShArName"].ToString());
                txtQCEnName.SendKeys(dr["QCEnName"].ToString());
                txtQCEnShName.SendKeys(dr["QCEnShName"].ToString());
                txtQCMOINum.SendKeys(dr["QCMOINum"].ToString());
                txtQCCCNum.SendKeys(dr["QCCCNum"].ToString());
                txtCRGregorianIssueDate.SendKeys(dr["GregorianIssueDate"].ToString());
                txtCRHijriIssueDate.SendKeys(dr["HijriIssueDate"].ToString());
                txtQCArName.Click();
                SelectElement ddlDropRegionSelector = new SelectElement(ddlDropRegion);
                ddlDropRegionSelector.SelectByText(dr["Region"].ToString());
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("ctl00$ContentPlaceHolder1$dropCity")));
                SelectElement ddlDropCitySelector = new SelectElement(ddlDropCity);
                By byVal = By.XPath("//select/option[text()='" + dr["City"].ToString() + "']");
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(byVal));
                ddlDropCitySelector.SelectByText(dr["City"].ToString());
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("ctl00$ContentPlaceHolder1$dropCity")));
                btnNextPage1.Click();
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
        }

        public void FillEditQCAccountPage1(Browser bro, DataRow dr)
        {
            try
            {
                ClearPage1Fields();
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("ctl00$ContentPlaceHolder1$txtQCArName")));

                txtQCArName.SendKeys(dr["QCArName"].ToString());
                txtQCShArName.SendKeys(dr["QCShArName"].ToString());
                txtQCEnName.SendKeys(dr["QCEnName"].ToString());
                txtQCEnShName.SendKeys(dr["QCEnShName"].ToString());
                txtQCMOINum.SendKeys(dr["QCMOINum"].ToString());
                txtQCCCNum.SendKeys(dr["QCCCNum"].ToString());
                txtCRGregorianIssueDate.SendKeys(dr["GregorianIssueDate"].ToString());
                txtCRHijriIssueDate.SendKeys(dr["HijriIssueDate"].ToString());
                txtQCArName.Click();
                SelectElement ddlDropRegionSelector = new SelectElement(ddlDropRegion);
                ddlDropRegionSelector.SelectByText(dr["Region"].ToString());
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("ctl00$ContentPlaceHolder1$dropCity")));
                SelectElement ddlDropCitySelector = new SelectElement(ddlDropCity);
                By byVal = By.XPath("//select/option[text()='" + dr["City"].ToString() + "']");
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(byVal));
                ddlDropCitySelector.SelectByText(dr["City"].ToString());
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("ctl00$ContentPlaceHolder1$dropCity")));
                btnNextPage1.Click();
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
        }

        public void FillAddNewQCAccountPage2(Browser bro, DataRow dr)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                txtQCAddress.SendKeys(dr["QCAddress"].ToString());
                txtQCEmail.SendKeys(dr["QCEmail"].ToString());
                txtQCPhoneNum.SendKeys(dr["QCPhoneNum"].ToString());
                txtQCFaxNum.SendKeys(dr["QCFaxNum"].ToString());
                txtWebSite.SendKeys(dr["WebSite"].ToString());
                txtSMSCAlertNum.SendKeys(dr["SMSCAlertNum"].ToString());
                txtAlertEmail.SendKeys(dr["AlertEmail"].ToString());
                btnNextPage2.SendKeys(Keys.Return);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            //ClickNextButton(bro.WebDriver);
            // btnNext.Click();
        }

        public void FillEditQCAccountPage2(Browser bro, DataRow dr)
        {
            try
            {
                ClearPage2Fields();
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                txtQCAddress.SendKeys(dr["QCAddress"].ToString());
                txtQCEmail.SendKeys(dr["QCEmail"].ToString());
                txtQCPhoneNum.SendKeys(dr["QCPhoneNum"].ToString());
                txtQCFaxNum.SendKeys(dr["QCFaxNum"].ToString());
                txtWebSite.SendKeys(dr["WebSite"].ToString());
                txtSMSCAlertNum.SendKeys(dr["SMSCAlertNum"].ToString());
                txtAlertEmail.SendKeys(dr["AlertEmail"].ToString());
                btnNextPage2.SendKeys(Keys.Return);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            //ClickNextButton(bro.WebDriver);
            // btnNext.Click();
        }

        private void ClickNextButton(IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath("//span[text()[contains(.,'Next')]]/..")).Click();
            }
            catch (Exception ex) { }
        }

        public void FillAddNewQCAccountPage3(Browser bro, DataRow dr)
        {
            try
            {
                txtContactName.SendKeys(dr["ContactName"].ToString());
                txtContactMobile.SendKeys(dr["ContactMobile"].ToString());
                txtContactPhone.SendKeys(dr["ContactPhone"].ToString());
                txtContactJobTitle.SendKeys(dr["ContactJobTitle"].ToString());
                txtContactManagerName.SendKeys(dr["ContactManagerName"].ToString());
                txtContactManagerMobile.SendKeys(dr["ContactManagerMobile"].ToString());
                txtContactManagerPhone.SendKeys(dr["ContactManagerPhone"].ToString());
                txtContactManagerEmail.SendKeys(dr["ContactManagerEmail"].ToString());
                txtManagerName.SendKeys(dr["ManagerName"].ToString());
                txtManagerMobile.SendKeys(dr["ManagerMobile"].ToString());
                txtManagerPhone.SendKeys(dr["ManagerPhone"].ToString());
                btnNextPage3.SendKeys(Keys.Return);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }

        }

        public void FillEditQCAccountPage3(Browser bro, DataRow dr)
        {
            try
            {
                ClearPage3Fields();
                txtContactName.SendKeys(dr["ContactName"].ToString());
                txtContactMobile.SendKeys(dr["ContactMobile"].ToString());
                txtContactPhone.SendKeys(dr["ContactPhone"].ToString());
                txtContactJobTitle.SendKeys(dr["ContactJobTitle"].ToString());
                txtContactManagerName.SendKeys(dr["ContactManagerName"].ToString());
                txtContactManagerMobile.SendKeys(dr["ContactManagerMobile"].ToString());
                txtContactManagerPhone.SendKeys(dr["ContactManagerPhone"].ToString());
                txtContactManagerEmail.SendKeys(dr["ContactManagerEmail"].ToString());
                txtManagerName.SendKeys(dr["ManagerName"].ToString());
                txtManagerMobile.SendKeys(dr["ManagerMobile"].ToString());
                txtManagerPhone.SendKeys(dr["ManagerPhone"].ToString());
                btnNextPage3.SendKeys(Keys.Return);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }

        }

        public void FillAddnewQCAccountPage4(Browser bro, DataRow dr)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                SelectElement ddlHosListSelector = new SelectElement(ddlHosList);
                //ddlHosListSelector.SelectByText(dr["HospitalList"].ToString());
                ddlHosListSelector.SelectByIndex(1);
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnAddHospital")));
                btnAddHospital.Click();
                Common.ExplicitWait(5);
                try
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(btnNextPage4));
                    btnNextPage4.Click();
                }
                catch (Exception ex) { btnNextPage4.SendKeys(Keys.Return); }
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(btnsave.GetAttribute("id"))));
                btnsave.Click();
            }
            catch (Exception ex) { Logger.Log(ex.Message); }

        }

        public void FillEditQCAccountPage4(Browser bro, DataRow dr)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                SelectElement ddlHosListSelector = new SelectElement(ddlHosList);
                //ddlHosListSelector.SelectByText(dr["HospitalList"].ToString());
                ddlHosListSelector.SelectByIndex(1);
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnAddHospital")));
                btnAddHospital.Click();
                Common.ExplicitWait(5);
                btnNextPage4.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lnkbtnsave")));
                btnsave.Click();
            }
            catch (Exception ex) { Logger.Log(ex.Message); }

        }

        public void GoTo(Browser bro)
        {
            bro.WebDriver.Url = "https://192.168.41.22/EMC.UI/QCs/QCList.aspx";
            bro.WebDriver.Navigate();
        }

    }
}
