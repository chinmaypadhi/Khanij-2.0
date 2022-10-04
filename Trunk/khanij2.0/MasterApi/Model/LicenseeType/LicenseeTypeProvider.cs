// ***********************************************************************
//  Controller Name          : LicenseeTypeController
//  Description              : Add,View,Edit,Update,Delete Licensee Type details
//  Created By               : Sanjay Kumar
//  Created On               : 08 Jan 2021
// ***********************************************************************
using Dapper;

using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.LicenseeType
{
    public class LicenseeTypeProvider: RepositoryBase, ILicenseeTypeProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LicenseeTypeProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        public MessageEF AddLicenseeType(LicenseeTypeMaster objLicenseeType)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("LicenseeTypeName", objLicenseeType.LicenseeTypeName);
                p.Add("CreatedBy", objLicenseeType.CreatedBy);
                p.Add("IsActive", objLicenseeType.IsActive);
                p.Add("UserLoginId", objLicenseeType.UserLoginId);
                p.Add("Chk", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEETYPE_MASTER", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// View Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        public List<LicenseeTypeMaster> ViewLicenseeType(LicenseeTypeMaster objLicenseeType)
        {
            List<LicenseeTypeMaster> ListLicenseeType = new List<LicenseeTypeMaster>();
            try
            {
                var paramList = new
                {
                    LicenseeTypeName = objLicenseeType.LicenseeTypeName,
                    Chk = "5",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<LicenseeTypeMaster>("USP_LICENSEETYPE_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListLicenseeType = result.ToList();
                }

                return ListLicenseeType;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListLicenseeType = null;
            }



        }
        /// <summary>
        /// Edit Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        public LicenseeTypeMaster EditLicenseeType(LicenseeTypeMaster objLicenseeType)
        {
            LicenseeTypeMaster LobjLicenseeType = new LicenseeTypeMaster();
            try
            {
                var paramList = new
                {
                    LicenseeTypeId = objLicenseeType.LicenseeTypeId,
                    Chk = "2",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<LicenseeTypeMaster>("USP_LICENSEETYPE_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjLicenseeType = result.FirstOrDefault();
                }

                return LobjLicenseeType;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjLicenseeType = null;
            }
        }
        /// <summary>
        /// Update Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        public MessageEF UpdateLicenseeType(LicenseeTypeMaster objLicenseeType)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("LicenseeTypeName", objLicenseeType.LicenseeTypeName);
                p.Add("LicenseeTypeId", objLicenseeType.LicenseeTypeId);
                p.Add("CreatedBy", objLicenseeType.CreatedBy);
                p.Add("IsActive", objLicenseeType.IsActive);
                p.Add("UserLoginId", objLicenseeType.UserLoginId);
                p.Add("Chk", 3);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEETYPE_MASTER", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");


                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Delete Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        public MessageEF DeleteLicenseeType(LicenseeTypeMaster objLicenseeType)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("LicenseeTypeId", objLicenseeType.LicenseeTypeId);
                p.Add("CreatedBy", objLicenseeType.CreatedBy);
                p.Add("UserLoginId", objLicenseeType.UserLoginId);
                p.Add("Chk", 4);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LICENSEETYPE_MASTER", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");

                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;

        }
    }
}
