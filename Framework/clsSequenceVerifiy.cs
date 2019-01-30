using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
using OpenQA.Selenium.Remote;

namespace SeleniumFramework
{
    

    class clsSequenceVerify
    {
        public IWebDriver driver;
        public Dictionary<IWebElement, IWebElement> gObjectList;
        public Dictionary<string, string> WebControlList;
        public Dictionary<IWebElement, string> Heuristic_Map_List;
        public List<Command> CurrentColumnList;
        public long MatchAcceptablePerentage = 90;
        public string parent_xpath;
        public int ObjectNotFoundCounter;
        public int OBJECTNOTFOUND_MAXLIMIT;
        public string SuiteMode;
        

        public  Boolean isAttribtuePresent(IWebElement element, String attribute)
        {
            Boolean result = false;
            try
            {
                String value = element.GetAttribute(attribute);
                //if (value == null )
                //{
                //    result = true;
                //}
                if (value == "false")
                {
                    result = false;
                }
                else if (value == "true")
                {
                    result = true;
                }

            }
            catch (Exception e) { Debug.WriteLine(e.Message); }

            return result;
        }

        public  void PrintChildAttributes(IWebElement child, string value)
        {
            if (isAttribtuePresent(child, "id"))
            { Debug.Write("[ID]:" + child.GetAttribute("id")); }


            Debug.Write("   [TagName]:"+ child.TagName);
            Debug.Write("   [Enabled]:"+ child.Enabled.ToString());
            Debug.Write("   [Displayed]:"+ child.Displayed.ToString());

            if (isAttribtuePresent(child, "type"))
            { Debug.Write("   [Type]:" + child.GetAttribute("type")); }

            Debug.WriteLine("   [Value]:"+ value);
        }


        public string TakeScreenShot()
        {

            string fileName;
            fileName = "";
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                string path = Environment.CurrentDirectory;
                fileName = path + "\\StepScreenshots\\" + DateTime.Now.ToString("dd-MM-yy-HH-mm-ss-ff") + ".png";
                ss.SaveAsFile(fileName, ScreenshotImageFormat.Png);
               
            }
            catch (UnhandledAlertException uae) { Logger.Log(uae.Message + "\n StackTrace" + uae.StackTrace + "\n"); }
            return fileName;

        }

        public void Init_WebControlList(IWebDriver pdriver, List<Command> pCurrentColumnList, bool ploopback, string pSuiteMode)
        {
            driver = pdriver;
            Heuristic_Map_List = new Dictionary<IWebElement, string>();
            gObjectList = new Dictionary<IWebElement, IWebElement>();
            WebControlList = new Dictionary<string, string>();
            WebControlList.Add("input", "input");
            WebControlList.Add("a", "a");
            WebControlList.Add("select", "select");
            //WebControlList.Add("span", "span");
            parent_xpath = "//*[name()='input' or name()='a' or name()='select' ]";
            CurrentColumnList = pCurrentColumnList;
            ObjectNotFoundCounter = 0;
            OBJECTNOTFOUND_MAXLIMIT = 1;
            SuiteMode = pSuiteMode;


        }



        public List<Command>  SequenceVerify()
        {
            // WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 0, 20));
            //  wait.Until(drv => drv.FindElement(By.XPath(parent_xpath)));
            string errordetails;

            foreach (Command cmd in CurrentColumnList)
            {
               
                if (cmd.CommandData != "" && cmd.CommandName != "" )
                {
                    errordetails = "";
                    if (ObjectNotFoundCounter < OBJECTNOTFOUND_MAXLIMIT)
                    {
                       
                            cmd.CommandResult = Verify(cmd.CommandName, cmd.CommandData, out errordetails, cmd.ColumnName);
                            cmd.ErrorDetails = errordetails;
                            if (SuiteMode == "NO") cmd.StepImagePath = TakeScreenShot();
                        
                    }


                }
            }
            return CurrentColumnList;
        }


       

        private  IWebElement GetChild(string column, string data)
        {
            IWebElement returnchild = null;
           

          

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 0, 30));
            try
            {

                 if (column.StartsWith("/"))
                {
                    //handle xpaths 
                    wait.Until(drv => drv.FindElement(By.XPath(column)));
                    returnchild = driver.FindElement(By.XPath(column));

                }
                else if (column.Equals("xpath"))
                {
                    //handle xpaths 
                    wait.Until(drv => drv.FindElement(By.XPath(data)));
                    returnchild = driver.FindElement(By.XPath(data));

                }
                else
                {

                    wait.Until(drv => drv.FindElement(By.Id(column)));
                    returnchild = driver.FindElement(By.Id(column));

                    if (returnchild != null)
                    {

                        if (!Heuristic_Map_List.ContainsKey(returnchild))
                        {
                            Heuristic_Map_List.Add(returnchild, column);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine("CHILD:" + column + " DATA:" + data + "-->" + ex.Message);
            }
            finally
            {
                if (returnchild == null) ObjectNotFoundCounter++;
            }

            return returnchild;

        }

        private  IWebElement GetMatchingChild(string column)
        {
            IWebElement returnchild = null;

            ReadOnlyCollection<IWebElement> childObjects = driver.FindElements(By.XPath(parent_xpath));

            //we should wait here if needed.
            foreach (IWebElement child in childObjects)
            {

                if (!Heuristic_Map_List.ContainsKey(child))
                {
                    if (StringExtender.CompareStringsRatcliff(child.GetAttribute("id").ToLower(), column.ToLower()) > MatchAcceptablePerentage)
                    {
                        Heuristic_Map_List.Add(child, column);
                        returnchild = child;
                        break;
                    }
                }
            }

            return returnchild;
        }


        private  bool Verify(string columnName, string data, out string ErrorDetails,string columnActualName)
        {
            bool returnValue;
            returnValue = false;
            ErrorDetails = "";

            //Check for wait command
            if (columnName.ToLower().Contains("wait"))
            {
                Thread.Sleep(TimeSpan.FromSeconds(Int32.Parse(data)));

                return true;
            }

            if (columnName.ToLower().Contains("navigate"))
            {
                //handle navigation command
                driver.Url = data;
                driver.Navigate();
                return true;
            }

            if (columnName.ToUpper().Contains("DB_UPDATE"))
            {
                //handle DB command
                DataManager.ExcuteQuery(data);
                return true;
            }


            IWebElement child;
            //Get child object using ids
            child = GetChild(columnName,data);

            //if still not found, try getting it with matching percentage with any object displayed.
            // if (child == null) child = GetMatchingChild(columnName);

            if (child == null)
            {
                Debug.WriteLine("ColumnName :{} -- No matching child object found :( Check if the interface is changed or the currentColumn list is correct).", columnName);
                ErrorDetails = columnActualName + " -- No matching object found :( Check if the interface is changed or the currentColumn list is correct).";
                return false;
            }
            //Wait for object 

            if (!child.Displayed ) { PrintChildAttributes(child, data); return false; }

            try
            {
                switch (child.TagName)
                {
                    
                    case "textarea":
                        PrintChildAttributes(child, data);
                        if (!isAttribtuePresent(child, "readonly") && !isAttribtuePresent(child, "disabled"))
                        {
                            child.Clear();
                            child.SendKeys(data);

                        }
                        if (child.GetAttribute("value") == data) returnValue = true;
                        else
                        {
                            ErrorDetails = columnActualName + "-->Text value does not match with application Text value.";
                           returnValue = false;

                        }
                        //Assert.AreEqual(child.GetAttribute("value"), data);
                        break;

                    case "input":
                        if (child.GetAttribute("type") == "text" || child.GetAttribute("type") == "password" || child.GetAttribute("type") == "search")
                        {

                            PrintChildAttributes(child, data);

                            if (!isAttribtuePresent(child, "readonly") && !isAttribtuePresent(child, "disabled"))
                            {
                                child.Clear();
                                child.SendKeys(data);
                            }

                            //Assert.AreEqual(child.GetAttribute("value"), data);
                            if (child.GetAttribute("value") == data) returnValue = true;
                            else
                            {
                                ErrorDetails = columnActualName + "-->Text value does not match with application Text value.";
                                returnValue = false; }
                        }
                        else if (child.GetAttribute("type") == "file")
                        {
                            PrintChildAttributes(child, data);

                            if (!isAttribtuePresent(child, "readonly") && !isAttribtuePresent(child, "disabled"))
                            {
                                child.Clear();
                                string FullFilePath;
                                FullFilePath = System.IO.Directory.GetCurrentDirectory() + data;
                                child.SendKeys(FullFilePath);
                            }

                            //Assert.AreEqual(child.GetAttribute("value"), data);
                            if (child.GetAttribute("value") == data) returnValue = true;
                            else
                            {
                                ErrorDetails = columnActualName + "-->File control value does not match with application File control value.";
                                returnValue = false;
                            }

                        }
                        else if (child.GetAttribute("type") == "radio" || child.GetAttribute("type") == "checkbox")
                        {

                            PrintChildAttributes(child, data);
                            if (!isAttribtuePresent(child, "disabled"))
                            {
                                if (!child.Selected) child.Click();
                                returnValue = true;
                            }
                            else if (child.Selected) returnValue = true;



                        }

                        break;

                    case "select":
                        PrintChildAttributes(child, data);
                        SelectElement selector = new SelectElement(child);
                        if (!isAttribtuePresent(child, "disabled"))   selector.SelectByText(data);
                        if (new SelectElement(GetChild(columnName, data)).SelectedOption.Text == data) returnValue = true;
                        else
                        {
                            ErrorDetails = columnActualName + "-->dropdownlist value does not match with application dropdownlist control value.";
                            returnValue = false; }
                        break;


                 
                    case "div":
                        PrintChildAttributes(child, data);
                        if (child.Exists())
                        {
                            child.Click();
                            if (!data.ToUpper().Equals("CLICK"))
                            {
                                if (child.Text.Trim().Equals(data))
                                    returnValue = true;
                                else
                                {
                                    ErrorDetails = columnActualName + "--><DIV> text value does not match with application <DIV> text value.";
                                    returnValue = false;
                                }
                            }
                            else returnValue = true;
                        }
                        break;

                    case "td":
                        PrintChildAttributes(child, data);
                        if (child.Exists())
                        {
                            child.Click();
                            if (child.Text.Trim().Equals(data))
                                returnValue = true;
                            else
                            {
                                ErrorDetails = columnActualName + "--><TD> text value does not match with application <TD> text value.";
                                returnValue = false;
                            }
                        }

                        break;

                    case "a":
                    case "checkbox":
                    case "span":

                        PrintChildAttributes(child, data);
                        if (child.Enabled)
                        {
                            child.Click();
                            returnValue= true;
                        }

                        break;

                }
                return returnValue;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                ErrorDetails = columnActualName + "-->[An Exception has Occured while handling this object.]" + ex.Message;
                return returnValue;

            }


        }


    }

}
