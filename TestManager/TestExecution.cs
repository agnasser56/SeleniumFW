using OpenQA.Selenium;
using RegressionSuite;
using SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ReportUnit;
using System.Diagnostics;

namespace TestManager
{
    public class TestExecution: TestBase
    {

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
                //AG TEST
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
