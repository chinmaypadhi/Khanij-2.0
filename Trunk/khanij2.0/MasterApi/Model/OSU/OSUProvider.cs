// ***********************************************************************
//  Class Name               : OSUProvider
//  Description              : Add,View,Edit,Update,Delete OSU details
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Jan 2021
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.OSU
{
    public class OSUProvider: RepositoryBase, IOSUProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public OSUProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add OSU details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        public MessageEF AddOSUmaster(OSUmaster objOSUmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("ApplicantName", objOSUmaster.ApplicantName);
                p.Add("UserTypeId", objOSUmaster.UserTypeId);
                p.Add("DistrictId", objOSUmaster.DistrictID);
                p.Add("CompanyId", objOSUmaster.CompanyId);
                p.Add("Email", objOSUmaster.EmailID);
                p.Add("MobileNo", objOSUmaster.MobileNumber);
                p.Add("Address", objOSUmaster.Address);
                p.Add("MineStatusId", objOSUmaster.ID);
                if (objOSUmaster.LesseeTypeID != null)
                {                   
                    p.Add("LeaseTypeId", objOSUmaster.LesseeTypeID);
                }
                else if (objOSUmaster.LicenseeTypeID != null)
                {  
                    p.Add("LeaseTypeId", objOSUmaster.LicenseeTypeID);
                }
                p.Add("UserId", objOSUmaster.UserId);
                p.Add("UserLoginId", objOSUmaster.UserLoginId);
                var result= Connection.Query<MessageEF>("uspInsertOsuUserCreation", p, commandType: CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objMessage = result.FirstOrDefault();
                }
                return objMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }
        /// <summary>
        /// Bind District List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        public List<OSUmaster> GetDistrictList(OSUmaster objOSUmaster)
        {
            List<OSUmaster> ObjDistrictList = new List<OSUmaster>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<OSUmaster>("Usp_GetDistrict", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjDistrictList = result.ToList();
                }
                return ObjDistrictList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind User Type List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        public List<OSUmaster> GetUserTypeList(OSUmaster objOSUmaster)
        {
            List<OSUmaster> ObjUserTypeList = new List<OSUmaster>();

            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<OSUmaster>("uspGetLesseeLicenseeType", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjUserTypeList = result.ToList();
                }

                return ObjUserTypeList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Company Type List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        public List<OSUmaster> GetCompanyList(OSUmaster objOSUmaster)
        {
            List<OSUmaster> ObjCompanyList = new List<OSUmaster>();

            try
            {
                var paramList = new
                {
                    
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<OSUmaster>("uspGetCompanyName", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjCompanyList = result.ToList();
                }

                return ObjCompanyList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Lessee Type List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        public List<OSUmaster> GetChangeStatusList(OSUmaster objOSUmaster)
        {
            List<OSUmaster> ObjChangeStatusList = new List<OSUmaster>();
            try
            {
                var paramList = new
                {
                    UserType = objOSUmaster.UserType
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<OSUmaster>("uspGetStatus", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjChangeStatusList = result.ToList();
                }

                return ObjChangeStatusList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Licensee Type List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        public List<OSUmaster> GetLesseeTypeList(OSUmaster objOSUmaster)
        {
            List<OSUmaster> ObjLesseeTypeList = new List<OSUmaster>();

            try
            {
                var paramList = new
                {
                    Check="0"
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<OSUmaster>("GetLesseeLicenseeTypeMasters", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjLesseeTypeList = result.ToList();
                }

                return ObjLesseeTypeList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Get Change Status List Details in view
        /// </summary>
        /// <param name="objOSUmaster"></param>
        /// <returns></returns>
        public List<OSUmaster> GetLicenseeTypeList(OSUmaster objOSUmaster)
        {
            List<OSUmaster> ObjLicenseeTypeList = new List<OSUmaster>();

            try
            {
                var paramList = new
                {
                    Check = "1"
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<OSUmaster>("GetLesseeLicenseeTypeMasters", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjLicenseeTypeList = result.ToList();
                }

                return ObjLicenseeTypeList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Update Encrypt Password
        /// </summary>
        /// <param name="updateEncryptPasswordModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserName", updateEncryptPasswordModel.UserName.Trim());
                param.Add("@EncryptPassword", updateEncryptPasswordModel.EncryptPassword.Trim());
                param.Add("@Check", 1);
                var result = await Connection.ExecuteScalarAsync("uspUpdateEncryptPassword", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = result.ToString();
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
