// ***********************************************************************
// Assembly         : Khanij
// Author           : Akshaya Dalei
// Created          : 22-June-2021
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

namespace ReturnApi.Model.eReturnCoalYearly
{
    public class YearlyCoalReturnProvider : RepositoryBase, IYearlyCoalReturnProvider
    {
        public YearlyCoalReturnProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        #region Yearly Coal Return

        #region Yearly Coal Return Details
        /// <summary>
        /// Yearly Coal Return Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>

        public async Task<List<YearlyReturnModel>> GetYearlyReturnDetails(YearlyReturnModel yearlyReturnModel)
        {
            List<YearlyReturnModel> lstYearlyReturnModel = new List<YearlyReturnModel>();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 4);
                param.Add("@FinancialYear", yearlyReturnModel.FinancialYear);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result = await Connection.QueryAsync<YearlyReturnModel>("GetDetailsofMonthlyReturn", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    lstYearlyReturnModel = result.ToList();
                }
                return lstYearlyReturnModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstYearlyReturnModel = null;
            }
        }
        #endregion

        #region Mine Details
        /// <summary>
        /// Lessee Mine Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<CoalYearlyMineDetailsModel> GetLesseMineDeatils(YearlyReturnModel yearlyReturnModel)
        {
            CoalYearlyMineDetailsModel coalYearlyMineDetailsModel = new CoalYearlyMineDetailsModel();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result = await Connection.QueryAsync<CoalYearlyMineDetailsModel>("UspGetForm_F1_Details", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    coalYearlyMineDetailsModel = result.FirstOrDefault();
                }
                return coalYearlyMineDetailsModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                coalYearlyMineDetailsModel = null;
            }
        }

        /// <summary>
        /// Mine Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<CoalYearlyMineDetailsModel> Get_CoalYearlyMineDetails(YearlyReturnModel yearlyReturnModel)
        {
            CoalYearlyMineDetailsModel coalYearlyMineDetailsModel = new CoalYearlyMineDetailsModel();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserID", yearlyReturnModel.UserId);
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 1);
                var result = await Connection.QueryAsync<CoalYearlyMineDetailsModel>("GetCoalYearMineDetails", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    coalYearlyMineDetailsModel = result.FirstOrDefault();
                }
                return coalYearlyMineDetailsModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Add Mine Details
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> ADD_MineDetails(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                if (coalYearlyViewModel.objMine.Certify == true)
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Check", 1);
                    param.Add("@Name_of_mine", coalYearlyViewModel.objMine.Name_of_mine);
                    param.Add("@postal_address_of_mine", coalYearlyViewModel.objMine.postal_address_of_mine);
                    param.Add("@DateOfopening", coalYearlyViewModel.objMine.DateOfopening);
                    param.Add("@Situation_of_Mine", coalYearlyViewModel.objMine.Situation_of_Mine);
                    param.Add("@Tahsil", coalYearlyViewModel.objMine.Tahsil);
                    param.Add("@District", coalYearlyViewModel.objMine.District);
                    param.Add("@State", coalYearlyViewModel.objMine.State);
                    param.Add("@Name_of_Owner", coalYearlyViewModel.objMine.Name_of_Owner);
                    param.Add("@Postal_address_of_owner", coalYearlyViewModel.objMine.Postal_address_of_owner);
                    param.Add("@DateOfclosing", coalYearlyViewModel.objMine.DateOfclosing);
                    param.Add("@Name_of_agents", coalYearlyViewModel.objMine.Name_of_agents);
                    param.Add("@Address_of_agents", coalYearlyViewModel.objMine.Address_of_agents);
                    param.Add("@Name_of_manager", coalYearlyViewModel.objMine.Name_of_manager);
                    param.Add("@Address_of_manager", coalYearlyViewModel.objMine.Address_of_manager);
                    param.Add("@Certify", coalYearlyViewModel.objMine.Certify);
                    param.Add("@Designations", coalYearlyViewModel.objMine.Designations);
                    param.Add("@Numbers_employed", coalYearlyViewModel.objMine.Numbers_employed);
                    param.Add("@Machinery_Used", coalYearlyViewModel.objMine.Machinery_Used);
                    param.Add("@Nature_Of_Power", coalYearlyViewModel.objMine.Nature_Of_Power);
                    param.Add("@Financial_Year", coalYearlyViewModel.objMine.Year);
                    param.Add("@Agent_Name", coalYearlyViewModel.objMine.Agent_Name);
                    param.Add("@Agent_Address", coalYearlyViewModel.objMine.Agent_Address);
                    param.Add("@CreatedBy", coalYearlyViewModel.UserId);
                    param.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    await Connection.QueryAsync<int>("Usp_AnnualReturn_CoalYearMineDetails", param, commandType: CommandType.StoredProcedure);
                    int newID = param.Get<int>("Result");
                    if (newID == 2)
                    {
                        messageEF.Satus = "This Details Already Exit..";
                    }
                    else if (newID == 1)
                    {
                        messageEF.Satus = "Record has been Inserted";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return messageEF;

        }

        /// <summary>
        /// Update Mine Details
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> Update_MineDetails(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                if (coalYearlyViewModel.objMine.Certify == true)
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Check", 2);
                    param.Add("@Coal_Year_Id", coalYearlyViewModel.objMine.Coal_Year_Id);

                    param.Add("@Name_of_mine", coalYearlyViewModel.objMine.Name_of_mine);
                    param.Add("@postal_address_of_mine", coalYearlyViewModel.objMine.postal_address_of_mine);
                    param.Add("@DateOfopening", coalYearlyViewModel.objMine.DateOfopening);
                    param.Add("@Situation_of_Mine", coalYearlyViewModel.objMine.Situation_of_Mine);
                    param.Add("@Tahsil", coalYearlyViewModel.objMine.Tahsil);
                    param.Add("@District", coalYearlyViewModel.objMine.District);
                    param.Add("@State", coalYearlyViewModel.objMine.State);
                    param.Add("@Name_of_Owner", coalYearlyViewModel.objMine.Name_of_Owner);
                    param.Add("@Postal_address_of_owner", coalYearlyViewModel.objMine.Postal_address_of_owner);

                    param.Add("@DateOfclosing", coalYearlyViewModel.objMine.DateOfclosing);
                    param.Add("@Name_of_agents", coalYearlyViewModel.objMine.Name_of_agents);
                    param.Add("@Address_of_agents", coalYearlyViewModel.objMine.Address_of_agents);
                    param.Add("@Name_of_manager", coalYearlyViewModel.objMine.Name_of_manager);
                    param.Add("@Address_of_manager", coalYearlyViewModel.objMine.Address_of_manager);
                    param.Add("@Certify", coalYearlyViewModel.objMine.Certify);
                    param.Add("@Designations", coalYearlyViewModel.objMine.Designations);
                    param.Add("@Numbers_employed", coalYearlyViewModel.objMine.Numbers_employed);
                    param.Add("@Machinery_Used", coalYearlyViewModel.objMine.Machinery_Used);
                    param.Add("@Nature_Of_Power", coalYearlyViewModel.objMine.Nature_Of_Power);

                    param.Add("@Agent_Name", coalYearlyViewModel.objMine.Agent_Name);
                    param.Add("@Agent_Address", coalYearlyViewModel.objMine.Agent_Address);

                    param.Add("@Financial_Year", coalYearlyViewModel.objMine.Year);
                    param.Add("@ModifiedBy", coalYearlyViewModel.UserId);

                    param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                    var result =await Connection.QueryAsync<int>("Usp_AnnualReturn_CoalYearMineDetails", param, commandType: System.Data.CommandType.StoredProcedure);
                    int nweID = param.Get<int>("Result");
                    if (nweID == 2)
                    {
                        messageEF.Satus = "Record Has not Updated..";
                    }
                    else if (nweID == 1)
                    {
                        messageEF.Satus = "Record has been Updated..";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return messageEF;
        }

        #endregion

        #region Table A
        /// <summary>
        /// Get Employment Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<EMPLOYMENT> Get_EMPLOYMENT(YearlyReturnModel yearlyReturnModel)
        {
            EMPLOYMENT eMPLOYMENT = new EMPLOYMENT();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 2);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<EMPLOYMENT>("GetCoalYearMineDetails", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    eMPLOYMENT = result.FirstOrDefault();
                }
                return eMPLOYMENT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                eMPLOYMENT = null;
            }
        }

        /// <summary>
        /// Add Employment
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> ADD_EMPLOYMENT(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                #region Parameters
                param.Add("@NumberofPersons", coalYearlyViewModel.objEmployment.NumberofPersons);
                param.Add("@Belowground_onDay", coalYearlyViewModel.objEmployment.Belowground_onDay);
                param.Add("@Belowground_onDate", coalYearlyViewModel.objEmployment.Belowground_onDatestr);
                param.Add("@Mine_onDay", coalYearlyViewModel.objEmployment.Mine_onDay);
                param.Add("@Mine_onDate", coalYearlyViewModel.objEmployment.Mine_onDatestr);
                param.Add("@BG_Overman_2A", coalYearlyViewModel.objEmployment.BG_Overman_2A);
                param.Add("@BG_Overman_2B", coalYearlyViewModel.objEmployment.BG_Overman_2B);
                param.Add("@BG_Overman_2C", coalYearlyViewModel.objEmployment.BG_Overman_2C);
                param.Add("@BG_Overman_3", coalYearlyViewModel.objEmployment.BG_Overman_3);
                param.Add("@BG_Overman_4A", coalYearlyViewModel.objEmployment.BG_Overman_4A);
                param.Add("@BG_Overman_4B", coalYearlyViewModel.objEmployment.BG_Overman_4B);
                param.Add("@BG_Overman_4C", coalYearlyViewModel.objEmployment.BG_Overman_4C);
                param.Add("@BG_Overman_4D", coalYearlyViewModel.objEmployment.BG_Overman_4D);
                param.Add("@BG_Overman_5", coalYearlyViewModel.objEmployment.BG_Overman_5);
                param.Add("@BG_Mine_Loader_2A", coalYearlyViewModel.objEmployment.BG_Mine_Loader_2A);
                param.Add("@BG_Mine_Loader_2B", coalYearlyViewModel.objEmployment.BG_Mine_Loader_2B);
                param.Add("@BG_Mine_Loader_2C", coalYearlyViewModel.objEmployment.BG_Mine_Loader_2C);
                param.Add("@BG_Mine_Loader_3", coalYearlyViewModel.objEmployment.BG_Mine_Loader_3);
                param.Add("@BG_Mine_Loader_4A", coalYearlyViewModel.objEmployment.BG_Mine_Loader_4A);
                param.Add("@BG_Mine_Loader_4B", coalYearlyViewModel.objEmployment.BG_Mine_Loader_4B);
                param.Add("@BG_Mine_Loader_4C", coalYearlyViewModel.objEmployment.BG_Mine_Loader_4C);
                param.Add("@BG_Mine_Loader_4D", coalYearlyViewModel.objEmployment.BG_Mine_Loader_4D);
                param.Add("@BG_Mine_Loader_5", coalYearlyViewModel.objEmployment.BG_Mine_Loader_5);
                param.Add("@BG_Others_2A", coalYearlyViewModel.objEmployment.BG_Others_2A);
                param.Add("@BG_Others_2B", coalYearlyViewModel.objEmployment.BG_Others_2B);
                param.Add("@BG_Others_2C", coalYearlyViewModel.objEmployment.BG_Others_2C);
                param.Add("@BG_Others_3", coalYearlyViewModel.objEmployment.BG_Others_3);
                param.Add("@BG_Others_4A", coalYearlyViewModel.objEmployment.BG_Others_4A);
                param.Add("@BG_Others_4B", coalYearlyViewModel.objEmployment.BG_Others_4B);
                param.Add("@BG_Others_4C", coalYearlyViewModel.objEmployment.BG_Others_4C);
                param.Add("@BG_Others_4D", coalYearlyViewModel.objEmployment.BG_Others_4D);
                param.Add("@BG_Others_5", coalYearlyViewModel.objEmployment.BG_Others_5);
                param.Add("@OC_Overman_2A", coalYearlyViewModel.objEmployment.OC_Overman_2A);
                param.Add("@OC_Overman_2B", coalYearlyViewModel.objEmployment.OC_Overman_2B);
                param.Add("@OC_Overman_2C", coalYearlyViewModel.objEmployment.OC_Overman_2C);
                param.Add("@OC_Overman_3", coalYearlyViewModel.objEmployment.OC_Overman_3);
                param.Add("@OC_Overman_4A", coalYearlyViewModel.objEmployment.OC_Overman_4A);
                param.Add("@OC_Overman_4B", coalYearlyViewModel.objEmployment.OC_Overman_4B);
                param.Add("@OC_Overman_4C", coalYearlyViewModel.objEmployment.OC_Overman_4C);
                param.Add("@OC_Overman_4D", coalYearlyViewModel.objEmployment.OC_Overman_4D);
                param.Add("@OC_Overman_5", coalYearlyViewModel.objEmployment.OC_Overman_5);
                param.Add("@OC_Mine_Loader_2A", coalYearlyViewModel.objEmployment.OC_Mine_Loader_2A);
                param.Add("@OC_Mine_Loader_2B", coalYearlyViewModel.objEmployment.OC_Mine_Loader_2B);
                param.Add("@OC_Mine_Loader_2C", coalYearlyViewModel.objEmployment.OC_Mine_Loader_2C);
                param.Add("@OC_Mine_Loader_3", coalYearlyViewModel.objEmployment.OC_Mine_Loader_3);
                param.Add("@OC_Mine_Loader_4A", coalYearlyViewModel.objEmployment.OC_Mine_Loader_4A);
                param.Add("@OC_Mine_Loader_4B", coalYearlyViewModel.objEmployment.OC_Mine_Loader_4B);
                param.Add("@OC_Mine_Loader_4C", coalYearlyViewModel.objEmployment.OC_Mine_Loader_4C);
                param.Add("@OC_Mine_Loader_4D", coalYearlyViewModel.objEmployment.OC_Mine_Loader_4D);
                param.Add("@OC_Mine_Loader_5", coalYearlyViewModel.objEmployment.OC_Mine_Loader_5);
                param.Add("@OC_Others_2A", coalYearlyViewModel.objEmployment.OC_Others_2A);
                param.Add("@OC_Others_2B", coalYearlyViewModel.objEmployment.OC_Others_2B);
                param.Add("@OC_Others_2C", coalYearlyViewModel.objEmployment.OC_Others_2C);
                param.Add("@OC_Others_3", coalYearlyViewModel.objEmployment.OC_Others_3);
                param.Add("@OC_Others_4A", coalYearlyViewModel.objEmployment.OC_Others_4A);
                param.Add("@OC_Others_4B", coalYearlyViewModel.objEmployment.OC_Others_4B);
                param.Add("@OC_Others_4C", coalYearlyViewModel.objEmployment.OC_Others_4C);
                param.Add("@OC_Others_4D", coalYearlyViewModel.objEmployment.OC_Others_4D);
                param.Add("@OC_Others_5", coalYearlyViewModel.objEmployment.OC_Others_5);
                param.Add("@CS_staff_2A", coalYearlyViewModel.objEmployment.CS_staff_2A);
                param.Add("@CS_staff_2B", coalYearlyViewModel.objEmployment.CS_staff_2B);
                param.Add("@CS_staff_2C", coalYearlyViewModel.objEmployment.CS_staff_2C);
                param.Add("@CS_staff_3", coalYearlyViewModel.objEmployment.CS_staff_3);
                param.Add("@CS_staff_4A", coalYearlyViewModel.objEmployment.CS_staff_4A);
                param.Add("@CS_staff_4B", coalYearlyViewModel.objEmployment.CS_staff_4B);
                param.Add("@CS_staff_4C", coalYearlyViewModel.objEmployment.CS_staff_4C);
                param.Add("@CS_staff_4D", coalYearlyViewModel.objEmployment.CS_staff_4D);
                param.Add("@CS_staff_5", coalYearlyViewModel.objEmployment.CS_staff_5);
                param.Add("@Workers_2A", coalYearlyViewModel.objEmployment.Workers_2A);
                param.Add("@Workers_2B", coalYearlyViewModel.objEmployment.Workers_2B);
                param.Add("@Workers_2C", coalYearlyViewModel.objEmployment.Workers_2C);
                param.Add("@Workers_3", coalYearlyViewModel.objEmployment.Workers_3);
                param.Add("@Workers_4A", coalYearlyViewModel.objEmployment.Workers_4A);
                param.Add("@Workers_4B", coalYearlyViewModel.objEmployment.Workers_4B);
                param.Add("@Workers_4C", coalYearlyViewModel.objEmployment.Workers_4C);
                param.Add("@Workers_4D", coalYearlyViewModel.objEmployment.Workers_4D);
                param.Add("@Workers_5", coalYearlyViewModel.objEmployment.Workers_5);
                param.Add("@Others_2A", coalYearlyViewModel.objEmployment.Others_2A);
                param.Add("@Others_2B", coalYearlyViewModel.objEmployment.Others_2B);
                param.Add("@Others_2C", coalYearlyViewModel.objEmployment.Others_2C);
                param.Add("@Others_3", coalYearlyViewModel.objEmployment.Others_3);
                param.Add("@Others_4A", coalYearlyViewModel.objEmployment.Others_4A);
                param.Add("@Others_4B", coalYearlyViewModel.objEmployment.Others_4B);
                param.Add("@Others_4C", coalYearlyViewModel.objEmployment.Others_4C);
                param.Add("@Others_4D", coalYearlyViewModel.objEmployment.Others_4D);
                param.Add("@Others_5", coalYearlyViewModel.objEmployment.Others_5);
                param.Add("@Total_2A", coalYearlyViewModel.objEmployment.Total_2A);
                param.Add("@Total_2B", coalYearlyViewModel.objEmployment.Total_2B);
                param.Add("@Total_2C", coalYearlyViewModel.objEmployment.Total_2C);
                param.Add("@Total_3", coalYearlyViewModel.objEmployment.Total_3);
                param.Add("@Total_4A", coalYearlyViewModel.objEmployment.Total_4A);
                param.Add("@Total_4B", coalYearlyViewModel.objEmployment.Total_4B);
                param.Add("@Total_4C", coalYearlyViewModel.objEmployment.Total_4C);
                param.Add("@Total_4D", coalYearlyViewModel.objEmployment.Total_4D);
                param.Add("@Total_5", coalYearlyViewModel.objEmployment.Total_5);

                param.Add("@Belowground_No_Employee", coalYearlyViewModel.objEmployment.Belowground_No_Employee);
                param.Add("@Mine_No_Employee", coalYearlyViewModel.objEmployment.Mine_No_Employee);

                param.Add("@Financial_Year", coalYearlyViewModel.objEmployment.Year);
                param.Add("@CreatedBy", coalYearlyViewModel.UserId);
                #endregion
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturn_CoalYearEmployment", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Inserted";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                coalYearlyViewModel = null;
                messageEF = null;
            }
        }

        /// <summary>
        /// Update Employment
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> Update_EMPLOYMENT(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                #region Parameters
                param.Add("@Employment_Id", coalYearlyViewModel.objEmployment.Employment_Id);
                param.Add("@NumberofPersons", coalYearlyViewModel.objEmployment.NumberofPersons);
                param.Add("@Belowground_onDay", coalYearlyViewModel.objEmployment.Belowground_onDay);
                param.Add("@Belowground_onDate", coalYearlyViewModel.objEmployment.Belowground_onDatestr);
                param.Add("@Mine_onDay", coalYearlyViewModel.objEmployment.Mine_onDay);
                param.Add("@Mine_onDate", coalYearlyViewModel.objEmployment.Mine_onDatestr);
                param.Add("@BG_Overman_2A", coalYearlyViewModel.objEmployment.BG_Overman_2A);
                param.Add("@BG_Overman_2B", coalYearlyViewModel.objEmployment.BG_Overman_2B);
                param.Add("@BG_Overman_2C", coalYearlyViewModel.objEmployment.BG_Overman_2C);
                param.Add("@BG_Overman_3", coalYearlyViewModel.objEmployment.BG_Overman_3);
                param.Add("@BG_Overman_4A", coalYearlyViewModel.objEmployment.BG_Overman_4A);
                param.Add("@BG_Overman_4B", coalYearlyViewModel.objEmployment.BG_Overman_4B);
                param.Add("@BG_Overman_4C", coalYearlyViewModel.objEmployment.BG_Overman_4C);
                param.Add("@BG_Overman_4D", coalYearlyViewModel.objEmployment.BG_Overman_4D);
                param.Add("@BG_Overman_5", coalYearlyViewModel.objEmployment.BG_Overman_5);
                param.Add("@BG_Mine_Loader_2A", coalYearlyViewModel.objEmployment.BG_Mine_Loader_2A);
                param.Add("@BG_Mine_Loader_2B", coalYearlyViewModel.objEmployment.BG_Mine_Loader_2B);
                param.Add("@BG_Mine_Loader_2C", coalYearlyViewModel.objEmployment.BG_Mine_Loader_2C);
                param.Add("@BG_Mine_Loader_3", coalYearlyViewModel.objEmployment.BG_Mine_Loader_3);
                param.Add("@BG_Mine_Loader_4A", coalYearlyViewModel.objEmployment.BG_Mine_Loader_4A);
                param.Add("@BG_Mine_Loader_4B", coalYearlyViewModel.objEmployment.BG_Mine_Loader_4B);
                param.Add("@BG_Mine_Loader_4C", coalYearlyViewModel.objEmployment.BG_Mine_Loader_4C);
                param.Add("@BG_Mine_Loader_4D", coalYearlyViewModel.objEmployment.BG_Mine_Loader_4D);
                param.Add("@BG_Mine_Loader_5", coalYearlyViewModel.objEmployment.BG_Mine_Loader_5);
                param.Add("@BG_Others_2A", coalYearlyViewModel.objEmployment.BG_Others_2A);
                param.Add("@BG_Others_2B", coalYearlyViewModel.objEmployment.BG_Others_2B);
                param.Add("@BG_Others_2C", coalYearlyViewModel.objEmployment.BG_Others_2C);
                param.Add("@BG_Others_3", coalYearlyViewModel.objEmployment.BG_Others_3);
                param.Add("@BG_Others_4A", coalYearlyViewModel.objEmployment.BG_Others_4A);
                param.Add("@BG_Others_4B", coalYearlyViewModel.objEmployment.BG_Others_4B);
                param.Add("@BG_Others_4C", coalYearlyViewModel.objEmployment.BG_Others_4C);
                param.Add("@BG_Others_4D", coalYearlyViewModel.objEmployment.BG_Others_4D);
                param.Add("@BG_Others_5", coalYearlyViewModel.objEmployment.BG_Others_5);
                param.Add("@OC_Overman_2A", coalYearlyViewModel.objEmployment.OC_Overman_2A);
                param.Add("@OC_Overman_2B", coalYearlyViewModel.objEmployment.OC_Overman_2B);
                param.Add("@OC_Overman_2C", coalYearlyViewModel.objEmployment.OC_Overman_2C);
                param.Add("@OC_Overman_3", coalYearlyViewModel.objEmployment.OC_Overman_3);
                param.Add("@OC_Overman_4A", coalYearlyViewModel.objEmployment.OC_Overman_4A);
                param.Add("@OC_Overman_4B", coalYearlyViewModel.objEmployment.OC_Overman_4B);
                param.Add("@OC_Overman_4C", coalYearlyViewModel.objEmployment.OC_Overman_4C);
                param.Add("@OC_Overman_4D", coalYearlyViewModel.objEmployment.OC_Overman_4D);
                param.Add("@OC_Overman_5", coalYearlyViewModel.objEmployment.OC_Overman_5);
                param.Add("@OC_Mine_Loader_2A", coalYearlyViewModel.objEmployment.OC_Mine_Loader_2A);
                param.Add("@OC_Mine_Loader_2B", coalYearlyViewModel.objEmployment.OC_Mine_Loader_2B);
                param.Add("@OC_Mine_Loader_2C", coalYearlyViewModel.objEmployment.OC_Mine_Loader_2C);
                param.Add("@OC_Mine_Loader_3", coalYearlyViewModel.objEmployment.OC_Mine_Loader_3);
                param.Add("@OC_Mine_Loader_4A", coalYearlyViewModel.objEmployment.OC_Mine_Loader_4A);
                param.Add("@OC_Mine_Loader_4B", coalYearlyViewModel.objEmployment.OC_Mine_Loader_4B);
                param.Add("@OC_Mine_Loader_4C", coalYearlyViewModel.objEmployment.OC_Mine_Loader_4C);
                param.Add("@OC_Mine_Loader_4D", coalYearlyViewModel.objEmployment.OC_Mine_Loader_4D);
                param.Add("@OC_Mine_Loader_5", coalYearlyViewModel.objEmployment.OC_Mine_Loader_5);
                param.Add("@OC_Others_2A", coalYearlyViewModel.objEmployment.OC_Others_2A);
                param.Add("@OC_Others_2B", coalYearlyViewModel.objEmployment.OC_Others_2B);
                param.Add("@OC_Others_2C", coalYearlyViewModel.objEmployment.OC_Others_2C);
                param.Add("@OC_Others_3", coalYearlyViewModel.objEmployment.OC_Others_3);
                param.Add("@OC_Others_4A", coalYearlyViewModel.objEmployment.OC_Others_4A);
                param.Add("@OC_Others_4B", coalYearlyViewModel.objEmployment.OC_Others_4B);
                param.Add("@OC_Others_4C", coalYearlyViewModel.objEmployment.OC_Others_4C);
                param.Add("@OC_Others_4D", coalYearlyViewModel.objEmployment.OC_Others_4D);
                param.Add("@OC_Others_5", coalYearlyViewModel.objEmployment.OC_Others_5);
                param.Add("@CS_staff_2A", coalYearlyViewModel.objEmployment.CS_staff_2A);
                param.Add("@CS_staff_2B", coalYearlyViewModel.objEmployment.CS_staff_2B);
                param.Add("@CS_staff_2C", coalYearlyViewModel.objEmployment.CS_staff_2C);
                param.Add("@CS_staff_3", coalYearlyViewModel.objEmployment.CS_staff_3);
                param.Add("@CS_staff_4A", coalYearlyViewModel.objEmployment.CS_staff_4A);
                param.Add("@CS_staff_4B", coalYearlyViewModel.objEmployment.CS_staff_4B);
                param.Add("@CS_staff_4C", coalYearlyViewModel.objEmployment.CS_staff_4C);
                param.Add("@CS_staff_4D", coalYearlyViewModel.objEmployment.CS_staff_4D);
                param.Add("@CS_staff_5", coalYearlyViewModel.objEmployment.CS_staff_5);
                param.Add("@Workers_2A", coalYearlyViewModel.objEmployment.Workers_2A);
                param.Add("@Workers_2B", coalYearlyViewModel.objEmployment.Workers_2B);
                param.Add("@Workers_2C", coalYearlyViewModel.objEmployment.Workers_2C);
                param.Add("@Workers_3", coalYearlyViewModel.objEmployment.Workers_3);
                param.Add("@Workers_4A", coalYearlyViewModel.objEmployment.Workers_4A);
                param.Add("@Workers_4B", coalYearlyViewModel.objEmployment.Workers_4B);
                param.Add("@Workers_4C", coalYearlyViewModel.objEmployment.Workers_4C);
                param.Add("@Workers_4D", coalYearlyViewModel.objEmployment.Workers_4D);
                param.Add("@Workers_5", coalYearlyViewModel.objEmployment.Workers_5);
                param.Add("@Others_2A", coalYearlyViewModel.objEmployment.Others_2A);
                param.Add("@Others_2B", coalYearlyViewModel.objEmployment.Others_2B);
                param.Add("@Others_2C", coalYearlyViewModel.objEmployment.Others_2C);
                param.Add("@Others_3", coalYearlyViewModel.objEmployment.Others_3);
                param.Add("@Others_4A", coalYearlyViewModel.objEmployment.Others_4A);
                param.Add("@Others_4B", coalYearlyViewModel.objEmployment.Others_4B);
                param.Add("@Others_4C", coalYearlyViewModel.objEmployment.Others_4C);
                param.Add("@Others_4D", coalYearlyViewModel.objEmployment.Others_4D);
                param.Add("@Others_5", coalYearlyViewModel.objEmployment.Others_5);
                param.Add("@Total_2A", coalYearlyViewModel.objEmployment.Total_2A);
                param.Add("@Total_2B", coalYearlyViewModel.objEmployment.Total_2B);
                param.Add("@Total_2C", coalYearlyViewModel.objEmployment.Total_2C);
                param.Add("@Total_3", coalYearlyViewModel.objEmployment.Total_3);
                param.Add("@Total_4A", coalYearlyViewModel.objEmployment.Total_4A);
                param.Add("@Total_4B", coalYearlyViewModel.objEmployment.Total_4B);
                param.Add("@Total_4C", coalYearlyViewModel.objEmployment.Total_4C);
                param.Add("@Total_4D", coalYearlyViewModel.objEmployment.Total_4D);
                param.Add("@Total_5", coalYearlyViewModel.objEmployment.Total_5);

                param.Add("@Belowground_No_Employee", coalYearlyViewModel.objEmployment.Belowground_No_Employee);
                param.Add("@Mine_No_Employee", coalYearlyViewModel.objEmployment.Mine_No_Employee);

                param.Add("@Financial_Year", coalYearlyViewModel.objEmployment.Year);
                param.Add("@ModifiedBy", coalYearlyViewModel.UserId);
                #endregion

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturn_CoalYearEmployment", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "Record Has not Updated..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Updated..";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                coalYearlyViewModel = null;
                messageEF = null;
            }
        }

        #endregion

        #region Table B
        /// <summary>
        /// To Get ELECTRICAL APPARTATUS Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<ELECTRICAL_APPARTATUS> Get_ELECTRICAL_APPARTATUS(YearlyReturnModel yearlyReturnModel)
        {
            ELECTRICAL_APPARTATUS eLECTRICAL_APPARTATUS = new ELECTRICAL_APPARTATUS();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 3);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<ELECTRICAL_APPARTATUS>("GetCoalYearMineDetails", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    eLECTRICAL_APPARTATUS = result.FirstOrDefault();
                }
                return eLECTRICAL_APPARTATUS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                yearlyReturnModel = null;
                eLECTRICAL_APPARTATUS = null;
            }
        }

        /// <summary>
        /// To Add ELECTRICAL APPARTATUS Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> ADD_ELECTRICAL_APPARTATUS(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                #region Parameters                  
                param.Add("@Generated_OwnUse", coalYearlyViewModel.objElectrical.Generated_OwnUse);
                param.Add("@Purchased_OwnUse", coalYearlyViewModel.objElectrical.Purchased_OwnUse);
                param.Add("@Generated_Sale", coalYearlyViewModel.objElectrical.Generated_Sale);
                param.Add("@Purchased_Sale", coalYearlyViewModel.objElectrical.Purchased_Sale);
                param.Add("@Voltageofsupply", coalYearlyViewModel.objElectrical.Voltageofsupply);
                param.Add("@Periodicity", coalYearlyViewModel.objElectrical.Periodicity);
                param.Add("@Source_of_supply", coalYearlyViewModel.objElectrical.Source_of_supply);
                param.Add("@Ag_Lighting", coalYearlyViewModel.objElectrical.Ag_Lighting);
                param.Add("@Bg_Lighting", coalYearlyViewModel.objElectrical.Bg_Lighting);
                param.Add("@Ag_Power", coalYearlyViewModel.objElectrical.Ag_Power);
                param.Add("@Bg_Power", coalYearlyViewModel.objElectrical.Bg_Power);
                param.Add("@High_pressure", coalYearlyViewModel.objElectrical.High_pressure);
                param.Add("@Medium_pressure", coalYearlyViewModel.objElectrical.Medium_pressure);
                param.Add("@A1_Winding_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Winding_NoOfUnit_Use);
                param.Add("@A1_Winding_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Winding_TotalHP_Use);
                param.Add("@A1_Winding_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Winding_NoOfUnit_Reserve);
                param.Add("@A1_Winding_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Winding_TotalHP_Reserve);
                param.Add("@A1_Ventilation_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Ventilation_NoOfUnit_Use);
                param.Add("@A1_Ventilation_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Ventilation_TotalHP_Use);
                param.Add("@A1_Ventilation_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Ventilation_NoOfUnit_Reserve);
                param.Add("@A1_Ventilation_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Ventilation_TotalHP_Reserve);
                param.Add("@A1_Haulage_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Haulage_NoOfUnit_Use);
                param.Add("@A1_Haulage_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Haulage_TotalHP_Use);
                param.Add("@A1_Haulage_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Haulage_NoOfUnit_Reserve);
                param.Add("@A1_Haulage_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Haulage_TotalHP_Reserve);
                param.Add("@A1_Pumping_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Pumping_NoOfUnit_Use);
                param.Add("@A1_Pumping_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Pumping_TotalHP_Use);
                param.Add("@A1_Pumping_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Pumping_NoOfUnit_Reserve);
                param.Add("@A1_Pumping_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Pumping_TotalHP_Reserve);
                param.Add("@A1_Coalwashing_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Coalwashing_NoOfUnit_Use);
                param.Add("@A1_Coalwashing_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Coalwashing_TotalHP_Use);
                param.Add("@A1_Coalwashing_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Coalwashing_NoOfUnit_Reserve);
                param.Add("@A1_Coalwashing_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Coalwashing_TotalHP_Reserve);
                param.Add("@A1_Workshops_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Workshops_NoOfUnit_Use);
                param.Add("@A1_Workshops_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Workshops_TotalHP_Use);
                param.Add("@A1_Workshops_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Workshops_NoOfUnit_Reserve);
                param.Add("@A1_Workshops_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Workshops_TotalHP_Reserve);
                param.Add("@A1_Miscellaneous", coalYearlyViewModel.objElectrical.A1_Miscellaneous);
                param.Add("@A1_Miscellaneous_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Miscellaneous_NoOfUnit_Use);
                param.Add("@A1_Miscellaneous_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Miscellaneous_TotalHP_Use);
                param.Add("@A1_Miscellaneous_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Miscellaneous_NoOfUnit_Reserve);
                param.Add("@A1_Miscellaneous_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Miscellaneous_TotalHP_Reserve);
                param.Add("@A1_Total_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Total_NoOfUnit_Use);
                param.Add("@A1_Total_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Total_TotalHP_Use);
                param.Add("@A1_Total_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Total_NoOfUnit_Reserve);
                param.Add("@A1_Total_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Total_TotalHP_Reserve);
                param.Add("@A2_Winding_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Winding_NoOfUnit_Use);
                param.Add("@A2_Winding_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Winding_TotalHP_Use);
                param.Add("@A2_Winding_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Winding_NoOfUnit_Reserve);
                param.Add("@A2_Winding_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Winding_TotalHP_Reserve);
                param.Add("@A2_Haulage_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Haulage_NoOfUnit_Use);
                param.Add("@A2_Haulage_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Haulage_TotalHP_Use);
                param.Add("@A2_Haulage_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Haulage_NoOfUnit_Reserve);
                param.Add("@A2_Haulage_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Haulage_TotalHP_Reserve);
                param.Add("@A2_Ventilation_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Ventilation_NoOfUnit_Use);
                param.Add("@A2_Ventilation_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Ventilation_TotalHP_Use);
                param.Add("@A2_Ventilation_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Ventilation_NoOfUnit_Reserve);
                param.Add("@A2_Ventilation_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Ventilation_TotalHP_Reserve);
                param.Add("@A2_Pumping_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Pumping_NoOfUnit_Use);
                param.Add("@A2_Pumping_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Pumping_TotalHP_Use);
                param.Add("@A2_Pumping_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Pumping_NoOfUnit_Reserve);
                param.Add("@A2_Pumping_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Pumping_TotalHP_Reserve);
                param.Add("@A2_Other_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Other_NoOfUnit_Use);
                param.Add("@A2_Other_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Other_TotalHP_Use);
                param.Add("@A2_Other_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Other_NoOfUnit_Reserve);
                param.Add("@A2_Other_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Other_TotalHP_Reserve);
                param.Add("@A2_Conveyors_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Conveyors_NoOfUnit_Use);
                param.Add("@A2_Conveyors_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Conveyors_TotalHP_Use);
                param.Add("@A2_Conveyors_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Conveyors_NoOfUnit_Reserve);
                param.Add("@A2_Conveyors_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Conveyors_TotalHP_Reserve);
                param.Add("@A2_Electric_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Electric_NoOfUnit_Use);
                param.Add("@A2_Electric_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Electric_TotalHP_Use);
                param.Add("@A2_Electric_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Electric_NoOfUnit_Reserve);
                param.Add("@A2_Electric_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Electric_TotalHP_Reserve);
                param.Add("@A2_Miscellaneous", coalYearlyViewModel.objElectrical.A2_Miscellaneous);
                param.Add("@A2_Miscellaneous_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Miscellaneous_NoOfUnit_Use);
                param.Add("@A2_Miscellaneous_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Miscellaneous_TotalHP_Use);
                param.Add("@A2_Miscellaneous_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Miscellaneous_NoOfUnit_Reserve);
                param.Add("@A2_Miscellaneous_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Miscellaneous_TotalHP_Reserve);
                param.Add("@A2_Total_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Total_NoOfUnit_Use);
                param.Add("@A2_Total_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Total_TotalHP_Use);
                param.Add("@A2_Total_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Total_NoOfUnit_Reserve);
                param.Add("@A2_Total_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Total_TotalHP_Reserve);
                param.Add("@B_Haulage_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Haulage_NoOfUnit_Use);
                param.Add("@B_Haulage_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Haulage_TotalHP_Use);
                param.Add("@B_Haulage_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Haulage_NoOfUnit_Reserve);
                param.Add("@B_Haulage_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Haulage_TotalHP_Reserve);
                param.Add("@B_Ventilation_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Ventilation_NoOfUnit_Use);
                param.Add("@B_Ventilation_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Ventilation_TotalHP_Use);
                param.Add("@B_Ventilation_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Ventilation_NoOfUnit_Reserve);
                param.Add("@B_Ventilation_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Ventilation_TotalHP_Reserve);
                param.Add("@B_Pumping_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Pumping_NoOfUnit_Use);
                param.Add("@B_Pumping_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Pumping_TotalHP_Use);
                param.Add("@B_Pumping_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Pumping_NoOfUnit_Reserve);
                param.Add("@B_Pumping_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Pumping_TotalHP_Reserve);
                param.Add("@B_Coal_cutting_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Coal_cutting_NoOfUnit_Use);
                param.Add("@B_Coal_cutting_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Coal_cutting_TotalHP_Use);
                param.Add("@B_Coal_cutting_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Coal_cutting_NoOfUnit_Reserve);
                param.Add("@B_Coal_cutting_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Coal_cutting_TotalHP_Reserve);
                param.Add("@B_Other_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Other_NoOfUnit_Use);
                param.Add("@B_Other_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Other_TotalHP_Use);
                param.Add("@B_Other_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Other_NoOfUnit_Reserve);
                param.Add("@B_Other_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Other_TotalHP_Reserve);
                param.Add("@B_Conveyors_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Conveyors_NoOfUnit_Use);
                param.Add("@B_Conveyors_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Conveyors_TotalHP_Use);
                param.Add("@B_Conveyors_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Conveyors_NoOfUnit_Reserve);
                param.Add("@B_Conveyors_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Conveyors_TotalHP_Reserve);
                param.Add("@B_Electric_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Electric_NoOfUnit_Use);
                param.Add("@B_Electric_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Electric_TotalHP_Use);
                param.Add("@B_Electric_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Electric_NoOfUnit_Reserve);
                param.Add("@B_Electric_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Electric_TotalHP_Reserve);
                param.Add("@B_Miscellaneous", coalYearlyViewModel.objElectrical.B_Miscellaneous);
                param.Add("@B_Miscellaneous_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Miscellaneous_NoOfUnit_Use);
                param.Add("@B_Miscellaneous_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Miscellaneous_TotalHP_Use);
                param.Add("@B_Miscellaneous_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Miscellaneous_NoOfUnit_Reserve);
                param.Add("@B_Miscellaneous_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Miscellaneous_TotalHP_Reserve);
                param.Add("@B_Total_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Total_NoOfUnit_Use);
                param.Add("@B_Total_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Total_TotalHP_Use);
                param.Add("@B_Total_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Total_NoOfUnit_Reserve);
                param.Add("@B_Total_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Total_TotalHP_Reserve);

                param.Add("@Financial_Year", coalYearlyViewModel.objElectrical.Year);
                param.Add("@CreatedBy", coalYearlyViewModel.UserId);
                #endregion
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturn_CoalYearELECTRICAL", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Inserted";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                coalYearlyViewModel = null;
                messageEF = null;

            }
        }

        /// <summary>
        /// To Update ELECTRICAL APPARTATUS Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> Update_ELECTRICAL_APPARTATUS(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                #region Parameters
                param.Add("@Electrical_Appartatus_Id", coalYearlyViewModel.objElectrical.Electrical_Appartatus_Id);
                param.Add("@Generated_OwnUse", coalYearlyViewModel.objElectrical.Generated_OwnUse);
                param.Add("@Purchased_OwnUse", coalYearlyViewModel.objElectrical.Purchased_OwnUse);
                param.Add("@Generated_Sale", coalYearlyViewModel.objElectrical.Generated_Sale);
                param.Add("@Purchased_Sale", coalYearlyViewModel.objElectrical.Purchased_Sale);
                param.Add("@Voltageofsupply", coalYearlyViewModel.objElectrical.Voltageofsupply);
                param.Add("@Periodicity", coalYearlyViewModel.objElectrical.Periodicity);
                param.Add("@Source_of_supply", coalYearlyViewModel.objElectrical.Source_of_supply);
                param.Add("@Ag_Lighting", coalYearlyViewModel.objElectrical.Ag_Lighting);
                param.Add("@Bg_Lighting", coalYearlyViewModel.objElectrical.Bg_Lighting);
                param.Add("@Ag_Power", coalYearlyViewModel.objElectrical.Ag_Power);
                param.Add("@Bg_Power", coalYearlyViewModel.objElectrical.Bg_Power);
                param.Add("@High_pressure", coalYearlyViewModel.objElectrical.High_pressure);
                param.Add("@Medium_pressure", coalYearlyViewModel.objElectrical.Medium_pressure);
                param.Add("@A1_Winding_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Winding_NoOfUnit_Use);
                param.Add("@A1_Winding_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Winding_TotalHP_Use);
                param.Add("@A1_Winding_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Winding_NoOfUnit_Reserve);
                param.Add("@A1_Winding_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Winding_TotalHP_Reserve);
                param.Add("@A1_Ventilation_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Ventilation_NoOfUnit_Use);
                param.Add("@A1_Ventilation_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Ventilation_TotalHP_Use);
                param.Add("@A1_Ventilation_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Ventilation_NoOfUnit_Reserve);
                param.Add("@A1_Ventilation_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Ventilation_TotalHP_Reserve);
                param.Add("@A1_Haulage_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Haulage_NoOfUnit_Use);
                param.Add("@A1_Haulage_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Haulage_TotalHP_Use);
                param.Add("@A1_Haulage_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Haulage_NoOfUnit_Reserve);
                param.Add("@A1_Haulage_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Haulage_TotalHP_Reserve);
                param.Add("@A1_Pumping_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Pumping_NoOfUnit_Use);
                param.Add("@A1_Pumping_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Pumping_TotalHP_Use);
                param.Add("@A1_Pumping_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Pumping_NoOfUnit_Reserve);
                param.Add("@A1_Pumping_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Pumping_TotalHP_Reserve);
                param.Add("@A1_Coalwashing_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Coalwashing_NoOfUnit_Use);
                param.Add("@A1_Coalwashing_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Coalwashing_TotalHP_Use);
                param.Add("@A1_Coalwashing_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Coalwashing_NoOfUnit_Reserve);
                param.Add("@A1_Coalwashing_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Coalwashing_TotalHP_Reserve);
                param.Add("@A1_Workshops_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Workshops_NoOfUnit_Use);
                param.Add("@A1_Workshops_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Workshops_TotalHP_Use);
                param.Add("@A1_Workshops_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Workshops_NoOfUnit_Reserve);
                param.Add("@A1_Workshops_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Workshops_TotalHP_Reserve);
                param.Add("@A1_Miscellaneous", coalYearlyViewModel.objElectrical.A1_Miscellaneous);
                param.Add("@A1_Miscellaneous_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Miscellaneous_NoOfUnit_Use);
                param.Add("@A1_Miscellaneous_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Miscellaneous_TotalHP_Use);
                param.Add("@A1_Miscellaneous_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Miscellaneous_NoOfUnit_Reserve);
                param.Add("@A1_Miscellaneous_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Miscellaneous_TotalHP_Reserve);
                param.Add("@A1_Total_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A1_Total_NoOfUnit_Use);
                param.Add("@A1_Total_TotalHP_Use", coalYearlyViewModel.objElectrical.A1_Total_TotalHP_Use);
                param.Add("@A1_Total_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A1_Total_NoOfUnit_Reserve);
                param.Add("@A1_Total_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A1_Total_TotalHP_Reserve);
                param.Add("@A2_Winding_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Winding_NoOfUnit_Use);
                param.Add("@A2_Winding_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Winding_TotalHP_Use);
                param.Add("@A2_Winding_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Winding_NoOfUnit_Reserve);
                param.Add("@A2_Winding_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Winding_TotalHP_Reserve);
                param.Add("@A2_Haulage_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Haulage_NoOfUnit_Use);
                param.Add("@A2_Haulage_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Haulage_TotalHP_Use);
                param.Add("@A2_Haulage_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Haulage_NoOfUnit_Reserve);
                param.Add("@A2_Haulage_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Haulage_TotalHP_Reserve);
                param.Add("@A2_Ventilation_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Ventilation_NoOfUnit_Use);
                param.Add("@A2_Ventilation_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Ventilation_TotalHP_Use);
                param.Add("@A2_Ventilation_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Ventilation_NoOfUnit_Reserve);
                param.Add("@A2_Ventilation_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Ventilation_TotalHP_Reserve);
                param.Add("@A2_Pumping_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Pumping_NoOfUnit_Use);
                param.Add("@A2_Pumping_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Pumping_TotalHP_Use);
                param.Add("@A2_Pumping_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Pumping_NoOfUnit_Reserve);
                param.Add("@A2_Pumping_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Pumping_TotalHP_Reserve);
                param.Add("@A2_Other_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Other_NoOfUnit_Use);
                param.Add("@A2_Other_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Other_TotalHP_Use);
                param.Add("@A2_Other_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Other_NoOfUnit_Reserve);
                param.Add("@A2_Other_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Other_TotalHP_Reserve);
                param.Add("@A2_Conveyors_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Conveyors_NoOfUnit_Use);
                param.Add("@A2_Conveyors_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Conveyors_TotalHP_Use);
                param.Add("@A2_Conveyors_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Conveyors_NoOfUnit_Reserve);
                param.Add("@A2_Conveyors_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Conveyors_TotalHP_Reserve);
                param.Add("@A2_Electric_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Electric_NoOfUnit_Use);
                param.Add("@A2_Electric_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Electric_TotalHP_Use);
                param.Add("@A2_Electric_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Electric_NoOfUnit_Reserve);
                param.Add("@A2_Electric_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Electric_TotalHP_Reserve);
                param.Add("@A2_Miscellaneous", coalYearlyViewModel.objElectrical.A2_Miscellaneous);
                param.Add("@A2_Miscellaneous_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Miscellaneous_NoOfUnit_Use);
                param.Add("@A2_Miscellaneous_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Miscellaneous_TotalHP_Use);
                param.Add("@A2_Miscellaneous_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Miscellaneous_NoOfUnit_Reserve);
                param.Add("@A2_Miscellaneous_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Miscellaneous_TotalHP_Reserve);
                param.Add("@A2_Total_NoOfUnit_Use", coalYearlyViewModel.objElectrical.A2_Total_NoOfUnit_Use);
                param.Add("@A2_Total_TotalHP_Use", coalYearlyViewModel.objElectrical.A2_Total_TotalHP_Use);
                param.Add("@A2_Total_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.A2_Total_NoOfUnit_Reserve);
                param.Add("@A2_Total_TotalHP_Reserve", coalYearlyViewModel.objElectrical.A2_Total_TotalHP_Reserve);
                param.Add("@B_Haulage_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Haulage_NoOfUnit_Use);
                param.Add("@B_Haulage_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Haulage_TotalHP_Use);
                param.Add("@B_Haulage_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Haulage_NoOfUnit_Reserve);
                param.Add("@B_Haulage_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Haulage_TotalHP_Reserve);
                param.Add("@B_Ventilation_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Ventilation_NoOfUnit_Use);
                param.Add("@B_Ventilation_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Ventilation_TotalHP_Use);
                param.Add("@B_Ventilation_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Ventilation_NoOfUnit_Reserve);
                param.Add("@B_Ventilation_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Ventilation_TotalHP_Reserve);
                param.Add("@B_Pumping_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Pumping_NoOfUnit_Use);
                param.Add("@B_Pumping_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Pumping_TotalHP_Use);
                param.Add("@B_Pumping_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Pumping_NoOfUnit_Reserve);
                param.Add("@B_Pumping_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Pumping_TotalHP_Reserve);
                param.Add("@B_Coal_cutting_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Coal_cutting_NoOfUnit_Use);
                param.Add("@B_Coal_cutting_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Coal_cutting_TotalHP_Use);
                param.Add("@B_Coal_cutting_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Coal_cutting_NoOfUnit_Reserve);
                param.Add("@B_Coal_cutting_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Coal_cutting_TotalHP_Reserve);
                param.Add("@B_Other_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Other_NoOfUnit_Use);
                param.Add("@B_Other_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Other_TotalHP_Use);
                param.Add("@B_Other_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Other_NoOfUnit_Reserve);
                param.Add("@B_Other_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Other_TotalHP_Reserve);
                param.Add("@B_Conveyors_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Conveyors_NoOfUnit_Use);
                param.Add("@B_Conveyors_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Conveyors_TotalHP_Use);
                param.Add("@B_Conveyors_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Conveyors_NoOfUnit_Reserve);
                param.Add("@B_Conveyors_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Conveyors_TotalHP_Reserve);
                param.Add("@B_Electric_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Electric_NoOfUnit_Use);
                param.Add("@B_Electric_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Electric_TotalHP_Use);
                param.Add("@B_Electric_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Electric_NoOfUnit_Reserve);
                param.Add("@B_Electric_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Electric_TotalHP_Reserve);
                param.Add("@B_Miscellaneous", coalYearlyViewModel.objElectrical.B_Miscellaneous);
                param.Add("@B_Miscellaneous_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Miscellaneous_NoOfUnit_Use);
                param.Add("@B_Miscellaneous_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Miscellaneous_TotalHP_Use);
                param.Add("@B_Miscellaneous_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Miscellaneous_NoOfUnit_Reserve);
                param.Add("@B_Miscellaneous_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Miscellaneous_TotalHP_Reserve);
                param.Add("@B_Total_NoOfUnit_Use", coalYearlyViewModel.objElectrical.B_Total_NoOfUnit_Use);
                param.Add("@B_Total_TotalHP_Use", coalYearlyViewModel.objElectrical.B_Total_TotalHP_Use);
                param.Add("@B_Total_NoOfUnit_Reserve", coalYearlyViewModel.objElectrical.B_Total_NoOfUnit_Reserve);
                param.Add("@B_Total_TotalHP_Reserve", coalYearlyViewModel.objElectrical.B_Total_TotalHP_Reserve);



                param.Add("@Financial_Year", coalYearlyViewModel.objElectrical.Year);
                param.Add("@CreatedBy", coalYearlyViewModel.UserId);
                #endregion

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await  Connection.QueryAsync<int>("Usp_AnnualReturn_CoalYearELECTRICAL", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "Record Has not Updated..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Updated..";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                messageEF = null;
                coalYearlyViewModel = null;
            }
        }

        #endregion

        #region Table C
        /// <summary>
        /// To Get MACHINERY EQUIPMENT Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<MACHINERY_EQUIPMENT> Get_MACHINERY_EQUIPMENT(YearlyReturnModel yearlyReturnModel)
        {
            MACHINERY_EQUIPMENT mACHINERY_EQUIPMENT = new MACHINERY_EQUIPMENT();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 4);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<MACHINERY_EQUIPMENT>("GetCoalYearMineDetails", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    mACHINERY_EQUIPMENT = result.FirstOrDefault();
                }
                return mACHINERY_EQUIPMENT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mACHINERY_EQUIPMENT = null;
                yearlyReturnModel = null;
            }
        }

        /// <summary>
        /// To ADD MACHINERY EQUIPMENT Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> ADD_MACHINERY_EQUIPMENT(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                #region Parameters
                param.Add("@Boilers_NoOfUnit_Use", coalYearlyViewModel.objMachinery.Boilers_NoOfUnit_Use);
                param.Add("@Boilers_TotalHP_Use", coalYearlyViewModel.objMachinery.Boilers_TotalHP_Use);
                param.Add("@Boilers_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.Boilers_NoOfUnit_Reserve);
                param.Add("@Boilers_TotalHP_Reserve", coalYearlyViewModel.objMachinery.Boilers_TotalHP_Reserve);
                param.Add("@SteamTurbines_NoOfUnit_Use", coalYearlyViewModel.objMachinery.SteamTurbines_NoOfUnit_Use);
                param.Add("@SteamTurbines_TotalHP_Use", coalYearlyViewModel.objMachinery.SteamTurbines_TotalHP_Use);
                param.Add("@SteamTurbines_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.SteamTurbines_NoOfUnit_Reserve);
                param.Add("@SteamTurbines_TotalHP_Reserve", coalYearlyViewModel.objMachinery.SteamTurbines_TotalHP_Reserve);
                param.Add("@DieselEngines_NoOfUnit_Use", coalYearlyViewModel.objMachinery.DieselEngines_NoOfUnit_Use);
                param.Add("@DieselEngines_TotalHP_Use", coalYearlyViewModel.objMachinery.DieselEngines_TotalHP_Use);
                param.Add("@DieselEngines_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.DieselEngines_NoOfUnit_Reserve);
                param.Add("@DieselEngines_TotalHP_Reserve", coalYearlyViewModel.objMachinery.DieselEngines_TotalHP_Reserve);
                param.Add("@Gasoline_NoOfUnit_Use", coalYearlyViewModel.objMachinery.Gasoline_NoOfUnit_Use);
                param.Add("@Gasoline_TotalHP_Use", coalYearlyViewModel.objMachinery.Gasoline_TotalHP_Use);
                param.Add("@Gasoline_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.Gasoline_NoOfUnit_Reserve);
                param.Add("@Gasoline_TotalHP_Reserve", coalYearlyViewModel.objMachinery.Gasoline_TotalHP_Reserve);
                param.Add("@HydraulicTurbines_NoOfUnit_Use", coalYearlyViewModel.objMachinery.HydraulicTurbines_NoOfUnit_Use);
                param.Add("@HydraulicTurbines_TotalHP_Use", coalYearlyViewModel.objMachinery.HydraulicTurbines_TotalHP_Use);
                param.Add("@HydraulicTurbines_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.HydraulicTurbines_NoOfUnit_Reserve);
                param.Add("@HydraulicTurbines_TotalHP_Reserve", coalYearlyViewModel.objMachinery.HydraulicTurbines_TotalHP_Reserve);
                param.Add("@AirCompressors_NoOfUnit_Use", coalYearlyViewModel.objMachinery.AirCompressors_NoOfUnit_Use);
                param.Add("@AirCompressors_TotalHP_Use", coalYearlyViewModel.objMachinery.AirCompressors_TotalHP_Use);
                param.Add("@AirCompressors_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.AirCompressors_NoOfUnit_Reserve);
                param.Add("@AirCompressors_TotalHP_Reserve", coalYearlyViewModel.objMachinery.AirCompressors_TotalHP_Reserve);
                param.Add("@Winding_NoOfUnit_Use", coalYearlyViewModel.objMachinery.Winding_NoOfUnit_Use);
                param.Add("@Winding_TotalHP_Use", coalYearlyViewModel.objMachinery.Winding_TotalHP_Use);
                param.Add("@Winding_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.Winding_NoOfUnit_Reserve);
                param.Add("@Winding_TotalHP_Reserve", coalYearlyViewModel.objMachinery.Winding_TotalHP_Reserve);
                param.Add("@A1Ventilation_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A1Ventilation_NoOfUnit_Use);
                param.Add("@A1Ventilation_TotalHP_Use", coalYearlyViewModel.objMachinery.A1Ventilation_TotalHP_Use);
                param.Add("@A1Ventilation_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A1Ventilation_NoOfUnit_Reserve);
                param.Add("@A1Ventilation_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A1Ventilation_TotalHP_Reserve);
                param.Add("@A1Haulage_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A1Haulage_NoOfUnit_Use);
                param.Add("@A1Haulage_TotalHP_Use", coalYearlyViewModel.objMachinery.A1Haulage_TotalHP_Use);
                param.Add("@A1Haulage_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A1Haulage_NoOfUnit_Reserve);
                param.Add("@A1Haulage_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A1Haulage_TotalHP_Reserve);
                param.Add("@A1Pumping_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A1Pumping_NoOfUnit_Use);
                param.Add("@A1Pumping_TotalHP_Use", coalYearlyViewModel.objMachinery.A1Pumping_TotalHP_Use);
                param.Add("@A1Pumping_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A1Pumping_NoOfUnit_Reserve);
                param.Add("@A1Pumping_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A1Pumping_TotalHP_Reserve);
                param.Add("@Dressing_NoOfUnit_Use", coalYearlyViewModel.objMachinery.Dressing_NoOfUnit_Use);
                param.Add("@Dressing_TotalHP_Use", coalYearlyViewModel.objMachinery.Dressing_TotalHP_Use);
                param.Add("@Dressing_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.Dressing_NoOfUnit_Reserve);
                param.Add("@Dressing_TotalHP_Reserve", coalYearlyViewModel.objMachinery.Dressing_TotalHP_Reserve);
                param.Add("@Workshops_NoOfUnit_Use", coalYearlyViewModel.objMachinery.Workshops_NoOfUnit_Use);
                param.Add("@Workshops_TotalHP_Use", coalYearlyViewModel.objMachinery.Workshops_TotalHP_Use);
                param.Add("@Workshops_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.Workshops_NoOfUnit_Reserve);
                param.Add("@Workshops_TotalHP_Reserve", coalYearlyViewModel.objMachinery.Workshops_TotalHP_Reserve);
                param.Add("@A1Miscellaneous_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A1Miscellaneous_NoOfUnit_Use);
                param.Add("@A1Miscellaneous_TotalHP_Use", coalYearlyViewModel.objMachinery.A1Miscellaneous_TotalHP_Use);
                param.Add("@A1Miscellaneous_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A1Miscellaneous_NoOfUnit_Reserve);
                param.Add("@A1Miscellaneous_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A1Miscellaneous_TotalHP_Reserve);
                param.Add("@A2Haulage_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A2Haulage_NoOfUnit_Use);
                param.Add("@A2Haulage_TotalHP_Use", coalYearlyViewModel.objMachinery.A2Haulage_TotalHP_Use);
                param.Add("@A2Haulage_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A2Haulage_NoOfUnit_Reserve);
                param.Add("@A2Haulage_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A2Haulage_TotalHP_Reserve);
                param.Add("@A2Ventilation_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A2Ventilation_NoOfUnit_Use);
                param.Add("@A2Ventilation_TotalHP_Use", coalYearlyViewModel.objMachinery.A2Ventilation_TotalHP_Use);
                param.Add("@A2Ventilation_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A2Ventilation_NoOfUnit_Reserve);
                param.Add("@A2Ventilation_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A2Ventilation_TotalHP_Reserve);
                param.Add("@A2Pumping_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A2Pumping_NoOfUnit_Use);
                param.Add("@A2Pumping_TotalHP_Use", coalYearlyViewModel.objMachinery.A2Pumping_TotalHP_Use);
                param.Add("@A2Pumping_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A2Pumping_NoOfUnit_Reserve);
                param.Add("@A2Pumping_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A2Pumping_TotalHP_Reserve);
                param.Add("@locomotives_NoOfUnit_Use", coalYearlyViewModel.objMachinery.locomotives_NoOfUnit_Use);
                param.Add("@locomotives_TotalHP_Use", coalYearlyViewModel.objMachinery.locomotives_TotalHP_Use);
                param.Add("@locomotives_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.locomotives_NoOfUnit_Reserve);
                param.Add("@locomotives_TotalHP_Reserve", coalYearlyViewModel.objMachinery.locomotives_TotalHP_Reserve);
                param.Add("@A2Miscellaneous_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A2Miscellaneous_NoOfUnit_Use);
                param.Add("@A2Miscellaneous_TotalHP_Use", coalYearlyViewModel.objMachinery.A2Miscellaneous_TotalHP_Use);
                param.Add("@A2Miscellaneous_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A2Miscellaneous_NoOfUnit_Reserve);
                param.Add("@A2Miscellaneous_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A2Miscellaneous_TotalHP_Reserve);

                param.Add("@A1_Total_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A1_Total_NoOfUnit_Use);
                param.Add("@A1_Total_TotalHP_Use", coalYearlyViewModel.objMachinery.A1_Total_TotalHP_Use);
                param.Add("@A1_Total_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A1_Total_NoOfUnit_Reserve);
                param.Add("@A1_Total_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A1_Total_TotalHP_Reserve);
                param.Add("@A2_Total_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A2_Total_NoOfUnit_Use);
                param.Add("@A2_Total_TotalHP_Use", coalYearlyViewModel.objMachinery.A2_Total_TotalHP_Use);
                param.Add("@A2_Total_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A2_Total_NoOfUnit_Reserve);
                param.Add("@A2_Total_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A2_Total_TotalHP_Reserve);
                param.Add("@A3_Total_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A3_Total_NoOfUnit_Use);
                param.Add("@A3_Total_TotalHP_Use", coalYearlyViewModel.objMachinery.A3_Total_TotalHP_Use);
                param.Add("@A3_Total_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A3_Total_NoOfUnit_Reserve);
                param.Add("@A3_Total_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A3_Total_TotalHP_Reserve);

                param.Add("@A1_Miscellaneous", coalYearlyViewModel.objMachinery.A1_Miscellaneous);
                param.Add("@A2_Miscellaneous", coalYearlyViewModel.objMachinery.A2_Miscellaneous);

                param.Add("@Financial_Year", coalYearlyViewModel.objMachinery.Year);
                param.Add("@CreatedBy", coalYearlyViewModel.UserId);
                #endregion
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturn_CoalYearMACHINERY", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Inserted";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                coalYearlyViewModel = null;
            }
        }

        /// <summary>
        /// To UPDATE MACHINERY EQUIPMENT Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> Update_MACHINERY_EQUIPMENT(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                #region Parameters
                param.Add("@Equipment_Id", coalYearlyViewModel.objMachinery.Equipment_Id);
                param.Add("@Boilers_NoOfUnit_Use", coalYearlyViewModel.objMachinery.Boilers_NoOfUnit_Use);
                param.Add("@Boilers_TotalHP_Use", coalYearlyViewModel.objMachinery.Boilers_TotalHP_Use);
                param.Add("@Boilers_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.Boilers_NoOfUnit_Reserve);
                param.Add("@Boilers_TotalHP_Reserve", coalYearlyViewModel.objMachinery.Boilers_TotalHP_Reserve);
                param.Add("@SteamTurbines_NoOfUnit_Use", coalYearlyViewModel.objMachinery.SteamTurbines_NoOfUnit_Use);
                param.Add("@SteamTurbines_TotalHP_Use", coalYearlyViewModel.objMachinery.SteamTurbines_TotalHP_Use);
                param.Add("@SteamTurbines_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.SteamTurbines_NoOfUnit_Reserve);
                param.Add("@SteamTurbines_TotalHP_Reserve", coalYearlyViewModel.objMachinery.SteamTurbines_TotalHP_Reserve);
                param.Add("@DieselEngines_NoOfUnit_Use", coalYearlyViewModel.objMachinery.DieselEngines_NoOfUnit_Use);
                param.Add("@DieselEngines_TotalHP_Use", coalYearlyViewModel.objMachinery.DieselEngines_TotalHP_Use);
                param.Add("@DieselEngines_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.DieselEngines_NoOfUnit_Reserve);
                param.Add("@DieselEngines_TotalHP_Reserve", coalYearlyViewModel.objMachinery.DieselEngines_TotalHP_Reserve);
                param.Add("@Gasoline_NoOfUnit_Use", coalYearlyViewModel.objMachinery.Gasoline_NoOfUnit_Use);
                param.Add("@Gasoline_TotalHP_Use", coalYearlyViewModel.objMachinery.Gasoline_TotalHP_Use);
                param.Add("@Gasoline_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.Gasoline_NoOfUnit_Reserve);
                param.Add("@Gasoline_TotalHP_Reserve", coalYearlyViewModel.objMachinery.Gasoline_TotalHP_Reserve);
                param.Add("@HydraulicTurbines_NoOfUnit_Use", coalYearlyViewModel.objMachinery.HydraulicTurbines_NoOfUnit_Use);
                param.Add("@HydraulicTurbines_TotalHP_Use", coalYearlyViewModel.objMachinery.HydraulicTurbines_TotalHP_Use);
                param.Add("@HydraulicTurbines_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.HydraulicTurbines_NoOfUnit_Reserve);
                param.Add("@HydraulicTurbines_TotalHP_Reserve", coalYearlyViewModel.objMachinery.HydraulicTurbines_TotalHP_Reserve);
                param.Add("@AirCompressors_NoOfUnit_Use", coalYearlyViewModel.objMachinery.AirCompressors_NoOfUnit_Use);
                param.Add("@AirCompressors_TotalHP_Use", coalYearlyViewModel.objMachinery.AirCompressors_TotalHP_Use);
                param.Add("@AirCompressors_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.AirCompressors_NoOfUnit_Reserve);
                param.Add("@AirCompressors_TotalHP_Reserve", coalYearlyViewModel.objMachinery.AirCompressors_TotalHP_Reserve);
                param.Add("@Winding_NoOfUnit_Use", coalYearlyViewModel.objMachinery.Winding_NoOfUnit_Use);
                param.Add("@Winding_TotalHP_Use", coalYearlyViewModel.objMachinery.Winding_TotalHP_Use);
                param.Add("@Winding_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.Winding_NoOfUnit_Reserve);
                param.Add("@Winding_TotalHP_Reserve", coalYearlyViewModel.objMachinery.Winding_TotalHP_Reserve);
                param.Add("@A1Ventilation_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A1Ventilation_NoOfUnit_Use);
                param.Add("@A1Ventilation_TotalHP_Use", coalYearlyViewModel.objMachinery.A1Ventilation_TotalHP_Use);
                param.Add("@A1Ventilation_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A1Ventilation_NoOfUnit_Reserve);
                param.Add("@A1Ventilation_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A1Ventilation_TotalHP_Reserve);
                param.Add("@A1Haulage_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A1Haulage_NoOfUnit_Use);
                param.Add("@A1Haulage_TotalHP_Use", coalYearlyViewModel.objMachinery.A1Haulage_TotalHP_Use);
                param.Add("@A1Haulage_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A1Haulage_NoOfUnit_Reserve);
                param.Add("@A1Haulage_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A1Haulage_TotalHP_Reserve);
                param.Add("@A1Pumping_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A1Pumping_NoOfUnit_Use);
                param.Add("@A1Pumping_TotalHP_Use", coalYearlyViewModel.objMachinery.A1Pumping_TotalHP_Use);
                param.Add("@A1Pumping_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A1Pumping_NoOfUnit_Reserve);
                param.Add("@A1Pumping_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A1Pumping_TotalHP_Reserve);
                param.Add("@Dressing_NoOfUnit_Use", coalYearlyViewModel.objMachinery.Dressing_NoOfUnit_Use);
                param.Add("@Dressing_TotalHP_Use", coalYearlyViewModel.objMachinery.Dressing_TotalHP_Use);
                param.Add("@Dressing_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.Dressing_NoOfUnit_Reserve);
                param.Add("@Dressing_TotalHP_Reserve", coalYearlyViewModel.objMachinery.Dressing_TotalHP_Reserve);
                param.Add("@Workshops_NoOfUnit_Use", coalYearlyViewModel.objMachinery.Workshops_NoOfUnit_Use);
                param.Add("@Workshops_TotalHP_Use", coalYearlyViewModel.objMachinery.Workshops_TotalHP_Use);
                param.Add("@Workshops_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.Workshops_NoOfUnit_Reserve);
                param.Add("@Workshops_TotalHP_Reserve", coalYearlyViewModel.objMachinery.Workshops_TotalHP_Reserve);
                param.Add("@A1Miscellaneous_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A1Miscellaneous_NoOfUnit_Use);
                param.Add("@A1Miscellaneous_TotalHP_Use", coalYearlyViewModel.objMachinery.A1Miscellaneous_TotalHP_Use);
                param.Add("@A1Miscellaneous_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A1Miscellaneous_NoOfUnit_Reserve);
                param.Add("@A1Miscellaneous_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A1Miscellaneous_TotalHP_Reserve);
                param.Add("@A2Haulage_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A2Haulage_NoOfUnit_Use);
                param.Add("@A2Haulage_TotalHP_Use", coalYearlyViewModel.objMachinery.A2Haulage_TotalHP_Use);
                param.Add("@A2Haulage_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A2Haulage_NoOfUnit_Reserve);
                param.Add("@A2Haulage_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A2Haulage_TotalHP_Reserve);
                param.Add("@A2Ventilation_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A2Ventilation_NoOfUnit_Use);
                param.Add("@A2Ventilation_TotalHP_Use", coalYearlyViewModel.objMachinery.A2Ventilation_TotalHP_Use);
                param.Add("@A2Ventilation_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A2Ventilation_NoOfUnit_Reserve);
                param.Add("@A2Ventilation_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A2Ventilation_TotalHP_Reserve);
                param.Add("@A2Pumping_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A2Pumping_NoOfUnit_Use);
                param.Add("@A2Pumping_TotalHP_Use", coalYearlyViewModel.objMachinery.A2Pumping_TotalHP_Use);
                param.Add("@A2Pumping_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A2Pumping_NoOfUnit_Reserve);
                param.Add("@A2Pumping_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A2Pumping_TotalHP_Reserve);
                param.Add("@locomotives_NoOfUnit_Use", coalYearlyViewModel.objMachinery.locomotives_NoOfUnit_Use);
                param.Add("@locomotives_TotalHP_Use", coalYearlyViewModel.objMachinery.locomotives_TotalHP_Use);
                param.Add("@locomotives_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.locomotives_NoOfUnit_Reserve);
                param.Add("@locomotives_TotalHP_Reserve", coalYearlyViewModel.objMachinery.locomotives_TotalHP_Reserve);
                param.Add("@A2Miscellaneous_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A2Miscellaneous_NoOfUnit_Use);
                param.Add("@A2Miscellaneous_TotalHP_Use", coalYearlyViewModel.objMachinery.A2Miscellaneous_TotalHP_Use);
                param.Add("@A2Miscellaneous_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A2Miscellaneous_NoOfUnit_Reserve);
                param.Add("@A2Miscellaneous_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A2Miscellaneous_TotalHP_Reserve);

                param.Add("@A1_Total_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A1_Total_NoOfUnit_Use);
                param.Add("@A1_Total_TotalHP_Use", coalYearlyViewModel.objMachinery.A1_Total_TotalHP_Use);
                param.Add("@A1_Total_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A1_Total_NoOfUnit_Reserve);
                param.Add("@A1_Total_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A1_Total_TotalHP_Reserve);

                param.Add("@A2_Total_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A2_Total_NoOfUnit_Use);
                param.Add("@A2_Total_TotalHP_Use", coalYearlyViewModel.objMachinery.A2_Total_TotalHP_Use);
                param.Add("@A2_Total_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A2_Total_NoOfUnit_Reserve);
                param.Add("@A2_Total_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A2_Total_TotalHP_Reserve);

                param.Add("@A3_Total_NoOfUnit_Use", coalYearlyViewModel.objMachinery.A3_Total_NoOfUnit_Use);
                param.Add("@A3_Total_TotalHP_Use", coalYearlyViewModel.objMachinery.A3_Total_TotalHP_Use);
                param.Add("@A3_Total_NoOfUnit_Reserve", coalYearlyViewModel.objMachinery.A3_Total_NoOfUnit_Reserve);
                param.Add("@A3_Total_TotalHP_Reserve", coalYearlyViewModel.objMachinery.A3_Total_TotalHP_Reserve);


                param.Add("@A1_Miscellaneous", coalYearlyViewModel.objMachinery.A1_Miscellaneous);
                param.Add("@A2_Miscellaneous", coalYearlyViewModel.objMachinery.A2_Miscellaneous);


                param.Add("@Financial_Year", coalYearlyViewModel.objMachinery.Year);
                param.Add("@CreatedBy", coalYearlyViewModel.UserId);
                #endregion

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturn_CoalYearMACHINERY", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "Record Has not Updated..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Updated..";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                coalYearlyViewModel = null;
            }
        }
         
        #endregion

        #region Table D
        /// <summary>
        /// To Get MECHANICAL VENTILATORS Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<MECHANICAL_VENTILATORS> Get_MECHANICAL_VENTILATORS(YearlyReturnModel yearlyReturnModel)
        {
            MECHANICAL_VENTILATORS mECHANICAL_VENTILATORS = new MECHANICAL_VENTILATORS();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 5);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<MECHANICAL_VENTILATORS>("GetCoalYearMineDetails", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    mECHANICAL_VENTILATORS = result.FirstOrDefault();
                }
                return mECHANICAL_VENTILATORS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mECHANICAL_VENTILATORS = null;
            }
        }

        /// <summary>
        /// To Add MECHANICAL VENTILATORS Details Data 
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> ADD_MECHANICAL_VENTILATORS(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                #region Parameters          

                param.Add("@Nameofexplosive", coalYearlyViewModel.objVentilators.Nameofexplosive);
                param.Add("@Quantity_used", coalYearlyViewModel.objVentilators.Quantity_used);
                param.Add("@Electric", coalYearlyViewModel.objVentilators.Electric);
                param.Add("@Ordinary", coalYearlyViewModel.objVentilators.Ordinary);
                param.Add("@Safety_Lamps", coalYearlyViewModel.objVentilators.Safety_Lamps);
                param.Add("@Lead_Rivet", coalYearlyViewModel.objVentilators.Lead_Rivet);
                param.Add("@Magnetic", coalYearlyViewModel.objVentilators.Magnetic);
                param.Add("@Other", coalYearlyViewModel.objVentilators.Other);
                param.Add("@Mechanical_Ventilator", coalYearlyViewModel.objVentilators.Mechanical_Ventilator);
                param.Add("@Position", coalYearlyViewModel.objVentilators.Position);
                param.Add("@Avg_Totalqty", coalYearlyViewModel.objVentilators.Avg_Totalqty);
                param.Add("@Water_gauge", coalYearlyViewModel.objVentilators.Water_gauge);

                param.Add("@Financial_Year", coalYearlyViewModel.objVentilators.Year);
                param.Add("@CreatedBy", coalYearlyViewModel.UserId);
                #endregion
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USPAnnualReturn_CoalYearMECHANICAL", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Inserted";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Update MECHANICAL VENTILATORS Details Data 
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> Update_MECHANICAL_VENTILATORS(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                #region Parameters
                param.Add("@Ventilators_Id", coalYearlyViewModel.objVentilators.Ventilators_Id);
                param.Add("@Nameofexplosive", coalYearlyViewModel.objVentilators.Nameofexplosive);
                param.Add("@Quantity_used", coalYearlyViewModel.objVentilators.Quantity_used);
                param.Add("@Electric", coalYearlyViewModel.objVentilators.Electric);
                param.Add("@Ordinary", coalYearlyViewModel.objVentilators.Ordinary);
                param.Add("@Safety_Lamps", coalYearlyViewModel.objVentilators.Safety_Lamps);
                param.Add("@Lead_Rivet", coalYearlyViewModel.objVentilators.Lead_Rivet);
                param.Add("@Magnetic", coalYearlyViewModel.objVentilators.Magnetic);
                param.Add("@Other", coalYearlyViewModel.objVentilators.Other);
                param.Add("@Mechanical_Ventilator", coalYearlyViewModel.objVentilators.Mechanical_Ventilator);
                param.Add("@Position", coalYearlyViewModel.objVentilators.Position);
                param.Add("@Avg_Totalqty", coalYearlyViewModel.objVentilators.Avg_Totalqty);
                param.Add("@Water_gauge", coalYearlyViewModel.objVentilators.Water_gauge);

                param.Add("@Financial_Year", coalYearlyViewModel.objVentilators.Year);
                param.Add("@CreatedBy", coalYearlyViewModel.UserId);
                #endregion

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USPAnnualReturn_CoalYearMECHANICAL", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "Record Has not Updated..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Updated..";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Table E(a)
        /// <summary>
        /// To Get E EXPLOSIVES Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<E_EXPLOSIVES>> GetE_EXPLOSIVES(YearlyReturnModel yearlyReturnModel)
        {
            List<E_EXPLOSIVES> lste_EXPLOSIVEs = new List<E_EXPLOSIVES>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 6);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<E_EXPLOSIVES>("GetCoalYearMineDetails", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lste_EXPLOSIVEs = result.ToList();
                }
                return lste_EXPLOSIVEs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lste_EXPLOSIVEs = null;
            }
        }

        /// <summary>
        /// To Add E EXPLOSIVES Details Data 
        /// </summary>
        /// <param name="e_EXPLOSIVES"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddE_EXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                if (e_EXPLOSIVES.MineralGradeId != null && e_EXPLOSIVES.Opening_stocks != null && e_EXPLOSIVES.Closingstocks != null)
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@MineralGradeId", e_EXPLOSIVES.MineralGradeId);
                    param.Add("@Opening_stocks", e_EXPLOSIVES.Opening_stocks);
                    param.Add("@Coal_raised", e_EXPLOSIVES.Coal_raised);
                    param.Add("@Totalvalueofrasing", e_EXPLOSIVES.Totalvalueofrasing);
                    param.Add("@TotalI", e_EXPLOSIVES.TotalI);
                    param.Add("@Coaldespatched", e_EXPLOSIVES.Coaldespatched);
                    param.Add("@Collieryconsumption", e_EXPLOSIVES.Collieryconsumption);
                    param.Add("@Coalusedforcoking", e_EXPLOSIVES.Coalusedforcoking);
                    param.Add("@Shortagedueto_Causes", e_EXPLOSIVES.Shortagedueto_Causes);
                    param.Add("@Closingstocks", e_EXPLOSIVES.Closingstocks);
                    param.Add("@TotalII", e_EXPLOSIVES.TotalII);
                    param.Add("@Financial_Year", e_EXPLOSIVES.Year1);
                    param.Add("@CreatedBy", e_EXPLOSIVES.UserId);
                    param.Add("@Check", 1);
                    param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                    var result =await Connection.QueryAsync<int>("USPAnnualReturn_CoalYearE_EXPLOSIVES", param, commandType: System.Data.CommandType.StoredProcedure);
                    int newID = param.Get<int>("Result");
                    messageEF.Satus = newID.ToString();
                }
                else
                {
                    messageEF.Satus = "0";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Update E EXPLOSIVES Details Data 
        /// </summary>
        /// <param name="e_EXPLOSIVES"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateE_EXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@E_Explosive_Id", e_EXPLOSIVES.E_Explosive_Id);
                param.Add("@MineralGradeId", e_EXPLOSIVES.MineralGradeId);
                param.Add("@Opening_stocks", e_EXPLOSIVES.Opening_stocks);
                param.Add("@Coal_raised", e_EXPLOSIVES.Coal_raised);
                param.Add("@Totalvalueofrasing", e_EXPLOSIVES.Totalvalueofrasing);
                param.Add("@TotalI", e_EXPLOSIVES.TotalI);
                param.Add("@Coaldespatched", e_EXPLOSIVES.Coaldespatched);
                param.Add("@Collieryconsumption", e_EXPLOSIVES.Collieryconsumption);
                param.Add("@Coalusedforcoking", e_EXPLOSIVES.Coalusedforcoking);
                param.Add("@Shortagedueto_Causes", e_EXPLOSIVES.Shortagedueto_Causes);
                param.Add("@Closingstocks", e_EXPLOSIVES.Closingstocks);
                param.Add("@TotalII", e_EXPLOSIVES.TotalII);
                param.Add("@Financial_Year", e_EXPLOSIVES.Year1);
                param.Add("@ModifiedBy", e_EXPLOSIVES.UserId);
                param.Add("@Check", 2);
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USPAnnualReturn_CoalYearE_EXPLOSIVES", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                messageEF.Satus = newID.ToString();
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Delete E EXPLOSIVES Details Data 
        /// </summary>
        /// <param name="e_EXPLOSIVES"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteE_EXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@E_Explosive_Id", e_EXPLOSIVES.E_Explosive_Id);
                param.Add("@Financial_Year", e_EXPLOSIVES.Year1);
                param.Add("@ModifiedBy", e_EXPLOSIVES.UserId);
                param.Add("@Check", 3);
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USPAnnualReturn_CoalYearE_EXPLOSIVES", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                messageEF.Satus = newID.ToString();
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// To Get Mineral Grade Details Data 
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<E_EXPLOSIVES>> GetMineralGarde(YearlyReturnModel yearlyReturnModel)
        {
            List<E_EXPLOSIVES> lstE_EXPLOSIVES = new List<E_EXPLOSIVES>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserId", yearlyReturnModel.UserId);
                param.Add("@Check", 1);
                var result =await Connection.QueryAsync<E_EXPLOSIVES>("UspGetMineralGrade", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstE_EXPLOSIVES = result.ToList();
                }
                return lstE_EXPLOSIVES;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstE_EXPLOSIVES = null;
            }
        }

        /// <summary>
        /// To Get Details By Mineral Id  
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<E_EXPLOSIVES> Change_MineralGrade(YearlyReturnModel yearlyReturnModel)
        {
            E_EXPLOSIVES e_EXPLOSIVES = new E_EXPLOSIVES();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserId", yearlyReturnModel.UserId);
                param.Add("@MineralGradeId", yearlyReturnModel.MineralGradeId);
                param.Add("@Check", 3);
                var result =await Connection.QueryAsync<E_EXPLOSIVES>("Usp_GetCoal_TableAMonthly", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    e_EXPLOSIVES = result.FirstOrDefault();
                    e_EXPLOSIVES.Coaldespatched = e_EXPLOSIVES.CoalDispatched.ToString();
                    e_EXPLOSIVES.Opening_stocks = e_EXPLOSIVES.OpeningStock.ToString();
                }
                return e_EXPLOSIVES;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Table E(b)
        /// <summary>
        /// To Get E EXPLOSIVES b Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>

        public async Task<E_EXPLOSIVES_b> Get_E_EXPLOSIVES_b(YearlyReturnModel yearlyReturnModel)
        {
            E_EXPLOSIVES_b e_EXPLOSIVES_B = new E_EXPLOSIVES_b();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 7);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<E_EXPLOSIVES_b>("GetCoalYearMineDetails", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    e_EXPLOSIVES_B = result.FirstOrDefault();
                }
                return e_EXPLOSIVES_B;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                e_EXPLOSIVES_B = null;
            }
        }

        /// <summary>
        /// To Add E EXPLOSIVES b Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> ADD_E_EXPLOSIVES_b(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                #region Parameters                  
                param.Add("@OpeningStocks_hard", coalYearlyViewModel.objE_Explosives_b.OpeningStocks_hard);
                param.Add("@Cokemanufactured_hard", coalYearlyViewModel.objE_Explosives_b.Cokemanufactured_hard);
                param.Add("@Totalvalueofcokemade_hard", coalYearlyViewModel.objE_Explosives_b.Totalvalueofcokemade_hard);
                param.Add("@TotalI_hard", coalYearlyViewModel.objE_Explosives_b.TotalI_hard);
                param.Add("@Cokedespatched_hard", coalYearlyViewModel.objE_Explosives_b.Cokedespatched_hard);
                param.Add("@Collieryconsumption_hard", coalYearlyViewModel.objE_Explosives_b.Collieryconsumption_hard);
                param.Add("@Shortage_hard", coalYearlyViewModel.objE_Explosives_b.Shortage_hard);
                param.Add("@Closingstocks_hard", coalYearlyViewModel.objE_Explosives_b.Closingstocks_hard);
                param.Add("@TotalII_hard", coalYearlyViewModel.objE_Explosives_b.TotalII_hard);
                param.Add("@OpeningStocks_soft", coalYearlyViewModel.objE_Explosives_b.OpeningStocks_soft);
                param.Add("@Cokemanufactured_soft", coalYearlyViewModel.objE_Explosives_b.Cokemanufactured_soft);
                param.Add("@Totalvalueofcokemade_soft", coalYearlyViewModel.objE_Explosives_b.Totalvalueofcokemade_soft);
                param.Add("@TotalI_soft", coalYearlyViewModel.objE_Explosives_b.TotalI_soft);
                param.Add("@Cokedespatched_soft", coalYearlyViewModel.objE_Explosives_b.Cokedespatched_soft);
                param.Add("@Collieryconsumption_soft", coalYearlyViewModel.objE_Explosives_b.Collieryconsumption_soft);
                param.Add("@Shortage_soft", coalYearlyViewModel.objE_Explosives_b.Shortage_soft);
                param.Add("@Closingstocks_soft", coalYearlyViewModel.objE_Explosives_b.Closingstocks_soft);
                param.Add("@TotalII_soft", coalYearlyViewModel.objE_Explosives_b.TotalII_soft);

                param.Add("@Financial_Year", coalYearlyViewModel.objE_Explosives_b.Year);
                param.Add("@CreatedBy", coalYearlyViewModel.UserId);
                #endregion
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USPAnnualReturn_CoalYearE_EXPLOSIVES_B", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Inserted";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Update E EXPLOSIVES b Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> Update_E_EXPLOSIVES_b(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                #region Parameters
                param.Add("@E_Explosives_b_Id", coalYearlyViewModel.objE_Explosives_b.E_Explosives_b_Id);
                param.Add("@OpeningStocks_hard", coalYearlyViewModel.objE_Explosives_b.OpeningStocks_hard);
                param.Add("@Cokemanufactured_hard", coalYearlyViewModel.objE_Explosives_b.Cokemanufactured_hard);
                param.Add("@Totalvalueofcokemade_hard", coalYearlyViewModel.objE_Explosives_b.Totalvalueofcokemade_hard);
                param.Add("@TotalI_hard", coalYearlyViewModel.objE_Explosives_b.TotalI_hard);
                param.Add("@Cokedespatched_hard", coalYearlyViewModel.objE_Explosives_b.Cokedespatched_hard);
                param.Add("@Collieryconsumption_hard", coalYearlyViewModel.objE_Explosives_b.Collieryconsumption_hard);
                param.Add("@Shortage_hard", coalYearlyViewModel.objE_Explosives_b.Shortage_hard);
                param.Add("@Closingstocks_hard", coalYearlyViewModel.objE_Explosives_b.Closingstocks_hard);
                param.Add("@TotalII_hard", coalYearlyViewModel.objE_Explosives_b.TotalII_hard);
                param.Add("@OpeningStocks_soft", coalYearlyViewModel.objE_Explosives_b.OpeningStocks_soft);
                param.Add("@Cokemanufactured_soft", coalYearlyViewModel.objE_Explosives_b.Cokemanufactured_soft);
                param.Add("@Totalvalueofcokemade_soft", coalYearlyViewModel.objE_Explosives_b.Totalvalueofcokemade_soft);
                param.Add("@TotalI_soft", coalYearlyViewModel.objE_Explosives_b.TotalI_soft);
                param.Add("@Cokedespatched_soft", coalYearlyViewModel.objE_Explosives_b.Cokedespatched_soft);
                param.Add("@Collieryconsumption_soft", coalYearlyViewModel.objE_Explosives_b.Collieryconsumption_soft);
                param.Add("@Shortage_soft", coalYearlyViewModel.objE_Explosives_b.Shortage_soft);
                param.Add("@Closingstocks_soft", coalYearlyViewModel.objE_Explosives_b.Closingstocks_soft);
                param.Add("@TotalII_soft", coalYearlyViewModel.objE_Explosives_b.TotalII_soft);

                param.Add("@Financial_Year", coalYearlyViewModel.objE_Explosives_b.Year);
                param.Add("@CreatedBy", coalYearlyViewModel.UserId);
                #endregion

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USPAnnualReturn_CoalYearE_EXPLOSIVES_B", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "Record Has not Updated..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Updated..";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Final Submit
        /// <summary>
        /// Final Submit Of E Return Coal
        /// </summary>
        /// <param name="e_EXPLOSIVES_B"></param>
        /// <returns></returns>
        public async Task<MessageEF> Update_FinalSubmit(E_EXPLOSIVES_b e_EXPLOSIVES_B)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Financial_Year", e_EXPLOSIVES_B.Year);
                param.Add("@CreatedBy", e_EXPLOSIVES_B.UserId);
                param.Add("@Check", 3);
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USPAnnualReturn_CoalYearE_EXPLOSIVES_B", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "Yearly Return has not Submited";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Yearly Return has been Submited Successfully";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion
    }
}
