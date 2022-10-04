using Dapper;
using Microsoft.AspNetCore.Mvc;
using ReturnApi.Factory;
using ReturnApi.Repository;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Model.e_Return_NonCoal
{
    public class eReturnNonCoalProvider : RepositoryBase, IeReturnNonCoalProvider
    {
        public eReturnNonCoalProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }


        /// <summary>
        /// Get List of Financil Year
        /// </summary>
        /// <param name="ObjMR"></param>
        /// <returns>DDLResult class</returns>
        public async Task<DDLResult> ListOfFinancilaYear(MonthlyReturnModelNonCoal ObjMR)
        {
            DDLResult objres = new DDLResult();
            List<MonthlyReturnModelNonCoal> ListDP = new List<MonthlyReturnModelNonCoal>();

            try
            {
                var paramList = new
                {
                    Check = 3,
                    UserID = ObjMR.Uid,
                };
                var result = await Connection.QueryAsync<MonthlyReturnModelNonCoal>("GetFinancialYearList", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    foreach (MonthlyReturnModelNonCoal dr in result)
                    {
                        ListDP.Add(new MonthlyReturnModelNonCoal()
                        {
                            Year = dr.Year,
                        });
                    }
                    objres.GetDDL = ListDP;
                }
                return objres;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objres = null;
                ListDP = null;
                ObjMR = null;
            }
        }

        /// <summary>
        /// Get Fi Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of MonthlyReturnModelNonCoal class</returns>
        public async Task<List<MonthlyReturnModelNonCoal>> GetViewDetails(MonthlyReturnModelNonCoal model)
        {
            List<MonthlyReturnModelNonCoal> obJMonthlyReturnModelNonCoal = new List<MonthlyReturnModelNonCoal>();
            try
            {
                var paramList = new
                {
                    FinancialYear = model.Year,
                    UserID = model.Uid,
                    Check = 1,
                };
                var result = await Connection.ExecuteReaderAsync("GetDetailsofMonthlyReturn", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        model = new MonthlyReturnModelNonCoal();

                        model.Months = Convert.ToInt32(dt.Rows[i]["M_Id"]);
                        model.Years = Convert.ToInt32(dt.Rows[i]["Year"]);
                        model.MonthYear = Convert.ToString(dt.Rows[i]["MonthYear"]);
                        model.Status = Convert.ToString(dt.Rows[i]["Status"]);
                        model.ModifiedOn = Convert.ToString(dt.Rows[i]["ModifiedOn"]);
                        model.FormType = Convert.ToString(dt.Rows[i]["FormType"]);

                        string Mname = Convert.ToString(dt.Rows[i]["MineralName"]);
                        if (Mname != "" && Mname != null)
                        {
                            model.MineralName = Convert.ToString(dt.Rows[i]["MineralName"]);
                        }
                        obJMonthlyReturnModelNonCoal.Add(model);


                    }
                }
                return obJMonthlyReturnModelNonCoal;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                obJMonthlyReturnModelNonCoal = null;
                model = null;
            }
        }

        /// <summary>
        /// Get Lessee Mines Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>GetFormF1DetailsModel class</returns>
        public async Task<GetFormF1DetailsModel> GetLesseMineDeatils(MonthlyReturnModelNonCoal model)
        {
            GetFormF1DetailsModel objModel = new GetFormF1DetailsModel();
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

                    for (int i = 0; i < dt.Rows.Count; i++)
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
        /// Get Return SUbmitted Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>GetFormF1DetailsModel class</returns>
        public async Task<GetFormF1DetailsModel> GeteReturnSubmittedDetails(MonthlyReturnModelNonCoal model)
        {
            GetFormF1DetailsModel objModel = new GetFormF1DetailsModel();
            try
            {
                var paramList = new
                {
                    UserID = model.Uid,
                    Month_Year = model.MonthYear,
                    FormType = "Form F1",
                };
                var result = await Connection.ExecuteReaderAsync("USPtoPrintForm1Part1", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {



                    if (!(dt.Rows[0]["Details_Id"] is DBNull))
                    {
                        objModel.Details_Id = Convert.ToInt32(dt.Rows[0]["Details_Id"]);
                    }
                    if (!(dt.Rows[0]["Wages_Id"] is DBNull))
                    {
                        objModel.Wages_Id = Convert.ToInt32(dt.Rows[0]["Wages_Id"]);
                    }
                    objModel.MinePostOffice = Convert.ToString(dt.Rows[0]["MinePostOffice"]);
                    objModel.MineFaxNo = Convert.ToString(dt.Rows[0]["MineFaxNo"]);
                    objModel.LesseeFaxNo = Convert.ToString(dt.Rows[0]["LesseeFaxNo"]);
                    string Rentpaid = Convert.ToString(dt.Rows[0]["Rent_paid"]);
                    if (Rentpaid != "")
                        objModel.Rentpaid = Convert.ToString(dt.Rows[0]["Rent_paid"]);

                    if (!(dt.Rows[0]["Royalty_paid"] is DBNull))
                    {
                        objModel.Royaltypaid = Convert.ToDecimal(dt.Rows[0]["Royalty_paid"]);
                    }
                    string DeadRentpaid = Convert.ToString(dt.Rows[0]["Dead_Rent_paid"]);
                    if (DeadRentpaid != "")
                        objModel.DeadRentpaid = Convert.ToString(dt.Rows[0]["Dead_Rent_paid"]);

                    if (!(dt.Rows[0]["DMF"] is DBNull))
                    {
                        objModel.DMFPaid = Convert.ToDecimal(dt.Rows[0]["DMF"]);
                    }
                    if (!(dt.Rows[0]["NMET"] is DBNull))
                    {
                        objModel.NMETPaid = Convert.ToDecimal(dt.Rows[0]["NMET"]);
                    }
                    if (!(dt.Rows[0]["NoOfDaysMineWork"] is DBNull))
                    {
                        objModel.NoOfDaysMineWork = Convert.ToInt32(dt.Rows[0]["NoOfDaysMineWork"]);
                    }
                    List<Working_of_Mine> pmodel = new List<Working_of_Mine>();
                    Working_of_Mine objWork;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objWork = new Working_of_Mine();
                        if (!(dt.Rows[i]["Work_Id"] is DBNull))
                        {
                            objWork.Work_Id = Convert.ToInt32(dt.Rows[i]["Work_Id"]);
                        }
                        if (!(dt.Rows[i]["NoOfDaysWorkStop"] is DBNull))
                        {
                            objWork.NoOfDaysWorkStop = Convert.ToInt32(dt.Rows[i]["NoOfDaysWorkStop"]);
                        }
                        objWork.Reason = Convert.ToString(dt.Rows[i]["Reason"]);
                        pmodel.Add(objWork);
                    }
                    objModel.MineWork = pmodel;

                    string DirectMale1 = Convert.ToString(dt.Rows[0]["DirectMale1"]);
                    if (DirectMale1 != null && DirectMale1 != "")
                        objModel.DirectMale1 = Convert.ToDecimal(dt.Rows[0]["DirectMale1"]);


                    string DirectMale2 = Convert.ToString(dt.Rows[0]["DirectMale2"]);
                    if (DirectMale2 != null && DirectMale2 != "")
                        objModel.DirectMale2 = Convert.ToDecimal(dt.Rows[0]["DirectMale2"]);

                    string DirectMale3 = Convert.ToString(dt.Rows[0]["DirectMale3"]);
                    if (DirectMale3 != null && DirectMale3 != "")
                        objModel.DirectMale3 = Convert.ToDecimal(dt.Rows[0]["DirectMale3"]);

                    string DirectFemale1 = Convert.ToString(dt.Rows[0]["DirectFemale1"]);
                    if (DirectFemale1 != null && DirectFemale1 != "")
                        objModel.DirectFemale1 = Convert.ToDecimal(dt.Rows[0]["DirectFemale1"]);

                    string DirectFemale2 = Convert.ToString(dt.Rows[0]["DirectFemale2"]);
                    if (DirectFemale2 != null && DirectFemale2 != "")
                        objModel.DirectFemale2 = Convert.ToDecimal(dt.Rows[0]["DirectFemale2"]);

                    string DirectFemale3 = Convert.ToString(dt.Rows[0]["DirectFemale3"]);
                    if (DirectFemale3 != null && DirectFemale3 != "")
                        objModel.DirectFemale3 = Convert.ToDecimal(dt.Rows[0]["DirectFemale3"]);

                    string ContractMale1 = Convert.ToString(dt.Rows[0]["ContractMale1"]);
                    if (ContractMale1 != null && ContractMale1 != "")
                        objModel.ContractMale1 = Convert.ToDecimal(dt.Rows[0]["ContractMale1"]);

                    string ContractMale2 = Convert.ToString(dt.Rows[0]["ContractMale2"]);
                    if (ContractMale2 != null && ContractMale2 != "")
                        objModel.ContractMale2 = Convert.ToDecimal(dt.Rows[0]["ContractMale2"]);

                    string ContractMale3 = Convert.ToString(dt.Rows[0]["ContractMale3"]);
                    if (ContractMale3 != null && ContractMale3 != "")
                        objModel.ContractMale3 = Convert.ToDecimal(dt.Rows[0]["ContractMale3"]);

                    string ContractFemale1 = Convert.ToString(dt.Rows[0]["ContractFemale1"]);
                    if (ContractFemale1 != null && ContractFemale1 != "")
                        objModel.ContractFemale1 = Convert.ToDecimal(dt.Rows[0]["ContractFemale1"]);

                    string ContractFemale2 = Convert.ToString(dt.Rows[0]["ContractFemale2"]);
                    if (ContractFemale2 != null && ContractFemale2 != "")
                        objModel.ContractFemale2 = Convert.ToDecimal(dt.Rows[0]["ContractFemale2"]);

                    string ContractFemale3 = Convert.ToString(dt.Rows[0]["ContractFemale3"]);
                    if (ContractFemale3 != null && ContractFemale3 != "")
                        objModel.ContractFemale3 = Convert.ToDecimal(dt.Rows[0]["ContractFemale3"]);

                    string TotalWagesMale1 = Convert.ToString(dt.Rows[0]["BGTotalMale"]);
                    if (TotalWagesMale1 != null && TotalWagesMale1 != "")
                        objModel.TotalWagesMale1 = Convert.ToDecimal(dt.Rows[0]["BGTotalMale"]);

                    string TotalWagesFeMale1 = Convert.ToString(dt.Rows[0]["BGTotalFemale"]);
                    if (TotalWagesFeMale1 != null && TotalWagesMale1 != "")
                        objModel.TotalWagesFeMale1 = Convert.ToDecimal(dt.Rows[0]["BGTotalFemale"]);

                    string TotalWagesMale2 = Convert.ToString(dt.Rows[0]["OCTotalMale"]);
                    if (TotalWagesMale2 != null && TotalWagesMale2 != "")
                        objModel.TotalWagesMale2 = Convert.ToDecimal(dt.Rows[0]["OCTotalMale"]);

                    string TotalWagesFeMale2 = Convert.ToString(dt.Rows[0]["OCTptalFemale"]);
                    if (TotalWagesFeMale2 != null && TotalWagesFeMale2 != "")
                        objModel.TotalWagesFeMale2 = Convert.ToDecimal(dt.Rows[0]["OCTptalFemale"]);


                    string TotalWagesMale3 = Convert.ToString(dt.Rows[0]["AGTotalMale"]);
                    if (TotalWagesMale3 != null && TotalWagesMale3 != "")
                        objModel.TotalWagesMale3 = Convert.ToDecimal(dt.Rows[0]["AGTotalMale"]);

                    string TotalWagesFeMale3 = Convert.ToString(dt.Rows[0]["AGTotalFemale"]);
                    if (TotalWagesFeMale3 != null && TotalWagesFeMale3 != "")
                        objModel.TotalWagesFeMale3 = Convert.ToDecimal(dt.Rows[0]["AGTotalFemale"]);


                    string TotalDirectMale = Convert.ToString(dt.Rows[0]["TotalDirectMale"]);
                    if (TotalDirectMale != null && TotalDirectMale != "")
                        objModel.TotalDirectMale = Convert.ToDecimal(dt.Rows[0]["TotalDirectMale"]);

                    string TotalDirectFemale = Convert.ToString(dt.Rows[0]["TotalDirectFemale"]);
                    if (TotalDirectFemale != null && TotalDirectFemale != "")
                        objModel.TotalDirectFemale = Convert.ToDecimal(dt.Rows[0]["TotalDirectFemale"]);

                    string TotalContractMale = Convert.ToString(dt.Rows[0]["TotalContractMale"]);
                    if (TotalContractMale != null && TotalContractMale != "")
                        objModel.TotalContractMale = Convert.ToDecimal(dt.Rows[0]["TotalContractMale"]);

                    string TotalContractFemale = Convert.ToString(dt.Rows[0]["TotalContractFemale"]);
                    if (TotalContractFemale != null && TotalContractFemale != "")
                        objModel.TotalContractFemale = Convert.ToDecimal(dt.Rows[0]["TotalContractFemale"]);

                    string TotalMaleWages = Convert.ToString(dt.Rows[0]["TotalMaleWages"]);
                    if (TotalMaleWages != null && TotalMaleWages != "")
                        objModel.TotalMaleWages = Convert.ToDecimal(dt.Rows[0]["TotalMaleWages"]);


                    string TotalFeMaleWages = Convert.ToString(dt.Rows[0]["TotalFeMaleWages"]);
                    if (TotalFeMaleWages != null && TotalFeMaleWages != "")
                        objModel.TotalFeMaleWages = Convert.ToDecimal(dt.Rows[0]["TotalFeMaleWages"]);

                    objModel.Registrationnumber = Convert.ToString(dt.Rows[0]["Registrationnumber"]);
                    objModel.MINE_CODE = Convert.ToString(dt.Rows[0]["MINE_CODE"]);
                    objModel.MineralName = Convert.ToString(dt.Rows[0]["MineralName"]);
                    objModel.MineName = Convert.ToString(dt.Rows[0]["MineName"]);
                    objModel.MineAddress = Convert.ToString(dt.Rows[0]["MineAddress"]);
                    objModel.MineVillage = Convert.ToString(dt.Rows[0]["MineVillage"]);
                    objModel.MineDistrict = Convert.ToString(dt.Rows[0]["MineDistrict"]);
                    objModel.MineState = Convert.ToString(dt.Rows[0]["MineState"]);
                    objModel.MineTehsil = Convert.ToString(dt.Rows[0]["MineTehsil"]);
                    objModel.MinePinCode = Convert.ToString(dt.Rows[0]["MinePinCode"]);
                    objModel.MineEmailID = Convert.ToString(dt.Rows[0]["MineEmailID"]);
                    objModel.MineMobileNo = Convert.ToString(dt.Rows[0]["MineMobileNo"]);
                    objModel.MinePhoneNo = Convert.ToString(dt.Rows[0]["MinePhoneNo"]);
                    objModel.LesseeName = Convert.ToString(dt.Rows[0]["LesseeName"]);
                    objModel.LesseeAddress = Convert.ToString(dt.Rows[0]["LesseeAddress"]);
                    objModel.LesseeStateName = Convert.ToString(dt.Rows[0]["LesseeStateName"]);
                    objModel.LesseeDistrictName = Convert.ToString(dt.Rows[0]["LesseeDistrictName"]);
                    objModel.LesseePinCode = Convert.ToString(dt.Rows[0]["LesseePinCode"]);
                    objModel.LesseeEmailID = Convert.ToString(dt.Rows[0]["LesseeEmailID"]);
                    objModel.LesseeMobileNo = Convert.ToString(dt.Rows[0]["LesseeMobileNo"]);

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
        /// Get Rent Royalty Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>GetRentRoyaltyDetailsModel class</returns>
        public async Task<GetRentRoyaltyDetailsModel> GetRentRoyalty(MonthlyReturnModelNonCoal model)
        {
            GetRentRoyaltyDetailsModel objModel = new GetRentRoyaltyDetailsModel();
            try
            {
                var paramList = new
                {
                    UserID = model.Uid,
                    Month_Year = model.MonthYear,
                };
                var result = await Connection.ExecuteReaderAsync("Usp_Rent_Royalty", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    objModel.Royaltypaid = Convert.ToDecimal(dt.Rows[0]["PayableRoyalty"]);
                    objModel.DMFPaid = Convert.ToDecimal(dt.Rows[0]["DMF"]);
                    objModel.NMETPaid = Convert.ToDecimal(dt.Rows[0]["NMET"]);
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
        /// Add Royalty Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddRoyaltyDetails(GetFormF1DetailsModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 1);
                p.Add("UserId", objModel.UserID);
                p.Add("MineralId", objModel.MineralID);
                p.Add("MinePostOffice", objModel.MinePostOffice);
                p.Add("MineFaxNo", objModel.MineFaxNo);
                p.Add("LesseeFaxNo", objModel.LesseeFaxNo);
                p.Add("Rent_paid", objModel.Rentpaid);
                p.Add("Royalty_paid", objModel.Royaltypaid);
                p.Add("Dead_Rent_paid", objModel.DeadRentpaid);
                p.Add("DMF", objModel.DMFPaid);
                p.Add("NMET", objModel.NMETPaid);
                p.Add("FormType", "Form F1");
                p.Add("ReturnType", "Monthly");
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("NoOfDaysMineWork", objModel.NoOfDaysMineWork);
                DataTable dataTable = new DataTable("MineWork");
                //we create column names as per the type in DB 
                dataTable.Columns.Add("MineWorkId", typeof(Int32));
                dataTable.Columns.Add("Work_Id", typeof(Int32));
                dataTable.Columns.Add("NoOfDaysWorkStop", typeof(Int32));
                dataTable.Columns.Add("Reason", typeof(string));
                dataTable.Columns.Add("CreatedBY", typeof(Int32));
                Working_of_Mine ObjWOMModel;
                List<Working_of_Mine> _objListModel = new List<Working_of_Mine>();
                for (var j = 0; j < objModel.intNoOfDaysWorkStop.Count; j++)
                {
                    ObjWOMModel = new Working_of_Mine();
                    ObjWOMModel.NoOfDaysWorkStop = objModel.intNoOfDaysWorkStop[j];
                    ObjWOMModel.Reason = objModel.strReason[j];
                    ObjWOMModel.CREATED_BY = objModel.UserID;
                    _objListModel.Add(ObjWOMModel);
                }

                objModel.MineWork = (_objListModel != null) ? _objListModel : null;

                for (var i = 0; i < objModel.MineWork.Count; i++)
                {
                    if (objModel.MineWork[i].NoOfDaysWorkStop != null && objModel.MineWork[i].NoOfDaysWorkStop != 0 && objModel.MineWork[i].Reason != null)
                    {
                        dataTable.Rows.Add(i + 1, objModel.MineWork[i].Work_Id, objModel.MineWork[i].NoOfDaysWorkStop, objModel.MineWork[i].Reason, objModel.UserID);
                    }
                    else
                    {
                        dataTable.Rows.Add(i + 1, 0, 0, "", objModel.UserID);
                    }
                }

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    p.Add("BULK_MINEWORK", dataTable, DbType.Object);
                }

                p.Add("WorkPlace1", "WorkPlace1");
                p.Add("DirectMale1", objModel.DirectMale1);
                p.Add("DirectFemale1", objModel.DirectFemale1);
                p.Add("ContractMale1", objModel.ContractMale1);
                p.Add("ContractFemale1", objModel.ContractFemale1);
                p.Add("BGTotalMale", objModel.TotalWagesMale1);
                p.Add("BGTotalFemale", objModel.TotalWagesFeMale1);

                p.Add("WorkPlace2", "Opencast");
                p.Add("DirectMale2", objModel.DirectMale2);
                p.Add("DirectFemale2", objModel.DirectFemale2);
                p.Add("ContractMale2", objModel.ContractMale2);
                p.Add("ContractFemale2", objModel.ContractFemale2);
                p.Add("OCTotalMale", objModel.TotalWagesMale2);
                p.Add("OCTptalFemale", objModel.TotalWagesFeMale2);

                p.Add("WorkPlace3", "Above ground");
                p.Add("DirectMale3", objModel.DirectMale3);
                p.Add("DirectFemale3", objModel.DirectFemale3);
                p.Add("ContractMale3", objModel.ContractMale3);
                p.Add("ContractFemale3", objModel.ContractFemale3);
                p.Add("AGTotalMale", objModel.TotalWagesMale3);
                p.Add("AGTotalFemale", objModel.TotalWagesFeMale3);

                p.Add("TotalDirectMale", objModel.TotalDirectMale);
                p.Add("TotalDirectFemale", objModel.TotalDirectFemale);
                p.Add("TotalContractMale", objModel.TotalContractMale);
                p.Add("TotalContractFemale", objModel.TotalContractFemale);
                p.Add("TotalMaleWages", objModel.TotalMaleWages);
                p.Add("TotalFeMaleWages", objModel.TotalFeMaleWages);
                p.Add("AGTotalFemale", objModel.TotalWagesFeMale3);


                p.Add("Registrationnumber", objModel.Registrationnumber);
                p.Add("MINE_CODE", objModel.MINE_CODE);
                p.Add("MineralName", objModel.MineralName);
                p.Add("MineName", objModel.MineName);
                p.Add("MineAddress", objModel.MineAddress);
                p.Add("MineVillage", objModel.MineVillage);
                p.Add("MineDistrict", objModel.MineDistrict);
                p.Add("MineState", objModel.MineState);
                p.Add("MineTehsil", objModel.MineTehsil);
                p.Add("MinePinCode", objModel.MinePinCode);
                p.Add("MineEmailID", objModel.MineEmailID);
                p.Add("MineMobileNo", objModel.MineMobileNo);
                p.Add("MinePhoneNo", objModel.MinePhoneNo);
                p.Add("LesseeName", objModel.LesseeName);
                p.Add("LesseeAddress", objModel.LesseeAddress);
                p.Add("LesseeStateName", objModel.LesseeStateName);
                p.Add("LesseeDistrictName", objModel.LesseeDistrictName);
                p.Add("LesseePinCode", objModel.LesseePinCode);
                p.Add("LesseeEmailID", objModel.LesseeEmailID);
                p.Add("LesseeMobileNo", objModel.LesseeMobileNo);
                p.Add("OtherMinerals", objModel.OtherMineral);

                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("UspADDeReturnPartOne", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();


                if (response == "2")
                {
                    objMessage.Msg = "This Record Already Exist";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Part one has been saved";
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
        /// Update Royalty Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateRoyaltyDetails(GetFormF1DetailsModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("Check", 2);
                p.Add("UserId", objModel.UserID);
                p.Add("Details_Id", objModel.Details_Id);
                p.Add("Wages_Id", objModel.Wages_Id);
                p.Add("MineralId", objModel.MineralID);
                p.Add("MinePostOffice", objModel.MinePostOffice);
                p.Add("MineFaxNo", objModel.MineFaxNo);
                p.Add("LesseeFaxNo", objModel.LesseeFaxNo);
                p.Add("Rent_paid", objModel.Rentpaid);
                p.Add("Royalty_paid", objModel.Royaltypaid);
                p.Add("Dead_Rent_paid", objModel.DeadRentpaid);
                p.Add("DMF", objModel.DMFPaid);
                p.Add("NMET", objModel.NMETPaid);
                p.Add("FormType", "Form F1");
                p.Add("ReturnType", "Monthly");
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("NoOfDaysMineWork", objModel.NoOfDaysMineWork);
                DataTable dataTable = new DataTable("MineWork");
                //we create column names as per the type in DB 
                dataTable.Columns.Add("MineWorkId", typeof(Int32));
                dataTable.Columns.Add("Work_Id", typeof(Int32));
                dataTable.Columns.Add("NoOfDaysWorkStop", typeof(Int32));
                dataTable.Columns.Add("Reason", typeof(string));
                dataTable.Columns.Add("CreatedBY", typeof(Int32));


                Working_of_Mine ObjWOMModel;
                List<Working_of_Mine> _objListModel = new List<Working_of_Mine>();
                for (var j = 0; j < objModel.intNoOfDaysWorkStop.Count; j++)
                {
                    ObjWOMModel = new Working_of_Mine();
                    ObjWOMModel.Work_Id = objModel.intwork[j];
                    ObjWOMModel.NoOfDaysWorkStop = objModel.intNoOfDaysWorkStop[j];
                    ObjWOMModel.Reason = objModel.strReason[j];
                    ObjWOMModel.CREATED_BY = objModel.UserID;
                    _objListModel.Add(ObjWOMModel);
                }
                objModel.MineWork = (_objListModel != null) ? _objListModel : null;
                for (var i = 0; i < objModel.MineWork.Count; i++)
                {
                    if (objModel.MineWork[i].NoOfDaysWorkStop != null && objModel.MineWork[i].NoOfDaysWorkStop != 0 && objModel.MineWork[i].Reason != null)
                    {
                        dataTable.Rows.Add(i + 1, objModel.MineWork[i].Work_Id, objModel.MineWork[i].NoOfDaysWorkStop, objModel.MineWork[i].Reason, objModel.UserID);
                    }
                    else
                    {
                        dataTable.Rows.Add(i + 1, 0, 0, "", objModel.UserID);
                    }
                }

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    p.Add("BULK_MINEWORK", dataTable, DbType.Object);
                }

                p.Add("WorkPlace1", "WorkPlace1");
                p.Add("DirectMale1", objModel.DirectMale1);
                p.Add("DirectFemale1", objModel.DirectFemale1);
                p.Add("ContractMale1", objModel.ContractMale1);
                p.Add("ContractFemale1", objModel.ContractFemale1);
                p.Add("BGTotalMale", objModel.TotalWagesMale1);
                p.Add("BGTotalFemale", objModel.TotalWagesFeMale1);

                p.Add("WorkPlace2", "Opencast");
                p.Add("DirectMale2", objModel.DirectMale2);
                p.Add("DirectFemale2", objModel.DirectFemale2);
                p.Add("ContractMale2", objModel.ContractMale2);
                p.Add("ContractFemale2", objModel.ContractFemale2);
                p.Add("OCTotalMale", objModel.TotalWagesMale2);
                p.Add("OCTptalFemale", objModel.TotalWagesFeMale2);

                p.Add("WorkPlace3", "Above ground");
                p.Add("DirectMale3", objModel.DirectMale3);
                p.Add("DirectFemale3", objModel.DirectFemale3);
                p.Add("ContractMale3", objModel.ContractMale3);
                p.Add("ContractFemale3", objModel.ContractFemale3);
                p.Add("AGTotalMale", objModel.TotalWagesMale3);
                p.Add("AGTotalFemale", objModel.TotalWagesFeMale3);

                p.Add("TotalDirectMale", objModel.TotalDirectMale);
                p.Add("TotalDirectFemale", objModel.TotalDirectFemale);
                p.Add("TotalContractMale", objModel.TotalContractMale);
                p.Add("TotalContractFemale", objModel.TotalContractFemale);
                p.Add("TotalMaleWages", objModel.TotalMaleWages);
                p.Add("TotalFeMaleWages", objModel.TotalFeMaleWages);
                p.Add("AGTotalFemale", objModel.TotalWagesFeMale3);


                p.Add("Registrationnumber", objModel.Registrationnumber);
                p.Add("MINE_CODE", objModel.MINE_CODE);
                p.Add("MineralName", objModel.MineralName);
                p.Add("MineName", objModel.MineName);
                p.Add("MineAddress", objModel.MineAddress);
                p.Add("MineVillage", objModel.MineVillage);
                p.Add("MineDistrict", objModel.MineDistrict);
                p.Add("MineState", objModel.MineState);
                p.Add("MineTehsil", objModel.MineTehsil);
                p.Add("MinePinCode", objModel.MinePinCode);
                p.Add("MineEmailID", objModel.MineEmailID);
                p.Add("MineMobileNo", objModel.MineMobileNo);
                p.Add("MinePhoneNo", objModel.MinePhoneNo);
                p.Add("LesseeName", objModel.LesseeName);
                p.Add("LesseeAddress", objModel.LesseeAddress);
                p.Add("LesseeStateName", objModel.LesseeStateName);
                p.Add("LesseeDistrictName", objModel.LesseeDistrictName);
                p.Add("LesseePinCode", objModel.LesseePinCode);
                p.Add("LesseeEmailID", objModel.LesseeEmailID);
                p.Add("LesseeMobileNo", objModel.LesseeMobileNo);
                p.Add("OtherMinerals", objModel.OtherMineral);

                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("UspADDeReturnPartOne", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();


                if (response == "2")
                {
                    objMessage.Msg = "Part one has Not Updated";
                }
                else if (response == "1")
                {
                    objMessage.Msg = "Part one has been Updated";
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
        /// Get Mineral Information
        /// </summary>
        /// <param name="model"></param>
        /// <returns>GetFormF1DetailsModel class</returns>
        public async Task<GetFormF1DetailsModel> GetMineralInfo(MonthlyReturnModelNonCoal model)
        {
            GetFormF1DetailsModel objModel = new GetFormF1DetailsModel();
            try
            {
                var paramList = new
                {
                    UserId = model.Uid,
                    Check = 1,
                };
                var result = await Connection.ExecuteReaderAsync("Usp_LesseeMineralInfo", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    if (!(dt.Rows[0]["MineralID"] is DBNull))
                    {
                        objModel.MineralID = Convert.ToInt32(dt.Rows[0]["MineralID"]);
                    }
                    if (!(dt.Rows[0]["MineralName"] is DBNull))
                    {
                        objModel.MineralName = Convert.ToString(dt.Rows[0]["MineralName"]);
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
        /// Get Production Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>ProductionModel_Monthly class</returns>
        public async Task<ProductionModel_Monthly> GetProduction(MonthlyReturnModelNonCoal model)
        {
            ProductionModel_Monthly objModel = new ProductionModel_Monthly();
            try
            {
                var paramList = new
                {

                    UserID = model.Uid,
                    Month_Year = model.MonthYear,
                    Check = 1,
                };


                var result = await Connection.ExecuteReaderAsync("USP_GETFormF1Part2", paramList, commandType: System.Data.CommandType.StoredProcedure);



                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    objModel.MineralId1 = Convert.ToInt32(dt.Rows[0]["MineralId"]);
                    //objModel.TypeOfProduction_Id = Convert.ToInt32(dt.Rows[0]["TypeOfProduction_Id"]);
                    objModel.TypeOfProduction_Id = (dt.Rows[0]["TypeOfProduction_Id"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["TypeOfProduction_Id"]) : 0);
                    objModel.TypeofOreProduced = Convert.ToString(dt.Rows[0]["TypeOfProduction"]);

                    objModel.OpeningStockOCW = (dt.Rows[0]["OpeningStockCw"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["OpeningStockCw"]) : 0);
                    objModel.productionOCW = (dt.Rows[0]["ProductionCW"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["ProductionCW"]) : 0);
                    objModel.closingOCW = (dt.Rows[0]["ClosingStockCW"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["ClosingStockCW"]) : 0);

                    objModel.OpeningStockUW = (dt.Rows[0]["OpeningStockUW"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["OpeningStockUW"]) : 0);
                    objModel.productionUW = (dt.Rows[0]["ProductionUW"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["ProductionUW"]) : 0);
                    objModel.closingUW = (dt.Rows[0]["ClosingStockUW"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["ClosingStockUW"]) : 0);

                    objModel.OpeningStockDW = (dt.Rows[0]["OpeningStockDW"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["OpeningStockDW"]) : 0);
                    objModel.productionDW = (dt.Rows[0]["ProductionDW"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["ProductionDW"]) : 0);
                    objModel.closingDW = (dt.Rows[0]["ClosingStockDW"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["ClosingStockDW"]) : 0);

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
        /// Get Details of Deduction
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Details_of_deductions_Monthly class</returns>
        public async Task<Details_of_deductions_Monthly> GetDetails_of_deductions(GetFormF1DetailsModel model)
        {
            Details_of_deductions_Monthly objModel = new Details_of_deductions_Monthly();
            try
            {
                var paramList = new
                {

                    UserID = model.UserID,
                    Month_Year = model.Month_Year,
                    MineralId = model.MineralID,
                    Check = 2,
                };


                var result = await Connection.ExecuteReaderAsync("USP_GETFormF1Part2", paramList, commandType: System.Data.CommandType.StoredProcedure);



                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    objModel.DeductionMade_Id = Convert.ToInt32(dt.Rows[0]["DeductionMade_Id"]);

                    objModel.Deduction_claimedType1 = Convert.ToString(dt.Rows[0]["Deduction_claimedType1"]);
                    objModel.Amount1 = Convert.ToString(dt.Rows[0]["Amount1"]);
                    objModel.Remarks1 = Convert.ToString(dt.Rows[0]["Remarks1"]);

                    objModel.Deduction_claimedType2 = Convert.ToString(dt.Rows[0]["Deduction_claimedType2"]);
                    objModel.Amount2 = Convert.ToString(dt.Rows[0]["Amount2"]);
                    objModel.Remarks2 = Convert.ToString(dt.Rows[0]["Remarks2"]);

                    objModel.Deduction_claimedType3 = Convert.ToString(dt.Rows[0]["Deduction_claimedType3"]);
                    objModel.Amount3 = Convert.ToString(dt.Rows[0]["Amount3"]);
                    objModel.Remarks3 = Convert.ToString(dt.Rows[0]["Remarks3"]);

                    objModel.Deduction_claimedType4 = Convert.ToString(dt.Rows[0]["Deduction_claimedType4"]);
                    objModel.Amount4 = Convert.ToString(dt.Rows[0]["Amount4"]);
                    objModel.Remarks4 = Convert.ToString(dt.Rows[0]["Remarks4"]);

                    objModel.Deduction_claimedType5 = Convert.ToString(dt.Rows[0]["Deduction_claimedType5"]);
                    objModel.Amount5 = Convert.ToString(dt.Rows[0]["Amount5"]);
                    objModel.Remarks5 = Convert.ToString(dt.Rows[0]["Remarks5"]);

                    objModel.Deduction_claimedType6 = Convert.ToString(dt.Rows[0]["Deduction_claimedType6"]);
                    objModel.Amount6 = Convert.ToString(dt.Rows[0]["Amount6"]);
                    objModel.Remarks6 = Convert.ToString(dt.Rows[0]["Remarks6"]);

                    objModel.Deduction_claimedType7 = Convert.ToString(dt.Rows[0]["Deduction_claimedType7"]);
                    objModel.Amount7 = Convert.ToString(dt.Rows[0]["Amount7"]);
                    objModel.Remarks7 = Convert.ToString(dt.Rows[0]["Remarks7"]);
                    objModel.TotalAmount = Convert.ToString(dt.Rows[0]["TotalAmount"]);
                    objModel.ex_mineSale = Convert.ToString(dt.Rows[0]["ExMineSale"]);
                    objModel.CExMineSale = Convert.ToString(dt.Rows[0]["CExMineSale"]);

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
        /// Get Reason
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Reason_Inc_Dec_Monthly class</returns>
        public async Task<Reason_Inc_Dec_Monthly> GetReason_Inc_Dec(GetFormF1DetailsModel model)
        {
            Reason_Inc_Dec_Monthly objModel = new Reason_Inc_Dec_Monthly();
            try
            {
                var paramList = new
                {

                    UserID = model.UserID,
                    Month_Year = model.Month_Year,
                    MineralId = model.MineralID,
                    Check = 3,
                };


                var result = await Connection.ExecuteReaderAsync("USP_GETFormF1Part2", paramList, commandType: System.Data.CommandType.StoredProcedure);



                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    objModel.Reason_Inc_Dec_Id = Convert.ToInt32(dt.Rows[0]["Reason_Inc_Dec_Id"]);
                    objModel.productionIncrDecResion = Convert.ToString(dt.Rows[0]["productionIncrDecResion"]);
                    objModel.ex_minepriceIncrDecResion = Convert.ToString(dt.Rows[0]["ex_minepriceIncrDecResion"]);
                    objModel.certify = Convert.ToBoolean(dt.Rows[0]["certify"]);

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
        /// Get Pulverization Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Details_of_deductions_Monthly class</returns>
        public async Task<Details_of_deductions_Monthly> Getpulverization(GetFormF1DetailsModel model)
        {
            Details_of_deductions_Monthly objModel = new Details_of_deductions_Monthly();
            try
            {
                var paramList = new
                {

                    UserID = model.UserID,
                    Month_Year = model.Month_Year,
                    Check = 4,
                };


                var result = await Connection.ExecuteReaderAsync("USP_GETFormF1Part2", paramList, commandType: System.Data.CommandType.StoredProcedure);



                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    objModel.Average_Id = Convert.ToInt32(dt.Rows[0]["Average_Id"]);
                    objModel.Averagecostofpulverization = Convert.ToString(dt.Rows[0]["Averagecostofpulverization"]);

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
        /// Get Opening Stock
        /// </summary>
        /// <param name="model"></param>
        /// <returns>ProductionModel_Monthly class</returns>
        public async Task<ProductionModel_Monthly> OpeningStock(GetFormF1DetailsModel model)
        {
            ProductionModel_Monthly objModel = new ProductionModel_Monthly();
            try
            {
                var paramList = new
                {

                    UserId = model.UserID,
                    MineralId = model.MineralID,
                    MonthName = model.Month_Year,
                    Check = 1,
                };


                var result = await Connection.ExecuteReaderAsync("Usp_GetOpeningStock", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var ds = ConvertDataReaderToDataSet(result);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    objModel.OpeningStockOCW = (ds.Tables[0].Rows[0]["ClosingStockCW"] != DBNull.Value ? Convert.ToDecimal(ds.Tables[0].Rows[0]["ClosingStockCW"]) : 0);
                    objModel.OpeningStockUW = (ds.Tables[0].Rows[0]["ClosingStockUW"] != DBNull.Value ? Convert.ToDecimal(ds.Tables[0].Rows[0]["ClosingStockUW"]) : 0);
                    objModel.OpeningStockDW = (ds.Tables[0].Rows[0]["ClosingStockDW"] != DBNull.Value ? Convert.ToDecimal(ds.Tables[0].Rows[0]["ClosingStockDW"]) : 0);
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
        /// Get Mineral form
        /// </summary>
        /// <param name="ObjMR"></param>
        /// <returns>DDLResult class</returns>
        public async Task<DDLResult> GetMineralForm(MonthlyReturnModelNonCoal ObjMR)
        {
            DDLResult objres = new DDLResult();
            DataTable ObjDt = new DataTable();
            List<MonthlyReturnModelNonCoal> ListDP = new List<MonthlyReturnModelNonCoal>();
            MonthlyReturnModelNonCoal DPEF = new MonthlyReturnModelNonCoal();

            try
            {
                var paramList = new
                {
                    MineralId = ObjMR.MineralId,
                    UserId = ObjMR.Uid,


                };
                var result = await Connection.QueryAsync<MonthlyReturnModelNonCoal>("Usp_GetMineralFORM_E_Return", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {


                    foreach (MonthlyReturnModelNonCoal dr in result)
                    {
                        ListDP.Add(new MonthlyReturnModelNonCoal()
                        {
                            MineralNatureId = dr.MineralNatureId,
                            MineralNature = dr.MineralNature,
                        });
                    }

                    objres.GetDDL = ListDP;
                }
                return objres;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objres = null;
                ObjMR = null;
            }

        }

        /// <summary>
        /// Get Mineral Grade
        /// </summary>
        /// <param name="ObjMR"></param>
        /// <returns>DDLResult class</returns>
        public async Task<DDLResult> GetMineralGrade(MonthlyReturnModelNonCoal ObjMR)
        {
            DDLResult objres = new DDLResult();
            DataTable ObjDt = new DataTable();
            List<MonthlyReturnModelNonCoal> ListDP = new List<MonthlyReturnModelNonCoal>();
            MonthlyReturnModelNonCoal DPEF = new MonthlyReturnModelNonCoal();

            try
            {
                var paramList = new
                {
                    MineralNatureId = ObjMR.MineralNatureId,
                    UserId = ObjMR.Uid,
                    Check = 2,


                };
                var result = await Connection.QueryAsync<MonthlyReturnModelNonCoal>("UspGetMineralForE_Return", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {


                    foreach (MonthlyReturnModelNonCoal dr in result)
                    {
                        ListDP.Add(new MonthlyReturnModelNonCoal()
                        {
                            MineralGradeID = dr.MineralGradeID,
                            MineralGrade = dr.MineralGrade,
                        });
                    }

                    objres.GetDDL = ListDP;
                }

                return objres;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objres = null;
                ObjMR = null;
            }
        }

        /// <summary>
        /// Add Grade wise ROM
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> ADDGradewise_ROM(Gradewise_ROMModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();

                p.Add("MineralNatureId", objModel.MineralNatureId8);
                p.Add("MineralGradeId", objModel.MineralGradeId8);
                p.Add("Despatches_minehead", objModel.Despatches_minehead);
                p.Add("Ex_mine_Price", objModel.Ex_mine_Price);
                p.Add("Month_Year", objModel.Month_YearGradewise_ROM);
                p.Add("CreatedBy", objModel.UID);
                p.Add("Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_Gradewise_ROM", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
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
        /// Get Grade wise ROM
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of Gradewise_ROMModel Details</returns>
        public async Task<List<Gradewise_ROMModel>> GetGradewise_ROM(MonthlyReturnModelNonCoal model)
        {
            List<Gradewise_ROMModel> list = new List<Gradewise_ROMModel>();
            try
            {
                var paramList = new
                {
                    Month_Year = model.MonthYear,
                    UserID = model.Uid,
                    Check = 1,
                };


                var result = await Connection.ExecuteReaderAsync("Usp_GetGradewise_ROM", paramList, commandType: System.Data.CommandType.StoredProcedure);



                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Gradewise_ROMModel objModel = new Gradewise_ROMModel();
                        objModel.GradeWiseRom_Id = Convert.ToInt32(dt.Rows[i]["GradeWiseRom_Id"]);
                        objModel.MineralNatureId8 = Convert.ToInt32(dt.Rows[i]["MineralNatureId"]);
                        objModel.MineralNature = Convert.ToString(dt.Rows[i]["MineralNature"]);
                        objModel.MineralGradeId8 = Convert.ToInt32(dt.Rows[i]["MineralGradeId"]);
                        objModel.MineralGrade = Convert.ToString(dt.Rows[i]["MineralGrade"]);
                        objModel.Despatches_minehead = Convert.ToDecimal(dt.Rows[i]["Despatches_minehead"]);
                        objModel.Ex_mine_Price = Convert.ToDecimal(dt.Rows[i]["Ex_mine_Price"]);
                        objModel.Month_YearGradewise_ROM = Convert.ToString(dt.Rows[i]["Month_Year"]);
                        // objModel.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
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
                list = null;
                model = null;
            }
        }

        /// <summary>
        /// Update Grade Wise ROM
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateGradewise_ROM(Gradewise_ROMModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("GradeWiseRom_Id", objModel.GradeWiseRom_Id);
                p.Add("MineralNatureId", objModel.MineralNatureId8);
                p.Add("MineralGradeId", objModel.MineralGradeId8);
                p.Add("Despatches_minehead", objModel.Despatches_minehead);
                p.Add("Ex_mine_Price", objModel.Ex_mine_Price);
                p.Add("Month_Year", objModel.Month_YearGradewise_ROM);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_Gradewise_ROM", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
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
        /// Delete Grade wise ROM
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> DeleteGradewise_ROM(Gradewise_ROMModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("GradeWiseRom_Id", objModel.GradeWiseRom_Id);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Check", 3);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_Gradewise_ROM", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
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
        /// Get Mineral From Production
        /// </summary>
        /// <param name="ObjMR"></param>
        /// <returns>DDLResult</returns>
        public async Task<DDLResult> GetMineralFormProduction(MonthlyReturnModelNonCoal ObjMR)
        {
            DDLResult objres = new DDLResult();
            List<MonthlyReturnModelNonCoal> ListDP = new List<MonthlyReturnModelNonCoal>();

            try
            {
                var paramList = new
                {
                    MineralId = ObjMR.MineralId,
                    UserId = ObjMR.Uid,
                    Check = 1,


                };
                var result = await Connection.QueryAsync<MonthlyReturnModelNonCoal>("UspGetMineralForE_Return", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {


                    foreach (MonthlyReturnModelNonCoal dr in result)
                    {
                        ListDP.Add(new MonthlyReturnModelNonCoal()
                        {
                            MineralNatureId = dr.MineralNatureId,
                            MineralNature = dr.MineralNature,
                        });
                    }

                    objres.GetDDL = ListDP;
                }
                return objres;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objres = null;
                ObjMR = null;
                ListDP = null;
            }

        }

        /// <summary>
        /// Add Grade wise Production
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> ADDGradewise_Production(Grade_WiseProduction objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("MineralNaturaId", objModel.MineralNatureId5);
                p.Add("MineralGradeId", objModel.MineralGradeId5);
                p.Add("OpeningStock_MineHead", objModel.OpeningStock_MineHead);
                p.Add("Production", objModel.Production);
                p.Add("Dispatch_MineHead", objModel.Dispatch_MineHead);
                p.Add("ClosingStock_MineHead", objModel.ClosingStock_MineHead);
                p.Add("Ex_MinePrice", objModel.Ex_MinePrice);
                p.Add("Month_Year", objModel.Month_YearGradeWise);
                p.Add("CreatedBy", objModel.UID);
                p.Add("Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_Gradewise_Production", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
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
        /// Get Grade wise Production
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of Grade_WiseProduction</returns>
        public async Task<List<Grade_WiseProduction>> GetGrade_WiseProduction(MonthlyReturnModelNonCoal model)
        {
            List<Grade_WiseProduction> list = new List<Grade_WiseProduction>();
            try
            {
                var paramList = new
                {
                    Month_Year = model.MonthYear,
                    UserID = model.Uid,
                    Check = 1,
                };
                var result = await Connection.ExecuteReaderAsync("Usp_GetGradewise_Production", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Grade_WiseProduction objModel = new Grade_WiseProduction();
                        objModel.GradeWiseProduction_Id = Convert.ToInt32(dt.Rows[i]["GradeWiseProduction_Id"]);
                        objModel.MineralNatureId5 = Convert.ToInt32(dt.Rows[i]["MineralNatureId"]);
                        objModel.MineralNature = Convert.ToString(dt.Rows[i]["MineralNature"]);
                        objModel.MineralGradeId5 = Convert.ToInt32(dt.Rows[i]["MineralGradeId"]);
                        objModel.MineralGrade = Convert.ToString(dt.Rows[i]["MineralGrade"]);
                        objModel.OpeningStock_MineHead = Convert.ToDecimal(dt.Rows[i]["OpeningStock_MineHead"]);
                        objModel.Production = Convert.ToDecimal(dt.Rows[i]["Production"]);
                        objModel.Dispatch_MineHead = (dt.Rows[i]["Dispatch_MineHead"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[i]["Dispatch_MineHead"]) : 0);
                        objModel.ClosingStock_MineHead = (dt.Rows[i]["ClosingStock_MineHead"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[i]["ClosingStock_MineHead"]) : 0);
                        objModel.Ex_MinePrice = Convert.ToDecimal(dt.Rows[i]["Ex_MinePrice"]);
                        objModel.Month_YearGradeWise = Convert.ToString(dt.Rows[i]["Month_Year"]);
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
                list = null;
                model = null;
            }
        }

        /// <summary>
        /// Update grade wise production
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateGradewise_Prod(Grade_WiseProduction objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("GradeWiseProduction_Id", objModel.GradeWiseProduction_Id);
                p.Add("MineralNaturaId", objModel.MineralNatureId5);
                p.Add("MineralGradeId", objModel.MineralGradeId5);
                p.Add("OpeningStock_MineHead", objModel.OpeningStock_MineHead);
                p.Add("Production", objModel.Production);
                p.Add("Dispatch_MineHead", objModel.Dispatch_MineHead);
                p.Add("ClosingStock_MineHead", objModel.ClosingStock_MineHead);
                p.Add("Ex_MinePrice", objModel.Ex_MinePrice);
                p.Add("Month_Year", objModel.Month_YearGradeWise);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_Gradewise_Production", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
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
        /// Delete Grade wise production
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> DeleteGradewise_Prod(Grade_WiseProduction objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("GradeWiseProduction_Id", objModel.GradeWiseProduction_Id);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Check", 3);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_Gradewise_Production", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
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
        /// Get Nature of Dispatch
        /// </summary>
        /// <param name="ObjMR"></param>
        /// <returns>List of SalesDispatchModel</returns>
        public async Task<List<SalesDispatchModel>> GetNatureOfDispatch(SalesDispatchModel ObjMR)
        {
            List<SalesDispatchModel> ListDP = new List<SalesDispatchModel>();
            SalesDispatchModel DPEF = new SalesDispatchModel();

            try
            {
                var result = await Connection.QueryAsync<SalesDispatchModel>("GetNatureOfDispatch", commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {


                    foreach (SalesDispatchModel dr in result)
                    {
                        ListDP.Add(new SalesDispatchModel()
                        {
                            NatureofDispatch = dr.NatureofDispatch,
                        });
                    }
                    return ListDP;
                }
                return ListDP;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ListDP = null;
                ObjMR = null;
            }
        }

        /// <summary>
        /// Get Purchaser Consignee
        /// </summary>
        /// <param name="ObjMR"></param>
        /// <returns>List of SalesDispatchModel</returns>
        public async Task<List<SalesDispatchModel>> GetPurchaserConsignee(MonthlyReturnModelNonCoal ObjMR)
        {
            List<SalesDispatchModel> ListDP = new List<SalesDispatchModel>();
            SalesDispatchModel DPEF = new SalesDispatchModel();

            try
            {
                var paramList = new
                {
                    UserId = ObjMR.Uid,
                    Check = 2,
                };

                var result = await Connection.ExecuteReaderAsync("Usp_GetSaleDispatch", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SalesDispatchModel objModel = new SalesDispatchModel();
                        objModel.PurchaserConsineeId = Convert.ToInt32(dt.Rows[i]["PurchaserConsigneeId"]);
                        objModel.PurchaserConsinee = Convert.ToString(dt.Rows[i]["Consignee"]);
                        ListDP.Add(objModel);
                    }
                }
                return ListDP;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ListDP = null;
                ObjMR = null;
            }

        }

        /// <summary>
        /// Add Sale and Despatch
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddSaleDispatch(SalesDispatchModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("MineralNatureId", objModel.MineralNatureId6);
                p.Add("MineralGradeId", objModel.MineralGradeId6);
                p.Add("NatureOfDispatch", objModel.NatureofDispatch);
                p.Add("RegistrationNo", objModel.RegistrationNo);
                p.Add("PurchaserConsinee", objModel.PurchaserConsinee);
                p.Add("DomesticPurpose_Quantity", objModel.DomesticPurposes_Quantity);
                p.Add("SaleValue", objModel.SaleValue);
                p.Add("Country", objModel.Country);
                p.Add("Export_Quantity", objModel.Export_Quantity);
                p.Add("FOBValue", objModel.FOBValue);
                p.Add("Month_Year", objModel.MonthYear);
                p.Add("MineralId", objModel.MineralId);
                p.Add("CreatedBy", objModel.UId);
                p.Add("Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_SaleDispatch", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
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
        /// Get Sale Dispatch
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of SalesDispatchModel</returns>
        public async Task<List<SalesDispatchModel>> GetSalesDespatch(MonthlyReturnModelNonCoal model)
        {
            List<SalesDispatchModel> list = new List<SalesDispatchModel>();
            try
            {
                var paramList = new
                {
                    Month_Year = model.MonthYear,
                    UserID = model.Uid,
                    Check = 1,
                };


                var result = await Connection.ExecuteReaderAsync("Usp_GetSaleDispatch", paramList, commandType: System.Data.CommandType.StoredProcedure);



                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SalesDispatchModel objModel = new SalesDispatchModel();
                        objModel.Sale_Dispatch_Id = Convert.ToInt32(dt.Rows[i]["Sale_Dispatch_Id"]);
                        objModel.MineralNatureId6 = Convert.ToInt32(dt.Rows[i]["MineralNatureId"]);
                        objModel.MineralNature = Convert.ToString(dt.Rows[i]["MineralNature"]);
                        objModel.MineralGradeId6 = Convert.ToInt32(dt.Rows[i]["MineralGradeId"]);
                        objModel.MineralGrade = Convert.ToString(dt.Rows[i]["MineralGrade"]);
                        objModel.NatureofDispatch = Convert.ToString(dt.Rows[i]["NatureofDispatch"]);
                        objModel.RegistrationNo = Convert.ToString(dt.Rows[i]["RegistrationNo"]);
                        objModel.PurchaserConsinee = Convert.ToString(dt.Rows[i]["PurchaserConsinee"]);
                        objModel.DomesticPurposes_Quantity = Convert.ToDecimal(dt.Rows[i]["DomesticPurposes_Quantity"]);
                        objModel.SaleValue = Convert.ToDecimal(dt.Rows[i]["SaleValue"]);
                        objModel.Country = Convert.ToString(dt.Rows[i]["Country"]);
                        objModel.Export_Quantity = Convert.ToDecimal(dt.Rows[i]["Export_Quantity"]);
                        objModel.FOBValue = Convert.ToString(dt.Rows[i]["FOBValue"]);
                        objModel.Month_YearSalesDispatch = Convert.ToString(dt.Rows[i]["Month_Year"]);
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
                list = null;
                model = null;
            }
        }

        /// <summary>
        /// Update Sale Despatch
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateSaleDispatch(SalesDispatchModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Sale_Dispatch_Id", objModel.Sale_Dispatch_Id);
                p.Add("MineralNatureId", objModel.MineralNatureId6);
                p.Add("MineralGradeId", objModel.MineralGradeId6);
                p.Add("NatureOfDispatch", objModel.NatureofDispatch);
                p.Add("RegistrationNo", objModel.RegistrationNo);
                p.Add("PurchaserConsinee", objModel.PurchaserConsinee);
                p.Add("DomesticPurpose_Quantity", objModel.DomesticPurposes_Quantity);
                p.Add("SaleValue", objModel.SaleValue);
                p.Add("Country", objModel.Country);
                p.Add("Export_Quantity", objModel.Export_Quantity);
                p.Add("FOBValue", objModel.FOBValue);
                p.Add("Month_Year", objModel.MonthYear);
                p.Add("ModifiedBy", objModel.UId);
                p.Add("Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_SaleDispatch", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
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
        /// Delete Sale Dispatch
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> DeleteSaleDispatch(SalesDispatchModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("Sale_Dispatch_Id", objModel.Sale_Dispatch_Id);
                p.Add("ModifiedBy", objModel.UId);
                p.Add("Check", 3);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_SaleDispatch", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
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
        /// Add Pulverization Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddPulverization(Mineral_PulverizedModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("MineralNatureId", objModel.MineralNatureId7);
                p.Add("MineralGradeId", objModel.MineralGradeId7);
                p.Add("Total_Qty_Mineral_Pulverization", objModel.Total_Qty_Mineral_Pulverization);
                p.Add("Pulverized_MeshSize", objModel.Pulverized_MeshSize);
                p.Add("Pulverized_Qty", objModel.Pulverized_Qty);
                p.Add("Produced_MeshSize", objModel.Produced_MeshSize);
                p.Add("Produced_Qty", objModel.Produced_Qty);
                p.Add("Produced_Ex_factory_Sale_value", objModel.Produced_Ex_factory_Sale_value);
                p.Add("Month_Year", objModel.Month_YearPulverization);
                p.Add("CreatedBy", objModel.UId);
                p.Add("Check", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_Mineral_Pulverization", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
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
        /// Get Mineral Pulverized
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of Mineral_PulverizedModel class</returns>
        public async Task<List<Mineral_PulverizedModel>> GetMineral_Pulverized(MonthlyReturnModelNonCoal model)
        {
            List<Mineral_PulverizedModel> list = new List<Mineral_PulverizedModel>();
            try
            {
                var paramList = new
                {
                    Month_Year = model.MonthYear,
                    UserID = model.Uid,
                    Check = 1,
                };

                var result = await Connection.ExecuteReaderAsync("Usp_GetMineral_Pulverization", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Mineral_PulverizedModel objModel = new Mineral_PulverizedModel();
                        objModel.Pulverization_id = Convert.ToInt32(dt.Rows[i]["Pulverization_id"]);
                        objModel.MineralNatureId7 = Convert.ToInt32(dt.Rows[i]["MineralNatureId"]);
                        objModel.MineralNature = Convert.ToString(dt.Rows[i]["MineralNature"]);
                        objModel.MineralGradeId7 = Convert.ToInt32(dt.Rows[i]["MineralGradeId"]);
                        objModel.MineralGrade = Convert.ToString(dt.Rows[i]["MineralGrade"]);
                        objModel.Total_Qty_Mineral_Pulverization = Convert.ToDecimal(dt.Rows[i]["Total_Qty_Mineral_Pulverization"]);
                        objModel.Pulverized_MeshSize = Convert.ToString(dt.Rows[i]["Pulverized_MeshSize"]);
                        objModel.Pulverized_Qty = Convert.ToDecimal(dt.Rows[i]["Pulverized_Qty"]);
                        objModel.Produced_MeshSize = Convert.ToString(dt.Rows[i]["Produced_MeshSize"]);
                        objModel.Produced_Qty = Convert.ToDecimal(dt.Rows[i]["Produced_Qty"]);
                        objModel.Produced_Ex_factory_Sale_value = Convert.ToDecimal(dt.Rows[i]["Produced_Ex_factory_Sale_value"]);
                        objModel.Month_YearPulverization = Convert.ToString(dt.Rows[i]["Month_Year"]);
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
                list = null;
                model = null;
            }
        }

        /// <summary>
        /// Update mineral pulverized
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateMineral_Pulverized(Mineral_PulverizedModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("Pulverization_id", objModel.Pulverization_id);
                p.Add("MineralNatureId", objModel.MineralNatureId7);
                p.Add("MineralGradeId", objModel.MineralGradeId7);
                p.Add("Total_Qty_Mineral_Pulverization", objModel.Total_Qty_Mineral_Pulverization);
                p.Add("Pulverized_MeshSize", objModel.Pulverized_MeshSize);
                p.Add("Pulverized_Qty", objModel.Pulverized_Qty);
                p.Add("Produced_MeshSize", objModel.Produced_MeshSize);
                p.Add("Produced_Qty", objModel.Produced_Qty);
                p.Add("Produced_Ex_factory_Sale_value", objModel.Produced_Ex_factory_Sale_value);
                p.Add("Month_Year", objModel.Month_YearPulverization);
                p.Add("ModifiedBy", objModel.UId);
                p.Add("Check", 2);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_Mineral_Pulverization", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
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
        /// Delete mineral Pulverized
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> DeleteeMineral_Pulverized(Mineral_PulverizedModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("Pulverization_id", objModel.Pulverization_id);
                p.Add("ModifiedBy", objModel.UId);
                p.Add("Check", 3);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_Mineral_Pulverization", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
                return objMessage;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objModel = null;
                objMessage = null;
            }


        }

        /// <summary>
        /// Add Reason
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddReasonForInDc(Reason_Inc_Dec_Monthly objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("productionIncrDecResion", objModel.productionIncrDecResion);
                p.Add("ex_minepriceIncrDecResion", objModel.ex_minepriceIncrDecResion);
                p.Add("certify", objModel.certify);
                p.Add("MineralId", objModel.MineralId);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("CreatedBy", objModel.UID);
                p.Add("Check", 5);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_eReturn_FormF1Part2", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (objMessage.Satus == "2")
                {
                    objMessage.Msg = "This Details Already Exist..";
                }
                else if (objMessage.Satus == "1")
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
        /// Add Deduction Made 
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddDeductionMade(Details_of_deductions_Monthly objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("Deduction_claimedType7", objModel.Deduction_claimedType7);

                p.Add("Amount1", objModel.Amount1);
                p.Add("Amount2", objModel.Amount2);
                p.Add("Amount3", objModel.Amount3);
                p.Add("Amount4", objModel.Amount4);
                p.Add("Amount5", objModel.Amount5);
                p.Add("Amount6", objModel.Amount6);
                p.Add("Amount7", objModel.Amount7);

                p.Add("Remarks1", objModel.Remarks1);
                p.Add("Remarks2", objModel.Remarks2);
                p.Add("Remarks3", objModel.Remarks3);
                p.Add("Remarks4", objModel.Remarks4);
                p.Add("Remarks5", objModel.Remarks5);
                p.Add("Remarks6", objModel.Remarks6);
                p.Add("Remarks7", objModel.Remarks7);
                p.Add("TotalAmount", objModel.TotalAmount);
                p.Add("MineralId", objModel.MineralId);

                p.Add("CExMineSale", objModel.CExMineSale);
                p.Add("ExMineSale", objModel.ex_mineSale);

                p.Add("CreatedBy", objModel.UID);
                p.Add("Month_Year", objModel.Month_Year);

                p.Add("Check", 3);

                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_eReturn_FormF1Part2", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (objMessage.Satus == "2")
                {
                    objMessage.Msg = "This Details Already Exist..";
                }
                else if (objMessage.Satus == "1")
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
        /// Update Reason
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateReasonForInDc(Reason_Inc_Dec_Monthly objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("Reason_Inc_Dec_Id", objModel.Reason_Inc_Dec_Id);
                p.Add("productionIncrDecResion", objModel.productionIncrDecResion);
                p.Add("ex_minepriceIncrDecResion", objModel.ex_minepriceIncrDecResion);
                p.Add("MineralId", objModel.MineralId);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Check", 6);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_eReturn_FormF1Part2", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (objMessage.Satus == "2")
                {
                    objMessage.Msg = "Record Has not Updated..";
                }
                else if (objMessage.Satus == "1")
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
        /// Update details of deduction
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateDetails_of_deductions(Details_of_deductions_Monthly objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();

                p.Add("DeductionMade_Id", objModel.DeductionMade_Id);
                p.Add("Averagecostofpulverization", objModel.Averagecostofpulverization);
                p.Add("Deduction_claimedType1", objModel.Deduction_claimedType1);
                p.Add("Amount1", objModel.Amount1);
                p.Add("Remarks1", objModel.Remarks1);


                p.Add("Deduction_claimedType2", objModel.Deduction_claimedType2);
                p.Add("Amount2", objModel.Amount2);
                p.Add("Remarks2", objModel.Remarks2);

                p.Add("Deduction_claimedType3", objModel.Deduction_claimedType3);
                p.Add("Amount3", objModel.Amount3);
                p.Add("Remarks3", objModel.Remarks3);

                p.Add("Deduction_claimedType4", objModel.Deduction_claimedType4);
                p.Add("Amount4", objModel.Amount4);
                p.Add("Remarks4", objModel.Remarks4);

                p.Add("Deduction_claimedType5", objModel.Deduction_claimedType5);
                p.Add("Amount5", objModel.Amount5);
                p.Add("Remarks5", objModel.Remarks5);

                p.Add("Deduction_claimedType6", objModel.Deduction_claimedType6);
                p.Add("Amount6", objModel.Amount6);
                p.Add("Remarks6", objModel.Remarks6);

                p.Add("Deduction_claimedType7", objModel.Deduction_claimedType7);
                p.Add("Amount7", objModel.Amount7);
                p.Add("Remarks7", objModel.Remarks7);

                p.Add("TotalAmount", objModel.TotalAmount);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("MineralId", objModel.MineralId);
                p.Add("CExMineSale", objModel.CExMineSale);
                p.Add("ExMineSale", objModel.ex_mineSale);

                p.Add("ModifiedBy", objModel.UID);
                p.Add("Check", 4);

                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_eReturn_FormF1Part2", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (objMessage.Satus == "2")
                {
                    objMessage.Msg = "Record Has not Updated..";
                }
                else if (objMessage.Satus == "1")
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
        /// Add Type Production Part2
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddTypeProductionPartTwo(ProductionModel_Monthly objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("TypeofOreProduced", objModel.TypeofOreProduced);
                p.Add("Category_Type1", "Open Cast workings");
                p.Add("OpeningStockCW", objModel.OpeningStockOCW);
                p.Add("ProductionCW", objModel.productionOCW);
                p.Add("ClosingStockCW", objModel.closingOCW);

                p.Add("Category_Type2", "Underground Workings");
                p.Add("OpeningStockUW", objModel.OpeningStockUW);
                p.Add("ProductionUW", objModel.productionUW);
                p.Add("ClosingStockUW", objModel.closingUW);

                p.Add("Category_Type3", "Dump workings");
                p.Add("OpeningStockDW", objModel.OpeningStockDW);
                p.Add("ProductionDW", objModel.productionDW);
                p.Add("ClosingStockDW", objModel.closingDW);


                p.Add("CreatedBy", objModel.UID);
                p.Add("MineralId", objModel.MineralId1);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("Check", 1);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_eReturn_FormF1Part2", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (objMessage.Satus == "2")
                {
                    objMessage.Msg = "This Details Already Exit..";
                }
                else if (objMessage.Satus == "1")
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
        /// Update production Type F2
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateTypeProductionPartTwo(ProductionModel_Monthly objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("TypeOfProduction_Id", objModel.TypeOfProduction_Id);
                p.Add("TypeofOreProduced", objModel.TypeofOreProduced);
                p.Add("Category_Type1", "Open Cast workings");
                p.Add("OpeningStockCW", objModel.OpeningStockOCW);
                p.Add("ProductionCW", objModel.productionOCW);
                p.Add("ClosingStockCW", objModel.closingOCW);
                p.Add("Category_Type2", "Underground Workings");
                p.Add("OpeningStockUW", objModel.OpeningStockUW);
                p.Add("ProductionUW", objModel.productionUW);
                p.Add("ClosingStockUW", objModel.closingUW);
                p.Add("Category_Type3", "Dump workings");
                p.Add("OpeningStockDW", objModel.OpeningStockDW);
                p.Add("ProductionDW", objModel.productionDW);
                p.Add("ClosingStockDW", objModel.closingDW);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("MineralId", objModel.MineralId1);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("Check", 2);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_eReturn_FormF1Part2", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (objMessage.Satus == "2")
                {
                    objMessage.Msg = "Record Has not Updated..";
                }
                else if (objMessage.Satus == "1")
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
        /// Update final Submit
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> Update_FinalSubmit(Reason_Inc_Dec_Monthly objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("CreatedBy", objModel.UID);
                p.Add("Check", 7);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_eReturn_FormF1Part2", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (objMessage.Satus == "2")
                {
                    objMessage.Msg = "Monthly Return has not Submited";
                }
                else if (objMessage.Satus == "1")
                {
                    objMessage.Msg = "Monthly Return has been Submited Successfully";
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
        /// Add Pulverization f2
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> Addpulverization1(Details_of_deductions_Monthly objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("Averagecostofpulverization", objModel.Averagecostofpulverization);
                p.Add("CreatedBy", objModel.UID);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("Check", 8);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_eReturn_FormF1Part2", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (objMessage.Satus == "2")
                {
                    objMessage.Msg = "This Details Already Exit..";
                }
                else if (objMessage.Satus == "1")
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
        /// Update Pulverization Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> Updatepulverization(Details_of_deductions_Monthly objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("Average_Id", objModel.Average_Id);
                p.Add("Averagecostofpulverization", objModel.Averagecostofpulverization);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("Check", 9);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Usp_eReturn_FormF1Part2", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (objMessage.Satus == "2")
                {
                    objMessage.Msg = "Record Has not Updated..";
                }
                else if (objMessage.Satus == "1")
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
        /// Get details of form1 part1 print
        /// </summary>
        /// <param name="model"></param>
        /// <returns>GetFormF1DetailsModel class</returns>
        public async Task<GetFormF1DetailsModel> GetFormF1Part1ForPrint(MonthlyReturnModelNonCoal model)
        {

            GetFormF1DetailsModel objModel = new GetFormF1DetailsModel();
            try
            {
                var paramList = new
                {
                    FormType = "Form F1",
                    UserID = model.Uid,
                    Month_Year = model.MonthYear,
                    Check = 1,
                };


                var result = await Connection.ExecuteReaderAsync("UspGetFormF1ForPrint", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    objModel.Month_Year = Convert.ToString(dt.Rows[0]["Month_Year"]);
                    objModel.Registrationnumber = Convert.ToString(dt.Rows[0]["Registrationnumber"]);
                    objModel.MINE_CODE = Convert.ToString(dt.Rows[0]["MINE_CODE"]);
                    objModel.MineralName = Convert.ToString(dt.Rows[0]["MineralName"]);
                    objModel.MineName = Convert.ToString(dt.Rows[0]["MineName"]);
                    objModel.MineAddress = Convert.ToString(dt.Rows[0]["MineAddress"]);
                    objModel.MineVillage = Convert.ToString(dt.Rows[0]["MineVillage"]);
                    objModel.MineDistrict = Convert.ToString(dt.Rows[0]["MineDistrict"]);
                    objModel.MineState = Convert.ToString(dt.Rows[0]["MineState"]);
                    objModel.MineTehsil = Convert.ToString(dt.Rows[0]["MineTehsil"]);
                    objModel.MinePinCode = Convert.ToString(dt.Rows[0]["MinePinCode"]);
                    objModel.MinePostOffice = Convert.ToString(dt.Rows[0]["MinePostOffice"]);
                    objModel.MineFaxNo = Convert.ToString(dt.Rows[0]["MineFaxNo"]);
                    objModel.LesseeFaxNo = Convert.ToString(dt.Rows[0]["LesseeFaxNo"]);
                    objModel.MineEmailID = Convert.ToString(dt.Rows[0]["MineEmailID"]);
                    objModel.MineMobileNo = Convert.ToString(dt.Rows[0]["MineMobileNo"]);
                    objModel.MinePhoneNo = Convert.ToString(dt.Rows[0]["MinePhoneNo"]);
                    objModel.LesseeName = Convert.ToString(dt.Rows[0]["LesseeName"]);
                    objModel.LesseeAddress = Convert.ToString(dt.Rows[0]["LesseeAddress"]);
                    objModel.LesseeDistrictName = Convert.ToString(dt.Rows[0]["MineDistrict"]);
                    objModel.LesseeTehsilName = Convert.ToString(dt.Rows[0]["MineTehsil"]);
                    objModel.LesseeStateName = Convert.ToString(dt.Rows[0]["MineState"]);
                    objModel.LesseeMobileNo = Convert.ToString(dt.Rows[0]["LesseeMobileNo"]);
                    objModel.LesseePinCode = Convert.ToString(dt.Rows[0]["LesseePinCode"]);
                    objModel.LesseeEmailID = Convert.ToString(dt.Rows[0]["LesseeEmailID"]);
                    objModel.OtherMineral = Convert.ToString(dt.Rows[0]["OtherMinerals"]);

                    if (!(dt.Rows[0]["Details_Id"] is DBNull))
                    {
                        objModel.Details_Id = Convert.ToInt32(dt.Rows[0]["Details_Id"]);
                    }

                    if (!(dt.Rows[0]["Wages_Id"] is DBNull))
                    {
                        objModel.Wages_Id = Convert.ToInt32(dt.Rows[0]["Wages_Id"]);
                    }

                    objModel.Rentpaid = (dt.Rows[0]["Rent_paid"] != DBNull.Value ? Convert.ToString(dt.Rows[0]["Rent_paid"]) : "0");
                    if (!(dt.Rows[0]["Royalty_paid"] is DBNull))
                    {
                        objModel.Royaltypaid = Convert.ToDecimal(dt.Rows[0]["Royalty_paid"]);
                    }
                    objModel.DeadRentpaid = (dt.Rows[0]["Dead_Rent_paid"] != DBNull.Value ? Convert.ToString(dt.Rows[0]["Dead_Rent_paid"]) : "0");
                    if (!(dt.Rows[0]["DMF"] is DBNull))
                    {
                        objModel.DMFPaid = Convert.ToDecimal(dt.Rows[0]["DMF"]);
                    }
                    if (!(dt.Rows[0]["NMET"] is DBNull))
                    {
                        objModel.NMETPaid = Convert.ToDecimal(dt.Rows[0]["NMET"]);
                    }
                    if (!(dt.Rows[0]["NoOfDaysMineWork"] is DBNull))
                    {
                        objModel.NoOfDaysMineWork = Convert.ToInt32(dt.Rows[0]["NoOfDaysMineWork"]);
                    }
                    objModel.DirectMale1 = (dt.Rows[0]["DirectMale1"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["DirectMale1"]) : 0);
                    objModel.DirectMale2 = (dt.Rows[0]["DirectMale2"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["DirectMale2"]) : 0);
                    objModel.DirectMale3 = (dt.Rows[0]["DirectMale3"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["DirectMale3"]) : 0);

                    objModel.DirectFemale1 = (dt.Rows[0]["DirectFemale1"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["DirectFemale1"]) : 0);
                    objModel.DirectFemale2 = (dt.Rows[0]["DirectFemale2"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["DirectFemale2"]) : 0);
                    objModel.DirectFemale3 = (dt.Rows[0]["DirectFemale3"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["DirectFemale3"]) : 0);

                    objModel.ContractMale1 = (dt.Rows[0]["ContractMale1"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["ContractMale1"]) : 0);
                    objModel.ContractMale2 = (dt.Rows[0]["ContractMale2"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["ContractMale2"]) : 0);
                    objModel.ContractMale3 = (dt.Rows[0]["ContractMale3"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["ContractMale3"]) : 0);

                    objModel.ContractFemale1 = (dt.Rows[0]["ContractFemale1"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["ContractFemale1"]) : 0);
                    objModel.ContractFemale2 = (dt.Rows[0]["ContractFemale2"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["ContractFemale2"]) : 0);
                    objModel.ContractFemale3 = (dt.Rows[0]["ContractFemale3"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["ContractFemale3"]) : 0);

                    objModel.TotalWagesMale1 = (dt.Rows[0]["BGTotalMale"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["BGTotalMale"]) : 0);
                    objModel.TotalWagesFeMale1 = (dt.Rows[0]["BGTotalFemale"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["BGTotalFemale"]) : 0);

                    objModel.TotalWagesMale2 = (dt.Rows[0]["OCTotalMale"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["OCTotalMale"]) : 0);
                    objModel.TotalWagesFeMale2 = (dt.Rows[0]["OCTptalFemale"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["OCTptalFemale"]) : 0);

                    objModel.TotalWagesMale3 = (dt.Rows[0]["AGTotalMale"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["AGTotalMale"]) : 0);
                    objModel.TotalWagesFeMale3 = (dt.Rows[0]["AGTotalFemale"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["AGTotalFemale"]) : 0);

                    objModel.TotalDirectMale = (dt.Rows[0]["TotalDirectMale"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["TotalDirectMale"]) : 0);
                    objModel.TotalDirectFemale = (dt.Rows[0]["TotalDirectFemale"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["TotalDirectFemale"]) : 0);

                    objModel.TotalContractMale = (dt.Rows[0]["TotalContractMale"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["TotalContractMale"]) : 0);
                    objModel.TotalContractFemale = (dt.Rows[0]["TotalContractFemale"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["TotalContractFemale"]) : 0);

                    objModel.TotalMaleWages = (dt.Rows[0]["TotalMaleWages"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["TotalMaleWages"]) : 0);
                    objModel.TotalFeMaleWages = (dt.Rows[0]["TotalFeMaleWages"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["TotalFeMaleWages"]) : 0);
                    //---------------------------------

                    objModel.TypeOfProduction = Convert.ToString(dt.Rows[0]["TypeOfProduction"]);
                    if (!(dt.Rows[0]["OpeningStockCw"] is DBNull))
                    {
                        objModel.OpeningStockCw = Convert.ToDecimal(dt.Rows[0]["OpeningStockCw"]);
                    }
                    if (!(dt.Rows[0]["OpeningStockUW"] is DBNull))
                    {
                        objModel.OpeningStockUW = Convert.ToDecimal(dt.Rows[0]["OpeningStockUW"]);
                    }
                    if (!(dt.Rows[0]["OpeningStockDW"] is DBNull))
                    {
                        objModel.OpeningStockDW = Convert.ToDecimal(dt.Rows[0]["OpeningStockDW"]);
                    }
                    if (!(dt.Rows[0]["ProductionCW"] is DBNull))
                    {
                        objModel.ProductionCW = Convert.ToDecimal(dt.Rows[0]["ProductionCW"]);
                    }
                    if (!(dt.Rows[0]["ProductionUW"] is DBNull))
                    {
                        objModel.ProductionUW = Convert.ToDecimal(dt.Rows[0]["ProductionUW"]);
                    }
                    if (!(dt.Rows[0]["ProductionDW"] is DBNull))
                    {
                        objModel.ProductionDW = Convert.ToDecimal(dt.Rows[0]["ProductionDW"]);
                    }
                    if (!(dt.Rows[0]["ClosingStockCW"] is DBNull))
                    {
                        objModel.ClosingStockCW = Convert.ToDecimal(dt.Rows[0]["ClosingStockCW"]);
                    }
                    if (!(dt.Rows[0]["ClosingStockUW"] is DBNull))
                    {
                        objModel.ClosingStockUW = Convert.ToDecimal(dt.Rows[0]["ClosingStockUW"]);
                    }
                    if (!(dt.Rows[0]["ClosingStockDW"] is DBNull))
                    {
                        objModel.ClosingStockDW = Convert.ToDecimal(dt.Rows[0]["ClosingStockDW"]);
                    }
                    objModel.Amount1 = Convert.ToString(dt.Rows[0]["Amount1"]);
                    objModel.Amount2 = Convert.ToString(dt.Rows[0]["Amount2"]);
                    objModel.Amount3 = Convert.ToString(dt.Rows[0]["Amount3"]);
                    objModel.Amount4 = Convert.ToString(dt.Rows[0]["Amount4"]);
                    objModel.Amount5 = Convert.ToString(dt.Rows[0]["Amount5"]);
                    objModel.Amount6 = Convert.ToString(dt.Rows[0]["Amount6"]);
                    objModel.Amount7 = Convert.ToString(dt.Rows[0]["Amount7"]);

                    objModel.Remarks1 = Convert.ToString(dt.Rows[0]["Remarks1"]);
                    objModel.Remarks2 = Convert.ToString(dt.Rows[0]["Remarks2"]);
                    objModel.Remarks3 = Convert.ToString(dt.Rows[0]["Remarks3"]);
                    objModel.Remarks4 = Convert.ToString(dt.Rows[0]["Remarks4"]);
                    objModel.Remarks5 = Convert.ToString(dt.Rows[0]["Remarks5"]);
                    objModel.Remarks6 = Convert.ToString(dt.Rows[0]["Remarks6"]);
                    objModel.Remarks7 = Convert.ToString(dt.Rows[0]["Remarks7"]);
                    objModel.TotalAmount = Convert.ToString(dt.Rows[0]["TotalAmount"]);

                    objModel.productionIncrDecResion = Convert.ToString(dt.Rows[0]["productionIncrDecResion"]);
                    objModel.ex_minepriceIncrDecResion = Convert.ToString(dt.Rows[0]["ex_minepriceIncrDecResion"]);
                    objModel.Averagecostofpulverization = Convert.ToDecimal(dt.Rows[0]["Averagecostofpulverization"]);
                    objModel.certify = Convert.ToBoolean(dt.Rows[0]["certify"]);
                    //----------------------------------
                    objModel.DistrictName = Convert.ToString(dt.Rows[0]["DistrictName"]);
                    objModel.Month_Year = Convert.ToString(dt.Rows[0]["Month_Year"]);
                    objModel.SubmitDate = Convert.ToString(dt.Rows[0]["SubmitDate"]);
                    objModel.DSCFilePath = Convert.ToString(dt.Rows[0]["DSCFilePath"]);
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
        /// Get details of mines work details for print
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of Working_of_Mine class</returns>
        public async Task<List<Working_of_Mine>> GetMineWorkDetails(MonthlyReturnModelNonCoal model)
        {
            List<Working_of_Mine> list = new List<Working_of_Mine>();
            try
            {
                var paramList = new
                {
                    Month_Year = model.MonthYear,
                    UserID = model.Uid,
                    Check = 3,
                };

                var result = await Connection.ExecuteReaderAsync("UspGetFormF1ForPrint", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Working_of_Mine objModel = new Working_of_Mine();
                        objModel.Work_Id = Convert.ToInt32(dt.Rows[i]["Work_Id"]);
                        objModel.NoOfDaysWorkStop = Convert.ToInt32(dt.Rows[i]["NoOfDaysWorkStop"]);
                        objModel.Reason = Convert.ToString(dt.Rows[i]["Reason"]);
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
                list = null;
                model = null;
            }
        }

        /// <summary>
        /// Update fole path for print
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> Update_Filepath(MonthlyReturnModelNonCoal objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("fileName", objModel.ServerPath);
                p.Add("ID", objModel.ID);
                p.Add("UpdateIn", objModel.UpdateIn);
                p.Add("UserId", objModel.Uid);
                p.Add("MonthYear", objModel.MonthYear);
                int response = await Connection.QueryFirstAsync<int>("UpdateDSCPath", p, commandType: CommandType.StoredProcedure);
                objMessage.Satus = response.ToString();
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
