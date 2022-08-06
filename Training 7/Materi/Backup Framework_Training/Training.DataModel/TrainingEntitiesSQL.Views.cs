//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Data.Mapping.EntityViewGenerationAttribute(typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySets78E799F4E2700D6268337ABD16B399A5C6FDA687755DFA428D7B0B720013373B))]

namespace Edm_EntityMappingGeneratedViews
{
    
    
    /// <Summary>
    /// The type contains views for EntitySets and AssociationSets that were generated at design time.
    /// </Summary>
    public sealed class ViewsForBaseEntitySets78E799F4E2700D6268337ABD16B399A5C6FDA687755DFA428D7B0B720013373B : System.Data.Mapping.EntityViewContainer
    {
        
        /// <Summary>
        /// The constructor stores the views for the extents and also the hash values generated based on the metadata and mapping closure and views.
        /// </Summary>
        public ViewsForBaseEntitySets78E799F4E2700D6268337ABD16B399A5C6FDA687755DFA428D7B0B720013373B()
        {
            this.EdmEntityContainerName = "TrainingEntities";
            this.StoreEntityContainerName = "TrainingModelStoreContainer";
            this.HashOverMappingClosure = "6c76eacb467abdf8e30107848275777043f7ebc46f974a26df2bf151540d5ee8";
            this.HashOverAllExtentViews = "52e8a5ec06a536ea831d30cf1f36d98a7b5c53c7c2a1f0d1f87d9d93aec02a80";
            this.ViewCount = 8;
        }
        
        /// <Summary>
        /// The method returns the view for the index given.
        /// </Summary>
        protected override System.Collections.Generic.KeyValuePair<string, string> GetViewAt(int index)
        {
            if ((index == 0))
            {
                return GetView0();
            }
            if ((index == 1))
            {
                return GetView1();
            }
            if ((index == 2))
            {
                return GetView2();
            }
            if ((index == 3))
            {
                return GetView3();
            }
            if ((index == 4))
            {
                return GetView4();
            }
            if ((index == 5))
            {
                return GetView5();
            }
            if ((index == 6))
            {
                return GetView6();
            }
            if ((index == 7))
            {
                return GetView7();
            }
            throw new System.IndexOutOfRangeException();
        }
        
        /// <Summary>
        /// return view for TrainingModelStoreContainer.CUST
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView0()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("TrainingModelStoreContainer.CUST", @"
    SELECT VALUE -- Constructing CUST
        [TrainingModel.Store.CUST](T1.[CUST.CUST_ID], T1.[CUST.CUST_NO], T1.[CUST.CUST_TYPE], T1.[CUST.CUST_NAME], T1.[CUST.IDENTITY_TYPE], T1.[CUST.IDENTITY_NO], T1.[CUST.USR_CRT], T1.[CUST.DTM_CRT], T1.[CUST.USR_UPD], T1.[CUST.DTM_UPD], T1.[CUST.BIRTH_DT], T1.[CUST.BIRTH_PLACE], T1.[CUST.MARITAL_STATUS], T1.CUST_RELIGION, T1.CUST_NATIONALITY, T1.[CUST.MONTHLY_INCOME])
    FROM (
        SELECT 
            T.CustId AS [CUST.CUST_ID], 
            T.CustNo AS [CUST.CUST_NO], 
            T.CustType AS [CUST.CUST_TYPE], 
            T.CustName AS [CUST.CUST_NAME], 
            T.IdentityType AS [CUST.IDENTITY_TYPE], 
            T.IdentityNo AS [CUST.IDENTITY_NO], 
            T.LastUserTimestamp.UsrCrt AS [CUST.USR_CRT], 
            T.LastUserTimestamp.DtmCrt AS [CUST.DTM_CRT], 
            T.LastUserTimestamp.UsrUpd AS [CUST.USR_UPD], 
            T.LastUserTimestamp.DtmUpd AS [CUST.DTM_UPD], 
            T.BirthDt AS [CUST.BIRTH_DT], 
            T.BirthPlace AS [CUST.BIRTH_PLACE], 
            T.MaritalStatus AS [CUST.MARITAL_STATUS], 
            T.Religion AS CUST_RELIGION, 
            T.Nationality AS CUST_NATIONALITY, 
            T.MonthlyIncome AS [CUST.MONTHLY_INCOME], 
            True AS _from0
        FROM TrainingEntities.Custs AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for TrainingEntities.Custs
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView1()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("TrainingEntities.Custs", "\r\n    SELECT VALUE -- Constructing Custs\r\n        [TrainingModel.Cust](T2.Cust_Cu" +
                    "stId, T2.Cust_CustNo, T2.Cust_CustType, T2.Cust_CustName, T2.Cust_IdentityType, " +
                    "T2.Cust_IdentityNo, T2.Cust_BirthDt, T2.Cust_BirthPlace, T2.Cust_MaritalStatus, " +
                    "T2.Cust_Religion, T2.Cust_Nationality, T2.Cust_MonthlyIncome, T2.Cust_LastUserTi" +
                    "mestamp)\r\n    FROM (\r\n        SELECT -- Constructing LastUserTimestamp\r\n        " +
                    "    T1.Cust_CustId, \r\n            T1.Cust_CustNo, \r\n            T1.Cust_CustType" +
                    ", \r\n            T1.Cust_CustName, \r\n            T1.Cust_IdentityType, \r\n        " +
                    "    T1.Cust_IdentityNo, \r\n            T1.Cust_BirthDt, \r\n            T1.Cust_Bir" +
                    "thPlace, \r\n            T1.Cust_MaritalStatus, \r\n            T1.Cust_Religion, \r\n" +
                    "            T1.Cust_Nationality, \r\n            T1.Cust_MonthlyIncome, \r\n        " +
                    "    [TrainingModel.UserTimestamp](T1.Cust_LastUserTimestamp_UsrCrt, T1.Cust_Last" +
                    "UserTimestamp_DtmCrt, T1.Cust_LastUserTimestamp_UsrUpd, T1.Cust_LastUserTimestam" +
                    "p_DtmUpd) AS Cust_LastUserTimestamp\r\n        FROM (\r\n            SELECT \r\n      " +
                    "          T.CUST_ID AS Cust_CustId, \r\n                T.CUST_NO AS Cust_CustNo, " +
                    "\r\n                T.CUST_TYPE AS Cust_CustType, \r\n                T.CUST_NAME AS" +
                    " Cust_CustName, \r\n                T.IDENTITY_TYPE AS Cust_IdentityType, \r\n      " +
                    "          T.IDENTITY_NO AS Cust_IdentityNo, \r\n                T.BIRTH_DT AS Cust" +
                    "_BirthDt, \r\n                T.BIRTH_PLACE AS Cust_BirthPlace, \r\n                " +
                    "T.MARITAL_STATUS AS Cust_MaritalStatus, \r\n                T.RELIGION AS Cust_Rel" +
                    "igion, \r\n                T.NATIONALITY AS Cust_Nationality, \r\n                T." +
                    "MONTHLY_INCOME AS Cust_MonthlyIncome, \r\n                T.USR_CRT AS Cust_LastUs" +
                    "erTimestamp_UsrCrt, \r\n                T.DTM_CRT AS Cust_LastUserTimestamp_DtmCrt" +
                    ", \r\n                T.USR_UPD AS Cust_LastUserTimestamp_UsrUpd, \r\n              " +
                    "  T.DTM_UPD AS Cust_LastUserTimestamp_DtmUpd, \r\n                True AS _from0\r\n" +
                    "            FROM TrainingModelStoreContainer.CUST AS T\r\n        ) AS T1\r\n    ) A" +
                    "S T2");
        }
        
        /// <Summary>
        /// return view for TrainingModelStoreContainer.REF_MASTER
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView2()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("TrainingModelStoreContainer.REF_MASTER", @"
    SELECT VALUE -- Constructing REF_MASTER
        [TrainingModel.Store.REF_MASTER](T1.[REF_MASTER.REF_MASTER_ID], T1.[REF_MASTER.MASTER_CODE], T1.[REF_MASTER.DESCRIPTION], T1.[REF_MASTER.MASTER_TYPE], T1.[REF_MASTER.USR_CRT], T1.[REF_MASTER.DTM_CRT], T1.[REF_MASTER.USR_UPD], T1.[REF_MASTER.DTM_UPD])
    FROM (
        SELECT 
            T.RefMasterId AS [REF_MASTER.REF_MASTER_ID], 
            T.MasterCode AS [REF_MASTER.MASTER_CODE], 
            T.Description AS [REF_MASTER.DESCRIPTION], 
            T.MasterType AS [REF_MASTER.MASTER_TYPE], 
            T.LastUserTimestamp.UsrCrt AS [REF_MASTER.USR_CRT], 
            T.LastUserTimestamp.DtmCrt AS [REF_MASTER.DTM_CRT], 
            T.LastUserTimestamp.UsrUpd AS [REF_MASTER.USR_UPD], 
            T.LastUserTimestamp.DtmUpd AS [REF_MASTER.DTM_UPD], 
            True AS _from0
        FROM TrainingEntities.RefMasters AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for TrainingEntities.RefMasters
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView3()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("TrainingEntities.RefMasters", @"
    SELECT VALUE -- Constructing RefMasters
        [TrainingModel.RefMaster](T2.RefMaster_RefMasterId, T2.RefMaster_MasterCode, T2.RefMaster_Description, T2.RefMaster_MasterType, T2.RefMaster_LastUserTimestamp)
    FROM (
        SELECT -- Constructing LastUserTimestamp
            T1.RefMaster_RefMasterId, 
            T1.RefMaster_MasterCode, 
            T1.RefMaster_Description, 
            T1.RefMaster_MasterType, 
            [TrainingModel.UserTimestamp](T1.RefMaster_LastUserTimestamp_UsrCrt, T1.RefMaster_LastUserTimestamp_DtmCrt, T1.RefMaster_LastUserTimestamp_UsrUpd, T1.RefMaster_LastUserTimestamp_DtmUpd) AS RefMaster_LastUserTimestamp
        FROM (
            SELECT 
                T.REF_MASTER_ID AS RefMaster_RefMasterId, 
                T.MASTER_CODE AS RefMaster_MasterCode, 
                T.DESCRIPTION AS RefMaster_Description, 
                T.MASTER_TYPE AS RefMaster_MasterType, 
                T.USR_CRT AS RefMaster_LastUserTimestamp_UsrCrt, 
                T.DTM_CRT AS RefMaster_LastUserTimestamp_DtmCrt, 
                T.USR_UPD AS RefMaster_LastUserTimestamp_UsrUpd, 
                T.DTM_UPD AS RefMaster_LastUserTimestamp_DtmUpd, 
                True AS _from0
            FROM TrainingModelStoreContainer.REF_MASTER AS T
        ) AS T1
    ) AS T2");
        }
        
        /// <Summary>
        /// return view for TrainingModelStoreContainer.CUSTOMER_HANDLING
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView4()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("TrainingModelStoreContainer.CUSTOMER_HANDLING", "\r\n    SELECT VALUE -- Constructing CUSTOMER_HANDLING\r\n        [TrainingModel.Stor" +
                    "e.CUSTOMER_HANDLING](T1.[CUSTOMER_HANDLING.CUSTOMER_HANDLING_ID], T1.[CUSTOMER_H" +
                    "ANDLING.REGISTRATION_NO], T1.[CUSTOMER_HANDLING.CUSTOMER_NAME], T1.[CUSTOMER_HAN" +
                    "DLING.MOBILE_PHONE_NO], T1.[CUSTOMER_HANDLING.EMAIL], T1.[CUSTOMER_HANDLING.SERV" +
                    "ICE_CATEGORY], T1.[CUSTOMER_HANDLING.MEDIA_OF_SERVICE], T1.[CUSTOMER_HANDLING.CH" +
                    "RONOLOGIC], T1.[CUSTOMER_HANDLING.SERVICE_STATUS], T1.[CUSTOMER_HANDLING.ADMIN_F" +
                    "EE], T1.[CUSTOMER_HANDLING.COMPLETION_DT], T1.[CUSTOMER_HANDLING.USR_CRT], T1.[C" +
                    "USTOMER_HANDLING.DTM_CRT], T1.[CUSTOMER_HANDLING.USR_UPD], T1.[CUSTOMER_HANDLING" +
                    ".DTM_UPD])\r\n    FROM (\r\n        SELECT \r\n            T.CustomerHandlingId AS [CU" +
                    "STOMER_HANDLING.CUSTOMER_HANDLING_ID], \r\n            T.RegistrationNo AS [CUSTOM" +
                    "ER_HANDLING.REGISTRATION_NO], \r\n            T.CustomerName AS [CUSTOMER_HANDLING" +
                    ".CUSTOMER_NAME], \r\n            T.MobilePhoneNo AS [CUSTOMER_HANDLING.MOBILE_PHON" +
                    "E_NO], \r\n            T.Email AS [CUSTOMER_HANDLING.EMAIL], \r\n            T.Servi" +
                    "ceCategory AS [CUSTOMER_HANDLING.SERVICE_CATEGORY], \r\n            T.MediaOfServi" +
                    "ce AS [CUSTOMER_HANDLING.MEDIA_OF_SERVICE], \r\n            T.Chronologic AS [CUST" +
                    "OMER_HANDLING.CHRONOLOGIC], \r\n            T.ServiceStatus AS [CUSTOMER_HANDLING." +
                    "SERVICE_STATUS], \r\n            T.AdminFee AS [CUSTOMER_HANDLING.ADMIN_FEE], \r\n  " +
                    "          T.CompletionDt AS [CUSTOMER_HANDLING.COMPLETION_DT], \r\n            T.L" +
                    "astUserTimestamp.UsrCrt AS [CUSTOMER_HANDLING.USR_CRT], \r\n            T.LastUser" +
                    "Timestamp.DtmCrt AS [CUSTOMER_HANDLING.DTM_CRT], \r\n            T.LastUserTimesta" +
                    "mp.UsrUpd AS [CUSTOMER_HANDLING.USR_UPD], \r\n            T.LastUserTimestamp.DtmU" +
                    "pd AS [CUSTOMER_HANDLING.DTM_UPD], \r\n            True AS _from0\r\n        FROM Tr" +
                    "ainingEntities.CustomerHandlings AS T\r\n    ) AS T1");
        }
        
        /// <Summary>
        /// return view for TrainingEntities.CustomerHandlings
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView5()
        {
            System.Text.StringBuilder viewString = new System.Text.StringBuilder(2587);
            viewString.Append("\r\n    SELECT VALUE -- Constructing CustomerHandlings\r\n        [TrainingModel.Cus");
            viewString.Append("tomerHandling](T2.CustomerHandling_CustomerHandlingId, T2.CustomerHandling_Regis");
            viewString.Append("trationNo, T2.CustomerHandling_CustomerName, T2.CustomerHandling_MobilePhoneNo, ");
            viewString.Append("T2.CustomerHandling_Email, T2.CustomerHandling_ServiceCategory, T2.CustomerHandl");
            viewString.Append("ing_MediaOfService, T2.CustomerHandling_Chronologic, T2.CustomerHandling_Service");
            viewString.Append("Status, T2.CustomerHandling_AdminFee, T2.CustomerHandling_CompletionDt, T2.Custo");
            viewString.Append("merHandling_LastUserTimestamp)\r\n    FROM (\r\n        SELECT -- Constructing LastU");
            viewString.Append("serTimestamp\r\n            T1.CustomerHandling_CustomerHandlingId, \r\n            ");
            viewString.Append("T1.CustomerHandling_RegistrationNo, \r\n            T1.CustomerHandling_CustomerNa");
            viewString.Append("me, \r\n            T1.CustomerHandling_MobilePhoneNo, \r\n            T1.CustomerHa");
            viewString.Append("ndling_Email, \r\n            T1.CustomerHandling_ServiceCategory, \r\n            T");
            viewString.Append("1.CustomerHandling_MediaOfService, \r\n            T1.CustomerHandling_Chronologic");
            viewString.Append(", \r\n            T1.CustomerHandling_ServiceStatus, \r\n            T1.CustomerHand");
            viewString.Append("ling_AdminFee, \r\n            T1.CustomerHandling_CompletionDt, \r\n            [Tr");
            viewString.Append("ainingModel.UserTimestamp](T1.CustomerHandling_LastUserTimestamp_UsrCrt, T1.Cust");
            viewString.Append("omerHandling_LastUserTimestamp_DtmCrt, T1.CustomerHandling_LastUserTimestamp_Usr");
            viewString.Append("Upd, T1.CustomerHandling_LastUserTimestamp_DtmUpd) AS CustomerHandling_LastUserT");
            viewString.Append("imestamp\r\n        FROM (\r\n            SELECT \r\n                T.CUSTOMER_HANDLI");
            viewString.Append("NG_ID AS CustomerHandling_CustomerHandlingId, \r\n                T.REGISTRATION_N");
            viewString.Append("O AS CustomerHandling_RegistrationNo, \r\n                T.CUSTOMER_NAME AS Custo");
            viewString.Append("merHandling_CustomerName, \r\n                T.MOBILE_PHONE_NO AS CustomerHandlin");
            viewString.Append("g_MobilePhoneNo, \r\n                T.EMAIL AS CustomerHandling_Email, \r\n        ");
            viewString.Append("        T.SERVICE_CATEGORY AS CustomerHandling_ServiceCategory, \r\n              ");
            viewString.Append("  T.MEDIA_OF_SERVICE AS CustomerHandling_MediaOfService, \r\n                T.CHR");
            viewString.Append("ONOLOGIC AS CustomerHandling_Chronologic, \r\n                T.SERVICE_STATUS AS ");
            viewString.Append("CustomerHandling_ServiceStatus, \r\n                T.ADMIN_FEE AS CustomerHandlin");
            viewString.Append("g_AdminFee, \r\n                T.COMPLETION_DT AS CustomerHandling_CompletionDt, ");
            viewString.Append("\r\n                T.USR_CRT AS CustomerHandling_LastUserTimestamp_UsrCrt, \r\n    ");
            viewString.Append("            T.DTM_CRT AS CustomerHandling_LastUserTimestamp_DtmCrt, \r\n          ");
            viewString.Append("      T.USR_UPD AS CustomerHandling_LastUserTimestamp_UsrUpd, \r\n                ");
            viewString.Append("T.DTM_UPD AS CustomerHandling_LastUserTimestamp_DtmUpd, \r\n                True A");
            viewString.Append("S _from0\r\n            FROM TrainingModelStoreContainer.CUSTOMER_HANDLING AS T\r\n ");
            viewString.Append("       ) AS T1\r\n    ) AS T2");
            return new System.Collections.Generic.KeyValuePair<string, string>("TrainingEntities.CustomerHandlings", viewString.ToString());
        }
        
        /// <Summary>
        /// return view for TrainingModelStoreContainer.SUPPL
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView6()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("TrainingModelStoreContainer.SUPPL", @"
    SELECT VALUE -- Constructing SUPPL
        [TrainingModel.Store.SUPPL](T1.[SUPPL.SUPPL_ID], T1.[SUPPL.SUPPL_NO], T1.[SUPPL.SUPPL_NAME], T1.[SUPPL.SUPPL_ADDRESS], T1.[SUPPL.SUPPL_RT], T1.[SUPPL.SUPPL_RW], T1.[SUPPL.SUPPL_KELURAHAN], T1.[SUPPL.SUPPL_KECAMATAN], T1.[SUPPL.SUPPL_CITY], T1.[SUPPL.SUPPL_ZIPCODE], T1.[SUPPL.USR_CRT], T1.[SUPPL.DTM_CRT], T1.[SUPPL.USR_UPD], T1.[SUPPL.DTM_UPD], T1.SUPPL_PRODUCE)
    FROM (
        SELECT 
            T.SupplId AS [SUPPL.SUPPL_ID], 
            T.SupplNo AS [SUPPL.SUPPL_NO], 
            T.SupplName AS [SUPPL.SUPPL_NAME], 
            T.SupplAddress AS [SUPPL.SUPPL_ADDRESS], 
            T.SupplRt AS [SUPPL.SUPPL_RT], 
            T.SupplRw AS [SUPPL.SUPPL_RW], 
            T.SupplKelurahan AS [SUPPL.SUPPL_KELURAHAN], 
            T.SupplKecamatan AS [SUPPL.SUPPL_KECAMATAN], 
            T.SupplCity AS [SUPPL.SUPPL_CITY], 
            T.SupplZipcode AS [SUPPL.SUPPL_ZIPCODE], 
            T.LastUserTimestamp.UsrCrt AS [SUPPL.USR_CRT], 
            T.LastUserTimestamp.DtmCrt AS [SUPPL.DTM_CRT], 
            T.LastUserTimestamp.UsrUpd AS [SUPPL.USR_UPD], 
            T.LastUserTimestamp.DtmUpd AS [SUPPL.DTM_UPD], 
            T.Produce AS SUPPL_PRODUCE, 
            True AS _from0
        FROM TrainingEntities.Suppls AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for TrainingEntities.Suppls
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView7()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("TrainingEntities.Suppls", "\r\n    SELECT VALUE -- Constructing Suppls\r\n        [TrainingModel.Suppl](T2.Suppl" +
                    "_SupplId, T2.Suppl_SupplNo, T2.Suppl_SupplName, T2.Suppl_SupplAddress, T2.Suppl_" +
                    "SupplRt, T2.Suppl_SupplRw, T2.Suppl_SupplKelurahan, T2.Suppl_SupplKecamatan, T2." +
                    "Suppl_SupplCity, T2.Suppl_SupplZipcode, T2.Suppl_Produce, T2.Suppl_LastUserTimes" +
                    "tamp)\r\n    FROM (\r\n        SELECT -- Constructing LastUserTimestamp\r\n           " +
                    " T1.Suppl_SupplId, \r\n            T1.Suppl_SupplNo, \r\n            T1.Suppl_SupplN" +
                    "ame, \r\n            T1.Suppl_SupplAddress, \r\n            T1.Suppl_SupplRt, \r\n    " +
                    "        T1.Suppl_SupplRw, \r\n            T1.Suppl_SupplKelurahan, \r\n            T" +
                    "1.Suppl_SupplKecamatan, \r\n            T1.Suppl_SupplCity, \r\n            T1.Suppl" +
                    "_SupplZipcode, \r\n            T1.Suppl_Produce, \r\n            [TrainingModel.User" +
                    "Timestamp](T1.Suppl_LastUserTimestamp_UsrCrt, T1.Suppl_LastUserTimestamp_DtmCrt," +
                    " T1.Suppl_LastUserTimestamp_UsrUpd, T1.Suppl_LastUserTimestamp_DtmUpd) AS Suppl_" +
                    "LastUserTimestamp\r\n        FROM (\r\n            SELECT \r\n                T.SUPPL_" +
                    "ID AS Suppl_SupplId, \r\n                T.SUPPL_NO AS Suppl_SupplNo, \r\n          " +
                    "      T.SUPPL_NAME AS Suppl_SupplName, \r\n                T.SUPPL_ADDRESS AS Supp" +
                    "l_SupplAddress, \r\n                T.SUPPL_RT AS Suppl_SupplRt, \r\n               " +
                    " T.SUPPL_RW AS Suppl_SupplRw, \r\n                T.SUPPL_KELURAHAN AS Suppl_Suppl" +
                    "Kelurahan, \r\n                T.SUPPL_KECAMATAN AS Suppl_SupplKecamatan, \r\n      " +
                    "          T.SUPPL_CITY AS Suppl_SupplCity, \r\n                T.SUPPL_ZIPCODE AS " +
                    "Suppl_SupplZipcode, \r\n                T.PRODUCE AS Suppl_Produce, \r\n            " +
                    "    T.USR_CRT AS Suppl_LastUserTimestamp_UsrCrt, \r\n                T.DTM_CRT AS " +
                    "Suppl_LastUserTimestamp_DtmCrt, \r\n                T.USR_UPD AS Suppl_LastUserTim" +
                    "estamp_UsrUpd, \r\n                T.DTM_UPD AS Suppl_LastUserTimestamp_DtmUpd, \r\n" +
                    "                True AS _from0\r\n            FROM TrainingModelStoreContainer.SUP" +
                    "PL AS T\r\n        ) AS T1\r\n    ) AS T2");
        }
    }
}
