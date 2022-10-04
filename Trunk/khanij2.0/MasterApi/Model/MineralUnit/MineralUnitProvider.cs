// ***********************************************************************
//  Class Name               : MineralUnitProvider
//  Description              : Add,View,Edit,Update,Delete Mineral Unit details
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Jan 2021
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MasterApi.Model.MineralUnit
{
    public class MineralUnitProvider: RepositoryBase, IMineralUnitProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public MineralUnitProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        public MessageEF AddMineralUnitMaster(MineralUnitmaster objMineralUnitmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("UnitName", objMineralUnitmaster.MineralUnitName);
                p.Add("UserID", objMineralUnitmaster.CreatedBy);
                p.Add("IsActive", objMineralUnitmaster.IsActive);
                p.Add("Chk", "1");
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("spMineralUnitMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
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
        /// View Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        public List<MineralUnitmaster> ViewMineralUnitMaster(MineralUnitmaster objMineralUnitmaster)
        {
            List<MineralUnitmaster> ListMineralUnitmaster = new List<MineralUnitmaster>();
            try
            {
                var paramList = new
                {
                    UnitName = objMineralUnitmaster.MineralUnitName,
                    Chk = "0",

                };
                var result = Connection.Query<MineralUnitmaster>("spMineralUnitMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListMineralUnitmaster = result.ToList();
                }

                return ListMineralUnitmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListMineralUnitmaster = null;
            }



        }
        /// <summary>
        /// Edit Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        public MineralUnitmaster EditMineralUnitMaster(MineralUnitmaster objMineralUnitmaster)
        {
            MineralUnitmaster LobjMMineralUnitmaster = new MineralUnitmaster();
            try
            {
                var paramList = new
                {
                    UnitID = objMineralUnitmaster.MineralUnitID,
                    Chk = "4",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<MineralUnitmaster>("spMineralUnitMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjMMineralUnitmaster = result.FirstOrDefault();
                }

                return LobjMMineralUnitmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjMMineralUnitmaster = null;
            }
        }
        /// <summary>
        /// Delete Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        public MessageEF DeleteMineralUnitMaster(MineralUnitmaster objMineralUnitmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "UnitID",objMineralUnitmaster.MineralUnitID,
                        "Chk","3"
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("Result");
                var result = Connection.Query<string>("spMineralUnitMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("Result");
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
        /// Update Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        public MessageEF UpdateMineralUnitMaster(MineralUnitmaster objMineralUnitmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("UnitName", objMineralUnitmaster.MineralUnitName);
                p.Add("UnitID", objMineralUnitmaster.MineralUnitID);
                p.Add("UserID", objMineralUnitmaster.CreatedBy);
                p.Add("IsActive", objMineralUnitmaster.IsActive);
                p.Add("Chk", "2");
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("spMineralUnitMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
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
        /// View Lessee Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        public List<MineralUnitmaster> ViewLesseeMineralUnitMaster(MineralUnitmaster objMineralUnitmaster)
        {
            List<MineralUnitmaster> ListMineralUnitmaster = new List<MineralUnitmaster>();
            try
            {
                var paramList = new
                {
                    ACTION = "T"
                };
                var result = Connection.Query<MineralUnitmaster>("[USP_FILL_COMMON_DATA]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListMineralUnitmaster = result.ToList();
                }
                return ListMineralUnitmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListMineralUnitmaster = null;
            }
        }
    }
}
