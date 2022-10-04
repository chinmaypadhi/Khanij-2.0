// ***********************************************************************
//  Class Name               : MineralNameProvider
//  Description              : Add,View,Edit,Update,Delete Mineral details
//  Created By               : Akshaya Dalei
//  Created On               : 18 March 2021
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

namespace MasterApi.Model.MineralName
{
    public class MineralNameProvider : RepositoryBase, IMineralNameProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public MineralNameProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        #region Add
        public MessageEF AddMineralName(MineralModel mineralModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                var search = ViewMineralName(mineralModel).FirstOrDefault(x => x.MineralName.ToUpper() == mineralModel.MineralName.ToUpper() && x.IsDelete == false);
                if (search != null)
                {
                    objMessage.Satus = "2";
                }
                else
                {
                    p.Add("@operation", 1);
                    p.Add("@MineralID", 0);
                    p.Add("@IsActive", (mineralModel.IsActive == null ? mineralModel.IsActive = true : mineralModel.IsActive = mineralModel.IsActive));
                    p.Add("@MineralSchedulePartId", mineralModel.MineralSchedulePartId);
                    p.Add("@MineralName", mineralModel.MineralName);
                    p.Add("@UnitId", mineralModel.UnitId);
                    p.Add("@RoyaltyRateTypeId", mineralModel.RoyaltyRateTypeId);
                    p.Add("@CreatedBy", mineralModel.CreatedBy);
                    p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    Connection.Query<int>("uspMineralMasterOperation", p, commandType: CommandType.StoredProcedure);
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
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion
        /// <summary>
        /// Delete Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        #region Delete
        public MessageEF DeleteMineralName(MineralModel mineralModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "@MineralID",mineralModel.MineralID,
                        "@operation",3,
                        "@CreatedBy",mineralModel.CreatedBy,
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("uspMineralMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Edit Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        #region Edit
        public MineralModel EditMineralName(MineralModel mineralModel)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@MineralID", mineralModel.MineralID);
                param.Add("@operation",4);
                var result = Connection.Query<MineralModel>("uspMineralMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    mineralModel = result.FirstOrDefault();
                }

                return mineralModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                mineralModel = null;
            }
        }
        #endregion
        /// <summary>
        /// Update Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        #region Update
        public MessageEF UpdateMineralName(MineralModel mineralModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 2);
                p.Add("@MineralID", mineralModel.MineralID);
                p.Add("@IsActive", (mineralModel.IsActive == null ? mineralModel.IsActive = true : mineralModel.IsActive = mineralModel.IsActive));
                p.Add("@MineralSchedulePartId", mineralModel.MineralSchedulePartId);
                p.Add("@MineralName", mineralModel.MineralName);
                p.Add("@UnitId", mineralModel.UnitId);
                p.Add("@RoyaltyRateTypeId", mineralModel.RoyaltyRateTypeId);
                p.Add("@CreatedBy", mineralModel.CreatedBy);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspMineralMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// View Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        #region View
        public List<MineralModel> ViewMineralName(MineralModel mineralModel)
        {
            List<MineralModel> listMineralModel = new List<MineralModel>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                var result = Connection.Query<MineralModel>("uspMineralMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listMineralModel = result.ToList();
                }

                return listMineralModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listMineralModel = null;
            }

        }
        #endregion
    }
}
