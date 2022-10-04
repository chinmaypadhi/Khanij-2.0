// ***********************************************************************
//  Class Name               : MineralScheduleProvider
//  Description              : Add,View,Edit,Update,Delete Mineral Schedule details
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

namespace MasterApi.Model.MineralSchedule
{
    public class MineralScheduleProvider : RepositoryBase, IMineralScheduleProvider
    {
        public MineralScheduleProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        #region Add
        public MessageEF AddMineralSchedule(MineralScheduleModel mineralScheduleModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@MineralScheduleID", 0);
                p.Add("@MineralScheduleName", mineralScheduleModel.MineralScheduleName);
                p.Add("@MineralTypeID", mineralScheduleModel.MineralTypeId);
                p.Add("@userId", mineralScheduleModel.CreatedBy);
                p.Add("@UserloginId", mineralScheduleModel.CreatedBy);
                p.Add("@IsActive", mineralScheduleModel.IsActive == null ? true : mineralScheduleModel.IsActive);
                p.Add("@operation", 1);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspMineralScheduleMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// Delete Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        #region Delete
        public MessageEF DeleteMineralSchedule(MineralScheduleModel mineralScheduleModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                object[] objArray = new object[] {
                        "@MineralScheduleID",mineralScheduleModel.MineralScheduleID,
                        "@operation",3,
                        "@userId",mineralScheduleModel.CreatedBy,
                        "@userLoginId",mineralScheduleModel.CreatedBy
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("uspMineralScheduleMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Edit Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        #region Edit
        public MineralScheduleModel EditMineralSchedule(MineralScheduleModel mineralScheduleModel)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@MineralScheduleID", mineralScheduleModel.MineralScheduleID);

                var result = Connection.Query<MineralScheduleModel>("uspMineralScheduleMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    mineralScheduleModel = result.FirstOrDefault();
                }

                return mineralScheduleModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                mineralScheduleModel = null;
            }
        }
        #endregion
        /// <summary>
        /// Update Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        #region Update
        public MessageEF UpdateMineralSchedule(MineralScheduleModel mineralScheduleModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@MineralScheduleID", mineralScheduleModel.MineralScheduleID);
                p.Add("@MineralScheduleName", mineralScheduleModel.MineralScheduleName);
                p.Add("@MineralTypeID", mineralScheduleModel.MineralTypeId);
                p.Add("@userId", mineralScheduleModel.CreatedBy);
                p.Add("@UserloginId", mineralScheduleModel.CreatedBy);
                p.Add("@IsActive", mineralScheduleModel.IsActive == null ? true : mineralScheduleModel.IsActive);
                p.Add("@operation", 2);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspMineralScheduleMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// View Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        #region View
        public List<MineralScheduleModel> ViewMineralSchedule(MineralScheduleModel mineralScheduleModel)
        {
            List<MineralScheduleModel> listMineralScheduleModel = new List<MineralScheduleModel>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@MineralTypeID", mineralScheduleModel.MineralTypeId);
                var result = Connection.Query<MineralScheduleModel>("uspMineralScheduleMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listMineralScheduleModel = result.ToList();
                }

                return listMineralScheduleModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listMineralScheduleModel = null;
            }
        }
        #endregion
    }
}
