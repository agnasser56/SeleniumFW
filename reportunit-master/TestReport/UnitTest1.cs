using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestReport
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ReportUnit.ReportInterface rep = new ReportUnit.ReportInterface();
            rep.GenerateReport(@"D:\Automation\Selenium\Framework\BATDemo-master\BATDemoTests\bin\Debug", @"D:\Automation\Selenium\Framework\BATDemo-master\BATDemoTests\bin\Debug");
        }
    }
}
