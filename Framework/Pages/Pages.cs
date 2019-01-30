using SeleniumFramework;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
namespace SeleniumFramework
{
    public static class Pages
    {
         
        //private static T GetPage<T>() where T : new()
        //{
        //    var page = new T();
        //    PageFactory.InitElements(Browser.d,page);
        //    return page;
        //}
        private static T GetPage<T>(IWebDriver wd) where T : new()
        {
            var page = new T();
            PageFactory.InitElements(wd, page);
            return page;
        }


        public static RestrictionWarningManagement RestrictionWarningManagement(IWebDriver wd)
        {
            return GetPage<RestrictionWarningManagement>(wd);
        }

        public static ManagerialRegionsManagement ManagerialRegionsManagement(IWebDriver wd)
        {
            return GetPage<ManagerialRegionsManagement>(wd);
        }
        public static RolesManagement RolesManagement(IWebDriver wd)
        {
            return GetPage<RolesManagement>(wd);
        }
        public static AnnouncementsManagement AnnouncementsManagement(IWebDriver wd)
        {
            return GetPage<AnnouncementsManagement>(wd);
        }
        public static CertificateManagement CertificateManagement(IWebDriver wd)
        {
            return GetPage<CertificateManagement>(wd);
        }
        public static SickLeaveManagement SickLeaveManagement(IWebDriver wd)
        {
            return GetPage<SickLeaveManagement>(wd);
        }

               

        public static ClientManagement ClientManagement(IWebDriver wd)
        {
            return GetPage<ClientManagement>(wd);
        }

        public static UsersManagement UsersManagement(IWebDriver wd)
        {
            return GetPage<UsersManagement>(wd);
        }

        public static clsLogin LoginUserPage(IWebDriver wd)
        {
            return GetPage<clsLogin>(wd);
        }
        public static clsLogin2 LoginUserPage1(IWebDriver wd)
        {
                return GetPage<clsLogin2>(wd); 
        }

        

            public static ManageMohDoctors MohDoctorsPage(IWebDriver wd)
        {
            return GetPage<ManageMohDoctors>(wd);
        }


        public static ManageHospitalDoctors HospitalDoctorsPage(IWebDriver wd)
        {
            return GetPage<ManageHospitalDoctors>(wd);
        }


        

        public static ManageClientCertificateRequest ClientCertificateRequestPage(IWebDriver wd)
        {
            return GetPage<ManageClientCertificateRequest>(wd);
        }

        public static ManageClientRequest ClientRequestPage(IWebDriver wd)
        {
            return GetPage<ManageClientRequest>(wd);
        }

        public static ManageClientRequest4Individual ClientRequest4IndividualPage(IWebDriver wd)
        {
            return GetPage<ManageClientRequest4Individual>(wd);
        }

        

        public static QCAccountManagement ManageQCAccount(IWebDriver wd)
        {


            return GetPage<QCAccountManagement>(wd);
        }

        public static ManageHospital ManageHospitalPage(IWebDriver wd)
        {


            return GetPage<ManageHospital>(wd);
        }

        public static GeneralFunctionRunner RunnerPage(IWebDriver wd)
        {


            return GetPage<GeneralFunctionRunner>(wd);
        }

        public static ManageBranch ManageBranchPage(IWebDriver wd)
        {


            return GetPage<ManageBranch>(wd);
        }

        public static ManageHospitalUsers ManageHospitalUsersPage(IWebDriver wd)
        {


            return GetPage<ManageHospitalUsers>(wd);
        }


        public static ManageBranchUsers ManageBranchUsersPage(IWebDriver wd)
        {


            return GetPage<ManageBranchUsers>(wd);
        }

        public static ManageMedicalTest ManageMedicalTestPage(IWebDriver wd)
        {


            return GetPage<ManageMedicalTest>(wd);
        }

        public static ManageControlPanel ManageControlPanelPage(IWebDriver wd)
        {


            return GetPage<ManageControlPanel>(wd);
        }

        public static ManageCertificates ManageCertificatePage(IWebDriver wd)
        {


            return GetPage<ManageCertificates>(wd);
        }
        public static ManageCertificateResultRetestPermission CertificateResultRetestPermissionPage(IWebDriver wd)
        {


            return GetPage<ManageCertificateResultRetestPermission>(wd);
        }

        public static MyProfile ViewMyProfilePage(IWebDriver wd)
        {


            return GetPage<MyProfile>(wd);
        }

        public static PublicInquires PublicInquiryPage(IWebDriver wd)
        {


            return GetPage<PublicInquires>(wd);
        }

        public static MyAccount MyAccountPage(IWebDriver wd)
        {


            return GetPage<MyAccount>(wd);
        }

        public static ManageFunction ManageFunctionPage(IWebDriver wd)
        {


            return GetPage<ManageFunction>(wd);
        }




   

        public static TopNavigationPage TopNavigationPage(IWebDriver wd)
        {
             return GetPage<TopNavigationPage>(wd);
        }
        public static HospitalSearch HospitalSearchPage(IWebDriver wd)
        {
            return GetPage<HospitalSearch>(wd);
        }






    }
}
