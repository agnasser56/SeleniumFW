using System;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.IO;
using OpenQA.Selenium.Support.UI;
namespace SeleniumFramework
{
    public class ClientManagement
    {
        public enum ActionType { Edit, Delete, Enable,Disable,View };

        [FindsBy(How = How.Id, Using = "lnkBtn")]
        private IWebElement btnAddNewClient;

        [FindsBy(How = How.Id, Using = "txtClientArName")]
        private IWebElement txtClientArName;

        [FindsBy(How = How.Id, Using = "txtClientShArName")]
        private IWebElement txtClientShArName;

        [FindsBy(How = How.Id, Using = "txtClientEnName")]
        private IWebElement txtClientEnName;

        [FindsBy(How = How.Id, Using = "txtClientEnShName")]
        private IWebElement txtClientEnShName;

        [FindsBy(How = How.Id, Using = "dropSectorType")]
        private IWebElement ddlDropSectorType;

        [FindsBy(How = How.Id, Using = "txtClientMOINum")]
        private IWebElement txtClientMOINum;

        [FindsBy(How = How.Id, Using = "txtClientCCNum")]
        private IWebElement txtClientCCNum;

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_gmdClientCGrg_txtDate")]
        private IWebElement txtGregorianIssueDate;

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_gmdClientCCHijri_txtDate")]
        private IWebElement txtHijriIssueDate;

        [FindsBy(How = How.Id, Using = "dropRegion")]
        private IWebElement ddlDropRegion;

        [FindsBy(How = How.Id, Using = "dropCity")]
        private IWebElement ddlDropCity;

        [FindsBy(How = How.XPath, Using = "//span[text()[contains(.,'Next')]]/..")]
        private IWebElement btnNext;

        [FindsBy(How = How.XPath, Using = "(//span[text()[contains(.,'Next')]]/..)[1]")]
        private IWebElement btnNextPage1;

        
        //Page 2
        [FindsBy(How = How.Id, Using = "txtClientAddress")]
        private IWebElement txtClientAddress;

        [FindsBy(How = How.Id, Using = "txtClientEmail")]
        private IWebElement txtClientEmail;

        [FindsBy(How = How.Id, Using = "txtClientPhoneNum")]
        private IWebElement txtClientPhoneNum;

        [FindsBy(How = How.Id, Using = "txtClientFaxNum")]
        private IWebElement txtClientFaxNum;

        [FindsBy(How = How.Id, Using = "txtWebSite")]
        private IWebElement txtWebSite;

        [FindsBy(How = How.Id, Using = "txtSMSCAlertNum")]
        private IWebElement txtSMSCAlertNum;

        [FindsBy(How = How.Id, Using = "txtAlertEmail")]
        private IWebElement txtAlertEmail;

        [FindsBy(How = How.XPath, Using = "(//span[text()[contains(.,'Next')]]/..)[2]")]
        private IWebElement btnNextPage2;


        //Page 3
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

        [FindsBy(How = How.XPath, Using = "(//span[text()[contains(.,'Next')]]/..)[3]")]
        private IWebElement btnNextPage3;
        //Page 4
        [FindsBy(How = How.Id, Using = "rbtnlCertificatesDeliveryStatus_0")]
        private IWebElement rdbCertificatesDeliveryStatus_0;

        [FindsBy(How = How.Id, Using = "rbtnlCertificatesDeliveryStatus_1")]
        private IWebElement rdbCertificatesDeliveryStatus_1;

        [FindsBy(How = How.Id, Using = "rbtnlCertificatesDeliveryType_0")]
        private IWebElement rdbCertificatesDeliveryType_0;

        [FindsBy(How = How.Id, Using = "rbtnlCertificatesDeliveryType_1")]
        private IWebElement rdbCertificatesDeliveryType_1;

        [FindsBy(How = How.Id, Using = "rbtnlCertificatesDeliveryMode_0")]
        private IWebElement rdbCertificatesDeliveryMode_0;

        [FindsBy(How = How.Id, Using = "rbtnlCertificatesDeliveryMode_1")]
        private IWebElement rdbCertificatesDeliveryMode_1;

        [FindsBy(How = How.Id, Using = "txtWebServiceUrl")]
        private IWebElement txtWebServiceUrl;

        [FindsBy(How = How.Id, Using = "txtWebServiceDomain")]
        private IWebElement txtWebServiceDomain;

        [FindsBy(How = How.Id, Using = "txtWebServiceUserName")]
        private IWebElement txtWebServiceUserName;

        [FindsBy(How = How.Id, Using = "txtWebServicePassword")]
        private IWebElement txtWebServicePassword;

        [FindsBy(How = How.Id, Using = "txtConfirmWebServicePassword")]
        private IWebElement txtConfirmWebServicePassword;

        [FindsBy(How = How.XPath, Using = "//span[@id='Label8']//..")]
        private IWebElement btnNextPage4;

        
        //page 5

        [FindsBy(How = How.Id, Using = "lnkbtnsave")]
        private IWebElement btnsave;

        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "span", Priority = 0)]
        [FindsBy(How = How.Id, Using = "lblSuccess", Priority = 1)]
        private IWebElement chkAddSuccess;

        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "span", Priority = 0)]
        [FindsBy(How = How.Id, Using = "lblSuccessMsg", Priority = 1)]
        private IWebElement chkCertficateSuccess;

        [FindsBy(How = How.Id, Using = "TabContainer2_header")]
        private IWebElement chkViewClient;
        

        //Search Client
        [FindsBy(How = How.Id, Using = "txtMOINumber")]
        private IWebElement txtMOINumber;

        [FindsBy(How = How.Id, Using = "txtClientName")]
        private IWebElement txtClientName;

        [FindsBy(How = How.Id, Using = "drpStatus")]
        private IWebElement ddlDrpStatus;
        
        [FindsBy(How = How.Id, Using = "drpPaging")]
        private IWebElement ddlDrpPaging;
        
        [FindsBy(How = How.Id, Using = "btnShow")]
        private IWebElement btnBtnShow;

        [FindsBy(How = How.Id, Using = "gdvClients")]
        private IWebElement gdvClients;

       
        

        //Hosptial Certificates
        [FindsBy(How = How.Id, Using = "ddlCertificate")]
        private IWebElement ddlCertificate;
        
        [FindsBy(How = How.Id, Using = "txtboxPrice")]
        private IWebElement txtPrice;

        [FindsBy(How = How.Id, Using = "rdioHospitals_0")]
        private IWebElement rdbAllHospitals_0;

        [FindsBy(How = How.Id, Using = "rdioHospitals_1")]
        private IWebElement rdbSpecificHospitals_1;

        [FindsBy(How = How.Id, Using = "txtBoxHospital")]
        private IWebElement txtHospitalName;

        [FindsBy(How = How.Id, Using = "txtboxMOINo")]
        private IWebElement txtHospitalMOINo;

        [FindsBy(How = How.Id, Using = "chkRow")]
        private IWebElement chkHospital;

        [FindsBy(How = How.Id, Using = "btnAdd")]
        private IWebElement btnBtnAdd;


        //Client Certificats page
        [FindsBy(How = How.Id, Using = "GVHospitals")]
        private IWebElement gdvHospitals;

        [FindsBy(How = How.Id, Using = "DDLCertificate2")]
        private IWebElement ddlCertificateToRemove;
        
        [FindsBy(How = How.Id, Using = "txtboxHospital2")]
        private IWebElement txtHospitalToRemoveCertificate;

        [FindsBy(How = How.Id, Using = "btnShow2")]
        private IWebElement btnShow2;

        [FindsBy(How = How.Id, Using = "gvIncludedCertificate")]
        private IWebElement gvIncludedCertificate;


        //Client Sick Leave page
        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "span", Priority = 0)]
        [FindsBy(How = How.Id, Using = "__tab_TabSickLeaves", Priority = 1)]
        private IWebElement tabClientSickLeaves;

        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "span", Priority = 0)]
        [FindsBy(How = How.Id, Using = "MyAccountLabel", Priority = 1)]
        private IWebElement btnMyAccount;


        [FindsBy(How = How.Id, Using = "txtFullName")]
        private IWebElement txtHospitalFullName;

        [FindsBy(How = How.Id, Using = "gvNotAssociatedHospitals")]
        private IWebElement gdvNotAssociatedHospitals;


        
        [FindsBy(How = How.Id, Using = "btnSearch")]
        private IWebElement btnSearch;

        [FindsBy(How = How.Id, Using = "btnAssociateHospitalToClient")]
        private IWebElement btnAssociateHospitalToClient;

        [FindsBy(How = How.Id, Using = "txtFullnameForAsscoiated")]
        private IWebElement txtFullnameForAsscoiated;

        [FindsBy(How = How.Id, Using = "btnSearchAssociated")]
        private IWebElement btnSearchAssociated;

        [FindsBy(How = How.Id, Using = "gvAssociatedHospitals")]
        private IWebElement gdvAssociatedHospitals;

        [FindsBy(How = How.Id, Using = "btnRemoveAssociation")]
        private IWebElement btnRemoveAssociation;

   

        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "span", Priority = 0)]
        [FindsBy(How = How.Id, Using = "lblSuccessAssociate", Priority = 1)]
        private IWebElement chkSickLeaveSuccess;


        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "span", Priority = 0)]
        [FindsBy(How = How.Id, Using = "lblSuccessRemove", Priority = 1)]
        private IWebElement chkSickLeaveRemoveSuccess;

        #region Navigation
        public void GoTo(Browser bro)
        {
            bro.WebDriver.Url = "https://192.168.41.22/EMC.UI/Clients/ClientList.aspx";
            bro.WebDriver.Navigate();
        }

        public void GoToSickLeaves(Browser webBrowser)
        {
            tabClientSickLeaves.Click();

        }

        #endregion

        public void AddNewClient(FunctionParameters fn)
        {
            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }

                btnAddNewClient.Click();
                ProcessAddNewClientPage1(fn.testData);
                ProcessAddNewClientPage2(fn.testData);
                ProcessAddNewClientPage3(fn.testData);
                FillAddNewClientPage1(fn.WebBrowser, fn.testData);
                Common.ExplicitWait(3);
                FillAddNewClientPage2(fn.WebBrowser, fn.testData);
                Common.ExplicitWait(3);
                FillAddNewClientPage3(fn.WebBrowser, fn.testData);
                Common.ExplicitWait(3);
                FillAddNewClientPage4(fn.WebBrowser, fn.testData);
                Common.ExplicitWait(3);

                //Update sheet with new values
                DataManager.UpdateExcelSheet(fn.testData.Table, fn.SheetName, "RowID=" + fn.RowNo);
            }
            catch (Exception ex) { }
        }

        public void EditClient(FunctionParameters fn)
        {
            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                ClearFieldsPage1(fn);
                FillAddNewClientPage1(fn.WebBrowser, fn.testData);
                Common.ExplicitWait(3);
                ClearFieldsPage2(fn);
                FillAddNewClientPage2(fn.WebBrowser, fn.testData);
                Common.ExplicitWait(3);
                ClearFieldsPage3(fn);
                FillAddNewClientPage3(fn.WebBrowser, fn.testData);
                Common.ExplicitWait(3);
                ClearFieldsPage4(fn);
                FillAddNewClientPage4(fn.WebBrowser, fn.testData);
                Common.ExplicitWait(3);
                //Update sheet with new values
                DataManager.UpdateExcelSheet(fn.testData.Table, fn.SheetName, "RowID=" + fn.RowNo);
            }
            catch (Exception ex) { }
        }
        public void DeleteClientAccount(FunctionParameters fn)
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
        public void SearchClient(FunctionParameters fn, ActionType act)
        {
            try
            {
                DataTable dt = new DataTable();
                
                dt = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo);
                
                WebDriverWait wait = new WebDriverWait(fn.WebBrowser.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                txtMOINumber.SendKeys(dt.Rows[0]["ClientMOINum"].ToString());
                //txtClientName.SendKeys(dt.Rows[0]["ClientShArName"].ToString());
                //SelectElement ddlDrpStatusSelector = new SelectElement(ddlDrpStatus);
                //ddlDrpStatusSelector.SelectByText(dt.Rows[0]["ClientStatus"].ToString());
                
                btnBtnShow.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("gdvClients")));
                if (gdvClients.Displayed)
                {
                    switch (act)
                    {
                        case ActionType.Edit:
                            {
                                if (gdvClients.FindElement(By.XPath("//td[text()[contains(.,'" + dt.Rows[0]["ClientMOINum"].ToString() + "')]]")).Displayed)
                                {
                                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='gdvClients']/tbody//td[text() [contains(.,'" + dt.Rows[0]["ClientMOINum"].ToString() + "')]]/..//a[@id='imgBtnEdit']")));
                                    gdvClients.FindElement(By.XPath("//*[@id='gdvClients']/tbody//td[text() [contains(.,'" + dt.Rows[0]["ClientMOINum"].ToString() + "')]]/..//a[@id='imgBtnEdit']")).Click();
                                }
                                break;
                            }
                        case ActionType.Delete:
                            {
                                if (gdvClients.FindElement(By.XPath("//td[text()[contains(.,'" + dt.Rows[0]["ClientMOINum"].ToString() + "')]]")).Displayed)
                                {

                                    gdvClients.FindElement(By.XPath("//*[@id='gdvClients']/tbody//td[text() [contains(.,'" + dt.Rows[0]["ClientMOINum"].ToString() + "')]]/..//a[@id='imgBtnDelete']")).Click();
                                }
                                break;
                            }
                        case ActionType.Disable:
                            {
                                if (gdvClients.FindElement(By.XPath("//td[text()[contains(.,'" + dt.Rows[0]["ClientMOINum"].ToString() + "')]]")).Displayed)
                                {

                                    gdvClients.FindElement(By.XPath("//*[@id='gdvClients']/tbody//td[text() [contains(.,'" + dt.Rows[0]["ClientMOINum"].ToString() + "')]]/..//a[@id='imgBtnActive']")).Click();
                                }
                                break;
                            }
                        case ActionType.Enable:
                            {
                                if (gdvClients.FindElement(By.XPath("//td[text()[contains(.,'" + dt.Rows[0]["ClientMOINum"].ToString() + "')]]")).Displayed)
                                {

                                    gdvClients.FindElement(By.XPath("//*[@id='gdvClients']/tbody//td[text() [contains(.,'" + dt.Rows[0]["ClientMOINum"].ToString() + "')]]/..//a[@id='imgBtnActive']")).Click();
                                }
                                break;
                            }
                        case ActionType.View:
                            {
                                if (gdvClients.FindElement(By.XPath("//td[text()[contains(.,'" + dt.Rows[0]["ClientMOINum"].ToString() + "')]]")).Displayed)
                                {

                                    gdvClients.FindElement(By.XPath("//*[@id='gdvClients']/tbody//td[text() [contains(.,'" + dt.Rows[0]["ClientMOINum"].ToString() + "')]]/..//a[@id='imgBtnClientCertificates']")).Click();
                                }
                                break;
                            }

                            
                    }

                   
                }


            }
            catch (Exception ex) { fn.Message = ex.Message; }
        }


        private void ProcessAddNewClientPage1(DataRow dr)
        {
            try
            {
                //In case column is Auto, auto generate value
                dr["ClientArName"] = (dr["ClientArName"].ToString().ToLower() == "auto" ? Faker.Name.ArabicName() : dr["ClientArName"]);
                dr["ClientShArName"] = (dr["ClientShArName"].ToString().ToLower() == "auto" ? Faker.Name.ArabicName() : dr["ClientShArName"]);
                dr["ClientEnName"] = (dr["ClientEnName"].ToString().ToLower() == "auto" ? Faker.Name.First() : dr["ClientEnName"]);
                dr["ClientEnShName"] = (dr["ClientEnShName"].ToString().ToLower() == "auto" ? Faker.Name.First() : dr["ClientEnShName"]);
                dr["ClientEnShName"] = (dr["ClientEnShName"].ToString().ToLower() == "auto" ? Faker.Name.First() : dr["ClientEnShName"]);
                dr["ClientCCNum"] = (dr["ClientCCNum"].ToString().ToLower() == "auto" ? Faker.RandomNumber.Next(10000, 99999) : dr["ClientCCNum"]);
                dr["GregorianIssueDate"] = (dr["GregorianIssueDate"].ToString().ToLower() == "auto" ? DateTime.Now.ToString("dd/MM/yyyy") : dr["GregorianIssueDate"]);
                dr["HijriIssueDate"] = (dr["HijriIssueDate"].ToString().ToLower() == "auto" ? DBOperations.GetTodayHijriDate() : dr["HijriIssueDate"]);

            }
            catch (Exception ex) { }
        }
        private void ProcessAddNewClientPage2(DataRow dr)
        {
            try
            {
                //In case column is Auto, auto generate value
                dr["ClientAddress"] = (dr["ClientAddress"].ToString().ToLower() == "auto" ? Faker.Address.StreetName() : dr["ClientAddress"]);
                dr["ClientEmail"] = (dr["ClientEmail"].ToString().ToLower() == "auto" ? Faker.Internet.Email() : dr["ClientEmail"]);
                dr["ClientPhoneNum"] = (dr["ClientPhoneNum"].ToString().ToLower() == "auto" ? Faker.Phone.Number("011#######") : dr["ClientPhoneNum"]);
                dr["ClientFaxNum"] = (dr["ClientFaxNum"].ToString().ToLower() == "auto" ? Faker.Phone.Number("011#######") : dr["ClientFaxNum"]);
                dr["WebSite"] = (dr["WebSite"].ToString().ToLower() == "auto" ? Faker.Internet.Url() : dr["WebSite"]);
                dr["SMSCAlertNum"] = (dr["SMSCAlertNum"].ToString().ToLower() == "auto" ? Faker.Phone.Number("9665########") : dr["SMSCAlertNum"]);
                dr["AlertEmail"] = (dr["AlertEmail"].ToString().ToLower() == "auto" ? Faker.Internet.Email() : dr["AlertEmail"]);               


            }
            catch (Exception ex) { }
        }
        private void ProcessAddNewClientPage3(DataRow dr)
        {
            try
            {
                //In case column is Auto, auto generate value
             
                dr["ContactName"] = (dr["ContactName"].ToString().ToLower() == "auto" ? Faker.Name.ArabicName() : dr["ContactName"]);
                dr["ContactMobile"] = (dr["ContactMobile"].ToString().ToLower() == "auto" ?Faker.Phone.Number("9665########") : dr["ContactMobile"]);
                dr["ContactPhone"] = (dr["ContactPhone"].ToString().ToLower() == "auto" ? Faker.Phone.Number("01########") : dr["ContactPhone"]);
                dr["ContactJobTitle"] = (dr["ContactJobTitle"].ToString().ToLower() == "auto" ? Faker.Name.Prefix()+Faker.Name.FullName(Faker.NameFormats.WithPrefix) : dr["ContactJobTitle"]);
                dr["ContactManagerName"] = (dr["ContactManagerName"].ToString().ToLower() == "auto" ? Faker.Name.First() : dr["ContactManagerName"]);
                dr["ContactManagerMobile"] = (dr["ContactManagerMobile"].ToString().ToLower() == "auto" ? Faker.Phone.Number("9665########") : dr["ContactManagerMobile"]);
                dr["ContactManagerPhone"] = (dr["ContactManagerPhone"].ToString().ToLower() == "auto" ? Faker.Phone.Number("01########") : dr["ContactManagerPhone"]);
                dr["ContactManagerEmail"] = (dr["ContactManagerEmail"].ToString().ToLower() == "auto" ? Faker.Internet.Email() : dr["ContactManagerEmail"]);
                dr["ManagerName"] = (dr["ManagerName"].ToString().ToLower() == "auto" ? Faker.Name.First() : dr["ManagerName"]);
                dr["ManagerMobile"] = (dr["ManagerMobile"].ToString().ToLower() == "auto" ? Faker.Phone.Number("9665########") : dr["ManagerMobile"]);
                dr["ManagerPhone"] = (dr["ManagerPhone"].ToString().ToLower() == "auto" ? Faker.Phone.Number("01########") : dr["ManagerPhone"]);
            }
            catch (Exception ex) { }
        }

       
        
        public void FillAddNewClientPage1(Browser bro, DataRow dr)
        {
            try
            {
                //Default waiting 
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                txtClientArName.SendKeys(dr["ClientArName"].ToString());
                txtClientShArName.SendKeys(dr["ClientShArName"].ToString());
                txtClientEnName.SendKeys(dr["ClientEnName"].ToString());
                txtClientEnShName.SendKeys(dr["ClientEnShName"].ToString());
                SelectElement ddlDropSectorTypeSelector = new SelectElement(ddlDropSectorType);
                ddlDropSectorTypeSelector.SelectByText(dr["SectorType"].ToString());
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("ctl00$ContentPlaceHolder1$txtClientMOINum")));
                txtClientMOINum.SendKeys(dr["ClientMOINum"].ToString());
                txtClientCCNum.SendKeys(dr["ClientCCNum"].ToString());
                txtGregorianIssueDate.SendKeys(dr["GregorianIssueDate"].ToString());
                txtHijriIssueDate.SendKeys(dr["HijriIssueDate"].ToString());
                txtClientArName.Click();
                SelectElement ddlDropRegionSelector = new SelectElement(ddlDropRegion);
                ddlDropRegionSelector.SelectByText(dr["Region"].ToString());

                SelectElement ddlDropCitySelector = new SelectElement(ddlDropCity);
                By byVal = By.XPath("//select/option[text()='" + dr["City"].ToString() + "']");
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(byVal));

                ddlDropCitySelector.SelectByText(dr["City"].ToString());
                btnNextPage1.Click();
            }
            catch (Exception ex) { }
        }
        public void FillAddNewClientPage2(Browser bro, DataRow dr)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                txtClientAddress.SendKeys(dr["ClientAddress"].ToString());
                txtClientEmail.SendKeys(dr["ClientEmail"].ToString());
                txtClientPhoneNum.SendKeys(dr["ClientPhoneNum"].ToString());
                txtClientFaxNum.SendKeys(dr["ClientFaxNum"].ToString());
                txtWebSite.SendKeys(dr["WebSite"].ToString());
                txtSMSCAlertNum.SendKeys(dr["SMSCAlertNum"].ToString());
                txtAlertEmail.SendKeys(dr["AlertEmail"].ToString());
                btnNextPage2.SendKeys(Keys.Return);
            }
            catch (Exception ex) { }
        }
        public void FillAddNewClientPage3(Browser bro, DataRow dr)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
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
            catch (Exception ex) { }

        }
        public void FillAddNewClientPage4(Browser bro, DataRow dr)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));

                if (dr["CertificatesDeliveryChannel"].ToString().ToLower().Contains("inactive"))
                {

                    rdbCertificatesDeliveryStatus_0.Click();
                }
                else
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(rdbCertificatesDeliveryMode_1));
                    rdbCertificatesDeliveryStatus_1.Click();

                    if (dr["DeliveryChannelType"].ToString().ToLower().Contains("summarized"))
                    {

                        rdbCertificatesDeliveryType_0.Click();
                    }
                    else
                        rdbCertificatesDeliveryType_1.Click();

                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id("rbtnlCertificatesDeliveryMode_0")));

                    if (dr["DataDeliveryMode"].ToString().ToLower().Contains("push"))
                    {

                        rdbCertificatesDeliveryMode_0.Click();
                    }
                    else
                        rdbCertificatesDeliveryMode_1.Click();

                    txtWebServiceUrl.SendKeys(dr["WebServiceUrl"].ToString());
                    txtWebServiceDomain.SendKeys(dr["WebServiceDomain"].ToString());
                    txtWebServiceUserName.SendKeys(dr["WebServiceUserName"].ToString());
                    if (txtWebServicePassword.Exists())
                    {
                        txtWebServicePassword.SendKeys(dr["WebServicePassword"].ToString());
                        txtConfirmWebServicePassword.SendKeys(dr["ConfirmWebServicePassword"].ToString());
                    }
                }
                wait.Until(ExpectedConditions.ElementToBeClickable(btnNextPage4));
                btnNextPage4.Click();
                
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lnkbtnsave")));
                btnsave.Click();
            }
            catch (Exception ex) { }

        }


        private bool VerifyClientPage1(Browser bro, DataRow dr)
        {
            bool result = false;
            try
            {
                result = (txtClientArName.GetAttribute("value") == dr["ClientArName"].ToString()?true:false);
                result = result && txtClientShArName.GetAttribute("value") == dr["ClientShArName"].ToString() ? true : false;

                result = result && txtClientEnName.GetAttribute("value") == dr["ClientEnName"].ToString() ? true : false;
                result = result && txtClientEnShName.GetAttribute("value") == dr["ClientEnShName"].ToString() ? true : false;

                result = result && Common.VerifyOptionExist(ddlDropSectorType, dr["SectorType"].ToString());
                result = result && txtClientMOINum.GetAttribute("value") == dr["ClientMOINum"].ToString() ? true : false;
                result = result && txtClientCCNum.GetAttribute("value") == dr["ClientCCNum"].ToString() ? true : false;
                result = result && txtGregorianIssueDate.GetAttribute("value") == dr["GregorianIssueDate"].ToString() ? true : false;
                result = result && txtHijriIssueDate.GetAttribute("value") == dr["HijriIssueDate"].ToString() ? true : false;


                result = result && Common.VerifyOptionExist(ddlDropSectorType, dr["Region"].ToString());
                result = result && Common.VerifyOptionExist(ddlDropSectorType, dr["City"].ToString());
                return result;
            }
            catch (Exception ex) { result = false; return result; }
        }

        private bool VerifyClientPage2(Browser bro, DataRow dr)
        {
            bool result = false;
            try
            {
                result = (txtClientAddress.GetAttribute("value") == dr["ClientAddress"].ToString() ? true : false);
                result = result && txtClientEmail.GetAttribute("value") == dr["ClientEmail"].ToString() ? true : false;
                result = result && txtClientPhoneNum.GetAttribute("value") == dr["ClientPhoneNum"].ToString() ? true : false;

               
                result = result && txtClientFaxNum.GetAttribute("value") == dr["ClientFaxNum"].ToString() ? true : false;
                result = result && txtWebSite.GetAttribute("value") == dr["WebSite"].ToString() ? true : false;
                result = result && txtSMSCAlertNum.GetAttribute("value") == dr["SMSCAlertNum"].ToString() ? true : false;
                result = result && txtAlertEmail.GetAttribute("value") == dr["AlertEmail"].ToString() ? true : false;


                return result;
                
            }
            catch (Exception ex) { result = false; return result; }
        }

        private bool VerifyClientPage3(Browser bro, DataRow dr)
        {
            bool result = false;
            try
            {
                result = (txtContactName.GetAttribute("value") == dr["ContactName"].ToString() ? true : false);
                result = result && txtContactMobile.GetAttribute("value") == dr["ContactMobile"].ToString() ? true : false;
                result = result && txtContactPhone.GetAttribute("value") == dr["ContactPhone"].ToString() ? true : false;


                result = result && txtContactJobTitle.GetAttribute("value") == dr["ContactJobTitle"].ToString() ? true : false;
                result = result && txtContactManagerName.GetAttribute("value") == dr["ContactManagerName"].ToString() ? true : false;
                result = result && txtContactManagerMobile.GetAttribute("value") == dr["ContactManagerMobile"].ToString() ? true : false;
                result = result && txtContactManagerPhone.GetAttribute("value") == dr["ContactManagerPhone"].ToString() ? true : false;

                result = result && txtContactManagerEmail.GetAttribute("value") == dr["ContactManagerEmail"].ToString() ? true : false;
                result = result && txtManagerName.GetAttribute("value") == dr["ManagerName"].ToString() ? true : false;
                result = result && txtManagerMobile.GetAttribute("value") == dr["ManagerMobile"].ToString() ? true : false;
                result = result && txtManagerPhone.GetAttribute("value") == dr["ManagerPhone"].ToString() ? true : false;
                
                return result;                
            }
            catch (Exception ex) { result = false; return result; }
        }

        private bool VerifyClientPage4(Browser bro, DataRow dr)
        {
            bool result = false;
            try
            {
                result = Common.VerifyRadiobuttonOptionByLabelText(bro.WebDriver, dr["CertificatesDeliveryChannel"].ToString());
                
                return result;
            }
            catch (Exception ex) { result = false; return result; }
        }


        public void ClearFieldsPage2(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(txtClientAddress));

                txtClientAddress.Clear();
                txtClientEmail.Clear();
                txtClientPhoneNum.Clear();
                txtClientFaxNum.Clear();
                txtWebSite.Clear();
                txtSMSCAlertNum.Clear();
                txtAlertEmail.Clear();

            }
            catch (Exception ex) { }
        }
        public void ClearFieldsPage3(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));

                wait.Until(ExpectedConditions.ElementToBeClickable(txtContactName));
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
            catch (Exception ex) { }

        }
        public void ClearFieldsPage4(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));

                wait.Until(ExpectedConditions.ElementToBeClickable(txtWebServiceUrl));
                txtWebServiceUrl.Clear();
                txtWebServiceDomain.Clear();
                txtWebServiceUserName.Clear();               
            }
            catch (Exception ex) { }

        }
       
        

        public bool ViewClientDetails(FunctionParameters fn)
        {
            
            bool res = false ;
            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                res = VerifyClientPage1(fn.WebBrowser, fn.testData);
                btnNextPage1.SendKeys(Keys.Return);
                res = res && VerifyClientPage2(fn.WebBrowser, fn.testData);
                btnNextPage2.SendKeys(Keys.Return);
                res = res && VerifyClientPage3(fn.WebBrowser, fn.testData);
                btnNextPage3.SendKeys(Keys.Return);
                res = res && VerifyClientPage4(fn.WebBrowser, fn.testData);
                btnNextPage4.SendKeys(Keys.Return);
                return res;
            }
            catch (Exception ex) { res = false; return res; }
        }

        public void GoToMyAccount(Browser webBrowser)
        {
            try
            {
                btnMyAccount.Click();
            }
            catch (Exception ex) { }
            
        }

        private void ClearFieldsPage1(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(txtClientArName));

                txtClientArName.Clear();
                txtClientShArName.Clear();
                txtClientEnName.Clear();
                txtClientEnShName.Clear();
                txtClientCCNum.Clear();
                txtGregorianIssueDate.Clear();
                txtHijriIssueDate.Clear();
                txtClientArName.Click();
               
            }
            catch (Exception ex) { }
        }

        public void AddClientCertificate(FunctionParameters fn)
        {
            try
            {
                //Default waiting 
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));

                DataTable dt = new DataTable();

                dt = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo);


                SelectElement ddlCertificateSelector = new SelectElement(ddlCertificate);
                ddlCertificateSelector.SelectByText(dt.Rows[0]["CertificateName"].ToString());
                txtPrice.SendKeys(dt.Rows[0]["CertificatePrice"].ToString());
                if(dt.Rows[0]["AllHospitals"].ToString()!="")
                {
                    if (dt.Rows[0]["AllHospitals"].ToString().ToLower() == "yes")
                        rdbAllHospitals_0.Click();
                    else
                    {
                        rdbSpecificHospitals_1.Click();
                        if(dt.Rows[0]["HospitalName"].ToString()!="")
                            txtHospitalName.SendKeys(dt.Rows[0]["HospitalName"].ToString());
                        if(dt.Rows[0]["HospitalMOI"].ToString()!="")
                            txtHospitalMOINo.SendKeys(dt.Rows[0]["HospitalMOI"].ToString());
                        btnBtnShow.Click();
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Id("GVHospitals")));
                        if(gdvHospitals.Exists())
                        {
                            if (gdvHospitals.Displayed)
                            {
                                if (gdvHospitals.FindElement(By.XPath("//td[text()[contains(.,'" + dt.Rows[0]["HospitalName"].ToString() + "')]]")).Displayed)
                                {

                                    gdvHospitals.FindElement(By.XPath("//*[@id='GVHospitals']/tbody//td[text() [contains(.,'" + dt.Rows[0]["HospitalName"].ToString() + "')]]/..//input[@id='chkRow']")).Click();
                                }
                            }
                            btnBtnAdd.Click();
                        }

                    }
                }
               
            }
            catch (Exception ex) { }
        }


        public void RemoveClientCertificate(FunctionParameters fn)
        {
            try
            {
                //Default waiting 
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));

                DataTable dt = new DataTable();

                dt = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo);

                //                SelectElement ddlCertificateToRemoveSelector = new SelectElement(ddlCertificateToRemove);

                //              ddlCertificateToRemoveSelector.SelectByText(dt.Rows[0]["CertificateName"].ToString());
                txtHospitalToRemoveCertificate.SendKeys(dt.Rows[0]["HospitalName"].ToString());
                btnShow2.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("gvIncludedCertificate")));
                if (gvIncludedCertificate.Exists())
                {
                    if (gvIncludedCertificate.Displayed)
                    {
                        if (gvIncludedCertificate.FindElement(By.XPath("//td[text()[contains(.,'" + dt.Rows[0]["CertificateName"].ToString() + "')]]")).Displayed)
                        {

                            gvIncludedCertificate.FindElement(By.XPath("//*[@id='gvIncludedCertificate']/tbody//td[text() [contains(.,'" + dt.Rows[0]["CertificateName"].ToString() + "')]]/..//a[@id='imgBtnDelete']")).Click();
                        }
                        wait.Until(ExpectedConditions.AlertIsPresent());
                        fn.WebDriver.SwitchTo().Alert();
                        fn.WebDriver.SwitchTo().Alert().Accept();
                    }
                    
                }
                

            }
            catch (Exception ex) { }
        }


        public void AddClientSickLeave(FunctionParameters fn)
        {
            try
            {
                //Default waiting 
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));

                DataTable dt = new DataTable();

                dt = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo);

                txtHospitalFullName.SendKeys(dt.Rows[0]["HospitalName"].ToString());
                btnSearch.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("gvNotAssociatedHospitals")));
                string xpathToParentRow = "";
                xpathToParentRow += "//td[text()[contains(.,'" + dt.Rows[0]["HospitalName"].ToString() + "')]]";
                if (gdvNotAssociatedHospitals.Exists())
                {
                    if (gdvNotAssociatedHospitals.Displayed)
                    {

                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathToParentRow)));

                        if (gdvNotAssociatedHospitals.FindElement(By.XPath("//td[text()[contains(.,'" + dt.Rows[0]["HospitalName"].ToString() + "')]]")).Displayed)
                        {

                            gdvNotAssociatedHospitals.FindElement(By.XPath("//*[@id='gvNotAssociatedHospitals']/tbody//td[text() [contains(.,'" + dt.Rows[0]["HospitalName"].ToString() + "')]]/..//input[@id='chkRow']")).Click();
                        }
                    }
                    btnAssociateHospitalToClient.Click();
                }

            }
            catch (Exception ex) { }
        }

        public void RemoveClientSickLeave(FunctionParameters fn)
        {
            try
            {
                //Default waiting 
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));

                DataTable dt = new DataTable();

                dt = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo);

                txtFullnameForAsscoiated.SendKeys(dt.Rows[0]["HospitalName"].ToString());
                btnSearchAssociated.Click();

                if (gdvAssociatedHospitals.Exists())
                {
                    if (gdvAssociatedHospitals.Displayed)
                    {
                        if (gdvAssociatedHospitals.FindElement(By.XPath("//table[@id='gvAssociatedHospitals']/tbody/tr/td[text()[contains(.,'" + dt.Rows[0]["HospitalName"].ToString() + "')]]")).Displayed)
                        {

                            gdvAssociatedHospitals.FindElement(By.XPath("//*[@id='gvAssociatedHospitals']/tbody//td[text() [contains(.,'" + dt.Rows[0]["HospitalName"].ToString() + "')]]/..//input[@id='chkRow']")).Click();
                        }
                    }
                    btnRemoveAssociation.Click();
                }

            }
            catch (Exception ex) { }
        }



        public bool CheckAddNewClient(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "CheckAddNewClient";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

        public bool CheckEditClient(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "CheckEditClient";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

        public bool CheckEnableClient(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "CheckEnableClient";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }


        public bool CheckDisbleClient(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "CheckDisbleClient";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);            
        }
        public bool CheckDeleteClient(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "CheckDeleteClient";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);            
        }
        public bool CheckDeleteClientFail(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "Check Delete Client Fail";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }
        public bool CheckViewClient(FunctionParameters fn)
        {
            fn.Function_Name = "View Client";
            if (chkViewClient.Exists())
            {
                if (chkViewClient.Displayed )
                    return true;
                else
                    return false;
            }
            else return false;
        }
        
        public bool CheckSearchClient(FunctionParameters fn)
        {
            fn.Function_Name = "Search Client";
            if (gdvClients.Exists())
            {
                if (gdvClients.Displayed )
                    return true;
                else
                    return false;
            }
            else return false;
        }

        public bool CheckAddCertificateToClient(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "CheckAddCertificateToClient";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkCertficateSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkCertficateSuccess, fn.ExpectedResult);           
        }
        public bool CheckRemoveCertificateFromClient(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "CheckRemoveCertificateFromClient";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkCertficateSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkCertficateSuccess, fn.ExpectedResult);            
        }

        public bool CheckAssociateHospitalToClient(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "CheckAssociateHospitalToClient";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkSickLeaveSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkSickLeaveSuccess, fn.ExpectedResult);

          
        }
        public bool CheckRemoveAssociateHospitalToClient(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "CheckRemoveAssociateHospitalToClient";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkSickLeaveRemoveSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkSickLeaveRemoveSuccess, fn.ExpectedResult);
            
        }
    }


}