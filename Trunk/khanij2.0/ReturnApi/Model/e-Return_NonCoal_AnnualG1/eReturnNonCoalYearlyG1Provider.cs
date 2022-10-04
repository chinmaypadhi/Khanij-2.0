using Dapper;
using Microsoft.AspNetCore.Mvc;
using ReturnApi.Factory;
using ReturnApi.Model.e_Return_NonCoal;
using ReturnApi.Repository;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace ReturnApi.Model.e_Return_NonCoal_AnnualG1
{
    public class eReturnNonCoalYearlyG1Provider : RepositoryBase, IeReturnNonCoalYearlyG1Provider
    {
        public eReturnNonCoalYearlyG1Provider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        /// <summary>
        /// Get Yearly Return G2 Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List YearlyReturnModel class</returns>
        public async Task<List<YearlyReturnModel>> GetYearlyReturnDetails(MonthlyReturnModelNonCoal model)
        {
            List<YearlyReturnModel> list = new List<YearlyReturnModel>();
            try
            {
                var paramList = new
                {
                    FinancialYear = model.Year,
                    UserID = model.Uid,
                    Check = 4,
                };

                var result = await Connection.ExecuteReaderAsync("GetDetailsofMonthlyReturn", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        YearlyReturnModel objModel = new YearlyReturnModel();

                        objModel.FinancialYear = Convert.ToString(dt.Rows[i]["Financial_Year"]);
                        objModel.Status = Convert.ToString(dt.Rows[i]["Status"]);
                        objModel.ModifiedOn = Convert.ToString(dt.Rows[i]["ModifiedOn"]);
                        objModel.MineralName = Convert.ToString(dt.Rows[i]["MineralName"]);
                        list.Add(objModel);
                    }

                }
                return list;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                model = null;
                list = null;
            }
        }

        #region Part 1 H1

        /// <summary>
        /// Get Other Minea Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>AnnualReturnH1ViewModel class</returns>
        public async Task<AnnualReturnH1ViewModel> GetMineOtherDetails(MonthlyReturnModelNonCoal model)
        {
            AnnualReturnH1ViewModel objModel = new AnnualReturnH1ViewModel();
            try
            {
                var paramList = new
                {
                    Return_Year = model.Year,
                    UserID = model.Uid,
                    Check = 1,
                };
                var result = await Connection.ExecuteReaderAsync("GetAnnualReturnPart1", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objModel.objOtherDetails.OtherDetails_Id = Convert.ToInt32(dt.Rows[0]["OtherDetails_Id"]);

                        objModel.objMineDetails.Registrationnumber = Convert.ToString(dt.Rows[0]["Registrationnumber"]);
                        objModel.objMineDetails.MINE_CODE = Convert.ToString(dt.Rows[0]["MINE_CODE"]);
                        objModel.objMineDetails.MineralName = Convert.ToString(dt.Rows[0]["MineralName"]);
                        objModel.objMineDetails.OtherMineral = Convert.ToString(dt.Rows[0]["OtherMineral"]);
                        objModel.objMineDetails.MineName = Convert.ToString(dt.Rows[0]["MineName"]);
                        objModel.objMineDetails.MineAddress = Convert.ToString(dt.Rows[0]["MineAddress"]);
                        objModel.objMineDetails.MineVillage = Convert.ToString(dt.Rows[0]["MineVillage"]);
                        objModel.objMineDetails.MineDistrict = Convert.ToString(dt.Rows[0]["MineDistrict"]);
                        objModel.objMineDetails.MineState = Convert.ToString(dt.Rows[0]["MineState"]);
                        objModel.objMineDetails.MineTehsil = Convert.ToString(dt.Rows[0]["MineTehsil"]);
                        objModel.objMineDetails.MinePinCode = Convert.ToString(dt.Rows[0]["MinePinCode"]);
                        objModel.objMineDetails.MineEmailID = Convert.ToString(dt.Rows[0]["MineEmailID"]);
                        objModel.objMineDetails.MineMobileNo = Convert.ToString(dt.Rows[0]["MineMobileNo"]);
                        objModel.objMineDetails.MinePhoneNo = Convert.ToString(dt.Rows[0]["MinePhoneNo"]);
                        objModel.objMineDetails.LesseeName = Convert.ToString(dt.Rows[0]["LesseeName"]);
                        objModel.objMineDetails.LesseeAddress = Convert.ToString(dt.Rows[0]["LesseeAddress"]);
                        objModel.objMineDetails.LesseeVillageName = Convert.ToString(dt.Rows[0]["LesseeVillageName"]);
                        objModel.objMineDetails.LesseeDistrictName = Convert.ToString(dt.Rows[0]["LesseeDistrictName"]);
                        objModel.objMineDetails.LesseeStateName = Convert.ToString(dt.Rows[0]["LesseeStateName"]);
                        objModel.objMineDetails.LesseePinCode = Convert.ToString(dt.Rows[0]["LesseePinCode"]);
                        objModel.objMineDetails.LesseeTehsilName = Convert.ToString(dt.Rows[0]["LesseeTehsilName"]);
                        objModel.objMineDetails.LesseeEmailID = Convert.ToString(dt.Rows[0]["LesseeEmailID"]);
                        objModel.objMineDetails.LesseeMobileNo = Convert.ToString(dt.Rows[0]["LesseeMobileNo"]);
                        objModel.objMineDetails.LesseePhoneNo = Convert.ToString(dt.Rows[0]["LesseePhoneNo"]);
                        objModel.objOtherDetails.RegisteredOffice = Convert.ToString(dt.Rows[0]["RegisteredOffice"]);
                        objModel.objOtherDetails.Director_in_charge = Convert.ToString(dt.Rows[0]["Director_in_charge"]);
                        objModel.objOtherDetails.Agent = Convert.ToString(dt.Rows[0]["Agent"]);
                        objModel.objOtherDetails.Manager = Convert.ToString(dt.Rows[0]["Manager"]);
                        objModel.objOtherDetails.MiningEngineer_in_charge = Convert.ToString(dt.Rows[0]["MiningEngineer_in_charge"]);
                        objModel.objOtherDetails.Geologist_in_charge = Convert.ToString(dt.Rows[0]["Geologist_in_charge"]);
                        objModel.objOtherDetails.Transferor = Convert.ToString(dt.Rows[0]["Transferor"]);
                        string Dateof_Transfer = Convert.ToString(dt.Rows[0]["Dateof_Transfer"]);
                        if (Dateof_Transfer != null && Dateof_Transfer != "")
                            objModel.objOtherDetails.Dateof_Transfer = Convert.ToString(dt.Rows[0]["Dateof_Transfer"]);
                        objModel.objOtherDetails.MinePostOffice = Convert.ToString(dt.Rows[0]["MinePostOffice"]);
                        objModel.objOtherDetails.MineFaxNo = Convert.ToString(dt.Rows[0]["MineFaxNo"]);
                        objModel.objOtherDetails.LesseeFaxNo = Convert.ToString(dt.Rows[0]["LesseeFaxNo"]);
                        objModel.objOtherDetails.SubmitDate = Convert.ToString(dt.Rows[0]["SubmitDate"]);
                        objModel.objOtherDetails.DSCFilePath = Convert.ToString(dt.Rows[0]["DSCFilePath"]);
                    }

                }
                return objModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                model = null;
                objModel = null;
            }
        }

        /// <summary>
        /// Get Particulars Of Area
        /// </summary>
        /// <param name="model"></param>
        /// <returns>ParticularsofArea class</returns>
        public async Task<ParticularsofArea> GetParticularsofArea(MonthlyReturnModelNonCoal model)
        {
            ParticularsofArea objModel = new ParticularsofArea();
            try
            {
                var paramList = new
                {
                    Return_Year = model.Year,
                    UserID = model.Uid,
                    Check = 2,
                };
                var result = await Connection.ExecuteReaderAsync("GetAnnualReturnPart1", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (!(dt.Rows[i]["Particular_Id"] is DBNull))
                        {
                            objModel.Particular_Id.Add(Convert.ToInt32(dt.Rows[i]["Particular_Id"]));
                        }
                        objModel.Lease_number.Add(Convert.ToString(dt.Rows[i]["Lease_number"]));
                        objModel.underlease_UnderForest.Add(Convert.ToString(dt.Rows[i]["underlease_UnderForest"]));
                        objModel.underlease_OutsideForest.Add(Convert.ToString(dt.Rows[i]["underlease_OutsideForest"]));
                        objModel.underlease_Total.Add(Convert.ToString(dt.Rows[i]["underlease_Total"]));

                        if (!(dt.Rows[i]["Date_of_execution"] is DBNull))
                        {
                            string Date_of_execution = (Convert.ToDateTime(dt.Rows[i]["Date_of_execution"])).ToString("dd/MM/yyyy");

                            if (Date_of_execution != null && Date_of_execution != "")
                                objModel.Date_of_execution_str.Add((Convert.ToDateTime(dt.Rows[i]["Date_of_execution"])).ToString("dd/MM/yyyy"));
                        }
                        objModel.Periodoflease.Add(Convert.ToString(dt.Rows[i]["Periodoflease"]));
                        objModel.Surfacerights_UnderForest.Add(Convert.ToString(dt.Rows[i]["Surfacerights_UnderForest"]));
                        objModel.Surfacerights_OutsideForest.Add(Convert.ToString(dt.Rows[i]["Surfacerights_OutsideForest"]));
                        objModel.Surfacerights_Total.Add(Convert.ToString(dt.Rows[i]["Surfacerights_Total"]));
                        if (!(dt.Rows[i]["RenewalDate"] is DBNull))
                        {
                            string RenewalDate = (Convert.ToDateTime(dt.Rows[i]["RenewalDate"])).ToString("dd/MM/yyyy");
                            if (RenewalDate != null && RenewalDate != "")
                                objModel.RenewalDate_str.Add((Convert.ToDateTime(dt.Rows[i]["RenewalDate"])).ToString("dd/MM/yyyy"));
                        }

                        objModel.RenewalPeriod.Add(Convert.ToString(dt.Rows[i]["RenewalPeriod"]));
                        objModel.More_mine_details = Convert.ToString(dt.Rows[i]["More_mine_details"]);
                        objModel.Mineral_produced = Convert.ToString(dt.Rows[i]["Mineral_produced"]);

                    }

                }
                return objModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                model = null;
                objModel = null;
            }
        }

        /// <summary>
        /// Get Lease Area Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>LeaseArea class</returns>
        public async Task<LeaseArea> GetLeasearea(MonthlyReturnModelNonCoal model)
        {
            LeaseArea objModel = new LeaseArea();
            try
            {
                var paramList = new
                {
                    Return_Year = model.Year,
                    UserID = model.Uid,
                    Check = 3,
                };
                var result = await Connection.ExecuteReaderAsync("GetAnnualReturnPart1", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    objModel.Lease_Area_Id = Convert.ToInt32(dt.Rows[0]["Lease_Area_Id"]);
                    objModel.UnderForest1 = Convert.ToString(dt.Rows[0]["UnderForest1"]);
                    objModel.UnderForest2 = Convert.ToString(dt.Rows[0]["UnderForest2"]);
                    objModel.UnderForest3 = Convert.ToString(dt.Rows[0]["UnderForest3"]);
                    objModel.UnderForest4 = Convert.ToString(dt.Rows[0]["UnderForest4"]);
                    objModel.UnderForest5 = Convert.ToString(dt.Rows[0]["UnderForest5"]);
                    objModel.UnderForest6 = Convert.ToString(dt.Rows[0]["UnderForest6"]);
                    objModel.UnderForest7 = Convert.ToString(dt.Rows[0]["UnderForest7"]);

                    objModel.Outsideforest1 = Convert.ToString(dt.Rows[0]["Outsideforest1"]);
                    objModel.Outsideforest2 = Convert.ToString(dt.Rows[0]["Outsideforest2"]);
                    objModel.Outsideforest3 = Convert.ToString(dt.Rows[0]["Outsideforest3"]);
                    objModel.Outsideforest4 = Convert.ToString(dt.Rows[0]["Outsideforest4"]);
                    objModel.Outsideforest5 = Convert.ToString(dt.Rows[0]["Outsideforest5"]);
                    objModel.Outsideforest6 = Convert.ToString(dt.Rows[0]["Outsideforest6"]);
                    objModel.Outsideforest7 = Convert.ToString(dt.Rows[0]["Outsideforest7"]);

                    objModel.Total1 = Convert.ToString(dt.Rows[0]["Total1"]);
                    objModel.Total2 = Convert.ToString(dt.Rows[0]["Total2"]);
                    objModel.Total3 = Convert.ToString(dt.Rows[0]["Total3"]);
                    objModel.Total4 = Convert.ToString(dt.Rows[0]["Total4"]);
                    objModel.Total5 = Convert.ToString(dt.Rows[0]["Total5"]);
                    objModel.Total6 = Convert.ToString(dt.Rows[0]["Total6"]);
                    objModel.Total7 = Convert.ToString(dt.Rows[0]["Total7"]);

                    objModel.AgencyofMine = Convert.ToString(dt.Rows[0]["AgencyofMine"]);

                }
                return objModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                model = null;
                objModel = null;
            }
        }

        /// <summary>
        /// Get Lessee Mines Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>MineDetailsModel class</returns>
        public async Task<MineDetailsModel> GetLesseMineDeatils(MonthlyReturnModelNonCoal model)
        {
            MineDetailsModel objModel = new MineDetailsModel();
            try
            {
                var paramList = new
                {
                    UserID = model.Uid,
                };

                var result = await Connection.ExecuteReaderAsync("UspGetForm_F1_Details", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    objModel.Registrationnumber = Convert.ToString(dt.Rows[0]["Registrationnumber"]);
                    objModel.MINE_CODE = Convert.ToString(dt.Rows[0]["MINE_CODE"]);
                    objModel.MineralID = Convert.ToInt32(dt.Rows[0]["MineralID"]);
                    objModel.MineralName = Convert.ToString(dt.Rows[0]["MineralName"]);
                    if (Convert.ToString(dt.Rows[0]["OtherMineral"]) != null && Convert.ToString(dt.Rows[0]["OtherMineral"]) != "")
                        objModel.OtherMineral = Convert.ToString(dt.Rows[0]["OtherMineral"]);
                    else
                        objModel.OtherMineral = "N/A";
                    if (Convert.ToString(dt.Rows[0]["MineName"]) != null && Convert.ToString(dt.Rows[0]["MineName"]) != "")
                        objModel.MineName = Convert.ToString(dt.Rows[0]["MineName"]);
                    else
                        objModel.MineName = "N/A";
                    objModel.MineAddress = Convert.ToString(dt.Rows[0]["MineAddress"]);
                    objModel.MineVillage = Convert.ToString(dt.Rows[0]["MineVillage"]);
                    objModel.MineDistrict = Convert.ToString(dt.Rows[0]["MineDistrict"]);
                    objModel.MineState = Convert.ToString(dt.Rows[0]["MineState"]);
                    objModel.MineTehsil = Convert.ToString(dt.Rows[0]["MineTehsil"]);
                    objModel.MinePinCode = Convert.ToString(dt.Rows[0]["MinePinCode"]);
                    if (Convert.ToString(dt.Rows[0]["MinePostOffice"]) != null && Convert.ToString(dt.Rows[0]["MinePostOffice"]) != "")
                        objModel.MinePostOffice = Convert.ToString(dt.Rows[0]["MinePostOffice"]);
                    else
                        objModel.MinePostOffice = "N/A";

                    if (Convert.ToString(dt.Rows[0]["MineFaxNo"]) != null && Convert.ToString(dt.Rows[0]["MineFaxNo"]) != "")
                        objModel.MineFaxNo = Convert.ToString(dt.Rows[0]["MineFaxNo"]);
                    else
                        objModel.MineFaxNo = "N/A";

                    objModel.MineEmailID = Convert.ToString(dt.Rows[0]["MineEmailID"]);
                    objModel.MineMobileNo = Convert.ToString(dt.Rows[0]["MineMobileNo"]);
                    objModel.MinePhoneNo = Convert.ToString(dt.Rows[0]["MinePhoneNo"]);

                    objModel.LesseeName = Convert.ToString(dt.Rows[0]["LesseeName"]);
                    objModel.LesseeAddress = Convert.ToString(dt.Rows[0]["LesseeAddress"]);
                    objModel.LesseeVillageName = Convert.ToString(dt.Rows[0]["MineVillage"]);
                    objModel.LesseeDistrictName = Convert.ToString(dt.Rows[0]["MineDistrict"]);
                    objModel.LesseeTehsilName = Convert.ToString(dt.Rows[0]["MineTehsil"]);

                    objModel.LesseeStateName = Convert.ToString(dt.Rows[0]["MineState"]);
                    objModel.LesseePinCode = Convert.ToString(dt.Rows[0]["LesseePinCode"]);
                    if (Convert.ToString(dt.Rows[0]["MinePostOffice"]) != null && Convert.ToString(dt.Rows[0]["MinePostOffice"]) != "")
                        objModel.LesseePostOffice = Convert.ToString(dt.Rows[0]["MinePostOffice"]);
                    else
                        objModel.LesseePostOffice = "N/A";

                    if (Convert.ToString(dt.Rows[0]["MineFaxNo"]) != null && Convert.ToString(dt.Rows[0]["MineFaxNo"]) != "")
                        objModel.LesseeFaxNo = Convert.ToString(dt.Rows[0]["MineFaxNo"]);
                    else
                        objModel.LesseeFaxNo = "N/A";
                    objModel.LesseeEmailID = Convert.ToString(dt.Rows[0]["LesseeEmailID"]);
                    objModel.LesseeMobileNo = Convert.ToString(dt.Rows[0]["LesseeMobileNo"]);
                    objModel.LesseePhoneNo = Convert.ToString(dt.Rows[0]["MinePhoneNo"]);

                }
                return objModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                model = null;
                objModel = null;
            }
        }

        /// <summary>
        /// Get Agency of mines Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of GetDDL Class</returns>
        public async Task<List<GetDDL>> GetAgencyOfMine(MonthlyReturnModelNonCoal model)
        {
            List<GetDDL> list = new List<GetDDL>();
            try
            {
                var paramList = new
                {
                    Check = 4,
                };
                var result = await Connection.ExecuteReaderAsync("GetAnnualReturnPart1", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        GetDDL objModel = new GetDDL();
                        objModel.Agency_Mine = Convert.ToString(dt.Rows[i]["Agency_Mine"]);
                        list.Add(objModel);
                    }

                }
                return list;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                model = null;
                list = null;
            }
        }

        /// <summary>
        /// Add Mine Other Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddMineOtherDetails(AnnualReturnH1ViewModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Registrationnumber", objModel.objMineDetails.Registrationnumber);
                p.Add("MINE_CODE", objModel.objMineDetails.MINE_CODE);
                p.Add("OtherMineral", objModel.objMineDetails.OtherMineral);
                p.Add("MineralName", objModel.objMineDetails.MineralName);
                p.Add("MineName", objModel.objMineDetails.MineName);
                p.Add("MineAddress", objModel.objMineDetails.MineAddress);
                p.Add("MineVillage", objModel.objMineDetails.MineVillage);
                p.Add("MineDistrict", objModel.objMineDetails.MineDistrict);
                p.Add("MineState", objModel.objMineDetails.MineState);
                p.Add("MineTehsil", objModel.objMineDetails.MineTehsil);
                p.Add("MinePinCode", objModel.objMineDetails.MinePinCode);
                p.Add("MineEmailID", objModel.objMineDetails.MineEmailID);
                p.Add("MineMobileNo", objModel.objMineDetails.MineMobileNo);
                p.Add("MinePhoneNo", objModel.objMineDetails.MinePhoneNo);
                p.Add("LesseeName", objModel.objMineDetails.LesseeName);
                p.Add("LesseeAddress", objModel.objMineDetails.LesseeAddress);
                p.Add("LesseeVillageName", objModel.objMineDetails.LesseeVillageName);
                p.Add("LesseeDistrictName", objModel.objMineDetails.LesseeDistrictName);
                p.Add("LesseeStateName", objModel.objMineDetails.LesseeStateName);
                p.Add("LesseePinCode", objModel.objMineDetails.LesseePinCode);
                p.Add("LesseeTehsilName", objModel.objMineDetails.LesseeTehsilName);
                p.Add("LesseeEmailID", objModel.objMineDetails.LesseeEmailID);
                p.Add("LesseeMobileNo", objModel.objMineDetails.LesseeMobileNo);
                p.Add("LesseePhoneNo", objModel.objMineDetails.LesseePhoneNo);
                p.Add("RegisteredOffice", objModel.objOtherDetails.RegisteredOffice);
                p.Add("Director_in_charge", objModel.objOtherDetails.Director_in_charge);
                p.Add("Agent", objModel.objOtherDetails.Agent);
                p.Add("Manager", objModel.objOtherDetails.Manager);
                p.Add("MiningEngineer_in_charge", objModel.objOtherDetails.MiningEngineer_in_charge);
                p.Add("Geologist_in_charge", objModel.objOtherDetails.Geologist_in_charge);
                p.Add("Transferor", objModel.objOtherDetails.Transferor);
                p.Add("Dateof_Transfer", objModel.objOtherDetails.Dateof_Transfer);
                p.Add("Financial_Year", objModel.objOtherDetails.Year);
                p.Add("MinePostOffice", objModel.objOtherDetails.MinePostOffice);
                p.Add("MineFaxNo", objModel.objOtherDetails.MineFaxNo);
                p.Add("LesseeFaxNo", objModel.objOtherDetails.LesseeFaxNo);
                p.Add("CreatedBy", objModel.objMineDetails.UID);
                p.Add("Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_OtherDetails", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "This Details Already Exit..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Inserted";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }

        }

        /// <summary>
        /// Add Particulars of Area Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddParticularsofArea(AnnualReturnH1ViewModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                DataTable dataTable = new DataTable("ParticularsofArea");
                //we create column names as per the type in DB 
                dataTable.Columns.Add("PAId", typeof(Int32));
                dataTable.Columns.Add("Particular_Id", typeof(Int32));
                dataTable.Columns.Add("Lease_number", typeof(string));
                dataTable.Columns.Add("underlease_UnderForest", typeof(string));
                dataTable.Columns.Add("underlease_OutsideForest", typeof(string));
                dataTable.Columns.Add("underlease_Total", typeof(string));
                dataTable.Columns.Add("Date_of_execution", typeof(DateTime));
                dataTable.Columns.Add("Periodoflease", typeof(string));
                dataTable.Columns.Add("Surfacerights_UnderForest", typeof(string));
                dataTable.Columns.Add("Surfacerights_OutsideForest", typeof(string));
                dataTable.Columns.Add("Surfacerights_Total", typeof(string));
                dataTable.Columns.Add("RenewalDate", typeof(DateTime));
                dataTable.Columns.Add("RenewalPeriod", typeof(string));
                dataTable.Columns.Add("Mineral_produced", typeof(string));
                dataTable.Columns.Add("More_mine_details", typeof(string));
                dataTable.Columns.Add("CreatedBy", typeof(Int32));


                for (var i = 0; i < objModel.objParticular.Lease_number.Count; i++)
                {
                    dataTable.Rows.Add(i + 1, //objModel.objParticular.Particular_Id[i],
                                                i + 1,
                                              objModel.objParticular.Lease_number[i],
                                              objModel.objParticular.underlease_UnderForest[i],
                                              objModel.objParticular.underlease_OutsideForest[i],
                                              objModel.objParticular.underlease_Total[i],
                                              objModel.objParticular.Date_of_execution[i],
                                              objModel.objParticular.Periodoflease[i],
                                              objModel.objParticular.Surfacerights_UnderForest[i],
                                              objModel.objParticular.Surfacerights_OutsideForest[i],
                                              objModel.objParticular.Surfacerights_Total[i],
                                              objModel.objParticular.RenewalDate[i],
                                              objModel.objParticular.RenewalPeriod[i],
                                              objModel.objParticular.Mineral_produced,
                                              objModel.objParticular.More_mine_details,
                                              objModel.objParticular.UID);
                }



                var p = new DynamicParameters();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    p.Add("BULK_ParticularArea", dataTable, DbType.Object);
                }
                p.Add("Financial_Year", objModel.objParticular.Year);

                p.Add("Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_ParticularsofArea", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "This Details Already Exit..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Inserted";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }

        }

        /// <summary>
        /// Add Lease Area 
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddLeasearea(AnnualReturnH1ViewModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("UnderForest1", objModel.objLeaseArea.UnderForest1);
                p.Add("UnderForest2", objModel.objLeaseArea.UnderForest2);
                p.Add("UnderForest3", objModel.objLeaseArea.UnderForest3);
                p.Add("UnderForest4", objModel.objLeaseArea.UnderForest4);
                p.Add("UnderForest5", objModel.objLeaseArea.UnderForest5);
                p.Add("UnderForest6", objModel.objLeaseArea.UnderForest6);
                p.Add("UnderForest7", objModel.objLeaseArea.UnderForest7);
                p.Add("Outsideforest1", objModel.objLeaseArea.Outsideforest1);
                p.Add("Outsideforest2", objModel.objLeaseArea.Outsideforest2);
                p.Add("Outsideforest3", objModel.objLeaseArea.Outsideforest3);
                p.Add("Outsideforest4", objModel.objLeaseArea.Outsideforest4);
                p.Add("Outsideforest5", objModel.objLeaseArea.Outsideforest5);
                p.Add("Outsideforest6", objModel.objLeaseArea.Outsideforest6);
                p.Add("Outsideforest7", objModel.objLeaseArea.Outsideforest7);
                p.Add("Total1", objModel.objLeaseArea.Total1);
                p.Add("Total2", objModel.objLeaseArea.Total2);
                p.Add("Total3", objModel.objLeaseArea.Total3);
                p.Add("Total4", objModel.objLeaseArea.Total4);
                p.Add("Total5", objModel.objLeaseArea.Total5);
                p.Add("Total6", objModel.objLeaseArea.Total6);
                p.Add("Total7", objModel.objLeaseArea.Total7);
                p.Add("AgencyofMine", objModel.objLeaseArea.AgencyofMine);
                p.Add("Financial_Year", objModel.objLeaseArea.Year);
                p.Add("CreatedBy", objModel.objLeaseArea.UID);
                p.Add("Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_Leasearea", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "This Details Already Exit..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Inserted";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }

        }

        /// <summary>
        /// Update Mine Other Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateMineOtherDetails(AnnualReturnH1ViewModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("OtherDetails_Id", objModel.objOtherDetails.OtherDetails_Id);
                p.Add("Registrationnumber", objModel.objMineDetails.Registrationnumber);
                p.Add("MINE_CODE", objModel.objMineDetails.MINE_CODE);
                p.Add("OtherMineral", objModel.objMineDetails.OtherMineral);
                p.Add("MineralName", objModel.objMineDetails.MineralName);
                p.Add("MineName", objModel.objMineDetails.MineName);
                p.Add("MineAddress", objModel.objMineDetails.MineAddress);
                p.Add("MineVillage", objModel.objMineDetails.MineVillage);
                p.Add("MineDistrict", objModel.objMineDetails.MineDistrict);
                p.Add("MineState", objModel.objMineDetails.MineState);
                p.Add("MineTehsil", objModel.objMineDetails.MineTehsil);
                p.Add("MinePinCode", objModel.objMineDetails.MinePinCode);
                p.Add("MineEmailID", objModel.objMineDetails.MineEmailID);
                p.Add("MineMobileNo", objModel.objMineDetails.MineMobileNo);
                p.Add("MinePhoneNo", objModel.objMineDetails.MinePhoneNo);
                p.Add("LesseeName", objModel.objMineDetails.LesseeName);
                p.Add("LesseeAddress", objModel.objMineDetails.LesseeAddress);
                p.Add("LesseeVillageName", objModel.objMineDetails.LesseeVillageName);
                p.Add("LesseeDistrictName", objModel.objMineDetails.LesseeDistrictName);
                p.Add("LesseeStateName", objModel.objMineDetails.LesseeStateName);
                p.Add("LesseePinCode", objModel.objMineDetails.LesseePinCode);
                p.Add("LesseeTehsilName", objModel.objMineDetails.LesseeTehsilName);
                p.Add("LesseeEmailID", objModel.objMineDetails.LesseeEmailID);
                p.Add("LesseeMobileNo", objModel.objMineDetails.LesseeMobileNo);
                p.Add("LesseePhoneNo", objModel.objMineDetails.LesseePhoneNo);
                p.Add("RegisteredOffice", objModel.objOtherDetails.RegisteredOffice);
                p.Add("Director_in_charge", objModel.objOtherDetails.Director_in_charge);
                p.Add("Agent", objModel.objOtherDetails.Agent);
                p.Add("Manager", objModel.objOtherDetails.Manager);
                p.Add("MiningEngineer_in_charge", objModel.objOtherDetails.MiningEngineer_in_charge);
                p.Add("Geologist_in_charge", objModel.objOtherDetails.Geologist_in_charge);
                p.Add("Transferor", objModel.objOtherDetails.Transferor);
                p.Add("Dateof_Transfer", objModel.objOtherDetails.Dateof_Transfer);
                p.Add("Financial_Year", objModel.objOtherDetails.Year);
                p.Add("MinePostOffice", objModel.objOtherDetails.MinePostOffice);
                p.Add("MineFaxNo", objModel.objOtherDetails.MineFaxNo);
                p.Add("LesseeFaxNo", objModel.objOtherDetails.LesseeFaxNo);
                p.Add("ModifiedBy", objModel.objMineDetails.UID);
                p.Add("Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_OtherDetails", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "Record Has not Updated..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Updated..";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }



        }

        /// <summary>
        /// Update particulars of Area
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateParticularsofArea(AnnualReturnH1ViewModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                DataTable dataTable = new DataTable("ParticularsofArea");
                //we create column names as per the type in DB 
                dataTable.Columns.Add("PAId", typeof(Int32));
                dataTable.Columns.Add("Particular_Id", typeof(Int32));
                dataTable.Columns.Add("Lease_number", typeof(string));
                dataTable.Columns.Add("underlease_UnderForest", typeof(string));
                dataTable.Columns.Add("underlease_OutsideForest", typeof(string));
                dataTable.Columns.Add("underlease_Total", typeof(string));
                dataTable.Columns.Add("Date_of_execution", typeof(DateTime));
                dataTable.Columns.Add("Periodoflease", typeof(string));
                dataTable.Columns.Add("Surfacerights_UnderForest", typeof(string));
                dataTable.Columns.Add("Surfacerights_OutsideForest", typeof(string));
                dataTable.Columns.Add("Surfacerights_Total", typeof(string));
                dataTable.Columns.Add("RenewalDate", typeof(DateTime));
                dataTable.Columns.Add("RenewalPeriod", typeof(string));
                dataTable.Columns.Add("Mineral_produced", typeof(string));
                dataTable.Columns.Add("More_mine_details", typeof(string));
                dataTable.Columns.Add("CreatedBy", typeof(Int32));


                for (var i = 0; i < objModel.objParticular.Lease_number.Count; i++)
                {
                    dataTable.Rows.Add(i + 1, //objModel.objParticular.Particular_Id[i],
                                                objModel.objParticular.Particular_Id[i],
                                              objModel.objParticular.Lease_number[i],
                                              objModel.objParticular.underlease_UnderForest[i],
                                              objModel.objParticular.underlease_OutsideForest[i],
                                              objModel.objParticular.underlease_Total[i],
                                              objModel.objParticular.Date_of_execution[i],
                                              objModel.objParticular.Periodoflease[i],
                                              objModel.objParticular.Surfacerights_UnderForest[i],
                                              objModel.objParticular.Surfacerights_OutsideForest[i],
                                              objModel.objParticular.Surfacerights_Total[i],
                                              objModel.objParticular.RenewalDate[i],
                                              objModel.objParticular.RenewalPeriod[i],
                                              objModel.objParticular.Mineral_produced,
                                              objModel.objParticular.More_mine_details,
                                              objModel.objParticular.UID);
                }



                var p = new DynamicParameters();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    p.Add("BULK_ParticularArea", dataTable, DbType.Object);
                }
                p.Add("Financial_Year", objModel.objParticular.Year);
                p.Add("ModifiedBy", objModel.objParticular.UID);

                p.Add("Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_ParticularsofArea", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "Record Has not Updated..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Updated..";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }

        }

        /// <summary>
        /// Update Lease Area 
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateLeasearea(AnnualReturnH1ViewModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Lease_Area_Id", objModel.objLeaseArea.Lease_Area_Id);
                p.Add("UnderForest1", objModel.objLeaseArea.UnderForest1);
                p.Add("UnderForest2", objModel.objLeaseArea.UnderForest2);
                p.Add("UnderForest3", objModel.objLeaseArea.UnderForest3);
                p.Add("UnderForest4", objModel.objLeaseArea.UnderForest4);
                p.Add("UnderForest5", objModel.objLeaseArea.UnderForest5);
                p.Add("UnderForest6", objModel.objLeaseArea.UnderForest6);
                p.Add("UnderForest7", objModel.objLeaseArea.UnderForest7);
                p.Add("Outsideforest1", objModel.objLeaseArea.Outsideforest1);
                p.Add("Outsideforest2", objModel.objLeaseArea.Outsideforest2);
                p.Add("Outsideforest3", objModel.objLeaseArea.Outsideforest3);
                p.Add("Outsideforest4", objModel.objLeaseArea.Outsideforest4);
                p.Add("Outsideforest5", objModel.objLeaseArea.Outsideforest5);
                p.Add("Outsideforest6", objModel.objLeaseArea.Outsideforest6);
                p.Add("Outsideforest7", objModel.objLeaseArea.Outsideforest7);
                p.Add("Total1", objModel.objLeaseArea.Total1);
                p.Add("Total2", objModel.objLeaseArea.Total2);
                p.Add("Total3", objModel.objLeaseArea.Total3);
                p.Add("Total4", objModel.objLeaseArea.Total4);
                p.Add("Total5", objModel.objLeaseArea.Total5);
                p.Add("Total6", objModel.objLeaseArea.Total6);
                p.Add("Total7", objModel.objLeaseArea.Total7);
                p.Add("AgencyofMine", objModel.objLeaseArea.AgencyofMine);
                p.Add("Financial_Year", objModel.objLeaseArea.Year);
                p.Add("ModifiedBy", objModel.objLeaseArea.UID);
                p.Add("Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_Leasearea", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "Record Has not Updated..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Updated..";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }

        }
        #endregion

        #region Part 2 H1
        /// <summary>
        /// Get Staff and work details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>StaffandWorkModel class</returns>
        public async Task<StaffandWorkModel> GetStaffandWork(MonthlyReturnModelNonCoal model)
        {
            StaffandWorkModel objModel = new StaffandWorkModel();
            try
            {
                var paramList = new
                {
                    Return_Year = model.Year,
                    UserID = model.Uid,
                    Check = 1,
                };

                var result = await Connection.ExecuteReaderAsync("GetAnnualReturnPart2", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    objModel.WorkDetails_Id = Convert.ToInt32(dt.Rows[0]["WorkDetails_Id"]);
                    objModel.Whollyemployed1 = Convert.ToString(dt.Rows[0]["Whollyemployed1"]);
                    objModel.Whollyemployed2 = Convert.ToString(dt.Rows[0]["Whollyemployed2"]);
                    objModel.Whollyemployed3 = Convert.ToString(dt.Rows[0]["Whollyemployed3"]);
                    objModel.Whollyemployed4 = Convert.ToString(dt.Rows[0]["Whollyemployed4"]);
                    objModel.Whollyemployed5 = Convert.ToString(dt.Rows[0]["Whollyemployed5"]);
                    objModel.Whollyemployed_Total = Convert.ToString(dt.Rows[0]["Whollyemployed_Total"]);
                    objModel.Partlyemployed1 = Convert.ToString(dt.Rows[0]["Partlyemployed1"]);
                    objModel.Partlyemployed2 = Convert.ToString(dt.Rows[0]["Partlyemployed2"]);
                    objModel.Partlyemployed3 = Convert.ToString(dt.Rows[0]["Partlyemployed3"]);
                    objModel.Partlyemployed4 = Convert.ToString(dt.Rows[0]["Partlyemployed4"]);
                    objModel.Partlyemployed5 = Convert.ToString(dt.Rows[0]["Partlyemployed5"]);
                    objModel.Partlyemployed_Total = Convert.ToString(dt.Rows[0]["Partlyemployed_Total"]);

                }
                return objModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                model = null;
                objModel = null;
            }
        }

        /// <summary>
        /// Get Salary wages paid details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>SalaryWagesPaidModel class</returns>
        public async Task<SalaryWagesPaidModel> GetSalaryWagesPaid(MonthlyReturnModelNonCoal model)
        {
            SalaryWagesPaidModel objModel = new SalaryWagesPaidModel();
            try
            {
                var paramList = new
                {
                    Return_Year = model.Year,
                    UserID = model.Uid,
                    Check = 2,
                };
                var result = await Connection.ExecuteReaderAsync("GetAnnualReturnPart2", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    objModel.SalaryWages_Id = Convert.ToInt32(dt.Rows[0]["SalaryWages_Id"]);

                    string WorkingBelowGrounddate = Convert.ToString(dt.Rows[0]["WorkingBelowGrounddate"]);
                    if (WorkingBelowGrounddate != null && WorkingBelowGrounddate != "")
                        objModel.WorkingBelowGrounddate_str = (Convert.ToDateTime(dt.Rows[0]["WorkingBelowGrounddate"])).ToString("dd/MM/yyyy");

                    objModel.WorkingBelowNo = Convert.ToString(dt.Rows[0]["WorkingBelowNo"]);

                    string WorkingOnMinedate = Convert.ToString(dt.Rows[0]["WorkingOnMinedate"]);
                    if (WorkingOnMinedate != null && WorkingOnMinedate != "")
                        objModel.WorkingOnMinedate_str = (Convert.ToDateTime(dt.Rows[0]["WorkingOnMinedate"])).ToString("dd/MM/yyyy");
                    objModel.WorkingOnMineNo = Convert.ToString(dt.Rows[0]["WorkingOnMineNo"]);
                    objModel.BG_Direct = Convert.ToString(dt.Rows[0]["BG_Direct"]);
                    objModel.BG_Contract = Convert.ToString(dt.Rows[0]["BG_Contract"]);
                    objModel.BG_Total = Convert.ToString(dt.Rows[0]["BG_Total"]);
                    objModel.BG_NoOFDaysWork = Convert.ToString(dt.Rows[0]["BG_NoOFDaysWork"]);
                    objModel.BG_Male = Convert.ToString(dt.Rows[0]["BG_Male"]);
                    objModel.BG_Female = Convert.ToString(dt.Rows[0]["BG_Female"]);
                    objModel.BG_Average_Total = Convert.ToString(dt.Rows[0]["BG_Average_Total"]);
                    objModel.BG_TotalWages = Convert.ToString(dt.Rows[0]["BG_TotalWages"]);
                    objModel.OC_Direct = Convert.ToString(dt.Rows[0]["OC_Direct"]);
                    objModel.OC_Contract = Convert.ToString(dt.Rows[0]["OC_Contract"]);
                    objModel.OC_Total = Convert.ToString(dt.Rows[0]["OC_Total"]);
                    objModel.OC_NoOFDaysWork = Convert.ToString(dt.Rows[0]["OC_NoOFDaysWork"]);
                    objModel.OC_Male = Convert.ToString(dt.Rows[0]["OC_Male"]);
                    objModel.OC_Female = Convert.ToString(dt.Rows[0]["OC_Female"]);
                    objModel.OC_Average_Total = Convert.ToString(dt.Rows[0]["OC_Average_Total"]);
                    objModel.OC_TotalWages = Convert.ToString(dt.Rows[0]["OC_TotalWages"]);
                    objModel.AG_Direct = Convert.ToString(dt.Rows[0]["AG_Direct"]);
                    objModel.AG_Contract = Convert.ToString(dt.Rows[0]["AG_Contract"]);
                    objModel.AG_Total = Convert.ToString(dt.Rows[0]["AG_Total"]);
                    objModel.AG_NoOFDaysWork = Convert.ToString(dt.Rows[0]["AG_NoOFDaysWork"]);
                    objModel.AG_Male = Convert.ToString(dt.Rows[0]["AG_Male"]);
                    objModel.AG_Female = Convert.ToString(dt.Rows[0]["AG_Female"]);
                    objModel.AG_Average_Total = Convert.ToString(dt.Rows[0]["AG_Average_Total"]);
                    objModel.AG_TotalWages = Convert.ToString(dt.Rows[0]["AG_TotalWages"]);
                    objModel.Total_Direct = Convert.ToString(dt.Rows[0]["Total_Direct"]);
                    objModel.Total_Contract = Convert.ToString(dt.Rows[0]["Total_Contract"]);
                    objModel.Total_Total = Convert.ToString(dt.Rows[0]["Total_Total"]);
                    objModel.Total_NoOFDaysWork = Convert.ToString(dt.Rows[0]["Total_NoOFDaysWork"]);
                    objModel.Total_Male = Convert.ToString(dt.Rows[0]["Total_Male"]);
                    objModel.Total_Female = Convert.ToString(dt.Rows[0]["Total_Female"]);
                    objModel.Total_Average_Total = Convert.ToString(dt.Rows[0]["Total_Average_Total"]);
                    objModel.Total_TotalWages = Convert.ToString(dt.Rows[0]["Total_TotalWages"]);

                }
                return objModel;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                model = null;
                objModel = null;
            }
        }

        /// <summary>
        /// Get Capital structure details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>CapitalStructure class</returns>
        public async Task<CapitalStructure> GetCapitalStructure(MonthlyReturnModelNonCoal model)
        {
            CapitalStructure objModel = new CapitalStructure();
            try
            {
                var paramList = new
                {
                    Return_Year = model.Year,
                    UserID = model.Uid,
                    Check = 3,
                };
                var result = await Connection.ExecuteReaderAsync("GetAnnualReturnPart2", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    objModel.CapitalStructure_Id = Convert.ToInt32(dt.Rows[0]["CapitalStructure_Id"]);

                    objModel.ValueofFixedAssets = Convert.ToString(dt.Rows[0]["ValueofFixedAssets"]);
                    objModel.OtherMineCode = Convert.ToString(dt.Rows[0]["OtherMineCode"]);
                    objModel.Land_AtBeginning = Convert.ToString(dt.Rows[0]["Land_AtBeginning"]);
                    objModel.Land_Additions = Convert.ToString(dt.Rows[0]["Land_Additions"]);
                    objModel.Land_Sold_Discarded = Convert.ToString(dt.Rows[0]["Land_Sold_Discarded"]);
                    objModel.Land_Depreciation = Convert.ToString(dt.Rows[0]["Land_Depreciation"]);
                    objModel.Land_Net_closing_Balance = Convert.ToString(dt.Rows[0]["Land_Net_closing_Balance"]);
                    objModel.Land_Estimated_Market = Convert.ToString(dt.Rows[0]["Land_Estimated_Market"]);
                    objModel.Industrial_AtBeginning = Convert.ToString(dt.Rows[0]["Industrial_AtBeginning"]);
                    objModel.Industrial_Additions = Convert.ToString(dt.Rows[0]["Industrial_Additions"]);
                    objModel.Industrial_Sold_Discarded = Convert.ToString(dt.Rows[0]["Industrial_Sold_Discarded"]);
                    objModel.Industrial_Depreciation = Convert.ToString(dt.Rows[0]["Industrial_Depreciation"]);
                    objModel.Industrial_Net_closing_Balance = Convert.ToString(dt.Rows[0]["Industrial_Net_closing_Balance"]);
                    objModel.Industrial_Estimated_Market = Convert.ToString(dt.Rows[0]["Industrial_Estimated_Market"]);
                    objModel.Residential_AtBeginning = Convert.ToString(dt.Rows[0]["Residential_AtBeginning"]);
                    objModel.Residential_Additions = Convert.ToString(dt.Rows[0]["Residential_Additions"]);
                    objModel.Residential_Sold_Discarded = Convert.ToString(dt.Rows[0]["Residential_Sold_Discarded"]);
                    objModel.Residential_Depreciation = Convert.ToString(dt.Rows[0]["Residential_Depreciation"]);
                    objModel.Residential_Net_closing_Balance = Convert.ToString(dt.Rows[0]["Residential_Net_closing_Balance"]);
                    objModel.Residential_Estimated_Market = Convert.ToString(dt.Rows[0]["Residential_Estimated_Market"]);
                    objModel.P_M_T_AtBeginning = Convert.ToString(dt.Rows[0]["P_M_T_AtBeginning"]);
                    objModel.P_M_T_Additions = Convert.ToString(dt.Rows[0]["P_M_T_Additions"]);
                    objModel.P_M_T_Sold_Discarded = Convert.ToString(dt.Rows[0]["P_M_T_Sold_Discarded"]);
                    objModel.P_M_T_Depreciation = Convert.ToString(dt.Rows[0]["P_M_T_Depreciation"]);
                    objModel.P_M_T_Net_closing_Balance = Convert.ToString(dt.Rows[0]["P_M_T_Net_closing_Balance"]);
                    objModel.P_M_T_Estimated_Market = Convert.ToString(dt.Rows[0]["P_M_T_Estimated_Market"]);
                    objModel.Exp_AtBeginning = Convert.ToString(dt.Rows[0]["Exp_AtBeginning"]);
                    objModel.Exp_Additions = Convert.ToString(dt.Rows[0]["Exp_Additions"]);
                    objModel.Exp_Sold_Discarded = Convert.ToString(dt.Rows[0]["Exp_Sold_Discarded"]);
                    objModel.Exp_Depreciation = Convert.ToString(dt.Rows[0]["Exp_Depreciation"]);
                    objModel.Exp_Net_closing_Balance = Convert.ToString(dt.Rows[0]["Exp_Net_closing_Balance"]);
                    objModel.Exp_Estimated_Market = Convert.ToString(dt.Rows[0]["Exp_Estimated_Market"]);
                    objModel.Total_AtBeginning = Convert.ToString(dt.Rows[0]["Total_AtBeginning"]);
                    objModel.Total_Additions = Convert.ToString(dt.Rows[0]["Total_Additions"]);
                    objModel.Total_Sold_Discarded = Convert.ToString(dt.Rows[0]["Total_Sold_Discarded"]);
                    objModel.Total_Depreciation = Convert.ToString(dt.Rows[0]["Total_Depreciation"]);
                    objModel.Total_Net_closing_Balance = Convert.ToString(dt.Rows[0]["Total_Net_closing_Balance"]);
                    objModel.Total_Estimated_Market = Convert.ToString(dt.Rows[0]["Total_Estimated_Market"]);

                }
                return objModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                model = null;
                objModel = null;
            }
        }

        /// <summary>
        /// Get source of finance details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>SourceOfFinance class</returns>
        public async Task<SourceOfFinance> GetSourceOfFinance(MonthlyReturnModelNonCoal model)
        {
            SourceOfFinance objModel = new SourceOfFinance();
            try
            {
                var paramList = new
                {
                    Return_Year = model.Year,
                    UserID = model.Uid,
                    Check = 4,
                };
                var result = await Connection.ExecuteReaderAsync("GetAnnualReturnPart2", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    objModel.SourceOfFinance_Id = Convert.ToInt32(dt.Rows[0]["SourceOfFinance_Id"]);
                    objModel.ShareCapital = Convert.ToString(dt.Rows[0]["ShareCapital"]);
                    objModel.OwnCapital = Convert.ToString(dt.Rows[0]["OwnCapital"]);
                    objModel.Reserve = Convert.ToString(dt.Rows[0]["Reserve"]);
                    objModel.Institution = Convert.ToString(dt.Rows[0]["Institution"]);
                    objModel.AmountofLoan = Convert.ToString(dt.Rows[0]["AmountofLoan"]);
                    objModel.RateofInterest = Convert.ToString(dt.Rows[0]["RateofInterest"]);
                    objModel.Interestpaid = Convert.ToString(dt.Rows[0]["Interestpaid"]);
                    objModel.Rentspaid = Convert.ToString(dt.Rows[0]["Rentspaid"]);

                }
                return objModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                model = null;
                objModel = null;
            }
        }

        /// <summary>
        /// Get work details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>WorkModel class</returns>
        public async Task<WorkModel> GetWorkDetails(MonthlyReturnModelNonCoal model)
        {
            WorkModel objModel = new WorkModel();
            try
            {
                var paramList = new
                {
                    Return_Year = model.Year,
                    UserID = model.Uid,
                    Check = 5,
                };
                var result = await Connection.ExecuteReaderAsync("GetAnnualReturnPart2", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    if (dt != null)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            objModel.NoOfDaysMineWorked = Convert.ToInt32(dt.Rows[0]["NoOfDaysMineWorked"]);
                            objModel.NoOfShiftPerDay = Convert.ToInt32(dt.Rows[0]["NoOfShiftPerDay"]);
                            objModel.Work_Id.Add(Convert.ToInt32(dt.Rows[i]["Work_Id"]));
                            objModel.Reason.Add(Convert.ToString(dt.Rows[i]["Reason"]));
                            objModel.NoOfDaysMineStop.Add(Convert.ToInt32(dt.Rows[i]["NoOfDaysMineStop"]));

                        }
                    }

                }
                return objModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                model = null;
                objModel = null;
            }
        }

        /// <summary>
        /// Add staff and work
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddStaffandWork(AnnualReturnH1PartTwoModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Whollyemployed1", objModel.objStaffWork.Whollyemployed1);
                p.Add("Whollyemployed2", objModel.objStaffWork.Whollyemployed2);
                p.Add("Whollyemployed3", objModel.objStaffWork.Whollyemployed3);
                p.Add("Whollyemployed4", objModel.objStaffWork.Whollyemployed4);
                p.Add("Whollyemployed5", objModel.objStaffWork.Whollyemployed5);
                p.Add("Whollyemployed_Total", objModel.objStaffWork.Whollyemployed_Total);
                p.Add("Partlyemployed1", objModel.objStaffWork.Partlyemployed1);
                p.Add("Partlyemployed2", objModel.objStaffWork.Partlyemployed2);
                p.Add("Partlyemployed3", objModel.objStaffWork.Partlyemployed3);
                p.Add("Partlyemployed4", objModel.objStaffWork.Partlyemployed4);
                p.Add("Partlyemployed5", objModel.objStaffWork.Partlyemployed5);
                p.Add("Partlyemployed_Total", objModel.objStaffWork.Partlyemployed_Total);
                p.Add("Financial_Year", objModel.objStaffWork.Year);
                p.Add("CreatedBy", objModel.objStaffWork.UID);
                p.Add("Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_StaffandWork", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "This Details Already Exit..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Saved";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;

            }

        }

        /// <summary>
        /// Add work details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddWorkDetails(AnnualReturnH1PartTwoModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                DataTable dataTable = new DataTable("MineWork");

                dataTable.Columns.Add("Work_Id", typeof(Int32));
                dataTable.Columns.Add("NoOfDaysMineStop", typeof(Int32));
                dataTable.Columns.Add("Reason", typeof(string));
                dataTable.Columns.Add("CreatedBy", typeof(Int32));
                for (var i = 0; i < objModel.objWork.NoOfDaysMineStop.Count; i++)
                {
                    dataTable.Rows.Add(i + 1, objModel.objWork.NoOfDaysMineStop[i],
                                              objModel.objWork.Reason[i],
                                             objModel.objWork.UID);
                }
                var p = new DynamicParameters();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    p.Add("BULK_MINEWORK", dataTable, DbType.Object);
                }
                p.Add("NoOfDaysMineWorked", objModel.objWork.NoOfDaysMineWorked);
                p.Add("NoOfShiftPerDay", objModel.objWork.NoOfShiftPerDay);
                p.Add("Financial_Year", objModel.objWork.Year);
                p.Add("CreatedBy", objModel.objWork.UID);
                p.Add("Check", 3);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_StaffandWork", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "This Details Already Exit..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Saved";
                }
                return objMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }
        }

        /// <summary>
        /// Add salary wages paid
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddSalaryWagesPaid(AnnualReturnH1PartTwoModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("WorkingBelowGrounddate", objModel.objSalaryWages.WorkingBelowGrounddate_str);
                p.Add("WorkingBelowNo", objModel.objSalaryWages.WorkingBelowNo);
                p.Add("WorkingOnMinedate", objModel.objSalaryWages.WorkingOnMinedate_str);
                p.Add("WorkingOnMineNo", objModel.objSalaryWages.WorkingOnMineNo);
                p.Add("BG_Direct", objModel.objSalaryWages.BG_Direct);
                p.Add("BG_Contract", objModel.objSalaryWages.BG_Contract);
                p.Add("BG_Total", objModel.objSalaryWages.BG_Total);
                p.Add("BG_NoOFDaysWork", objModel.objSalaryWages.BG_NoOFDaysWork);
                p.Add("BG_Male", objModel.objSalaryWages.BG_Male);
                p.Add("BG_Female", objModel.objSalaryWages.BG_Female);
                p.Add("BG_Average_Total", objModel.objSalaryWages.BG_Average_Total);
                p.Add("BG_TotalWages", objModel.objSalaryWages.BG_TotalWages);
                p.Add("OC_Direct", objModel.objSalaryWages.OC_Direct);
                p.Add("OC_Contract", objModel.objSalaryWages.OC_Contract);
                p.Add("OC_Total", objModel.objSalaryWages.OC_Total);
                p.Add("OC_NoOFDaysWork", objModel.objSalaryWages.OC_NoOFDaysWork);
                p.Add("OC_Male", objModel.objSalaryWages.OC_Male);
                p.Add("OC_Female", objModel.objSalaryWages.OC_Female);
                p.Add("OC_Average_Total", objModel.objSalaryWages.OC_Average_Total);
                p.Add("OC_TotalWages", objModel.objSalaryWages.OC_TotalWages);
                p.Add("AG_Direct", objModel.objSalaryWages.AG_Direct);
                p.Add("AG_Contract", objModel.objSalaryWages.AG_Contract);
                p.Add("AG_Total", objModel.objSalaryWages.AG_Total);
                p.Add("AG_NoOFDaysWork", objModel.objSalaryWages.AG_NoOFDaysWork);
                p.Add("AG_Male", objModel.objSalaryWages.AG_Male);
                p.Add("AG_Female", objModel.objSalaryWages.AG_Female);
                p.Add("AG_Average_Total", objModel.objSalaryWages.AG_Average_Total);
                p.Add("AG_TotalWages", objModel.objSalaryWages.AG_TotalWages);
                p.Add("Total_Direct", objModel.objSalaryWages.Total_Direct);
                p.Add("Total_Contract", objModel.objSalaryWages.Total_Contract);
                p.Add("Total_Total", objModel.objSalaryWages.Total_Total);
                p.Add("Total_NoOFDaysWork", objModel.objSalaryWages.Total_NoOFDaysWork);
                p.Add("Total_Male", objModel.objSalaryWages.Total_Male);
                p.Add("Total_Female", objModel.objSalaryWages.Total_Female);
                p.Add("Total_Average_Total", objModel.objSalaryWages.Total_Average_Total);
                p.Add("Total_TotalWages", objModel.objSalaryWages.Total_TotalWages);
                p.Add("Financial_Year", objModel.objSalaryWages.Year);
                p.Add("CreatedBy", objModel.objSalaryWages.UID);
                p.Add("Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_SalaryWagesPaid", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "This Details Already Exit..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Saved";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }
        }

        /// <summary>
        /// Add Capital Structure Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddCapitalStructure(AnnualReturnH1PartTwoModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("ValueofFixedAssets", objModel.objCapitalStructure.ValueofFixedAssets);
                p.Add("OtherMineCode", objModel.objCapitalStructure.OtherMineCode);
                p.Add("Land_AtBeginning", objModel.objCapitalStructure.Land_AtBeginning);
                p.Add("Land_Additions", objModel.objCapitalStructure.Land_Additions);
                p.Add("Land_Sold_Discarded", objModel.objCapitalStructure.Land_Sold_Discarded);
                p.Add("Land_Depreciation", objModel.objCapitalStructure.Land_Depreciation);
                p.Add("Land_Net_closing_Balance", objModel.objCapitalStructure.Land_Net_closing_Balance);
                p.Add("Land_Estimated_Market", objModel.objCapitalStructure.Land_Estimated_Market);
                p.Add("Industrial_AtBeginning", objModel.objCapitalStructure.Industrial_AtBeginning);
                p.Add("Industrial_Additions", objModel.objCapitalStructure.Industrial_Additions);
                p.Add("Industrial_Sold_Discarded", objModel.objCapitalStructure.Industrial_Sold_Discarded);
                p.Add("Industrial_Depreciation", objModel.objCapitalStructure.Industrial_Depreciation);
                p.Add("Industrial_Net_closing_Balance", objModel.objCapitalStructure.Industrial_Net_closing_Balance);
                p.Add("Industrial_Estimated_Market", objModel.objCapitalStructure.Industrial_Estimated_Market);
                p.Add("Residential_AtBeginning", objModel.objCapitalStructure.Residential_AtBeginning);
                p.Add("Residential_Additions", objModel.objCapitalStructure.Residential_Additions);
                p.Add("Residential_Sold_Discarded", objModel.objCapitalStructure.Residential_Sold_Discarded);
                p.Add("Residential_Depreciation", objModel.objCapitalStructure.Residential_Depreciation);
                p.Add("Residential_Net_closing_Balance", objModel.objCapitalStructure.Residential_Net_closing_Balance);
                p.Add("Residential_Estimated_Market", objModel.objCapitalStructure.Residential_Estimated_Market);
                p.Add("P_M_T_AtBeginning", objModel.objCapitalStructure.P_M_T_AtBeginning);
                p.Add("P_M_T_Additions", objModel.objCapitalStructure.P_M_T_Additions);
                p.Add("P_M_T_Sold_Discarded", objModel.objCapitalStructure.P_M_T_Sold_Discarded);
                p.Add("P_M_T_Depreciation", objModel.objCapitalStructure.P_M_T_Depreciation);
                p.Add("P_M_T_Net_closing_Balance", objModel.objCapitalStructure.P_M_T_Net_closing_Balance);
                p.Add("P_M_T_Estimated_Market", objModel.objCapitalStructure.P_M_T_Estimated_Market);
                p.Add("Exp_AtBeginning", objModel.objCapitalStructure.Exp_AtBeginning);
                p.Add("Exp_Additions", objModel.objCapitalStructure.Exp_Additions);
                p.Add("Exp_Sold_Discarded", objModel.objCapitalStructure.Exp_Sold_Discarded);
                p.Add("Exp_Depreciation", objModel.objCapitalStructure.Exp_Depreciation);
                p.Add("Exp_Net_closing_Balance", objModel.objCapitalStructure.Exp_Net_closing_Balance);
                p.Add("Exp_Estimated_Market", objModel.objCapitalStructure.Exp_Estimated_Market);
                p.Add("Total_AtBeginning", objModel.objCapitalStructure.Total_AtBeginning);
                p.Add("Total_Additions", objModel.objCapitalStructure.Total_Additions);
                p.Add("Total_Sold_Discarded", objModel.objCapitalStructure.Total_Sold_Discarded);
                p.Add("Total_Depreciation", objModel.objCapitalStructure.Total_Depreciation);
                p.Add("Total_Net_closing_Balance", objModel.objCapitalStructure.Total_Net_closing_Balance);
                p.Add("Total_Estimated_Market", objModel.objCapitalStructure.Total_Estimated_Market);
                p.Add("Financial_Year", objModel.objCapitalStructure.Year);
                p.Add("CreatedBy", objModel.objCapitalStructure.UID);
                p.Add("Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_CapitalStructure", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "This Details Already Exit..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Saved";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }



        }

        /// <summary>
        /// Add Source of finance details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddSourceOfFinance(AnnualReturnH1PartTwoModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("ShareCapital", objModel.objSource.ShareCapital);
                p.Add("OwnCapital", objModel.objSource.OwnCapital);
                p.Add("Reserve", objModel.objSource.Reserve);
                p.Add("Institution", objModel.objSource.Institution);
                p.Add("AmountofLoan", objModel.objSource.AmountofLoan);
                p.Add("RateofInterest", objModel.objSource.RateofInterest);
                p.Add("Interestpaid", objModel.objSource.Interestpaid);
                p.Add("Rentspaid", objModel.objSource.Rentspaid);
                p.Add("Financial_Year", objModel.objSource.Year);
                p.Add("CreatedBy", objModel.objSource.UID);
                p.Add("Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_SourceOfFinance", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "This Details Already Exit..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Saved";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }

        }

        /// <summary>
        /// Update staff and work details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateStaffandWork(AnnualReturnH1PartTwoModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("WorkDetails_Id", objModel.objStaffWork.WorkDetails_Id);
                p.Add("Whollyemployed1", objModel.objStaffWork.Whollyemployed1);
                p.Add("Whollyemployed2", objModel.objStaffWork.Whollyemployed2);
                p.Add("Whollyemployed3", objModel.objStaffWork.Whollyemployed3);
                p.Add("Whollyemployed4", objModel.objStaffWork.Whollyemployed4);
                p.Add("Whollyemployed5", objModel.objStaffWork.Whollyemployed5);
                p.Add("Whollyemployed_Total", objModel.objStaffWork.Whollyemployed_Total);
                p.Add("Partlyemployed1", objModel.objStaffWork.Partlyemployed1);
                p.Add("Partlyemployed2", objModel.objStaffWork.Partlyemployed2);
                p.Add("Partlyemployed3", objModel.objStaffWork.Partlyemployed3);
                p.Add("Partlyemployed4", objModel.objStaffWork.Partlyemployed4);
                p.Add("Partlyemployed5", objModel.objStaffWork.Partlyemployed5);
                p.Add("Partlyemployed_Total", objModel.objStaffWork.Partlyemployed_Total);
                p.Add("Financial_Year", objModel.objStaffWork.Year);
                p.Add("ModifiedBy", objModel.objStaffWork.UID);
                p.Add("Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_StaffandWork", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "Record Has not Updated..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Updated..";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }
        }

        /// <summary>
        /// Update work details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateWorkDetails(AnnualReturnH1PartTwoModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                DataTable dataTable = new DataTable("MineWork");
                dataTable.Columns.Add("Work_Id", typeof(Int32));
                dataTable.Columns.Add("NoOfDaysMineStop", typeof(Int32));
                dataTable.Columns.Add("Reason", typeof(string));
                dataTable.Columns.Add("CreatedBy", typeof(Int32));
                for (var i = 0; i < objModel.objWork.NoOfDaysMineStop.Count; i++)
                {
                    dataTable.Rows.Add(i + 1, objModel.objWork.NoOfDaysMineStop[i],
                                              objModel.objWork.Reason[i],
                                             objModel.objWork.UID);
                }
                var p = new DynamicParameters();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    p.Add("BULK_MINEWORK", dataTable, DbType.Object);
                }
                p.Add("NoOfDaysMineWorked", objModel.objWork.NoOfDaysMineWorked);
                p.Add("NoOfShiftPerDay", objModel.objWork.NoOfShiftPerDay);
                p.Add("Financial_Year", objModel.objWork.Year);
                p.Add("CreatedBy", objModel.objWork.UID);
                p.Add("Check", 4);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_StaffandWork", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "This has not Updated..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Updated Successfully";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }

        }

        /// <summary>
        /// Update salary wages paid
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateSalaryWagesPaid(AnnualReturnH1PartTwoModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("SalaryWages_Id", objModel.objSalaryWages.SalaryWages_Id);
                p.Add("WorkingBelowGrounddate", objModel.objSalaryWages.WorkingBelowGrounddate_str);
                p.Add("WorkingBelowNo", objModel.objSalaryWages.WorkingBelowNo);
                p.Add("WorkingOnMinedate", objModel.objSalaryWages.WorkingOnMinedate_str);
                p.Add("WorkingOnMineNo", objModel.objSalaryWages.WorkingOnMineNo);
                p.Add("BG_Direct", objModel.objSalaryWages.BG_Direct);
                p.Add("BG_Contract", objModel.objSalaryWages.BG_Contract);
                p.Add("BG_Total", objModel.objSalaryWages.BG_Total);
                p.Add("BG_NoOFDaysWork", objModel.objSalaryWages.BG_NoOFDaysWork);
                p.Add("BG_Male", objModel.objSalaryWages.BG_Male);
                p.Add("BG_Female", objModel.objSalaryWages.BG_Female);
                p.Add("BG_Average_Total", objModel.objSalaryWages.BG_Average_Total);
                p.Add("BG_TotalWages", objModel.objSalaryWages.BG_TotalWages);
                p.Add("OC_Direct", objModel.objSalaryWages.OC_Direct);
                p.Add("OC_Contract", objModel.objSalaryWages.OC_Contract);
                p.Add("OC_Total", objModel.objSalaryWages.OC_Total);
                p.Add("OC_NoOFDaysWork", objModel.objSalaryWages.OC_NoOFDaysWork);
                p.Add("OC_Male", objModel.objSalaryWages.OC_Male);
                p.Add("OC_Female", objModel.objSalaryWages.OC_Female);
                p.Add("OC_Average_Total", objModel.objSalaryWages.OC_Average_Total);
                p.Add("OC_TotalWages", objModel.objSalaryWages.OC_TotalWages);
                p.Add("AG_Direct", objModel.objSalaryWages.AG_Direct);
                p.Add("AG_Contract", objModel.objSalaryWages.AG_Contract);
                p.Add("AG_Total", objModel.objSalaryWages.AG_Total);
                p.Add("AG_NoOFDaysWork", objModel.objSalaryWages.AG_NoOFDaysWork);
                p.Add("AG_Male", objModel.objSalaryWages.AG_Male);
                p.Add("AG_Female", objModel.objSalaryWages.AG_Female);
                p.Add("AG_Average_Total", objModel.objSalaryWages.AG_Average_Total);
                p.Add("AG_TotalWages", objModel.objSalaryWages.AG_TotalWages);
                p.Add("Total_Direct", objModel.objSalaryWages.Total_Direct);
                p.Add("Total_Contract", objModel.objSalaryWages.Total_Contract);
                p.Add("Total_Total", objModel.objSalaryWages.Total_Total);
                p.Add("Total_NoOFDaysWork", objModel.objSalaryWages.Total_NoOFDaysWork);
                p.Add("Total_Male", objModel.objSalaryWages.Total_Male);
                p.Add("Total_Female", objModel.objSalaryWages.Total_Female);
                p.Add("Total_Average_Total", objModel.objSalaryWages.Total_Average_Total);
                p.Add("Total_TotalWages", objModel.objSalaryWages.Total_TotalWages);
                p.Add("Financial_Year", objModel.objSalaryWages.Year);
                p.Add("ModifiedBy", objModel.objSalaryWages.UID);
                p.Add("Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_SalaryWagesPaid", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "Record Has not Updated..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Updated..";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }
        }

        /// <summary>
        /// Update capital structure
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateCapitalStructure(AnnualReturnH1PartTwoModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CapitalStructure_Id", objModel.objCapitalStructure.CapitalStructure_Id);
                p.Add("ValueofFixedAssets", objModel.objCapitalStructure.ValueofFixedAssets);
                p.Add("OtherMineCode", objModel.objCapitalStructure.OtherMineCode);
                p.Add("Land_AtBeginning", objModel.objCapitalStructure.Land_AtBeginning);
                p.Add("Land_Additions", objModel.objCapitalStructure.Land_Additions);
                p.Add("Land_Sold_Discarded", objModel.objCapitalStructure.Land_Sold_Discarded);
                p.Add("Land_Depreciation", objModel.objCapitalStructure.Land_Depreciation);
                p.Add("Land_Net_closing_Balance", objModel.objCapitalStructure.Land_Net_closing_Balance);
                p.Add("Land_Estimated_Market", objModel.objCapitalStructure.Land_Estimated_Market);
                p.Add("Industrial_AtBeginning", objModel.objCapitalStructure.Industrial_AtBeginning);
                p.Add("Industrial_Additions", objModel.objCapitalStructure.Industrial_Additions);
                p.Add("Industrial_Sold_Discarded", objModel.objCapitalStructure.Industrial_Sold_Discarded);
                p.Add("Industrial_Depreciation", objModel.objCapitalStructure.Industrial_Depreciation);
                p.Add("Industrial_Net_closing_Balance", objModel.objCapitalStructure.Industrial_Net_closing_Balance);
                p.Add("Industrial_Estimated_Market", objModel.objCapitalStructure.Industrial_Estimated_Market);
                p.Add("Residential_AtBeginning", objModel.objCapitalStructure.Residential_AtBeginning);
                p.Add("Residential_Additions", objModel.objCapitalStructure.Residential_Additions);
                p.Add("Residential_Sold_Discarded", objModel.objCapitalStructure.Residential_Sold_Discarded);
                p.Add("Residential_Depreciation", objModel.objCapitalStructure.Residential_Depreciation);
                p.Add("Residential_Net_closing_Balance", objModel.objCapitalStructure.Residential_Net_closing_Balance);
                p.Add("Residential_Estimated_Market", objModel.objCapitalStructure.Residential_Estimated_Market);
                p.Add("P_M_T_AtBeginning", objModel.objCapitalStructure.P_M_T_AtBeginning);
                p.Add("P_M_T_Additions", objModel.objCapitalStructure.P_M_T_Additions);
                p.Add("P_M_T_Sold_Discarded", objModel.objCapitalStructure.P_M_T_Sold_Discarded);
                p.Add("P_M_T_Depreciation", objModel.objCapitalStructure.P_M_T_Depreciation);
                p.Add("P_M_T_Net_closing_Balance", objModel.objCapitalStructure.P_M_T_Net_closing_Balance);
                p.Add("P_M_T_Estimated_Market", objModel.objCapitalStructure.P_M_T_Estimated_Market);
                p.Add("Exp_AtBeginning", objModel.objCapitalStructure.Exp_AtBeginning);
                p.Add("Exp_Additions", objModel.objCapitalStructure.Exp_Additions);
                p.Add("Exp_Sold_Discarded", objModel.objCapitalStructure.Exp_Sold_Discarded);
                p.Add("Exp_Depreciation", objModel.objCapitalStructure.Exp_Depreciation);
                p.Add("Exp_Net_closing_Balance", objModel.objCapitalStructure.Exp_Net_closing_Balance);
                p.Add("Exp_Estimated_Market", objModel.objCapitalStructure.Exp_Estimated_Market);
                p.Add("Total_AtBeginning", objModel.objCapitalStructure.Total_AtBeginning);
                p.Add("Total_Additions", objModel.objCapitalStructure.Total_Additions);
                p.Add("Total_Sold_Discarded", objModel.objCapitalStructure.Total_Sold_Discarded);
                p.Add("Total_Depreciation", objModel.objCapitalStructure.Total_Depreciation);
                p.Add("Total_Net_closing_Balance", objModel.objCapitalStructure.Total_Net_closing_Balance);
                p.Add("Total_Estimated_Market", objModel.objCapitalStructure.Total_Estimated_Market);
                p.Add("Financial_Year", objModel.objCapitalStructure.Year);
                p.Add("ModifiedBy", objModel.objCapitalStructure.UID);
                p.Add("Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_CapitalStructure", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "Record Has not Updated..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Updated..";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }
        }

        /// <summary>
        /// Update source of finance
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateSourceOfFinance(AnnualReturnH1PartTwoModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("SourceOfFinance_Id", objModel.objSource.SourceOfFinance_Id);
                p.Add("ShareCapital", objModel.objSource.ShareCapital);
                p.Add("OwnCapital", objModel.objSource.OwnCapital);
                p.Add("Reserve", objModel.objSource.Reserve);
                p.Add("Institution", objModel.objSource.Institution);
                p.Add("AmountofLoan", objModel.objSource.AmountofLoan);
                p.Add("RateofInterest", objModel.objSource.RateofInterest);
                p.Add("Interestpaid", objModel.objSource.Interestpaid);
                p.Add("Rentspaid", objModel.objSource.Rentspaid);
                p.Add("Financial_Year", objModel.objSource.Year);
                p.Add("ModifiedBy", objModel.objSource.UID);
                p.Add("Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_AnnualReturnH1_SourceOfFinance", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "Record Has not Updated..";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Record has been Updated..";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
                objModel = null;
            }
        }
        #endregion

        /// <summary>
        /// Convert DataReader to Dataset
        /// </summary>
        /// <param name="data"></param>
        /// <returns>DataSet</returns>
        public DataSet ConvertDataReaderToDataSet(IDataReader data)
        {
            DataSet ds = new DataSet();
            int i = 0;
            while (!data.IsClosed)
            {
                ds.Tables.Add("Table" + (i + 1));
                ds.EnforceConstraints = false;
                ds.Tables[i].Load(data);
                i++;
            }
            return ds;
        }
    }
}
