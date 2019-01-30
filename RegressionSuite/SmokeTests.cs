using System;
using System.Data;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.IO;

using System.Threading.Tasks;
using System.Xml;
using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFramework;
using System.Configuration;
using OpenQA.Selenium;
using System.Diagnostics;

namespace RegressionSuite
{
    //   [TestClass]
    public class SmokeTests : TestBase
    {



        #region Izhar's

        public void AddNewHospital(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageHospitalPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageHospitalPage(fn.WebDriver).AddNewHospital(fn);
                // //Assert.IsTrue(Pages.ManageHospitalPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageHospitalPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageHospitalPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ViewHospital(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageHospitalPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageHospitalPage(fn.WebDriver).ViewHospital(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageHospitalPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ManageHospitalPage(fn.WebDriver).CheckOverall());
            }


        }

        public void EditHospital(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageHospitalPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageHospitalPage(fn.WebDriver).EditHospital(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageHospitalPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageHospitalPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void DeleteHospital(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageHospitalPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageHospitalPage(fn.WebDriver).DeleteHospital(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageHospitalPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ManageHospitalPage(fn.WebDriver).CheckOverall());
            }

        }

        public void ActivateHospital(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageHospitalPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageHospitalPage(fn.WebDriver).ActivateHospital(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageHospitalPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageHospitalPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void DeActivateHospital(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageHospitalPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageHospitalPage(fn.WebDriver).DeActivateHospital(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageHospitalPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageHospitalPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ActivateBranch(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageBranchPage(fn.WebDriver).GoTo_Hospital(fn.WebBrowser);
                Pages.ManageBranchPage(fn.WebDriver).ActivateBranch(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageBranchPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageBranchPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void DeActivateBranch(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageBranchPage(fn.WebDriver).GoTo_Hospital(fn.WebBrowser);
                Pages.ManageBranchPage(fn.WebDriver).DeActivateBranch(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageBranchPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageBranchPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void CertificateInquriy(FunctionParameters fn)
        {
            try
            {
                //Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.PublicInquiryPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.PublicInquiryPage(fn.WebDriver).CertificateInquriy(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.PublicInquiryPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.PublicInquiryPage(fn.WebDriver).CheckOverall());
            }

        }

        public void SickLeaveInquiry(FunctionParameters fn)
        {
            try
            {
                //Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.PublicInquiryPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.PublicInquiryPage(fn.WebDriver).SickLeaveInquiry(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.PublicInquiryPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.PublicInquiryPage(fn.WebDriver).CheckOverall());
            }

        }


        public void AddNewBranch(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageBranchPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageBranchPage(fn.WebDriver).AddNewBranch(fn);
                //////Assert.IsTrue(Pages.ManageBranchPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageBranchPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageBranchPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ViewBranch(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageBranchPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageBranchPage(fn.WebDriver).ViewBranch(fn);
                // //Assert.IsTrue(Pages.ManageBranchPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageBranchPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ManageBranchPage(fn.WebDriver).CheckOverall());
            }

        }

        public void EditBranch(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageBranchPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageBranchPage(fn.WebDriver).EditBranch(fn);
                ////Assert.IsTrue(Pages.ManageBranchPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageBranchPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageBranchPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void DeleteBranch(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageBranchPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageBranchPage(fn.WebDriver).DeleteBranch(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageBranchPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ManageBranchPage(fn.WebDriver).CheckOverall());
            }

        }

        public void AddNewHospitalUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageHospitalUsersPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageHospitalUsersPage(fn.WebDriver).AddNewHospitalUser(fn);
                ////Assert.IsTrue(Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ViewHospitalUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageHospitalUsersPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageHospitalUsersPage(fn.WebDriver).ViewHospitalUser(fn);
                // //Assert.IsTrue(Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageHospitalUsersPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ManageHospitalUsersPage(fn.WebDriver).CheckOverall());
            }


        }

        public void EditHospitalUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageHospitalUsersPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageHospitalUsersPage(fn.WebDriver).EditHospitalUser(fn);
                ////Assert.IsTrue(Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void DeleteHospitalUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageHospitalUsersPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageHospitalUsersPage(fn.WebDriver).DeleteHospitalUser(fn);
                // //Assert.IsTrue(Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ActivateHospitalUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageHospitalUsersPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageHospitalUsersPage(fn.WebDriver).ActivateHospitalUser(fn);
                // //Assert.IsTrue(Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void DeactivateHospitalUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageHospitalUsersPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageHospitalUsersPage(fn.WebDriver).DeactivateHospitalUser(fn);
                // //Assert.IsTrue(Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ResetHospitalUserPassword(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageHospitalUsersPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageHospitalUsersPage(fn.WebDriver).ResetHospitalUserPassword(fn);
                // //Assert.IsTrue(Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageHospitalUsersPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void AddNewBranchUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageBranchUsersPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageBranchUsersPage(fn.WebDriver).AddNewBranchUser(fn);
                ////Assert.IsTrue(Pages.ManageBranchUsersPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageBranchUsersPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageBranchUsersPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ViewBranchUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageBranchUsersPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageBranchUsersPage(fn.WebDriver).ViewBranchUser(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageBranchUsersPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ManageBranchUsersPage(fn.WebDriver).CheckOverall());
            }


        }

        public void EditBranchUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageBranchUsersPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageBranchUsersPage(fn.WebDriver).EditBranchUser(fn);
                ////Assert.IsTrue(Pages.ManageBranchUsersPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageBranchUsersPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageBranchUsersPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void DeleteBranchUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageBranchUsersPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageBranchUsersPage(fn.WebDriver).DeleteBranchUser(fn);
                //   //Assert.IsTrue(Pages.ManageBranchUsersPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageBranchUsersPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageBranchUsersPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ActivateBranchUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageBranchUsersPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageBranchUsersPage(fn.WebDriver).ActivateBranchUser(fn);
                ////Assert.IsTrue(Pages.ManageBranchUsersPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageBranchUsersPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ManageBranchUsersPage(fn.WebDriver).CheckOverall());
            }




        }

        public void DeactivateBranchUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageBranchUsersPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageBranchUsersPage(fn.WebDriver).DeactivateBranchUser(fn);
                ////Assert.IsTrue(Pages.ManageBranchUsersPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageBranchUsersPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ManageBranchUsersPage(fn.WebDriver).CheckOverall());
            }


        }


        public void ResetBranchUserPassword(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageBranchUsersPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageBranchUsersPage(fn.WebDriver).ResetBranchUserPassword(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageBranchUsersPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageBranchUsersPage(fn.WebDriver).CheckSuccess());
            }


        }




        public void AddNewMedicalTest(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageMedicalTestPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageMedicalTestPage(fn.WebDriver).AddNewMedicalTest(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ViewMedicalTest(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageMedicalTestPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageMedicalTestPage(fn.WebDriver).ViewMedicalTest(fn);
                //   //Assert.IsTrue(Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageMedicalTestPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ManageMedicalTestPage(fn.WebDriver).CheckOverall());
            }


        }

        public void EditMedicalTest(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageMedicalTestPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageMedicalTestPage(fn.WebDriver).EditMedicalTest(fn);
                //   //Assert.IsTrue(Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void DeleteMedicalTest(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageMedicalTestPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageMedicalTestPage(fn.WebDriver).DeleteMedicalTest(fn);
                // //Assert.IsTrue(Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ActivateMedicalTest(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageMedicalTestPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageMedicalTestPage(fn.WebDriver).ActivateMedicalTest(fn);
                // //Assert.IsTrue(Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void DeactivateMedicalTest(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageMedicalTestPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageMedicalTestPage(fn.WebDriver).DeactivateMedicalTest(fn);
                // //Assert.IsTrue(Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageMedicalTestPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void AddAdminUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageControlPanelPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageControlPanelPage(fn.WebDriver).AddAdminUser(fn);
                //  //Assert.IsTrue(Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ViewAdminUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageControlPanelPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageControlPanelPage(fn.WebDriver).ViewAdminUser(fn);
                // //Assert.IsTrue(Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageControlPanelPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ManageControlPanelPage(fn.WebDriver).CheckOverall());
            }

        }

        public void EditAdminUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageControlPanelPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageControlPanelPage(fn.WebDriver).EditAdminUser(fn);
                // //Assert.IsTrue(Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void DeleteAdminUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageControlPanelPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageControlPanelPage(fn.WebDriver).DeleteAdminUser(fn);
                ////Assert.IsTrue(Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ActivateAdminUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageControlPanelPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageControlPanelPage(fn.WebDriver).ActivateAdminUser(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void DeactivateAdminUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageControlPanelPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageControlPanelPage(fn.WebDriver).DeactivateAdminUser(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void RestAdminUserPassword(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageControlPanelPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageControlPanelPage(fn.WebDriver).RestAdminUserPassword(fn);
                ////Assert.IsTrue(Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageControlPanelPage(fn.WebDriver).CheckSuccess());
            }

        }


        public void AddNewCertificate(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageCertificatePage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageCertificatePage(fn.WebDriver).AddNewCertificate(fn);
                // //Assert.IsTrue(Pages.ManageCertificatePage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageCertificatePage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageCertificatePage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ViewCertificate(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageCertificatePage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageCertificatePage(fn.WebDriver).ViewCertificate(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageCertificatePage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ManageCertificatePage(fn.WebDriver).CheckOverall());
            }

        }

        public void EditCertificate(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageCertificatePage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageCertificatePage(fn.WebDriver).EditCertificate(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageCertificatePage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageCertificatePage(fn.WebDriver).CheckSuccess());
            }

        }

        public void DeleteCertificate(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageCertificatePage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageCertificatePage(fn.WebDriver).DeleteCertificate(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageCertificatePage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ManageCertificatePage(fn.WebDriver).CheckOverall());
            }

        }

        public void ActivateCertificate(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageCertificatePage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageCertificatePage(fn.WebDriver).ActivateCertificate(fn);
                ////Assert.IsTrue(Pages.ManageCertificatePage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageCertificatePage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageCertificatePage(fn.WebDriver).CheckSuccess());
            }

        }

        public void DeActivateCertificate(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageCertificatePage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageCertificatePage(fn.WebDriver).DeActivateCertificate(fn);
                ////Assert.IsTrue(Pages.ManageCertificatePage(fn.WebDriver).CheckSuccess());
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageCertificatePage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageCertificatePage(fn.WebDriver).CheckSuccess());
            }

        }

        public void AddCertificateResultRetestPermission(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.CertificateResultRetestPermissionPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.CertificateResultRetestPermissionPage(fn.WebDriver).Add(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.CertificateResultRetestPermissionPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.CertificateResultRetestPermissionPage(fn.WebDriver).CheckSuccess());
            }

        }

        public void DeleteCertificateResultRetestPermission(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.CertificateResultRetestPermissionPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.CertificateResultRetestPermissionPage(fn.WebDriver).Delete(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.CertificateResultRetestPermissionPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.CertificateResultRetestPermissionPage(fn.WebDriver).CheckOverall());
            }

        }

        public void ViewFunction(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageFunctionPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageFunctionPage(fn.WebDriver).ViewFunction(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageFunctionPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ManageFunctionPage(fn.WebDriver).CheckOverall());
            }

        }

        public void EditFunction(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageFunctionPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageFunctionPage(fn.WebDriver).EditFunction(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageFunctionPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageFunctionPage(fn.WebDriver).CheckSuccess());
            }

        }



        public void ViewMyProfile1(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ViewMyProfilePage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ViewMyProfilePage(fn.WebDriver).ViewMyProfile(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ViewMyProfilePage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ViewMyProfilePage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ViewClientCertificateRequest(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientCertificateRequestPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientCertificateRequestPage(fn.WebDriver).ViewClientCertificateRequest(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ClientCertificateRequestPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ClientCertificateRequestPage(fn.WebDriver).CheckOverall());
            }

        }

        public void ViewClientRequest(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientRequestPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientRequestPage(fn.WebDriver).ViewClientRequest(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ClientRequestPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ClientRequestPage(fn.WebDriver).CheckOverall());
            }

        }

        public void CreateClientRequest4Individual(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientRequest4IndividualPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientRequest4IndividualPage(fn.WebDriver).CreateClientRequest4Individual(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ClientRequest4IndividualPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.ClientRequest4IndividualPage(fn.WebDriver).CheckOverall());
            }

        }




        public void AddNewMohDoctor(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.MohDoctorsPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.MohDoctorsPage(fn.WebDriver).AddNewMohDoctor(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.MohDoctorsPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.MohDoctorsPage(fn.WebDriver).CheckSuccess());
            }

        }


        public void ViewMohDoctor(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.MohDoctorsPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.MohDoctorsPage(fn.WebDriver).ViewMohDoctor(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.MohDoctorsPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.MohDoctorsPage(fn.WebDriver).CheckOverall());
            }

        }

        public void EditMohDoctor(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.MohDoctorsPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.MohDoctorsPage(fn.WebDriver).EditMohDoctor(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.MohDoctorsPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.MohDoctorsPage(fn.WebDriver).CheckOverall());
            }

        }

        public void DeleteMohDoctor(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.MohDoctorsPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.MohDoctorsPage(fn.WebDriver).DeleteMohDoctor(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.MohDoctorsPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.MohDoctorsPage(fn.WebDriver).CheckOverall());
            }

        }


        public void AddHospitalDoctorUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.HospitalDoctorsPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.HospitalDoctorsPage(fn.WebDriver).AddHospitalDoctorUser(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.HospitalDoctorsPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.HospitalDoctorsPage(fn.WebDriver).CheckSuccess());
            }

        }



        public void ViewHospitalDoctorUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.HospitalDoctorsPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.HospitalDoctorsPage(fn.WebDriver).ViewHospitalDoctorUser(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.HospitalDoctorsPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.HospitalDoctorsPage(fn.WebDriver).CheckOverall());
            }

        }

        public void EditHospitalDoctorUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.HospitalDoctorsPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.HospitalDoctorsPage(fn.WebDriver).EditHospitalDoctorUser(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.HospitalDoctorsPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.HospitalDoctorsPage(fn.WebDriver).CheckOverall());
            }

        }

        public void DeleteHospitalDoctorUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.HospitalDoctorsPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.HospitalDoctorsPage(fn.WebDriver).DeleteHospitalDoctorUser(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.HospitalDoctorsPage(fn.WebDriver).CheckOverall());
                Reporter.ReportResultsToXML(fn, Pages.HospitalDoctorsPage(fn.WebDriver).CheckOverall());
            }

        }

        public string GetLastLoginID(String SheetName, string rowNo)
        {
            DataTable dt = new DataTable();
            string query;
            string LastLoginID = "";


            query = "select top 1 LoginRowId from[<SheetName>$]  where[<SheetName>$].RowId = <ROWID>";
            query = query.Replace("<SheetName>", SheetName);
            query = query.Replace("<ROWID>", rowNo);

            dt = DataManager.GetExcelDataTable(query);

            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    LastLoginID = r["LoginRowId"].ToString();
                }
            }
            return LastLoginID;
        }



        public void ExecuteTestSuite(FunctionParameters fn)
        {
            //This function will run the test suite in sequential order using a single webdriver object.
            try
            {

                string query = "";
                string LastLoginID = "0";
                DataTable dt = new DataTable();
                query = "select * from [Driver$] where RowID in (<IDs>)";
                string Ids = GenericFunction.GetString(GenericFunction.GetIterations(fn.RowNo));
                query = query.Replace("<IDs>", Ids);
                dt = DataManager.GetExcelDataTable(query);


                if (dt == null)
                {
                    Console.WriteLine("Excel Sheet not found.");
                    return;
                }
                FunctionParameters fncParam = null;
                foreach (DataRow r in dt.Rows)
                {

                    fncParam = new FunctionParameters(r, fn.WebDriver, fn.WebBrowser, LastLoginID);
                    //get loginrow id and set it to lastloginid

                    ExecuteFunction(fncParam);
                    LastLoginID = GetLastLoginID(r["TestDataSheetName"].ToString(), r["TestDataSheetRowNo"].ToString());


                }


            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {

            }

        }





        public void ChangePassword(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ViewMyProfilePage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ViewMyProfilePage(fn.WebDriver).ChangePassword(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ViewMyProfilePage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ViewMyProfilePage(fn.WebDriver).CheckSuccess());
            }

        }

        public void ChangeCertificatePrice(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.MyAccountPage(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.MyAccountPage(fn.WebDriver).ChangeCertificatePrice(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.MyAccountPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.MyAccountPage(fn.WebDriver).CheckSuccess());
            }

        }


        #endregion


        #region QC_Management
        public void ListQCAccounts(FunctionParameters fn)
        {
            try
            {


                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageQCAccount(fn.WebDriver).DisplayListOfQCAccounts(fn);
            }
            catch (Exception ex) { fn.Message = ex.Message; }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ManageQCAccount(fn.WebDriver).CheckListQCAccount());
                Reporter.ReportResultsToExcel(fn, Pages.ManageQCAccount(fn.WebDriver).CheckListQCAccount());
            }
        }

        public void AddQCAccounts(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageQCAccount(fn.WebDriver).AddNewQCAccount(fn);
                ;
            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ManageQCAccount(fn.WebDriver).CheckAddNewQCAccountSuccess(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ManageQCAccount(fn.WebDriver).CheckAddNewQCAccountSuccess(fn));

            }

        }

        public void AddQCAccountsMOIExist(FunctionParameters fn)
        {
            try
            {
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageQCAccount(fn.WebDriver).AddNewQCAccount(fn);
                ;
            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ManageQCAccount(fn.WebDriver).CheckAddNewQCAccount_MOIAlreadyExist(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ManageQCAccount(fn.WebDriver).CheckAddNewQCAccount_MOIAlreadyExist(fn));
            }

        }




        public void AddQCAccounts_InvalidMOI(FunctionParameters fn)

        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageQCAccount(fn.WebDriver).AddNewQCAccount(fn);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ManageQCAccount(fn.WebDriver).CheckAddNewQCAccount_InvalidMOI(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ManageQCAccount(fn.WebDriver).CheckAddNewQCAccount_InvalidMOI(fn));
            }

        }


        public void EditQCAccounts(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageQCAccount(fn.WebDriver).SearchQCAccount(fn, QCAccountManagement.ActionType.Edit);
                Pages.ManageQCAccount(fn.WebDriver).EditQCAccount(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ManageQCAccount(fn.WebDriver).CheckEditQCAccountSuccess(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ManageQCAccount(fn.WebDriver).CheckEditQCAccountSuccess(fn));
            }
        }


        public void DeleteQCAccounts(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageQCAccount(fn.WebDriver).SearchQCAccount(fn, QCAccountManagement.ActionType.Delete);
                Pages.ManageQCAccount(fn.WebDriver).DeleteQCAccount(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ManageQCAccount(fn.WebDriver).CheckDeleteQCAccountSuccess(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ManageQCAccount(fn.WebDriver).CheckDeleteQCAccountSuccess(fn));

            }
        }

        public void DeleteQCAccountsInUse(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageQCAccount(fn.WebDriver).SearchQCAccount(fn, QCAccountManagement.ActionType.Delete);
                Pages.ManageQCAccount(fn.WebDriver).DeleteQCAccount(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ManageQCAccount(fn.WebDriver).CheckDeleteQCAccountInUse(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ManageQCAccount(fn.WebDriver).CheckDeleteQCAccountInUse(fn));

            }

        }

        public void DisableQCAccounts(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageQCAccount(fn.WebDriver).SearchQCAccount(fn, QCAccountManagement.ActionType.Disable);

            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ManageQCAccount(fn.WebDriver).CheckDisableQCAccountSuccess(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ManageQCAccount(fn.WebDriver).CheckDisableQCAccountSuccess(fn));

            }
        }

        public void EnableQCAccounts(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageQCAccount(fn.WebDriver).SearchQCAccount(fn, QCAccountManagement.ActionType.Enable);

            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ManageQCAccount(fn.WebDriver).CheckEnableQCAccountSuccess(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ManageQCAccount(fn.WebDriver).CheckEnableQCAccountSuccess(fn));
            }
        }


        public void AddQCUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManageQCAccount(fn.WebDriver).SearchQCAccount(fn, QCAccountManagement.ActionType.Edit);
                Pages.UsersManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.UsersManagement(fn.WebDriver).AddQCUser(fn);

            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckAddNewQCUser(fn));
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckAddNewQCUser(fn));

            }
        }


        public void DeleteQCUser(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                //Go to QC Account page
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);


                Pages.ManageQCAccount(fn.WebDriver).SearchQCAccount(fn, QCAccountManagement.ActionType.Edit);


                //Go to User Management Page
                Pages.UsersManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.UsersManagement(fn.WebDriver).SearchUser(fn, UsersManagement.ActionType.Delete);
                Pages.UsersManagement(fn.WebDriver).DeleteQCUser(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckDeleteQCUser(fn));
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckDeleteQCUser(fn));

            }
        }


        public void EditQCUser(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                //Go to QC Account page
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);


                Pages.ManageQCAccount(fn.WebDriver).SearchQCAccount(fn, QCAccountManagement.ActionType.Edit);


                //Go to User Management Page
                Pages.UsersManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.UsersManagement(fn.WebDriver).SearchUser(fn, UsersManagement.ActionType.Edit);
                Pages.UsersManagement(fn.WebDriver).EditQCUser(fn);

            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckEditQCUser(fn));
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckEditQCUser(fn));

            }
        }

        public void EnableQCUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                //Go to QC Account page
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);


                Pages.ManageQCAccount(fn.WebDriver).SearchQCAccount(fn, QCAccountManagement.ActionType.Edit);


                //Go to User Management Page
                Pages.UsersManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.UsersManagement(fn.WebDriver).SearchUser(fn, UsersManagement.ActionType.Enable);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckEnableQCUser(fn));
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckEnableQCUser(fn));

            }
        }

        public void DisableQCUser(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                //Go to QC Account page
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);

                Pages.ManageQCAccount(fn.WebDriver).SearchQCAccount(fn, QCAccountManagement.ActionType.Edit);

                //Go to User Management Page
                Pages.UsersManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.UsersManagement(fn.WebDriver).SearchUser(fn, UsersManagement.ActionType.Disable);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckDisableQCUser(fn));
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckDisableQCUser(fn));
            }
        }

        public void ResetQCUserPassword(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                //Go to QC Account page
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);


                Pages.ManageQCAccount(fn.WebDriver).SearchQCAccount(fn, QCAccountManagement.ActionType.Edit);


                //Go to User Management Page
                Pages.UsersManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.UsersManagement(fn.WebDriver).SearchUser(fn, UsersManagement.ActionType.ResetPassword);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckResetQCUserPassword(fn));
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckResetQCUserPassword(fn));

            }
        }

        public void ViewListOfQCUsers(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                //Go to QC Account page
                Pages.ManageQCAccount(fn.WebDriver).GoTo(fn.WebBrowser);

                Pages.ManageQCAccount(fn.WebDriver).SearchQCAccount(fn, QCAccountManagement.ActionType.Edit);

                //Go to User Management Page
                Pages.UsersManagement(fn.WebDriver).GoTo(fn.WebBrowser);


            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckListOfQCUsers());
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckListOfQCUsers());

            }

        }

        public void QCAccountManagementTest(FunctionParameters fn)
        {
            AddQCAccounts(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EditQCAccounts(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EnableQCAccounts(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            DisableQCAccounts(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EnableQCAccounts(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            DeleteQCAccountsInUse(fn);


        }

        public void QCUsersManagementTest(FunctionParameters fn)
        {
            AddQCUser(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EditQCUser(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EnableQCUser(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            DisableQCUser(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EnableQCUser(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            ResetQCUserPassword(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            DeleteQCUser(fn);


        }
        #endregion        

        #region ClientManagement

        public void ViewMyProfile(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.UsersManagement(fn.WebDriver).GoToMyProfile(fn.WebBrowser);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckViewUser(fn));
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckViewUser(fn));
            }

        }

        public void AddClient(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).AddNewClient(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ClientManagement(fn.WebDriver).CheckAddNewClient(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ClientManagement(fn.WebDriver).CheckAddNewClient(fn));

            }


        }


        public void EditClient(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.Edit);
                Pages.ClientManagement(fn.WebDriver).EditClient(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ClientManagement(fn.WebDriver).CheckEditClient(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ClientManagement(fn.WebDriver).CheckEditClient(fn));
            }

        }

        public void EnableClient(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.Enable);

            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ClientManagement(fn.WebDriver).CheckEnableClient(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ClientManagement(fn.WebDriver).CheckEnableClient(fn));
            }

        }

        public void DisableClient(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.Disable);

            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ClientManagement(fn.WebDriver).CheckDisbleClient(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ClientManagement(fn.WebDriver).CheckDisbleClient(fn));
            }

        }

        public void DeleteClient(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.Delete);
                Pages.ClientManagement(fn.WebDriver).DeleteClientAccount(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ClientManagement(fn.WebDriver).CheckDeleteClient(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ClientManagement(fn.WebDriver).CheckDeleteClient(fn));
            }

        }

        public void DeleteClientFail(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.Delete);
                Pages.ClientManagement(fn.WebDriver).DeleteClientAccount(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ClientManagement(fn.WebDriver).CheckDeleteClientFail(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ClientManagement(fn.WebDriver).CheckDeleteClientFail(fn));
            }

        }

        public void ViewClient(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.View);
            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ClientManagement(fn.WebDriver).CheckViewClient(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ClientManagement(fn.WebDriver).CheckViewClient(fn));
            }

        }


        public void ViewClientDetails(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoToMyAccount(fn.WebBrowser);

            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ClientManagement(fn.WebDriver).ViewClientDetails(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ClientManagement(fn.WebDriver).ViewClientDetails(fn));

            }

        }

        public void CertificateManagement(FunctionParameters fn)
        {
            AddClientCertificate(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            RemoveClientCertificate(fn);



        }

        public void SickLeaveManagement(FunctionParameters fn)
        {
            AddClientSickLeave(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            RemoveClientSickLeave(fn);
        }

        public void AddClientCertificate(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.View);
                Pages.ClientManagement(fn.WebDriver).AddClientCertificate(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ClientManagement(fn.WebDriver).CheckAddCertificateToClient(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ClientManagement(fn.WebDriver).CheckAddCertificateToClient(fn));
            }


        }

        public void RemoveClientCertificate(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.View);
                Pages.ClientManagement(fn.WebDriver).RemoveClientCertificate(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ClientManagement(fn.WebDriver).CheckRemoveCertificateFromClient(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ClientManagement(fn.WebDriver).CheckRemoveCertificateFromClient(fn));
            }


        }

        public void AddClientSickLeave(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.View);
                Pages.ClientManagement(fn.WebDriver).GoToSickLeaves(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).AddClientSickLeave(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ClientManagement(fn.WebDriver).CheckAssociateHospitalToClient(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ClientManagement(fn.WebDriver).CheckAssociateHospitalToClient(fn));
            }
        }

        public void RemoveClientSickLeave(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.View);
                Pages.ClientManagement(fn.WebDriver).GoToSickLeaves(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).RemoveClientSickLeave(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.ClientManagement(fn.WebDriver).CheckRemoveAssociateHospitalToClient(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ClientManagement(fn.WebDriver).CheckRemoveAssociateHospitalToClient(fn));
            }


        }

        public void ViewListOfClientUsers(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.Edit);
                Pages.UsersManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.UsersManagement(fn.WebDriver).AddUser(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckAddNewQCUser(fn));
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckAddNewQCUser(fn));
            }


        }

        public void AddClientUser(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.Edit);
                Pages.UsersManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.UsersManagement(fn.WebDriver).AddUser(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckAddNewQCUser(fn));
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckAddNewQCUser(fn));
            }
        }

        public void EditClientUser(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.Edit);

                //Go to User Management Page
                Pages.UsersManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.UsersManagement(fn.WebDriver).SearchUser(fn, UsersManagement.ActionType.Edit);
                Pages.UsersManagement(fn.WebDriver).EditUser(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckEditUser(fn));
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckEditUser(fn));
            }
        }

        public void EnableClientUser(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.Edit);

                //Go to User Management Page
                Pages.UsersManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.UsersManagement(fn.WebDriver).SearchUser(fn, UsersManagement.ActionType.Enable);

            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckEnableUser(fn));
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckEnableUser(fn));
            }
        }

        public void DisableClientUser(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.Edit);

                //Go to User Management Page
                Pages.UsersManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.UsersManagement(fn.WebDriver).SearchUser(fn, UsersManagement.ActionType.Disable);

            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckDisableUser(fn));
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckDisableUser(fn));
            }
        }

        public void DeleteClientUser(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.Edit);

                //Go to User Management Page
                Pages.UsersManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.UsersManagement(fn.WebDriver).SearchUser(fn, UsersManagement.ActionType.Delete);
                Pages.UsersManagement(fn.WebDriver).DeleteUser(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckDeleteUser(fn));
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckDeleteUser(fn));
            }
        }

        public void ResetClientUserPassword(FunctionParameters fn)
        {

            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ClientManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ClientManagement(fn.WebDriver).SearchClient(fn, ClientManagement.ActionType.Edit);

                //Go to User Management Page
                Pages.UsersManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.UsersManagement(fn.WebDriver).SearchUser(fn, UsersManagement.ActionType.ResetPassword);

            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.UsersManagement(fn.WebDriver).CheckResetUserPassword(fn));
                Reporter.ReportResultsToExcel(fn, Pages.UsersManagement(fn.WebDriver).CheckResetUserPassword(fn));
            }
        }

        public void EnableDisableView(FunctionParameters fn)
        {
            DisableClient(fn);
            EnableClient(fn);

            ViewClient(fn);
        }

        public void ClientManagementTest(FunctionParameters fn)
        {
            AddClient(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EditClient(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            ViewClient(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EnableClient(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            DisableClient(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EnableClient(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            AddClientCertificate(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            RemoveClientCertificate(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            AddClientSickLeave(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            RemoveClientSickLeave(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            DeleteClient(fn);

        }

        public void ClientUserTest(FunctionParameters fn)
        {
            AddClientUser(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EditClientUser(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            DisableClientUser(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EnableClientUser(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            ResetClientUserPassword(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            DeleteClientUser(fn);
        }
        #endregion

        #region SickLeaveManagmenet
        public void AddSickLeave(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.SickLeaveManagement(fn.WebDriver).GoToAddSickLeavePage(fn.WebBrowser);
                Pages.SickLeaveManagement(fn.WebDriver).AddSickLeave(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.SickLeaveManagement(fn.WebDriver).CheckAddSickLeave(fn));
                Reporter.ReportResultsToExcel(fn, Pages.SickLeaveManagement(fn.WebDriver).CheckAddSickLeave(fn));
            }
        }


        public void SearchSickLeave(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.SickLeaveManagement(fn.WebDriver).GoToSickLeaveList(fn.WebBrowser);
                Pages.SickLeaveManagement(fn.WebDriver).SearchSickLeave(fn, SeleniumFramework.SickLeaveManagement.ActionType.Edit);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {

            }
        }

        public void ApproveSickLeave(FunctionParameters fn)
        {
            try
            {
                SearchSickLeave(fn);
                Pages.SickLeaveManagement(fn.WebDriver).BrowseSickLeave(fn);
                Pages.SickLeaveManagement(fn.WebDriver).ApproveSickLeave(fn);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.SickLeaveManagement(fn.WebDriver).CheckApproveSickLeave(fn));
                Reporter.ReportResultsToExcel(fn, Pages.SickLeaveManagement(fn.WebDriver).CheckApproveSickLeave(fn));
            }
        }

        public void RejectSickLeave(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.SickLeaveManagement(fn.WebDriver).GoToSickLeaveList(fn.WebBrowser);
                Pages.SickLeaveManagement(fn.WebDriver).SearchSickLeave(fn, SeleniumFramework.SickLeaveManagement.ActionType.Edit);
                Pages.SickLeaveManagement(fn.WebDriver).BrowseSickLeave(fn);
                Pages.SickLeaveManagement(fn.WebDriver).RejectSickLeave(fn);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.SickLeaveManagement(fn.WebDriver).CheckRejectSickLeave(fn));
                Reporter.ReportResultsToExcel(fn, Pages.SickLeaveManagement(fn.WebDriver).CheckRejectSickLeave(fn));
            }
        }


        public void AddSearchSickLeave(FunctionParameters fn)
        {
            try
            {
                AddSickLeave(fn);
                SearchSickLeave(fn);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {

            }
        }

        public void SickLeaveManagementTest(FunctionParameters fn)
        {
            AddSickLeave(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            ApproveSickLeave(fn);

        }

        #endregion

        #region CertificateResultManagement

        public void AddCertificateResult(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.CertificateManagement(fn.WebDriver).GoToCertificatesAddList(fn.WebBrowser);
                Pages.CertificateManagement(fn.WebDriver).SearchClient(fn, SeleniumFramework.CertificateManagement.ActionType.Add);
                Pages.CertificateManagement(fn.WebDriver).AddCertificate(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {

                Reporter.ReportResultsToExcel(fn, Pages.CertificateManagement(fn.WebDriver).CheckAddCertificate(fn));
                Reporter.ReportResultsToXML(fn, Pages.CertificateManagement(fn.WebDriver).CheckAddCertificate(fn));
            }
        }

        public void Add_ApproveCertificateResult(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.CertificateManagement(fn.WebDriver).GoToCertificatesAddList(fn.WebBrowser);
                Pages.CertificateManagement(fn.WebDriver).SearchClient(fn, SeleniumFramework.CertificateManagement.ActionType.Add);
                Pages.CertificateManagement(fn.WebDriver).AddCertificate(fn);
                Pages.CertificateManagement(fn.WebDriver).ApproveCertificate(fn);
            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.CertificateManagement(fn.WebDriver).CheckApproveCertificate(fn));
                Reporter.ReportResultsToXML(fn, Pages.CertificateManagement(fn.WebDriver).CheckApproveCertificate(fn));
            }
        }

        public void Add_RejectCertificateResult(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.CertificateManagement(fn.WebDriver).GoToCertificatesAddList(fn.WebBrowser);
                Pages.CertificateManagement(fn.WebDriver).SearchClient(fn, SeleniumFramework.CertificateManagement.ActionType.Add);
                Pages.CertificateManagement(fn.WebDriver).AddCertificate(fn);
                Pages.CertificateManagement(fn.WebDriver).RejectCertificate(fn);
            }

            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.CertificateManagement(fn.WebDriver).CheckRejectCertificate(fn));
                Reporter.ReportResultsToXML(fn, Pages.CertificateManagement(fn.WebDriver).CheckRejectCertificate(fn));
            }
        }

        public void SearchCertificateResult(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.CertificateManagement(fn.WebDriver).GoToCertificatesList(fn.WebBrowser);
                Pages.CertificateManagement(fn.WebDriver).SearchCertificateByIndividualID(fn, SeleniumFramework.CertificateManagement.ActionType.Edit);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.SickLeaveManagement(fn.WebDriver).CheckSearchSickLeave(fn));
                Reporter.ReportResultsToXML(fn, Pages.SickLeaveManagement(fn.WebDriver).CheckSearchSickLeave(fn));
            }
        }

        public void Edit_ApproveCertificateResult(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.CertificateManagement(fn.WebDriver).GoToCertificatesList(fn.WebBrowser);

                Pages.CertificateManagement(fn.WebDriver).EditMedicalTestResult(fn);
                Pages.CertificateManagement(fn.WebDriver).ApproveCertificate(fn);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.CertificateManagement(fn.WebDriver).CheckEditCertificate(fn));
                Reporter.ReportResultsToXML(fn, Pages.CertificateManagement(fn.WebDriver).CheckEditCertificate(fn));
            }
        }

        public void EditCertificateResult(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.CertificateManagement(fn.WebDriver).GoToCertificatesList(fn.WebBrowser);
                Pages.CertificateManagement(fn.WebDriver).EditMedicalTestResult(fn);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.CertificateManagement(fn.WebDriver).CheckEditCertificate(fn));
                Reporter.ReportResultsToXML(fn, Pages.CertificateManagement(fn.WebDriver).CheckEditCertificate(fn));
            }
        }


        public void TestAddThenApproveCertificateResult(FunctionParameters fn)
        {
            AddCertificateResult(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            SearchApproveCertificateResult(fn);
        }

        public void AddDuplicateCertificateResult(FunctionParameters fn)
        {
            try
            {
                AddCertificateResult(fn);
                Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
                AddCertificateResult(fn);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.CertificateManagement(fn.WebDriver).CheckAddDuplicateCertificate(fn));
                Reporter.ReportResultsToXML(fn, Pages.CertificateManagement(fn.WebDriver).CheckAddDuplicateCertificate(fn));
            }

        }

        public void SearchApproveCertificateResult(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.CertificateManagement(fn.WebDriver).GoToCertificatesList(fn.WebBrowser);
                Pages.CertificateManagement(fn.WebDriver).SearchApproveCertificate(fn);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.CertificateManagement(fn.WebDriver).CheckApproveCertificate(fn));
                Reporter.ReportResultsToXML(fn, Pages.CertificateManagement(fn.WebDriver).CheckApproveCertificate(fn));
            }
        }

        public void CertificateResultManagementTest(FunctionParameters fn)
        {
            AddCertificateResult(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            SearchApproveCertificateResult(fn);

        }
        #endregion


        #region Announcements
        public void AddAnnouncement(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.AnnouncementsManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.AnnouncementsManagement(fn.WebDriver).AddNewAnnouncement(fn);

            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.AnnouncementsManagement(fn.WebDriver).CheckAddAnnouncement(fn));
                Reporter.ReportResultsToExcel(fn, Pages.AnnouncementsManagement(fn.WebDriver).CheckAddAnnouncement(fn));
            }
        }

        public void EditAnnouncement(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.AnnouncementsManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.AnnouncementsManagement(fn.WebDriver).SearchAnnouncement(fn, AnnouncementsManagement.ActionType.Edit);
                Pages.AnnouncementsManagement(fn.WebDriver).EditAnnouncement(fn);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.AnnouncementsManagement(fn.WebDriver).CheckEditAnnouncement(fn));
                Reporter.ReportResultsToExcel(fn, Pages.AnnouncementsManagement(fn.WebDriver).CheckEditAnnouncement(fn));
            }
        }
        public void EnableAnnouncement(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.AnnouncementsManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.AnnouncementsManagement(fn.WebDriver).SearchAnnouncement(fn, AnnouncementsManagement.ActionType.Enable);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.AnnouncementsManagement(fn.WebDriver).CheckEnableAnnouncement(fn));
                Reporter.ReportResultsToExcel(fn, Pages.AnnouncementsManagement(fn.WebDriver).CheckEnableAnnouncement(fn));
            }
        }
        public void DisableAnnouncement(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.AnnouncementsManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.AnnouncementsManagement(fn.WebDriver).SearchAnnouncement(fn, AnnouncementsManagement.ActionType.Disable);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.AnnouncementsManagement(fn.WebDriver).CheckDisbleAnnouncement(fn));
                Reporter.ReportResultsToExcel(fn, Pages.AnnouncementsManagement(fn.WebDriver).CheckDisbleAnnouncement(fn));
            }
        }

        public void DeleteAnnouncement(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.AnnouncementsManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.AnnouncementsManagement(fn.WebDriver).SearchAnnouncement(fn, AnnouncementsManagement.ActionType.Delete);
                Pages.AnnouncementsManagement(fn.WebDriver).DeleteAnnouncement(fn);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.AnnouncementsManagement(fn.WebDriver).CheckDeleteAnnouncement(fn));
                Reporter.ReportResultsToExcel(fn, Pages.AnnouncementsManagement(fn.WebDriver).CheckDeleteAnnouncement(fn));
            }
        }
        public void ViewAnnouncementsList(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.AnnouncementsManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.AnnouncementsManagement(fn.WebDriver).SearchAnnouncement(fn, AnnouncementsManagement.ActionType.View);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                Reporter.ReportResultsToXML(fn, Pages.AnnouncementsManagement(fn.WebDriver).CheckViewAnnouncement(fn));
                Reporter.ReportResultsToExcel(fn, Pages.AnnouncementsManagement(fn.WebDriver).CheckViewAnnouncement(fn));
            }


        }


        #endregion

        #region RoleManagement

        public void AddRole(FunctionParameters fn)
        {
            try
            {

                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.RolesManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.RolesManagement(fn.WebDriver).AddNewRole(fn);

            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                fn.Function_Name = "Add Role";
                Reporter.ReportResultsToXML(fn, Pages.RolesManagement(fn.WebDriver).CheckAddRole(fn));
                Reporter.ReportResultsToExcel(fn, Pages.RolesManagement(fn.WebDriver).CheckAddRole(fn));

            }
        }

        public void EditRole(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.RolesManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.RolesManagement(fn.WebDriver).SearchRole(fn, RolesManagement.ActionType.Edit);


            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                fn.Function_Name = "Edit Role";
                Reporter.ReportResultsToXML(fn, Pages.RolesManagement(fn.WebDriver).CheckEditRole(fn));
                Reporter.ReportResultsToExcel(fn, Pages.RolesManagement(fn.WebDriver).CheckEditRole(fn));
            }
        }

        public void DeleteRole(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.RolesManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.RolesManagement(fn.WebDriver).SearchRole(fn, RolesManagement.ActionType.Delete);
                Pages.RolesManagement(fn.WebDriver).DeleteRole(fn);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                fn.Function_Name = "Delete Role";
                Reporter.ReportResultsToXML(fn, Pages.RolesManagement(fn.WebDriver).CheckDeleteRole(fn));
                Reporter.ReportResultsToExcel(fn, Pages.RolesManagement(fn.WebDriver).CheckDeleteRole(fn));
            }
        }

        public void ViewRolesList(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.RolesManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.RolesManagement(fn.WebDriver).SearchRole(fn, RolesManagement.ActionType.View);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                fn.Function_Name = "View Role List";
                Reporter.ReportResultsToXML(fn, Pages.RolesManagement(fn.WebDriver).CheckViewRole(fn));
                Reporter.ReportResultsToExcel(fn, Pages.RolesManagement(fn.WebDriver).CheckViewRole(fn));
            }
        }

        public void RoleManagementTest(FunctionParameters fn)
        {
            AddRole(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EditRole(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            ViewRolesList(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            DeleteRole(fn);
        }
        #endregion

        #region ManagerialRegions

        public void AddManagerialRegion(FunctionParameters fn)
        {
            try
            {

                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManagerialRegionsManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManagerialRegionsManagement(fn.WebDriver).AddNewManagerialRegion(fn);

            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                fn.Function_Name = "Add ManagerialRegion";
                Reporter.ReportResultsToXML(fn, Pages.ManagerialRegionsManagement(fn.WebDriver).CheckAddManagerialRegions(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ManagerialRegionsManagement(fn.WebDriver).CheckAddManagerialRegions(fn));
            }
        }

        public void EditManagerialRegion(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManagerialRegionsManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManagerialRegionsManagement(fn.WebDriver).SearchManagerialRegions(fn, ManagerialRegionsManagement.ActionType.Edit);
                Pages.ManagerialRegionsManagement(fn.WebDriver).EditManagerialRegions(fn);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                fn.Function_Name = "Edit ManagerialRegion";
                Reporter.ReportResultsToXML(fn, Pages.ManagerialRegionsManagement(fn.WebDriver).CheckEditManagerialRegions(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ManagerialRegionsManagement(fn.WebDriver).CheckEditManagerialRegions(fn));
            }
        }

        public void DeleteManagerialRegion(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManagerialRegionsManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManagerialRegionsManagement(fn.WebDriver).SearchManagerialRegions(fn, ManagerialRegionsManagement.ActionType.Delete);
                Pages.ManagerialRegionsManagement(fn.WebDriver).DeleteManagerialRegions(fn);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                fn.Function_Name = "Delete ManagerialRegion";
                Reporter.ReportResultsToXML(fn, Pages.ManagerialRegionsManagement(fn.WebDriver).CheckDeleteManagerialRegions(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ManagerialRegionsManagement(fn.WebDriver).CheckDeleteManagerialRegions(fn));
            }
        }

        public void ViewManagerialRegionsList(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.ManagerialRegionsManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.ManagerialRegionsManagement(fn.WebDriver).SearchManagerialRegions(fn, ManagerialRegionsManagement.ActionType.View);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                fn.Function_Name = "View ManagerialRegion List";
                Reporter.ReportResultsToXML(fn, Pages.ManagerialRegionsManagement(fn.WebDriver).CheckViewManagerialRegions(fn));
                Reporter.ReportResultsToExcel(fn, Pages.ManagerialRegionsManagement(fn.WebDriver).CheckViewManagerialRegions(fn));
            }
        }

        public void ManagerialRegionManagementTest(FunctionParameters fn)
        {
            AddManagerialRegion(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EditManagerialRegion(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            ViewManagerialRegionsList(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            DeleteManagerialRegion(fn);
        }


        #endregion

        #region RestrictionsAndWarnings

        public void AddRestrictionWarning(FunctionParameters fn)
        {
            try
            {

                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.RestrictionWarningManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.RestrictionWarningManagement(fn.WebDriver).AddNewRestrictionWarning(fn);

            }


            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                fn.Function_Name = "Add RestrictionWarning";
                Reporter.ReportResultsToXML(fn, Pages.RestrictionWarningManagement(fn.WebDriver).CheckAddRestrictionWarning(fn));
                Reporter.ReportResultsToExcel(fn, Pages.RestrictionWarningManagement(fn.WebDriver).CheckAddRestrictionWarning(fn));
            }
        }

        public void EditRestrictionWarning(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.RestrictionWarningManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.RestrictionWarningManagement(fn.WebDriver).SearchRestrictionWarning(fn, RestrictionWarningManagement.ActionType.Edit);
                Pages.RestrictionWarningManagement(fn.WebDriver).EditRestrictionWarning(fn);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                fn.Function_Name = "Edit RestrictionWarning";
                Reporter.ReportResultsToXML(fn, Pages.RestrictionWarningManagement(fn.WebDriver).CheckEditRestrictionWarning(fn));
                Reporter.ReportResultsToExcel(fn, Pages.RestrictionWarningManagement(fn.WebDriver).CheckEditRestrictionWarning(fn));
            }
        }

        public void DeleteRestrictionWarning(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.RestrictionWarningManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.RestrictionWarningManagement(fn.WebDriver).SearchRestrictionWarning(fn, RestrictionWarningManagement.ActionType.Delete);
                Pages.RestrictionWarningManagement(fn.WebDriver).DeleteRestrictionWarning(fn);
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                fn.Function_Name = "Delete RestrictionWarning";
                Reporter.ReportResultsToXML(fn, Pages.RestrictionWarningManagement(fn.WebDriver).CheckDeleteRestrictionWarning(fn));
                Reporter.ReportResultsToExcel(fn, Pages.RestrictionWarningManagement(fn.WebDriver).CheckDeleteRestrictionWarning(fn));
            }
        }

        public void EnableRestrictionWarning(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.RestrictionWarningManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.RestrictionWarningManagement(fn.WebDriver).SearchRestrictionWarning(fn, RestrictionWarningManagement.ActionType.Enable);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                fn.Function_Name = "Enable RestrictionWarning";
                Reporter.ReportResultsToXML(fn, Pages.RestrictionWarningManagement(fn.WebDriver).CheckEnableRestrictionWarning(fn));
                Reporter.ReportResultsToExcel(fn, Pages.RestrictionWarningManagement(fn.WebDriver).CheckEnableRestrictionWarning(fn));
            }
        }

        public void DisableRestrictionWarning(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.RestrictionWarningManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.RestrictionWarningManagement(fn.WebDriver).SearchRestrictionWarning(fn, RestrictionWarningManagement.ActionType.Disable);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                fn.Function_Name = "Disable RestrictionWarning";
                Reporter.ReportResultsToXML(fn, Pages.RestrictionWarningManagement(fn.WebDriver).CheckDisbleRestrictionWarning(fn));
                Reporter.ReportResultsToExcel(fn, Pages.RestrictionWarningManagement(fn.WebDriver).CheckDisbleRestrictionWarning(fn));
            }
        }

        public void ViewRestrictionWarningsList(FunctionParameters fn)
        {
            try
            {
                Pages.LoginUserPage1(fn.WebDriver).Login(fn);
                Pages.RestrictionWarningManagement(fn.WebDriver).GoTo(fn.WebBrowser);
                Pages.RestrictionWarningManagement(fn.WebDriver).SearchRestrictionWarning(fn, RestrictionWarningManagement.ActionType.View);

            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            finally
            {
                fn.Function_Name = "View RestrictionWarning List";
                Reporter.ReportResultsToXML(fn, Pages.RestrictionWarningManagement(fn.WebDriver).CheckViewRestrictionWarning(fn));
                Reporter.ReportResultsToExcel(fn, Pages.RestrictionWarningManagement(fn.WebDriver).CheckViewRestrictionWarning(fn));
            }
        }

        public void RestrictionWarningManagementTest(FunctionParameters fn)
        {
            AddRestrictionWarning(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EditRestrictionWarning(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            ViewRestrictionWarningsList(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            DisableRestrictionWarning(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            EnableRestrictionWarning(fn);
            Pages.LoginUserPage(fn.WebDriver).LogOut(fn);
            DeleteRestrictionWarning(fn);
        }

        #endregion




        public void ExecuteFunction(FunctionParameters fncParam)
        {
            try
            {
                ReporterX.StartIteration(fncParam.TestCaseDescription, int.Parse(fncParam.RowNo));

                SmokeTests c = new SmokeTests();
                MethodInfo method = typeof(SmokeTests).GetMethod(fncParam.Function_Name);
                Console.WriteLine(method.Name);
                method.Invoke(c, new object[] { fncParam });

                ReporterX.EndIteration();
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
        }

        public void MainSequentialMethod()
        {
            FunctionParameters mainFnParams = new FunctionParameters();
            try
            {
                string query = "";
                DataTable dt = new DataTable();
                string RQMID = "";

                // Initializing all global variables and report configurations
                GlobalVars.Environment.InitializeEnvironmentVars();

                GlobalVars.Test.InitializeTestVars(DataManager.GetExcelDataTable("select * from [Environment$]"));

                GlobalVars.Reporter.InitializeReporterVars();

                ReporterX.Initialize();


                //Get the RQM Variables             
                RQMID = (Environment.GetEnvironmentVariable("qm_RQM_TESTCASE_WEBID") == null ? "" : Environment.GetEnvironmentVariable("qm_RQM_TESTCASE_WEBID"));

                if (RQMID == "")
                    query = "select * from [Driver$] where Execution_Flag = 'YES'";
                else
                    query = "select * from [Driver$] where RQMID = '" + RQMID + "' And Execution_Flag = 'YES'";

                // Opening Custom report file && logger file creation
                if (RQMID == "")
                    ReporterX.OpenHtmlReport(GlobalVars.Test.ProjectName, false);
                else
                    ReporterX.OpenHtmlReport(GlobalVars.Test.ProjectName, true);


                dt = DataManager.GetExcelDataTable(query);


                if (dt == null)
                {
                    Console.WriteLine("Excel Sheet not found.");
                    return;
                }

                // Log Master Record Data.
                GlobalVars.Reporter.CycleTotalTestCases = dt.Rows.Count;
                mainFnParams.masterRecID = MasterRecordLog();

                foreach (DataRow r in dt.Rows)
                {

                    GlobalVars.Reporter.TestCaseStatus = true;

                    ReporterX.StartTestCase(r["TestCaseID"].ToString());

                    FunctionParameters fncParam = new FunctionParameters(r);
                    fncParam.masterRecID = mainFnParams.masterRecID;
                    if (fncParam.SuiteFlag.ToUpper() == "YES")
                    {
                        ExecuteTestSuite(fncParam);
                    }
                    else
                    {
                        ExecuteFunction(fncParam);

                        //Single login needs to be implemented 
                        // LastLoginID = GetLastLoginID(r["TestDataSheetName"].ToString(), r["TestDataSheetRowNo"].ToString());
                    }

                    ReporterX.EndTestCase();

                    fncParam.WebDriver.Quit();
                }

                ReporterX.ExecutionFinalResults();

                //Update Master Record by end time and final results
                UpdateMasterRecordLog(mainFnParams.masterRecID);


                Console.WriteLine("\n\n ========= END OF EXEC ========= Exit Code [" + Environment.ExitCode + "] =========");
                //ReporterX.GenerateReport();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n");
            }
            finally
            {

                ReleaseWebDrivers();

                //Process the resulted XML File 
                Reporter.ProcessXMLReport(mainFnParams);

                //Generate Testing result Report
                try
                {
                    ReportUnit.ReportInterface rep = new ReportUnit.ReportInterface();
                    Console.WriteLine("My Current Directory:" + Environment.CurrentDirectory);
                    rep.GenerateReport(Environment.CurrentDirectory, Environment.CurrentDirectory);
                    Reporter.ArchiveTestResults();



                    //Open the generated html report 
                    //if (File.Exists(Environment.CurrentDirectory + "\\TestResult.html"))
                    //    System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\TestResult.html");
                }
                catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
                Logger.SaveLog();

                ReporterX.GenerateReport();

                if (GlobalVars.Reporter.FinalResults.Trim().ToUpper() == "PASS")
                    Environment.Exit(0);
                else if (GlobalVars.Reporter.FinalResults.Trim().ToUpper() == "FAIL")
                    Environment.Exit(1);

            }
        }

        public Dictionary<Task, IWebDriver> tasks;

        public int DriverCounter;
        public int MaxDriverCount = 2;


        void MonitorTaskStatus()
        {
            int x = 0;
            foreach (KeyValuePair<Task, IWebDriver> entry in tasks)
            {

                if (entry.Key.IsCompleted)
                {
                    try
                    {
                        if (entry.Value.Url != "")
                        {

                            entry.Value.Quit();
                            entry.Value.Dispose();
                            DriverCounter--;
                        }
                    }
                    catch (System.InvalidOperationException ex) { }
                }
                x++;

                Console.WriteLine("Task" + x.ToString() + ":{0} ", entry.Key.Status);

            }


        }


        void ReleaseWebDrivers()
        {
            //foreach (KeyValuePair<Task, IWebDriver> entry in tasks)
            //{

            //    try
            //    {
            //        if (entry.Value.Url != "")
            //        {

            //            entry.Value.Quit();
            //            entry.Value.Dispose();
            //        }
            //    }
            //    catch (System.InvalidOperationException ex) { }

            //}

            //Clean up all the running processes of chrome driver
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                chromeDriverProcess.Kill();
            }
        }

        public void ParallelTestExecutor(FunctionParameters fn)
        {

            try
            {
                DriverCounter++;
                Console.WriteLine(fn.Function_Name);
                var t1 = new Task(() => ExecuteTestSuite(fn), TaskCreationOptions.LongRunning);
                tasks.Add(t1, fn.WebDriver);
                t1.Start();
            }
            catch (Exception ex) { Console.WriteLine("TestExecutor Failed:{0} ", ex.Message); }


        }

        public void MainParallelMethod(string NoOfBrowsers)
        {
            FunctionParameters mainFnParams = new FunctionParameters();
            try

            {

                string query = "";
                DataTable dt = new DataTable();
                string RQMID = "";
                string ids = "";
                DriverCounter = 0;
                MaxDriverCount = Int32.Parse(NoOfBrowsers);
                tasks = new Dictionary<Task, IWebDriver>();

                RQMID = Environment.ExpandEnvironmentVariables("%qm_RQM_TESTCASE_WEBID%");
                ids = Environment.ExpandEnvironmentVariables("%qm_SUITE_TESTCASES%");
                RQMID = (Environment.GetEnvironmentVariable("qm_RQM_TESTCASE_WEBID") == null ? "" : Environment.GetEnvironmentVariable("qm_RQM_TESTCASE_WEBID"));


                if (RQMID == "")
                { query = "select * from [Driver$] where SuiteFlag = 'YES'"; }
                else
                    query = "select * from [Driver$] where RQMID = " + RQMID;


                dt = DataManager.GetExcelDataTable(query);


                if (dt == null)
                {
                    Console.WriteLine("Excel Sheet not found.");
                    return;
                }

                //Suites rows
                foreach (DataRow r in dt.Rows)
                {
                    MonitorTaskStatus();

                    while (DriverCounter >= MaxDriverCount)
                    {
                        MonitorTaskStatus();
                        Thread.Sleep(TimeSpan.FromSeconds(10));
                    }



                    if (r["SuiteFlag"].ToString().ToUpper() == "YES")
                    {
                        FunctionParameters fncParam = new FunctionParameters(r);
                        ParallelTestExecutor(fncParam);
                        //ExecuteTestSuite(fncParam);
                    }
                }

                while (DriverCounter > 0)
                {
                    MonitorTaskStatus();
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n");
            }
            finally
            {

                ReleaseWebDrivers();

                //Process the resulted XML File 
                Reporter.ProcessXMLReport(mainFnParams);

                //Generate Testing result Report
                try
                {
                    ReportUnit.ReportInterface rep = new ReportUnit.ReportInterface();
                    Console.WriteLine("My Current Directory:" + Environment.CurrentDirectory);
                    rep.GenerateReport(Environment.CurrentDirectory, Environment.CurrentDirectory);
                    Reporter.ArchiveTestResults();


                    //Open the generated html report 
                    //if (File.Exists(Environment.CurrentDirectory + "\\TestResult.html"))
                    //    System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\TestResult.html");
                }
                catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
                Logger.SaveLog();

            }
        }

        public void TestRunner(FunctionParameters fn)
        {
            try
            {

                Pages.RunnerPage(fn.WebDriver).Run(fn);

            }

            catch (Exception ex) { Logger.Log(ex.Message + "\n StackTrace" + ex.StackTrace + "\n"); }
            finally
            {
                Reporter.ReportResultsToExcel(fn, Pages.ManageHospitalPage(fn.WebDriver).CheckSuccess());
                Reporter.ReportResultsToXML(fn, Pages.ManageHospitalPage(fn.WebDriver).CheckSuccess());
            }

        }


        #region Update Execution Log DB
        public static string MasterRecordLog()
        {
            try
            {
                string StartTime = DateTime.Now.ToString();

                string RQM_TESTSUITE_WEBID = (Environment.GetEnvironmentVariable("qm_RQM_TESTSUITE_WEBID") == null ? "" : Environment.GetEnvironmentVariable("qm_RQM_TESTSUITE_WEBID"));
                string RQM_TESTSUITE_NAME = (Environment.GetEnvironmentVariable("qm_RQM_TESTSUITE_NAME") == null ? "" : Environment.GetEnvironmentVariable("qm_RQM_TESTSUITE_NAME"));
                string RQM_TESTPLAN_NAME = (Environment.GetEnvironmentVariable("qm_RQM_TESTPLAN_NAME") == null ? "" : Environment.GetEnvironmentVariable("qm_RQM_TESTPLAN_NAME"));
                string RQM_TESTPLAN_WEBID = (Environment.GetEnvironmentVariable("qm_RQM_TESTPLAN_WEBID") == null ? "" : Environment.GetEnvironmentVariable("qm_RQM_TESTPLAN_WEBID"));
                //string RQM_TESTSUITE_TOTAL_TESTCASES = (Environment.GetEnvironmentVariable("qm_RQM_TESTSUITE_TOTAL_TESTCASES") == null ? "" : Environment.GetEnvironmentVariable("qm_RQM_TESTSUITE_TOTAL_TESTCASES"));
                string RQM_SUITEEXECUTIONRECORD_WEBID = (Environment.GetEnvironmentVariable("qm_RQM_SUITEEXECUTIONRECORD_WEBID") == null ? "" : Environment.GetEnvironmentVariable("qm_RQM_SUITEEXECUTIONRECORD_WEBID"));
                string RQM_SUITEEXECUTIONRECORD_NAME = (Environment.GetEnvironmentVariable("qm_RQM_SUITEEXECUTIONRECORD_NAME") == null ? "" : Environment.GetEnvironmentVariable("qm_RQM_SUITEEXECUTIONRECORD_NAME"));

                //GlobalVars.Reporter.FinalResults;

                string sMasterQuery = "INSERT INTO [dbo].[TestMasterExecutionRecord] " +
                                    "([RQM_TESTSUITE_WEBID],[RQM_TESTSUITE_NAME],[RQM_TESTSUITE_TOTAL_TESTCASES],[RQM_SUITEEXECUTIONRECORD_WEBID], " +
                                    "[RQM_SUITEEXECUTIONRECORD_NAME],[RQM_TESTPLAN_NAME],[RQM_TESTPLAN_WEBID],[StartTime],[EndTime],[RunResult],[ProjectName],[RunType]) " +
                                    "VALUES('<RQM_TESTSUITE_WEBID>','<RQM_TESTSUITE_NAME>','<RQM_TESTSUITE_TOTAL_TESTCASES>' " +
                                    ",'<RQM_SUITEEXECUTIONRECORD_WEBID>','<RQM_SUITEEXECUTIONRECORD_NAME>','<RQM_TESTPLAN_NAME>','<RQM_TESTPLAN_WEBID>','<StartTime>' " +
                                    ",'<EndTime>','<RunResult>','<ProjectName>','<RunType>') ; SELECT SCOPE_IDENTITY();";

                sMasterQuery = sMasterQuery.Replace("<RQM_TESTSUITE_WEBID>", RQM_TESTSUITE_WEBID);
                sMasterQuery = sMasterQuery.Replace("<RQM_TESTSUITE_NAME>", RQM_TESTSUITE_NAME);
                sMasterQuery = sMasterQuery.Replace("<RQM_TESTSUITE_TOTAL_TESTCASES>", GlobalVars.Reporter.CycleTotalTestCases.ToString());
                sMasterQuery = sMasterQuery.Replace("<RQM_SUITEEXECUTIONRECORD_WEBID>", RQM_SUITEEXECUTIONRECORD_WEBID);
                sMasterQuery = sMasterQuery.Replace("<RQM_SUITEEXECUTIONRECORD_NAME>", RQM_SUITEEXECUTIONRECORD_NAME);
                sMasterQuery = sMasterQuery.Replace("<RQM_TESTPLAN_NAME>", RQM_TESTPLAN_NAME);
                sMasterQuery = sMasterQuery.Replace("<RQM_TESTPLAN_WEBID>", RQM_TESTPLAN_WEBID);
                sMasterQuery = sMasterQuery.Replace("<StartTime>", StartTime);
                sMasterQuery = sMasterQuery.Replace("<EndTime>", "");
                sMasterQuery = sMasterQuery.Replace("<RunResult>", "");
                sMasterQuery = sMasterQuery.Replace("<ProjectName>", GlobalVars.Test.ProjectName);
                sMasterQuery = sMasterQuery.Replace("<RunType>", GlobalVars.Test.RunType);



                string fk_MasterExecutionRecordID = "";

                fk_MasterExecutionRecordID = DataManager.InsertExecutionRecord(sMasterQuery);

                return fk_MasterExecutionRecordID;
            }
            catch (Exception)
            { return ""; }
        }

        public static void UpdateMasterRecordLog(string MasterRecID)
        {
            try
            {
                string EndTime = DateTime.Now.ToString();


                //GlobalVars.Reporter.FinalResults;

                string sMasterQuery = "UPDATE [dbo].[TestMasterExecutionRecord] " +
                                    "SET EndTime = '" + EndTime + "' , RunResult = '" + GlobalVars.Reporter.FinalResults + "' WHERE ID = " + MasterRecID;
                DataManager.UpdateExecutionRecord(sMasterQuery);
            }
            catch (Exception)
            { return; }
        }

        public static void TestCaseLog(FunctionParameters fn, string MasterExecutionRecordID)
        {

            try
            {
                string pSQL = "";
                int duration = 0;
                duration = (int)((DateTime.Parse(GlobalVars.Reporter.EndTime) - DateTime.Parse(GlobalVars.Reporter.StartTime)).TotalSeconds);


                pSQL = "INSERT INTO[dbo].[TestCaseExecutionRecords] " +
                    "([fk_MasterExecutionRecordID],[TestCaseID],[TestCaseDescription],[ExpectedResult],[Function_Name] " +
                    ",[StartTime],[EndTime],[Duration],[Comments],[ActualResult],[RunType],[IterationsCount]) " +
                    "VALUES(<fk_MasterExecutionRecordID>,'<TestCaseID>','<TestCaseDescription>','<ExpectedResult>','<Function_Name>','<StartTime>','<EndTime>' " +
                    ",<Duration>,'<Comments>','<ActualResult>','<RunType>','<IterationsCount>')";

                pSQL = pSQL.Replace("<fk_MasterExecutionRecordID>", MasterExecutionRecordID);
                pSQL = pSQL.Replace("<TestCaseDescription>", fn.TestCaseDescription);
                pSQL = pSQL.Replace("<TestCaseID>", fn.TestCaseID);
                pSQL = pSQL.Replace("<ExpectedResult>", fn.ExpectedResult);
                pSQL = pSQL.Replace("<Function_Name>", fn.Function_Name);
                pSQL = pSQL.Replace("<StartTime>", fn.StartTime.ToString());
                pSQL = pSQL.Replace("<EndTime>", fn.EndTime.ToString());
                pSQL = pSQL.Replace("<Duration>", fn.Duration);
                pSQL = pSQL.Replace("<Comments>", "");
                pSQL = pSQL.Replace("<ActualResult>", fn.Result);
                pSQL = pSQL.Replace("<RunType>", GlobalVars.Test.RunType);
                pSQL = pSQL.Replace("<IterationsCount>", GlobalVars.Reporter.TestCaseIterations.ToString());


                DataManager.InsertExecutionRecord(pSQL);
            }
            catch (Exception)
            { }
        }
        #endregion





    }
}
