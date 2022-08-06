//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Data.Mapping.EntityViewGenerationAttribute(typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySetsC13C258206CD7E8A5EDCC7F20267AC8A64E84B7BDA2F46EAA6540AE6A495296C))]

namespace Edm_EntityMappingGeneratedViews
{
    
    
    /// <Summary>
    /// The type contains views for EntitySets and AssociationSets that were generated at design time.
    /// </Summary>
    public sealed class ViewsForBaseEntitySetsC13C258206CD7E8A5EDCC7F20267AC8A64E84B7BDA2F46EAA6540AE6A495296C : System.Data.Mapping.EntityViewContainer
    {
        
        /// <Summary>
        /// The constructor stores the views for the extents and also the hash values generated based on the metadata and mapping closure and views.
        /// </Summary>
        public ViewsForBaseEntitySetsC13C258206CD7E8A5EDCC7F20267AC8A64E84B7BDA2F46EAA6540AE6A495296C()
        {
            this.EdmEntityContainerName = "TrainingEntities";
            this.StoreEntityContainerName = "TrainingModelStoreContainer";
            this.HashOverMappingClosure = "42094d5b2a1f2c7fc7354938738ad2c113b8ca1229452ab97b6c6c1d8b9e674f";
            this.HashOverAllExtentViews = "76b2dc6cc5a7b022b8eff7240dca4df8b250db37b0ad56f52d70d0646204c73f";
            this.ViewCount = 4;
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
            throw new System.IndexOutOfRangeException();
        }
        
        /// <Summary>
        /// return view for TrainingModelStoreContainer.CUST
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView0()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("TrainingModelStoreContainer.CUST", @"
    SELECT VALUE -- Constructing CUST
        [TrainingModel.Store.CUST](T1.[CUST.CUST_ID], T1.[CUST.CUST_NO], T1.[CUST.CUST_TYPE], T1.[CUST.CUST_NAME], T1.[CUST.IDENTITY_TYPE], T1.[CUST.IDENTITY_NO], T1.[CUST.USR_CRT], T1.[CUST.DTM_CRT], T1.[CUST.USR_UPD], T1.[CUST.DTM_UPD])
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
            True AS _from0
        FROM TrainingEntities.Custs AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for TrainingModelStoreContainer.CUST_ADDR
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView1()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("TrainingModelStoreContainer.CUST_ADDR", @"
    SELECT VALUE -- Constructing CUST_ADDR
        [TrainingModel.Store.CUST_ADDR](T1.[CUST_ADDR.CUST_ADDR_ID], T1.[CUST_ADDR.CUST_ID], T1.[CUST_ADDR.ADDRESS], T1.[CUST_ADDR.ADDRESS_TYPE], T1.[CUST_ADDR.RT], T1.[CUST_ADDR.RW], T1.[CUST_ADDR.KELURAHAN], T1.[CUST_ADDR.KECAMATAN], T1.[CUST_ADDR.CITY], T1.[CUST_ADDR.ZIPCODE], T1.[CUST_ADDR.USR_CRT], T1.[CUST_ADDR.DTM_CRT], T1.[CUST_ADDR.USR_UPD], T1.[CUST_ADDR.DTM_UPD])
    FROM (
        SELECT 
            T.CustAddrId AS [CUST_ADDR.CUST_ADDR_ID], 
            T.CustId AS [CUST_ADDR.CUST_ID], 
            T.Address AS [CUST_ADDR.ADDRESS], 
            T.AddressType AS [CUST_ADDR.ADDRESS_TYPE], 
            T.Rt AS [CUST_ADDR.RT], 
            T.Rw AS [CUST_ADDR.RW], 
            T.Kelurahan AS [CUST_ADDR.KELURAHAN], 
            T.Kecamatan AS [CUST_ADDR.KECAMATAN], 
            T.City AS [CUST_ADDR.CITY], 
            T.Zipcode AS [CUST_ADDR.ZIPCODE], 
            T.LastUserTimestamp.UsrCrt AS [CUST_ADDR.USR_CRT], 
            T.LastUserTimestamp.DtmCrt AS [CUST_ADDR.DTM_CRT], 
            T.LastUserTimestamp.UsrUpd AS [CUST_ADDR.USR_UPD], 
            T.LastUserTimestamp.DtmUpd AS [CUST_ADDR.DTM_UPD], 
            True AS _from0
        FROM TrainingEntities.CustAddrs AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for TrainingEntities.Custs
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView2()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("TrainingEntities.Custs", @"
    SELECT VALUE -- Constructing Custs
        [TrainingModel.Cust](T2.Cust_CustId, T2.Cust_CustNo, T2.Cust_CustType, T2.Cust_CustName, T2.Cust_IdentityType, T2.Cust_IdentityNo, T2.Cust_LastUserTimestamp)
    FROM (
        SELECT -- Constructing LastUserTimestamp
            T1.Cust_CustId, 
            T1.Cust_CustNo, 
            T1.Cust_CustType, 
            T1.Cust_CustName, 
            T1.Cust_IdentityType, 
            T1.Cust_IdentityNo, 
            [TrainingModel.UserTimestamp](T1.Cust_LastUserTimestamp_UsrCrt, T1.Cust_LastUserTimestamp_DtmCrt, T1.Cust_LastUserTimestamp_UsrUpd, T1.Cust_LastUserTimestamp_DtmUpd) AS Cust_LastUserTimestamp
        FROM (
            SELECT 
                T.CUST_ID AS Cust_CustId, 
                T.CUST_NO AS Cust_CustNo, 
                T.CUST_TYPE AS Cust_CustType, 
                T.CUST_NAME AS Cust_CustName, 
                T.IDENTITY_TYPE AS Cust_IdentityType, 
                T.IDENTITY_NO AS Cust_IdentityNo, 
                T.USR_CRT AS Cust_LastUserTimestamp_UsrCrt, 
                T.DTM_CRT AS Cust_LastUserTimestamp_DtmCrt, 
                T.USR_UPD AS Cust_LastUserTimestamp_UsrUpd, 
                T.DTM_UPD AS Cust_LastUserTimestamp_DtmUpd, 
                True AS _from0
            FROM TrainingModelStoreContainer.CUST AS T
        ) AS T1
    ) AS T2");
        }
        
        /// <Summary>
        /// return view for TrainingEntities.CustAddrs
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView3()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("TrainingEntities.CustAddrs", "\r\n    SELECT VALUE -- Constructing CustAddrs\r\n        [TrainingModel.CustAddr](T2" +
                    ".CustAddr_CustAddrId, T2.CustAddr_CustId, T2.CustAddr_Address, T2.CustAddr_Addre" +
                    "ssType, T2.CustAddr_Rt, T2.CustAddr_Rw, T2.CustAddr_Kelurahan, T2.CustAddr_Kecam" +
                    "atan, T2.CustAddr_City, T2.CustAddr_Zipcode, T2.CustAddr_LastUserTimestamp)\r\n   " +
                    " FROM (\r\n        SELECT -- Constructing LastUserTimestamp\r\n            T1.CustAd" +
                    "dr_CustAddrId, \r\n            T1.CustAddr_CustId, \r\n            T1.CustAddr_Addre" +
                    "ss, \r\n            T1.CustAddr_AddressType, \r\n            T1.CustAddr_Rt, \r\n     " +
                    "       T1.CustAddr_Rw, \r\n            T1.CustAddr_Kelurahan, \r\n            T1.Cus" +
                    "tAddr_Kecamatan, \r\n            T1.CustAddr_City, \r\n            T1.CustAddr_Zipco" +
                    "de, \r\n            [TrainingModel.UserTimestamp](T1.CustAddr_LastUserTimestamp_Us" +
                    "rCrt, T1.CustAddr_LastUserTimestamp_DtmCrt, T1.CustAddr_LastUserTimestamp_UsrUpd" +
                    ", T1.CustAddr_LastUserTimestamp_DtmUpd) AS CustAddr_LastUserTimestamp\r\n        F" +
                    "ROM (\r\n            SELECT \r\n                T.CUST_ADDR_ID AS CustAddr_CustAddrI" +
                    "d, \r\n                T.CUST_ID AS CustAddr_CustId, \r\n                T.ADDRESS A" +
                    "S CustAddr_Address, \r\n                T.ADDRESS_TYPE AS CustAddr_AddressType, \r\n" +
                    "                T.RT AS CustAddr_Rt, \r\n                T.RW AS CustAddr_Rw, \r\n  " +
                    "              T.KELURAHAN AS CustAddr_Kelurahan, \r\n                T.KECAMATAN A" +
                    "S CustAddr_Kecamatan, \r\n                T.CITY AS CustAddr_City, \r\n             " +
                    "   T.ZIPCODE AS CustAddr_Zipcode, \r\n                T.USR_CRT AS CustAddr_LastUs" +
                    "erTimestamp_UsrCrt, \r\n                T.DTM_CRT AS CustAddr_LastUserTimestamp_Dt" +
                    "mCrt, \r\n                T.USR_UPD AS CustAddr_LastUserTimestamp_UsrUpd, \r\n      " +
                    "          T.DTM_UPD AS CustAddr_LastUserTimestamp_DtmUpd, \r\n                True" +
                    " AS _from0\r\n            FROM TrainingModelStoreContainer.CUST_ADDR AS T\r\n       " +
                    " ) AS T1\r\n    ) AS T2");
        }
    }
}