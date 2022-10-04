// ***********************************************************************
//  Class Name               : CheckPostProvider
//  Description              : Add,View,Edit,Update,Delete Checkpost details
//  Created By               : Lingaraj Dalai
//  Created On               : 20 Jan 2021
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace MasterApi.Model.Checkpost
{
    public class CheckPostProvider:RepositoryBase,ICheckPostProvider
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public CheckPostProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        public MessageEF AddCheckPostmaster(Checkpostmaster objCheckPostmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CheckpostName", objCheckPostmaster.CheckPostName);
                p.Add("DistrictID", objCheckPostmaster.DistrictID);
                p.Add("UserID", objCheckPostmaster.UserID);
                p.Add("IsActive", objCheckPostmaster.IsActive);
                p.Add("CreatedBy", objCheckPostmaster.CreatedBy);
                p.Add("UserLoginID", objCheckPostmaster.CreatedBy);
                p.Add("Check", "1");
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("UspForCheckPostmaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response == "2")
                {
                    objMessage.Satus = "3";

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
        /// Edit Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        public List<Checkpostmaster> ViewCheckPostmaster(Checkpostmaster objCheckPostmaster)
        {
            List<Checkpostmaster> ListCheckPostmaster = new List<Checkpostmaster>();
            try
            {
                var paramList = new
                {
                    C_Id = objCheckPostmaster.CheckPostId,
                    Check = "2",
                };
                var result = Connection.Query<Checkpostmaster>("UspForCheckPostmaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListCheckPostmaster = result.ToList();
                }

                return ListCheckPostmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListCheckPostmaster = null;
            }



        }
        /// <summary>
        /// View Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        public Checkpostmaster EditCheckPostmaster(Checkpostmaster objCheckPostmaster)
        {
            Checkpostmaster LobjCheckPostmaster = new Checkpostmaster();
            try
            {
                var paramList = new
                {
                    C_Id = objCheckPostmaster.CheckPostId,
                    Check = "2",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<Checkpostmaster>("UspForCheckPostmaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjCheckPostmaster = result.FirstOrDefault();
                }

                return LobjCheckPostmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjCheckPostmaster = null;
            }
        }
        /// <summary>
        /// Delete Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        public MessageEF DeleteCheckPostmaster(Checkpostmaster objCheckPostmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "C_Id",objCheckPostmaster.CheckPostId,
                        "Check","4"
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("UspForCheckPostmaster", _param, commandType: System.Data.CommandType.StoredProcedure);
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
        /// <summary>
        /// Update Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        public MessageEF UpdateCheckPostmaster(Checkpostmaster objCheckPostmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CheckpostName", objCheckPostmaster.CheckPostName);
                p.Add("C_id", objCheckPostmaster.CheckPostId);
                p.Add("DistrictID", objCheckPostmaster.DistrictID);
                p.Add("UserId", objCheckPostmaster.UserID);
                p.Add("ModifiedBy", objCheckPostmaster.CreatedBy);
                //p.Add("UserLoginID", objCheckPostmaster.CreatedBy);
                p.Add("IsActive", objCheckPostmaster.IsActive);
                p.Add("Check", "3");
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("UspForCheckPostmaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");



                string response = newID.ToString();

                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response == "2")
                {
                    objMessage.Satus = "3";

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
        /// Bind District List Details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        public List<Checkpostmaster> GetDistrictList(Checkpostmaster objCheckPostmaster)
        {
            List<Checkpostmaster> ObjDistrictList = new List<Checkpostmaster>();
            try
            {
                var paramList = new
                {
                    //DistrictId = objCheckPostmaster.DistrictID
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<Checkpostmaster>("Usp_GetDistrict", paramList, commandType: System.Data.CommandType.StoredProcedure);

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
        /// Bind User List details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        public List<Checkpostmaster> GetUserList(Checkpostmaster objCheckPostmaster)
        {
            List<Checkpostmaster> ObjUserList = new List<Checkpostmaster>();
            try
            {
                var paramList = new
                {
                    //DistrictId = objCheckPostmaster.DistrictID
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<Checkpostmaster>("uspSelectCheckPostUser", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjUserList = result.ToList();
                }

                return ObjUserList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
