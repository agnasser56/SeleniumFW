using System;
using System.IO;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;



namespace SeleniumFramework
{
   public static class ReporterX
    {

        public static void Initialize()
        {
            //ReportConfiguration conf = new ReportConfiguration();
            //conf.ReportLevel = ReportLevel.All;
            //conf.SnapshotsLevel = CaptureLevel.OnError;
            //conf.ReportFolder = "RunResult_LeanFT";
            //conf.TargetDirectory = GlobalVars.Reporter.ReportFolder;
            //Reporter.Init(conf);
            GlobalVars.Reporter.ReportLevel = "All"; //All , Error , Warning
            GlobalVars.Reporter.SnapshotCaptureLevel = "OnError"; // "OnError","All"
        }

        /// <summary>
        /// Log Result of the step based on returned success or error messages.
        /// </summary>
        /// <param name="IsPositiveScenario"></param>
        /// <param name="sTitle"></param>
        /// <param name="sfieldsError"></param>
        /// <param name="msgSuccess"></param>
        /// <param name="msgError"></param>
        /// <param name="iTimeOut"></param>
        /// <returns></returns>
        public static bool LogResult(string IsPositiveScenario, string sTitle, string sfieldsError, IWebElement msgSuccess , IWebElement msgError, int iTimeOut)
        {
            string msgSuc = "";
            string msgErr = "";
            bool retStatus = true;

            //////
            System.Threading.Thread.Sleep(1000);

            try
            {
                
                if (IsPositiveScenario.ToUpper() == "TRUE")
                {
                    if (sfieldsError.Trim().Length > 0)
                    {
                        retStatus = false;
                        ReporterX.ReportEvent(sTitle, sTitle + " Has Field Validation Errors : " + sfieldsError, "Failed");
                    }
                    else
                    {
                        

                        if (msgSuccess.Exists(iTimeOut))
                        {

                            msgSuc = msgSuccess.Text.ToString();
                            ReporterX.ReportEvent(sTitle, sTitle + " Has Passed , System Returned Message : " + msgSuc, "Passed");

                        }
                        else
                        {
                            

                            if (msgError.Exists(iTimeOut))
                            {
                                msgErr = msgError.Text.ToString();
                                ReporterX.ReportEvent(sTitle, sTitle + " Has Failed , System Returned Message : " + msgErr, "Failed");
                                retStatus = false;


                            }
                            else
                            {
                                ReporterX.ReportEvent(sTitle, sTitle + " Has Failed , System No Response.", "Failed");
                                retStatus = false;
                            }

                        }
                    }                    
                    
                }
                else if (IsPositiveScenario.ToUpper() == "FALSE")
                {
                    if (sfieldsError.Trim().Length > 0)
                    {
                        retStatus = true;
                        ReporterX.ReportEvent(sTitle, sTitle + " Has Field Validation Errors : " + sfieldsError, "Passed");
                    }
                    else
                    {
                        

                        if (msgSuccess.Exists(iTimeOut))
                        {

                            msgSuc = msgSuccess.Text.ToString();
                            ReporterX.ReportEvent(sTitle, sTitle + " Has Passed , System Returned Message : " + msgSuc, "Failed");

                        }
                        else
                        {
                            

                            if (msgError.Exists(iTimeOut))
                            {
                                msgErr = msgError.Text.ToString();
                                ReporterX.ReportEvent(sTitle, sTitle + " Has Failed , System Returned Message : " + msgErr, "Passed");
                                retStatus = true;


                            }
                            else
                            {
                                ReporterX.ReportEvent(sTitle, sTitle + " Has Failed , System No Response.", "Passed");
                                retStatus = true;
                            }

                        }
                    }

                }
                return retStatus;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                ReporterX.ReportEvent("Log Step Result.", "Log Step Result Has Failed , System Returned Message : " + ex.Message, "Failed");
                return false;

            }
            
        }
       
        /*'#####***********************************************************************************************************************************************************************************'
        '###  Function Name: 			'ReportEvent
        '*
        '###  Function Description: 	Log Result to Custom Report and LeanFt Reporter
        '*
        '###  Created Date: 			25/Oct/2016
        '*
        '###  Created By:     			Abdelghany Elsayed / aelsayed@elm
        '************************************************************************************************************************************************************************************/
        public static void ReportEvent(string sStepName, string sDetails, string sStatus)
        {
            try
            {
                if (GlobalVars.Reporter.ReportLevel.ToUpper() == "ALL")
                {
                    ////Reporter.ReportEvent(sStepName, sDetails, sStatus);
                    Console.WriteLine("\t\t["+ sStatus + "]  "+sDetails);
                    InsertResult(sStepName, sStepName, sDetails, sStatus.ToString());
                    if (sStatus.ToString().ToUpper() == "FAILED")
                        GlobalVars.Reporter.TestCaseStatus = false;

                }
                else if (GlobalVars.Reporter.ReportLevel.ToUpper() == "ERROR")
                {
                    if (sStatus.ToString().ToUpper() == "FAILED")
                    {
                        ////Reporter.ReportEvent(sStepName, sDetails, sStatus);
                        Console.WriteLine("\t\t[" + sStatus + "]  " + sDetails);
                        InsertResult(sStepName, sStepName, sDetails, sStatus.ToString());
                        GlobalVars.Reporter.TestCaseStatus = false;
                    }
                }
                else if (GlobalVars.Reporter.ReportLevel.ToUpper() == "WARNING")
                {
                    if (sStatus.ToString().ToUpper() == "WARNING")
                    {
                        ////Reporter.ReportEvent(sStepName, sDetails, sStatus);
                        Console.WriteLine("\t\t[" + sStatus + "]  " + sDetails);
                        InsertResult(sStepName, sStepName, sDetails, sStatus.ToString());
                    }
                }
            }
            catch (Exception e)
            {
               // //Reporter.ReportEvent("Report Evenet.", "Report Evenet.", "Failed", e);                
                Logger.LogError("Report Evenet || "+e.Message);
                Console.WriteLine("\t\t[Failed]  " + e.Message);
            }
                    
        }

        /*'#####***********************************************************************************************************************************************************************************'
	    '###  Function Name: 			fnOpenHtmlFile
	    '*
	    '###  Function Description: 	will open Custom report at the path /Reports
	    '*
	    '###  Created Date: 			16/11/2015
	    '*
	    '###  Created By:     			Abdelghany Elsayed / aelsayed@elm
	    '************************************************************************************************************************************************************************************/
        public static void OpenHtmlReport(string sProjectName,bool RQM_Mode)
        {
            try
            {
                if (GlobalVars.Test.CustomReportEnable)
                {
                    // reset counters .

                    GlobalVars.Reporter.PassCount = 0;
                    GlobalVars.Reporter.FailCount = 0;
                    GlobalVars.Reporter.ScreenCaptureCount = 0;
                    GlobalVars.Reporter.TotalPassCount = 0;
                    GlobalVars.Reporter.TotalFailCount = 0;
                    GlobalVars.Reporter.TotalTestCaseCount = 0;

                    if (!RQM_Mode)
                    {
                        // checking the Reports Main Folder
                        if (!System.IO.Directory.Exists(GlobalVars.Reporter.ReportFolder))
                            System.IO.Directory.CreateDirectory(GlobalVars.Reporter.ReportFolder);

                        // checking the Automation_Result_ folder
                        if (!System.IO.Directory.Exists(GlobalVars.Reporter.RunResultFolder))
                            System.IO.Directory.CreateDirectory(GlobalVars.Reporter.RunResultFolder);

                        // checking the screen shots folder
                        if (!System.IO.Directory.Exists(GlobalVars.Reporter.ScreenShootFolder))
                            System.IO.Directory.CreateDirectory(GlobalVars.Reporter.ScreenShootFolder);

                        var objFile = System.IO.File.CreateText(GlobalVars.Reporter.ReportFileName);

                        objFile.WriteLine("<HTML><BODY><TABLE BORDER=0 CELLPADDING=3 CELLSPACING=1 WIDTH=100%>");
                        objFile.WriteLine("<TR COLS=2><TD BGCOLOR=WHITE ><IMG SRC=http://www.elm.sa/_LAYOUTS/AlElmPortal/Images/elm_logo.png> </TD> <TD WIDTH=100% BGCOLOR=WHITE><Center><FONT FACE=\"Microsoft YaHei UI\" COLOR=#088A08 SIZE=4><B>&nbsp;" + sProjectName + "  Automation Execution Report <br/>" + DateTime.Now.ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("HH:mm:ss") + " <br/> Tested on Machine " + Environment.MachineName + "</B></FONT></Center></TD></TR></TABLE>");
                        objFile.WriteLine("</BODY></HTML><BR>");
                        objFile.Close();
                    }
                    else
                    {

                        GlobalVars.Reporter.ScreenShootFolder = GlobalVars.Reporter.RQM_RunResult + "\\ScreenShots_" + GlobalVars.Test.ProjectName;

                        GlobalVars.Reporter.ReportFileName = GlobalVars.Reporter.RQM_RunResult + "\\" + "Automation_Report.html";

                        // checking the Reports Main Folder
                        if (!System.IO.Directory.Exists(GlobalVars.Reporter.ReportFolder))
                            System.IO.Directory.CreateDirectory(GlobalVars.Reporter.ReportFolder);

                        // checking the Automation_Result_ folder
                        if (System.IO.Directory.Exists(GlobalVars.Reporter.RQM_RunResult))
                        {
                            System.IO.Directory.Delete(GlobalVars.Reporter.RQM_RunResult, true);
                            System.Threading.Thread.Sleep(1000);
                            System.IO.Directory.CreateDirectory(GlobalVars.Reporter.RQM_RunResult);
                        }

                        // checking the screen shots folder
                        if (!System.IO.Directory.Exists(GlobalVars.Reporter.ScreenShootFolder))
                            System.IO.Directory.CreateDirectory(GlobalVars.Reporter.ScreenShootFolder);

                        var objFile = System.IO.File.CreateText(GlobalVars.Reporter.ReportFileName);

                        objFile.WriteLine("<HTML><BODY><TABLE BORDER=0 CELLPADDING=3 CELLSPACING=1 WIDTH=100%>");
                        objFile.WriteLine("<TR COLS=2><TD BGCOLOR=WHITE ><IMG SRC=http://www.elm.sa/_LAYOUTS/AlElmPortal/Images/elm_logo.png> </TD> <TD WIDTH=100% BGCOLOR=WHITE><Center><FONT FACE=\"Microsoft YaHei UI\" COLOR=#088A08 SIZE=4><B>&nbsp;" + sProjectName + "  Automation Execution Report <br/>" + DateTime.Now.ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("HH:mm:ss") + " <br/> Tested on Machine " + Environment.MachineName + "</B></FONT></Center></TD></TR></TABLE>");
                        objFile.WriteLine("</BODY></HTML><BR>");
                        objFile.Close();
                    }
                }
            }
            catch (Exception e)
            {
                ////Reporter.ReportEvent("Open Custom HTML Report.", "Open Custom HTML Report.", "Failed", e);
                Logger.LogError("Open Custom HTML Report || " + e.Message);
                Console.WriteLine("\t\t[Failed]  Open Custom HTML Report : " + e.Message);
            }
            
        }

        /*'#####***********************************************************************************************************************************************************************************'
        '###  Function Name: 			'InsertResult
        '*
        '###  Function Description: 	Log Result to reporter and  Custom Report
        '*
        '###  Created Date: 			20/Oct/2016
        '*
        '###  Created By:     			Abdelghany Elsayed / aelsayed@elm
        '************************************************************************************************************************************************************************************/
        private static void InsertResult(string sDesc, string sExpected, string sActual, string sResult)

        {
            try
            {
                if (GlobalVars.Test.CustomReportEnable)
                {

                    var objFile = System.IO.File.AppendText(GlobalVars.Reporter.ReportFileName);

                    if (sResult.Trim().ToUpper() == "FAILED")
                    {

                        GlobalVars.Reporter.FailCount = GlobalVars.Reporter.FailCount + 1;

                        //GlobalVars.Reporter.TestCaseStatus = false;

                        if (GlobalVars.Reporter.SnapshotCaptureLevel.ToUpper() == "ONERROR" || GlobalVars.Reporter.SnapshotCaptureLevel.ToUpper() == "ALL")
                        {

                            string screenFile = SaveScreenShot();

                            GlobalVars.Reporter.ScreenCaptureCount = GlobalVars.Reporter.ScreenCaptureCount + 1;

                            objFile.WriteLine("<TR COLS=5><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS)\"  SIZE=2>&nbsp;" + sDesc + "</FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS)\"  SIZE=2>&nbsp;" + sExpected + "</FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"WINGDINGS\"  SIZE=4>2</FONT><FONT FACE=\"Times New Roman (Headings CS)\" SIZE=2><A HREF='" + screenFile + "'>&nbsp;" + sActual + "</A></FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS)\" SIZE=3 COLOR=RED><Center>" + sResult + "</Center></FONT></TD></TR>");

                        }
                        else
                        {

                            objFile.WriteLine("<TR COLS=5><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS)\"  SIZE=2>&nbsp;" + sDesc + "</FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS)\"  SIZE=2>&nbsp;" + sExpected + "</FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS)\" SIZE=2>&nbsp;" + sActual + "</FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS)\" SIZE=3 COLOR=RED>O</FONT><FONT FACE=\"Times New Roman (Headings CS)\" SIZE=3 COLOR=RED><Center>" + sResult + "</Center></FONT></TD></TR>");
                        }


                    }
                    else if (sResult.Trim().ToUpper() == "PASSED")
                    {
                        GlobalVars.Reporter.PassCount = GlobalVars.Reporter.PassCount + 1;

                        if (GlobalVars.Reporter.SnapshotCaptureLevel.ToUpper() == "ALL")
                        {

                            string screenFile = SaveScreenShot();

                            GlobalVars.Reporter.ScreenCaptureCount = GlobalVars.Reporter.ScreenCaptureCount + 1;

                            objFile.WriteLine("<TR COLS=5><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS)\" SIZE=2>&nbsp;" + sDesc + "</FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS)\"  SIZE=2>&nbsp;" + sExpected + "</FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"WINGDINGS\"  SIZE=4>2</FONT><FONT FACE=\"Times New Roman (Headings CS)\"  SIZE=2><A HREF='" + screenFile + "'>" + sActual + "</A></FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS) \" SIZE=5 COLOR=GREEN>P</FONT><FONT FACE=\"Times New Roman (Headings CS)\"  SIZE=2 COLOR=Lime><Center>" + sResult + "</Center></FONT></TD></TR>");

                        }
                        else
                        {

                            objFile.WriteLine("<TR COLS=5><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS)\"  SIZE=2>&nbsp;" + sDesc + "</FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Tahoma\" SIZE=2>&nbsp;" + sExpected + "</FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Tahoma\"  SIZE=2>&nbsp;" + sActual + "</FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Tahoma\"  SIZE=3 COLOR=GREEN><Center>" + sResult + "</Center></FONT></TD></TR>");
                        }
                    }
                    else if (sResult.Trim().ToUpper() == "WARNING")
                    {
                        objFile.WriteLine("<TR COLS=5><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS)\"  SIZE=2>" + sDesc + "</FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS)\" SIZE=2>" + sExpected + "</FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS)\" SIZE=2>" + sActual + "</FONT></TD><TD BGCOLOR=#EEEEEE WIDTH=25%><FONT FACE=\"Times New Roman (Headings CS) \" SIZE=3 COLOR=#FF8C00></FONT><FONT FACE=\"Times New Roman (Headings CS)\"  SIZE=3 COLOR=#FF8C00><Center>" + sResult + "</Center></FONT></TD></TR>");
                    }

                    objFile.Close();
                }
            }
            catch (Exception e)
            {
                //Reporter.ReportEvent("Insert Result.", "Insert Result.", "Failed", e);
                Logger.LogError("Insert Result || " + e.Message);
                Console.WriteLine("\t\t[Failed]  Insert Result : " + e.Message);
            }
            
        }

        /*'#####***********************************************************************************************************************************************************************************'
	    '###  Function Name: 			StartTestCase
	    '*
	    '###  Function Description: 	Start Reporter Test and Add heading to custom report test case.
	    '*
	    '###  Created Date: 			25/Oct/2016
	    '*
	    '###  Created By:     			Abdelghany Elsayed / aelsayed@elm
	    '************************************************************************************************************************************************************************************/
        public static void StartTestCase(string sTestCaseName)
        {
            try
            {
                
                Console.WriteLine("\n\n_________ Start Test Case [ "+ sTestCaseName + " ] _________");

                //Reporter.StartTest(sTestCaseName);

                //GlobalVars.Reporter.StartTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                GlobalVars.Reporter.StartTime = DateTime.Now.ToString();

                GlobalVars.Reporter.TotalTestCaseCount = GlobalVars.Reporter.TotalTestCaseCount + 1;
                if (GlobalVars.Test.CustomReportEnable)
                {
                    var objFile = System.IO.File.AppendText(GlobalVars.Reporter.ReportFileName);
                    objFile.WriteLine("<HTML><BODY><TABLE BORDER=1 CELLPADDING=3 CELLSPACING=1 WIDTH=100%>");
                    objFile.WriteLine("<TR><TD BGCOLOR=#6D7B8D WIDTH=25%><FONT FACE=\"Segoe UI Semilight\" COLOR=WHITE SIZE=3><B>&nbsp;&nbsp;Test Case ID:</B></FONT></TD><TD BGCOLOR=#6D7B8D COLSPAN=5><FONT FACE=\"Segoe UI Semilight\" COLOR=WHITE SIZE=3><B><Center>" + sTestCaseName + "</Center></B></FONT></TD></TR>");
                    GlobalVars.Reporter.PassCount = 0;
                    GlobalVars.Reporter.FailCount = 0;
                    objFile.Close();
                }

            }
            catch (Exception e)
            {
                //Reporter.ReportEvent("starting New Test", "start New Test / Test Case", "Failed", e);
                Logger.LogError("Starting New Test || " + e.Message);
                Console.WriteLine("\t\t[Failed]  Starting New Test : " + e.Message);
            }
            
        }

        /*'#####***********************************************************************************************************************************************************************************'
        '###  Function Name: 			EndTestCase
        '*
        '###  Function Description: 	Ending a reporter Test and Close the Custom report Test case with details.
        '*
        '###  Created Date: 			25/Oct/2016
        '*
        '###  Created By:     			Abdelghany Elsayed / aelsayed@elm
        '************************************************************************************************************************************************************************************/
        public static void EndTestCase()
        {
            try
            {
                //Reporter.EndTest();

                Console.WriteLine("\n_________ End Test Case _________");

                if (GlobalVars.Test.CustomReportEnable)
                {
                    //GlobalVars.Reporter.EndTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                    GlobalVars.Reporter.EndTime = DateTime.Now.ToString();

                    var objFile = System.IO.File.AppendText(GlobalVars.Reporter.ReportFileName);

                    objFile.WriteLine("<TR COLS=5><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Microsoft YaHei UI\" COLOR=WHITE SIZE=2><B>&nbsp;&nbsp;Start Time: </B></FONT></TD><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Microsoft YaHei UI\" COLOR=WHITE SIZE=2><B><Center>" + GlobalVars.Reporter.StartTime + "</Center></B></FONT></TD><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Microsoft YaHei UI\" COLOR=WHITE SIZE=2><B>&nbsp;&nbsp;End Time: </B></FONT></TD><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Microsoft YaHei UI\" COLOR=WHITE SIZE=2><B><Center>" + GlobalVars.Reporter.EndTime + "</Center></B></FONT></TD></TR>");

                    if (GlobalVars.Reporter.FailCount > 0)
                    {
                        GlobalVars.Reporter.FinalResults = "FAIL";
                        GlobalVars.Reporter.TotalFailCount = GlobalVars.Reporter.TotalFailCount + 1;
                        objFile.WriteLine("<TR COLS=5><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Microsoft YaHei UI\" COLOR=WHITE SIZE=2><B><Center>End of Test Case</Center></B></FONT></TD><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Microsoft YaHei UI\" COLOR=WHITE SIZE=2><B><Center>Test Steps Passed : &nbsp;" + GlobalVars.Reporter.PassCount + "</Center></B></FONT></TD><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Microsoft YaHei UI\" COLOR=WHITE SIZE=2><B><Center>Test Steps Failed : &nbsp;" + GlobalVars.Reporter.FailCount + "</Center></B></FONT></TD><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Microsoft YaHei UI\" COLOR=WHITE SIZE=2><B><Center>Final Test Result : </B></FONT><FONT COLOR=RED><B>&nbsp;" + GlobalVars.Reporter.FinalResults + "</Center></B></FONT></TD></TR>");
                    }
                    else
                    {
                        GlobalVars.Reporter.FinalResults = "PASS";
                        GlobalVars.Reporter.TotalPassCount = GlobalVars.Reporter.TotalPassCount + 1;
                        objFile.WriteLine("<TR COLS=5><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Microsoft YaHei UI\" COLOR=WHITE SIZE=2><B><Center>End of Test Case</Center></B></FONT></TD><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Microsoft YaHei UI\" COLOR=WHITE SIZE=2><B><Center>Test Steps Passed : &nbsp;" + GlobalVars.Reporter.PassCount + "</Center></B></FONT></TD><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Microsoft YaHei UI\" COLOR=WHITE SIZE=2><B><Center>Test Steps Failed :&nbsp;" + GlobalVars.Reporter.FailCount + "</Center></B></FONT></TD><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Microsoft YaHei UI\" COLOR=WHITE SIZE=2><B><Center>Final Test Result : </B></FONT><FONT COLOR=#7FE817><B>&nbsp;" + GlobalVars.Reporter.FinalResults + "</Center></B></FONT></TD></TR>");
                    }

                    objFile.WriteLine("</TABLE></BODY></HTML>");

                    GlobalVars.Reporter.FailCount = 0;
                    GlobalVars.Reporter.PassCount = 0;

                    objFile.Close();
                }

            }
            catch (Exception e)
            {
                //Reporter.ReportEvent("Ending Test / Test Case", "Ending Test / Test Case", "Failed", e);
                Logger.LogError("Ending Test  || " + e.Message);
                Console.WriteLine("\t\t[Failed]  Ending Test : " + e.Message);
            }
            
        }

        /*'#####***********************************************************************************************************************************************************************************'
	    '###  Function Name: 			StartIteration
	    '*
	    '###  Function Description: 	Start reporter contexct and custom report html iteration
	    '*
	    '###  Created Date: 			25/Oct/2016
	    '*
	    '###  Created By:     			Abdelghany Elsayed / aelsayed@elm
	    '************************************************************************************************************************************************************************************/
        public static void StartIteration(string sTestCaseName,int iIterationid)
        {
            try
            {
                //Reporter.StartReportingContext("Iteration : "+ iIterationid);
                
                Console.WriteLine("\n\t............ Start Iteration With ROW [ " + iIterationid + " ]............");

                if (GlobalVars.Test.CustomReportEnable)
                {
                    var objFile = System.IO.File.AppendText(GlobalVars.Reporter.ReportFileName);
                    objFile.WriteLine("<TR COLS=6><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Segoe UI Semilight\" COLOR=WHITE SIZE=3><B>&nbsp;&nbsp;Test Case Description:</B></FONT></TD><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Segoe UI Semilight\" COLOR=WHITE SIZE=3><B><Center>" + sTestCaseName + "</Center></B></FONT></TD><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Segoe UI Semilight\" COLOR=WHITE SIZE=3><B>&nbsp;&nbsp;Iteration Id: </B></FONT></TD><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Segoe UI Semilight\" COLOR=WHITE SIZE=3><B><Center>" + iIterationid + "</Center></B></FONT></TD></TR>");
                    objFile.WriteLine("<TR COLS=6><TD BGCOLOR=84596B WIDTH=25%><FONT FACE=\"Segoe UI Semilight\" COLOR=WHITE SIZE=3><B><Center>Step Description</Center></B></FONT></TD><TD BGCOLOR=84596B WIDTH=30%><FONT FACE=\"Segoe UI Semilight\" COLOR=WHITE SIZE=3><B><Center>Expected Value</Center></B></FONT></TD><TD BGCOLOR=84596B WIDTH=30%><FONT FACE=\"Segoe UI Semilight\" COLOR=WHITE SIZE=3><B><Center>Actual Value</Center></B></FONT></TD><TD BGCOLOR=84596B WIDTH=15%><FONT FACE=\"Segoe UI Semilight\" COLOR=WHITE SIZE=3><B><Center>Result</Center></B></FONT></TD></TR>");
                    objFile.Close();
                }

            }
            catch (Exception e)
            {
                //Reporter.ReportEvent("starting New Iteration", "start New Iteration / Context", "Failed", e);
                Logger.LogError("starting New Iteration  || " + e.Message);
                Console.WriteLine("\t\t[Failed]  starting New Iteration : " + e.Message);
            }
            
        }

        /*'#####***********************************************************************************************************************************************************************************'
        '###  Function Name: 			EndIteration
        '*
        '###  Function Description: 	Ending the Lean Built In reporter Context
        '*
        '###  Created Date: 			26/Oct/2016
        '*
        '###  Created By:     			Abdelghany Elsayed / aelsayed@elm
        '************************************************************************************************************************************************************************************/
        public static void EndIteration()
        {
            try
            {
                //Reporter.EndReportingContext();
                Console.WriteLine("\n\t............ End Iteration ............");
            }
            catch (Exception e)
            {
                //Reporter.ReportEvent("Ending  Iteration", "End  Iteration / Context", "Failed", e);
                Logger.LogError("Ending  Iteration || " + e.Message);
                Console.WriteLine("\t\t[Failed]  Ending  Iteration  : " + e.Message);
            }
        }

        /*'#####***********************************************************************************************************************************************************************************'
	    '###  Function Name: 			ExecutionFinalResults
	    '*
	    '###  Function Description: 	Summary for all the executed test cases at the custom report.
	    '*
	    '###  Created Date: 			26/Oct/2016
	    '*
	    '###  Created By:     			Abdelghany Elsayed / aelsayed@elm
	    '************************************************************************************************************************************************************************************/
        public static void ExecutionFinalResults()
        {
            try
            {
                if (GlobalVars.Test.CustomReportEnable)
                {
                    var objFile = System.IO.File.AppendText(GlobalVars.Reporter.ReportFileName);

                    objFile.WriteLine("<TABLE><TR><TD COLSPAN=2> </TD></TR></TABLE>");

                    objFile.WriteLine("<HTML><BODY><TABLE BORDER=1 CELLPADDING=3 CELLSPACING=1 WIDTH=100%><Caption><font FACE=\"Microsoft YaHei UI\" COLOR=#009900 SIZE=3><b> Test Automation Result Summary </b></font></caption>");

                    objFile.WriteLine("<TR COLS=6><TD BGCOLOR=#6d7b8d WIDTH=33%><FONT FACE=\"Microsoft YaHei UI\" COLOR=White SIZE=2><B><Center>Total No Of Test Cases</Center></B></FONT></TD><TD BGCOLOR=#6d7b8d WIDTH=33%><FONT FACE=\"Microsoft YaHei UI\" COLOR=White SIZE=2><B><Center>Passed</Center></B></FONT></TD><TD BGCOLOR=#6d7b8d WIDTH=33%><FONT FACE=\"Microsoft YaHei UI\" COLOR=White SIZE=2><B><Center>Failed</Center></B></FONT></TD></TR>");

                    objFile.WriteLine("<TR><TD BGCOLOR=#6d7b8d WIDTH=33%><FONT FACE=\"Microsoft YaHei UI\" COLOR=White SIZE=2><B><Center>" + GlobalVars.Reporter.TotalTestCaseCount+ "</Center></B></FONT></TD><TD BGCOLOR=#6d7b8d WIDTH=33%><FONT FACE=\"Microsoft YaHei UI\" COLOR=#00E600 SIZE=2><B> <Center>" + GlobalVars.Reporter.TotalPassCount+ "</Center></B></FONT></TD><TD BGCOLOR=#6d7b8d WIDTH=33%><FONT FACE=\"Microsoft YaHei UI\" COLOR=Red SIZE=2><B> <Center>" + GlobalVars.Reporter.TotalFailCount+ "</Center></B></FONT></TD></TR>");
                    
                    objFile.WriteLine(" </table></body></html>");

                    objFile.Close();

                    if (GlobalVars.Reporter.TotalFailCount > 0)
                        Environment.ExitCode = 1;
                }
            }
            catch (Exception e)
            {
                //Reporter.ReportEvent("Log the Final Results to Custom Report.", "Log the Final Results to Custom Report.", "Failed", e);
                Logger.LogError("log final result || " + e.Message);
                Console.WriteLine("\t\t[Failed]  log final result  : " + e.Message);
            }
            
        }

        /*'#####***********************************************************************************************************************************************************************************'
        '###  Function Name: 			SaveScreenShot
        '*
        '###  Function Description: 	Get screen shoot from desktop
        '*
        '###  Created Date: 			20/Oct/2016
        '*
        '###  Created By:     			Abdelghany Elsayed / aelsayed@elm
        '************************************************************************************************************************************************************************************/
        private static string SaveScreenShot()
        {
            try
            {
                Bitmap printscreen = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
                Graphics graphics = Graphics.FromImage(printscreen as Image);
                graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
                string screenName = GlobalVars.Reporter.ScreenShootFolder + "\\Screen" + GlobalVars.Reporter.ScreenCaptureCount + ".png";
                printscreen.Save(screenName);
                return screenName;
            }
            catch(Exception e)
            {
                Logger.LogError("Get ScreenShot || " + e.Message);
                return null;
            }
            
        }

        /*'#####***********************************************************************************************************************************************************************************'
        '###  Function Name: 			GenerateReport
        '*
        '###  Function Description: 	Generet LeanFT Report and open the Custom report.
        '*
        '###  Created Date: 			20/Oct/2016
        '*
        '###  Created By:     			Abdelghany Elsayed / aelsayed@elm
        '************************************************************************************************************************************************************************************/
        public static void GenerateReport()
        {
            try
            {
                //Reporter.GenerateReport();
                if (GlobalVars.Test.EnvironmentData["ShowRunResult"].ToString().ToUpper() == "YES")
                 System.Diagnostics.Process.Start("chrome.exe", GlobalVars.Reporter.ReportFileName);
            }
            catch (Exception e)
            {
                Logger.LogError("Generate Report || " + e.Message);
                Console.WriteLine("\t\t[Failed]  Generate Report  : " + e.Message);
            }
            
        }


    }
}
