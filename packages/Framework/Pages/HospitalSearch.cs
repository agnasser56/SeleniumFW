using System;
using OpenQA.Selenium.Support.UI;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
namespace SeleniumFramework
{

   public  class HospitalSearch
    {
        [FindsBy(How = How.Id, Using = "dropRegion")]
        private IWebElement ddlRegion;

        [FindsBy(How = How.Id, Using = "dropCity")]
        private IWebElement ddlCity;

        [FindsBy(How = How.Id, Using = "drpRetestAuth")]
        private IWebElement ddlRetestAuthority;

        [FindsBy(How = How.Id, Using = "btnShow")]
        private IWebElement btnShow;


        [FindsBy(How = How.Id, Using = "gdvHospitals")]
        private IWebElement chkSearchHospitals;
        public bool SearchHospital(FunctionParameters fn)
        {
            try { 
            //Default waiting 
            WebDriverWait wait = new WebDriverWait(fn.WebDriver, TimeSpan.FromSeconds(fn.WebBrowser.DefaultTimeout));
            DataTable dt = new DataTable();
            dt = DataManager.GetExcelDataTable("select top 1 * from ["+fn.SheetName+"$] where RowID="+fn.RowNo);
            fn.WebDriver.Url = fn.WebDriver.FindElement(By.XPath("//map/area[@title='"+ dt.Rows[0]["Region"].ToString() + "']")).GetAttribute("href");
            fn.WebDriver.Navigate();
            SearchHospital(dt.Rows[0]);
            if (chkSearchHospitals.Displayed == true)
                return true;
            else return false;

        }
            catch { return false; }
        }
        
        public void  SearchHospital(DataRow dr)
        {
            try
            {
                SelectElement ddlRegionSelect = new SelectElement(ddlRegion);
                ddlRegionSelect.SelectByText(dr["Region"].ToString()+ " District");

                SelectElement ddlCitySelect = new SelectElement(ddlCity);
                ddlCitySelect.SelectByText(dr["City"].ToString());

                SelectElement ddlRetestAuthoritySelect = new SelectElement(ddlRetestAuthority);
                ddlRetestAuthoritySelect.SelectByText(dr["RetestAuthority"].ToString());
                btnShow.Click();
 
            }
            catch {  }
        }

        }
}
