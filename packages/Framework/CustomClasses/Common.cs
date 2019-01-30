using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Data;

namespace SeleniumFramework
{
    public class Common
    {

        public static List<Command> LoadCommandList(FunctionParameters fn)
        {
            DataTable dt = new DataTable();
            DataTable Hdt = new DataTable();
            string query;

            query = "select  * from  [<Sheetname>$] where RowID in (0,<ROWID>) order by RowID asc";
            query = query.Replace("<Sheetname>", fn.SheetName);
            query = query.Replace("<ROWID>", fn.RowNo);


            dt = DataManager.GetExcelDataTable(query);


            if (dt != null)
            {
               return DataManager.GetCommandList(dt);
            }
            else { return null; }
            
        }


        public static bool CheckOverallResult(List<Command> CommandList, FunctionParameters fn)
        {
            
            GenerateHTMLReportWithStepDetails(CommandList,fn);
            bool OverallResult = true;
            string commandsBuffer="";
            commandsBuffer = "\n" + fn.Function_Name;
            foreach (Command cmd in CommandList)
            {
               
                if (cmd.CommandData != "" && cmd.CommandName != "")
                {
                    commandsBuffer = commandsBuffer + "\nCommandName: " + cmd.CommandName + " CommandData: " + cmd.CommandData + " CommandResult:" + cmd.CommandResult.ToString() + " ErrorDetails: " + cmd.ErrorDetails ;

                    if (cmd.CommandResult == false)
                    {
                        
                        OverallResult = false; break;

                    }
                }
            }
            Logger.LogCommand(commandsBuffer);
            return OverallResult;
        }

        public static string InsertFunctionTable(List<Command> CommandList)
        {
            string commandsBuffer;
            commandsBuffer = "<table border='1' style='border-collapse:collapse;'>";
            commandsBuffer = commandsBuffer + "<tr bgcolor='#000080' style='color:white;font-weight:bold;'><td>ColumnName</td><td>CommandName</td><td>CommandData</td><td>CommandResult</td><td>ErrorDetails</td><td>Image</td></tr>";

            foreach (Command cmd in CommandList)
            {

                if (cmd.CommandData != "" && cmd.CommandName != "")
                {
                    //commandsBuffer = commandsBuffer + "\nCommandName: " + cmd.CommandName + " CommandData: " + cmd.CommandData + " CommandResult:" + cmd.CommandResult.ToString() + " ErrorDetails: " + cmd.ErrorDetails;
                    commandsBuffer = commandsBuffer + "<tr><td>" + cmd.ColumnName + "</td><td>" + cmd.CommandName + "</td><td>" + cmd.CommandData + "</td><td>" + cmd.CommandResult + "</td><td>" + cmd.ErrorDetails + "</td><td><a href='" + cmd.StepImagePath + "'>image</a></td></tr>";
                }
            }

            commandsBuffer = commandsBuffer + "</table><br/>";
            return commandsBuffer;
        }


        public static bool GenerateHTMLReportWithStepDetails(List<Command> CommandList, FunctionParameters fn)
        {
            bool OverallResult = true;
            string commandsBuffer = "";            
            commandsBuffer = "<!DOCTYPE html><html><head><meta charset='UTF-8'></head><body style='font - family:Calibri'>";

            //Login
            if (fn.LoginCommandList != null)
            {
                commandsBuffer = commandsBuffer + "<h3>" + "Login" + "</h3>";
                commandsBuffer = commandsBuffer + InsertFunctionTable(fn.LoginCommandList);
            }
            
            //Function
            commandsBuffer = commandsBuffer+"<h3>" + fn.Function_Name+"</h3>";
            commandsBuffer = commandsBuffer + InsertFunctionTable(CommandList);

            commandsBuffer = commandsBuffer + "</body></html>";
            StepReporter.SaveLog(fn.Function_Name + ".html", commandsBuffer);
            //Logger.LogCommand(commandsBuffer);
            return OverallResult;
        }

        public static bool VerifyOptionExist( IWebElement elm,string OptionValue)
        {
            bool result=false;
            try
            {
                if (elm.FindElement(By.XPath("//option[text()='" + OptionValue + "']")) != null)
                    result =  true;
                return result;

            }
            catch (Exception ex) { return result; }
        }

        public static void ExplicitWait(int Duration)
        {
            Thread.Sleep(TimeSpan.FromSeconds(Duration));
        }

        public static bool WaitForOptionPresenance(Browser brow, IWebElement elm, string OptionValue)
        {
            bool result = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(brow.WebDriver, TimeSpan.FromSeconds(brow.DefaultTimeout));
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//select/option[text()='" +OptionValue + "']")));
                result = VerifyOptionExist(elm,OptionValue);
                return result;
            }
            catch (Exception ex) { return result; }
        }
        
        public static bool VerifyRadiobuttonOptionByLabelText(IWebDriver elm, string OptionValue)
        {
            bool result = false;
            IWebElement radioButton = elm.FindElement(By.Id(elm.FindElement(By.XPath("//label[text()[contains(.,'" + OptionValue + "')]]")).GetAttribute("for")));
            
            try
            {

                if (radioButton != null)
                {
                    if(radioButton.GetAttribute("checked")== "true")                   
                        result = true;
                }
                return result;

            }
            catch (Exception ex) { return result; }
        }

        public static bool CheckPointVerification(IWebElement elem, string text)
        {
            bool success = false;
            try
            {
                if (elem.Exists())
                {
                    if (elem.Displayed)
                    {
                        if (elem.Text.ToLower().Contains(text.ToLower()))
                        {
                            success = true;
                            return success;
                        }
                        else return success;
                    }
                    else return success;
                }
                else
                    return success;

            }
            catch (Exception ex) { return success; }
        }

    }
}
