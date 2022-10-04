// ***********************************************************************
// Assembly         : Khanij
// Author           : Akshaya Dalei
// Created          : 25-May-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************


using Dapper;
using ReturnApi.Factory;
using ReturnApi.Repository;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Model.eReturnCoalMonthly
{
    public class MonthlyCoalReturnProvider : RepositoryBase, IMonthlyCoalReturnProvider
    {
        public MonthlyCoalReturnProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        #region Monthly Coal Return
        /// <summary>
        /// To Bind Monthly Return Coal Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<MonthlyReturnModel>> eReturnMonthlyDetails(MonthlyReturnModel monthlyReturnModel)
        {
            List<MonthlyReturnModel> lstMonthlyReturnModel = new List<MonthlyReturnModel>();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@FinancialYear", monthlyReturnModel.FinancialYear);
                param.Add("@UserID", monthlyReturnModel.UserId);
                var result = await Connection.QueryAsync<MonthlyReturnModel>("GetDetailsofMonthlyReturn", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    lstMonthlyReturnModel = result.ToList();
                }
                return lstMonthlyReturnModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstMonthlyReturnModel = null;
            }

        }


        #region Mine Details
        /// <summary>
        /// To Bind Mine Details Lessee
        /// </summary>
        /// <param name="coalMonthlyMineDetailsModel"></param>
        /// <returns></returns>

        public async Task<CoalMonthlyMineDetailsModel> LesseMineDeatils(CoalMonthlyMineDetailsModel coalMonthlyMineDetailsModel)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@UserID", coalMonthlyMineDetailsModel.UserId);
                var result = await Connection.QueryAsync<CoalMonthlyMineDetailsModel>("UspGetForm_F1_Details", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    coalMonthlyMineDetailsModel = result.FirstOrDefault();
                }
                return coalMonthlyMineDetailsModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                coalMonthlyMineDetailsModel = null;
            }
        }

        /// <summary>
        /// To Bind Mine Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>

        public async Task<CoalMonthlyMineDetailsModel> Get_CoalMonthlyMineDetails(MonthlyReturnModel monthlyReturnModel)
        {
            CoalMonthlyMineDetailsModel coalMonthlyMineDetailsModel = new CoalMonthlyMineDetailsModel();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@Month_Year", monthlyReturnModel.MonthYear);
                param.Add("@Check", 1);
                param.Add("@UserID", monthlyReturnModel.UserId);
                var result = await Connection.QueryAsync<CoalMonthlyMineDetailsModel>("UspGet_CoalMonthlyMineDetails", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    coalMonthlyMineDetailsModel = result.FirstOrDefault();
                }
                return coalMonthlyMineDetailsModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                coalMonthlyMineDetailsModel = null;
            }
        }

        /// <summary>
        /// To Update Mine Details
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>

        public async Task<MessageEF> Update_MineDetails(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@Coal_Monthly_Id", coalMonthlyViewModel.objMine.Coal_Monthly_Id);
                p.Add("@Name_of_mine", coalMonthlyViewModel.objMine.Name_of_mine);
                p.Add("@postal_address_of_mine", coalMonthlyViewModel.objMine.postal_address_of_mine);
                p.Add("@Situation_of_Mine", coalMonthlyViewModel.objMine.Situation_of_Mine);
                p.Add("@Tahsil", coalMonthlyViewModel.objMine.Tahsil);
                p.Add("@District", coalMonthlyViewModel.objMine.District);
                p.Add("@State", coalMonthlyViewModel.objMine.State);
                p.Add("@Name_of_Owner", coalMonthlyViewModel.objMine.Name_of_Owner);
                p.Add("@Postal_address_of_owner", coalMonthlyViewModel.objMine.Postal_address_of_owner);
                p.Add("@Name_of_agents", coalMonthlyViewModel.objMine.Name_of_agents);
                p.Add("@Address_of_agents", coalMonthlyViewModel.objMine.Address_of_agents);
                p.Add("@Name_of_manager", coalMonthlyViewModel.objMine.Name_of_manager);
                p.Add("@Address_of_manager", coalMonthlyViewModel.objMine.Address_of_manager);
                p.Add("@Certify", coalMonthlyViewModel.objMine.Certify);
                p.Add("@Month_Year", coalMonthlyViewModel.objMine.Month_Year4);
                p.Add("@Agent_Name", coalMonthlyViewModel.objMine.agent_name);
                p.Add("@Agent_Address", coalMonthlyViewModel.objMine.agent_address);
                p.Add("@ModifiedBy", coalMonthlyViewModel.UserId);
                p.Add("@Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_CoalMonthlyMineDetails", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// To Add Mine Details
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> ADD_MineDetails(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@Name_of_mine", coalMonthlyViewModel.objMine.Name_of_mine);
                p.Add("@postal_address_of_mine", coalMonthlyViewModel.objMine.postal_address_of_mine);
                p.Add("@Situation_of_Mine", coalMonthlyViewModel.objMine.Situation_of_Mine);
                p.Add("@Tahsil", coalMonthlyViewModel.objMine.Tahsil);
                p.Add("@District", coalMonthlyViewModel.objMine.District);
                p.Add("@State", coalMonthlyViewModel.objMine.State);
                p.Add("@Name_of_Owner", coalMonthlyViewModel.objMine.Name_of_Owner);
                p.Add("@Postal_address_of_owner", coalMonthlyViewModel.objMine.Postal_address_of_owner);

                p.Add("@Name_of_agents", coalMonthlyViewModel.objMine.Name_of_agents);
                p.Add("@Address_of_agents", coalMonthlyViewModel.objMine.Address_of_agents);
                p.Add("@Name_of_manager", coalMonthlyViewModel.objMine.Name_of_manager);
                p.Add("@Address_of_manager", coalMonthlyViewModel.objMine.Address_of_manager);
                p.Add("@Certify", coalMonthlyViewModel.objMine.Certify);

                p.Add("@Month_Year", coalMonthlyViewModel.objMine.Month_Year4);
                p.Add("@CreatedBy", coalMonthlyViewModel.UserId);
                p.Add("@Agent_Name", coalMonthlyViewModel.objMine.agent_name);
                p.Add("@Agent_Address", coalMonthlyViewModel.objMine.agent_address);
                p.Add("@Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_CoalMonthlyMineDetails", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        #endregion

        #region Table A
        /// <summary>
        /// To Add Table A
        /// </summary>
        /// <param name="tABLE_A_Model"></param>
        /// <returns></returns>

        public async Task<MessageEF> AddCoal_TableAMonthly(TABLE_A_Model tABLE_A_Model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@Name_OF_Colliery_Siding", tABLE_A_Model.Name_OF_Colliery_Siding);
                p.Add("@MineralNatureId", tABLE_A_Model.MineralNatureId);
                p.Add("@MineralGradeId", tABLE_A_Model.MineralGradeId);
                p.Add("@Size_Of_Coal", tABLE_A_Model.Size_Of_Coal);
                p.Add("@Opening_Stock", tABLE_A_Model.Opening_Stock);
                p.Add("@OpenCW", tABLE_A_Model.OpenCW);
                p.Add("@Below_GW_DevelopmentDistricts", tABLE_A_Model.Below_GW_DevelopmentDistricts);
                p.Add("@Below_GW_DepillaringDistricts", tABLE_A_Model.Below_GW_DepillaringDistricts);
                p.Add("@CollieryConsumption", tABLE_A_Model.CollieryConsumption);
                p.Add("@Coalused_Makingcoke_Colliery", tABLE_A_Model.Coalused_Makingcoke_Colliery);
                p.Add("@CokeProduced", tABLE_A_Model.CokeProduced);
                p.Add("@CoalDespatched_ByRail", tABLE_A_Model.CoalDespatched_ByRail);
                p.Add("@CoalDespatched_ByRoad", tABLE_A_Model.CoalDespatched_ByRoad);
                p.Add("@CoalDespatched_ByOther", tABLE_A_Model.CoalDespatched_ByOther);
                p.Add("@Closing_Stock", tABLE_A_Model.Closing_Stock);
                p.Add("@CoalRaised", tABLE_A_Model.CoalRaised);
                p.Add("@Month_Year", tABLE_A_Model.Month_Year);
                p.Add("@CreatedBy", tABLE_A_Model.UserId);
                p.Add("@Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_Coal_TableAMonthly", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// To Update Table A
        /// </summary>
        /// <param name="tABLE_A_Model"></param>
        /// <returns></returns>

        public async Task<MessageEF> UpdateCoal_TableAMonthly(TABLE_A_Model tABLE_A_Model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@Coal_TableA_Id", tABLE_A_Model.Coal_TableA_Id);
                p.Add("@Name_OF_Colliery_Siding", tABLE_A_Model.Name_OF_Colliery_Siding);
                p.Add("@MineralNatureId", tABLE_A_Model.MineralNatureId);
                p.Add("@MineralGradeId", tABLE_A_Model.MineralGradeId);
                p.Add("@Size_Of_Coal", tABLE_A_Model.Size_Of_Coal);
                p.Add("@Opening_Stock", tABLE_A_Model.Opening_Stock);
                p.Add("@OpenCW", tABLE_A_Model.OpenCW);
                p.Add("@Below_GW_DevelopmentDistricts", tABLE_A_Model.Below_GW_DevelopmentDistricts);
                p.Add("@Below_GW_DepillaringDistricts", tABLE_A_Model.Below_GW_DepillaringDistricts);
                p.Add("@CollieryConsumption", tABLE_A_Model.CollieryConsumption);
                p.Add("@Coalused_Makingcoke_Colliery", tABLE_A_Model.Coalused_Makingcoke_Colliery);
                p.Add("@CokeProduced", tABLE_A_Model.CokeProduced);
                p.Add("@CoalDespatched_ByRail", tABLE_A_Model.CoalDespatched_ByRail);
                p.Add("@CoalDespatched_ByRoad", tABLE_A_Model.CoalDespatched_ByRoad);
                p.Add("@CoalDespatched_ByOther", tABLE_A_Model.CoalDespatched_ByOther);
                p.Add("@Closing_Stock", tABLE_A_Model.Closing_Stock);
                p.Add("@CoalRaised", tABLE_A_Model.CoalRaised);
                p.Add("@Month_YearTableA", tABLE_A_Model.Month_Year);
                p.Add("@ModifiedBy", tABLE_A_Model.UserId);
                p.Add("@Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_Coal_TableAMonthly", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// To Opening Stock
        /// </summary>
        /// <param name="tABLE_A_Model"></param>
        /// <returns></returns> 

        public async Task<TABLE_A_Model> Coal_TableAOpeningStock(MonthlyReturnModel monthlyReturnModel)
        {
            TABLE_A_Model tABLE_A_Model = new TABLE_A_Model();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@UserID", monthlyReturnModel.UserId);
                param.Add("@Month_Year", monthlyReturnModel.MonthYear);
                param.Add("@MineralNatureId", monthlyReturnModel.MineralNatureId);
                param.Add("@MineralGradeId", monthlyReturnModel.MineralGradeId);
                param.Add("@Size_Of_Coal", monthlyReturnModel.Size_Of_Coal);
                param.Add("@Check", 2);
                var result = await Connection.QueryAsync<TABLE_A_Model>("Usp_GetCoal_TableAMonthly", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    tABLE_A_Model = result.FirstOrDefault();
                }
                return tABLE_A_Model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                tABLE_A_Model = null;
            }
        }

        /// <summary>
        /// To Delete Table A
        /// </summary>
        /// <param name="tABLE_A_Model"></param>
        /// <returns></returns> 

        public async Task<MessageEF> DeleteCoal_TableAMonthly(TABLE_A_Model tABLE_A_Model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "@Coal_TableA_Id",tABLE_A_Model.Coal_TableA_Id,
                        "@ModifiedBy",tABLE_A_Model.UserId,
                        "@Check",3
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = await Connection.QueryAsync<string>("USP_Coal_TableAMonthly", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("result");
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {
                objMessage.Satus = "3";
            }
            return objMessage;
        }

        /// <summary>
        /// To Table A Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns> 

        public async Task<List<TABLE_A_Model>> Coal_TableAMonthlyDetails(MonthlyReturnModel monthlyReturnModel)
        {
            List<TABLE_A_Model> lstTABLE_A_Model = new List<TABLE_A_Model>();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@Month_Year", monthlyReturnModel.MonthYear);
                param.Add("@UserID", monthlyReturnModel.UserId);
                var result = await Connection.QueryAsync<TABLE_A_Model>("Usp_GetCoal_TableAMonthly", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    lstTABLE_A_Model = result.ToList();
                }
                return lstTABLE_A_Model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstTABLE_A_Model = null;
            }
        }

        /// <summary>
        /// To Despatch Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns> 

        public async Task<List<TABLE_A_Model>> GetCoal_TableADispatchDetails(MonthlyReturnModel monthlyReturnModel)
        {
            List<TABLE_A_Model> lstTABLE_A_Model = new List<TABLE_A_Model>();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@Month_Year", monthlyReturnModel.MonthYear);
                param.Add("@UserID", monthlyReturnModel.UserId);
                param.Add("@MineralGradeId", monthlyReturnModel.MineralGradeId);
                var result = await Connection.QueryAsync<TABLE_A_Model>("uspGetLesseDispatchByMonth", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    lstTABLE_A_Model = result.ToList();
                }
                return lstTABLE_A_Model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstTABLE_A_Model = null;
            }
        }
        #endregion

        #region Table B
        /// <summary>
        /// To Add Table B
        /// </summary>
        /// <param name="tABLE_B_Model"></param>
        /// <returns></returns>

        public async Task<MessageEF> AddMACHINERY_TableBMonthly(TABLE_B_Model tABLE_B_Model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@WorkingsBG_Type", tABLE_B_Model.WorkingsBG_Type);
                p.Add("@Coal_Cutting_No_In_Use", tABLE_B_Model.Coal_Cutting_No_In_Use);
                p.Add("@Coal_Cutting_Type", tABLE_B_Model.Coal_Cutting_Type);
                p.Add("@Square_Metres_Cut", tABLE_B_Model.Square_Metres_Cut);
                p.Add("@Coal_cut", tABLE_B_Model.Coal_cut);
                p.Add("@MechanicalLoaders_NoInUse", tABLE_B_Model.MechanicalLoaders_NoInUse);
                p.Add("@MechanicalLoaders_Type", tABLE_B_Model.MechanicalLoaders_Type);
                p.Add("@MechanicalLoaders_Coalloaded", tABLE_B_Model.MechanicalLoaders_Coalloaded);
                p.Add("@Conveyors_Type", tABLE_B_Model.Conveyors_Type);
                p.Add("@Conveyors_Length", tABLE_B_Model.Conveyors_Length);
                p.Add("@Coal_conveyed", tABLE_B_Model.Coal_conveyed);
                p.Add("@Month_Year", tABLE_B_Model.Month_Year);
                p.Add("@CreatedBy", tABLE_B_Model.UserId);
                p.Add("@Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_MACHINERY_TableBMonthly", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// To Update Table B
        /// </summary>
        /// <param name="tABLE_B_Model"></param>
        /// <returns></returns>

        public async Task<MessageEF> UpdateMACHINERY_TableBMonthly(TABLE_B_Model tABLE_B_Model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@MACHINERY_TableB_Id", tABLE_B_Model.MACHINERY_TableB_Id);
                p.Add("@WorkingsBG_Type", tABLE_B_Model.WorkingsBG_Type);
                p.Add("@Coal_Cutting_No_In_Use", tABLE_B_Model.Coal_Cutting_No_In_Use);
                p.Add("@Coal_Cutting_Type", tABLE_B_Model.Coal_Cutting_Type);
                p.Add("@Square_Metres_Cut", tABLE_B_Model.Square_Metres_Cut);
                p.Add("@Coal_cut", tABLE_B_Model.Coal_cut);
                p.Add("@MechanicalLoaders_NoInUse", tABLE_B_Model.MechanicalLoaders_NoInUse);
                p.Add("@MechanicalLoaders_Type", tABLE_B_Model.MechanicalLoaders_Type);
                p.Add("@MechanicalLoaders_Coalloaded", tABLE_B_Model.MechanicalLoaders_Coalloaded);
                p.Add("@Conveyors_Type", tABLE_B_Model.Conveyors_Type);
                p.Add("@Conveyors_Length", tABLE_B_Model.Conveyors_Length);
                p.Add("@Coal_conveyed", tABLE_B_Model.Coal_conveyed);
                p.Add("@Month_YearTableB", tABLE_B_Model.Month_Year);
                p.Add("@ModifiedBy", tABLE_B_Model.UserId);
                p.Add("@Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_MACHINERY_TableBMonthly", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// To Delete Table B
        /// </summary>
        /// <param name="tABLE_B_Model"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteMACHINERY_TableBMonthly(TABLE_B_Model tABLE_B_Model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@MACHINERY_TableB_Id", tABLE_B_Model.MACHINERY_TableB_Id);
                p.Add("@ModifiedBy", tABLE_B_Model.UserId);
                p.Add("@Check", 3);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_MACHINERY_TableBMonthly", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// To Table B Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>

        public async Task<List<TABLE_B_Model>> GetMACHINERY_TableBMonthly(MonthlyReturnModel monthlyReturnModel)
        {
            List<TABLE_B_Model> lsttABLE_B_Model = new List<TABLE_B_Model>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Month_Year", monthlyReturnModel.MonthYear);
                param.Add("@Check", 1);
                param.Add("@UserID", monthlyReturnModel.UserId);
                var result = await Connection.QueryAsync<TABLE_B_Model>("Usp_GetMACHINERY_TableBMonthly", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    lsttABLE_B_Model = result.ToList();
                }
                return lsttABLE_B_Model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lsttABLE_B_Model = null;
            }
        }

        /// <summary>
        /// To Working BackGroung Type
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>

        public async Task<List<TABLE_B_Model>> GetWorkingBackGroungType(MonthlyReturnModel monthlyReturnModel)
        {
            List<TABLE_B_Model> lsttABLE_B_Model = new List<TABLE_B_Model>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                var result = await Connection.QueryAsync<TABLE_B_Model>("Usp_GetMACHINERY_TableBMonthly", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    lsttABLE_B_Model = result.ToList();
                }
                return lsttABLE_B_Model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lsttABLE_B_Model = null;
            }
        }


        #endregion

        #region Table C Men & Work
        /// <summary>
        /// To Bind Men & Work Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>

        public async Task<CoalMonthlyModel> Get_NumberOF_Work_TableCMonthly(MonthlyReturnModel monthlyReturnModel)
        {
            CoalMonthlyModel coalMonthlyModel = new CoalMonthlyModel();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@Month_Year", monthlyReturnModel.MonthYear);
                param.Add("@Check", 1);
                param.Add("@UserID", monthlyReturnModel.UserId);
                var result = await Connection.QueryAsync<CoalMonthlyModel>("UspGet_CoalMonthlyTableC", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    coalMonthlyModel = result.FirstOrDefault();
                    coalMonthlyModel.Month_Year3 = coalMonthlyModel.Month_Year;
                }
                return coalMonthlyModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                coalMonthlyModel = null;
            }
        }

        /// <summary>
        /// To Update Table C
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>

        public async Task<MessageEF> Update_NumberOF_Work_TableCMonthly(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@Working_BackgroundOn_Id", coalMonthlyViewModel.objWork.Working_BackgroundOn_Id);
                p.Add("@Belowground_on", coalMonthlyViewModel.objWork.Belowground_on_str);
                p.Add("@Mine_on", coalMonthlyViewModel.objWork.Mine_on_str);
                p.Add("@BG_Mine_Loader_Men", coalMonthlyViewModel.objWork.BG_Mine_Loader_Men);
                p.Add("@BG_Mine_Loader_Women", coalMonthlyViewModel.objWork.BG_Mine_Loader_Women);
                p.Add("@BG_Sickness", coalMonthlyViewModel.objWork.BG_Sickness);
                p.Add("@BG_Accident", coalMonthlyViewModel.objWork.BG_Accident);
                p.Add("@BG_Leave", coalMonthlyViewModel.objWork.BG_Leave);
                p.Add("@BG_OtherCause", coalMonthlyViewModel.objWork.BG_OtherCause);
                p.Add("@BG_Total", coalMonthlyViewModel.objWork.BG_Total);
                p.Add("@BG_Other_Men", coalMonthlyViewModel.objWork.BG_Other_Men);
                p.Add("@BG_Other_Women", coalMonthlyViewModel.objWork.BG_Other_Women);
                p.Add("@BG_Other_Sickness", coalMonthlyViewModel.objWork.BG_Other_Sickness);
                p.Add("@BG_Other_Accident", coalMonthlyViewModel.objWork.BG_Other_Accident);
                p.Add("@BG_Other_Leave", coalMonthlyViewModel.objWork.BG_Other_Leave);
                p.Add("@BG_Other_OtherCause", coalMonthlyViewModel.objWork.BG_Other_OtherCause);
                p.Add("@BG_Other_Total", coalMonthlyViewModel.objWork.BG_Other_Total);
                p.Add("@OC_Mine_Loader_Men", coalMonthlyViewModel.objWork.OC_Mine_Loader_Men);
                p.Add("@OC_Mine_Loader_Women", coalMonthlyViewModel.objWork.OC_Mine_Loader_Women);
                p.Add("@OC_Sickness", coalMonthlyViewModel.objWork.OC_Sickness);
                p.Add("@OC_Accident", coalMonthlyViewModel.objWork.OC_Accident);
                p.Add("@OC_Leave", coalMonthlyViewModel.objWork.OC_Leave);
                p.Add("@OC_OtherCause", coalMonthlyViewModel.objWork.OC_OtherCause);
                p.Add("@OC_Total", coalMonthlyViewModel.objWork.OC_Total);
                p.Add("@OC_Other_Men", coalMonthlyViewModel.objWork.OC_Other_Men);
                p.Add("@OC_Other_Women", coalMonthlyViewModel.objWork.OC_Other_Women);
                p.Add("@OC_Other_Sickness", coalMonthlyViewModel.objWork.OC_Other_Sickness);
                p.Add("@OC_Other_Accident", coalMonthlyViewModel.objWork.OC_Other_Accident);
                p.Add("@OC_Other_Leave", coalMonthlyViewModel.objWork.OC_Other_Leave);
                p.Add("@OC_Other_OtherCause", coalMonthlyViewModel.objWork.OC_Other_OtherCause);
                p.Add("@OC_Other_Total", coalMonthlyViewModel.objWork.OC_Other_Total);
                p.Add("@AG_Men", coalMonthlyViewModel.objWork.AG_Men);
                p.Add("@AG_Women", coalMonthlyViewModel.objWork.AG_Women);
                p.Add("@AG_Sickness", coalMonthlyViewModel.objWork.AG_Sickness);
                p.Add("@AG_Accident", coalMonthlyViewModel.objWork.AG_Accident);
                p.Add("@AG_Leave", coalMonthlyViewModel.objWork.AG_Leave);
                p.Add("@AG_OtherCause", coalMonthlyViewModel.objWork.AG_OtherCause);
                p.Add("@AG_Total", coalMonthlyViewModel.objWork.AG_Total);
                p.Add("@Total_Men", coalMonthlyViewModel.objWork.Total_Men);
                p.Add("@Total_Women", coalMonthlyViewModel.objWork.Total_Women);
                p.Add("@Total_Sickness", coalMonthlyViewModel.objWork.Total_Sickness);
                p.Add("@Total_Accident", coalMonthlyViewModel.objWork.Total_Accident);
                p.Add("@Total_Leave", coalMonthlyViewModel.objWork.Total_Leave);
                p.Add("@Total_OtherCause", coalMonthlyViewModel.objWork.Total_OtherCause);
                p.Add("@Total_All", coalMonthlyViewModel.objWork.Total_All);
                p.Add("@Month_Year", coalMonthlyViewModel.objWork.Month_Year3);
                p.Add("@Belowground_No_Employee", coalMonthlyViewModel.objWork.Belowground_No_Employee);
                p.Add("@Mine_No_Employee", coalMonthlyViewModel.objWork.Mine_No_Employee);
                p.Add("@ModifiedBy", coalMonthlyViewModel.UserId);
                p.Add("@Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_CoalMonthlyTableC", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// To Add Table C
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> ADD_NumberOF_Work_TableCMonthly(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@Belowground_on", coalMonthlyViewModel.objWork.Belowground_on_str);
                p.Add("@Mine_on", coalMonthlyViewModel.objWork.Mine_on_str);
                p.Add("@BG_Mine_Loader_Men", coalMonthlyViewModel.objWork.BG_Mine_Loader_Men);
                p.Add("@BG_Mine_Loader_Women", coalMonthlyViewModel.objWork.BG_Mine_Loader_Women);
                p.Add("@BG_Sickness", coalMonthlyViewModel.objWork.BG_Sickness);
                p.Add("@BG_Accident", coalMonthlyViewModel.objWork.BG_Accident);
                p.Add("@BG_Leave", coalMonthlyViewModel.objWork.BG_Leave);
                p.Add("@BG_OtherCause", coalMonthlyViewModel.objWork.BG_OtherCause);
                p.Add("@BG_Total", coalMonthlyViewModel.objWork.BG_Total);
                p.Add("@BG_Other_Men", coalMonthlyViewModel.objWork.BG_Other_Men);
                p.Add("@BG_Other_Women", coalMonthlyViewModel.objWork.BG_Other_Women);
                p.Add("@BG_Other_Sickness", coalMonthlyViewModel.objWork.BG_Other_Sickness);
                p.Add("@BG_Other_Accident", coalMonthlyViewModel.objWork.BG_Other_Accident);
                p.Add("@BG_Other_Leave", coalMonthlyViewModel.objWork.BG_Other_Leave);
                p.Add("@BG_Other_OtherCause", coalMonthlyViewModel.objWork.BG_Other_OtherCause);
                p.Add("@BG_Other_Total", coalMonthlyViewModel.objWork.BG_Other_Total);
                p.Add("@OC_Mine_Loader_Men", coalMonthlyViewModel.objWork.OC_Mine_Loader_Men);
                p.Add("@OC_Mine_Loader_Women", coalMonthlyViewModel.objWork.OC_Mine_Loader_Women);
                p.Add("@OC_Sickness", coalMonthlyViewModel.objWork.OC_Sickness);
                p.Add("@OC_Accident", coalMonthlyViewModel.objWork.OC_Accident);
                p.Add("@OC_Leave", coalMonthlyViewModel.objWork.OC_Leave);
                p.Add("@OC_OtherCause", coalMonthlyViewModel.objWork.OC_OtherCause);
                p.Add("@OC_Total", coalMonthlyViewModel.objWork.OC_Total);
                p.Add("@OC_Other_Men", coalMonthlyViewModel.objWork.OC_Other_Men);
                p.Add("@OC_Other_Women", coalMonthlyViewModel.objWork.OC_Other_Women);
                p.Add("@OC_Other_Sickness", coalMonthlyViewModel.objWork.OC_Other_Sickness);
                p.Add("@OC_Other_Accident", coalMonthlyViewModel.objWork.OC_Other_Accident);
                p.Add("@OC_Other_Leave", coalMonthlyViewModel.objWork.OC_Other_Leave);
                p.Add("@OC_Other_OtherCause", coalMonthlyViewModel.objWork.OC_Other_OtherCause);
                p.Add("@OC_Other_Total", coalMonthlyViewModel.objWork.OC_Other_Total);
                p.Add("@AG_Men", coalMonthlyViewModel.objWork.AG_Men);
                p.Add("@AG_Women", coalMonthlyViewModel.objWork.AG_Women);
                p.Add("@AG_Sickness", coalMonthlyViewModel.objWork.AG_Sickness);
                p.Add("@AG_Accident", coalMonthlyViewModel.objWork.AG_Accident);
                p.Add("@AG_Leave", coalMonthlyViewModel.objWork.AG_Leave);
                p.Add("@AG_OtherCause", coalMonthlyViewModel.objWork.AG_OtherCause);
                p.Add("@AG_Total", coalMonthlyViewModel.objWork.AG_Total);
                p.Add("@Total_Men", coalMonthlyViewModel.objWork.Total_Men);
                p.Add("@Total_Women", coalMonthlyViewModel.objWork.Total_Women);
                p.Add("@Total_Sickness", coalMonthlyViewModel.objWork.Total_Sickness);
                p.Add("@Total_Accident", coalMonthlyViewModel.objWork.Total_Accident);
                p.Add("@Total_Leave", coalMonthlyViewModel.objWork.Total_Leave);
                p.Add("@Total_OtherCause", coalMonthlyViewModel.objWork.Total_OtherCause);
                p.Add("@Total_All", coalMonthlyViewModel.objWork.Total_All);
                p.Add("@Month_Year", coalMonthlyViewModel.objWork.Month_Year3);
                p.Add("@Belowground_No_Employee", coalMonthlyViewModel.objWork.Belowground_No_Employee);
                p.Add("@Mine_No_Employee", coalMonthlyViewModel.objWork.Mine_No_Employee);
                p.Add("@CreatedBy", coalMonthlyViewModel.UserId);
                p.Add("@Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_CoalMonthlyTableC", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion

        #region Table D
        /// <summary>
        /// To Bind Table D Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>

        public async Task<Table_D_Model> Get_EarnDetails_TableDMonthly(MonthlyReturnModel monthlyReturnModel)
        {
            Table_D_Model table_D_Model = new Table_D_Model();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@Month_Year", monthlyReturnModel.MonthYear);
                param.Add("@Check", 1);
                param.Add("@UserID", monthlyReturnModel.UserId);
                var result = await Connection.QueryAsync<Table_D_Model>("UspGet_CoalMonthlyTableD", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    table_D_Model = result.FirstOrDefault();
                    table_D_Model.Month_Year5 = table_D_Model.Month_Year;
                }
                return table_D_Model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                table_D_Model = null;
            }
        }

        /// <summary>
        /// To Update Table D
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>

        public async Task<MessageEF> Update_Table_D(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@Attendance_earn_Id", coalMonthlyViewModel.objEarn.Attendance_earn_Id);
                p.Add("@BG_OS_Average_att", coalMonthlyViewModel.objEarn.BG_OS_Average_att);
                p.Add("@BG_OS_Aggregate_No", coalMonthlyViewModel.objEarn.BG_OS_Aggregate_No);
                p.Add("@BG_OS_Basic_wages", coalMonthlyViewModel.objEarn.BG_OS_Basic_wages);
                p.Add("@BG_OS_Dearness_allowance", coalMonthlyViewModel.objEarn.BG_OS_Dearness_allowance);
                p.Add("@BG_OS_cash", coalMonthlyViewModel.objEarn.BG_OS_cash);
                p.Add("@BG_OS_Total", coalMonthlyViewModel.objEarn.BG_OS_Total);
                p.Add("@BG_ML_Average_att", coalMonthlyViewModel.objEarn.BG_ML_Average_att);
                p.Add("@BG_ML_Aggregate_No", coalMonthlyViewModel.objEarn.BG_ML_Aggregate_No);
                p.Add("@BG_ML_Basic_wages", coalMonthlyViewModel.objEarn.BG_ML_Basic_wages);
                p.Add("@BG_ML_Dearness_allowance", coalMonthlyViewModel.objEarn.BG_ML_Dearness_allowance);
                p.Add("@BG_ML_cash", coalMonthlyViewModel.objEarn.BG_ML_cash);
                p.Add("@BG_ML_Total", coalMonthlyViewModel.objEarn.BG_ML_Total);
                p.Add("@BG_Other_Average_att", coalMonthlyViewModel.objEarn.BG_Other_Average_att);
                p.Add("@BG_Other_Aggregate_No", coalMonthlyViewModel.objEarn.BG_Other_Aggregate_No);
                p.Add("@BG_Other_Basic_wages", coalMonthlyViewModel.objEarn.BG_Other_Basic_wages);
                p.Add("@BG_Other_Dearness_allowance", coalMonthlyViewModel.objEarn.BG_Other_Dearness_allowance);
                p.Add("@BG_Other_cash", coalMonthlyViewModel.objEarn.BG_Other_cash);
                p.Add("@BG_Other_Total", coalMonthlyViewModel.objEarn.BG_Other_Total);
                p.Add("@OC_OS_Average_att", coalMonthlyViewModel.objEarn.OC_OS_Average_att);
                p.Add("@OC_OS_Aggregate_No", coalMonthlyViewModel.objEarn.OC_OS_Aggregate_No);
                p.Add("@OC_OS_Basic_wages", coalMonthlyViewModel.objEarn.OC_OS_Basic_wages);
                p.Add("@OC_OS_Dearness_allowance", coalMonthlyViewModel.objEarn.OC_OS_Dearness_allowance);
                p.Add("@OC_OS_cash", coalMonthlyViewModel.objEarn.OC_OS_cash);
                p.Add("@OC_OS_Total", coalMonthlyViewModel.objEarn.OC_OS_Total);
                p.Add("@OC_ML_Average_att", coalMonthlyViewModel.objEarn.OC_ML_Average_att);
                p.Add("@OC_ML_Aggregate_No", coalMonthlyViewModel.objEarn.OC_ML_Aggregate_No);
                p.Add("@OC_ML_Basic_wages", coalMonthlyViewModel.objEarn.OC_ML_Basic_wages);
                p.Add("@OC_ML_Dearness_allowance", coalMonthlyViewModel.objEarn.OC_ML_Dearness_allowance);
                p.Add("@OC_ML_cash", coalMonthlyViewModel.objEarn.OC_ML_cash);
                p.Add("@OC_ML_Total", coalMonthlyViewModel.objEarn.OC_ML_Total);
                p.Add("@OC_Other_Average_att", coalMonthlyViewModel.objEarn.OC_Other_Average_att);
                p.Add("@OC_Other_Aggregate_No", coalMonthlyViewModel.objEarn.OC_Other_Aggregate_No);
                p.Add("@OC_Other_Basic_wages", coalMonthlyViewModel.objEarn.OC_Other_Basic_wages);
                p.Add("@OC_Other_Dearness_allowance", coalMonthlyViewModel.objEarn.OC_Other_Dearness_allowance);
                p.Add("@OC_Other_cash", coalMonthlyViewModel.objEarn.OC_Other_cash);
                p.Add("@OC_Other_Total", coalMonthlyViewModel.objEarn.OC_Other_Total);
                p.Add("@AG_CSS_Average_att", coalMonthlyViewModel.objEarn.AG_CSS_Average_att);
                p.Add("@AG_CSS_Aggregate_No", coalMonthlyViewModel.objEarn.AG_CSS_Aggregate_No);
                p.Add("@AG_CSS_Basic_wages", coalMonthlyViewModel.objEarn.AG_CSS_Basic_wages);
                p.Add("@AG_CSS_Dearness_allowance", coalMonthlyViewModel.objEarn.AG_CSS_Dearness_allowance);
                p.Add("@AG_CSS_cash", coalMonthlyViewModel.objEarn.AG_CSS_cash);
                p.Add("@AG_CSS_Total", coalMonthlyViewModel.objEarn.AG_CSS_Total);
                p.Add("@AG_Other_Average_att", coalMonthlyViewModel.objEarn.AG_Other_Average_att);
                p.Add("@AG_Other_Aggregate_No", coalMonthlyViewModel.objEarn.AG_Other_Aggregate_No);
                p.Add("@AG_Other_Basic_wages", coalMonthlyViewModel.objEarn.AG_Other_Basic_wages);
                p.Add("@AG_Other_Dearness_allowance", coalMonthlyViewModel.objEarn.AG_Other_Dearness_allowance);
                p.Add("@AG_Other_cash", coalMonthlyViewModel.objEarn.AG_Other_cash);
                p.Add("@AG_Other_Total", coalMonthlyViewModel.objEarn.AG_Other_Total);
                p.Add("@Total_Estimated_Value", coalMonthlyViewModel.objEarn.Total_Estimated_Value);
                p.Add("@Normal_hrs_production_shifts", coalMonthlyViewModel.objEarn.Normal_hrs_production_shifts);

                p.Add("@First_Shift", coalMonthlyViewModel.objEarn.First_Shift);
                p.Add("@Second_Shift", coalMonthlyViewModel.objEarn.Second_Shift);
                p.Add("@Third_Shift", coalMonthlyViewModel.objEarn.Third_Shift);

                p.Add("@Month_Year", coalMonthlyViewModel.objEarn.Month_Year5);
                p.Add("@ModifiedBy", coalMonthlyViewModel.UserId);
                p.Add("@Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_CoalMonthlyTableD", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// To Add Table D
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>

        public async Task<MessageEF> ADD_Table_D(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@BG_OS_Average_att", coalMonthlyViewModel.objEarn.BG_OS_Average_att);
                p.Add("@BG_OS_Aggregate_No", coalMonthlyViewModel.objEarn.BG_OS_Aggregate_No);
                p.Add("@BG_OS_Basic_wages", coalMonthlyViewModel.objEarn.BG_OS_Basic_wages);
                p.Add("@BG_OS_Dearness_allowance", coalMonthlyViewModel.objEarn.BG_OS_Dearness_allowance);
                p.Add("@BG_OS_cash", coalMonthlyViewModel.objEarn.BG_OS_cash);
                p.Add("@BG_OS_Total", coalMonthlyViewModel.objEarn.BG_OS_Total);
                p.Add("@BG_ML_Average_att", coalMonthlyViewModel.objEarn.BG_ML_Average_att);
                p.Add("@BG_ML_Aggregate_No", coalMonthlyViewModel.objEarn.BG_ML_Aggregate_No);
                p.Add("@BG_ML_Basic_wages", coalMonthlyViewModel.objEarn.BG_ML_Basic_wages);
                p.Add("@BG_ML_Dearness_allowance", coalMonthlyViewModel.objEarn.BG_ML_Dearness_allowance);
                p.Add("@BG_ML_cash", coalMonthlyViewModel.objEarn.BG_ML_cash);
                p.Add("@BG_ML_Total", coalMonthlyViewModel.objEarn.BG_ML_Total);
                p.Add("@BG_Other_Average_att", coalMonthlyViewModel.objEarn.BG_Other_Average_att);
                p.Add("@BG_Other_Aggregate_No", coalMonthlyViewModel.objEarn.BG_Other_Aggregate_No);
                p.Add("@BG_Other_Basic_wages", coalMonthlyViewModel.objEarn.BG_Other_Basic_wages);
                p.Add("@BG_Other_Dearness_allowance", coalMonthlyViewModel.objEarn.BG_Other_Dearness_allowance);
                p.Add("@BG_Other_cash", coalMonthlyViewModel.objEarn.BG_Other_cash);
                p.Add("@BG_Other_Total", coalMonthlyViewModel.objEarn.BG_Other_Total);
                p.Add("@OC_OS_Average_att", coalMonthlyViewModel.objEarn.OC_OS_Average_att);
                p.Add("@OC_OS_Aggregate_No", coalMonthlyViewModel.objEarn.OC_OS_Aggregate_No);
                p.Add("@OC_OS_Basic_wages", coalMonthlyViewModel.objEarn.OC_OS_Basic_wages);
                p.Add("@OC_OS_Dearness_allowance", coalMonthlyViewModel.objEarn.OC_OS_Dearness_allowance);
                p.Add("@OC_OS_cash", coalMonthlyViewModel.objEarn.OC_OS_cash);
                p.Add("@OC_OS_Total", coalMonthlyViewModel.objEarn.OC_OS_Total);
                p.Add("@OC_ML_Average_att", coalMonthlyViewModel.objEarn.OC_ML_Average_att);
                p.Add("@OC_ML_Aggregate_No", coalMonthlyViewModel.objEarn.OC_ML_Aggregate_No);
                p.Add("@OC_ML_Basic_wages", coalMonthlyViewModel.objEarn.OC_ML_Basic_wages);
                p.Add("@OC_ML_Dearness_allowance", coalMonthlyViewModel.objEarn.OC_ML_Dearness_allowance);
                p.Add("@OC_ML_cash", coalMonthlyViewModel.objEarn.OC_ML_cash);
                p.Add("@OC_ML_Total", coalMonthlyViewModel.objEarn.OC_ML_Total);
                p.Add("@OC_Other_Average_att", coalMonthlyViewModel.objEarn.OC_Other_Average_att);
                p.Add("@OC_Other_Aggregate_No", coalMonthlyViewModel.objEarn.OC_Other_Aggregate_No);
                p.Add("@OC_Other_Basic_wages", coalMonthlyViewModel.objEarn.OC_Other_Basic_wages);
                p.Add("@OC_Other_Dearness_allowance", coalMonthlyViewModel.objEarn.OC_Other_Dearness_allowance);
                p.Add("@OC_Other_cash", coalMonthlyViewModel.objEarn.OC_Other_cash);
                p.Add("@OC_Other_Total", coalMonthlyViewModel.objEarn.OC_Other_Total);
                p.Add("@AG_CSS_Average_att", coalMonthlyViewModel.objEarn.AG_CSS_Average_att);
                p.Add("@AG_CSS_Aggregate_No", coalMonthlyViewModel.objEarn.AG_CSS_Aggregate_No);
                p.Add("@AG_CSS_Basic_wages", coalMonthlyViewModel.objEarn.AG_CSS_Basic_wages);
                p.Add("@AG_CSS_Dearness_allowance", coalMonthlyViewModel.objEarn.AG_CSS_Dearness_allowance);
                p.Add("@AG_CSS_cash", coalMonthlyViewModel.objEarn.AG_CSS_cash);
                p.Add("@AG_CSS_Total", coalMonthlyViewModel.objEarn.AG_CSS_Total);
                p.Add("@AG_Other_Average_att", coalMonthlyViewModel.objEarn.AG_Other_Average_att);
                p.Add("@AG_Other_Aggregate_No", coalMonthlyViewModel.objEarn.AG_Other_Aggregate_No);

                p.Add("@AG_Other_Basic_wages", coalMonthlyViewModel.objEarn.AG_Other_Basic_wages);
                p.Add("@AG_Other_Dearness_allowance", coalMonthlyViewModel.objEarn.AG_Other_Dearness_allowance);
                p.Add("@AG_Other_cash", coalMonthlyViewModel.objEarn.AG_Other_cash);
                p.Add("@AG_Other_Total", coalMonthlyViewModel.objEarn.AG_Other_Total);
                p.Add("@Total_Estimated_Value", coalMonthlyViewModel.objEarn.Total_Estimated_Value);
                p.Add("@Normal_hrs_production_shifts", coalMonthlyViewModel.objEarn.Normal_hrs_production_shifts);

                p.Add("@First_Shift", coalMonthlyViewModel.objEarn.First_Shift);
                p.Add("@Second_Shift", coalMonthlyViewModel.objEarn.Second_Shift);
                p.Add("@Third_Shift", coalMonthlyViewModel.objEarn.Third_Shift);

                p.Add("@Month_Year", coalMonthlyViewModel.objEarn.Month_Year5);
                p.Add("@CreatedBy", coalMonthlyViewModel.UserId);
                p.Add("@Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_CoalMonthlyTableD", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        #endregion

        #region Final Submit
        /// <summary>
        /// Monthly Coal Final Submission
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>

        public async Task<MessageEF> Update_FinalSubmit(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@Month_Year", coalMonthlyViewModel.objEarn.Month_Year5);
                p.Add("@CreatedBy", coalMonthlyViewModel.UserId);
                p.Add("@Check", 3);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_CoalMonthlyMineDetails", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        #endregion

        #region Previous Month Closing Stock
        /// <summary>
        /// Get Previous Month Closing Stock
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>

        public async Task<string> PreviousMonthClosingStock(MonthlyReturnModel monthlyReturnModel)
        {

            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@Month_Year", monthlyReturnModel.MonthYear);
                param.Add("@Check", 1);
                param.Add("@UserID", monthlyReturnModel.UserId);
                var result =await Connection.QueryAsync<string>("ereturn_GetPreviousMonthColosingStock", param, commandType: System.Data.CommandType.StoredProcedure);
                string output = "";
                if (result.Count() > 0)
                {
                    output = result.FirstOrDefault();
                }
                return output.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }


        #endregion

        #region Get Mineral Form & Grade
        /// <summary>
        /// Get Mineral Nature
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<MonthlyReturnModel>> GetMineralNature(MonthlyReturnModel monthlyReturnModel)
        {
            List<MonthlyReturnModel> lstmonthlyReturnModels = new List<MonthlyReturnModel>();
            try
            {


                DynamicParameters param = new DynamicParameters();
                param.Add("@MineralId", monthlyReturnModel.MineralId);
                param.Add("@Check", 1);
                param.Add("@UserId", monthlyReturnModel.UserId);
                var result =await Connection.QueryAsync<MonthlyReturnModel>("UspGetMineralForE_Return", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstmonthlyReturnModels = result.ToList();
                }
                return lstmonthlyReturnModels;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstmonthlyReturnModels = null;
            }
        }

        /// <summary>
        /// Get Mineral Grade
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<MonthlyReturnModel>> GetMineralGrade(MonthlyReturnModel monthlyReturnModel)
        {
            List<MonthlyReturnModel> lstmonthlyReturnModels = new List<MonthlyReturnModel>();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@MineralNatureId", monthlyReturnModel.MineralNatureId);
                param.Add("@Check", 2);
                param.Add("@UserId", monthlyReturnModel.UserId);
                var result =await Connection.QueryAsync<MonthlyReturnModel>("UspGetMineralForE_Return", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstmonthlyReturnModels = result.ToList();
                }
                return lstmonthlyReturnModels;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstmonthlyReturnModels = null;
            }
        }
        #endregion
        #endregion
    }
}
