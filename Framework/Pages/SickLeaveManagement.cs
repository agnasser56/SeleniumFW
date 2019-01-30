using System;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.IO;
using OpenQA.Selenium.Support.UI;
namespace SeleniumFramework
{
    public class SickLeaveManagement
    {
        public enum ActionType { Edit, Delete, Disable, Enable, ResetPassword };

        [FindsBy(How = How.XPath, Using = "//span[text()[contains(.,'close')]]/..")]
        private IWebElement btnColse;
    
        
        [FindsBy(How = How.Id, Using = "btnAddNewSickLeave")]
        private IWebElement btnAddNewSickLeave;
        

        [FindsBy(How = How.Id, Using = "ClientsRBList_0")]
        private IWebElement rdbClientTypeGov;

        [FindsBy(How = How.Id, Using = "ClientsRBList_1")]
        private IWebElement rdbClientTypePrivate;

        [FindsBy(How = How.Id, Using = "ClientsRBList_2")]
        private IWebElement rdbClientTypeBoth;

        [FindsBy(How = How.Id, Using = "txtclient")]
        private IWebElement txtClientName;

        [FindsBy(How = How.Id, Using = "rblIndividaulTypePatient_0")]
        private IWebElement rdblIndividaulTypePatient_Citizen;

        [FindsBy(How = How.Id, Using = "rblIndividaulTypePatient_1")]
        private IWebElement rdblIndividaulTypePatient_Resident;

        [FindsBy(How = How.Id, Using = "txtCitizenID")]
        private IWebElement txtCitizenID;

        [FindsBy(How = How.Id, Using = "txtIdExpiryDate")]
        private IWebElement txtIdExpiryDate;

        [FindsBy(How = How.Id, Using = "txtResidentsID")]
        private IWebElement txtResidentsID;

        [FindsBy(How = How.Id, Using = "txtResidentsSponsorID")]
        private IWebElement txtResidentsSponsorID;

        [FindsBy(How = How.Id, Using = "btnVerifyPatient")]
        private IWebElement btnVerifyPatient;

        [FindsBy(How = How.Id, Using = "lblValidationResult")]
        private IWebElement lblValidationResult;


        [FindsBy(How = How.Id, Using = "txtFullNamePatient")]
        private IWebElement txtFullNamePatient;

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


        [FindsBy(How = How.Id, Using = "lnkbtnsave")]
        private IWebElement btnsave;

        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "span", Priority = 0)]
        [FindsBy(How = How.Id, Using = "lblSuccess", Priority = 1)]
        private IWebElement chkAddSuccess;

        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "span", Priority = 0)]
        [FindsBy(How = How.Id, Using = "lblSickleaveId", Priority = 1)]
        private IWebElement lblSickLeaveID;

        [FindsBy(How = How.Id, Using = "btnApprove")]
        private IWebElement btnApproveSickLeave;


        [FindsBy(How = How.Id, Using = "btnReject")]
        private IWebElement btnRejectSickLeave;



        [FindsBy(How = How.Id, Using = "txtRejectReason")]
        private IWebElement txtRejectReason;

        [FindsBy(How = How.Id, Using = "btnRejection")]
        private IWebElement btnSubmitRejection;


        //Search sick leave
        [FindsBy(How = How.Id, Using = "txtSickLeaveId")]
        private IWebElement txtSickLeaveId;

        [FindsBy(How = How.Id, Using = "btnSearchBySickLeaveId")]
        private IWebElement btnSearchBySickLeaveId;

        [FindsBy(How = How.Id, Using = "txtIndividaualID")]
        private IWebElement txtIndividaualID;

        [FindsBy(How = How.Id, Using = "btnSearchByIndividual")]
        private IWebElement btnSearchByIndividual;

  
        [FindsBy(How = How.Id, Using = "drpStatus")]
        private IWebElement ddlDrpStatus;
  
        [FindsBy(How = How.Id, Using = "drpPageSize")]
        private IWebElement ddlDrpPageSize;
  
        [FindsBy(How = How.Id, Using = "btnAdvSearch")]
        private IWebElement btnAdvSearch;

        
       [FindsBy(How = How.Id, Using = "gvSickLeave")]
        private IWebElement gdvSickLeaves;



        #region Navigation
        public void GoToAddSickLeavePage(Browser bro)
        {
          
            if(btnColse.Exists())
            {
                btnColse.Click();
                
            }
            bro.WebDriver.Url = "https://192.168.41.22/EMC.UI/SickLeave/SickLeaveList.aspx";
            bro.WebDriver.Navigate();
            btnAddNewSickLeave.Click();

        }
        public void GoToSickLeaveList(Browser bro)
        {

            if (btnColse.Exists())
            {
                btnColse.Click();

            }
            bro.WebDriver.Url = "https://192.168.41.22/EMC.UI/SickLeave/SickLeaveList.aspx";
            bro.WebDriver.Navigate();
         }

        #endregion

        #region SickLeaveManangement
        public void AddSickLeave(FunctionParameters fn)
        {
            //Default waiting 
            WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));


            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                ProcessAddSickLeavePage(fn.WebBrowser, fn.testData);
                FillAddSickLeavePage1(fn.WebBrowser, fn.testData);
                FillAddSickLeavePage2(fn.WebBrowser, fn.testData);
                FillAddSickLeavePage3(fn.WebBrowser, fn.testData);

                //update the excel sheet with the sickleave id
               
                Common.ExplicitWait(3);
                fn.testData["SickLeaveID"] = lblSickLeaveID.Text;
                //Update sheet with new values
                DataManager.UpdateExcelSheet(fn.testData.Table, fn.SheetName, "RowID=" + fn.RowNo);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
        }

        public void SearchSickLeave(FunctionParameters fn, ActionType act)
        {
            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                txtSickLeaveId.SendKeys(fn.testData["SickLeaveID"].ToString());
                btnSearchBySickLeaveId.Click();


                if (gdvSickLeaves.Displayed)
                {
                    switch (act)
                    {
                        case ActionType.Edit:
                            {
                                if (gdvSickLeaves.FindElement(By.XPath("//td[text()[contains(.,'" + fn.testData["SickLeaveID"].ToString() + "')]]")).Displayed)
                                {

                                    gdvSickLeaves.FindElement(By.XPath("//*[@id='gvSickLeave']/tbody//td[text() [contains(.,'" + fn.testData["SickLeaveID"].ToString() + "')]]/..//a[@id='btnEdite']")).Click();
                                    
                                }
                                break;
                            }
                        case ActionType.Delete:
                            {
                                if (gdvSickLeaves.FindElement(By.XPath("//td[text()[contains(.,'" + fn.testData["SickLeaveID"].ToString() + "')]]")).Displayed)
                                {

                                    gdvSickLeaves.FindElement(By.XPath("//*[@id='gvSickLeave']/tbody//td[text() [contains(.,'" + fn.testData["SickLeaveID"].ToString() + "')]]/..//a[@id='btnEdite']")).Click();

                                }
                                break;
                            }
                       
                    }

                }
            }
            catch (Exception ex) { }
        }

        public void BrowseSickLeave(FunctionParameters fn)
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

        public void ProcessAddSickLeavePage(Browser bro, DataRow dr)
        {
            try
            {
                
                dr["NoOfDays"] = dr["NoOfDays"].ToString().ToLower() == "auto" ? Faker.RandomNumber.Next(11).ToString(): dr["NoOfDays"].ToString();
                dr["HijriStartDate"] = dr["HijriStartDate"].ToString().ToLower() == "auto"? DBOperations.GetSpecificHijriDate(dr["NoOfDays"].ToString()) : dr["HijriStartDate"].ToString();
                dr["HijriEndDate"] = dr["HijriEndDate"].ToString().ToLower() == "auto" ? DBOperations.GetSpecificHijriDate(dr["NoOfDays"].ToString()) : dr["HijriEndDate"].ToString();
                dr["VisitDate"] = dr["VisitDate"].ToString().ToLower() == "auto" ? DBOperations.GetTodayHijriDate() : dr["VisitDate"].ToString();
                dr["AddmissionDate"] = dr["AddmissionDate"].ToString().ToLower() == "auto" ? DBOperations.GetTodayHijriDate() : dr["AddmissionDate"].ToString();
                dr["DischargeDate"] = dr["DischargeDate"].ToString().ToLower() == "auto" ? DBOperations.GetSpecificHijriDate(dr["NoOfDays"].ToString()) : dr["DischargeDate"].ToString();
            }

            catch (Exception ex) { }
        }

        public void FillAddSickLeavePage1(Browser bro, DataRow dr)
        {
            //Default waiting 
            WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
            if(dr["ClientType"].ToString().ToLower()=="goverment")
                rdbClientTypeGov.Click();
            else if (dr["ClientType"].ToString().ToLower() == "private")
                 rdbClientTypePrivate.Click(); 
            else
                rdbClientTypeBoth.Click();

            Common.ExplicitWait(5);
            txtClientName.SendKeys(dr["ClientName"].ToString());
            if (dr["IndividaulTypePatient"].ToString() == "Citizen")
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(rdblIndividaulTypePatient_Citizen));
                rdblIndividaulTypePatient_Citizen.Click();
                txtCitizenID.SendKeys(dr["CitizenID"].ToString());
                txtIdExpiryDate.SendKeys(dr["IdExpiryDate"].ToString());
                
            }
            else
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(rdblIndividaulTypePatient_Resident));
                rdblIndividaulTypePatient_Resident.Click();
                txtResidentsID.SendKeys(dr["ResidentsID"].ToString());
                txtResidentsSponsorID.SendKeys(dr["ResidentsSponsorID"].ToString());
            }
            wait.Until(ExpectedConditions.ElementToBeClickable(btnVerifyPatient));
            Common.ExplicitWait(5);
            btnVerifyPatient.SendKeys(Keys.Return);
            Common.ExplicitWait(5);
            if (Common.CheckPointVerification(lblValidationResult, "Individual Information is incorrect"))
            {
                btnVerifyPatient.Click();
                Common.ExplicitWait(5);
            }
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(By.Id(txtFullNamePatient.GetAttribute("id")), dr["FullNamePatient"].ToString()));
            
            txtMobilePatient.SendKeys(dr["MobilePatient"].ToString());
            txtMedicalRecordNumber.SendKeys(dr["MedicalRecordNumber"].ToString());
            if (dr["NotificationLanguage"].ToString() == "Arabic")
            {
                rdbNotificationLanguage_Arabic.Click();
            }
            else
                rdbNotificationLanguage_English.Click();

            btnNext.Click();            
        }

        public void FillAddSickLeavePage2(Browser bro, DataRow dr)
        {
            //Default waiting 
            try
            {
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                SelectElement ddlDdlDoctorsSelector = new SelectElement(ddlDdlDoctors);
                ddlDdlDoctorsSelector.SelectByText(dr["TreatingDoctor"].ToString());
                wait.Until(ExpectedConditions.TextToBePresentInElement(lblTreatingDocLevel,dr["DoctorLevel"].ToString()));

                Common.ExplicitWait(3);
                SelectElement ddlAuditingDoctorSelector = new SelectElement(ddlAuditingDoctor);
                ddlAuditingDoctorSelector.SelectByText(dr["AuditingDoctor"].ToString());
                
                txtHijriStartDate.SendKeys(dr["HijriStartDate"].ToString());
                txtHijriEndDate.SendKeys(dr["HijriEndDate"].ToString());
                txtHijriVisitDate.SendKeys(dr["VisitDate"].ToString());
                txtHijriAddmissionDate.SendKeys(dr["AddmissionDate"].ToString());
                txtHijriDischargeDate.SendKeys(dr["DischargeDate"].ToString());
                txtHijriStartDate.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(btnCalculate));
                Common.ExplicitWait(3);
                btnCalculate.Click();
                
                SelectElement ddlDropRegionSelector = new SelectElement(ddlDropRegion);
                ddlDropRegionSelector.SelectByText(dr["ClientRegion"].ToString());
                Common.ExplicitWait(5);
                Common.WaitForOptionPresenance(bro, ddlDdlClientCity, dr["ClientCity"].ToString());
                
                SelectElement ddlDdlClientCitySelector = new SelectElement(ddlDdlClientCity);
                ddlDdlClientCitySelector.SelectByText(dr["ClientCity"].ToString());

                //Common.WaitForOptionPresenance(bro, ddlDdlIssuingLocation, dr["IssuingLocation"].ToString());

                //SelectElement ddlDdlIssuingLocationSelector = new SelectElement(ddlDdlIssuingLocation);
                //ddlDdlIssuingLocationSelector.SelectByText(dr["IssuingLocation"].ToString());
                //wait.Until(ExpectedConditions.ElementIsVisible(By.Name("ctl00$ContentPlaceHolder1$txtMedicalCondition")));
                txtMedicalCondition.SendKeys(dr["MedicalConditionComment"].ToString());
                //  wait.Until(ExpectedConditions.ElementIsVisible(By.Name("ctl00$ContentPlaceHolder1$txtMedicalCondition")));
                //btnNext.s();
                //btnNext.SendKeys(Keys.Return);
                btnNextPage2.Click();

            }
            catch (Exception ex) { }
    }

        public void FillAddSickLeavePage3(Browser bro, DataRow dr)
        {
            //Default waiting 
            try
            {
                WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(btnsave));
                btnsave.Click();                
            }
            catch (Exception ex) { }
        }

        public void GoToSickLeaves(Browser webBrowser)
        {
            //tabClientSickLeaves.Click();

        }

        public bool CheckAddSickLeave(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "Add Sick Leave";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
            
        }

        public bool CheckApproveSickLeave(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "Approve Sick Leave";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
                
                
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }

        public bool CheckRejectSickLeave(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "Reject Sick Leave";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddSuccess, fn.ExpectedResult);
        }
        public bool CheckSearchSickLeave(FunctionParameters fn)
        {
            bool success = false;
            try
            {
                fn.Function_Name = "Search Sick Leave";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(gdvSickLeaves.GetAttribute("id"))));
                if (gdvSickLeaves.Displayed)
                {
                    success = true;
                    return success;
                }
                else return success;
            }
            catch (Exception ex) { return success; }          
        }

        public void ApproveSickLeave(FunctionParameters fn)
        {
            try
            {
                btnApproveSickLeave.Click();
            }
            catch (Exception ex) { }
        }

        public void RejectSickLeave(FunctionParameters fn)
        {
            try
            {
                btnRejectSickLeave.Click();
                txtRejectReason.SendKeys("Reject reason");
                btnSubmitRejection.Click();


            }
            catch (Exception ex) { }
        }
        #endregion


    }
}
