// ***********************************************************************
//  Class Name               : MineralSchedulePartProvider
//  Description              : Add,View,Edit,Update,Delete Mineral Schedule Part details
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

namespace MasterApi.Model.MineralSchedulePart
{
    public class MineralSchedulePartProvider : RepositoryBase, IMineralSchedulePartProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public MineralSchedulePartProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        #region Add
        public MessageEF AddMineralSchedulePart(MineralSchedulePartModel mineralSchedulePartModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@MineralSchedulePartID",0);
                p.Add("@MineralSchedulePartName", mineralSchedulePartModel.MineralSchedulePartName);
                p.Add("@MineralScheduleID", mineralSchedulePartModel.MineralScheduleId); 
                p.Add("@MineralTypeID", mineralSchedulePartModel.MineralTypeId);
                p.Add("@userId", mineralSchedulePartModel.CreatedBy);
                p.Add("@UserloginId", mineralSchedulePartModel.CreatedBy);
                p.Add("@IsActive", mineralSchedulePartModel.IsActive == null ? true : mineralSchedulePartModel.IsActive);
                p.Add("@operation", 1);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspMineralSchedulePartMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// Delete Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        #region Delete
        public MessageEF DeleteMineralSchedulePart(MineralSchedulePartModel mineralSchedulePartModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                object[] objArray = new object[] {
                        "@MineralSchedulePartID",mineralSchedulePartModel.MineralSchedulePartID,
                        "@operation",3,
                        "@userId",mineralSchedulePartModel.CreatedBy,
                        "@userLoginId",mineralSchedulePartModel.CreatedBy
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("uspMineralSchedulePartMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Edit Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        #region Edit
        public MineralSchedulePartModel EditMineralSchedulePart(MineralSchedulePartModel mineralSchedulePartModel)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@MineralSchedulePartID", mineralSchedulePartModel.MineralSchedulePartID);

                var result = Connection.Query<MineralSchedulePartModel>("uspMineralSchedulePartMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    mineralSchedulePartModel = result.FirstOrDefault();
                }

                return mineralSchedulePartModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                mineralSchedulePartModel = null;
            }
        }
        #endregion
        /// <summary>
        /// Update Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        #region Update
        public MessageEF UpdateMineralSchedulePart(MineralSchedulePartModel mineralSchedulePartModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@MineralSchedulePartID", mineralSchedulePartModel.MineralSchedulePartID);
                p.Add("@MineralSchedulePartName", mineralSchedulePartModel.MineralSchedulePartName);
                p.Add("@MineralScheduleID", mineralSchedulePartModel.MineralScheduleId);
                p.Add("@MineralTypeID", mineralSchedulePartModel.MineralTypeId);
                p.Add("@userId", mineralSchedulePartModel.CreatedBy);
                p.Add("@UserloginId", mineralSchedulePartModel.CreatedBy);
                p.Add("@IsActive", mineralSchedulePartModel.IsActive == null ? true : mineralSchedulePartModel.IsActive);
                p.Add("@operation", 2);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspMineralSchedulePartMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// View Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        #region View
        public List<MineralSchedulePartModel> ViewMineralSchedulePart(MineralSchedulePartModel mineralSchedulePartModel)
        {
            List<MineralSchedulePartModel> listMineralSchedulePartModel = new List<MineralSchedulePartModel>(); 
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@MineralScheduleID", mineralSchedulePartModel.MineralScheduleId);
                var result = Connection.Query<MineralSchedulePartModel>("uspMineralSchedulePartMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                { 
                    listMineralSchedulePartModel = result.ToList();
                } 
                return listMineralSchedulePartModel; 
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listMineralSchedulePartModel = null;
            }
        }
        #endregion
    }
}
