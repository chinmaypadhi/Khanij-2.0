// ***********************************************************************
//  Class Name               : DivisionProvider
//  Description              : Add,View,Edit,Update,Delete Division details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
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

namespace MasterApi.Model.Division
{
    public class DivisionProvider : RepositoryBase,IDivisionProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="divisionProvider"></param>
        public DivisionProvider(IConnectionFactory connectionFactory):base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        #region Add
        public MessageEF AddDivision(RegionalModel regionalModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 1);
                p.Add("@RegionalName", regionalModel.RegionalName);
                p.Add("@StateID", regionalModel.StateID == null ? 26 : regionalModel.StateID);
                p.Add("@RegionalID", 0);
                p.Add("@userId", regionalModel.CreatedBy);
                p.Add("@UserLoginID", regionalModel.CreatedBy);
                p.Add("@IsActive", regionalModel.IsActive == null ? true : regionalModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspDivisionMasterOperation", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");



                string response = newID.ToString();
                if (response == "1")
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
        #endregion
        /// <summary>
        /// Delete Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        #region Delete
        public MessageEF DeleteDivision(RegionalModel regionalModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "@RegionalID",regionalModel.RegionalID,
                        "@operation",3,
                        "@userId",regionalModel.CreatedBy,
                        "@UserLoginID",regionalModel.CreatedBy
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("uspDivisionMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("result");
                if (response == "1")
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
        #endregion
        /// <summary>
        /// edit Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        #region Edit
        public RegionalModel EditDivision(RegionalModel regionalModel)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@RegionalID", regionalModel.RegionalID);

                var result = Connection.Query<RegionalModel>("uspDivisionMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    regionalModel = result.FirstOrDefault();
                }

                return regionalModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                regionalModel = null;
            }
        }
        #endregion
        /// <summary>
        /// Update Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        #region Update
        public MessageEF UpdateDivision(RegionalModel regionalModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 2);
                p.Add("@RegionalName", regionalModel.RegionalName);
                p.Add("@StateID", regionalModel.StateID==null?26: regionalModel.StateID);
                p.Add("@RegionalID", regionalModel.RegionalID);
                p.Add("@userId", regionalModel.CreatedBy);
                p.Add("@UserLoginID", regionalModel.CreatedBy);
                p.Add("@IsActive", regionalModel.IsActive == null ? true : regionalModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspDivisionMasterOperation", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");



                string response = newID.ToString();
                if (response == "1")
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
        #endregion
        /// <summary>
        /// View Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        #region View
        public List<RegionalModel> ViewDivision(RegionalModel regionalModel)
        {
            List<RegionalModel> listRegionalModel = new List<RegionalModel>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", regionalModel.CHK);
                param.Add("@StateID", regionalModel.StateID);
                var result = Connection.Query<RegionalModel>("uspDivisionMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listRegionalModel = result.ToList();
                }

                return listRegionalModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listRegionalModel = null;
            }
        }
        #endregion
    }
}
