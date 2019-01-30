using System;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.IO;
using OpenQA.Selenium.Support.UI;
namespace SeleniumFramework
{
    public class CertificateManagement
    {
        public enum ActionType { Add, Edit, Delete, Disable, Enable, ResetPassword };

        [FindsBy(How = How.XPath, Using = "//span[text()[contains(.,'close')]]/..")]
        private IWebElement btnColse;

        [FindsBy(How = How.Id, Using = "drpClients")]
        private IWebElement ddlClients;

        [FindsBy(How = How.Id, Using = "rblIndividaulType_0")]
        private IWebElement rdblIndividaulTypePatient_Citizen;

        [FindsBy(How = How.Id, Using = "rblIndividaulType_1")]
        private IWebElement rdblIndividaulTypePatient_Resident;

        [FindsBy(How = How.Id, Using = "txtCitizenID")]
        private IWebElement txtCitizenID;

        [FindsBy(How = How.Id, Using = "txtIdExpiryDate")]
        private IWebElement txtIdExpiryDate;

        [FindsBy(How = How.Id, Using = "txtResidentsID")]
        private IWebElement txtResidentsID;

        [FindsBy(How = How.Id, Using = "txtResidentsSponsorID")]
        private IWebElement txtResidentsSponsorID;

        [FindsBy(How = How.Id, Using = "txtVisaIssueDate")]
        private IWebElement txtVisaIssueDate;

        [FindsBy(How = How.Id, Using = "btnValidate")]
        private IWebElement btnValidate;

        [FindsBy(How = How.Id, Using = "btnVerifyPatient")]
        private IWebElement btnVerifyPatient;

        [FindsBy(How = How.Id, Using = "lblValidationResult")]
        private IWebElement lblValidationResult;


        [FindsBy(How = How.Id, Using = "rblResults_0")]
        private IWebElement rdbRblResults_0;

        [FindsBy(How = How.Id, Using = "rblResults_1")]
        private IWebElement rdbRblResults_1;

        [FindsBy(How = How.Id, Using = "drpValues")]
        private IWebElement ddlDrpValues;
        
        [FindsBy(How = How.Id, Using = "txtFreeText")]
        private IWebElement txtTxtFreeText;

        [FindsBy(How = How.Id, Using = "rblCResults_0")]
        private IWebElement rdbRblCResults_0;

        [FindsBy(How = How.Id, Using = "rblCResults_1")]
        private IWebElement rdbRblCResults_1;


        [FindsBy(How = How.Id, Using = "rblCerResult_0")]
        private IWebElement rdbRblCerResult_0;

        [FindsBy(How = How.Id, Using = "rblCerResult_1")]
        private IWebElement rdbRblCerResult_1;

        [FindsBy(How = How.Id, Using = "rblCerResult_2")]
        private IWebElement rdbRblCerResult_2;

        [FindsBy(How = How.Id, Using = "lstAllWarning")]
        private IWebElement ddlLstAllWarning;
        
        [FindsBy(How = How.Id, Using = "btnAddIncludedWarnings")]
        private IWebElement btnBtnAddIncludedWarnings;

        [FindsBy(How = How.Id, Using = "btnRemoveIncludedWarnings")]
        private IWebElement btnBtnRemoveIncludedWarnings;

        [FindsBy(How = How.Id, Using = "lstIncludedWarning")]
        private IWebElement ddlLstIncludedWarning;
        
        [FindsBy(How = How.Id, Using = "lstAllRestrictions")]
        private IWebElement ddlLstAllRestrictions;
        
        [FindsBy(How = How.Id, Using = "btnAddIncludedRestrictions")]
        private IWebElement btnAddIncludedRestrictions;

        [FindsBy(How = How.Id, Using = "btnRemoveIncludedRestrictions")]
        private IWebElement btnRemoveIncludedRestrictions;

        [FindsBy(How = How.Id, Using = "lstIncludedRestriction")]
        private IWebElement ddlLstIncludedRestriction;
        
        [FindsBy(How = How.Id, Using = "txtNotes")]
        private IWebElement txtTxtNotes;






        
        [FindsBy(How = How.Id, Using = "txtFullNamePatient")]
        private IWebElement txtFullNamePatient;

        [FindsBy(How = How.Id, Using = "lblName")]
        private IWebElement lblName;

        
        [FindsBy(How = How.Id, Using = "txtNotificationNO")]
        private IWebElement txtNotificationNO;

        [FindsBy(How = How.Id, Using = "txtNotificationEmail")]
        private IWebElement txtNotificationEmail;

        [FindsBy(How = How.Id, Using = "txtMobilePatient")]
        private IWebElement txtMobilePatient;

        [FindsBy(How = How.Id, Using = "txtMedicalRecordNumber")]
        private IWebElement txtMedicalRecordNumber;

        [FindsBy(How = How.Id, Using = "txtOccupation")]
        private IWebElement txtTxtOccupation;

        [FindsBy(How = How.Id, Using = "rblNotificationLanguage_0")]
        private IWebElement rdbNotificationLanguage_Arabic;

        [FindsBy(How = How.Id, Using = "rblNotificationLanguage_1")]
        private IWebElement rdbNotificationLanguage_English;

        [FindsBy(How = How.XPath, Using = "//span[text()[contains(.,'Next')]]/..")]
        private IWebElement btnNext;

        [FindsBy(How = How.Id, Using = "ddlDoctors")]
        private IWebElement ddlDdlDoctors;

        [FindsBy(How = How.Id, Using = "lblTreatingDocLevel")]
        private IWebElement txtTreatingDoctor;

        [FindsBy(How = How.Id, Using = "lblTreatingDocLevel")]
        private IWebElement lblTreatingDocLevel;

        [FindsBy(How = How.Id, Using = "DDL_AuditingDoctor")]
        private IWebElement ddlAuditingDoctor;

        [FindsBy(How = How.Id, Using = "lblAuditingDoctorLevel")]
        private IWebElement txtAuditingDoctor;

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_CalStartDate_txtDate")]
        private IWebElement txtHijriStartDate;

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_CalEndDate_txtDate")]
        private IWebElement txtHijriEndDate;

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_CalDateOfVisit_txtDate")]
        private IWebElement txtHijriVisitDate;

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_CalAddmissionDate_txtDate")]
        private IWebElement txtHijriAddmissionDate;

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_CalDischargeDate_txtDate")]
        private IWebElement txtHijriDischargeDate;

        [FindsBy(How = How.Id, Using = "lblDaysNo")]
        private IWebElement txtNoOfDays;

        [FindsBy(How = How.Id, Using = "btnCalculate")]
        private IWebElement btnCalculate;

        [FindsBy(How = How.Id, Using = "dropRegion")]
        private IWebElement ddlDropRegion;

        [FindsBy(How = How.Id, Using = "ddlClientLocation")]
        private IWebElement ddlDdlClientCity;

        [FindsBy(How = How.Id, Using = "ddlIssuingLocation")]
        private IWebElement ddlDdlIssuingLocation;

        [FindsBy(How = How.Id, Using = "txtMedicalCondition")]
        private IWebElement txtMedicalCondition;


        [FindsBy(How = How.Id, Using = "Label14")]
        private IWebElement btnNextPage2;


        [FindsBy(How = How.Id, Using = "btnSaveCert")]
        private IWebElement btnsave;

       
        [FindsBy(How = How.Id, Using = "lblSuccess")]
        private IWebElement chkAddSuccess;

       
        [FindsBy(How = How.Id, Using = "btnApprove")]
        private IWebElement btnApproveCertificateResult;


        [FindsBy(How = How.Id, Using = "btnReject")]
        private IWebElement btnRejectCertificateResult;



        [FindsBy(How = How.Id, Using = "btnRejection")]
        private IWebElement btnSubmitRejection;

        [FindsBy(How = How.Id, Using = "gvAllowedCertificates")]
        private IWebElement gdvAllowedCertificates;

        [FindsBy(How = How.Id, Using = "gvCerResultList")]
        private IWebElement gdvCerResultList;

        [FindsBy(How = How.Id, Using = "txtIndividaualID")]
        private IWebElement txtIndividaualID;

        [FindsBy(How = How.Id, Using = "btnSearchByIndividual")]
        private IWebElement btnSearchByIndividual;





        #region Navigation

        public void GoToCertificatesAddList(Browser bro)
        {

            if (btnColse.Exists())
            {
                btnColse.Click();

            }
            bro.WebDriver.Url = "https://192.168.41.22/EMC.UI/CertificateResult/CerResultAddList.aspx";
            bro.WebDriver.Navigate();
        }

        public void GoToCertificatesList(Browser bro)
        {

            if (btnColse.Exists())
            {
                btnColse.Click();

            }
            bro.WebDriver.Url = "https://192.168.41.22/EMC.UI/CertificateResult/CerResultsList.aspx";
            bro.WebDriver.Navigate();
        }

        #endregion

        #region CertificateManangement
        public void AddCertificate(FunctionParameters fn)
        {
            try
            {
                if (fn.testData == null)
                { 
                    
                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
              
                FillAddCertificatePage1(fn.WebBrowser, fn.testData);
              
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
        }
        
        public void SearchClient(FunctionParameters fn, ActionType act)
        {
            try
            {

                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }

                SelectElement ddlClientsSelect = new SelectElement(ddlClients);
                ddlClientsSelect.SelectByText(fn.testData["ClientName"].ToString());
                
                if (gdvAllowedCertificates.Displayed)
                {
                    switch (act)
                    {
                        case ActionType.Add:
                            {
                                if (gdvAllowedCertificates.FindElement(By.XPath("//td[text()[contains(.,'" + fn.testData["CertificateNameEn"].ToString() + "')]]")).Displayed)
                                {

                                    gdvAllowedCertificates.FindElement(By.XPath("//*[@id='gvAllowedCertificates']/tbody//td[text() [contains(.,'" + fn.testData["CertificateNameEn"].ToString() + "')]]/..//a[@id='btnAdd']")).Click();

                                }
                                break;
                            }               
                     }

                }
            }
            catch (Exception ex) { }
        }

        public void SearchCertificateByIndividualID(FunctionParameters fn,ActionType act)
        {
            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                
                if (fn.testData["ResidentsID"].ToString()!="")
                    txtIndividaualID.SendKeys(fn.testData["ResidentsID"].ToString());
                else
                    txtIndividaualID.SendKeys(fn.testData["CitizenID"].ToString());
                btnSearchByIndividual.Click();

                if (gdvCerResultList.Exists())
                {
                    if (gdvCerResultList.Displayed)
                    {
                        switch (act)
                        {
                            case ActionType.Edit:
                                {
                                    //a[text()[contains(.,'"+fn.testData["FullNamePatient"].ToString()+"')]]
                                    if (gdvCerResultList.FindElement(By.XPath("//a[text()[contains(.,'" + fn.testData["FullNamePatient"].ToString() + "')]]")).Displayed)
                                    {
                                        gdvCerResultList.FindElement(By.XPath("//a[text()[contains(.,'" + fn.testData["FullNamePatient"].ToString() + "')]]/../../td/a[@id='btnEdite']")).Click();

                                    }
                                    break;
                                }
                        }

                    }
                }
             

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
        }

        public void SearchApproveCertificate(FunctionParameters fn)
        {
            try
            {
                SearchCertificateByIndividualID(fn, ActionType.Edit);
                FillTestResults(fn.WebBrowser, fn.testData);
                btnsave.Click();
                btnApproveCertificateResult.Click();
            }
            catch (Exception ex) { }
        }

        public void EditMedicalTestResult(FunctionParameters fn)
        {
            try
            {
                SearchCertificateByIndividualID(fn, ActionType.Edit);
                FillTestResults(fn.WebBrowser, fn.testData);
                btnsave.Click();                
            }
            catch (Exception ex) { }
        }

        public void SearchRejectCertificate(FunctionParameters fn)
        {
            try
            {
                SearchCertificateByIndividualID(fn, ActionType.Edit);
                FillTestResults(fn.WebBrowser, fn.testData);
                btnsave.Click();
                btnRejectCertificateResult.Click();
            }
            catch (Exception ex) { }
        }

        public void ApproveCertificate(FunctionParameters fn)
        {
            try
            {
                btnApproveCertificateResult.Click();
            }
            catch (Exception ex) { }
        }

        public void RejectCertificate(FunctionParameters fn)
        {
            try
            {
                btnRejectCertificateResult.Click();

            }
            catch (Exception ex) { }
        }

        public void BrowseCertificate(FunctionParameters fn)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));

                btnNext.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(btnNextPage2.GetAttribute("id"))));
                btnNextPage2.Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(btnsave.GetAttribute("id"))));
                btnsave.Click();
            }
            catch (Exception ex) { }
        }

        public void ProcessAddCertificatePage(Browser bro, DataRow dr)
        {
            try
            {

                dr["HijriStartDate"] = dr["HijriStartDate"].ToString() == "AUTO" ? DBOperations.GetSpecificHijriDate("16") : dr["HijriStartDate"].ToString();
                dr["HijriEndDate"] = dr["HijriEndDate"].ToString() == "AUTO" ? DBOperations.GetSpecificHijriDate("16") : dr["HijriEndDate"].ToString();
                dr["VisitDate"] = dr["VisitDate"].ToString() == "AUTO" ? DBOperations.GetTodayHijriDate() : dr["VisitDate"].ToString();
                dr["AddmissionDate"] = dr["AddmissionDate"].ToString() == "AUTO" ? DBOperations.GetTodayHijriDate() : dr["AddmissionDate"].ToString();
                dr["DischargeDate"] = dr["DischargeDate"].ToString() == "AUTO" ? DBOperations.GetSpecificHijriDate("16") : dr["DischargeDate"].ToString();
            }

            catch (Exception ex) { }
        }

       
        public void FillAddCertificatePage1(Browser bro, DataRow dr)
        {
            //Default waiting 
            WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));

            if (dr["IndividaulTypePatient"].ToString() == "Citizen")
            {
                rdblIndividaulTypePatient_Citizen.Click();
                txtCitizenID.SendKeys(dr["CitizenID"].ToString());
                txtIdExpiryDate.SendKeys(dr["IdExpiryDate"].ToString());

            }
            else
            {
                rdblIndividaulTypePatient_Resident.Click();
                if (dr["ResidentsID"].ToString() != "")
                {
                    txtResidentsID.SendKeys(dr["ResidentsID"].ToString());
                    txtResidentsSponsorID.SendKeys(dr["ResidentsSponsorID"].ToString());
                }
                else
                {
                    txtResidentsID.SendKeys(dr["ResidentsID"].ToString());
                    txtResidentsSponsorID.SendKeys(dr["ResidentsSponsorID"].ToString());
                    txtVisaIssueDate.SendKeys(dr["VisaIssueDate"].ToString());
                }

            }

            wait.Until(ExpectedConditions.ElementToBeClickable(btnValidate));
            Common.ExplicitWait(5);
            btnValidate.SendKeys(Keys.Return);
            Common.ExplicitWait(5);
            if (Common.CheckPointVerification(chkAddSuccess, "individual information is incorrect"))
            {
                btnValidate.Click();
                Common.ExplicitWait(5);
            }
            wait.Until(ExpectedConditions.TextToBePresentInElement(lblName, dr["FullNamePatient"].ToString()));

            txtNotificationNO.SendKeys(dr["NotificationMobile"].ToString());
            txtNotificationEmail.SendKeys(dr["NotificationEmail"].ToString());

            if (dr["NotificationLanguage"].ToString() == "Arabic")
            {
                rdbNotificationLanguage_Arabic.Click();
            }
            else
                rdbNotificationLanguage_English.Click();

            //Abdomen Result
            FillTestResults(bro, dr);

            btnsave.Click();
        }

        private void FillTestResults(Browser bro, DataRow dr)
        {
            try
            {
                //Default waiting 
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                if (dr["Abdomen"].ToString().ToLower() == "passed")
                {
                    rdbRblResults_1.Click();
                }
                else
                    rdbRblResults_0.Click();

                
                SelectElement ddlDrpValuesSelector = new SelectElement(ddlDrpValues);
                ddlDrpValuesSelector.SelectByText(dr["PregnantTest"].ToString());

                txtTxtFreeText.SendKeys(dr["Wounds"].ToString());

                if (dr["Varias"].ToString().ToLower() == "passed")
                {
                    bro.WebDriver.FindElements(By.Id(rdbRblResults_0.GetAttribute("id")))[1].Click();
                    
                }
                else
                    bro.WebDriver.FindElements(By.Id(rdbRblResults_0.GetAttribute("id")))[1].Click();


                SelectElement chestTestValue = new SelectElement(bro.WebDriver.FindElements(By.Id(ddlDrpValues.GetAttribute("id")))[1]);
                chestTestValue.SelectByText(dr["Chest"].ToString());
                
                if (dr["Vision"].ToString().ToLower() == "passed")
                {
                    rdbRblCResults_1.Click();
                }
                else
                    rdbRblCResults_0.Click();

                if (dr["OverallResult"].ToString().ToLower() == "fit")
                { rdbRblCerResult_0.Click(); }
                else if (dr["OverallResult"].ToString().ToLower() == "not fit")
                {
                    rdbRblCerResult_1.Click();
                }
                else
                    rdbRblCerResult_2.Click();


                if (dr["Warnings"].ToString() != "")
                {
                    SelectElement ddlLstAllWarningSelector = new SelectElement(ddlLstAllWarning);
                    ddlLstAllWarningSelector.SelectByText(dr["Warnings"].ToString());
                    btnBtnAddIncludedWarnings.Click();
                }
                if (dr["Restrictions"].ToString() != "")
                {
                    SelectElement ddlLstAllRestrictionsSelector = new SelectElement(ddlLstAllRestrictions);
                    ddlLstAllRestrictionsSelector.SelectByText(dr["Restrictions"].ToString());
                    btnAddIncludedRestrictions.Click();
                }
                txtTxtNotes.SendKeys(dr["Notes"].ToString());
                

            }
            catch (Exception ex) { }
        }
       
        public bool CheckAddCertificate(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "Add Certificate";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }
        public bool CheckAddDuplicateCertificate(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "Add Duplicate Certificate";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }
        public bool CheckApproveCertificate(FunctionParameters fn)
        {
            try {
                fn.Function_Name = "Approve Certificate";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id")))); }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult); 

        }

        public bool CheckRejectCertificate(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "Reject Certificate";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);

            
        }

        public bool CheckEditCertificate(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "Edit Certificate";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

        #endregion


    }
}
