

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
namespace SeleniumFramework
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            //start the hub
            //initialize the browsers
            //Browser.Initialize();
            //UserGenerator.Initialize();
        }

        [TestCleanup]
        public void TestFixtureTearDown()
        {
            //Browser.Close();
           
        }
        
       // [TearDown]
        public static void TearDown()
        {
            //if(Pages.TopNavigation.IsLoggedIn())
            //    Pages.TopNavigation.LogOut();

            //if(UserGenerator.LastGeneratedUser != null)
            //    Browser.Goto("Account/DeleteUsers.cshtml");
        }
    }
}
