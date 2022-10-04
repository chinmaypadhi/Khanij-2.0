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

namespace ReturnApi.Model.e_Return_NonCoal
{
    public class eReturnNonCoalForm2Provider : RepositoryBase, IeReturnNonCoalForm2Provider
    {
        public eReturnNonCoalForm2Provider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

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
        /// Get Return Submitted Details
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
                    FormType = "Form F2",
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
        /// Get Rent Royalty
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
                p.Add("FormType", "Form F2");
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
                p.Add("FormType", "Form F2");
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
        /// Add Recoveries
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddRecoveries(RecoveriesModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("Check", 1);
                p.Add("MineralId", objModel.MineralId2);
                p.Add("OS_qty", objModel.OS_qty);
                p.Add("OS_grade", objModel.OS_grade);
                p.Add("OreReceived_qty", objModel.OreReceived_qty);
                p.Add("OreReceived_grade", objModel.OreReceived_grade);
                p.Add("OreTreated_qty", objModel.OreTreated_qty);
                p.Add("OreTreated_grade", objModel.OreTreated_grade);
                p.Add("Concentrates_qty", objModel.Concentrates_qty);
                p.Add("Concentrates_grade", objModel.Concentrates_grade);
                p.Add("Concentrates_Value", objModel.Concentrates_Value);
                p.Add("Tailings_Qty", objModel.Tailings_Qty);
                p.Add("Tailing_grade", objModel.Tailing_grade);
                p.Add("CS_qty", objModel.CS_qty);
                p.Add("CS_grade", objModel.CS_grade);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("CreatedBy", objModel.UID);



                // int response = Connection.QueryFirst<int>("UspADDeReturnPartOne", p, commandType: CommandType.StoredProcedure);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_Recoveries", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
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
        /// Get Recoveries
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of RecoveriesModel</returns>
        public async Task<List<RecoveriesModel>> GetRecoveries(MonthlyReturnModelNonCoal model)
        {
            List<RecoveriesModel> list = new List<RecoveriesModel>();
            try
            {
                var paramList = new
                {
                    Month_Year = model.MonthYear,
                    UserID = model.Uid,
                    Check = 1,
                };
                var result = await Connection.ExecuteReaderAsync("USP_GetReturnF2PartTwo_Recoveries", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RecoveriesModel objModel = new RecoveriesModel();
                        objModel.Recoverie_Id = Convert.ToInt32(dt.Rows[i]["Recoverie_Id"]);
                        objModel.MineralId2 = Convert.ToInt32(dt.Rows[i]["MineralId"]);
                        objModel.MineralName = Convert.ToString(dt.Rows[i]["MineralName"]);
                        objModel.OS_qty = Convert.ToDecimal(dt.Rows[i]["OS_qty"]);
                        objModel.OS_grade = Convert.ToString(dt.Rows[i]["OS_grade"]);
                        objModel.OreReceived_qty = Convert.ToDecimal(dt.Rows[i]["OreReceived_qty"]);
                        objModel.OreReceived_grade = Convert.ToString(dt.Rows[i]["OreReceived_grade"]);
                        objModel.OreTreated_qty = Convert.ToDecimal(dt.Rows[i]["OreTreated_qty"]);
                        objModel.OreTreated_grade = Convert.ToString(dt.Rows[i]["OreTreated_grade"]);
                        objModel.Concentrates_qty = Convert.ToDecimal(dt.Rows[i]["Concentrates_qty"]);
                        objModel.Concentrates_grade = Convert.ToString(dt.Rows[i]["Concentrates_grade"]);
                        objModel.Concentrates_Value = Convert.ToDecimal(dt.Rows[i]["Concentrates_Value"]);
                        objModel.Tailings_Qty = Convert.ToDecimal(dt.Rows[i]["Tailings_Qty"]);
                        objModel.Tailing_grade = Convert.ToString(dt.Rows[i]["Tailing_grade"]);
                        objModel.CS_qty = Convert.ToDecimal(dt.Rows[i]["CS_qty"]);
                        objModel.CS_grade = Convert.ToString(dt.Rows[i]["CS_grade"]);
                        objModel.Month_Year = Convert.ToString(dt.Rows[i]["Month_Year"]);
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
        /// Update Recoveries Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateRecoveries(RecoveriesModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 2);
                p.Add("Recoverie_Id", objModel.Recoverie_Id);
                p.Add("MineralId", objModel.MineralId2);
                p.Add("OS_qty", objModel.OS_qty);
                p.Add("OS_grade", objModel.OS_grade);
                p.Add("OreReceived_qty", objModel.OreReceived_qty);
                p.Add("OreReceived_grade", objModel.OreReceived_grade);
                p.Add("OreTreated_qty", objModel.OreTreated_qty);
                p.Add("OreTreated_grade", objModel.OreTreated_grade);
                p.Add("Concentrates_qty", objModel.Concentrates_qty);
                p.Add("Concentrates_grade", objModel.Concentrates_grade);
                p.Add("Concentrates_Value", objModel.Concentrates_Value);
                p.Add("Tailings_Qty", objModel.Tailings_Qty);
                p.Add("Tailing_grade", objModel.Tailing_grade);
                p.Add("CS_qty", objModel.CS_qty);
                p.Add("CS_grade", objModel.CS_grade);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("CreatedBy", objModel.UID);

                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_Recoveries", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
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
        /// Delete REcoveries Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> DeleteRecoveries(RecoveriesModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Recoverie_Id", objModel.Recoverie_Id);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Check", 3);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_Recoveries", p, commandType: CommandType.StoredProcedure);
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
        /// Add Recoveries smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 1);
                p.Add("MineralId", objModel.MineralId3);
                p.Add("OS_qty", objModel.OS_qty);
                p.Add("OS_grade", objModel.OS_grade);
                p.Add("Concentratesreceived_qty", objModel.Concentratesreceived_qty);
                p.Add("Concentratesreceived_grade", objModel.Concentratesreceived_grade);
                p.Add("Concentrates_othersources_qty", objModel.Concentrates_othersources_qty);
                p.Add("Concentrates_othersources_grade", objModel.Concentrates_othersources_grade);
                p.Add("Concentrates_sold_qty", objModel.Concentrates_sold_qty);
                p.Add("Concentrates_sold_grade", objModel.Concentrates_sold_grade);
                p.Add("Concentrates_treated_qty", objModel.Concentrates_treated_qty);
                p.Add("Concentrates_treated_grade", objModel.Concentrates_treated_grade);
                p.Add("CS_qty", objModel.CS_qty);
                p.Add("CS_grade", objModel.CS_grade);
                p.Add("Metalsrecovered_qty", objModel.Metalsrecovered_qty);
                p.Add("Metalsrecovered_grade", objModel.Metalsrecovered_grade);
                p.Add("Metalsrecovered_Value", objModel.Metalsrecovered_Value);
                p.Add("Other_byproducts_qty", objModel.Other_byproducts_qty);
                p.Add("Other_byproducts_grade", objModel.Other_byproducts_grade);
                p.Add("Other_byproducts_Value", objModel.Other_byproducts_Value);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("CreatedBy", objModel.UID);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_Recovery_atSmelter", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
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
        /// Get Recoveries Smelter
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of Recovery_atSmelterModel class</returns>
        public async Task<List<Recovery_atSmelterModel>> GetRecoveriesSmelter(MonthlyReturnModelNonCoal model)
        {
            List<Recovery_atSmelterModel> list = new List<Recovery_atSmelterModel>();
            try
            {
                var paramList = new
                {
                    Month_Year = model.MonthYear,
                    UserID = model.Uid,
                    Check = 2,
                };
                var result = await Connection.ExecuteReaderAsync("USP_GetReturnF2PartTwo_Recoveries", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Recovery_atSmelterModel objModel = new Recovery_atSmelterModel();
                        objModel.Recovery_atSmelter_Id = Convert.ToInt32(dt.Rows[i]["Recovery_atSmelter_Id"]);
                        objModel.MineralId3 = Convert.ToInt32(dt.Rows[i]["MineralId"]);
                        objModel.MineralName = Convert.ToString(dt.Rows[i]["MineralName"]);
                        objModel.OS_qty = Convert.ToDecimal(dt.Rows[i]["OS_qty"]);
                        objModel.OS_grade = Convert.ToString(dt.Rows[i]["OS_grade"]);
                        objModel.Concentratesreceived_qty = Convert.ToDecimal(dt.Rows[i]["Concentratesreceived_qty"]);
                        objModel.Concentratesreceived_grade = Convert.ToString(dt.Rows[i]["Concentratesreceived_grade"]);
                        objModel.Concentrates_othersources_qty = Convert.ToDecimal(dt.Rows[i]["Concentrates_othersources_qty"]);
                        objModel.Concentrates_othersources_grade = Convert.ToString(dt.Rows[i]["Concentrates_othersources_grade"]);
                        objModel.Concentrates_sold_qty = Convert.ToDecimal(dt.Rows[i]["Concentrates_sold_qty"]);
                        objModel.Concentrates_sold_grade = Convert.ToString(dt.Rows[i]["Concentrates_sold_grade"]);
                        objModel.Concentrates_treated_qty = Convert.ToDecimal(dt.Rows[i]["Concentrates_treated_qty"]);
                        objModel.Concentrates_treated_grade = Convert.ToString(dt.Rows[i]["Concentrates_treated_grade"]);
                        objModel.CS_qty = Convert.ToDecimal(dt.Rows[i]["CS_qty"]);
                        objModel.CS_grade = Convert.ToString(dt.Rows[i]["CS_grade"]);
                        objModel.Metalsrecovered_qty = Convert.ToDecimal(dt.Rows[i]["Metalsrecovered_qty"]);
                        objModel.Metalsrecovered_grade = Convert.ToString(dt.Rows[i]["Metalsrecovered_grade"]);
                        objModel.Metalsrecovered_Value = Convert.ToDecimal(dt.Rows[i]["Metalsrecovered_Value"]);
                        objModel.Other_byproducts_qty = Convert.ToDecimal(dt.Rows[i]["Other_byproducts_qty"]);
                        objModel.Other_byproducts_grade = Convert.ToString(dt.Rows[i]["Other_byproducts_grade"]);
                        objModel.Other_byproducts_Value = Convert.ToDecimal(dt.Rows[i]["Other_byproducts_Value"]);
                        objModel.Month_Year = Convert.ToString(dt.Rows[i]["Month_Year"]);
                        objModel.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
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
        /// Update Recoveries Smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("Check", 2);
                p.Add("Recovery_atSmelter_Id", objModel.Recovery_atSmelter_Id);
                p.Add("MineralId", objModel.MineralId3);
                p.Add("OS_qty", objModel.OS_qty);
                p.Add("OS_grade", objModel.OS_grade);
                p.Add("Concentratesreceived_qty", objModel.Concentratesreceived_qty);
                p.Add("Concentratesreceived_grade", objModel.Concentratesreceived_grade);
                p.Add("Concentrates_othersources_qty", objModel.Concentrates_othersources_qty);
                p.Add("Concentrates_othersources_grade", objModel.Concentrates_othersources_grade);
                p.Add("Concentrates_sold_qty", objModel.Concentrates_sold_qty);
                p.Add("Concentrates_sold_grade", objModel.Concentrates_sold_grade);
                p.Add("Concentrates_treated_qty", objModel.Concentrates_treated_qty);
                p.Add("Concentrates_treated_grade", objModel.Concentrates_treated_grade);
                p.Add("CS_qty", objModel.CS_qty);
                p.Add("CS_grade", objModel.CS_grade);
                p.Add("Metalsrecovered_qty", objModel.Metalsrecovered_qty);
                p.Add("Metalsrecovered_grade", objModel.Metalsrecovered_grade);
                p.Add("Metalsrecovered_Value", objModel.Metalsrecovered_Value);
                p.Add("Other_byproducts_qty", objModel.Other_byproducts_qty);
                p.Add("Other_byproducts_grade", objModel.Other_byproducts_grade);
                p.Add("Other_byproducts_Value", objModel.Other_byproducts_Value);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_Recovery_atSmelter", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
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
        /// Delete Recoveries at smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> DeleteRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Recovery_atSmelter_Id", objModel.Recovery_atSmelter_Id);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Check", 3);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_Recovery_atSmelter", p, commandType: CommandType.StoredProcedure);
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
        /// Get Mineral Grade for Tin
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List Recovery_atSmelterModel class</returns>
        public async Task<List<Recovery_atSmelterModel>> GetMineralGradeForTinMineral(MonthlyReturnModelNonCoal model)
        {
            List<Recovery_atSmelterModel> list = new List<Recovery_atSmelterModel>();
            try
            {
                var paramList = new
                {
                    UserId = model.Uid,
                    Check = 6,
                };

                var result = await Connection.ExecuteReaderAsync("UspGetMineralForE_Return", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Recovery_atSmelterModel objModel = new Recovery_atSmelterModel();
                        objModel.MineralId3 = Convert.ToInt32(dt.Rows[i]["MineralGradeID"]);
                        objModel.MineralName = Convert.ToString(dt.Rows[i]["MineralGrade"]);
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
        /// Add Sale Product Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddSaleProduct(SaleProductModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("Check", 1);
                p.Add("MineralId", objModel.MineralId);
                p.Add("Product", objModel.Product);
                p.Add("OS_Qty", objModel.OS_Qty);
                p.Add("OS_Grade", objModel.OS_Grade);
                p.Add("PlaceOfSale", objModel.PlaceOfSale);
                p.Add("Sold_Qty", objModel.Sold_Qty);
                p.Add("Sold_Grade", objModel.Sold_Grade);
                p.Add("Sold_Value", objModel.Sold_Value);
                p.Add("CS_Qty", objModel.CS_Qty);
                p.Add("CS_Grade", objModel.CS_Grade);
                p.Add("TinContent", objModel.TinContent);
                p.Add("AluminaContent", objModel.AluminaContent);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("CreatedBy", objModel.UID);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_SaleProduct", p, commandType: CommandType.StoredProcedure);
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
        /// Get Sale Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of SaleProductModel class</returns>
        public async Task<List<SaleProductModel>> GetSaleProduct(MonthlyReturnModelNonCoal model)
        {
            List<SaleProductModel> list = new List<SaleProductModel>();
            try
            {
                var paramList = new
                {
                    Month_Year = model.MonthYear,
                    UserID = model.Uid,
                    Check = 3,
                };


                var result = await Connection.ExecuteReaderAsync("USP_GetReturnF2PartTwo_Recoveries", paramList, commandType: System.Data.CommandType.StoredProcedure);



                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SaleProductModel objModel = new SaleProductModel();
                        objModel.SaleProductId = Convert.ToInt32(dt.Rows[i]["SaleProductId"]);
                        objModel.MineralId6 = Convert.ToInt32(dt.Rows[i]["MineralId"]);
                        objModel.MineralName = Convert.ToString(dt.Rows[i]["MineralName"]);
                        objModel.Product = Convert.ToString(dt.Rows[i]["Product"]);
                        objModel.OS_Qty = Convert.ToString(dt.Rows[i]["OS_Qty"]);
                        objModel.OS_Grade = Convert.ToString(dt.Rows[i]["OS_Grade"]);
                        objModel.PlaceOfSale = Convert.ToString(dt.Rows[i]["PlaceOfSale"]);
                        objModel.Sold_Qty = Convert.ToString(dt.Rows[i]["Sold_Qty"]);
                        objModel.Sold_Grade = Convert.ToString(dt.Rows[i]["Sold_Grade"]);
                        objModel.Sold_Value = Convert.ToString(dt.Rows[i]["Sold_Value"]);
                        objModel.CS_Qty = Convert.ToString(dt.Rows[i]["CS_Qty"]);
                        objModel.CS_Grade = Convert.ToString(dt.Rows[i]["CS_Grade"]);
                        objModel.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                        objModel.Month_Year = Convert.ToString(dt.Rows[i]["Month_Year"]);
                        objModel.MineralGradeId6 = Convert.ToInt32(dt.Rows[i]["MineralGradeId"]);

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
        /// Update Sale Product
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateSaleProduct(SaleProductModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("Check", 2);
                p.Add("SaleProductId", objModel.SaleProductId);
                p.Add("MineralId", objModel.MineralId);
                p.Add("Product", objModel.Product);
                p.Add("OS_Qty", objModel.OS_Qty);
                p.Add("OS_Grade", objModel.OS_Grade);
                p.Add("PlaceOfSale", objModel.PlaceOfSale);
                p.Add("Sold_Qty", objModel.Sold_Qty);
                p.Add("Sold_Grade", objModel.Sold_Grade);
                p.Add("Sold_Value", objModel.Sold_Value);
                p.Add("CS_Qty", objModel.CS_Qty);
                p.Add("CS_Grade", objModel.CS_Grade);
                p.Add("TinContent", objModel.TinContent);
                p.Add("AluminaContent", objModel.AluminaContent);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_SaleProduct", p, commandType: CommandType.StoredProcedure);
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
        /// Delete Sale Product
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> DeleteSaleProduct(SaleProductModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("SaleProductId", objModel.SaleProductId);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Check", 3);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_SaleProduct", p, commandType: CommandType.StoredProcedure);
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
        /// Get Mineral Form Production
        /// </summary>
        /// <param name="ObjMR"></param>
        /// <returns>List of SalesDispatchOf_OreModel Class</returns>
        public async Task<List<SalesDispatchOf_OreModel>> GetMineralFormProduction(MonthlyReturnModelNonCoal ObjMR)
        {
            List<SalesDispatchOf_OreModel> list = new List<SalesDispatchOf_OreModel>();

            try
            {
                var paramList = new
                {
                    MineralId = ObjMR.MineralId,
                    UserId = ObjMR.Uid,
                    Check = 1,
                };

                var result = await Connection.ExecuteReaderAsync("UspGetMineralForE_Return", paramList, commandType: System.Data.CommandType.StoredProcedure);


                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SalesDispatchOf_OreModel objModel = new SalesDispatchOf_OreModel();
                        objModel.MineralNatureId = Convert.ToInt32(dt.Rows[i]["MineralNatureId"]);
                        objModel.MineralNature = Convert.ToString(dt.Rows[i]["MineralNature"]);
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
                ObjMR = null;
            }

        }

        /// <summary>
        /// Get Nature of Dispatch
        /// </summary>
        /// <param name="ObjMR"></param>
        /// <returns>List of SalesDispatchModel class</returns>
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
        /// <returns>List of SalesDispatchModel class</returns>
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
        /// Add Sale Dispatch
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 1);
                p.Add("MineralId", objModel.MineralId9);
                p.Add("MineralNatureId", objModel.MineralNatureId);
                p.Add("MineralGradeId", objModel.MineralGradeId);
                p.Add("MineralGrade", objModel.MineralGrade);
                p.Add("NatureOfDispatch", objModel.NatureofDispatch);
                p.Add("RegistrationNo", objModel.RegistrationNo);
                p.Add("PurchaserConsinee", objModel.PurchaserConsinee);
                p.Add("DomesticPurpose_Quantity", objModel.DomesticPurposes_Quantity);
                p.Add("SaleValue", objModel.SaleValue);
                p.Add("Country", objModel.Country);
                p.Add("Export_Quantity", objModel.Export_Quantity);
                p.Add("FOBValue", objModel.FOBValue);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("CreatedBy", objModel.UID);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_SalesDispatch", p, commandType: CommandType.StoredProcedure);
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
        /// <returns>List of SalesDispatchOf_OreModel class</returns>
        public async Task<List<SalesDispatchOf_OreModel>> GetSaleDispatch(MonthlyReturnModelNonCoal model)
        {
            List<SalesDispatchOf_OreModel> list = new List<SalesDispatchOf_OreModel>();
            try
            {
                var paramList = new
                {
                    Month_Year = model.MonthYear,
                    UserID = model.Uid,
                    Check = 4,
                };
                var result = await Connection.ExecuteReaderAsync("USP_GetReturnF2PartTwo_Recoveries", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SalesDispatchOf_OreModel objModel = new SalesDispatchOf_OreModel();
                        objModel.Sale_Dispatch_Id = Convert.ToInt32(dt.Rows[i]["Sale_Dispatch_Id"]);
                        objModel.MineralId9 = Convert.ToInt32(dt.Rows[i]["MineralId"] == DBNull.Value ? 0 : dt.Rows[i]["MineralId"]);
                        objModel.MineralName = Convert.ToString(dt.Rows[i]["MineralName"]);
                        objModel.MineralNatureId = Convert.ToInt32(dt.Rows[i]["MineralNatureId"]);
                        objModel.MineralNature = Convert.ToString(dt.Rows[i]["MineralNature"]);
                        objModel.MineralGradeId = Convert.ToInt32(dt.Rows[i]["MineralGradeId"]);
                        objModel.MineralGrade = Convert.ToString(dt.Rows[i]["MineralGrade"]);
                        objModel.NatureofDispatch = Convert.ToString(dt.Rows[i]["NatureofDispatch"]);
                        objModel.RegistrationNo = Convert.ToString(dt.Rows[i]["RegistrationNo"]);
                        objModel.PurchaserConsinee = Convert.ToString(dt.Rows[i]["PurchaserConsinee"]);
                        objModel.DomesticPurposes_Quantity = Convert.ToDecimal(dt.Rows[i]["DomesticPurposes_Quantity"]);
                        objModel.SaleValue = Convert.ToDecimal(dt.Rows[i]["SaleValue"]);
                        objModel.Country = Convert.ToString(dt.Rows[i]["Country"]);
                        objModel.Export_Quantity = Convert.ToDecimal(dt.Rows[i]["Export_Quantity"]);
                        objModel.FOBValue = Convert.ToString(dt.Rows[i]["FOBValue"]);
                        objModel.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                        objModel.Month_Year = Convert.ToString(dt.Rows[i]["Month_Year"]);
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
        /// Update Sale Dispatch
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 2);
                p.Add("Sale_Dispatch_Id", objModel.Sale_Dispatch_Id);
                p.Add("MineralId", objModel.MineralId9);
                p.Add("MineralNatureId", objModel.MineralNatureId);
                p.Add("MineralGradeId", objModel.MineralGradeId);
                p.Add("MineralGrade", objModel.MineralGrade);
                p.Add("NatureOfDispatch", objModel.NatureofDispatch);
                p.Add("RegistrationNo", objModel.RegistrationNo);
                p.Add("PurchaserConsinee", objModel.PurchaserConsinee);
                p.Add("DomesticPurpose_Quantity", objModel.DomesticPurposes_Quantity);
                p.Add("SaleValue", objModel.SaleValue);
                p.Add("Country", objModel.Country);
                p.Add("Export_Quantity", objModel.Export_Quantity);
                p.Add("FOBValue", objModel.FOBValue);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_SalesDispatch", p, commandType: CommandType.StoredProcedure);
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
        public async Task<MessageEF> DeleteSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Sale_Dispatch_Id", objModel.Sale_Dispatch_Id);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Check", 3);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_SalesDispatch", p, commandType: CommandType.StoredProcedure);
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
        /// Add Reason
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddReasonForInDc(Reason_Inc_Dec_Monthly_FormF2 objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("MineralId", objModel.MineralId);
                p.Add("productionIncrDecResion", objModel.productionIncrDecResion);
                p.Add("ex_minepriceIncrDecResion", objModel.ex_minepriceIncrDecResion);
                p.Add("certify", objModel.certify);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("CreatedBy", objModel.UID);
                p.Add("Check", 1);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo__Reason_Inc_Dec", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
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
        /// Update Reason
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateReasonForInDc(Reason_Inc_Dec_Monthly_FormF2 objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("MineralId", objModel.MineralId);
                p.Add("Reason_Inc_Dec_Id", objModel.Reason_Inc_Dec_Id);
                p.Add("productionIncrDecResion", objModel.productionIncrDecResion);
                p.Add("ex_minepriceIncrDecResion", objModel.ex_minepriceIncrDecResion);
                p.Add("certify", objModel.certify);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Check", 2);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo__Reason_Inc_Dec", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
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
        /// Get Production Stock Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>ProductionandStocksModel class</returns>
        public async Task<ProductionandStocksModel> GetProductionandStocks(MonthlyReturnModelNonCoal model)
        {
            ProductionandStocksModel objModel = new ProductionandStocksModel();
            try
            {
                var paramList = new
                {
                    Month_Year = model.MonthYear,
                    UserID = model.Uid,
                    Check = 1,
                };

                var result = await Connection.ExecuteReaderAsync("USP_GetReturnF2PartTwo_ProductionandStocks", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        objModel.MineralId1 = Convert.ToInt32(dt.Rows[0]["MineralId"]);
                        objModel.ProductionandStocks_Id = Convert.ToInt32(dt.Rows[0]["ProductionandStocks_Id"]);

                        if (dt.Rows[0]["Development_OS_Qty"].ToString() != "")
                        {
                            objModel.Development_OS_Qty = Convert.ToDecimal(dt.Rows[0]["Development_OS_Qty"]);
                        }

                        objModel.Development_OS_grade = Convert.ToString(dt.Rows[0]["Development_OS_grade"]);

                        if (dt.Rows[0]["Development_Production_Qty"].ToString() != "")
                        {
                            objModel.Development_Production_Qty = Convert.ToDecimal(dt.Rows[0]["Development_Production_Qty"]);
                        }

                        objModel.Development_Production_grade = Convert.ToString(dt.Rows[0]["Development_Production_grade"]);
                        objModel.Development_CS_Qty = Convert.ToDecimal(dt.Rows[0]["Development_CS_Qty"]);
                        objModel.Development_CS_grade = Convert.ToString(dt.Rows[0]["Development_CS_grade"]);

                        if (dt.Rows[0]["Stoping_OS_Qty"].ToString() != "")
                        {
                            objModel.Stoping_OS_Qty = Convert.ToDecimal(dt.Rows[0]["Stoping_OS_Qty"]);
                        }


                        objModel.Stoping_OS_grade = Convert.ToString(dt.Rows[0]["Stoping_OS_grade"]);

                        if (dt.Rows[0]["Stoping_Production_Qty"].ToString() != "")
                        {
                            objModel.Stoping_Production_Qty = Convert.ToDecimal(dt.Rows[0]["Stoping_Production_Qty"]);
                        }

                        objModel.Stoping_Production_grade = Convert.ToString(dt.Rows[0]["Stoping_Production_grade"]);
                        objModel.Stoping_CS_Qty = Convert.ToDecimal(dt.Rows[0]["Stoping_CS_Qty"]);
                        objModel.Stoping_CS_grade = Convert.ToString(dt.Rows[0]["Stoping_CS_grade"]);

                        if (dt.Rows[0]["OpenCastWork_OS_Qty"].ToString() != "")
                        {
                            objModel.OpenCastWork_OS_Qty = Convert.ToDecimal(dt.Rows[0]["OpenCastWork_OS_Qty"]);
                        }

                        objModel.OpenCastWork_OS_grade = Convert.ToString(dt.Rows[0]["OpenCastWork_OS_grade"]);

                        if (dt.Rows[0]["OpenCastWork_Production_Qty"].ToString() != "")
                        {
                            objModel.OpenCastWork_Production_Qty = Convert.ToDecimal(dt.Rows[0]["OpenCastWork_Production_Qty"]);
                        }

                        objModel.OpenCastWork_Production_grade = Convert.ToString(dt.Rows[0]["OpenCastWork_Production_grade"]);
                        objModel.OpenCastWork_CS_Qty = Convert.ToDecimal(dt.Rows[0]["OpenCastWork_CS_Qty"]);
                        objModel.OpenCastWork_CS_grade = Convert.ToString(dt.Rows[0]["OpenCastWork_CS_grade"]);
                        objModel.Total_OS_Qty = Convert.ToDecimal(dt.Rows[0]["Total_OS_Qty"]);
                        objModel.Total_Production_Qty = Convert.ToDecimal(dt.Rows[0]["Total_Production_Qty"]);
                        objModel.Total_CS_Qty = Convert.ToDecimal(dt.Rows[0]["Total_CS_Qty"]);
                        objModel.ExMinePrice = Convert.ToDecimal(dt.Rows[0]["ExMinePrice"]);
                        objModel.Month_Year = Convert.ToString(dt.Rows[0]["MonthYear"]);

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
        /// Get Details Of Deduction
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Details_of_deductions_sale_computation class</returns>
        public async Task<Details_of_deductions_sale_computation> GetDetails_of_deductions(MonthlyReturnModelNonCoal model)
        {
            Details_of_deductions_sale_computation objModel = new Details_of_deductions_sale_computation();
            try
            {
                var paramList = new
                {
                    Month_Year = model.MonthYear,
                    MineralId = model.MineralId,
                    UserID = model.Uid,
                    Check = 2,
                };
                var result = await Connection.ExecuteReaderAsync("USP_GetReturnF2PartTwo_ProductionandStocks", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
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

                        objModel.CExMineSale = Convert.ToString(dt.Rows[0]["CExMineSale"]);
                        objModel.ex_mineSale = Convert.ToString(dt.Rows[0]["ExMineSale"]);

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
        /// Get Reason
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Reason_Inc_Dec_Monthly_FormF2 class</returns>
        public async Task<Reason_Inc_Dec_Monthly_FormF2> GetReason_Inc_Dec(MonthlyReturnModelNonCoal model)
        {
            Reason_Inc_Dec_Monthly_FormF2 objModel = new Reason_Inc_Dec_Monthly_FormF2();
            try
            {
                var paramList = new
                {
                    Month_Year = model.MonthYear,
                    MineralId = model.MineralId,
                    UserID = model.Uid,
                    Check = 5,
                };


                var result = await Connection.ExecuteReaderAsync("USP_GetReturnF2PartTwo_Recoveries", paramList, commandType: System.Data.CommandType.StoredProcedure);



                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objModel.Reason_Inc_Dec_Id = Convert.ToInt32(dt.Rows[0]["Reason_Inc_Dec_Id"]);
                        objModel.productionIncrDecResion = Convert.ToString(dt.Rows[0]["productionIncrDecResion"]);
                        objModel.ex_minepriceIncrDecResion = Convert.ToString(dt.Rows[0]["ex_minepriceIncrDecResion"]);
                        objModel.certify = Convert.ToBoolean(dt.Rows[0]["certify"]);

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
        /// Add Production and Syocks
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddProductionandStocks(ProductionandStocksModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("MineralId", objModel.MineralId1);
                p.Add("Development_OS_Qty", objModel.Development_OS_Qty);
                p.Add("Development_OS_grade", objModel.Development_OS_grade);
                p.Add("Development_Production_Qty", objModel.Development_Production_Qty);
                p.Add("Development_Production_grade", objModel.Development_Production_grade);
                p.Add("Development_CS_Qty", objModel.Development_CS_Qty);
                p.Add("Development_CS_grade", objModel.Development_CS_grade);
                p.Add("Stoping_OS_Qty", objModel.Stoping_OS_Qty);
                p.Add("Stoping_OS_grade", objModel.Stoping_OS_grade);
                p.Add("Stoping_Production_Qty", objModel.Stoping_Production_Qty);
                p.Add("Stoping_Production_grade", objModel.Stoping_Production_grade);
                p.Add("Stoping_CS_Qty", objModel.Stoping_CS_Qty);
                p.Add("Stoping_CS_grade", objModel.Stoping_CS_grade);
                p.Add("OpenCastWork_OS_Qty", objModel.OpenCastWork_OS_Qty);
                p.Add("OpenCastWork_OS_grade", objModel.OpenCastWork_OS_grade);
                p.Add("OpenCastWork_Production_Qty", objModel.OpenCastWork_Production_Qty);
                p.Add("OpenCastWork_Production_grade", objModel.OpenCastWork_Production_grade);
                p.Add("OpenCastWork_CS_Qty", objModel.OpenCastWork_CS_Qty);
                p.Add("OpenCastWork_CS_grade", objModel.OpenCastWork_CS_grade);
                p.Add("Total_OS_Qty", objModel.Total_OS_Qty);
                p.Add("Total_OS_grade", objModel.Total_OS_grade);
                p.Add("Total_Production_Qty", objModel.Total_Production_Qty);
                p.Add("Total_Production_grade", objModel.Total_Production_grade);
                p.Add("Total_CS_Qty", objModel.Total_CS_Qty);
                p.Add("Total_CS_grade", objModel.Total_CS_grade);
                p.Add("ExMinePrice", objModel.ExMinePrice);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("CreatedBy", objModel.UID);
                p.Add("Check", 1);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_ProductionandStocks", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
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
        /// Update production and stocks
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateProductionandStocks(ProductionandStocksModel objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("ProductionandStocks_Id", objModel.ProductionandStocks_Id);
                p.Add("MineralId", objModel.MineralId1);
                p.Add("Development_OS_Qty", objModel.Development_OS_Qty);
                p.Add("Development_OS_grade", objModel.Development_OS_grade);
                p.Add("Development_Production_Qty", objModel.Development_Production_Qty);
                p.Add("Development_Production_grade", objModel.Development_Production_grade);
                p.Add("Development_CS_Qty", objModel.Development_CS_Qty);
                p.Add("Development_CS_grade", objModel.Development_CS_grade);
                p.Add("Stoping_OS_Qty", objModel.Stoping_OS_Qty);
                p.Add("Stoping_OS_grade", objModel.Stoping_OS_grade);
                p.Add("Stoping_Production_Qty", objModel.Stoping_Production_Qty);
                p.Add("Stoping_Production_grade", objModel.Stoping_Production_grade);
                p.Add("Stoping_CS_Qty", objModel.Stoping_CS_Qty);
                p.Add("Stoping_CS_grade", objModel.Stoping_CS_grade);
                p.Add("OpenCastWork_OS_Qty", objModel.OpenCastWork_OS_Qty);
                p.Add("OpenCastWork_OS_grade", objModel.OpenCastWork_OS_grade);
                p.Add("OpenCastWork_Production_Qty", objModel.OpenCastWork_Production_Qty);
                p.Add("OpenCastWork_Production_grade", objModel.OpenCastWork_Production_grade);
                p.Add("OpenCastWork_CS_Qty", objModel.OpenCastWork_CS_Qty);
                p.Add("OpenCastWork_CS_grade", objModel.OpenCastWork_CS_grade);
                p.Add("Total_OS_Qty", objModel.Total_OS_Qty);
                p.Add("Total_OS_grade", objModel.Total_OS_grade);
                p.Add("Total_Production_Qty", objModel.Total_Production_Qty);
                p.Add("Total_Production_grade", objModel.Total_Production_grade);
                p.Add("Total_CS_Qty", objModel.Total_CS_Qty);
                p.Add("Total_CS_grade", objModel.Total_CS_grade);
                p.Add("ExMinePrice", objModel.ExMinePrice);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Check", 2);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_ProductionandStocks", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
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
        /// Add Details of Deduction
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddDetails_of_deductions(Details_of_deductions_sale_computation objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("MineralId", objModel.MineralId8);
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
                p.Add("CExMineSale", objModel.CExMineSale);
                p.Add("ExMineSale", objModel.ex_mineSale);

                p.Add("CreatedBy", objModel.UID);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("Check", 1);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_Detailsofdeductions", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
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
        /// Update Details of deduction
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> UpdateDetails_of_deductions(Details_of_deductions_sale_computation objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("MineralId", objModel.MineralId8);
                p.Add("DeductionMade_Id", objModel.DeductionMade_Id);
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
                p.Add("CExMineSale", objModel.CExMineSale);
                p.Add("ExMineSale", objModel.ex_mineSale);
                p.Add("ModifiedBy", objModel.UID);
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("Check", 2);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo_Detailsofdeductions", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
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
        /// Update final Submit
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> Update_FinalSubmit(Reason_Inc_Dec_Monthly_FormF2 objModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Month_Year", objModel.Month_Year);
                p.Add("CreatedBy", objModel.UID);
                p.Add("Check", 3);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_ReturnF2PartTwo__Reason_Inc_Dec", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                objMessage.Satus = response;
                if (response == "2")
                {
                    objMessage.Msg = "Monthly Return has not Submited";
                }
                else if (response == "1")
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
        /// Get Form2 for Print
        /// </summary>
        /// <param name="model"></param>
        /// <returns>LesseeFormF2Part1Model class</returns>
        public async Task<LesseeFormF2Part1Model> GetFormF2ForPrint(MonthlyReturnModelNonCoal model)
        {
            LesseeFormF2Part1Model objModel = new LesseeFormF2Part1Model();
            try
            {
                var paramList = new
                {
                    Month_Year = model.MonthYear,
                    FormType = "Form F2",
                    UserID = model.Uid,
                    Check = 1,
                };

                var result = await Connection.ExecuteReaderAsync("UspGetFormF2ForPrintPreview", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    objModel.Month_Year = Convert.ToString(dt.Rows[0]["Month_Year"]);
                    objModel.Registrationnumber = Convert.ToString(dt.Rows[0]["Registrationnumber"]);
                    objModel.MINE_CODE = Convert.ToString(dt.Rows[0]["MINE_CODE"]);
                    objModel.MineralName = Convert.ToString(dt.Rows[0]["MineralName"]);
                    objModel.OtherMineral = Convert.ToString(dt.Rows[0]["OtherMineral"]);
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
                    objModel.Details_Id = Convert.ToInt32(dt.Rows[0]["Details_Id"]);
                    objModel.Wages_Id = Convert.ToInt32(dt.Rows[0]["Wages_Id"]);
                    objModel.Rentpaid = Convert.ToDecimal(dt.Rows[0]["Rent_paid"]);
                    objModel.Royaltypaid = Convert.ToDecimal(dt.Rows[0]["Royalty_paid"]);
                    objModel.DeadRentpaid = Convert.ToDecimal(dt.Rows[0]["Dead_Rent_paid"]);
                    objModel.DMFPaid = Convert.ToDecimal(dt.Rows[0]["DMF"]);
                    objModel.NMETPaid = Convert.ToDecimal(dt.Rows[0]["NMET"]);
                    objModel.NoOfDaysMineWork = Convert.ToString(dt.Rows[0]["NoOfDaysMineWork"]);
                    objModel.NoOfDaysWorkStop = Convert.ToString(dt.Rows[0]["NoOfDaysWorkStop"]);
                    objModel.Reason = Convert.ToString(dt.Rows[0]["Reason"]);


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

                    objModel.Development_OS_Qty = Convert.ToDecimal(dt.Rows[0]["Development_OS_Qty"]);
                    objModel.Development_OS_grade = Convert.ToString(dt.Rows[0]["Development_OS_grade"]);
                    objModel.Development_Production_Qty = Convert.ToDecimal(dt.Rows[0]["Development_Production_Qty"]);
                    objModel.Development_Production_grade = Convert.ToString(dt.Rows[0]["Development_Production_grade"]);

                    objModel.Development_CS_Qty = Convert.ToDecimal(dt.Rows[0]["Development_CS_Qty"]);
                    objModel.Development_CS_grade = Convert.ToString(dt.Rows[0]["Development_CS_grade"]);
                    objModel.Stoping_OS_Qty = Convert.ToDecimal(dt.Rows[0]["Stoping_OS_Qty"]);

                    objModel.Stoping_OS_grade = Convert.ToString(dt.Rows[0]["Stoping_OS_grade"]);
                    objModel.Stoping_Production_Qty = Convert.ToDecimal(dt.Rows[0]["Stoping_Production_Qty"]);
                    objModel.Stoping_Production_grade = Convert.ToString(dt.Rows[0]["Stoping_Production_grade"]);

                    objModel.Stoping_CS_Qty = Convert.ToDecimal(dt.Rows[0]["Stoping_CS_Qty"]);
                    objModel.Stoping_CS_grade = Convert.ToString(dt.Rows[0]["Stoping_CS_grade"]);
                    objModel.OpenCastWork_OS_Qty = Convert.ToDecimal(dt.Rows[0]["OpenCastWork_OS_Qty"]);
                    objModel.OpenCastWork_OS_grade = Convert.ToString(dt.Rows[0]["OpenCastWork_OS_grade"]);
                    objModel.OpenCastWork_Production_Qty = Convert.ToDecimal(dt.Rows[0]["OpenCastWork_Production_Qty"]);
                    objModel.OpenCastWork_Production_grade = Convert.ToString(dt.Rows[0]["OpenCastWork_Production_grade"]);
                    objModel.OpenCastWork_CS_Qty = Convert.ToDecimal(dt.Rows[0]["OpenCastWork_CS_Qty"]);
                    objModel.OpenCastWork_CS_grade = Convert.ToString(dt.Rows[0]["OpenCastWork_CS_grade"]);
                    objModel.Total_OS_Qty = Convert.ToDecimal(dt.Rows[0]["Total_OS_Qty"]);
                    objModel.Total_CS_Qty = Convert.ToDecimal(dt.Rows[0]["Total_CS_Qty"]);
                    objModel.Total_Production_Qty = Convert.ToDecimal(dt.Rows[0]["Total_Production_Qty"]);
                    objModel.ExMinePrice = Convert.ToDecimal(dt.Rows[0]["ExMinePrice"]);

                    objModel.Deduction_claimedType7 = Convert.ToString(dt.Rows[0]["Deduction_claimedType7"]);
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
        /// Get Mine Work Details
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
                var result =await Connection.ExecuteReaderAsync("UspGetFormF1ForPrint", paramList, commandType: System.Data.CommandType.StoredProcedure);
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

                model = null;
                list = null;
            }
        }

        /// <summary>
        /// Get Recoveries Concentrator for print
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of RecoveriesModel class</returns>
        public async Task<List<RecoveriesModel>> GetRecoveries_ConcentratorForPrint(MonthlyReturnModelNonCoal model)
        {
            List<RecoveriesModel> list = new List<RecoveriesModel>();
            try
            {
                var paramList = new
                {
                    Month_Year = model.MonthYear,
                    UserID = model.Uid,
                    Check = 1,
                };
                var result =await Connection.ExecuteReaderAsync("USP_GetReturnF2PartTwo_Recoveries", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RecoveriesModel objModel = new RecoveriesModel();
                        objModel.Recoverie_Id = Convert.ToInt32(dt.Rows[i]["Recoverie_Id"]);
                        objModel.MineralId2 = Convert.ToInt32(dt.Rows[i]["MineralId"]);
                        objModel.MineralName = Convert.ToString(dt.Rows[i]["MineralName"]);
                        objModel.OS_qty = Convert.ToDecimal(dt.Rows[i]["OS_qty"]);
                        objModel.OS_grade = Convert.ToString(dt.Rows[i]["OS_grade"]);
                        objModel.OreReceived_qty = Convert.ToDecimal(dt.Rows[i]["OreReceived_qty"]);
                        objModel.OreReceived_grade = Convert.ToString(dt.Rows[i]["OreReceived_grade"]);
                        objModel.OreTreated_qty = Convert.ToDecimal(dt.Rows[i]["OreTreated_qty"]);
                        objModel.OreTreated_grade = Convert.ToString(dt.Rows[i]["OreTreated_grade"]);
                        objModel.Concentrates_qty = Convert.ToDecimal(dt.Rows[i]["Concentrates_qty"]);
                        objModel.Concentrates_grade = Convert.ToString(dt.Rows[i]["Concentrates_grade"]);
                        objModel.Concentrates_Value = Convert.ToDecimal(dt.Rows[i]["Concentrates_Value"]);
                        objModel.Tailings_Qty = Convert.ToDecimal(dt.Rows[i]["Tailings_Qty"]);
                        objModel.Tailing_grade = Convert.ToString(dt.Rows[i]["Tailing_grade"]);
                        objModel.CS_qty = Convert.ToDecimal(dt.Rows[i]["CS_qty"]);
                        objModel.CS_grade = Convert.ToString(dt.Rows[i]["CS_grade"]);
                        objModel.Month_Year = Convert.ToString(dt.Rows[i]["Month_Year"]);
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
        /// Upload file path For Print
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
                int response =await Connection.QueryFirstAsync<int>("UpdateDSCPath", p, commandType: CommandType.StoredProcedure);
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
