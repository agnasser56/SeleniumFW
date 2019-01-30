using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using OpenQA.Selenium;
using SeleniumFramework;
using System.Xml;
using System.Configuration;

namespace RegressionSuite
{
    class Reporter
    {

        public static void TestCaseLog(FunctionParameters fn, string MasterExecutionRecordID)
        {

            try
            {
                string pSQL = "";
                int duration = 0;
               
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



        internal static void ReportResultsToExcel(FunctionParameters fn,bool chkPointResult)
        {
            try
            {
                //string fileName = "";
                if (chkPointResult == false)
                {
                   // Screenshot ss = ((ITakesScreenshot)fn.WebDriver).GetScreenshot();
                    //string path = Environment.CurrentDirectory;
                    //fileName = path + "\\ScreenShots\\" + fn.Function_Name + DateTime.Now.ToString("HHmmss")+".png";
                    //ss.SaveAsFile(fileName, System.Drawing.Imaging.ImageFormat.Png);
                }                
                fn.EndTime = DateTime.Now;
                fn.Duration = Math.Round(fn.EndTime.Subtract(fn.StartTime).Duration().TotalMinutes, 3).ToString();
                fn.Result = (chkPointResult ? FunctionParameters.TestResult.Passed : FunctionParameters.TestResult.Failed).ToString();
                ReporterX.ReportEvent(fn.Function_Name, fn.Function_Name, fn.Result);
                string query = "Update [Driver$] set EndTime='" + DateTime.Now + "', StartTime='"+ fn.StartTime +"', Duration='"+fn.Duration+"',Result='"+fn.Result+ "' where TestCaseID=" + fn.TestCaseID;
                DataManager.ExcuteExcelQuery(query);

                // Insert Test Case Execution Log.
                TestCaseLog(fn, fn.masterRecID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal static void ProcessXMLReport(FunctionParameters fn)
        {
            try
            {
               
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigurationManager.AppSettings["XMLReportPath"]);

                XmlNodeList FailedTest = doc.SelectNodes("//test-case[@Result='Failed']");
                XmlNodeList PassedTest = doc.SelectNodes("//test-case[@Result='Passed']");
                XmlNodeList inconclusiveTest = doc.SelectNodes("//test-case[@Result='Inconclusive']");
                XmlNodeList skippedTest = doc.SelectNodes("//test-case[@Result='Skipped']");
                XmlNodeList totalNodes = doc.SelectNodes("//test-case");
                
                //Update test run node
                XmlNode testRunNode= doc.SelectSingleNode("//test-run");
                testRunNode.Attributes["id"].Value = DateTime.Now.ToString("yyyyMMddHHmm");
                testRunNode.Attributes["testcasecount"].Value = totalNodes.Count.ToString();
                testRunNode.Attributes["result"].Value = (PassedTest.Count==totalNodes.Count?FunctionParameters.TestResult.Passed:FunctionParameters.TestResult.Failed).ToString();
                testRunNode.Attributes["total"].Value = totalNodes.Count.ToString();
                testRunNode.Attributes["passed"].Value = PassedTest.Count.ToString();
                testRunNode.Attributes["failed"].Value = FailedTest.Count.ToString();
                testRunNode.Attributes["inconclusive"].Value = inconclusiveTest.Count.ToString();
                testRunNode.Attributes["skipped"].Value = skippedTest.Count.ToString();
                testRunNode.Attributes["asserts"].Value = "0";
                testRunNode.Attributes["start-time"].Value = fn.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
                testRunNode.Attributes["end-time"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                testRunNode.Attributes["duration"].Value = DateTime.Now.Subtract(fn.StartTime).ToString();
               
                XmlNodeList testSuitesList = doc.SelectNodes("//test-suite");
                foreach(XmlNode n in testSuitesList)
                {
                    n.Attributes["id"].Value = DateTime.Now.ToString("yyyyMMddHHmm");
                    n.Attributes["name"].Value = fn.Function_Name;
                    n.Attributes["fullname"].Value = fn.Function_Name;
                    n.Attributes["runstate"].Value = "Runnable";
                    n.Attributes["testcasecount"].Value = totalNodes.Count.ToString();
                    n.Attributes["result"].Value = (PassedTest.Count == totalNodes.Count ? FunctionParameters.TestResult.Passed : FunctionParameters.TestResult.Failed).ToString();
                    n.Attributes["duration"].Value = DateTime.Now.Subtract(fn.StartTime).ToString();
                    n.Attributes["total"].Value = totalNodes.Count.ToString();
                    n.Attributes["passed"].Value = PassedTest.Count.ToString();
                    n.Attributes["failed"].Value = FailedTest.Count.ToString();
                    n.Attributes["inconclusive"].Value = inconclusiveTest.Count.ToString();
                    n.Attributes["skipped"].Value = skippedTest.Count.ToString();
                    n.Attributes["asserts"].Value = "0";

                    if (n.Attributes["site"]!=null)
                        n.Attributes["site"].Value = "Child";
                }
                doc.Save(ConfigurationManager.AppSettings["XMLReportPath"]);
  
            }
            catch (Exception ex)
            {

            }
        }
        internal static void ReportResultsToXML(FunctionParameters fn, bool chkPointResult)
        {
            try
            {
                fn.EndTime = DateTime.Now;
                fn.Duration = fn.EndTime.Subtract(fn.StartTime).ToString();
                fn.Result = (chkPointResult ? FunctionParameters.TestResult.Passed : FunctionParameters.TestResult.Failed).ToString();
              //  ReporterX.ReportEvent(fn.Function_Name, fn.Function_Name, fn.Result);

                string xmlToLoad = "";
                if (File.Exists(ConfigurationManager.AppSettings["XMLReportPath"]))
                    xmlToLoad = ConfigurationManager.AppSettings["XMLReportPath"];
                else
                    xmlToLoad = ConfigurationManager.AppSettings["ReportTemplatePath"];

                XmlDocument doc = new XmlDocument();
                
                doc.Load(xmlToLoad);

                XmlNode el = doc.SelectSingleNode("//test-suite[@type='TestFixture']");

                XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "test-case", "");

                XmlAttribute attID = doc.CreateAttribute("id");
                attID.Value = fn.TestCaseID;
                XmlAttribute attName = doc.CreateAttribute("name");
                attName.Value = fn.Function_Name;
                XmlAttribute attFullname = doc.CreateAttribute("fullname");
                attFullname.Value  = fn.Function_Name; 
                XmlAttribute attRunstate = doc.CreateAttribute("runstate");
                attRunstate.Value = "Runnable";
                XmlAttribute attResult = doc.CreateAttribute("result");
                attResult.Value = fn.Result;
                XmlAttribute attLabel = doc.CreateAttribute("label");
                attLabel.Value = "Valid";
                XmlAttribute attDuration = doc.CreateAttribute("duration");
                attDuration.Value = fn.Duration;
                XmlAttribute attAssert = doc.CreateAttribute("assert");
                attAssert.Value = "0";

                newNode.Attributes.Append(attID);
                newNode.Attributes.Append(attName);
                newNode.Attributes.Append(attFullname);
                newNode.Attributes.Append(attRunstate);
                newNode.Attributes.Append(attResult);
                newNode.Attributes.Append(attLabel);
                newNode.Attributes.Append(attDuration);
                newNode.Attributes.Append(attAssert);

                if(!chkPointResult)
                {
                    string fileName = "";
                    if (chkPointResult == false)
                    {
                        Screenshot ss = ((ITakesScreenshot)fn.WebDriver).GetScreenshot();
                        fileName += "ScreenShots\\" + fn.Function_Name + DateTime.Now.ToString("HHmmss") + ".png";
                        ss.SaveAsFile(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        
                    }

                    XmlNode failureNode = doc.CreateNode(XmlNodeType.Element, "failure", "");
                    XmlNode failureMessage = doc.CreateNode(XmlNodeType.Element, "message", "");
                    XmlNode failureScreenShot = doc.CreateNode(XmlNodeType.Element, "ScreenShot", "");
                    failureMessage.InnerText = fn.Message;
                    failureScreenShot.InnerText = fileName;
                    failureNode.AppendChild(failureMessage);
                    failureNode.AppendChild(failureScreenShot);
                    newNode.AppendChild(failureNode);
                }
                el.AppendChild(newNode);

                doc.Save(ConfigurationManager.AppSettings["XMLReportPath"]);

               
            }
            catch (Exception ex)
            {

            }
        }        
        internal static void ArchiveTestResults()
        {
            try
            {
                File.Move(ConfigurationManager.AppSettings["XMLReportPath"] , ConfigurationManager.AppSettings["TestArchiveFolderPath"] + "\\TestResult"+DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")+".xml");
                File.Copy(ConfigurationManager.AppSettings["HTMLReportPath"] , ConfigurationManager.AppSettings["TestArchiveFolderPath"]+"\\TestResult" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".html");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
