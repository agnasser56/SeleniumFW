using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
namespace SeleniumFramework
{
    public static class Extensions
    {

        /// <summary>
        /// check if the element exists and in case true it will validate is it Enabled.
        /// </summary>
        /// <param name="el"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool WaitUntilEnabled(this IWebElement el)
        {
            bool tempRes = false;

            try
            {

                if (Exists(el))
                {

                    GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                    WebDriverWait wait = new WebDriverWait(GlobalVars.Test.Browser, TimeSpan.FromSeconds(1));
                    wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                    tempRes = wait.Until<bool>((d) => { return el.Enabled; });
                }
                else
                { tempRes = false; }

                return tempRes;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVars.Test.BrowserTimeOut);
            }

        }

        /// <summary>
        /// check if the element exists and in case true it will validate is it Enabled Or Time Out is Over.
        /// </summary>
        /// <param name="el"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool WaitUntilEnabled(this IWebElement el, int timeout)
        {
            bool tempRes = false;

            try
            {

                if (Exists(el))
                {

                    GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                    WebDriverWait wait = new WebDriverWait(GlobalVars.Test.Browser, TimeSpan.FromSeconds((double)timeout));
                    wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                    tempRes = wait.Until<bool>((d) => { return el.Enabled; });
                }
                else
                { tempRes = false; }

                return tempRes;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVars.Test.BrowserTimeOut);
            }

        }

        /// <summary>
        /// this function will check is the element exists then if true it will validate the test contains passed text.
        /// </summary>
        /// <param name="el"></param>
        /// <param name="timeout"></param>
        /// <param name="sText"></param>
        /// <returns></returns>
        public static bool WaitUntilTextPresent(this IWebElement el, string sText)
        {
            bool tempRes = false;

            try
            {

                if (Exists(el))
                {
                    GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                    WebDriverWait wait = new WebDriverWait(GlobalVars.Test.Browser, TimeSpan.FromSeconds(1));
                    wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                    tempRes = wait.Until<bool>((d) => { return el.Text.ToUpper().Contains(sText.ToUpper().Trim()); });
                }
                else
                { tempRes = false; }

                return tempRes;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVars.Test.BrowserTimeOut);
            }

        }


        /// <summary>
        /// this function will check is the element exists then if true it will validate the test contains passed text.
        /// </summary>        
        /// <param name="theCurrentWebDriver"></param>
        /// <param name="TimeOutInSeconds"></param>
        /// <returns></returns>
        public static void ExplicitWait(this IWebDriver wd, int timeOut)
        {

            try
            {
                TimeSpan ts = new TimeSpan(0,0,int.Parse(ConfigurationManager.AppSettings["Browser.DefaultTimeout"]));
                wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
                wd.Manage().Timeouts().ImplicitWait = ts;                
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }            

        }

        /// <summary>
        /// this function will check is the element exists then if true it will validate the test contains passed text Or Time Out is Over.
        /// </summary>
        /// <param name="el"></param>
        /// <param name="timeout"></param>
        /// <param name="sText"></param>
        /// <returns></returns>
        /// 
        public static bool WaitUntilTextPresent(this IWebElement el, string sText, int timeout)
        {
            bool tempRes = false;

            try
            {

                if (Exists(el))
                {
                    GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                    WebDriverWait wait = new WebDriverWait(GlobalVars.Test.Browser, TimeSpan.FromSeconds((double)timeout));
                    wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                    tempRes = wait.Until<bool>((d) => { return el.Text.ToUpper().Contains(sText.ToUpper().Trim()); });
                }
                else
                { tempRes = false; }

                return tempRes;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVars.Test.BrowserTimeOut);
            }

        }

        /// <summary>
        /// This function will check existance of an element then wait untile it Displayed = false
        /// </summary>
        /// <param name="el"></param>
        /// <returns></returns>

        public static bool WaitUntilHidden(this IWebElement el)
        {
            bool tempRes = true;
            // double X = 0;
            try
            {

                if (Exists(el))
                {


                    GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                    WebDriverWait wait = new WebDriverWait(GlobalVars.Test.Browser, TimeSpan.FromSeconds(GlobalVars.Test.BrowserTimeOut));
                    wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                    tempRes = wait.Until<bool>((d) => { return !el.Displayed; });

                    //do
                    //{
                    //    tempRes = el.Displayed;
                    //    if (tempRes == false)
                    //        break;
                    //    else
                    //    { System.Threading.Thread.Sleep(1000); X++; }


                    //} while (! el.Displayed || X > GlobalVars.Test.BrowserTimeOut);
                }
                else
                { tempRes = false; }

                return tempRes;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVars.Test.BrowserTimeOut);
            }

        }

        /// <summary>
        /// This function will check existance of an element then wait untile it Displayed = false Or Time Out is Over
        /// </summary>
        /// <param name="el"></param>
        /// <returns></returns>
        public static bool WaitUntilHidden(this IWebElement el, int timeout)
        {
            bool tempRes = true;

            try
            {

                if (Exists(el))
                {
                    GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                    WebDriverWait wait = new WebDriverWait(GlobalVars.Test.Browser, TimeSpan.FromSeconds((double)timeout));
                    wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                    tempRes = wait.Until<bool>((d) => { return !el.Displayed; });

                }
                else
                { tempRes = false; }

                return tempRes;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVars.Test.BrowserTimeOut);
            }

        }

        /// <summary>
        /// This function will wait untile ready state is Completeted then check that element is displayed Or Time Out is Over
        /// </summary>
        /// <param name="element"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>

        public static bool Exists(this IWebElement element, int timeOut)
        {
            bool isExist = false;

            // check that element is not null;
            if (element == null)
            {
                return false;
            }

            // check the element existance.
            try
            {
                GlobalVars.Test.Browser.Sync();
                GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((double)timeOut);
                try { isExist = element.Displayed; } catch (NoSuchElementException) { isExist = false; }
                return isExist;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVars.Test.BrowserTimeOut);
            }

        }

        /// <summary>
        /// This function will wait untile readu state is Completeted then check that element is displayed.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool Exists(this IWebElement element)
        {
            bool isExist = false;

            // check that element is not null;
            if (element == null)
            {
                return false;
            }

            // check the element existance.
            try
            {
                GlobalVars.Test.Browser.Sync();
                GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                try { isExist = element.Displayed; } catch (NoSuchElementException) { isExist = false; }
                return isExist;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                GlobalVars.Test.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVars.Test.BrowserTimeOut);
            }

        }


        #region Abdelghany

        /// <summary>
        /// this function is returning the text value of a table [Row][Column]
        /// </summary>
        /// <param name="element"></param>
        /// <param name="iRow"></param>
        /// <param name="iCell"></param>
        /// <returns></returns>

        public static string CellValue(this IWebElement element, int iRow, int iCell)
        {
            string CellValue = "";
            IWebElement objCell = null;
            IWebElement objRow = null;

            // check that element is not null;
            if (element == null)
            {
                return "";
            }

            if (element.TagName.ToUpper() != "TABLE")
            {
                return "";
            }

            try
            {

                if (Exists(element, 1))
                {
                    objRow = element.FindElements(By.TagName("tr"))[iRow];
                    objCell = objRow.FindElements(By.TagName("td"))[iCell];
                    CellValue = objCell.Text.Trim();

                }
                else
                { CellValue = ""; }

                return CellValue;
            }
            catch (Exception)
            {
                return "";
            }

        }

        /// <summary>
        /// this function will return the number of rows in a table
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>

        public static int RowCount(this IWebElement element)
        {
            int iRowCount = 0;

            // check that element is not null;
            if (element == null)
            {
                return iRowCount;
            }

            if (element.TagName.ToUpper() != "TABLE")
            {
                return iRowCount;
            }

            try
            {

                if (Exists(element, 1))
                {
                    iRowCount = element.FindElements(By.TagName("tr")).Count;

                }
                else
                { iRowCount = 0; }

                return iRowCount;
            }
            catch (Exception)
            {
                return iRowCount;
            }

        }


        /// <summary>
        /// This function retrun the columns count for a specific row
        /// </summary>
        /// <param name="element"></param>
        /// <param name="iRow"></param>
        /// <returns></returns>

        public static int ColumnsCount(this IWebElement element, int iRow)
        {
            int iCount = 0;
            IWebElement objRow = null;
            // check that element is not null;
            if (element == null)
            {
                return iCount;
            }

            if (element.TagName.ToUpper() != "TABLE")
            {
                return iCount;
            }

            try
            {

                if (Exists(element, 1))
                {
                    objRow = element.FindElements(By.TagName("tr"))[iRow];
                    iCount = objRow.FindElements(By.TagName("td")).Count;

                }
                else
                { iCount = 0; }

                return iCount;
            }
            catch (Exception)
            {
                return iCount;
            }

        }


        /// <summary>
        /// This ufnction will return the child item of a table cell and tking locator and index
        /// </summary>
        /// <param name="element"></param>
        /// <param name="iRow"></param>
        /// <param name="iCell"></param>
        /// <param name="Locator"></param>
        /// <param name="iIndex"></param>
        /// <returns></returns>

        public static IWebElement CellChildElement(this IWebElement element, int iRow, int iCell, By Locator, int iIndex)
        {

            IWebElement objCell = null;
            IWebElement objRow = null;
            IWebElement objChild = null;

            // check that element is not null;
            if (element == null)
            {
                return null;
            }

            if (element.TagName.ToUpper() != "TABLE")
            {
                return null;
            }

            try
            {

                if (Exists(element, 1))
                {
                    objRow = element.FindElements(By.TagName("tr"))[iRow];
                    objCell = objRow.FindElements(By.TagName("td"))[iCell];
                    objChild = objCell.FindElements(Locator)[iIndex];
                }
                else
                { objChild = null; }

                return objChild;
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// This Function is taking a locator and index then return an element.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="Locator"></param>
        /// <param name="iIndex"></param>
        /// <returns></returns>

        public static IWebElement FindChildren(this IWebElement element, By Locator, int iIndex)
        {

            IWebElement objChild = null;


            // check that element is not null;
            if (element == null)
            {
                return null;
            }

            try
            {
                if (Exists(element, 1))
                {
                    objChild = element.FindElements(Locator)[iIndex];

                }
                else
                { objChild = null; }

                return objChild;
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// This function is taking a string Value then search for the Radio Element that has the value and click it.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="sValue"></param>

        public static void RadioButtonSelect(this IWebElement element, string sValue)
        {
            // check that element is not null;
            if (element == null)
            {
                return;
            }

            try
            {
                if (Exists(element, 1))
                {
                    var objChildList = element.FindElements(By.TagName("label")); //for= 'Agency'By.TagName("input")

                    for (int i = 0; i < objChildList.Count; i++)
                    {
                        if (objChildList[i].GetAttribute("for").Trim().ToUpper() == sValue.Trim().ToUpper())
                        {
                            objChildList[i].Click();
                            break;
                        }
                    }

                }
                else
                { return; }

            }
            catch (Exception)
            {
                return;
            }

        }


        /// <summary>
        /// This function is taking a string Value then search for the Check Box Element that has the value and check if not selected then click it.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="sValue"></param>

        public static void CheckBoxSet(this IWebElement element, string sValue)
        {
            IWebElement objChild = null;

            // check that element is not null;
            if (element == null)
            {
                return;
            }

            try
            {
                if (Exists(element, 1))
                {
                    var objChildList = element.FindElements(By.TagName("label"));

                    for (int i = 0; i < objChildList.Count; i++)
                    {
                        objChild = objChildList[i];
                        if (objChild.GetAttribute("for").Trim().ToUpper() == sValue.Trim().ToUpper())
                        {
                            if (!objChild.Selected)
                                objChildList[i].Click();

                            break;
                        }
                    }

                }
                else
                { return; }

            }
            catch (Exception)
            {
                return;
            }

        }


        /// <summary>
        /// This function will be used to clear data and reset new data.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="sValue"></param>

        public static void SetValue(this IWebElement element, string sValue)
        {


            // check that element is not null;
            if (element == null)
            {
                return;
            }

            try
            {
                if (Exists(element, 1))
                {
                    element.RemoveAttribute("readonly");
                    element.RemoveAttribute("disabled");
                    element.Clear();
                    element.SendKeys(sValue.Trim());

                }
                else
                { return; }

            }
            catch (Exception)
            {
                return;
            }

        }

        /// <summary>
        /// this function will be used to remove attribute of any element by taking the attribute name.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="AttributeName"></param>

        public static void RemoveAttribute(this IWebElement element, string AttributeName)
        {
            IJavaScriptExecutor jsExec;
            string className = "";
            string ID = "";
            string name = "";
            string tagName = "";
            string getElementFunc = "";

            try
            {

                jsExec = (IJavaScriptExecutor)GlobalVars.Test.Browser;

                ID = element.GetAttribute("id");
                className = element.GetAttribute("class");
                name = element.GetAttribute("name");
                tagName = element.TagName;

                if (ID.Length > 0)
                {
                    getElementFunc = "getElementById('" + ID + "')";
                }
                else if (name.Length > 0)
                {
                    getElementFunc = "getElementsByName('" + name + "')";
                }
                else if (className.Length > 0)
                {
                    getElementFunc = "getElementsByClassName('" + className + "')";
                }
                else if (tagName.Length > 0)
                {
                    getElementFunc = "getElementsByTagName('" + tagName + "')";
                }

                try
                {
                    jsExec.ExecuteScript("for (i = 0; i < document." + getElementFunc + ".length; i++) { document." + getElementFunc + "[i].removeAttribute('" + AttributeName + "');}");
                }
                catch (Exception ex) { return; }

            }
            catch (Exception ex)
            { return; }
        }

        /// <summary>
        /// This function is waiting untile the readu state of IwebDriver browser to be COMPLETE
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>

        public static bool Sync(this IWebDriver driver)
        {

            string sState = "";
            IJavaScriptExecutor jsExec;

            bool isReady = false;

            if (driver == null)
            { return false; }

            try
            {
                jsExec = (IJavaScriptExecutor)driver;

                do
                {
                    sState = jsExec.ExecuteScript("return document.readyState;").ToString();

                    if (sState.Trim().ToUpper() == "COMPLETE")
                    {
                        isReady = true;
                        break;
                    }

                } while (sState.Trim().ToUpper() != "COMPLETE");

                return isReady;
            }
            catch (Exception ex)
            {
                return isReady;
            }
        }

        /// <summary>
        /// Mouse Click to be used instead of Event click.
        /// </summary>
        /// <param name="element"></param>
        public static void MouseClick(this IWebElement element)
        {
            Actions builder = new Actions(GlobalVars.Test.Browser);
            builder.Click(element);
            builder.Perform();
        }

        /// <summary>
        /// Right click an elemnet
        /// </summary>
        /// <param name="element"></param>
        public static void RightClick(this IWebElement element)
        {
            Actions builder = new Actions(GlobalVars.Test.Browser);
            builder.ContextClick(element);
            builder.Perform();
        }

        /// <summary>
        /// MouseHover
        /// </summary>
        /// <param name="element"></param>
        public static void MouseHover(this IWebElement element)
        {
            Actions builder = new Actions(GlobalVars.Test.Browser);
            builder.MoveToElement(element);
            builder.Perform();
        }
        #endregion


    }
}
