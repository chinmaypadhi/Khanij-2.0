// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 21-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MasterApi.Model.WeighBridge
{
    public class WeighBridgeProvider : RepositoryBase, IWeighBridgeProvider
    {
        public WeighBridgeProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddWeighBridgemaster(WeighBridgemaster objWeighBridgemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("WeighBridgeName", objWeighBridgemaster.WeighBridgeName);
                p.Add("DistrictID", objWeighBridgemaster.DistrictID);
                p.Add("Address", objWeighBridgemaster.Address);
                p.Add("UserName", objWeighBridgemaster.UserName);
                p.Add("Password", objWeighBridgemaster.Password);
                p.Add("IsActive", objWeighBridgemaster.IsActive);
                p.Add("CreatedBy", objWeighBridgemaster.CreatedBy);
                p.Add("UserLoginID", objWeighBridgemaster.CreatedBy);
                p.Add("Check", "2");
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("spWeighBridgeMaster", p, commandType: CommandType.StoredProcedure);
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
        public List<WeighBridgemaster> ViewWeighBridgemaster(WeighBridgemaster objWeighBridgemaster)
        {
            List<WeighBridgemaster> ListWeighBridgemaster = new List<WeighBridgemaster>();
            try
            {
                var paramList = new
                {
                    WeighBridgeName = objWeighBridgemaster.WeighBridgeName,
                    Check = "1",
                };
                var result = Connection.Query<WeighBridgemaster>("spWeighBridgeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListWeighBridgemaster = result.ToList();
                }

                return ListWeighBridgemaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListWeighBridgemaster = null;
            }



        }
        public WeighBridgemaster EditWeighBridgemaster(WeighBridgemaster objWeighBridgemaster)
        {
            WeighBridgemaster LobjWeighBridgemaster = new WeighBridgemaster();
            try
            {
                var paramList = new
                {
                    WeighBridgeId = objWeighBridgemaster.WeighBridgeId,
                    Check = "5",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<WeighBridgemaster>("spWeighBridgeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjWeighBridgemaster = result.FirstOrDefault();
                }

                return LobjWeighBridgemaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjWeighBridgemaster = null;
            }
        }
        public MessageEF DeleteWeighBridgemaster(WeighBridgemaster objWeighBridgemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "WeighBridgeId",objWeighBridgemaster.WeighBridgeId,
                        "Check","4"
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("spWeighBridgeMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
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
        public MessageEF UpdateWeighBridgemaster(WeighBridgemaster objWeighBridgemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("WeighBridgeName", objWeighBridgemaster.WeighBridgeName);
                p.Add("WeighBridgeId", objWeighBridgemaster.WeighBridgeId);
                p.Add("DistrictID", objWeighBridgemaster.DistrictID);
                p.Add("Address", objWeighBridgemaster.Address);
                p.Add("UserName", objWeighBridgemaster.UserName);
                p.Add("Password", objWeighBridgemaster.Password);
                p.Add("CreatedBy", objWeighBridgemaster.CreatedBy);
                p.Add("IsActive", objWeighBridgemaster.IsActive);
                p.Add("Check", "3");
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("spWeighBridgeMaster", p, commandType: CommandType.StoredProcedure);
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
        public List<WeighBridgemaster> GetDistrictList(WeighBridgemaster objWeighBridgemaster)
        {
            List<WeighBridgemaster> ObjDistrictList = new List<WeighBridgemaster>();
            try
            {
                var paramList = new
                {
                    //DistrictId = objWeighBridgemaster.DistrictID
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<WeighBridgemaster>("Usp_GetDistrict", paramList, commandType: System.Data.CommandType.StoredProcedure);

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
    }
}
