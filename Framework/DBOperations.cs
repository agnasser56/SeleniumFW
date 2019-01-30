using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;
using System.Reflection;
using Faker;
namespace SeleniumFramework
{
    public static class DBOperations
    {
        public static void InsertCompanyInfo(string MOI_NO)
        {
            dynamic SQL = null;
            SQL = "insert into TBL_CAC_TEST_DATA_COMPANY(MOI, Name ) values (<MOI_NO>, N'شركة اوتوميشن' )";
            SQL.Replace( "<MOI_NO>", MOI_NO);
            DataManager.ExcuteQuery(SQL);

        }
        public static void GetMethods(object str)
        {
            //DataTable dt = new DataTable();
            ////Get the function names with Exceution Flag = Yes
            //dt = DataManager.GetExcelDataTable("select * from [Driver$] where Execution_Flag = 'YES'");
            //List<MethodInfo> methods = new List<MethodInfo>(typeof(TestSuite).GetMethods());
            //TestSuite sm = new TestSuite();

            ////Get list of functions that exist in the excel sheet.
            //var myMethods = methods.Where(p => dt.AsEnumerable().Any(p2 => p2["Function_Name"].ToString() == p.Name));
        }
        public static void UploadTrsfownershipDocsToDB(DataRow dr)
        {

            try
            {
                string userID = DataManager.GetExcelValue("select top 1 UserName from [Login$] where RowID = "+dr["LoginRow"].ToString());
                string sql = "DECLARE @trsf_request_identity INT" +               
                            "SELECT top 1  @trsf_request_identity = TRANSFER_REQUEST_IDENTITY"+
                            "FROM[dbo].TBL_SOA_TRANSFER_OWNERSHIP_REQUEST L"+
                            "WHERE  L.WEB_USER_ID = '"+ userID + "'  order by OPERATION_LOG_TIME desc"+
                            "INSERT INTO[CAC_QA].[dbo].[TBL_CAC_CONTRACT_UPLOAD_IMAGES_PATH]"+
                            "([IMAGE_1] ,[IMAGE_2] ,[IMAGE_3]  ,[IMAGE_4] ,[IMAGE_5] ,[MORROR],[TRANSFER_REQUEST_IDENTITY]  ,[APPLICATION_LOG_IDENTITY] ,[IMAGES_COUNT])  VALUES"+
                            "('test.png',        '',         '',        '',        '',    null,       @trsf_request_identity,           0,                       1)";
                DataManager.ExcuteQuery(sql);
            }
            catch (Exception ex)
            {
            }
        }

        public static string GenerateVehiclePlateNo()
        {
            //        'Generate a date time serial no

            //'Replace the number with the char alternative

            //'Sample usage

            string plateText = "";
            string plateNo = "";

            string TemplateText;
            TemplateText = "أبحدرسصطعقكلمنهوي";
            //pick three random characters.
            int textLenght = TemplateText.Length;
            plateText += TemplateText.ElementAt(Faker.RandomNumber.Next(textLenght)).ToString();
            plateText += ",";
            plateText += TemplateText.ElementAt(Faker.RandomNumber.Next(textLenght)).ToString();
            plateText += ",";
            plateText += TemplateText.ElementAt(Faker.RandomNumber.Next(textLenght)).ToString();
            plateText += ",";
            plateNo = Faker.RandomNumber.Next(1000, 9999).ToString();

            plateText += plateNo;
            return plateText;
        }
        public static string GetVehicleRegCardNo(DataRow dr)
        { 
            string VehicleRegCardNo = "";
            string userName = DataManager.GetExcelValue("select top 1 UserName from [Login$] where RowID=" + dr["LoginRow"].ToString());  
            VehicleRegCardNo = DataManager.GetDBValue("select TOP 1 D.CARD_SERIAL_NUMBER from [CAC_QA].[dbo].[TBL_CAC_accounts] a inner join  [CAC_QA].[dbo].[TBL_CAC_VEHICLE_LICENSE_CARDS] D on a.account_identity = D.ACCOUNT_ID INNER JOIN  [CAC_QA].[dbo].[TBL_CAC_branchs] b  on a.account_identity = b.account_identity inner join [CAC_QA].[dbo].[TBL_CAC_users] c  on b.Branch_Identity = c.Branch_Identity  where c.web_user_ID = '" 
                +  userName + "' and current_status = 3").ToString();
            return VehicleRegCardNo;
        }
    public static  VehicleData InsertVehicle(bool AutoFlag)
        {

            VehicleData vehDetails = new VehicleData().GetVehicle();
            string VehiclePlateNo = "";
            string uniqueNumber = "";
            List <string> vehDet = new List<string>();
            //If autogenerate , then overwrite the old values
            if (AutoFlag == true)
            {
                uniqueNumber = Faker.RandomNumber.Next(1000000000, 2000000000).ToString();
                VehiclePlateNo = GenerateVehiclePlateNo();
                vehDetails.PlateType = "1";
                vehDet = VehiclePlateNo.Split(',').ToList();
                vehDetails.TEXT1 = vehDet.ElementAt(0);
                vehDetails.TEXT2 = vehDet.ElementAt(1);
                vehDetails.TEXT3 = vehDet.ElementAt(2);
                vehDetails.PLATE_NUMBER = vehDet.ElementAt(3);
                vehDetails.SEQUENCE_NUMBER = uniqueNumber;
                vehDetails.VEHICLE_ID_NUMBER = uniqueNumber;
                vehDetails.VEHICLE_ENGINE_NUMBER = uniqueNumber;
                vehDetails.VEHICLE_CARD_NUMBER = uniqueNumber;
             }
            string SQL = "";
            SQL = "Insert into [dbo].[TBL_CAC_TEST_DATA_VEHICLE] values ("
            + vehDetails.OwnerIdentifier + ","
            + vehDetails.SEQUENCE_NUMBER + ","
            + vehDetails.PLATE_NUMBER + ","
            + vehDetails.PlateType + ","
             + "N'" + vehDetails.TEXT1 + "',"
             + "N'" + vehDetails.TEXT2 + "',"
             + "N'" + vehDetails.TEXT3 + "'," 
             + "N'" + vehDetails.VEHICLE_ID_NUMBER + "',"
             + "N'" + vehDetails.PLATE_TYPE_DESC_EN + "',"
             + "N'" + vehDetails.REG_PLACE + "',"
             + "N'" + vehDetails.REG_HDATE + "',"
             + "N'" + vehDetails.REG_EXPIRY_HDATE + "',"
             + "N'" + vehDetails.MAKE + "',"
             + "N'" + vehDetails.MODEL + "',"
             + "N'" + vehDetails.MODEL_YEAR + "',"
             + "N'" + vehDetails.BODY_TYPE + "',"
             + "N'" + vehDetails.MAJOR_COLOR + "',"
             + "N'" + vehDetails.MINOR_COLOR + "',"
             + "N'" + vehDetails.LK_VEH_STATUS + "',"
             + "N'" + vehDetails.DESCRIPTION + "',"
             + "N'" + vehDetails.LK_VEH_BODY_TYPE + "',"
             + "N'" + vehDetails.LK_VEHICLE_CLASS + "',"
             + "N'" + vehDetails.VEHICLE_CLASS_DESC + "',"
             + "N'" + vehDetails.ENGINE_NUMBER + "',"
             + "N'" + vehDetails.CYLINDERS + "',"
             + "N'" + vehDetails.CAPACITY + "',"
             + "N'" + vehDetails.WEIGHT + "',"
             + "N'" + vehDetails.AXLES + "',"
             + "N'" + vehDetails.CUSTOM_CARD_NUMBER + "',"
             + "N'" + vehDetails.INSPECTION_CERT_NO + "',"
             + "N'" + vehDetails.PLATE_RETURN_IND + "',"
             + "N'" + vehDetails.TRANSFER_BLOCKED + "')";
            DataManager.ExcuteQuery(SQL);
            return vehDetails;
        }

        public static  void InsertLicenseTestData(string ID , string LicnsTypeCode, string LicnsTypeDesc)
        {
            string SQL;
            SQL = "insert into [dbo].[TBL_CAC_TEST_DATA_ListAllDLLics] values (<LicnsNo> , <LicnsTypeCode>, N'<LicnsTypeDesc>',14300603 ,14471230 ,N'الرياض' )";
            SQL = SQL.Replace("<LicnsNo>", ID);
            SQL = SQL.Replace("<LicnsTypeCode>", LicnsTypeCode);
            SQL = SQL.Replace("<LicnsTypeDesc>", LicnsTypeDesc);
            DataManager.ExcuteQuery(SQL); 
            

        }
        public static void InsertSaudiTestData(string ID, string FirstName,string FamilyName)
        {
            dynamic SQL = null;
            if(Regex.IsMatch(FirstName, @"\p{IsArabic}"))
                SQL = "insert into [TBL_CAC_TEST_DATA_SAUDI] values (<ID>,0,'14200506',N'الرياض' , N'<FirstName>',N'عبد الرحمن',N'مبروك',N'الدامر',N'<FamilyName>',N'هيا',N'الحربي','13770701','1958-01-20',N'الرياض',0,1,'امير',0,NULL,NULL,NULL,376455,'14030411',N'الرياض',0 )";
            else
                SQL = "insert into [TBL_CAC_TEST_DATA_SAUDI] values (<ID>,0,'14200506',N'الرياض' , N'<FirstName>',N'Abdulrahman',N'Mabrook',N'Aldamer',N'<FamilyName>',N'هيا',N'الحربي','13770701','1958-01-20',N'الرياض',0,1,'امير',0,NULL,NULL,NULL,376455,'14030411',N'الرياض',0 )";

            SQL = SQL.Replace("<ID>", ID);
            SQL = SQL.Replace( "<FirstName>", FirstName);
            SQL = SQL.Replace( "<FamilyName>", FamilyName);
            DataManager.ExcuteQuery(SQL);

        }

        public static object GetTodayHijriDate()
        {
            //This function use the DB engine to get the hijri date, sql server to a DB should be there

            dynamic SQL = null;
            SQL = "DECLARE @DateTime AS DATETIME SET @DateTime=GETDATE() SELECT FORMAT(@DateTime, 'yyyy/MM/dd', 'ar') AS [TodayHijriDate]";

            //	GetTodayHijriDate =  formatdate(GetDBValue(SQL),"/","DMY")
            return DataManager.GetDBValue(SQL);

        }
        public static  object GetSpecificHijriDate(string PeriodInDays)
        {
            //This function use the DB engine to get the hijri date, sql server to a DB should be there
            dynamic SQL;
            SQL = "DECLARE @DateTime AS DATETIME SET @DateTime = DateAdd(day, "+PeriodInDays+", GETDATE()) SELECT FORMAT(@DateTime, 'yyyy/MM/dd', 'ar') AS[SpecificHijriDate]";
            //'GetSpecificHijriDate =  formatdate(GetDBValue(SQL),"/","DMY")
            return DataManager.GetDBValue(SQL);
        }


        public static void InsertSaudiTestDataWithFatherName(string ID, string FirstName, string FatherName, string FamilyName)
        {
            dynamic SQL = null;
            SQL = "insert into [TBL_CAC_TEST_DATA_SAUDI] values (<ID>,0,'14200506',N'الرياض' , N'<FirstName>',N'<FatherName>',N'مبروك',N'الدامر',N'<FamilyName>',N'هيا',N'الحربي','13770701','1958-01-20',N'الرياض',0,1,'امير',0,NULL,NULL,NULL,376455,'14030411',N'الرياض',0 )";
            SQL = SQL.Replace( "<ID>", ID);
            SQL = SQL.Replace( "<FirstName>", FirstName);
            SQL = SQL.Replace( "<FatherName>", FatherName);
            SQL = SQL.Replace( "<FamilyName>", FamilyName);
            DataManager.ExcuteQuery(SQL);

        }

     
        public static void AssignMoqeemSponser(string IqamaID,string SponserID)
        {
            dynamic SQL = null;


            SQL = SQL = "update TBL_CAC_TEST_DATA_NONSAUDI set spnsrid = '" + SponserID + "' where id = '" + IqamaID + "'  ";

            DataManager.ExcuteQuery(SQL);
        }


        public static void InsertPerson(string PersonType, string ID, string FirstName, string FamilyName)
        {

            if (PersonType == "Saudi")
            {
                InsertSaudiTestData(ID, FirstName, FamilyName);
            }
            else {
                InsertNonSaudiTestData(ID, FirstName, FamilyName);
            }

        }
        public static void InsertPersonWithFatherName(string PersonType, string ID, string FirstName, string FatherName, string FamilyName)
        {

            if (PersonType == "Saudi")
            {
                InsertSaudiTestDataWithFatherName(ID, FirstName, FatherName, FamilyName);
            }
            else {
                InsertNonSaudiTestData(ID, FirstName, FamilyName);
            }

        }



        public static void InsertNonSaudiTestData(string ID, string FirstName, string FamilyName)
        {
            dynamic SQL = null;
            SQL = "INSERT INTO [dbo].[TBL_CAC_TEST_DATA_NONSAUDI]           ([ID]           ,[IQAMA_VERSION_NO]           ,[SPNSRID]           ,[SPNSRNAME]           ,[FIRSTNAME]           ,[FATHERNAME]           ,[GNDFATHERNAME]           ,[FAMILYNAME]           ,[GENDERCODE]           ,[GENDER]" + ",[RELIGIONCODE]           ,[RELIGION]           ,[NATIONALITYNICCODE]           ,[NATIONALITYMOFACODE]           ,[NATIONALITY]           ,[OCCUPATIONCODE]           ,[OCCUPATION]           ,[BIRTHHDATE]           ,[BIRTHGDATE]" + ",[BIRTHPLACECODE]           ,[BIRTHPLACE]           ,[IDISSUEDATE]           ,[IDEXPIRYDATE]           ,[IDISSUEPLACECODE]           ,[IDISSUEPLACE]           ,[PASSPRTNO]           ,[STATUSCODE]           ,[STATUS]" + ",[EXITIND]" + ",[IN_SIDE])" + "VALUES" + "     (<ID>" + "     ,1" + "     ,NULL" + "     ,NULL" + "     ,N'<FIRSTNAME>'" + "     ,N'<FATHERNAME>'" + "     ,N'<GNDFATHERNAME>'" + "     ,N'<FAMILYNAME>'" + "     ,1" + "     ,N'ذكر'" + "     ,1" + "     ,N'الاسلام'" + "     ,106" + "     ,'OMN'" + "     ,N'عمان'" + "     ,99010" + "     ,N'عامل'" + "     ,14111111" + "     ,'1991-05-25 00:00:00.000'" + "     ,108" + "     ,N'مصر                 '" + "     ,14190326" + "     ,<IDEXPIRYDATE>" + "     ,1" + "     ,N'الرياض'" + "     ,'<PASSPRTNO>'" + "     ,0" + "     ,N'حي يرزق'" + "     ,0" + "     ,0)";
            SQL = SQL.Replace( "<ID>", ID);
            SQL = SQL.Replace( "<FIRSTNAME>", FirstName);
            SQL = SQL.Replace( "<FATHERNAME>", FirstName);
            SQL = SQL.Replace( "<GNDFATHERNAME>", FirstName);
            SQL = SQL.Replace( "<FAMILYNAME>", FamilyName);
            SQL = SQL.Replace("<IDEXPIRYDATE>", "14471230");
            SQL = SQL.Replace( "<PASSPRTNO>", ID);

            DataManager.ExcuteQuery(SQL);

        }

        public static  void InsertCustomCardNo(CustomClasses.CustomCard CustomInfo)
        {
            dynamic SQL = null;

            SQL = "INSERT INTO [dbo].[TBL_CAC_TEST_DATA_VEHICLE_CUSTOMS_CARD_NUMBER]" + "([VEHICLE_CARD_NUMBER]" + ",[VEHICLE_CARD_TS]" + ",[VEHICLE_ENTRY_PLACE_CODE]" + ",[VEHICLE_ENTRY_PLACE_DESC]" + ",[VEHICLE_ID_NUMBER]" + ",[VEHICLE_CLASS_CODE]" + ",[VEHICLE_CLASS_DESC]" + ",[VEHICLE_MODEL_YEAR]" + ",[VEHICLE_MAKE]" + ",[VEHICLE_MODEL]" + ",[VEHICLE_MAJOR_COLOR]" + ",[VEHICLE_MINOR_COLOR]" + ",[VEHICLE_ENGINE_NUMBER]" + ",[VEHICLE_CAPACITY]" + ",[VEHICLE_WEIGHT]" + ",[RECORD_TS]" + ",[TIMESTAMP0]" + ",[PLATE_NUMBER]" + ",[TEXT1]" + " ,[TEXT2]" + " ,[TEXT3]" + " ,[REGISTRATION_TYPE_CODE]" + " ,[REGISTRATION_TYPE_DESCRIPTION])" + "VALUES" + "     (N'<VEHICLE_CARD_NUMBER>'" + "     ,'<VEHICLE_CARD_TS>'" + "     ,<VEHICLE_ENTRY_PLACE_CODE>" + "     ,'<VEHICLE_ENTRY_PLACE_DESC>'" + "     ,'<VEHICLE_ID_NUMBER>'" + "    ,<VEHICLE_CLASS_CODE>" + "    ,'<VEHICLE_CLASS_DESC>'" + "    ,<VEHICLE_MODEL_YEAR>" + "    ,'<VEHICLE_MAKE>'" + "    ,'<VEHICLE_MODEL>'" + "    ,'<VEHICLE_MAJOR_COLOR>'" + "    ,'<VEHICLE_MINOR_COLOR>'" + "    ,'<VEHICLE_ENGINE_NUMBER>'" + "    ,<VEHICLE_CAPACITY>" + "    ,<VEHICLE_WEIGHT>" + "    ,'<RECORD_TS>'" + "    ,'<TIMESTAMP0>'" + "    ,<PLATE_NUMBER>" + "    ,N'<TEXT1>'" + "    ,N'<TEXT2>'" + "    ,N'<TEXT3>'" + "    ,<REGISTRATION_TYPE_CODE>" + "    ,N'<REGISTRATION_TYPE_DESCRIPTION>')";

            SQL = SQL.Replace( "<VEHICLE_CARD_NUMBER>", CustomInfo.VEHICLE_CARD_NUMBER);
            SQL = SQL.Replace( "<VEHICLE_CARD_TS>", CustomInfo.VEHICLE_CARD_TS);
            SQL = SQL.Replace( "<VEHICLE_ENTRY_PLACE_CODE>", CustomInfo.VEHICLE_ENTRY_PLACE_CODE);
            SQL = SQL.Replace( "<VEHICLE_ENTRY_PLACE_DESC>", CustomInfo.VEHICLE_ENTRY_PLACE_DESC);
            SQL = SQL.Replace( "<VEHICLE_ID_NUMBER>", CustomInfo.VEHICLE_ID_NUMBER);
            SQL = SQL.Replace( "<VEHICLE_CLASS_CODE>", CustomInfo.VEHICLE_CLASS_CODE);
            SQL = SQL.Replace( "<VEHICLE_CLASS_DESC>", CustomInfo.VEHICLE_CLASS_DESC);
            SQL = SQL.Replace( "<VEHICLE_MODEL_YEAR>", CustomInfo.VEHICLE_MODEL_YEAR);
            SQL = SQL.Replace( "<VEHICLE_MAKE>", CustomInfo.VEHICLE_MAKE);
            SQL = SQL.Replace( "<VEHICLE_MODEL>", CustomInfo.VEHICLE_MODEL);
            SQL = SQL.Replace( "<VEHICLE_MAJOR_COLOR>", CustomInfo.VEHICLE_MAJOR_COLOR);
            SQL = SQL.Replace( "<VEHICLE_MINOR_COLOR>", CustomInfo.VEHICLE_MINOR_COLOR);
            SQL = SQL.Replace( "<VEHICLE_ENGINE_NUMBER>", CustomInfo.VEHICLE_ENGINE_NUMBER);
            SQL = SQL.Replace( "<VEHICLE_CAPACITY>", CustomInfo.VEHICLE_CAPACITY);
            SQL = SQL.Replace( "<VEHICLE_WEIGHT>", CustomInfo.VEHICLE_WEIGHT);
            SQL = SQL.Replace( "<RECORD_TS>", CustomInfo.RECORD_TS);
            SQL = SQL.Replace( "<VEHICLE_CAPACITY>", CustomInfo.VEHICLE_CAPACITY);
            SQL = SQL.Replace( "<TIMESTAMP0>", CustomInfo.TIMESTAMP0);
            SQL = SQL.Replace( "<PLATE_NUMBER>", CustomInfo.PLATE_NUMBER);
            SQL = SQL.Replace( "<TEXT1>", CustomInfo.TEXT1);
            SQL = SQL.Replace( "<TEXT2>", CustomInfo.TEXT2);
            SQL = SQL.Replace( "<TEXT3>", CustomInfo.TEXT3);
            SQL = SQL.Replace( "<REGISTRATION_TYPE_CODE>", CustomInfo.REGISTRATION_TYPE_CODE);
            SQL = SQL.Replace( "<REGISTRATION_TYPE_DESCRIPTION>", CustomInfo.REGISTRATION_TYPE_DESCRIPTION);

            DataManager.ExcuteQuery(SQL);


        }

       
       
    }
}
