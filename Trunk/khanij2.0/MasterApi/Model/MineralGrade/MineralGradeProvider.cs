// ***********************************************************************
//  Class Name               : MineralGradeProvider
//  Description              : Add,View,Edit,Update,Delete Mineral Grade details
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

namespace MasterApi.Model.MineralGrade
{
    public class MineralGradeProvider: RepositoryBase,IMineralGradeProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public MineralGradeProvider(IConnectionFactory connectionFactory):base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        #region Add
        public MessageEF AddMineralGrade(MineralGradeModel mineralGradeModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            { 

                var p = new DynamicParameters();
                p.Add("@MineralTypeId", mineralGradeModel.MineralTypeId);
                p.Add("@MineralId", mineralGradeModel.MineralId);
                p.Add("@MineralNatureId", mineralGradeModel.MineralNatureId);
                p.Add("@MineralGrade", mineralGradeModel.MineralGrade);
                p.Add("@userId",mineralGradeModel.CreatedBy);
                p.Add("@userLoginId",mineralGradeModel.UserLoginId);
                p.Add("@IsActive",mineralGradeModel.IsActive==null?true: mineralGradeModel.IsActive);
                p.Add("@chk",1);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspMineralGradeMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// Delete Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        #region Delete
        public MessageEF DeleteMineralGrade(MineralGradeModel mineralGradeModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@MineralGradeId", mineralGradeModel.MineralGradeId); 
                p.Add("@userId", mineralGradeModel.CreatedBy);
                p.Add("@userLoginId", mineralGradeModel.UserLoginId); 
                p.Add("@chk", 3);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspMineralGradeMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// Edit Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        #region Edit
        public MineralGradeModel EditMineralGrade(MineralGradeModel mineralGradeModel)
        {
            //CriticalityMaster objCriticalityMasters = new CriticalityMaster();


            try
            {
                //var paramList = new
                //{
                //    CriticalityMasterId = objCriticalityMaster.CriticalityMasterId,
                //    Chk = "Update",

                //};
                DynamicParameters param = new DynamicParameters();
                param.Add("@CHK",4);
                param.Add("@MineralGradeId", mineralGradeModel.MineralGradeId);

                var result = Connection.Query<MineralGradeModel>("uspMineralGradeMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    mineralGradeModel = result.FirstOrDefault();
                }

                return mineralGradeModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                mineralGradeModel = null;
            }
        }
        #endregion
        /// <summary>
        /// Update Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        #region Update
        public MessageEF UpdateMineralGrade(MineralGradeModel mineralGradeModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@MineralGradeId",mineralGradeModel.MineralGradeId);
                p.Add("@MineralTypeId", mineralGradeModel.MineralTypeId);
                p.Add("@MineralId", mineralGradeModel.MineralId);
                p.Add("@MineralNatureId", mineralGradeModel.MineralNatureId);
                p.Add("@MineralGrade", mineralGradeModel.MineralGrade);
                p.Add("@userId", mineralGradeModel.CreatedBy);
                p.Add("@userLoginId", mineralGradeModel.UserLoginId);
                p.Add("@IsActive", mineralGradeModel.IsActive == null ? true : mineralGradeModel.IsActive);
                p.Add("@chk", 2);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspMineralGradeMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// View Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        #region View
        public List<MineralGradeModel> ViewMineralGrade(MineralGradeModel mineralGradeModel)
        {
            List<MineralGradeModel> listMineralGradeModel = new List<MineralGradeModel>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@CHK", mineralGradeModel.CHK);
                param.Add("@MineralTypeId", mineralGradeModel.MineralTypeId);
                param.Add("@MineralId", mineralGradeModel.MineralId);
                param.Add("@MineralNatureId", mineralGradeModel.MineralNatureId);
                var result = Connection.Query<MineralGradeModel>("uspMineralGradeMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listMineralGradeModel = result.ToList();
                }
                else
                {
                    mineralGradeModel.MineralTypeId =null;
                    mineralGradeModel.MineralTypeName = string.Empty;
                    mineralGradeModel.MineralId = null;
                    mineralGradeModel.MineralName = string.Empty;
                    mineralGradeModel.MineralNatureId = null;
                    mineralGradeModel.MineralNature = string.Empty;
                    listMineralGradeModel.Add(mineralGradeModel);
                }

                return listMineralGradeModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listMineralGradeModel = null;
            }

        }

        
        #endregion
    }
}
