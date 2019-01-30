using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;

namespace SeleniumFramework
{

   


    class clsListFill
    {
        static IWebDriver driver;
        static Dictionary<IWebElement, IWebElement> gObjectList;
        static Dictionary<string, string> WebControlList;
        static Dictionary<IWebElement, string> Heuristic_Map_List;
        static List<Command> CurrentColumnList;
        static long MatchAcceptablePerentage = 90;
        static string parent_xpath;
        //static List<string> ColumnList;

        public  static Boolean isAttribtuePresent(IWebElement element, String attribute)
        {
            Boolean result = false;
            try
            {
                String value = element.GetAttribute(attribute);
                if (value != null)
                {
                    result = true;
                }
            }
            catch (Exception e) { Debug.WriteLine(e.Message); }

            return result;
        }

        public static void PrintChildAttributes(IWebElement child, string value)
        {
            if (isAttribtuePresent(child, "id"))
            { Debug.Write("ID:{0}", child.GetAttribute("id")); }

           
            Debug.Write("TagName:{0}", child.TagName );
            Debug.Write("Enabled:{0}", child.Enabled.ToString());
            Debug.Write("Displayed:{0}", child.Displayed.ToString ());

            if (isAttribtuePresent(child, "type"))
            { Debug.Write("Type:{0}", child.GetAttribute("type")); }

            Debug.WriteLine("Value:{0}", value);
        }



        public void Init_WebControlList(IWebDriver pdriver, List<Command> pCurrentColumnList, bool ploopback)
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


        }



        public void SequenceFill()
        {
            // WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 0, 20));
            //  wait.Until(drv => drv.FindElement(By.XPath(parent_xpath)));

            foreach (Command cmd in CurrentColumnList)
            {
                if (cmd.CommandData!="")
                Perform_Default_Operation(cmd.CommandName, cmd.CommandData);
            }
        }


        private static IWebElement GetChild(string column)
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
            catch (Exception ex) {  
                Debug.WriteLine(ex.Message); }

            return returnchild;

        }

        private static IWebElement GetMatchingChild(string column)
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


        private static void Perform_Default_Operation(string columnName, string data)
        {

            //Check for wait command
            if (columnName.ToLower().Contains("wait"))
            {
                Thread.Sleep(TimeSpan.FromSeconds(Int32.Parse(data)));
                return;
            }

            IWebElement child;
            //Get child object using ids
            child = GetChild(columnName);

            //if still not found, try getting it with matching percentage with any object displayed.
           // if (child == null) child = GetMatchingChild(columnName);

            if (child == null) {
                Debug.WriteLine("ColumnName :{} -- No matching child object found :( Check if the interface is changed or the currentColumn list is correct).", columnName);
                return;
            }
            //Wait for object 

            if (!child.Displayed || child.Enabled != true) { PrintChildAttributes(child, data); return; }

            try
            {
                switch (child.TagName)
                {

                    case "input":
                        if (child.GetAttribute("type") == "text" || child.GetAttribute("type") == "password" || child.GetAttribute("type") == "file")
                        {

                            PrintChildAttributes(child, data);
                            child.Clear();
                            child.SendKeys(data);
                            



                        }
                        else if (child.GetAttribute("type") == "radio" || child.GetAttribute("type") == "checkbox")
                        {
                            if (columnName == child.GetAttribute("id"))
                            {
                                PrintChildAttributes(child, data);
                                child.Click();
                                

                            }

                        }

                        break;

                    case "select":
                        PrintChildAttributes(child, data);
                        SelectElement selector = new SelectElement(child);
                        selector.SelectByText(data);
                        break;


                    case "a":
                    case "div":
                    case "checkbox":
                    case "span":
                                                
                            PrintChildAttributes(child, data);
                            child.Click();
                       
                        break;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }


        }


    }

}
