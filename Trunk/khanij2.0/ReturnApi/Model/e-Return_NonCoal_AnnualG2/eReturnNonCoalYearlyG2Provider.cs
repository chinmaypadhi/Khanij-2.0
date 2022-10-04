using Dapper;
using ReturnApi.Factory;
using ReturnApi.Repository;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Model.e_Return_NonCoal_AnnualG2
{
    public class eReturnNonCoalYearlyG2Provider : RepositoryBase, IeReturnNonCoalYearlyG2Provider
    {
        public eReturnNonCoalYearlyG2Provider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }


        #region Yearly Return Non Coal Details
        /// <summary>
        /// To Bind Yearly Return Non Coal Details
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
                var result =await Connection.QueryAsync<YearlyReturnModel>("GetDetailsofMonthlyReturn", param, commandType: System.Data.CommandType.StoredProcedure);

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

        #region Part One
        #region Lessee Mine Details
        /// <summary>
        /// To Bind Lessee Mine Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<MineDetailsModel> GetLesseMineDeatils(YearlyReturnModel yearlyReturnModel)
        {
            MineDetailsModel mineDetailsModel = new MineDetailsModel();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<MineDetailsModel>("UspGetForm_F1_Details", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    mineDetailsModel = result.FirstOrDefault();
                    if (string.IsNullOrEmpty(mineDetailsModel.OtherMineral))
                        mineDetailsModel.OtherMineral = "N/A";
                    if (string.IsNullOrEmpty(mineDetailsModel.MineName))
                        mineDetailsModel.MineName = "N/A";
                    if (string.IsNullOrEmpty(mineDetailsModel.MinePostOffice))
                        mineDetailsModel.MinePostOffice = "N/A";
                    if (string.IsNullOrEmpty(mineDetailsModel.MineFaxNo))
                        mineDetailsModel.MineFaxNo = "N/A";
                    mineDetailsModel.LesseeVillageName = mineDetailsModel.MineVillage;
                    mineDetailsModel.LesseeDistrictName = mineDetailsModel.MineDistrict;
                    mineDetailsModel.LesseeTehsilName = mineDetailsModel.MineTehsil;

                    mineDetailsModel.LesseeStateName = mineDetailsModel.MineState;
                    if (string.IsNullOrEmpty(mineDetailsModel.MinePostOffice))
                        mineDetailsModel.LesseePostOffice = mineDetailsModel.MinePostOffice;
                    else
                        mineDetailsModel.LesseePostOffice = "N/A";

                    if (string.IsNullOrEmpty(mineDetailsModel.MineFaxNo))
                        mineDetailsModel.LesseeFaxNo = mineDetailsModel.MineFaxNo;
                    else
                        mineDetailsModel.LesseeFaxNo = "N/A";
                    mineDetailsModel.LesseePhoneNo = mineDetailsModel.MinePhoneNo;
                }
                return mineDetailsModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Agency Of Mine
        /// <summary>
        /// To Bind Agency Of Mine Details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<List<YearlyReturnModel>> GetAgencyOfMine(int? UserId)
        {
            List<YearlyReturnModel> lstyearlyReturnModel = new List<YearlyReturnModel>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 4);
                var result =await Connection.QueryAsync<YearlyReturnModel>("GetAnnualReturnPart1", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstyearlyReturnModel = result.ToList();
                }
                return lstyearlyReturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstyearlyReturnModel = null;
            }
        }
        #endregion

        #region Mine Other Details
        #region Get Mine Other Details
        /// <summary>
        /// To Get Mine Other Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<AnnualReturnH1ViewModel> GetMineOtherDetails(YearlyReturnModel yearlyReturnModel)
        {
            try
            {
                AnnualReturnH1ViewModel objModel = new AnnualReturnH1ViewModel();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 1);
                param.Add("@UserID", yearlyReturnModel.UserId);
                IDataReader dr =await Connection.ExecuteReaderAsync("GetAnnualReturnPart1", param, commandType: System.Data.CommandType.StoredProcedure);
                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
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
        }
        #endregion

        #region Update Mine Other Details
        /// <summary>
        /// To Update Mine Other Details
        /// </summary>
        /// <param name="annualReturnH1ViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateMineOtherDetails(AnnualReturnH1ViewModel annualReturnH1ViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                MineOther_DetailsModel objModel = annualReturnH1ViewModel.objOtherDetails;
                MineDetailsModel objModelMine = annualReturnH1ViewModel.objMineDetails;
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", annualReturnH1ViewModel.UserId);
                param.Add("@OtherDetails_Id", objModel.OtherDetails_Id);
                param.Add("@Registrationnumber", objModelMine.Registrationnumber);
                param.Add("@MINE_CODE", objModelMine.MINE_CODE);
                param.Add("@MineralName", objModelMine.MineralName);
                param.Add("@OtherMineral", objModelMine.OtherMineral);
                param.Add("@MineName", objModelMine.MineName);
                param.Add("@MineAddress", objModelMine.MineAddress);
                param.Add("@MineVillage", objModelMine.MineVillage);
                param.Add("@MineDistrict", objModelMine.MineDistrict);
                param.Add("@MineState", objModelMine.MineState);
                param.Add("@MineTehsil", objModelMine.MineTehsil);
                param.Add("@MinePinCode", objModelMine.MinePinCode);
                param.Add("@MineEmailID", objModelMine.MineEmailID);
                param.Add("@MineMobileNo", objModelMine.MineMobileNo);
                param.Add("@MinePhoneNo", objModelMine.MinePhoneNo);
                param.Add("@LesseeName", objModelMine.LesseeName);
                param.Add("@LesseeAddress", objModelMine.LesseeAddress);
                param.Add("@LesseeVillageName", objModelMine.LesseeVillageName);
                param.Add("@LesseeDistrictName", objModelMine.LesseeDistrictName);
                param.Add("@LesseeStateName", objModelMine.LesseeStateName);
                param.Add("@LesseePinCode", objModelMine.LesseePinCode);
                param.Add("@LesseeTehsilName", objModelMine.LesseeTehsilName);
                param.Add("@LesseeEmailID", objModelMine.LesseeEmailID);
                param.Add("@LesseeMobileNo", objModelMine.LesseeMobileNo);
                param.Add("@LesseePhoneNo", objModelMine.LesseePhoneNo);

                param.Add("@RegisteredOffice", objModel.RegisteredOffice);
                param.Add("@Director_in_charge", objModel.Director_in_charge);
                param.Add("@Agent", objModel.Agent);
                param.Add("@Manager", objModel.Manager);
                param.Add("@MiningEngineer_in_charge", objModel.MiningEngineer_in_charge);
                param.Add("@Geologist_in_charge", objModel.Geologist_in_charge);
                param.Add("@Transferor", objModel.Transferor);
                param.Add("@Dateof_Transfer", objModel.Dateof_Transfer);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@MinePostOffice", objModel.MinePostOffice);
                param.Add("@MineFaxNo", objModel.MineFaxNo);
                param.Add("@LesseeFaxNo", objModel.LesseeFaxNo);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_OtherDetails", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Mine Other Details
        /// <summary>
        /// To Add Mine Other Details
        /// </summary>
        /// <param name="annualReturnH1ViewModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddMineOtherDetails(AnnualReturnH1ViewModel annualReturnH1ViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                MineOther_DetailsModel objModel = annualReturnH1ViewModel.objOtherDetails;
                MineDetailsModel objModelMine = annualReturnH1ViewModel.objMineDetails;
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", annualReturnH1ViewModel.UserId);

                param.Add("@Registrationnumber", objModelMine.Registrationnumber);
                param.Add("@MINE_CODE", objModelMine.MINE_CODE);
                param.Add("@OtherMineral", objModelMine.OtherMineral);
                param.Add("@MineralName", objModelMine.MineralName);
                param.Add("@MineName", objModelMine.MineName);
                param.Add("@MineAddress", objModelMine.MineAddress);
                param.Add("@MineVillage", objModelMine.MineVillage);
                param.Add("@MineDistrict", objModelMine.MineDistrict);
                param.Add("@MineState", objModelMine.MineState);
                param.Add("@MineTehsil", objModelMine.MineTehsil);
                param.Add("@MinePinCode", objModelMine.MinePinCode);
                param.Add("@MineEmailID", objModelMine.MineEmailID);
                param.Add("@MineMobileNo", objModelMine.MineMobileNo);
                param.Add("@MinePhoneNo", objModelMine.MinePhoneNo);
                param.Add("@LesseeName", objModelMine.LesseeName);
                param.Add("@LesseeAddress", objModelMine.LesseeAddress);
                param.Add("@LesseeVillageName", objModelMine.LesseeVillageName);
                param.Add("@LesseeDistrictName", objModelMine.LesseeDistrictName);
                param.Add("@LesseeStateName", objModelMine.LesseeStateName);
                param.Add("@LesseePinCode", objModelMine.LesseePinCode);

                param.Add("@LesseeTehsilName", objModelMine.LesseeTehsilName);
                param.Add("@LesseeEmailID", objModelMine.LesseeEmailID);
                param.Add("@LesseeMobileNo", objModelMine.LesseeMobileNo);
                param.Add("@LesseePhoneNo", objModelMine.LesseePhoneNo);

                param.Add("@RegisteredOffice", objModel.RegisteredOffice);
                param.Add("@Director_in_charge", objModel.Director_in_charge);
                param.Add("@Agent", objModel.Agent);
                param.Add("@Manager", objModel.Manager);
                param.Add("@MiningEngineer_in_charge", objModel.MiningEngineer_in_charge);
                param.Add("@Geologist_in_charge", objModel.Geologist_in_charge);
                param.Add("@Transferor", objModel.Transferor);
                param.Add("@Dateof_Transfer", objModel.Dateof_Transfer);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@MinePostOffice", objModel.MinePostOffice);
                param.Add("@MineFaxNo", objModel.MineFaxNo);
                param.Add("@LesseeFaxNo", objModel.LesseeFaxNo);
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_OtherDetails", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
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

        #region Particulars Of Area
        #region Get Particulars Of Area
        /// <summary>
        /// To Get Particulars Of Area
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<ParticularsofArea> GetParticularsofArea(YearlyReturnModel yearlyReturnModel)
        {
            try
            {
                ParticularsofArea objModel = new ParticularsofArea();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 2);
                param.Add("@UserID", yearlyReturnModel.UserId);
                IDataReader dr =await Connection.ExecuteReaderAsync("GetAnnualReturnPart1", param, commandType: System.Data.CommandType.StoredProcedure);
                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                DataTable dt = ds.Tables[0];
                if (dt != null)
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
        }
        #endregion

        #region Update Particulars Of Area
        /// <summary>
        /// To Update Particulars Of Area
        /// </summary>
        /// <param name="particularsofArea"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateParticularsofArea(ParticularsofArea particularsofArea)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", particularsofArea.UserId);
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
                for (var i = 0; i < particularsofArea.Particular_Id.Count; i++)
                {
                    dataTable.Rows.Add(i + 1, particularsofArea.Particular_Id[i],
                                                particularsofArea.Lease_number[i],
                                                particularsofArea.underlease_UnderForest[i],
                                                particularsofArea.underlease_OutsideForest[i],
                                                particularsofArea.underlease_Total[i],
                                                particularsofArea.Date_of_execution[i],
                                                particularsofArea.Periodoflease[i],
                                                particularsofArea.Surfacerights_UnderForest[i],
                                                particularsofArea.Surfacerights_OutsideForest[i],
                                                particularsofArea.Surfacerights_Total[i],
                                                particularsofArea.RenewalDate[i],
                                                particularsofArea.RenewalPeriod[i],
                                                particularsofArea.Mineral_produced,
                                                particularsofArea.More_mine_details,
                                                particularsofArea.UserId);
                }
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    param.Add("@BULK_ParticularArea", dataTable, DbType.Object);
                }

                param.Add("@Financial_Year", particularsofArea.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_ParticularsofArea", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Particulars Of Area
        /// <summary>
        /// To Add Particulars Of Area
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddParticularsofArea(ParticularsofArea objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", objModel.UserId);

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
                for (var i = 0; i < objModel.Lease_number.Count; i++)
                {
                    dataTable.Rows.Add(i + 1, objModel.Particular_Id[i],
                                              objModel.Lease_number[i],
                                              objModel.underlease_UnderForest[i],
                                              objModel.underlease_OutsideForest[i],
                                              objModel.underlease_Total[i],
                                              objModel.Date_of_execution[i],
                                              objModel.Periodoflease[i],
                                              objModel.Surfacerights_UnderForest[i],
                                              objModel.Surfacerights_OutsideForest[i],
                                              objModel.Surfacerights_Total[i],
                                              objModel.RenewalDate[i],
                                              objModel.RenewalPeriod[i],
                                              objModel.Mineral_produced,
                                              objModel.More_mine_details,
                                              objModel.UserId);
                }
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    param.Add("@BULK_ParticularArea", dataTable, DbType.Object);
                }
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_ParticularsofArea", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
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

        #region Lease Area
        #region Get Lease Area
        /// <summary>
        /// To Get Lease Area
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<LeaseArea> GetLeasearea(YearlyReturnModel yearlyReturnModel)
        {
            LeaseArea objModel = new LeaseArea();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 3);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<LeaseArea>("GetAnnualReturnPart1", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objModel = result.FirstOrDefault();
                }
                return objModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Lease Area
        /// <summary>
        /// To Update Lease Area
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateLeasearea(LeaseArea objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Lease_Area_Id", objModel.Lease_Area_Id);
                param.Add("@UnderForest1", objModel.UnderForest1);
                param.Add("@UnderForest2", objModel.UnderForest2);
                param.Add("@UnderForest3", objModel.UnderForest3);
                param.Add("@UnderForest4", objModel.UnderForest4);
                param.Add("@UnderForest5", objModel.UnderForest5);
                param.Add("@UnderForest6", objModel.UnderForest6);
                param.Add("@UnderForest7", objModel.UnderForest7);

                param.Add("@Outsideforest1", objModel.Outsideforest1);
                param.Add("@Outsideforest2", objModel.Outsideforest2);
                param.Add("@Outsideforest3", objModel.Outsideforest3);
                param.Add("@Outsideforest4", objModel.Outsideforest4);
                param.Add("@Outsideforest5", objModel.Outsideforest5);
                param.Add("@Outsideforest6", objModel.Outsideforest6);
                param.Add("@Outsideforest7", objModel.Outsideforest7);

                param.Add("@Total1", objModel.Total1);
                param.Add("@Total2", objModel.Total2);
                param.Add("@Total3", objModel.Total3);
                param.Add("@Total4", objModel.Total4);
                param.Add("@Total5", objModel.Total5);
                param.Add("@Total6", objModel.Total6);
                param.Add("@Total7", objModel.Total7);
                param.Add("@AgencyofMine", objModel.AgencyofMine);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_Leasearea", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Lease Area
        /// <summary>
        /// To Add Lease Area
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddLeasearea(LeaseArea objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@UnderForest1", objModel.UnderForest1);
                param.Add("@UnderForest2", objModel.UnderForest2);
                param.Add("@UnderForest3", objModel.UnderForest3);
                param.Add("@UnderForest4", objModel.UnderForest4);
                param.Add("@UnderForest5", objModel.UnderForest5);
                param.Add("@UnderForest6", objModel.UnderForest6);
                param.Add("@UnderForest7", objModel.UnderForest7);

                param.Add("@Outsideforest1", objModel.Outsideforest1);
                param.Add("@Outsideforest2", objModel.Outsideforest2);
                param.Add("@Outsideforest3", objModel.Outsideforest3);
                param.Add("@Outsideforest4", objModel.Outsideforest4);
                param.Add("@Outsideforest5", objModel.Outsideforest5);
                param.Add("@Outsideforest6", objModel.Outsideforest6);
                param.Add("@Outsideforest7", objModel.Outsideforest7);

                param.Add("@Total1", objModel.Total1);
                param.Add("@Total2", objModel.Total2);
                param.Add("@Total3", objModel.Total3);
                param.Add("@Total4", objModel.Total4);
                param.Add("@Total5", objModel.Total5);
                param.Add("@Total6", objModel.Total6);
                param.Add("@Total7", objModel.Total7);

                param.Add("@AgencyofMine", objModel.AgencyofMine);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_Leasearea", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
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

        #endregion

        #region Part Two
        #region Staff Details
        #region Get Staff Details
        /// <summary>
        /// To Get Staff and Work Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<StaffandWorkModel> GetStaffandWork(YearlyReturnModel yearlyReturnModel)
        {
            StaffandWorkModel staffandWorkModel = new StaffandWorkModel();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 1);
                param.Add("@UserID", yearlyReturnModel.UserId);

                var result =await Connection.QueryAsync<StaffandWorkModel>("GetAnnualReturnPart2", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    staffandWorkModel = result.FirstOrDefault();
                }
                return staffandWorkModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Staff Details
        /// <summary>
        /// To Update Staff Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateStaffandWork(StaffandWorkModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@WorkDetails_Id", objModel.WorkDetails_Id);
                param.Add("@Whollyemployed1", objModel.Whollyemployed1);
                param.Add("@Whollyemployed2", objModel.Whollyemployed2);
                param.Add("@Whollyemployed3", objModel.Whollyemployed3);
                param.Add("@Whollyemployed4", objModel.Whollyemployed4);
                param.Add("@Whollyemployed5", objModel.Whollyemployed5);
                param.Add("@Whollyemployed_Total", objModel.Whollyemployed_Total);
                param.Add("@Partlyemployed1", objModel.Partlyemployed1);
                param.Add("@Partlyemployed2", objModel.Partlyemployed2);
                param.Add("@Partlyemployed3", objModel.Partlyemployed3);
                param.Add("@Partlyemployed4", objModel.Partlyemployed4);
                param.Add("@Partlyemployed5", objModel.Partlyemployed5);
                param.Add("@Partlyemployed_Total", objModel.Partlyemployed_Total);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_StaffandWork", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Staff Details
        /// <summary>
        /// To Add Staff Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddStaffandWork(StaffandWorkModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@Whollyemployed1", objModel.Whollyemployed1);
                param.Add("@Whollyemployed2", objModel.Whollyemployed2);
                param.Add("@Whollyemployed3", objModel.Whollyemployed3);
                param.Add("@Whollyemployed4", objModel.Whollyemployed4);
                param.Add("@Whollyemployed5", objModel.Whollyemployed5);
                param.Add("@Whollyemployed_Total", objModel.Whollyemployed_Total);
                param.Add("@Partlyemployed1", objModel.Partlyemployed1);
                param.Add("@Partlyemployed2", objModel.Partlyemployed2);
                param.Add("@Partlyemployed3", objModel.Partlyemployed3);
                param.Add("@Partlyemployed4", objModel.Partlyemployed4);
                param.Add("@Partlyemployed5", objModel.Partlyemployed5);
                param.Add("@Partlyemployed_Total", objModel.Partlyemployed_Total);



                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_StaffandWork", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
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

        #region Work Details
        #region Get Work Details
        /// <summary>
        /// To Get Work Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<WorkModel> GetWorkDetails(YearlyReturnModel yearlyReturnModel)
        {
            WorkModel workModel = new WorkModel();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 5);
                param.Add("@UserID", yearlyReturnModel.UserId);
                IDataReader dr =await Connection.ExecuteReaderAsync("GetAnnualReturnPart2", param, commandType: System.Data.CommandType.StoredProcedure);
                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            workModel.NoOfDaysMineWorked = Convert.ToInt32(dt.Rows[0]["NoOfDaysMineWorked"]);
                            workModel.NoOfShiftPerDay = Convert.ToInt32(dt.Rows[0]["NoOfShiftPerDay"]);
                            workModel.Work_Id.Add(Convert.ToInt32(dt.Rows[i]["Work_Id"]));
                            workModel.Reason.Add(Convert.ToString(dt.Rows[i]["Reason"]));
                            workModel.NoOfDaysMineStop.Add(Convert.ToInt32(dt.Rows[i]["NoOfDaysMineStop"]));

                        }
                    }
                }

                return workModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Work Details
        /// <summary>
        /// To Update Work Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateWorkDetails(WorkModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 4);
                param.Add("@CreatedBy", objModel.UserId);

                DataTable dataTable = new DataTable("MineWork");

                dataTable.Columns.Add("Work_Id", typeof(Int32));
                dataTable.Columns.Add("NoOfDaysMineStop", typeof(Int32));
                dataTable.Columns.Add("Reason", typeof(string));
                dataTable.Columns.Add("CreatedBy", typeof(Int32));
                for (var i = 0; i < objModel.NoOfDaysMineStop.Count; i++)
                {
                    dataTable.Rows.Add(i + 1, objModel.NoOfDaysMineStop[i],
                                              objModel.Reason[i],
                                             objModel.UserId);
                }
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    param.Add("@BULK_MINEWORK", dataTable, DbType.Object);
                }
                param.Add("@NoOfDaysMineWorked", objModel.NoOfDaysMineWorked);
                param.Add("@NoOfShiftPerDay", objModel.NoOfShiftPerDay);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_StaffandWork", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This has not Updated..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Updated Successfully";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Work Details
        /// <summary>
        /// To Add Work Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddWorkDetails(WorkModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 3);
                param.Add("@CreatedBy", objModel.UserId);

                DataTable dataTable = new DataTable("MineWork");

                dataTable.Columns.Add("Work_Id", typeof(Int32));
                dataTable.Columns.Add("NoOfDaysMineStop", typeof(Int32));
                dataTable.Columns.Add("Reason", typeof(string));
                dataTable.Columns.Add("CreatedBy", typeof(Int32));
                for (var i = 0; i < objModel.NoOfDaysMineStop.Count; i++)
                {
                    dataTable.Rows.Add(i + 1, objModel.NoOfDaysMineStop[i],
                                              objModel.Reason[i],
                                             objModel.UserId);
                }
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    param.Add("@BULK_MINEWORK", dataTable, DbType.Object);
                }
                param.Add("@NoOfDaysMineWorked", objModel.NoOfDaysMineWorked);
                param.Add("@NoOfShiftPerDay", objModel.NoOfShiftPerDay);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_StaffandWork", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
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

        #region Salary/Wages Paid
        #region Get Salary/Wages
        /// <summary>
        /// To Get Salary/Wages
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<SalaryWagesPaidModel> GetSalaryWagesPaid(YearlyReturnModel yearlyReturnModel)
        {
            SalaryWagesPaidModel salaryWagesPaidModel = new SalaryWagesPaidModel();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 2);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<SalaryWagesPaidModel>("GetAnnualReturnPart2", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    salaryWagesPaidModel = result.FirstOrDefault();
                    if (salaryWagesPaidModel.WorkingBelowGrounddate != null)
                        salaryWagesPaidModel.WorkingBelowGrounddate_str = Convert.ToDateTime(salaryWagesPaidModel.WorkingBelowGrounddate, CultureInfo.CurrentCulture).ToString("dd/MM/yyyy");


                    if (salaryWagesPaidModel.WorkingOnMinedate != null)
                        salaryWagesPaidModel.WorkingOnMinedate_str = Convert.ToDateTime(salaryWagesPaidModel.WorkingOnMinedate, CultureInfo.CurrentCulture).ToString("dd/MM/yyyy");
                }
                return salaryWagesPaidModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update SalaryWages
        /// <summary>
        /// To Update SalaryWages
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateSalaryWagesPaid(SalaryWagesPaidModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@SalaryWages_Id", objModel.SalaryWages_Id);
                param.Add("@WorkingBelowGrounddate", objModel.WorkingBelowGrounddate_str);
                param.Add("@WorkingBelowNo", objModel.WorkingBelowNo);
                param.Add("@WorkingOnMinedate", objModel.WorkingOnMinedate_str);
                param.Add("@BG_Direct", objModel.BG_Direct);
                param.Add("@BG_Contract", objModel.BG_Contract);
                param.Add("@BG_Total", objModel.BG_Total);
                param.Add("@BG_NoOFDaysWork", objModel.BG_NoOFDaysWork);
                param.Add("@BG_Male", objModel.BG_Male);
                param.Add("@BG_Female", objModel.BG_Female);
                param.Add("@BG_Average_Total", objModel.BG_Average_Total);
                param.Add("@BG_TotalWages", objModel.BG_TotalWages);
                param.Add("@OC_Direct", objModel.OC_Direct);
                param.Add("@OC_Contract", objModel.OC_Contract);
                param.Add("@OC_Total", objModel.OC_Total);
                param.Add("@OC_NoOFDaysWork", objModel.OC_NoOFDaysWork);
                param.Add("@OC_Male", objModel.OC_Male);
                param.Add("@OC_Female", objModel.OC_Female);
                param.Add("@OC_Average_Total", objModel.OC_Average_Total);
                param.Add("@OC_TotalWages", objModel.OC_TotalWages);
                param.Add("@AG_Direct", objModel.AG_Direct);
                param.Add("@AG_Contract", objModel.AG_Contract);
                param.Add("@AG_Total", objModel.AG_Total);
                param.Add("@AG_NoOFDaysWork", objModel.AG_NoOFDaysWork);
                param.Add("@AG_Male", objModel.AG_Male);
                param.Add("@AG_Female", objModel.AG_Female);
                param.Add("@AG_Average_Total", objModel.AG_Average_Total);
                param.Add("@Total_Direct", objModel.Total_Direct);
                param.Add("@Total_Contract", objModel.Total_Contract);
                param.Add("@Total_Total", objModel.Total_Total);
                param.Add("@Total_NoOFDaysWork", objModel.Total_NoOFDaysWork);
                param.Add("@Total_Male", objModel.Total_Male);
                param.Add("@Total_Female", objModel.Total_Female);
                param.Add("@Total_Average_Total", objModel.Total_Average_Total);
                param.Add("@Total_TotalWages", objModel.Total_TotalWages);
                param.Add("@WorkingOnMineNo", objModel.WorkingOnMineNo);
                param.Add("@AG_TotalWages", objModel.AG_TotalWages);

                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_SalaryWagesPaid", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add SalaryWages
        /// <summary>
        /// To Add SalaryWages
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddSalaryWagesPaid(SalaryWagesPaidModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", objModel.UserId);

                param.Add("@WorkingBelowGrounddate", objModel.WorkingBelowGrounddate_str);
                param.Add("@WorkingBelowNo", objModel.WorkingBelowNo);
                param.Add("@WorkingOnMinedate", objModel.WorkingOnMinedate_str);
                param.Add("@WorkingOnMineNo", objModel.WorkingOnMineNo);

                param.Add("@BG_Direct", objModel.BG_Direct);
                param.Add("@BG_Contract", objModel.BG_Contract);
                param.Add("@BG_Total", objModel.BG_Total);
                param.Add("@BG_NoOFDaysWork", objModel.BG_NoOFDaysWork);

                param.Add("@BG_Male", objModel.BG_Male);
                param.Add("@BG_Female", objModel.BG_Female);
                param.Add("@BG_Average_Total", objModel.BG_Average_Total);
                param.Add("@BG_TotalWages", objModel.BG_TotalWages);

                param.Add("@OC_Direct", objModel.OC_Direct);
                param.Add("@OC_Contract", objModel.OC_Contract);
                param.Add("@OC_Total", objModel.OC_Total);
                param.Add("@OC_NoOFDaysWork", objModel.OC_NoOFDaysWork);

                param.Add("@OC_Male", objModel.OC_Male);
                param.Add("@OC_Female", objModel.OC_Female);
                param.Add("@OC_Average_Total", objModel.OC_Average_Total);
                param.Add("@OC_TotalWages", objModel.OC_TotalWages);

                param.Add("@AG_Direct", objModel.AG_Direct);
                param.Add("@AG_Contract", objModel.AG_Contract);
                param.Add("@AG_Total", objModel.AG_Total);
                param.Add("@AG_NoOFDaysWork", objModel.AG_NoOFDaysWork);

                param.Add("@AG_Male", objModel.AG_Male);
                param.Add("@AG_Female", objModel.AG_Female);
                param.Add("@AG_Average_Total", objModel.AG_Average_Total);
                param.Add("@AG_TotalWages", objModel.AG_TotalWages);

                param.Add("@Total_Direct", objModel.Total_Direct);
                param.Add("@Total_Contract", objModel.Total_Contract);
                param.Add("@Total_Total", objModel.Total_Total);
                param.Add("@Total_NoOFDaysWork", objModel.Total_NoOFDaysWork);

                param.Add("@Total_Male", objModel.Total_Male);
                param.Add("@Total_Female", objModel.Total_Female);
                param.Add("@Total_Average_Total", objModel.Total_Average_Total);
                param.Add("@Total_TotalWages", objModel.Total_TotalWages);

                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_SalaryWagesPaid", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
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

        #region Part II-A(Capital Structure)
        #region Get Capital Structure
        /// <summary>
        /// To Get Capital Structure
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<CapitalStructure> GetCapitalStructure(YearlyReturnModel yearlyReturnModel)
        {
            CapitalStructure capitalStructure = new CapitalStructure();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 3);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<CapitalStructure>("GetAnnualReturnPart2", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    capitalStructure = result.FirstOrDefault();
                }
                return capitalStructure;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Capital Structure
        /// <summary>
        /// To Update Capital Structure
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateCapitalStructure(CapitalStructure objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@CapitalStructure_Id", objModel.CapitalStructure_Id);
                param.Add("@ValueofFixedAssets", objModel.ValueofFixedAssets);
                param.Add("@OtherMineCode", objModel.OtherMineCode);
                param.Add("@Land_AtBeginning", objModel.Land_AtBeginning);
                param.Add("@Land_Additions", objModel.Land_Additions);
                param.Add("@Land_Sold_Discarded", objModel.Land_Sold_Discarded);
                param.Add("@Land_Depreciation", objModel.Land_Depreciation);
                param.Add("@Land_Net_closing_Balance", objModel.Land_Net_closing_Balance);
                param.Add("@Land_Estimated_Market", objModel.Land_Estimated_Market);
                param.Add("@Industrial_AtBeginning", objModel.Industrial_AtBeginning);
                param.Add("@Industrial_Additions", objModel.Industrial_Additions);
                param.Add("@Industrial_Sold_Discarded", objModel.Industrial_Sold_Discarded);
                param.Add("@Industrial_Depreciation", objModel.Industrial_Depreciation);
                param.Add("@Industrial_Net_closing_Balance", objModel.Industrial_Net_closing_Balance);
                param.Add("@Industrial_Estimated_Market", objModel.Industrial_Estimated_Market);
                param.Add("@Residential_AtBeginning", objModel.Residential_AtBeginning);
                param.Add("@Residential_Additions", objModel.Residential_Additions);
                param.Add("@Residential_Sold_Discarded", objModel.Residential_Sold_Discarded);
                param.Add("@Residential_Depreciation", objModel.Residential_Depreciation);
                param.Add("@Residential_Net_closing_Balance", objModel.Residential_Net_closing_Balance);
                param.Add("@Residential_Estimated_Market", objModel.Residential_Estimated_Market);
                param.Add("@P_M_T_AtBeginning", objModel.P_M_T_AtBeginning);
                param.Add("@P_M_T_Additions", objModel.P_M_T_Additions);
                param.Add("@P_M_T_Sold_Discarded", objModel.P_M_T_Sold_Discarded);
                param.Add("@P_M_T_Depreciation", objModel.P_M_T_Depreciation);
                param.Add("@P_M_T_Net_closing_Balance", objModel.P_M_T_Net_closing_Balance);
                param.Add("@P_M_T_Estimated_Market", objModel.P_M_T_Estimated_Market);
                param.Add("@Exp_AtBeginning", objModel.Exp_AtBeginning);
                param.Add("@Exp_Additions", objModel.Exp_Additions);
                param.Add("@Exp_Sold_Discarded", objModel.Exp_Sold_Discarded);
                param.Add("@Exp_Depreciation", objModel.Exp_Depreciation);
                param.Add("@Exp_Net_closing_Balance", objModel.Exp_Net_closing_Balance);
                param.Add("@Exp_Estimated_Market", objModel.Exp_Estimated_Market);
                param.Add("@Total_AtBeginning", objModel.Total_AtBeginning);
                param.Add("@Total_Additions", objModel.Total_Additions);
                param.Add("@Total_Sold_Discarded", objModel.Total_Sold_Discarded);
                param.Add("@Total_Depreciation", objModel.Total_Depreciation);
                param.Add("@Total_Net_closing_Balance", objModel.Total_Net_closing_Balance);
                param.Add("@Total_Estimated_Market", objModel.Total_Estimated_Market);

                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_CapitalStructure", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Capital Structure
        /// <summary>
        /// To Add Capital Structure
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddCapitalStructure(CapitalStructure objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@ValueofFixedAssets", objModel.ValueofFixedAssets);
                param.Add("@OtherMineCode", objModel.OtherMineCode);
                param.Add("@Land_AtBeginning", objModel.Land_AtBeginning);
                param.Add("@Land_Additions", objModel.Land_Additions);
                param.Add("@Land_Sold_Discarded", objModel.Land_Sold_Discarded);
                param.Add("@Land_Depreciation", objModel.Land_Depreciation);
                param.Add("@Land_Net_closing_Balance", objModel.Land_Net_closing_Balance);
                param.Add("@Land_Estimated_Market", objModel.Land_Estimated_Market);
                param.Add("@Industrial_AtBeginning", objModel.Industrial_AtBeginning);
                param.Add("@Industrial_Additions", objModel.Industrial_Additions);
                param.Add("@Industrial_Sold_Discarded", objModel.Industrial_Sold_Discarded);
                param.Add("@Industrial_Depreciation", objModel.Industrial_Depreciation);
                param.Add("@Industrial_Net_closing_Balance", objModel.Industrial_Net_closing_Balance);
                param.Add("@Industrial_Estimated_Market", objModel.Industrial_Estimated_Market);
                param.Add("@Residential_AtBeginning", objModel.Residential_AtBeginning);
                param.Add("@Residential_Additions", objModel.Residential_Additions);
                param.Add("@Residential_Sold_Discarded", objModel.Residential_Sold_Discarded);
                param.Add("@Residential_Depreciation", objModel.Residential_Depreciation);
                param.Add("@Residential_Net_closing_Balance", objModel.Residential_Net_closing_Balance);
                param.Add("@Residential_Estimated_Market", objModel.Residential_Estimated_Market);
                param.Add("@P_M_T_AtBeginning", objModel.P_M_T_AtBeginning);
                param.Add("@P_M_T_Additions", objModel.P_M_T_Additions);
                param.Add("@P_M_T_Sold_Discarded", objModel.P_M_T_Sold_Discarded);
                param.Add("@P_M_T_Depreciation", objModel.P_M_T_Depreciation);
                param.Add("@P_M_T_Net_closing_Balance", objModel.P_M_T_Net_closing_Balance);
                param.Add("@P_M_T_Estimated_Market", objModel.P_M_T_Estimated_Market);
                param.Add("@Exp_AtBeginning", objModel.Exp_AtBeginning);
                param.Add("@Exp_Additions", objModel.Exp_Additions);
                param.Add("@Exp_Sold_Discarded", objModel.Exp_Sold_Discarded);
                param.Add("@Exp_Depreciation", objModel.Exp_Depreciation);
                param.Add("@Exp_Net_closing_Balance", objModel.Exp_Net_closing_Balance);
                param.Add("@Exp_Estimated_Market", objModel.Exp_Estimated_Market);
                param.Add("@Total_AtBeginning", objModel.Total_AtBeginning);
                param.Add("@Total_Additions", objModel.Total_Additions);
                param.Add("@Total_Sold_Discarded", objModel.Total_Sold_Discarded);
                param.Add("@Total_Depreciation", objModel.Total_Depreciation);
                param.Add("@Total_Net_closing_Balance", objModel.Total_Net_closing_Balance);
                param.Add("@Total_Estimated_Market", objModel.Total_Estimated_Market);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_CapitalStructure", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
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

        #region Part-II A(Source Of Finance/Interest and Rent)
        #region Get Source Of Finance/Interest and Rent
        /// <summary>
        /// To Get Source Of Finance/Interest and Rent
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<SourceOfFinance> GetSourceOfFinance(YearlyReturnModel yearlyReturnModel)
        {
            SourceOfFinance sourceOfFinance = new SourceOfFinance();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 4);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<SourceOfFinance>("GetAnnualReturnPart2", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    sourceOfFinance = result.FirstOrDefault();
                }
                return sourceOfFinance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Source Of Finance/Interest and Rent
        /// <summary>
        /// To Update Source Of Finance/Interest and Rent
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateSourceOfFinance(SourceOfFinance objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@SourceOfFinance_Id", objModel.SourceOfFinance_Id);
                param.Add("@ShareCapital", objModel.ShareCapital);
                param.Add("@OwnCapital", objModel.OwnCapital);
                param.Add("@Reserve", objModel.Reserve);
                param.Add("@Institution", objModel.Institution);
                param.Add("@AmountofLoan", objModel.AmountofLoan);
                param.Add("@RateofInterest", objModel.RateofInterest);
                param.Add("@Interestpaid", objModel.Interestpaid);
                param.Add("@Rentspaid", objModel.Rentspaid);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_SourceOfFinance", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Source Of Finance/Interest and Rent
        /// <summary>
        /// To Add Source Of Finance/Interest and Rent
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddSourceOfFinance(SourceOfFinance objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@ShareCapital", objModel.ShareCapital);
                param.Add("@OwnCapital", objModel.OwnCapital);
                param.Add("@Reserve", objModel.Reserve);
                param.Add("@Institution", objModel.Institution);
                param.Add("@AmountofLoan", objModel.AmountofLoan);
                param.Add("@RateofInterest", objModel.RateofInterest);
                param.Add("@Interestpaid", objModel.Interestpaid);
                param.Add("@Rentspaid", objModel.Rentspaid);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_SourceOfFinance", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
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

        #endregion

        #region Part Three
        #region Quantity and Cost of Material Consumed
        #region Get Material Consumed
        /// <summary>
        /// To Get Material Consumed
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<MaterialConsumed> GetMaterialConsumed(YearlyReturnModel yearlyReturnModel)
        {
            MaterialConsumed materialConsumed = new MaterialConsumed();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 1);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<MaterialConsumed>("GetAnnualReturnPart3", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    materialConsumed = result.FirstOrDefault();
                }
                return materialConsumed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Material Consumed
        /// <summary>
        /// To Update Material Consumed
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateMaterialConsumed(MaterialConsumed objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@MaterialConsumed_Id", objModel.MaterialConsumed_Id);
                param.Add("@CoalQty", objModel.CoalQty);
                param.Add("@CoalValue", objModel.CoalValue);
                param.Add("@DieselOilQty", objModel.DieselOilQty);
                param.Add("@DieselOilValue", objModel.DieselOilValue);
                param.Add("@PetrolQty", objModel.PetrolQty);
                param.Add("@PetrolValue", objModel.PetrolValue);
                param.Add("@KeroseneQty", objModel.KeroseneQty);
                param.Add("@KeroseneValue", objModel.KeroseneValue);
                param.Add("@GasQty", objModel.GasQty);
                param.Add("@GasValue", objModel.GasValue);
                param.Add("@LubricantoilQty", objModel.LubricantoilQty);
                param.Add("@LubricantoilValue", objModel.LubricantoilValue);
                param.Add("@GreaseQty", objModel.GreaseQty);
                param.Add("@GreaseValue", objModel.GreaseValue);
                param.Add("@ConsumedQty", objModel.ConsumedQty);
                param.Add("@ConsumedValue", objModel.ConsumedValue);
                param.Add("@GeneratedQty", objModel.GeneratedQty);
                param.Add("@GeneratedValue", objModel.GeneratedValue);
                param.Add("@SoldQty", objModel.SoldQty);
                param.Add("@SoldValue", objModel.SoldValue);
                param.Add("@ExplosivesValue", objModel.ExplosivesValue);
                param.Add("@TyresQty", objModel.TyresQty);
                param.Add("@TyresValue", objModel.TyresValue);
                param.Add("@Timber_SupportsValue", objModel.Timber_SupportsValue);
                param.Add("@Drill_kitsQty", objModel.Drill_kitsQty);
                param.Add("@Drill_kitsValue", objModel.Drill_kitsValue);
                param.Add("@OtherSparesValue", objModel.OtherSparesValue);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_MaterialConsumed", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Material Consumed
        /// <summary>
        /// To Add Material Consumed
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddMaterialConsumed(MaterialConsumed objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@CoalQty", objModel.CoalQty);
                param.Add("@CoalValue", objModel.CoalValue);
                param.Add("@DieselOilQty", objModel.DieselOilQty);
                param.Add("@DieselOilValue", objModel.DieselOilValue);
                param.Add("@PetrolQty", objModel.PetrolQty);
                param.Add("@PetrolValue", objModel.PetrolValue);
                param.Add("@KeroseneQty", objModel.KeroseneQty);
                param.Add("@KeroseneValue", objModel.KeroseneValue);
                param.Add("@GasQty", objModel.GasQty);
                param.Add("@GasValue", objModel.GasValue);
                param.Add("@LubricantoilQty", objModel.LubricantoilQty);
                param.Add("@LubricantoilValue", objModel.LubricantoilValue);
                param.Add("@GreaseQty", objModel.GreaseQty);
                param.Add("@GreaseValue", objModel.GreaseValue);
                param.Add("@ConsumedQty", objModel.ConsumedQty);
                param.Add("@ConsumedValue", objModel.ConsumedValue);
                param.Add("@GeneratedQty", objModel.GeneratedQty);
                param.Add("@GeneratedValue", objModel.GeneratedValue);
                param.Add("@SoldQty", objModel.SoldQty);
                param.Add("@SoldValue", objModel.SoldValue);
                param.Add("@ExplosivesValue", objModel.ExplosivesValue);
                param.Add("@TyresQty", objModel.TyresQty);
                param.Add("@TyresValue", objModel.TyresValue);
                param.Add("@Timber_SupportsValue", objModel.Timber_SupportsValue);
                param.Add("@Drill_kitsQty", objModel.Drill_kitsQty);
                param.Add("@Drill_kitsValue", objModel.Drill_kitsValue);
                param.Add("@OtherSparesValue", objModel.OtherSparesValue);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_MaterialConsumed", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
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

        #region Royalty,Rents and Payments
        #region Get Royalty and Rents
        /// <summary>
        /// To Get Royalty and Rent
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<RoyaltyandRents> GetRoyaltyandRent(YearlyReturnModel yearlyReturnModel)
        {
            RoyaltyandRents royaltyandRents = new RoyaltyandRents();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 2);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<RoyaltyandRents>("GetAnnualReturnPart3", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    royaltyandRents = result.FirstOrDefault();
                }
                return royaltyandRents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Royalty and Rent
        /// <summary>
        /// To Update Royalty and Rent
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateRoyaltyandRent(RoyaltyandRents objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters(); 
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@RoyaltyandRents_Id", objModel.RoyaltyandRents_Id);
                param.Add("@RoyaltyCurrentyear", objModel.RoyaltyCurrentyear);
                param.Add("@RoyaltyArrears", objModel.RoyaltyArrears);
                param.Add("@DeadRentCurrentyear", objModel.DeadRentCurrentyear);
                param.Add("@DeadRentArrears", objModel.DeadRentArrears);
                param.Add("@SurfaceRentCurrentyear", objModel.SurfaceRentCurrentyear);
                param.Add("@SurfaceRentArrears", objModel.SurfaceRentArrears);
                param.Add("@DMFCurrentyear", objModel.DMFCurrentyear);
                param.Add("@DMFArrears", objModel.DMFArrears);
                param.Add("@NMETCurrentyear", objModel.NMETCurrentyear);
                param.Add("@NMETArrears", objModel.NMETArrears);
                param.Add("@Compensation_Trees", objModel.Compensation_Trees);
                param.Add("@Depreciation", objModel.Depreciation);
                param.Add("@SalesTax_CentralGovt", objModel.SalesTax_CentralGovt);
                param.Add("@SalesTax_StateGovt", objModel.SalesTax_StateGovt);
                param.Add("@Welfarecess_CentralGovt", objModel.Welfarecess_CentralGovt);
                param.Add("@Welfarecess_StateGovt", objModel.Welfarecess_StateGovt);
                param.Add("@Cess_CentralGovt", objModel.Cess_CentralGovt);
                param.Add("@Cess_StateGovt", objModel.Cess_StateGovt);
                param.Add("@CessdeadRent_CentralGovt", objModel.CessdeadRent_CentralGovt);
                param.Add("@CessdeadRent_StateGovt", objModel.CessdeadRent_StateGovt);
                param.Add("@Others_CentralGovt", objModel.Others_CentralGovt);
                param.Add("@Others_StateGovt", objModel.Others_StateGovt);
                param.Add("@Overheads", objModel.Overheads);
                param.Add("@Maintenance", objModel.Maintenance);
                param.Add("@Moneyvalue", objModel.Moneyvalue);
                param.Add("@Paymentmade", objModel.Paymentmade);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_RoyaltyandRents", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Royalty and Rent
        /// <summary>
        /// To Add Royalty and Rent
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddRoyaltyandRent(RoyaltyandRents objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@RoyaltyCurrentyear", objModel.RoyaltyCurrentyear);
                param.Add("@RoyaltyArrears", objModel.RoyaltyArrears);
                param.Add("@DeadRentCurrentyear", objModel.DeadRentCurrentyear);
                param.Add("@DeadRentArrears", objModel.DeadRentArrears);
                param.Add("@SurfaceRentCurrentyear", objModel.SurfaceRentCurrentyear);
                param.Add("@SurfaceRentArrears", objModel.SurfaceRentArrears);
                param.Add("@DMFCurrentyear", objModel.DMFCurrentyear);
                param.Add("@DMFArrears", objModel.DMFArrears);
                param.Add("@NMETCurrentyear", objModel.NMETCurrentyear);
                param.Add("@NMETArrears", objModel.NMETArrears);
                param.Add("@Compensation_Trees", objModel.Compensation_Trees);
                param.Add("@Depreciation", objModel.Depreciation);
                param.Add("@SalesTax_CentralGovt", objModel.SalesTax_CentralGovt);
                param.Add("@SalesTax_StateGovt", objModel.SalesTax_StateGovt);
                param.Add("@Welfarecess_CentralGovt", objModel.Welfarecess_CentralGovt);
                param.Add("@Welfarecess_StateGovt", objModel.Welfarecess_StateGovt);
                param.Add("@Cess_CentralGovt", objModel.Cess_CentralGovt);
                param.Add("@Cess_StateGovt", objModel.Cess_StateGovt);
                param.Add("@CessdeadRent_CentralGovt", objModel.CessdeadRent_CentralGovt);
                param.Add("@CessdeadRent_StateGovt", objModel.CessdeadRent_StateGovt);
                param.Add("@Others_CentralGovt", objModel.Others_CentralGovt);
                param.Add("@Others_StateGovt", objModel.Others_StateGovt);
                param.Add("@Overheads", objModel.Overheads);
                param.Add("@Maintenance", objModel.Maintenance);
                param.Add("@Moneyvalue", objModel.Moneyvalue);
                param.Add("@Paymentmade", objModel.Paymentmade);

                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_RoyaltyandRents", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
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

        #endregion

        #region Part Four
        #region Get Consumption Of Explosives
        /// <summary>
        /// To Get Consumption Of Explosives
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<AnnualReturnH1PartFourModel> GetExplosives(YearlyReturnModel yearlyReturnModel)
        {
            AnnualReturnH1PartFourModel annualReturnH1PartFourModel = new AnnualReturnH1PartFourModel();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 1);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<AnnualReturnH1PartFourModel>("GetAnnualReturnPart4", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    annualReturnH1PartFourModel = result.FirstOrDefault();
                }
                return annualReturnH1PartFourModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Consumption Of Explosives
        /// <summary>
        /// To Update Consumption Of Explosives
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateExplosives(AnnualReturnH1PartFourModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Explosives_Id", objModel.Explosives_Id);
                param.Add("@LicensedCapacity_Item1", objModel.LicensedCapacity_Item1);
                param.Add("@LicensedCapacity_Unit1", objModel.LicensedCapacity_Unit1);
                param.Add("@LicensedCapacity_Item2", objModel.LicensedCapacity_Item2);
                param.Add("@LicensedCapacity_Unit2", objModel.LicensedCapacity_Unit2);
                param.Add("@LicensedCapacity_Item3", objModel.LicensedCapacity_Item3);
                param.Add("@LicensedCapacity_Unit3", objModel.LicensedCapacity_Unit3);
                param.Add("@LicensedCapacity_Capacity3", objModel.LicensedCapacity_Capacity3);
                param.Add("@GunPow_Qty_Small", objModel.GunPow_Qty_Small);
                param.Add("@GunPow_Qty_Large", objModel.GunPow_Qty_Large);
                param.Add("@GunPow_Estimated_Small", objModel.GunPow_Estimated_Small);
                param.Add("@GunPow_Estimated_Large", objModel.GunPow_Estimated_Large);
                param.Add("@Looseammo_nitrate_Unit", objModel.Looseammo_nitrate_Unit);
                param.Add("@Looseammo_nitrate_Qty_Large", objModel.Looseammo_nitrate_Qty_Large);
                param.Add("@Looseammo_nitrate_Estimated_Small", objModel.Looseammo_nitrate_Estimated_Small);
                param.Add("@Cartridged_Qty_Large", objModel.Cartridged_Qty_Large);
                param.Add("@NitroCompound_Qty_Large", objModel.NitroCompound_Qty_Large);
                param.Add("@NitroCompound_Estimated_Small", objModel.NitroCompound_Estimated_Small);
                param.Add("@NitroCompound_Estimated_Large", objModel.NitroCompound_Estimated_Large);
                param.Add("@LiquidOxygen_Qty_Small", objModel.LiquidOxygen_Qty_Small);
                param.Add("@LiquidOxygen_Qty_Large", objModel.LiquidOxygen_Qty_Large);
                param.Add("@LiquidOxygen_Estimated_Small", objModel.LiquidOxygen_Estimated_Small);
                param.Add("@LiquidOxygen_Estimated_Large", objModel.LiquidOxygen_Estimated_Large);
                param.Add("@SlurryExplosives_Qty_Small", objModel.SlurryExplosives_Qty_Small);
                param.Add("@SlurryExplosives_Qty_Large", objModel.SlurryExplosives_Qty_Large);
                param.Add("@SlurryExplosives_Estimated_Small", objModel.SlurryExplosives_Estimated_Small);
                param.Add("@SlurryExplosives_Estimated_Large", objModel.SlurryExplosives_Estimated_Large);
                param.Add("@Detonators_Ord_Unit", objModel.Detonators_Ord_Unit);
                param.Add("@Detonators_Ord_Qty_Small", objModel.Detonators_Ord_Qty_Small);
                param.Add("@Detonators_Ord_Qty_Large", objModel.Detonators_Ord_Qty_Large);
                param.Add("@Detonators_Ord_Estimated_Large", objModel.Detonators_Ord_Estimated_Large);
                param.Add("@Detonators_Elec_Ord_Unit", objModel.Detonators_Elec_Ord_Unit);
                param.Add("@Detonators_Elec_Ord_Qty_Small", objModel.Detonators_Elec_Ord_Qty_Small);
                param.Add("@Detonators_Elec_Ord_Qty_Large", objModel.Detonators_Elec_Ord_Qty_Large);
                param.Add("@Detonators_Elec_Ord_Estimated_Small", objModel.Detonators_Elec_Ord_Estimated_Small);
                param.Add("@Detonators_Elec_Ord_Estimated_Large", objModel.Detonators_Elec_Ord_Estimated_Large);
                param.Add("@Detonators_Elec_Del_Unit", objModel.Detonators_Elec_Del_Unit);
                param.Add("@Detonators_Elec_Del_Qty_Small", objModel.Detonators_Elec_Del_Qty_Small);
                param.Add("@Detonators_Elec_Del_Qty_Large", objModel.Detonators_Elec_Del_Qty_Large);
                param.Add("@Detonators_Elec_Del_Estimated_Small", objModel.Detonators_Elec_Del_Estimated_Small);
                param.Add("@Detonators_Elec_Del_Estimated_Large", objModel.Detonators_Elec_Del_Estimated_Large);
                param.Add("@Fuse_Saf_Unit", objModel.Fuse_Saf_Unit);
                param.Add("@Fuse_Saf_Qty_Small", objModel.Fuse_Saf_Qty_Small);
                param.Add("@Fuse_Saf_Qty_Large", objModel.Fuse_Saf_Qty_Large);
                param.Add("@Fuse_Saf_Estimated_Small", objModel.Fuse_Saf_Estimated_Small);
                param.Add("@Fuse_Saf_Estimated_Large", objModel.Fuse_Saf_Estimated_Large);
                param.Add("@Fuse_Deton_Unit", objModel.Fuse_Deton_Unit);
                param.Add("@Fuse_Deton_Qty_Small", objModel.Fuse_Deton_Qty_Small);
                param.Add("@Fuse_Deton_Qty_Large", objModel.Fuse_Deton_Qty_Large);
                param.Add("@Fuse_Deton_Estimated_Small", objModel.Fuse_Deton_Estimated_Small);
                param.Add("@Fuse_Deton_Estimated_Large", objModel.Fuse_Deton_Estimated_Large);
                param.Add("@Plastic_Qty_Small", objModel.Plastic_Qty_Small);
                param.Add("@Plastic_Qty_Large", objModel.Plastic_Qty_Large);
                param.Add("@Plastic_Estimated_Small", objModel.Plastic_Estimated_Small);
                param.Add("@Plastic_Estimated_Large", objModel.Plastic_Estimated_Large);
                param.Add("@Others_Qty_Small", objModel.Others_Qty_Small);
                param.Add("@Others_Qty_Large", objModel.Others_Qty_Large);
                param.Add("@Others_Estimated_Small", objModel.Others_Estimated_Small);
                param.Add("@Others_Estimated_Large", objModel.Others_Estimated_Large);
                param.Add("@LicensedCapacity_Capacity1", objModel.LicensedCapacity_Capacity1);
                param.Add("@LicensedCapacity_Capacity2", objModel.LicensedCapacity_Capacity2);
                param.Add("@Looseammo_nitrate_Qty_Small", objModel.Looseammo_nitrate_Qty_Small);
                param.Add("@Looseammo_nitrate_Estimated_Large", objModel.Looseammo_nitrate_Estimated_Large);
                param.Add("@Cartridged_Unit", objModel.Cartridged_Unit);
                param.Add("@Cartridged_Qty_Small", objModel.Cartridged_Qty_Small);
                param.Add("@Cartridged_Estimated_Small", objModel.Cartridged_Estimated_Small);
                param.Add("@Cartridged_Estimated_Large", objModel.Cartridged_Estimated_Large);
                param.Add("@NitroCompound_Qty_Small", objModel.NitroCompound_Qty_Small);
                param.Add("@Detonators_Ord_Estimated_Small", objModel.Detonators_Ord_Estimated_Small);
                param.Add("@Others_Qty_Unit", objModel.Others_Qty_Unit);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_Explosives", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Consumption Of Explosives
        /// <summary>
        /// To Add Consumption Of Explosives
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddExplosives(AnnualReturnH1PartFourModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@LicensedCapacity_Item1", objModel.LicensedCapacity_Item1);
                param.Add("@LicensedCapacity_Unit1", objModel.LicensedCapacity_Unit1);
                param.Add("@LicensedCapacity_Item2", objModel.LicensedCapacity_Item2);
                param.Add("@LicensedCapacity_Unit2", objModel.LicensedCapacity_Unit2);
                param.Add("@LicensedCapacity_Item3", objModel.LicensedCapacity_Item3);
                param.Add("@LicensedCapacity_Unit3", objModel.LicensedCapacity_Unit3);
                param.Add("@LicensedCapacity_Capacity3", objModel.LicensedCapacity_Capacity3);
                param.Add("@GunPow_Qty_Small", objModel.GunPow_Qty_Small);
                param.Add("@GunPow_Qty_Large", objModel.GunPow_Qty_Large);
                param.Add("@GunPow_Estimated_Small", objModel.GunPow_Estimated_Small);
                param.Add("@GunPow_Estimated_Large", objModel.GunPow_Estimated_Large);
                param.Add("@Looseammo_nitrate_Unit", objModel.Looseammo_nitrate_Unit);
                param.Add("@Looseammo_nitrate_Qty_Large", objModel.Looseammo_nitrate_Qty_Large);
                param.Add("@Looseammo_nitrate_Estimated_Small", objModel.Looseammo_nitrate_Estimated_Small);
                param.Add("@Cartridged_Qty_Large", objModel.Cartridged_Qty_Large);
                param.Add("@NitroCompound_Qty_Large", objModel.NitroCompound_Qty_Large);
                param.Add("@NitroCompound_Estimated_Small", objModel.NitroCompound_Estimated_Small);
                param.Add("@NitroCompound_Estimated_Large", objModel.NitroCompound_Estimated_Large);
                param.Add("@LiquidOxygen_Qty_Small", objModel.LiquidOxygen_Qty_Small);
                param.Add("@LiquidOxygen_Qty_Large", objModel.LiquidOxygen_Qty_Large);
                param.Add("@LiquidOxygen_Estimated_Small", objModel.LiquidOxygen_Estimated_Small);
                param.Add("@LiquidOxygen_Estimated_Large", objModel.LiquidOxygen_Estimated_Large);
                param.Add("@SlurryExplosives_Qty_Small", objModel.SlurryExplosives_Qty_Small);
                param.Add("@SlurryExplosives_Qty_Large", objModel.SlurryExplosives_Qty_Large);
                param.Add("@SlurryExplosives_Estimated_Small", objModel.SlurryExplosives_Estimated_Small);
                param.Add("@SlurryExplosives_Estimated_Large", objModel.SlurryExplosives_Estimated_Large);
                param.Add("@Detonators_Ord_Unit", objModel.Detonators_Ord_Unit);
                param.Add("@Detonators_Ord_Qty_Small", objModel.Detonators_Ord_Qty_Small);
                param.Add("@Detonators_Ord_Qty_Large", objModel.Detonators_Ord_Qty_Large);
                param.Add("@Detonators_Ord_Estimated_Large", objModel.Detonators_Ord_Estimated_Large);
                param.Add("@Detonators_Elec_Ord_Unit", objModel.Detonators_Elec_Ord_Unit);
                param.Add("@Detonators_Elec_Ord_Qty_Small", objModel.Detonators_Elec_Ord_Qty_Small);
                param.Add("@Detonators_Elec_Ord_Qty_Large", objModel.Detonators_Elec_Ord_Qty_Large);
                param.Add("@Detonators_Elec_Ord_Estimated_Small", objModel.Detonators_Elec_Ord_Estimated_Small);
                param.Add("@Detonators_Elec_Ord_Estimated_Large", objModel.Detonators_Elec_Ord_Estimated_Large);
                param.Add("@Detonators_Elec_Del_Unit", objModel.Detonators_Elec_Del_Unit);
                param.Add("@Detonators_Elec_Del_Qty_Small", objModel.Detonators_Elec_Del_Qty_Small);
                param.Add("@Detonators_Elec_Del_Qty_Large", objModel.Detonators_Elec_Del_Qty_Large);
                param.Add("@Detonators_Elec_Del_Estimated_Small", objModel.Detonators_Elec_Del_Estimated_Small);
                param.Add("@Detonators_Elec_Del_Estimated_Large", objModel.Detonators_Elec_Del_Estimated_Large);
                param.Add("@Fuse_Saf_Unit", objModel.Fuse_Saf_Unit);
                param.Add("@Fuse_Saf_Qty_Small", objModel.Fuse_Saf_Qty_Small);
                param.Add("@Fuse_Saf_Qty_Large", objModel.Fuse_Saf_Qty_Large);
                param.Add("@Fuse_Saf_Estimated_Small", objModel.Fuse_Saf_Estimated_Small);
                param.Add("@Fuse_Saf_Estimated_Large", objModel.Fuse_Saf_Estimated_Large);
                param.Add("@Fuse_Deton_Unit", objModel.Fuse_Deton_Unit);
                param.Add("@Fuse_Deton_Qty_Small", objModel.Fuse_Deton_Qty_Small);
                param.Add("@Fuse_Deton_Qty_Large", objModel.Fuse_Deton_Qty_Large);
                param.Add("@Fuse_Deton_Estimated_Small", objModel.Fuse_Deton_Estimated_Small);
                param.Add("@Fuse_Deton_Estimated_Large", objModel.Fuse_Deton_Estimated_Large);
                param.Add("@Plastic_Qty_Small", objModel.Plastic_Qty_Small);
                param.Add("@Plastic_Qty_Large", objModel.Plastic_Qty_Large);
                param.Add("@Plastic_Estimated_Small", objModel.Plastic_Estimated_Small);
                param.Add("@Plastic_Estimated_Large", objModel.Plastic_Estimated_Large);
                param.Add("@Others_Qty_Small", objModel.Others_Qty_Small);
                param.Add("@Others_Qty_Large", objModel.Others_Qty_Large);
                param.Add("@Others_Estimated_Small", objModel.Others_Estimated_Small);
                param.Add("@Others_Estimated_Large", objModel.Others_Estimated_Large);
                param.Add("@LicensedCapacity_Capacity1", objModel.LicensedCapacity_Capacity1);
                param.Add("@LicensedCapacity_Capacity2", objModel.LicensedCapacity_Capacity2);
                param.Add("@Looseammo_nitrate_Qty_Small", objModel.Looseammo_nitrate_Qty_Small);
                param.Add("@Looseammo_nitrate_Estimated_Large", objModel.Looseammo_nitrate_Estimated_Large);
                param.Add("@Cartridged_Unit", objModel.Cartridged_Unit);
                param.Add("@Cartridged_Qty_Small", objModel.Cartridged_Qty_Small);
                param.Add("@Cartridged_Estimated_Small", objModel.Cartridged_Estimated_Small);
                param.Add("@Cartridged_Estimated_Large", objModel.Cartridged_Estimated_Large);
                param.Add("@NitroCompound_Qty_Small", objModel.NitroCompound_Qty_Small);
                param.Add("@Detonators_Ord_Estimated_Small", objModel.Detonators_Ord_Estimated_Small);
                param.Add("@Others_Qty_Unit", objModel.Others_Qty_Unit);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_Explosives", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Unit
        /// <summary>
        /// To Bind Unit
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<UnitType>> GetUnitTypeList(YearlyReturnModel yearlyReturnModel)
        {
            List<UnitType> lstUnit = new List<UnitType>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<UnitType>("select UnitID,UnitName from UnitMaster where IsActive=1 and IsDelete=0 order by UnitName", param, commandType: System.Data.CommandType.Text);
                if (result.Count() > 0)
                {
                    lstUnit = result.ToList();
                }
                return lstUnit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Part Five
        #region Exploration
        #region Update Exploration
        /// <summary>
        /// To Update Exploration
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateExploration(Exploration objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Exploration_Id", objModel.Exploration_Id);
                param.Add("@Drilling_holes_Beginning", objModel.Drilling_holes_Beginning);
                param.Add("@Drilling_holes_During", objModel.Drilling_holes_During);
                param.Add("@Drilling_holes_Cumulative", objModel.Drilling_holes_Cumulative);
                param.Add("@Drilling_holes_Dimension", objModel.Drilling_holes_Dimension);
                param.Add("@Drilling_Metrage_Beginning", objModel.Drilling_Metrage_Beginning);
                param.Add("@Drilling_Metrage_During", objModel.Drilling_Metrage_During);
                param.Add("@Drilling_Metrage_Cumulative", objModel.Drilling_Metrage_Cumulative);
                param.Add("@Drilling_Metrage_Dimension", objModel.Drilling_Metrage_Dimension);
                param.Add("@Pitting_Pits_Beginning", objModel.Pitting_Pits_Beginning);
                param.Add("@Pitting_Pits_During", objModel.Pitting_Pits_During);
                param.Add("@Pitting_Pits_Cumulative", objModel.Pitting_Pits_Cumulative);
                param.Add("@Pitting_Pits_Dimension", objModel.Pitting_Pits_Dimension);
                param.Add("@Pitting_Excavation_Beginning", objModel.Pitting_Excavation_Beginning);
                param.Add("@Pitting_Excavation_During", objModel.Pitting_Excavation_During);
                param.Add("@Pitting_Excavation_Cumulative", objModel.Pitting_Excavation_Cumulative);
                param.Add("@Pitting_Excavation_Dimension", objModel.Pitting_Excavation_Dimension);
                param.Add("@Pitting_trenches_Beginning", objModel.Pitting_trenches_Beginning);
                param.Add("@Pitting_trenches_During", objModel.Pitting_trenches_During);
                param.Add("@Pitting_trenches_Cumulative", objModel.Pitting_trenches_Cumulative);
                param.Add("@Pitting_trenches_Dimension", objModel.Pitting_trenches_Dimension);
                param.Add("@Pitting_Excavation1_Beginning", objModel.Pitting_Excavation1_Beginning);
                param.Add("@Pitting_Excavation1_During", objModel.Pitting_Excavation1_During);
                param.Add("@Pitting_Excavation1_Cumulative", objModel.Pitting_Excavation1_Cumulative);
                param.Add("@Pitting_Excavation1_Dimension", objModel.Pitting_Excavation1_Dimension);
                param.Add("@Pitting_Length_Beginning", objModel.Pitting_Length_Beginning);
                param.Add("@Pitting_Length_During", objModel.Pitting_Length_During);
                param.Add("@Pitting_Length_Cumulative", objModel.Pitting_Length_Cumulative);
                param.Add("@Pitting_Length_Dimension", objModel.Pitting_Length_Dimension);
                param.Add("@Expenditure_Beginning", objModel.Expenditure_Beginning);
                param.Add("@Expenditure_During", objModel.Expenditure_During);
                param.Add("@Expenditure_Cumulative", objModel.Expenditure_Cumulative);
                param.Add("@Exploration_Activity", objModel.Exploration_Activity);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_Exploration", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Exploration
        /// <summary>
        /// To Add Exploration
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddExploration(Exploration objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@Drilling_holes_Beginning", objModel.Drilling_holes_Beginning);
                param.Add("@Drilling_holes_During", objModel.Drilling_holes_During);
                param.Add("@Drilling_holes_Cumulative", objModel.Drilling_holes_Cumulative);
                param.Add("@Drilling_holes_Dimension", objModel.Drilling_holes_Dimension);
                param.Add("@Drilling_Metrage_Beginning", objModel.Drilling_Metrage_Beginning);
                param.Add("@Drilling_Metrage_During", objModel.Drilling_Metrage_During);
                param.Add("@Drilling_Metrage_Cumulative", objModel.Drilling_Metrage_Cumulative);
                param.Add("@Drilling_Metrage_Dimension", objModel.Drilling_Metrage_Dimension);
                param.Add("@Pitting_Pits_Beginning", objModel.Pitting_Pits_Beginning);
                param.Add("@Pitting_Pits_During", objModel.Pitting_Pits_During);
                param.Add("@Pitting_Pits_Cumulative", objModel.Pitting_Pits_Cumulative);
                param.Add("@Pitting_Pits_Dimension", objModel.Pitting_Pits_Dimension);
                param.Add("@Pitting_Excavation_Beginning", objModel.Pitting_Excavation_Beginning);
                param.Add("@Pitting_Excavation_During", objModel.Pitting_Excavation_During);
                param.Add("@Pitting_Excavation_Cumulative", objModel.Pitting_Excavation_Cumulative);
                param.Add("@Pitting_Excavation_Dimension", objModel.Pitting_Excavation_Dimension);
                param.Add("@Pitting_trenches_Beginning", objModel.Pitting_trenches_Beginning);
                param.Add("@Pitting_trenches_During", objModel.Pitting_trenches_During);
                param.Add("@Pitting_trenches_Cumulative", objModel.Pitting_trenches_Cumulative);
                param.Add("@Pitting_trenches_Dimension", objModel.Pitting_trenches_Dimension);
                param.Add("@Pitting_Excavation1_Beginning", objModel.Pitting_Excavation1_Beginning);
                param.Add("@Pitting_Excavation1_During", objModel.Pitting_Excavation1_During);
                param.Add("@Pitting_Excavation1_Cumulative", objModel.Pitting_Excavation1_Cumulative);
                param.Add("@Pitting_Excavation1_Dimension", objModel.Pitting_Excavation1_Dimension);
                param.Add("@Pitting_Length_Beginning", objModel.Pitting_Length_Beginning);
                param.Add("@Pitting_Length_During", objModel.Pitting_Length_During);
                param.Add("@Pitting_Length_Cumulative", objModel.Pitting_Length_Cumulative);
                param.Add("@Pitting_Length_Dimension", objModel.Pitting_Length_Dimension);
                param.Add("@Expenditure_Beginning", objModel.Expenditure_Beginning);
                param.Add("@Expenditure_During", objModel.Expenditure_During);
                param.Add("@Expenditure_Cumulative", objModel.Expenditure_Cumulative);
                param.Add("@Exploration_Activity", objModel.Exploration_Activity);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_Exploration", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exist..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Exploration
        /// <summary>
        /// To Get Exploration
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<Exploration> GetExploration(YearlyReturnModel yearlyReturnModel)
        {
            Exploration exploration = new Exploration();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 1);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<Exploration>("GetAnnualReturnPart5", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    exploration = result.FirstOrDefault();
                }
                return exploration;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Reserves and Resources estimated
        #region Update Reserves and Resources
        /// <summary>
        /// To Update Reserves and Resources
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateResources(ReservesAndResources objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Resources_Id", objModel.Resources_Id);
                param.Add("@AtBeginning_Proved", objModel.AtBeginning_Proved);
                param.Add("@Assessed_Proved", objModel.Assessed_Proved);
                param.Add("@Depletion_Proved", objModel.Depletion_Proved);
                param.Add("@Balance_Proved", objModel.Balance_Proved);

                param.Add("@AtBeginning_Probable1", objModel.AtBeginning_Probable1);
                param.Add("@Assessed_Probable1", objModel.Assessed_Probable1);
                param.Add("@Depletion_Probable1", objModel.Depletion_Probable1);
                param.Add("@Balance_Probable1", objModel.Balance_Probable1);

                param.Add("@AtBeginning_Probable2", objModel.AtBeginning_Probable2);
                param.Add("@Assessed_Probable2", objModel.Assessed_Probable2);
                param.Add("@Depletion_Probable2", objModel.Depletion_Probable2);
                param.Add("@Balance_Probable2", objModel.Balance_Probable2);

                param.Add("@AtBeginning_TotalReserves", objModel.AtBeginning_TotalReserves);
                param.Add("@Assessed_TotalReserves", objModel.Assessed_TotalReserves);
                param.Add("@Depletion_TotalReserves", objModel.Depletion_TotalReserves);
                param.Add("@Balance_TotalReserves", objModel.Balance_TotalReserves);

                param.Add("@AtBeginning_Feasibility", objModel.AtBeginning_Feasibility);
                param.Add("@Assessed_Feasibility", objModel.Assessed_Feasibility);
                param.Add("@Depletion_Feasibility", objModel.Depletion_Feasibility);
                param.Add("@Balance_Feasibility", objModel.Balance_Feasibility);

                param.Add("@AtBeginning_Prefeasibility1", objModel.AtBeginning_Prefeasibility1);
                param.Add("@Assessed_Prefeasibility1", objModel.Assessed_Prefeasibility1);
                param.Add("@Depletion_Prefeasibility1", objModel.Depletion_Prefeasibility1);
                param.Add("@Balance_Prefeasibility1", objModel.Balance_Prefeasibility1);

                param.Add("@AtBeginning_Prefeasibility2", objModel.AtBeginning_Prefeasibility2);
                param.Add("@Assessed_Prefeasibility2", objModel.Assessed_Prefeasibility2);
                param.Add("@Depletion_Prefeasibility2", objModel.Depletion_Prefeasibility2);
                param.Add("@Balance_Prefeasibility2", objModel.Balance_Prefeasibility2);

                param.Add("@AtBeginning_Measured", objModel.AtBeginning_Measured);
                param.Add("@Assessed_Measured", objModel.Assessed_Measured);
                param.Add("@Depletion_Measured", objModel.Depletion_Measured);
                param.Add("@Balance_Measured", objModel.Balance_Measured);

                param.Add("@AtBeginning_Indicated", objModel.AtBeginning_Indicated);
                param.Add("@Assessed_Indicated", objModel.Assessed_Indicated);
                param.Add("@Depletion_Indicated", objModel.Depletion_Indicated);
                param.Add("@Balance_Indicated", objModel.Balance_Indicated);

                param.Add("@AtBeginning_Inferred", objModel.AtBeginning_Inferred);
                param.Add("@Assessed_Inferred", objModel.Assessed_Inferred);
                param.Add("@Depletion_Inferred", objModel.Depletion_Inferred);
                param.Add("@Balance_Inferred", objModel.Balance_Inferred);

                param.Add("@AtBeginning_Reconnaissance", objModel.AtBeginning_Reconnaissance);
                param.Add("@Assessed_Reconnaissance", objModel.Assessed_Reconnaissance);
                param.Add("@Depletion_Reconnaissance", objModel.Depletion_Reconnaissance);
                param.Add("@Balance_Reconnaissance", objModel.Balance_Reconnaissance);


                param.Add("@AtBeginning_Totalremaining", objModel.AtBeginning_Totalremaining);
                param.Add("@Assessed_Totalremaining", objModel.Assessed_Totalremaining);
                param.Add("@Depletion_Totalremaining", objModel.Depletion_Totalremaining);
                param.Add("@Balance_Totalremaining", objModel.Balance_Totalremaining);

                param.Add("@AtBeginning_Total", objModel.AtBeginning_Total);
                param.Add("@Assessed_Total", objModel.Assessed_Total);
                param.Add("@Depletion_Total", objModel.Depletion_Total);
                param.Add("@Balance_Total", objModel.Balance_Total);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturnH1_Resources", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Reserves and Resources
        /// <summary>
        /// To Add Reserves and Resources
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddResources(ReservesAndResources objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@AtBeginning_Proved", objModel.AtBeginning_Proved);
                param.Add("@Assessed_Proved", objModel.Assessed_Proved);
                param.Add("@Depletion_Proved", objModel.Depletion_Proved);
                param.Add("@Balance_Proved", objModel.Balance_Proved);

                param.Add("@AtBeginning_Probable1", objModel.AtBeginning_Probable1);
                param.Add("@Assessed_Probable1", objModel.Assessed_Probable1);
                param.Add("@Depletion_Probable1", objModel.Depletion_Probable1);
                param.Add("@Balance_Probable1", objModel.Balance_Probable1);

                param.Add("@AtBeginning_Probable2", objModel.AtBeginning_Probable2);
                param.Add("@Assessed_Probable2", objModel.Assessed_Probable2);
                param.Add("@Depletion_Probable2", objModel.Depletion_Probable2);
                param.Add("@Balance_Probable2", objModel.Balance_Probable2);

                param.Add("@AtBeginning_TotalReserves", objModel.AtBeginning_TotalReserves);
                param.Add("@Assessed_TotalReserves", objModel.Assessed_TotalReserves);
                param.Add("@Depletion_TotalReserves", objModel.Depletion_TotalReserves);
                param.Add("@Balance_TotalReserves", objModel.Balance_TotalReserves);

                param.Add("@AtBeginning_Feasibility", objModel.AtBeginning_Feasibility);
                param.Add("@Assessed_Feasibility", objModel.Assessed_Feasibility);
                param.Add("@Depletion_Feasibility", objModel.Depletion_Feasibility);
                param.Add("@Balance_Feasibility", objModel.Balance_Feasibility);

                param.Add("@AtBeginning_Prefeasibility1", objModel.AtBeginning_Prefeasibility1);
                param.Add("@Assessed_Prefeasibility1", objModel.Assessed_Prefeasibility1);
                param.Add("@Depletion_Prefeasibility1", objModel.Depletion_Prefeasibility1);
                param.Add("@Balance_Prefeasibility1", objModel.Balance_Prefeasibility1);

                param.Add("@AtBeginning_Prefeasibility2", objModel.AtBeginning_Prefeasibility2);
                param.Add("@Assessed_Prefeasibility2", objModel.Assessed_Prefeasibility2);
                param.Add("@Depletion_Prefeasibility2", objModel.Depletion_Prefeasibility2);
                param.Add("@Balance_Prefeasibility2", objModel.Balance_Prefeasibility2);

                param.Add("@AtBeginning_Measured", objModel.AtBeginning_Measured);
                param.Add("@Assessed_Measured", objModel.Assessed_Measured);
                param.Add("@Depletion_Measured", objModel.Depletion_Measured);
                param.Add("@Balance_Measured", objModel.Balance_Measured);

                param.Add("@AtBeginning_Indicated", objModel.AtBeginning_Indicated);
                param.Add("@Assessed_Indicated", objModel.Assessed_Indicated);
                param.Add("@Depletion_Indicated", objModel.Depletion_Indicated);
                param.Add("@Balance_Indicated", objModel.Balance_Indicated);

                param.Add("@AtBeginning_Inferred", objModel.AtBeginning_Inferred);
                param.Add("@Assessed_Inferred", objModel.Assessed_Inferred);
                param.Add("@Depletion_Inferred", objModel.Depletion_Inferred);
                param.Add("@Balance_Inferred", objModel.Balance_Inferred);

                param.Add("@AtBeginning_Reconnaissance", objModel.AtBeginning_Reconnaissance);
                param.Add("@Assessed_Reconnaissance", objModel.Assessed_Reconnaissance);
                param.Add("@Depletion_Reconnaissance", objModel.Depletion_Reconnaissance);
                param.Add("@Balance_Reconnaissance", objModel.Balance_Reconnaissance);


                param.Add("@AtBeginning_Totalremaining", objModel.AtBeginning_Totalremaining);
                param.Add("@Assessed_Totalremaining", objModel.Assessed_Totalremaining);
                param.Add("@Depletion_Totalremaining", objModel.Depletion_Totalremaining);
                param.Add("@Balance_Totalremaining", objModel.Balance_Totalremaining);

                param.Add("@AtBeginning_Total", objModel.AtBeginning_Total);
                param.Add("@Assessed_Total", objModel.Assessed_Total);
                param.Add("@Depletion_Total", objModel.Depletion_Total);
                param.Add("@Balance_Total", objModel.Balance_Total);


                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturnH1_Resources", param, commandType: System.Data.CommandType.StoredProcedure);
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
        #endregion

        #region Get Reserves and Resources
        /// <summary>
        /// To Get Reserves and Resources
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<ReservesAndResources> GetResources(YearlyReturnModel yearlyReturnModel)
        {
            ReservesAndResources reservesAndResources = new ReservesAndResources();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 2);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<ReservesAndResources>("GetAnnualReturnPart5", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    reservesAndResources = result.FirstOrDefault();
                }
                return reservesAndResources;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region Reject,Waste,Trees Planted/survival
        #region Update Reject Waste
        /// <summary>
        /// To Update Reject Waste
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateRejectWaste(RejectWasteTreesPlanted objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@RWT_Id", objModel.RWT_Id);
                param.Add("@Reject_AtBeginning", objModel.Reject_AtBeginning);
                param.Add("@Reject_DuringYear", objModel.Reject_DuringYear);
                param.Add("@Reject_DisposedDuringYear", objModel.Reject_DisposedDuringYear);
                param.Add("@Reject_Stacked", objModel.Reject_Stacked);
                param.Add("@Reject_AverageGrade", objModel.Reject_AverageGrade);

                param.Add("@Processed_AtBeginning", objModel.Processed_AtBeginning);
                param.Add("@Processed_DuringYear", objModel.Processed_DuringYear);
                param.Add("@Processed_DisposedDuringYear", objModel.Processed_DisposedDuringYear);
                param.Add("@Processed_Stacked", objModel.Processed_Stacked);
                param.Add("@Processed_AverageGrade", objModel.Processed_AverageGrade);

                param.Add("@Waste_AtBeginning", objModel.Waste_AtBeginning);
                param.Add("@Waste_DuringYear", objModel.Waste_DuringYear);
                param.Add("@Waste_DisposedDuringYear", objModel.Waste_DisposedDuringYear);
                param.Add("@Waste_Stacked", objModel.Waste_Stacked);
                param.Add("@Waste_AverageGrade", objModel.Waste_AverageGrade);

                param.Add("@Treesplanted_in_LeaseArea", objModel.Treesplanted_in_LeaseArea);
                param.Add("@Treesplanted_Outside_LeaseArea", objModel.Treesplanted_Outside_LeaseArea);
                param.Add("@Survivalrate_in_LeaseArea", objModel.Survivalrate_in_LeaseArea);
                param.Add("@Survivalrate_Outside_LeaseArea", objModel.Survivalrate_Outside_LeaseArea);
                param.Add("@NoOFTrees_in_LeaseArea", objModel.NoOFTrees_in_LeaseArea);
                param.Add("@NoOFTrees_Outside_LeaseArea", objModel.NoOFTrees_Outside_LeaseArea);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturnH1_RejectWasteTreesPlanted", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Reject Waste
        /// <summary>
        /// To Add Reject Waste
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddRejectWaste(RejectWasteTreesPlanted objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@Reject_AtBeginning", objModel.Reject_AtBeginning);
                param.Add("@Reject_DuringYear", objModel.Reject_DuringYear);
                param.Add("@Reject_DisposedDuringYear", objModel.Reject_DisposedDuringYear);
                param.Add("@Reject_Stacked", objModel.Reject_Stacked);
                param.Add("@Reject_AverageGrade", objModel.Reject_AverageGrade);

                param.Add("@Processed_AtBeginning", objModel.Processed_AtBeginning);
                param.Add("@Processed_DuringYear", objModel.Processed_DuringYear);
                param.Add("@Processed_DisposedDuringYear", objModel.Processed_DisposedDuringYear);
                param.Add("@Processed_Stacked", objModel.Processed_Stacked);
                param.Add("@Processed_AverageGrade", objModel.Processed_AverageGrade);

                param.Add("@Waste_AtBeginning", objModel.Waste_AtBeginning);
                param.Add("@Waste_DuringYear", objModel.Waste_DuringYear);
                param.Add("@Waste_DisposedDuringYear", objModel.Waste_DisposedDuringYear);
                param.Add("@Waste_Stacked", objModel.Waste_Stacked);
                param.Add("@Waste_AverageGrade", objModel.Waste_AverageGrade);

                param.Add("@Treesplanted_in_LeaseArea", objModel.Treesplanted_in_LeaseArea);
                param.Add("@Treesplanted_Outside_LeaseArea", objModel.Treesplanted_Outside_LeaseArea);
                param.Add("@Survivalrate_in_LeaseArea", objModel.Survivalrate_in_LeaseArea);
                param.Add("@Survivalrate_Outside_LeaseArea", objModel.Survivalrate_Outside_LeaseArea);
                param.Add("@NoOFTrees_in_LeaseArea", objModel.NoOFTrees_in_LeaseArea);
                param.Add("@NoOFTrees_Outside_LeaseArea", objModel.NoOFTrees_Outside_LeaseArea);

                param.Add("@Financial_Year", objModel.Year);
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturnH1_RejectWasteTreesPlanted", param, commandType: System.Data.CommandType.StoredProcedure);
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
        #endregion

        #region Get Reject Waste
        /// <summary>
        /// To Get Reject Waste
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<RejectWasteTreesPlanted> GetRejectWasteTreesPlanted(YearlyReturnModel yearlyReturnModel)
        {
            RejectWasteTreesPlanted rejectWasteTreesPlanted = new RejectWasteTreesPlanted();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 3);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<RejectWasteTreesPlanted>("GetAnnualReturnPart5", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    rejectWasteTreesPlanted = result.FirstOrDefault();
                }
                return rejectWasteTreesPlanted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region Details Of Mineral Treatment Plant
        #region Update Details Of Mineral
        /// <summary>
        /// To Update Details Of Mineral
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateFurnishDetails(FurnishDetails objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Furnish_Id", objModel.Furnish_Id);
                param.Add("@Mineral_Treatment", objModel.Mineral_Treatment);
                param.Add("@TonnageFeed", objModel.TonnageFeed);
                param.Add("@AverageFeed", objModel.AverageFeed);
                param.Add("@Processed_products", objModel.Processed_products);

                param.Add("@Processed_Tonnage", objModel.Processed_Tonnage);
                param.Add("@Processed_Average", objModel.Processed_Average);
                param.Add("@Co_products", objModel.Co_products);
                param.Add("@Co_products_Tonnage", objModel.Co_products_Tonnage);

                param.Add("@Co_products_Average", objModel.Co_products_Average);
                param.Add("@TonnageTailings", objModel.TonnageTailings);
                param.Add("@AverageTailings", objModel.AverageTailings);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_FurnishDetails", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Details Of Mineral
        /// <summary>
        /// To Add Details Of Mineral
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddFurnishDetails(FurnishDetails objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@Mineral_Treatment", objModel.Mineral_Treatment);
                param.Add("@TonnageFeed", objModel.TonnageFeed);
                param.Add("@AverageFeed", objModel.AverageFeed);
                param.Add("@Processed_products", objModel.Processed_products);

                param.Add("@Processed_Tonnage", objModel.Processed_Tonnage);
                param.Add("@Processed_Average", objModel.Processed_Average);
                param.Add("@Co_products", objModel.Co_products);
                param.Add("@Co_products_Tonnage", objModel.Co_products_Tonnage);

                param.Add("@Co_products_Average", objModel.Co_products_Average);
                param.Add("@TonnageTailings", objModel.TonnageTailings);
                param.Add("@AverageTailings", objModel.AverageTailings);

                param.Add("@Financial_Year", objModel.Year);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_FurnishDetails", param, commandType: System.Data.CommandType.StoredProcedure);
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
        #endregion

        #region Get Details Of Mineral
        /// <summary>
        /// To Get Details Of Mineral
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<FurnishDetails> GetFurnishDetails(YearlyReturnModel yearlyReturnModel)
        {
            FurnishDetails furnishDetails = new FurnishDetails();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 4);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<FurnishDetails>("GetAnnualReturnPart5", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    furnishDetails = result.FirstOrDefault();
                }
                return furnishDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Type Of Machinery
        #region Add Machinery
        /// <summary>
        /// To Add Machinery
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddMachineryDetails(MachineryDetails objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@TypeofMachinery", objModel.TypeofMachinery);
                param.Add("@Capacity", objModel.Capacity);
                param.Add("@Capacity_Unit", objModel.Capacity_Unit);
                param.Add("@NoofMachinery", objModel.NoofMachinery);
                param.Add("@Type_Electrical", objModel.Type_Electrical);
                param.Add("@Used_Area", objModel.Used_Area);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@Check", 1);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<int>("Usp_AnnualReturnH1_MachineryDetails", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                messageEF.Satus = newID.ToString();
                return messageEF;
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
                return messageEF;
            }
        }
        #endregion

        #region Update Machinery
        /// <summary>
        /// To Update Machinery
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateMachineryDetails(MachineryDetails objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MachineryType_Id", objModel.MachineryType_Id);
                param.Add("@TypeofMachinery", objModel.TypeofMachinery);
                param.Add("@Capacity", objModel.Capacity);
                param.Add("@Capacity_Unit", objModel.Capacity_Unit);
                param.Add("@NoofMachinery", objModel.NoofMachinery);
                param.Add("@Type_Electrical", objModel.Type_Electrical);
                param.Add("@Used_Area", objModel.Used_Area);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Check", 2);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturnH1_MachineryDetails", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                messageEF.Satus = newID.ToString();
                return messageEF;
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
                return messageEF;
            }
        }
        #endregion

        #region Delete Machinery
        /// <summary>
        /// To Delete Machinery
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteMachineryDetails(MachineryDetails objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MachineryType_Id", objModel.MachineryType_Id);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Check", 3);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturnH1_MachineryDetails", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                messageEF.Satus = newID.ToString();
                return messageEF;
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
                return messageEF;
            }
        }
        #endregion

        #region Machinery Details
        /// <summary>
        /// To Get Machinery Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<List<MachineryDetails>> GetMachineryDetails(YearlyReturnModel yearlyReturnModel)
        {
            List<MachineryDetails> lstMachineryDetails = new List<MachineryDetails>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 1);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<MachineryDetails>("Usp_Machinery_Treatment", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstMachineryDetails = result.ToList();
                }
                return lstMachineryDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Type Of Machinery
        /// <summary>
        /// To Get Type Of Machinery Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<List<TypeOfMachinery>> GetTypeOfMachineryDetails(YearlyReturnModel yearlyReturnModel)
        {
            List<TypeOfMachinery> lstTypeOfMachinery = new List<TypeOfMachinery>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 6);
                var result =await Connection.QueryAsync<TypeOfMachinery>("GetAnnualReturnPart1", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstTypeOfMachinery = result.ToList();
                }
                return lstTypeOfMachinery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion
        #endregion

        #region Part Six
        #region Mineral Info
        /// <summary>
        /// To Get Mineral Info
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<MineralInfo> GetMineralInfo(YearlyReturnModel yearlyReturnModel)
        {
            MineralInfo mineralInfo = new MineralInfo();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@UserId", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<MineralInfo>("Usp_LesseeMineralInfo", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    mineralInfo = result.FirstOrDefault();
                }
                return mineralInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Production and Stocks
        #region Update Production and Stocks
        /// <summary>
        /// To Update Production and Stocks
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateProductionandStocks(ProductionandStocksModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ProductionandStocks_Id", objModel.ProductionandStocks_Id);
                param.Add("@MineralId", objModel.MineralId1);
                param.Add("@Development_OS_Qty", objModel.Development_OS_Qty);
                param.Add("@Development_OS_grade", objModel.Development_OS_grade);
                param.Add("@Development_Production_Qty", objModel.Development_Production_Qty);
                param.Add("@Development_Production_grade", objModel.Development_Production_grade);
                param.Add("@Development_CS_Qty", objModel.Development_CS_Qty);
                param.Add("@Development_CS_grade", objModel.Development_CS_grade);
                param.Add("@Stoping_OS_Qty", objModel.Stoping_OS_Qty);
                param.Add("@Stoping_OS_grade", objModel.Stoping_OS_grade);
                param.Add("@Stoping_Production_Qty", objModel.Stoping_Production_Qty);
                param.Add("@Stoping_Production_grade", objModel.Stoping_Production_grade);
                param.Add("@Stoping_CS_Qty", objModel.Stoping_CS_Qty);
                param.Add("@Stoping_CS_grade", objModel.Stoping_CS_grade);
                param.Add("@OpenCastWork_OS_Qty", objModel.OpenCastWork_OS_Qty);
                param.Add("@OpenCastWork_OS_grade", objModel.OpenCastWork_OS_grade);
                param.Add("@OpenCastWork_Production_Qty", objModel.OpenCastWork_Production_Qty);
                param.Add("@OpenCastWork_Production_grade", objModel.OpenCastWork_Production_grade);
                param.Add("@OpenCastWork_CS_Qty", objModel.OpenCastWork_CS_Qty);
                param.Add("@OpenCastWork_CS_grade", objModel.OpenCastWork_CS_grade);
                param.Add("@Total_OS_Qty", objModel.Total_OS_Qty);
                param.Add("@Total_OS_grade", objModel.Total_OS_grade);
                param.Add("@Total_Production_Qty", objModel.Total_Production_Qty);
                param.Add("@Total_Production_grade", objModel.Total_Production_grade);
                param.Add("@Total_CS_Qty", objModel.Total_CS_Qty);
                param.Add("@Total_CS_grade", objModel.Total_CS_grade);
                param.Add("@ExMinePrice", objModel.ExMinePrice);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturn__ProductionandStocks", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("result");
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

        #region Add Production and Stocks
        /// <summary>
        /// To Add Production and Stocks
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddProductionandStocks(ProductionandStocksModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);

                param.Add("@MineralId", objModel.MineralId1);
                param.Add("@Development_OS_Qty", objModel.Development_OS_Qty);
                param.Add("@Development_OS_grade", objModel.Development_OS_grade);
                param.Add("@Development_Production_Qty", objModel.Development_Production_Qty);
                param.Add("@Development_Production_grade", objModel.Development_Production_grade);
                param.Add("@Development_CS_Qty", objModel.Development_CS_Qty);
                param.Add("@Development_CS_grade", objModel.Development_CS_grade);
                param.Add("@Stoping_OS_Qty", objModel.Stoping_OS_Qty);
                param.Add("@Stoping_OS_grade", objModel.Stoping_OS_grade);
                param.Add("@Stoping_Production_Qty", objModel.Stoping_Production_Qty);
                param.Add("@Stoping_Production_grade", objModel.Stoping_Production_grade);
                param.Add("@Stoping_CS_Qty", objModel.Stoping_CS_Qty);
                param.Add("@Stoping_CS_grade", objModel.Stoping_CS_grade);
                param.Add("@OpenCastWork_OS_Qty", objModel.OpenCastWork_OS_Qty);
                param.Add("@OpenCastWork_OS_grade", objModel.OpenCastWork_OS_grade);
                param.Add("@OpenCastWork_Production_Qty", objModel.OpenCastWork_Production_Qty);
                param.Add("@OpenCastWork_Production_grade", objModel.OpenCastWork_Production_grade);
                param.Add("@OpenCastWork_CS_Qty", objModel.OpenCastWork_CS_Qty);
                param.Add("@OpenCastWork_CS_grade", objModel.OpenCastWork_CS_grade);
                param.Add("@Total_OS_Qty", objModel.Total_OS_Qty);
                param.Add("@Total_OS_grade", objModel.Total_OS_grade);
                param.Add("@Total_Production_Qty", objModel.Total_Production_Qty);
                param.Add("@Total_Production_grade", objModel.Total_Production_grade);
                param.Add("@Total_CS_Qty", objModel.Total_CS_Qty);
                param.Add("@Total_CS_grade", objModel.Total_CS_grade);
                param.Add("@ExMinePrice", objModel.ExMinePrice);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@Financial_Year", objModel.Year);

                param.Add("@result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturn__ProductionandStocks", param, commandType: System.Data.CommandType.StoredProcedure);

                int newID = param.Get<int>("result");
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
        #endregion

        #region Get Production and Stocks
        /// <summary>
        /// To Get Production and Stocks
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<ProductionandStocksModel> GetProductionandStocks(YearlyReturnModel yearlyReturnModel)
        {
            ProductionandStocksModel productionandStocksModel = new ProductionandStocksModel();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Financial_Year", yearlyReturnModel.Year);
                param.Add("@Check", 1);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<ProductionandStocksModel>("USP_GetAnnualReturn_ProductionandStocks", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    productionandStocksModel = result.FirstOrDefault();
                }
                return productionandStocksModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Details of Deduction
        #region Update Details of Deduction
        /// <summary>
        /// To Update Details of Deduction
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateDetails_of_deductions(Details_of_deductions objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 4);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@DeductionMade_Id", objModel.DeductionMade_Id);
                param.Add("@Deduction_claimedType1", objModel.Deduction_claimedType1);
                param.Add("@Amount1", objModel.Amount1);
                param.Add("@Remarks1", objModel.Remarks1);

                param.Add("@Deduction_claimedType2", objModel.Deduction_claimedType2);
                param.Add("@Amount2", objModel.Amount2);
                param.Add("@Remarks2", objModel.Remarks2);

                param.Add("@Deduction_claimedType3", objModel.Deduction_claimedType3);
                param.Add("@Amount3", objModel.Amount3);
                param.Add("@Remarks3", objModel.Remarks3);

                param.Add("@Deduction_claimedType4", objModel.Deduction_claimedType4);
                param.Add("@Amount4", objModel.Amount4);
                param.Add("@Remarks4", objModel.Remarks4);

                param.Add("@Deduction_claimedType5", objModel.Deduction_claimedType5);
                param.Add("@Amount5", objModel.Amount5);
                param.Add("@Remarks5", objModel.Remarks5);

                param.Add("@Deduction_claimedType6", objModel.Deduction_claimedType6);
                param.Add("@Amount6", objModel.Amount6);
                param.Add("@Remarks6", objModel.Remarks6);

                param.Add("@Deduction_claimedType7", objModel.Deduction_claimedType7);
                param.Add("@Amount7", objModel.Amount7);
                param.Add("@Remarks7", objModel.Remarks7);

                param.Add("@TotalAmount", objModel.TotalAmount);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@CExMineSale", objModel.CExMineSale);
                param.Add("@ExMineSale", objModel.ex_mineSale);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_PartSix_Annual", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Details of Deduction
        /// <summary>
        /// To Add Details of Deduction
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddDetails_of_deductions(Details_of_deductions objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 3);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@Deduction_claimedType1", objModel.Deduction_claimedType1);
                param.Add("@Amount1", objModel.Amount1);
                param.Add("@Remarks1", objModel.Remarks1);

                param.Add("@Deduction_claimedType2", objModel.Deduction_claimedType2);
                param.Add("@Amount2", objModel.Amount2);
                param.Add("@Remarks2", objModel.Remarks2);

                param.Add("@Deduction_claimedType3", objModel.Deduction_claimedType3);
                param.Add("@Amount3", objModel.Amount3);
                param.Add("@Remarks3", objModel.Remarks3);

                param.Add("@Deduction_claimedType4", objModel.Deduction_claimedType4);
                param.Add("@Amount4", objModel.Amount4);
                param.Add("@Remarks4", objModel.Remarks4);

                param.Add("@Deduction_claimedType5", objModel.Deduction_claimedType5);
                param.Add("@Amount5", objModel.Amount5);
                param.Add("@Remarks5", objModel.Remarks5);

                param.Add("@Deduction_claimedType6", objModel.Deduction_claimedType6);
                param.Add("@Amount6", objModel.Amount6);
                param.Add("@Remarks6", objModel.Remarks6);

                param.Add("@Deduction_claimedType7", objModel.Deduction_claimedType7);
                param.Add("@Amount7", objModel.Amount7);
                param.Add("@Remarks7", objModel.Remarks7);

                param.Add("@TotalAmount", objModel.TotalAmount);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@CExMineSale", objModel.CExMineSale);
                param.Add("@ExMineSale", objModel.ex_mineSale);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_PartSix_Annual", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Details of Deduction
        /// <summary>
        /// To Get Details of Deduction
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<Details_of_deductions> GetDetails_of_deductions(YearlyReturnModel yearlyReturnModel)
        {
            Details_of_deductions details_Of_Deductions = new Details_of_deductions();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 6);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<Details_of_deductions>("Usp_GetGradewise_ROM_Annual", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    details_Of_Deductions = result.FirstOrDefault();
                }
                return details_Of_Deductions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region Reason for Increase/Decrease
        #region Update Reason for Increase/Decrease
        /// <summary>
        /// To Update Reason for Increase/Decrease
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateReasonForInDc(Reason_Inc_Dec objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 6);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Reason_Inc_Dec_Id", objModel.Reason_Inc_Dec_Id);
                param.Add("@productionIncrDecResion", objModel.productionIncrDecResion);
                param.Add("@ex_minepriceIncrDecResion", objModel.ex_minepriceIncrDecResion);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_PartSix_Annual", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Reason for Increase/Decrease
        /// <summary>
        /// To Add Reason for Increase/Decrease
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddReasonForInDc(Reason_Inc_Dec objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 5);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@productionIncrDecResion", objModel.productionIncrDecResion);
                param.Add("@ex_minepriceIncrDecResion", objModel.ex_minepriceIncrDecResion);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_PartSix_Annual", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Reason for Increase/Decrease
        /// <summary>
        /// To Get Reason for Increase/Decrease
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<Reason_Inc_Dec> GetReason_Inc_Dec(YearlyReturnModel yearlyReturnModel)
        {
            Reason_Inc_Dec reason_Inc_Dec = new Reason_Inc_Dec();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Return_Year", yearlyReturnModel.Year);
                param.Add("@Check", 7);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<Reason_Inc_Dec>("Usp_GetGradewise_ROM_Annual", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    reason_Inc_Dec = result.FirstOrDefault();
                }
                return reason_Inc_Dec;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region Recoveries at Concentrator Mill/Plant
        #region Add Recoveries
        /// <summary>
        /// To Add Recoveries
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddRecoveries(RecoveriesModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MineralId", objModel.MineralId);
                param.Add("@OS_qty", objModel.OS_qty);
                param.Add("@OS_grade", objModel.OS_grade);
                param.Add("@OreReceived_qty", objModel.OreReceived_qty);
                param.Add("@OreReceived_grade", objModel.OS_grade);//objModel.OreReceived_grade);
                param.Add("@OreTreated_qty", objModel.OreTreated_qty);
                param.Add("@OreTreated_grade", objModel.OS_grade);//objModel.OreTreated_grade);
                param.Add("@Concentrates_qty", objModel.Concentrates_qty);
                param.Add("@Concentrates_grade", objModel.OS_grade);//objModel.Concentrates_grade);
                param.Add("@Concentrates_Value", objModel.Concentrates_Value);
                param.Add("@Tailings_Qty", objModel.Tailings_Qty);
                param.Add("@Tailing_grade", objModel.OS_grade);//objModel.Tailing_grade);
                param.Add("@CS_qty", objModel.CS_qty);
                param.Add("@CS_grade", objModel.OS_grade);//objModel.CS_grade);

                param.Add("@Financial_Year", objModel.Year);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@Check", 1);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturn_Recoveries", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = param.Get<int>("Result").ToString();

            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
            }
            return messageEF;
        }
        #endregion

        #region Update Recoveries
        /// <summary>
        /// To Update Recoveries
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateRecoveries(RecoveriesModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Recoverie_Id", objModel.Recoverie_Id);
                param.Add("@MineralId", objModel.MineralId);
                param.Add("@OS_qty", objModel.OS_qty);
                param.Add("@OS_grade", objModel.OS_grade);
                param.Add("@OreReceived_qty", objModel.OreReceived_qty);
                param.Add("@OreReceived_grade", objModel.OreReceived_grade);
                param.Add("@OreTreated_qty", objModel.OreTreated_qty);
                param.Add("@OreTreated_grade", objModel.OreTreated_grade);
                param.Add("@Concentrates_qty", objModel.Concentrates_qty);
                param.Add("@Concentrates_grade", objModel.Concentrates_grade);
                param.Add("@Concentrates_Value", objModel.Concentrates_Value);
                param.Add("@Tailings_Qty", objModel.Tailings_Qty);
                param.Add("@Tailing_grade", objModel.Tailing_grade);
                param.Add("@CS_qty", objModel.CS_qty);
                param.Add("@CS_grade", objModel.CS_grade);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Check", 2);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturn_Recoveries", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = param.Get<int>("Result").ToString();
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
            }
            return messageEF;
        }
        #endregion

        #region Delete Recoveries
        /// <summary>
        /// To Delete Recoveries
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteRecoveries(RecoveriesModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Recoverie_Id", objModel.Recoverie_Id);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Check", 3);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturn_Recoveries", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = param.Get<int>("Result").ToString();
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
            }
            return messageEF;
        }
        #endregion

        #region Get Recoveries
        /// <summary>
        /// To Get Recoveries
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<RecoveriesModel>> GetRecoveries(YearlyReturnModel yearlyReturnModel)
        {
            List<RecoveriesModel> lstRecoveriesModel = new List<RecoveriesModel>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Financial_Year", yearlyReturnModel.Year);
                param.Add("@Check", 2);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<RecoveriesModel>("USP_GetAnnualReturn_ProductionandStocks", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstRecoveriesModel = result.ToList();
                }
                return lstRecoveriesModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstRecoveriesModel = null;
            }

        }
        #endregion

        #endregion

        #region Recovery at the Smelter/Mill/Plant
        #region Add Recovery at the Smelter
        /// <summary>
        /// To Add Recovery at the Smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MineralId", objModel.MineralId);
                param.Add("@OS_qty", objModel.OS_qty);
                param.Add("@OS_grade", objModel.OS_grade);
                param.Add("@Concentratesreceived_qty", objModel.Concentratesreceived_qty);
                param.Add("@Concentratesreceived_grade", objModel.Concentratesreceived_grade);
                param.Add("@Concentrates_othersources_qty", objModel.Concentrates_othersources_qty);
                param.Add("@Concentrates_othersources_grade", objModel.Concentrates_othersources_grade);
                param.Add("@Concentrates_sold_qty", objModel.Concentrates_sold_qty);
                param.Add("@Concentrates_sold_grade", objModel.Concentrates_sold_grade);
                param.Add("@Concentrates_treated_qty", objModel.Concentrates_treated_qty);
                param.Add("@Concentrates_treated_grade", objModel.Concentrates_treated_grade);
                param.Add("@CS_qty", objModel.CS_qty);
                param.Add("@CS_grade", objModel.CS_grade);
                param.Add("@Metalsrecovered_qty", objModel.Metalsrecovered_qty);
                param.Add("@Metalsrecovered_grade", objModel.Metalsrecovered_grade);
                param.Add("@Metalsrecovered_Value", objModel.Metalsrecovered_Value);
                param.Add("@Other_byproducts_qty", objModel.Other_byproducts_qty);
                param.Add("@Other_byproducts_grade", objModel.Other_byproducts_grade);
                param.Add("@Other_byproducts_Value", objModel.Other_byproducts_Value);

                param.Add("@Financial_Year", objModel.Year);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@Check", 1);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnG2_Recovery_atSmelter", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = param.Get<int>("Result").ToString();
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
            }
            return messageEF;
        }
        #endregion

        #region Update Recovery at the Smelter
        /// <summary>
        /// To Update Recovery at the Smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Recovery_atSmelter_Id", objModel.Recovery_atSmelter_Id);
                param.Add("@MineralId", objModel.MineralId);
                param.Add("@OS_qty", objModel.OS_qty);
                param.Add("@OS_grade", objModel.OS_grade);
                param.Add("@Concentratesreceived_qty", objModel.Concentratesreceived_qty);
                param.Add("@Concentratesreceived_grade", objModel.Concentratesreceived_grade);
                param.Add("@Concentrates_othersources_qty", objModel.Concentrates_othersources_qty);
                param.Add("@Concentrates_othersources_grade", objModel.Concentrates_othersources_grade);
                param.Add("@Concentrates_sold_qty", objModel.Concentrates_sold_qty);
                param.Add("@Concentrates_sold_grade", objModel.Concentrates_sold_grade);
                param.Add("@Concentrates_treated_qty", objModel.Concentrates_treated_qty);
                param.Add("@Concentrates_treated_grade", objModel.Concentrates_treated_grade);
                param.Add("@CS_qty", objModel.CS_qty);
                param.Add("@CS_grade", objModel.CS_grade);
                param.Add("@Metalsrecovered_qty", objModel.Metalsrecovered_qty);
                param.Add("@Metalsrecovered_grade", objModel.Metalsrecovered_grade);
                param.Add("@Metalsrecovered_Value", objModel.Metalsrecovered_Value);
                param.Add("@Other_byproducts_qty", objModel.Other_byproducts_qty);
                param.Add("@Other_byproducts_grade", objModel.Other_byproducts_grade);
                param.Add("@Other_byproducts_Value", objModel.Other_byproducts_Value);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Check", 2);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnG2_Recovery_atSmelter", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = param.Get<int>("Result").ToString();
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
            }
            return messageEF;
        }
        #endregion

        #region Delete Recovery at the Smelter
        /// <summary>
        /// To Delete Recovery at the Smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Recovery_atSmelter_Id", objModel.Recovery_atSmelter_Id);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Check", 3);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnG2_Recovery_atSmelter", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = param.Get<int>("Result").ToString();
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
            }
            return messageEF;
        }
        #endregion

        #region Get Recovery at the Smelter
        /// <summary>
        /// To Delete Recovery at the Smelter
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<Recovery_atSmelterModel>> GetRecoveriesSmelter(YearlyReturnModel yearlyReturnModel)
        {
            List<Recovery_atSmelterModel> lstRecovery_atSmelterModel = new List<Recovery_atSmelterModel>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Financial_Year", yearlyReturnModel.Year);
                param.Add("@Check", 3);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<Recovery_atSmelterModel>("USP_GetAnnualReturn_ProductionandStocks", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstRecovery_atSmelterModel = result.ToList();
                }
                return lstRecovery_atSmelterModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstRecovery_atSmelterModel = null;
            }
        }
        #endregion

        #endregion

        #region Sales During the month
        #region Add Sales During the month
        /// <summary>
        /// To Add Sales During the month
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddSaleProduct(SaleProductModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MineralId", objModel.MineralId);
                param.Add("@Product", objModel.Product);
                param.Add("@OS_Qty", objModel.OS_Qty);
                param.Add("@OS_Grade", objModel.OS_Grade);
                param.Add("@PlaceOfSale", objModel.PlaceOfSale);
                param.Add("@Sold_Qty", objModel.Sold_Qty);
                param.Add("@Sold_Grade", objModel.Sold_Grade);
                param.Add("@Sold_Value", objModel.Sold_Value);
                param.Add("@CS_Qty", objModel.CS_Qty);
                param.Add("@CS_Grade", objModel.CS_Grade);

                param.Add("@Financial_Year", objModel.Year);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@Check", 1);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnG2_SaleProduct", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = param.Get<int>("Result").ToString();
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
            }
            return messageEF;
        }
        #endregion

        #region Update Sales During the month
        /// <summary>
        /// To Update Sales During the month
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateSaleProduct(SaleProductModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SaleProductId", objModel.SaleProductId);
                param.Add("@MineralId", objModel.MineralId);
                param.Add("@Product", objModel.Product);
                param.Add("@OS_Qty", objModel.OS_Qty);
                param.Add("@OS_Grade", objModel.OS_Grade);
                param.Add("@PlaceOfSale", objModel.PlaceOfSale);
                param.Add("@Sold_Qty", objModel.Sold_Qty);
                param.Add("@Sold_Grade", objModel.Sold_Grade);
                param.Add("@Sold_Value", objModel.Sold_Value);
                param.Add("@CS_Qty", objModel.CS_Qty);
                param.Add("@CS_Grade", objModel.CS_Grade);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Check", 2);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnG2_SaleProduct", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = param.Get<int>("Result").ToString();
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
            }
            return messageEF;
        }
        #endregion

        #region Delete Sales During the month
        /// <summary>
        /// To Delete Sales During the month
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteSaleProduct(SaleProductModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SaleProductId", objModel.SaleProductId);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Check", 3);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnG2_SaleProduct", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = param.Get<int>("Result").ToString();
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
            }
            return messageEF;
        }
        #endregion

        #region Get Sales During the month
        /// <summary>
        /// To Get Sales During the month
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<SaleProductModel>> GetSaleProduct(YearlyReturnModel yearlyReturnModel)
        {
            List<SaleProductModel> lstSaleProductModel = new List<SaleProductModel>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Financial_Year", yearlyReturnModel.Year);
                param.Add("@Check", 4);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<SaleProductModel>("USP_GetAnnualReturn_ProductionandStocks", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstSaleProductModel = result.ToList();
                }
                return lstSaleProductModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstSaleProductModel = null;
            }
        }
        #endregion

        #region Get Mineral Grade
        /// <summary>
        /// To Get Mineral Grade
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<MineralGrade>> GetMineralGradeForTinMineral(YearlyReturnModel yearlyReturnModel)
        {
            List<MineralGrade> lstMineralGrade = new List<MineralGrade>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserId", yearlyReturnModel.UserId);
                param.Add("@Check", 6);
                var result =await Connection.QueryAsync<MineralGrade>("UspGetMineralForE_Return", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstMineralGrade = result.ToList();
                }
                return lstMineralGrade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Closing Stock
        /// <summary>
        /// To Get Closing Stock
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns> 
        public async Task<OpeningStockandDispatch> Get_G2_ClosingStock(YearlyReturnModel yearlyReturnModel)
        {
            OpeningStockandDispatch openingStockandDispatch = new OpeningStockandDispatch();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserId", yearlyReturnModel.UserId);
                param.Add("@Financial_Year", yearlyReturnModel.Year);
                param.Add("@Check", 6);
                var result =await Connection.QueryAsync<OpeningStockandDispatch>("USP_GetAnnualReturn_ProductionandStocks", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    openingStockandDispatch = result.FirstOrDefault();
                }
                if (string.IsNullOrEmpty(openingStockandDispatch.ClosingStock.ToString()))
                {
                    openingStockandDispatch.ClosingStock = 0;
                }
                return openingStockandDispatch;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Dispatch
        /// <summary>
        /// To Get Dispatch
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<OpeningStockandDispatch> GetDispatch_Form2_Annual(YearlyReturnModel yearlyReturnModel)
        {
            OpeningStockandDispatch openingStockandDispatch = new OpeningStockandDispatch();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserId", yearlyReturnModel.UserId);
                param.Add("@MineralGradeId", yearlyReturnModel.MineralGradeId);
                param.Add("@Month_Year", yearlyReturnModel.Year);
                param.Add("@TinContent", yearlyReturnModel.TinContent);
                var result =await Connection.QueryAsync<OpeningStockandDispatch>("uspGetStockG2EReturn", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    openingStockandDispatch = result.FirstOrDefault();
                }
                if (openingStockandDispatch.CS_Qty == null)
                    openingStockandDispatch.CS_Qty = 0;

                openingStockandDispatch.ClosingStock = openingStockandDispatch.CS_Qty;
                return openingStockandDispatch;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region Sales/Dispatches
        #region Add Sales/Dispatches
        /// <summary>
        /// To Add Sales/Dispatches
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@MineralId", objModel.MineralId);
                param.Add("@MineralNatureId", objModel.MineralNatureId);
                param.Add("@MineralGradeId", objModel.MineralGradeId);
                param.Add("@NatureOfDispatch", objModel.NatureofDispatch);
                param.Add("@RegistrationNo", objModel.RegistrationNo);
                param.Add("@PurchaserConsinee", objModel.PurchaserConsinee);
                param.Add("@DomesticPurpose_Quantity", objModel.DomesticPurposes_Quantity);
                param.Add("@SaleValue", objModel.SaleValue);
                param.Add("@Country", objModel.Country);
                param.Add("@Export_Quantity", objModel.Export_Quantity);
                param.Add("@FOBValue", objModel.FOBValue);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@Check", 1);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnG2_SalesDispatch", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = param.Get<int>("Result").ToString();
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
            }
            return messageEF;
        }
        #endregion

        #region Update Sales/Dispatches
        /// <summary>
        /// To Update Sales/Dispatches
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Sale_Dispatch_Id", objModel.Sale_Dispatch_Id);
                param.Add("@MineralId", objModel.MineralId);
                param.Add("@MineralNatureId", objModel.MineralNatureId);
                param.Add("@MineralGradeId", objModel.MineralGradeId);
                param.Add("@NatureOfDispatch", objModel.NatureofDispatch);
                param.Add("@RegistrationNo", objModel.RegistrationNo);
                param.Add("@PurchaserConsinee", objModel.PurchaserConsinee);
                if (objModel.DomesticPurposes_Quantity == null)
                    objModel.DomesticPurposes_Quantity = 0;
                param.Add("@DomesticPurpose_Quantity", objModel.DomesticPurposes_Quantity);
                param.Add("@SaleValue", objModel.SaleValue);
                param.Add("@Country", objModel.Country);
                param.Add("@Export_Quantity", objModel.Export_Quantity);
                param.Add("@FOBValue", objModel.FOBValue);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Check", 2);
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnG2_SalesDispatch", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = param.Get<int>("Result").ToString();
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
            }
            return messageEF;
        }
        #endregion

        #region Delete Sales/Dispatches
        /// <summary>
        /// To Delete Sales/Dispatches
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Sale_Dispatch_Id", objModel.Sale_Dispatch_Id);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@Check", 3);
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnG2_SalesDispatch", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = param.Get<int>("Result").ToString();
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
            }
            return messageEF;
        }
        #endregion

        #region Get Sales/Dispatches
        /// <summary>
        /// To Get Sales/Dispatches
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<SalesDispatchOf_OreModel>> GetSaleDispatch(YearlyReturnModel yearlyReturnModel)
        {
            List<SalesDispatchOf_OreModel> lstSalesDispatchOf_OreModel = new List<SalesDispatchOf_OreModel>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Financial_Year", yearlyReturnModel.Year);
                param.Add("@Check", 5);
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<SalesDispatchOf_OreModel>("USP_GetAnnualReturn_ProductionandStocks", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstSalesDispatchOf_OreModel = result.ToList();
                }
                return lstSalesDispatchOf_OreModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstSalesDispatchOf_OreModel = null;
            }
        }
        #endregion

        #region Get Mineral Form
        /// <summary>
        /// To Get Mineral Form
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<MineralInfo>> GetMineralForm(YearlyReturnModel yearlyReturnModel)
        {
            List<MineralInfo> lstMineralInfo = new List<MineralInfo>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MineralId", yearlyReturnModel.MineralId);
                param.Add("@UserId", yearlyReturnModel.UserId);
                param.Add("@Check", 1);
                var result =await Connection.QueryAsync<MineralInfo>("UspGetMineralForE_Return", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstMineralInfo = result.ToList();
                }
                return lstMineralInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstMineralInfo = null;
            }
        }
        #endregion

        #region Get Mineral Grade
        /// <summary>
        /// To Get Mineral Grade
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<MineralGrade>> GetMineralGrade(YearlyReturnModel yearlyReturnModel)
        {
            List<MineralGrade> lstMineralGrade = new List<MineralGrade>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserId", yearlyReturnModel.UserId);
                param.Add("@Check", 6);
                var result =await Connection.QueryAsync<MineralGrade>("UspGetMineralForE_Return", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstMineralGrade = result.ToList();
                }
                return lstMineralGrade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstMineralGrade = null;
            }
        }
        #endregion

        #region Nature Of Dispatch
        /// <summary>
        /// To Get Nature Of Dispatch
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<MineralInfo>> GetNatureOfDispatch(YearlyReturnModel yearlyReturnModel)
        {
            List<MineralInfo> lstMineralInfo = new List<MineralInfo>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<MineralInfo>("select NatureOfDispatch from NatureOfDispatch_For_eReturn", param, commandType: System.Data.CommandType.Text);
                if (result.Count() > 0)
                {
                    lstMineralInfo = result.ToList();
                }
                return lstMineralInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstMineralInfo = null;
            }
        }
        #endregion

        #region Purchaser Consignee
        /// <summary>
        /// To Get Purchaser Consignee
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<List<MineralInfo>> GetPurchaserConsignee(YearlyReturnModel yearlyReturnModel)
        {
            List<MineralInfo> lstMineralInfo = new List<MineralInfo>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserId", yearlyReturnModel.UserId);
                param.Add("@Check", 2);
                var result =await Connection.QueryAsync<MineralInfo>("Usp_GetSaleDispatch", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstMineralInfo = result.ToList();
                }
                return lstMineralInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstMineralInfo = null;
            }
        }
        #endregion

        #endregion

        #endregion

        #region Part Seven
        #region Update CostOfProduction
        /// <summary>
        /// To Update Cost Of Production
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateCostOfProduction(CostOfProduction_Annual objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@ModifiedBy", objModel.UserId);
                param.Add("@CostOfProduction_Id", objModel.CostOfProduction_Id);
                param.Add("@Exploration", objModel.Exploration);
                param.Add("@Mining", objModel.Mining);
                param.Add("@Beneficiation", objModel.Beneficiation);
                param.Add("@Over_headcost", objModel.Over_headcost);
                param.Add("@Depreciation", objModel.Depreciation);
                param.Add("@Interest", objModel.Interest);
                param.Add("@Royalty", objModel.Royalty);
                param.Add("@DMF", objModel.DMF);
                param.Add("@NMET", objModel.NMET);
                param.Add("@Dead_Rent", objModel.Dead_Rent);
                param.Add("@Taxes", objModel.Taxes);
                param.Add("@Others", objModel.Others);
                param.Add("@Total", objModel.Total);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_CostOfProduction", param, commandType: System.Data.CommandType.StoredProcedure);
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

        #region Add Cost Of Production
        /// <summary>
        /// To Add Cost Of Production
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddCostOfProduction(CostOfProduction_Annual objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 1);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@Exploration", objModel.Exploration);
                param.Add("@Mining", objModel.Mining);
                param.Add("@Beneficiation", objModel.Beneficiation);
                param.Add("@Over_headcost", objModel.Over_headcost);
                param.Add("@Depreciation", objModel.Depreciation);
                param.Add("@Interest", objModel.Interest);
                param.Add("@Royalty", objModel.Royalty);
                param.Add("@DMF", objModel.DMF);
                param.Add("@NMET", objModel.NMET);
                param.Add("@Dead_Rent", objModel.Dead_Rent);
                param.Add("@Taxes", objModel.Taxes);
                param.Add("@Others", objModel.Others);
                param.Add("@Total", objModel.Total);
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@certify", objModel.certify);

                param.Add("@Result", DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("USP_AnnualReturnH1_CostOfProduction", param, commandType: System.Data.CommandType.StoredProcedure);
                int newID = param.Get<int>("Result");
                if (newID == 2)
                {
                    messageEF.Satus = "This Details Already Exit..";
                }
                else if (newID == 1)
                {
                    messageEF.Satus = "Record has been Saved";
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Final Submit Cost Of Production
        /// <summary>
        /// To Final Submit Cost Of Production
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> Update_FinalSubmit(CostOfProduction_Annual objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters(); 
                param.Add("@Financial_Year", objModel.Year);
                param.Add("@CreatedBy", objModel.UserId);
                param.Add("@Result",DbType.Int32,direction:ParameterDirection.Output);
                var result =await Connection.QueryAsync<int>("Usp_AnnualReturn_MajorMinerals_FinalSubmit",param,commandType:System.Data.CommandType.StoredProcedure);
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Cost Of Production
        /// <summary>
        /// To Get Cost Of Production
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public async Task<CostOfProduction_Annual> GetCostOfProduction(YearlyReturnModel yearlyReturnModel)
        {
            CostOfProduction_Annual costOfProduction_Annual = new CostOfProduction_Annual();
            try
            {
                DynamicParameters param = new DynamicParameters(); 
                param.Add("@Return_Year", yearlyReturnModel.Year); 
                param.Add("@UserID", yearlyReturnModel.UserId);
                var result =await Connection.QueryAsync<CostOfProduction_Annual>("GetAnnualReturnPart7",param,commandType:System.Data.CommandType.StoredProcedure);
                if(result.Count()>0)
                {
                    costOfProduction_Annual = result.FirstOrDefault();
                }
                return costOfProduction_Annual;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

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
