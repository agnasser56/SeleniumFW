using System;
using System.Data;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
namespace SeleniumFramework
{
    public class UsersManagement
    {
        public enum ActionType { Edit, Delete, Disable,Enable,ResetPassword };

        
        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "span", Priority = 0)]
        [FindsBy(How = How.Id, Using = "MyProfileLable", Priority = 1)]
        private IWebElement btnMyProfile;

        [FindsBy(How = How.XPath, Using = "//span[text()[contains(.,'Users')]]/..")]
        private IWebElement btnUsers;

        [FindsBy(How = How.XPath, Using = "//span[text()[contains(.,'Add user')]]/..")]
        private IWebElement btnAddUser;

        [FindsBy(How = How.Id, Using = "drpStatus")]
        private IWebElement ddlDrpStatus;

        
        [FindsBy(How = How.Id, Using = "gdvList")]
        private IWebElement GdvUsers;
        
        [FindsBy(How = How.Id, Using = "txtUsername")]
        private IWebElement txtTxtUsername;

        [FindsBy(How = How.Id, Using = "txtEnglishName")]
        private IWebElement txtTxtEnglishName;

        [FindsBy(How = How.Id, Using = "txtArabicName")]
        private IWebElement txtTxtArabicName;

        [FindsBy(How = How.Id, Using = "drpRole")]
        private IWebElement ddlDrpRole;
        
        [FindsBy(How = How.Id, Using = "txtNationalIdNumber")]
        private IWebElement txtTxtNationalIdNumber;

        [FindsBy(How = How.Id, Using = "txtPhone")]
        private IWebElement txtTxtPhone;

        [FindsBy(How = How.Id, Using = "txtMobile")]
        private IWebElement txtTxtMobile;

        [FindsBy(How = How.Id, Using = "txtJobTitle")]
        private IWebElement txtTxtJobTitle;

        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement txtTxtEmail;

        [FindsBy(How = How.Id, Using = "txtManagerName")]
        private IWebElement txtTxtManagerName;

        [FindsBy(How = How.Id, Using = "txtManagerPhone")]
        private IWebElement txtTxtManagerPhone;

        [FindsBy(How = How.Id, Using = "txtManagerMobile")]
        private IWebElement txtTxtManagerMobile;

        [FindsBy(How = How.Id, Using = "txtManagerEmail")]
        private IWebElement txtTxtManagerEmail;

        [FindsBy(How = How.Id, Using = "btnSave")]
        private IWebElement btnBtnSave;

        private IWebElement QCUserCell;

        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "span", Priority = 0)]                                        
        [FindsBy(How = How.Id, Using = "lblResultMessage", Priority = 1)]
        private IWebElement chkAddQCUserSuccess;

        public void GoTo(Browser bro)
        {
            btnUsers.Click();
           
        }
        public void GoToMyProfile(Browser bro)
        {
            btnMyProfile.Click();

        }
        public void SearchUser(FunctionParameters fn, ActionType act)
        {
            try
            {

                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                SelectElement ddlDrpStatusSelector = new SelectElement(ddlDrpStatus);
                ddlDrpStatusSelector.SelectByText(fn.testData["UserStatus"].ToString());
               
                if (GdvUsers.Displayed)
                {
                    switch (act)
                    {
                        case ActionType.Edit:
                            {
                                if (GdvUsers.FindElement(By.XPath("//td[text()[contains(.,'" + fn.testData["UserName"].ToString() + "')]]")).Displayed)
                                {

                                    QCUserCell = GdvUsers.FindElement(By.XPath("//*[@id='gdvList']/tbody//td[text() [contains(.,'" +fn.testData["UserName"].ToString() + "')]]/..//a[@id='imgBtnEdit']"));
                                    QCUserCell.Click();
                                }
                                break;
                            }
                        case ActionType.Delete:
                            {
                                if (GdvUsers.FindElement(By.XPath("//td[text()[contains(.,'" + fn.testData["UserName"].ToString() + "')]]")).Displayed)
                                {
                                    QCUserCell = GdvUsers.FindElement(By.XPath("//*[@id='gdvList']/tbody//td[text() [contains(.,'" + fn.testData["UserName"].ToString() + "')]]/..//a[@id='imgBtnDelete']"));
                                    QCUserCell.Click();
                                }
                                break;
                            }
                        case ActionType.Disable:
                            {
                                if (GdvUsers.FindElement(By.XPath("//td[text()[contains(.,'" + fn.testData["UserName"].ToString() + "')]]")).Displayed)
                                {

                                    QCUserCell = GdvUsers.FindElement(By.XPath("//*[@id='gdvList']/tbody//td[text() [contains(.,'" + fn.testData["UserName"].ToString() + "')]]/..//a[@id='imgBtnActive']"));
                                    QCUserCell.Click();
                                }
                                break;
                            }
                        case ActionType.Enable:
                            {
                                if (GdvUsers.FindElement(By.XPath("//td[text()[contains(.,'" +fn.testData["UserName"].ToString() + "')]]")).Displayed)
                                {

                                    QCUserCell = GdvUsers.FindElement(By.XPath("//*[@id='gdvList']/tbody//td[text() [contains(.,'" + fn.testData["UserName"].ToString() + "')]]/..//a[@id='imgBtnActive']"));
                                    QCUserCell.Click();
                                }
                                break;
                            }
                        case ActionType.ResetPassword:
                            {
                                if (GdvUsers.FindElement(By.XPath("//td[text()[contains(.,'" + fn.testData["UserName"].ToString() + "')]]")).Displayed)
                                {
                                    QCUserCell = GdvUsers.FindElement(By.XPath("//*[@id='gdvList']/tbody//td[text() [contains(.,'" + fn.testData["UserName"].ToString() + "')]]/..//a[@id='imgBtnResetPassword']"));
                                    QCUserCell.Click();
                                }
                                break;
                            }
                    }

                }
            }
            catch (Exception ex) { }
        }

        public bool CheckViewUser(FunctionParameters fn)
        {
            bool res = false;
            try
            {

                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                res = (txtTxtUsername.GetAttribute("value") == fn.testData["Username"].ToString() ? true : false);
                res = res && (txtTxtEnglishName.GetAttribute("value") == fn.testData["EnglishName"].ToString() ? true : false);
                res = res && (txtTxtArabicName.GetAttribute("value") == fn.testData["ArabicName"].ToString() ? true : false);
                //[text() [contains(., '" + fn.testData["Role"].ToString() + "')]]
                //option[text()='Report Viewer']
                if (ddlDrpRole.FindElement(By.XPath("//option[text()='" + fn.testData["Role"].ToString() + "']")) != null)
                    res = res && true;
                else res = res && false;
                res = res && (txtTxtNationalIdNumber.GetAttribute("value") == fn.testData["NationalIdNumber"].ToString() ? true : false);
                res = res && (txtTxtPhone.GetAttribute("value") == fn.testData["Phone"].ToString() ? true : false);
                res = res && (txtTxtMobile.GetAttribute("value") == fn.testData["Mobile"].ToString() ? true : false);
                res = res && (txtTxtJobTitle.GetAttribute("value") == fn.testData["JobTitle"].ToString() ? true : false);
                res = res && (txtTxtEmail.GetAttribute("value") == fn.testData["Email"].ToString() ? true : false);
                res = res && (txtTxtManagerName.GetAttribute("value") == fn.testData["ManagerName"].ToString() ? true : false);
                res = res && (txtTxtManagerPhone.GetAttribute("value") == fn.testData["ManagerPhone"].ToString() ? true : false);
                res = res && (txtTxtManagerMobile.GetAttribute("value") == fn.testData["ManagerMobile"].ToString() ? true : false);
                res = res && (txtTxtManagerEmail.GetAttribute("value") == fn.testData["ManagerEmail"].ToString() ? true : false);

                return res;

            }
            catch (Exception ex) { return res;}
        }
        public void EditQCUser(FunctionParameters fn)
        {
            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                FillAddQCUserForm(fn.WebBrowser, fn.testData);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
        }
        public void EditUser(FunctionParameters fn)
        {
            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                FillAddUserForm(fn.WebBrowser, fn.testData);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
        }

        public void DeleteQCUser(FunctionParameters fn)
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
        public void DeleteUser(FunctionParameters fn)
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

        public void AddQCUser(FunctionParameters fn)
        {
            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                ProcessAddQCUserForm(fn.testData);
                btnAddUser.Click();
                FillAddQCUserForm(fn.WebBrowser, fn.testData);
                //Update sheet with new values
                DataManager.UpdateExcelSheet(fn.testData.Table, fn.SheetName, "RowID=" + fn.RowNo);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
        }

        public void AddUser(FunctionParameters fn)
        {
            try
            {
                if (fn.testData == null)
                {

                    fn.testData = DataManager.GetExcelDataTable("select top 1 * from [" + fn.SheetName + "$] where RowID=" + fn.RowNo).Rows[0];
                }
                ProcessAddQCUserForm(fn.testData);
                btnAddUser.Click();
                FillAddQCUserForm(fn.WebBrowser, fn.testData);

                //Update sheet with new values
                DataManager.UpdateExcelSheet(fn.testData.Table, fn.SheetName, "RowID=" + fn.RowNo);

                //Update the user passsword as default password("12345678")
                string query;
                query = "Update [EMC_DB].[dbo].[TBL_EMC2_USERS]  set USER_PASSWORD='KawlZg4weOh+MJfTgi5Q1w==' where WEB_USER_ID = '<username>'";
                query = query.Replace("<username>", fn.testData["Username"].ToString());
                DataManager.ExcuteQuery(query);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
        }

        public bool CheckAddNewQCUser(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "AddNewQCUser";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddQCUserSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddQCUserSuccess, fn.ExpectedResult);
            
            
        }
        public bool CheckAddNewUser(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "AddNewUser";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddQCUserSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddQCUserSuccess, fn.ExpectedResult);
        }

        public bool CheckEditQCUser(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "EditNewUser";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddQCUserSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddQCUserSuccess, fn.ExpectedResult);
            
        }
        public bool CheckEditUser(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "EditNewUser";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddQCUserSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddQCUserSuccess, fn.ExpectedResult);
            
        }

        public bool CheckEnableQCUser(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "EnableQCUser";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddQCUserSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddQCUserSuccess, fn.ExpectedResult);
            

        }
        public bool CheckEnableUser(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "EnableUser";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddQCUserSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddQCUserSuccess, fn.ExpectedResult);
            
        }
        public bool CheckDisableQCUser(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "DisableQCUser";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddQCUserSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddQCUserSuccess, fn.ExpectedResult);        
        }
        public bool CheckDisableUser(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "DisableUser";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddQCUserSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddQCUserSuccess, fn.ExpectedResult);
            

        }


        public bool CheckResetQCUserPassword(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "ResetQCUserPasswordUser";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddQCUserSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddQCUserSuccess, fn.ExpectedResult);
            
        }
        public bool CheckResetUserPassword(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "ResetUserPasswordUser";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddQCUserSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddQCUserSuccess, fn.ExpectedResult);
            

        }
        public bool CheckDeleteQCUser(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "Delete QC User";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddQCUserSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddQCUserSuccess, fn.ExpectedResult);
           
        }
        public bool CheckDeleteUser(FunctionParameters fn)
        {
            try
            {
                fn.Function_Name = "Delete  User";
                WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(chkAddQCUserSuccess.GetAttribute("id"))));
            }
            catch (Exception ex) { }
            return Common.CheckPointVerification(chkAddQCUserSuccess, fn.ExpectedResult);

          
        }

        public bool CheckListOfQCUsers()
        {
            if (GdvUsers.Exists())
            {
                if (GdvUsers.Displayed)
                {
                        return true;
                    
                }
                else return false;
            }
            else
                return false;

        }
        public bool CheckListOfUsers()
        {
            if (GdvUsers.Exists())
            {
                if (GdvUsers.Displayed)
                {
                    return true;

                }
                else return false;
            }
            else
                return false;

        }
        public void ClearPage()
        {
            try
            {
                txtTxtEnglishName.Clear();
                txtTxtArabicName.Clear();           
                txtTxtPhone.Clear();
                txtTxtMobile.Clear();
                txtTxtJobTitle.Clear();
                txtTxtEmail.Clear();
                txtTxtManagerName.Clear();
                txtTxtManagerPhone.Clear();
                txtTxtManagerMobile.Clear();
                txtTxtManagerEmail.Clear();
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
        }

        public void ProcessAddQCUserForm(DataRow dr)
        {
            try
            {
                //In case column is Auto, auto generate value
                dr["Username"] = (dr["Username"].ToString().ToLower() == "auto" ? "ahmed" + Faker.RandomNumber.Next(100, 999).ToString() : dr["Username"]);
                dr["EnglishName"] = (dr["EnglishName"].ToString().ToLower() == "auto" ?"Auto"+ Faker.Name.First() : dr["EnglishName"]);
                dr["ArabicName"] = (dr["ArabicName"].ToString().ToLower() == "auto" ? "اوتو " + Faker.Name.ArabicName() : dr["ArabicName"]);
                dr["NationalIdNumber"] = (dr["NationalIdNumber"].ToString().ToLower() == "auto" ? Faker.NationalID.NationalNumber() : dr["NationalIdNumber"]);
                dr["Phone"] = (dr["Phone"].ToString().ToLower() == "auto" ? Faker.Phone.Number("011#######") : dr["Phone"]);
                dr["Mobile"] = (dr["Mobile"].ToString().ToLower() == "auto" ? Faker.Phone.Number("9665########") : dr["Mobile"]);
                dr["JobTitle"] = (dr["JobTitle"].ToString().ToLower() == "auto" ? "Senior QC "+Faker.Company.Name() : dr["JobTitle"]);
                dr["Email"] = (dr["Email"].ToString().ToLower() == "auto" ? Faker.Internet.Email() : dr["Email"]);
                dr["ManagerName"] = (dr["ManagerName"].ToString().ToLower() == "auto" ? Faker.Name.First() : dr["ManagerName"]);
                dr["ManagerPhone"] = (dr["ManagerPhone"].ToString().ToLower() == "auto" ? Faker.Phone.Number("011#######") : dr["ManagerPhone"]);
                dr["ManagerMobile"] = (dr["ManagerMobile"].ToString().ToLower() == "auto" ? Faker.Phone.Number("9665########") : dr["ManagerMobile"]);
                dr["ManagerEmail"] = (dr["ManagerEmail"].ToString().ToLower() == "auto" ? Faker.Internet.Email() : dr["ManagerEmail"]);

            }
            catch (Exception ex) { }
            
        }
        public void FillAddQCUserForm(Browser bro, DataRow dr)
        {
            ClearPage();

            WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
            txtTxtUsername.SendKeys(dr["Username"].ToString());
            txtTxtEnglishName.SendKeys(dr["EnglishName"].ToString());
            txtTxtArabicName.SendKeys(dr["ArabicName"].ToString());
            SelectElement ddlDrpRoleSelector = new SelectElement(ddlDrpRole);
            ddlDrpRoleSelector.SelectByText(dr["Role"].ToString());
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("ctl00$ContentPlaceHolder1$txtNationalIdNumber")));
            txtTxtNationalIdNumber.SendKeys(dr["NationalIdNumber"].ToString());
            txtTxtPhone.SendKeys(dr["Phone"].ToString());
            txtTxtMobile.SendKeys(dr["Mobile"].ToString());
            txtTxtJobTitle.SendKeys(dr["JobTitle"].ToString());
            txtTxtEmail.SendKeys(dr["Email"].ToString());
            txtTxtManagerName.SendKeys(dr["ManagerName"].ToString());
            txtTxtManagerPhone.SendKeys(dr["ManagerPhone"].ToString());
            txtTxtManagerMobile.SendKeys(dr["ManagerMobile"].ToString());
            txtTxtManagerEmail.SendKeys(dr["ManagerEmail"].ToString());
            btnBtnSave.Click();

        }
        public void FillAddUserForm(Browser bro, DataRow dr)
        {
            ClearPage();

            WebDriverWait wait = new WebDriverWait(bro.WebDriver, TimeSpan.FromSeconds(bro.DefaultTimeout));
            txtTxtUsername.SendKeys(dr["Username"].ToString());
            txtTxtEnglishName.SendKeys(dr["EnglishName"].ToString());
            txtTxtArabicName.SendKeys(dr["ArabicName"].ToString());
            SelectElement ddlDrpRoleSelector = new SelectElement(ddlDrpRole);
            ddlDrpRoleSelector.SelectByText(dr["Role"].ToString());
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("ctl00$ContentPlaceHolder1$txtNationalIdNumber")));
            txtTxtNationalIdNumber.SendKeys(dr["NationalIdNumber"].ToString());
            txtTxtPhone.SendKeys(dr["Phone"].ToString());
            txtTxtMobile.SendKeys(dr["Mobile"].ToString());
            txtTxtJobTitle.SendKeys(dr["JobTitle"].ToString());
            txtTxtEmail.SendKeys(dr["Email"].ToString());
            txtTxtManagerName.SendKeys(dr["ManagerName"].ToString());
            txtTxtManagerPhone.SendKeys(dr["ManagerPhone"].ToString());
            txtTxtManagerMobile.SendKeys(dr["ManagerMobile"].ToString());
            txtTxtManagerEmail.SendKeys(dr["ManagerEmail"].ToString());
            btnBtnSave.Click();

        }
    }
}