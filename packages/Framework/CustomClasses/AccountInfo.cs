using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace SeleniumFramework.CustomClasses
{
    class AccountInfo
    {
        public string Account_MOI_Number;
        public string ACCOUNT_AR_FULL_NAME;
        public string ACCOUNT_EN_FULL_NAME;
        public string ACCOUNT_IDENTITY;
        AccountInfo()
        { }
        public AccountInfo(DataTable dt)
        {
            try
            {
                Account_MOI_Number = dt.Rows[0]["Account_MOI_Number"].ToString();
                ACCOUNT_AR_FULL_NAME= dt.Rows[0]["ACCOUNT_AR_FULL_NAME"].ToString();
                ACCOUNT_EN_FULL_NAME = dt.Rows[0]["ACCOUNT_EN_FULL_NAME"].ToString();
                ACCOUNT_IDENTITY = dt.Rows[0]["ACCOUNT_IDENTITY"].ToString();
            }
            catch { }
        }
    }
}
