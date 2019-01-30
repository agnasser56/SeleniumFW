using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SeleniumFramework
{
    public class VehicleData
    {
        public string OwnerIdentifier { get; internal set; }
        public string VEHICLE_CARD_NUMBER { get; internal set; }
        public string VEHICLE_CARD_TS { get; internal set; }
        public string VEHICLE_ENTRY_PLACE_CODE { get; internal set; }
        public string VEHICLE_ENTRY_PLACE_DESC { get; internal set; }
        public string VEHICLE_ID_NUMBER { get; internal set; }
        public string VEHICLE_CLASS_CODE { get; internal set; }
        public string VEHICLE_CLASS_DESC { get; internal set; }
        public string VEHICLE_MODEL_YEAR { get; internal set; }
        public string VEHICLE_MAKE { get; internal set; }
        public string VEHICLE_MODEL { get; internal set; }
        public string VEHICLE_MAJOR_COLOR { get; internal set; }
        public string VEHICLE_MINOR_COLOR { get; internal set; }
        public string VEHICLE_ENGINE_NUMBER { get; internal set; }
        public string VEHICLE_CAPACITY { get; internal set; }
        public string VEHICLE_WEIGHT { get; internal set; }
        public string RECORD_TS { get; internal set; }
        public string SEQUENCE_NUMBER { get; internal set; }
        public string PlateType { get; internal set; }
        public string PLATE_TYPE_DESC_EN { get; internal set; }
        public string TIMESTAMP0 { get; internal set; }
        public string PLATE_NUMBER { get; internal set; }
        public string TEXT1 { get; internal set; }
        public string TEXT2 { get; internal set; }
        public string TEXT3 { get; internal set; }
        public string REGISTRATION_TYPE_CODE { get; internal set; }
        public string REGISTRATION_TYPE_DESCRIPTION { get; internal set; }
        public string WEIGHT { get; internal set; }
        public string AXLES { get; internal set; }
        public string MODEL { get; internal set; }
        public string REG_PLACE { get; internal set; }
        public string REG_HDATE { get; internal set; }
        public string REG_EXPIRY_HDATE { get; internal set; }
        public string MAKE { get; internal set; }
        public string MODEL_YEAR { get; internal set; }
        public string BODY_TYPE { get; internal set; }
        public string MAJOR_COLOR { get; internal set; }
        public string MINOR_COLOR { get; internal set; }
        public string LK_VEH_STATUS { get; internal set; }
        public string DESCRIPTION { get; internal set; }
        public string LK_VEH_BODY_TYPE { get; internal set; }
        public string LK_VEHICLE_CLASS { get; internal set; }
        public string ENGINE_NUMBER { get; internal set; }
        public string CYLINDERS { get; internal set; }
        public string CAPACITY { get; internal set; }
        public string CUSTOM_CARD_NUMBER { get; internal set; }
        public string INSPECTION_CERT_NO { get; internal set; }
        public string PLATE_RETURN_IND { get; internal set; }
        public string TRANSFER_BLOCKED { get; internal set; }

        public VehicleData()
        {

        }
        public VehicleData GetVehicle()
        {
            VehicleData excelVehData = new VehicleData(DataManager.GetExcelDataTable("select * from [VehicleData$] where RowID=161").Rows[0]);
            return excelVehData;
        }
        public VehicleData(DataRow dr)
        {
            try
            {
                foreach (object obj in dr.ItemArray)
                {
                    int i = 0;
                    if (obj == null)
                    {
                        dr[i] = "";
                        i++;
                    }
                }
                OwnerIdentifier = dr["OWNER_IDENTIFIER"].ToString();
                //VEHICLE_CARD_NUMBER = dr["VEHICLE_CARD_NUMBER"].ToString();
               // VEHICLE_CARD_TS = dr["VEHICLE_CARD_TS"].ToString();
                //VEHICLE_ENTRY_PLACE_CODE = dr["VEHICLE_ENTRY_PLACE_CODE"].ToString();
                //VEHICLE_ENTRY_PLACE_DESC = dr["VEHICLE_ENTRY_PLACE_DESC"].ToString();
                //VEHICLE_ID_NUMBER = dr["VEHICLE_ID_NUMBER"].ToString();
               // VEHICLE_CLASS_CODE = dr["VEHICLE_CLASS_CODE"].ToString();
               // VEHICLE_CLASS_DESC = dr["VEHICLE_CLASS_DESC"].ToString();
                VEHICLE_MODEL_YEAR = dr["MODEL_YEAR"].ToString();
                VEHICLE_MAKE = dr["MAKE"].ToString();
                VEHICLE_MODEL = dr["MODEL"].ToString();
                VEHICLE_MAJOR_COLOR = dr["MAJOR_COLOR"].ToString();
                VEHICLE_MINOR_COLOR = dr["MINOR_COLOR"].ToString();
                VEHICLE_ENGINE_NUMBER = dr["ENGINE_NUMBER"].ToString();
                VEHICLE_CAPACITY = dr["CAPACITY"].ToString();
                VEHICLE_WEIGHT = dr["WEIGHT"].ToString();
                //RECORD_TS = dr["RECORD_TS"].ToString();
                SEQUENCE_NUMBER = dr["SEQUENCE_NUMBER"].ToString();
                PlateType = dr["PLATE_TYPE"].ToString();
                PLATE_TYPE_DESC_EN = dr["PLATE_TYPE_DESC_EN"].ToString();
                //TIMESTAMP0 = dr["TIMESTAMP0"].ToString();
                PLATE_NUMBER = dr["PLATE_NUMBER"].ToString();
                TEXT1 = dr["TEXT_1"].ToString();
                TEXT2 = dr["TEXT_2"].ToString();
                TEXT3 = dr["TEXT_3"].ToString();
               // REGISTRATION_TYPE_CODE = dr["REGISTRATION_TYPE_CODE"].ToString();
                //REGISTRATION_TYPE_DESCRIPTION = dr["REGISTRATION_TYPE_DESCRIPTION"].ToString();
                WEIGHT = dr["WEIGHT"].ToString();
                AXLES = dr["AXLES"].ToString();
                MODEL = dr["MODEL"].ToString();
                REG_PLACE = dr["REG_PLACE"].ToString();
                REG_HDATE = dr["REG_HDATE"].ToString();
                REG_EXPIRY_HDATE = dr["REG_EXPIRY_HDATE"].ToString();
                MAKE = dr["MAKE"].ToString();
                MODEL_YEAR = dr["MODEL_YEAR"].ToString();
                BODY_TYPE = dr["BODY_TYPE"].ToString();
                MAJOR_COLOR = dr["MAJOR_COLOR"].ToString();
                MINOR_COLOR = dr["MINOR_COLOR"].ToString();
                LK_VEH_STATUS = dr["LK_VEH_STATUS"].ToString();
                DESCRIPTION = dr["DESCRIPTION"].ToString();
                LK_VEH_BODY_TYPE = dr["LK_VEH_BODY_TYPE"].ToString();
                LK_VEHICLE_CLASS = dr["LK_VEHICLE_CLASS"].ToString();
                ENGINE_NUMBER = dr["ENGINE_NUMBER"].ToString();
                CYLINDERS = dr["CYLINDERS"].ToString();
                CAPACITY = dr["CAPACITY"].ToString();
                CUSTOM_CARD_NUMBER = dr["CUSTOM_CARD_NUMBER"].ToString();
                INSPECTION_CERT_NO = dr["INSPECTION_CERT_NO"].ToString();
                PLATE_RETURN_IND = dr["PLATE_RETURN_IND"].ToString();
                TRANSFER_BLOCKED = dr["TRANSFER_BLOCKED"].ToString();

            }
            catch
            {

            }

        }
    }
}
