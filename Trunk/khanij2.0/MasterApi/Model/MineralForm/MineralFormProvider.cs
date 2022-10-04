// ***********************************************************************
//  Class Name               : MineralFormProvider
//  Description              : Add,View,Edit,Update,Delete Mineral Form details
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

namespace MasterApi.Model.MineralForm
{
    public class MineralFormProvider : RepositoryBase, IMineralFormProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public MineralFormProvider(IConnectionFactory connectionFactory):base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        #region Add
        public MessageEF AddMineralForm(MineralNatureModel mineralNatureModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {   

                var p = new DynamicParameters();
                p.Add("@MineralTypeId", mineralNatureModel.MineralTypeId);
                p.Add("@MineralId", mineralNatureModel.MineralId);
                p.Add("@MineralNature", mineralNatureModel.MineralNature); 
                p.Add("@userId", mineralNatureModel.CreatedBy);
                p.Add("@UserloginId", mineralNatureModel.CreatedBy);
                p.Add("@IsActive", mineralNatureModel.IsActive == null ? true : mineralNatureModel.IsActive);
                p.Add("@CHK", 1);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("MineralNatureOperation", p, commandType: CommandType.StoredProcedure);
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
        /// Delete Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        #region Delete
        public MessageEF DeleteMineralForm(MineralNatureModel mineralNatureModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {   

                object[] objArray = new object[] {
                        "@MineralNatureId",mineralNatureModel.MineralNatureId,
                        "@CHK",3,
                        "@userId",mineralNatureModel.CreatedBy,
                        "@userLoginId",mineralNatureModel.CreatedBy
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("MineralNatureOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Edit Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        #region Edit
        public MineralNatureModel EditMineralForm(MineralNatureModel mineralNatureModel)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@CHK", 4);
                param.Add("@MineralNatureId", mineralNatureModel.MineralNatureId);

                var result = Connection.Query<MineralNatureModel>("MineralNatureOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    mineralNatureModel = result.FirstOrDefault();
                }

                return mineralNatureModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                mineralNatureModel = null;
            }
        }
        #endregion
        /// <summary>
        /// Update Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        #region Update
        public MessageEF UpdateMineralForm(MineralNatureModel mineralNatureModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@MineralNatureId", mineralNatureModel.MineralNatureId);
                p.Add("@MineralTypeId", mineralNatureModel.MineralTypeId);
                p.Add("@MineralId", mineralNatureModel.MineralId);
                p.Add("@MineralNature", mineralNatureModel.MineralNature);
                p.Add("@userId", mineralNatureModel.CreatedBy);
                p.Add("@UserloginId", mineralNatureModel.CreatedBy);
                p.Add("@IsActive", mineralNatureModel.IsActive == null ? true : mineralNatureModel.IsActive);
                p.Add("@CHK", 2);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("MineralNatureOperation", p, commandType: CommandType.StoredProcedure);
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
        /// View Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        #region View
        public List<MineralNatureModel> ViewMineralForm(MineralNatureModel mineralNatureModel)
        {
            List<MineralNatureModel> listMineralNatureModel = new List<MineralNatureModel>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@CHK", 4);

                var result = Connection.Query<MineralNatureModel>("MineralNatureOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listMineralNatureModel = result.ToList();
                }

                return listMineralNatureModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listMineralNatureModel = null;
            }
        }
        #endregion
    }
}
