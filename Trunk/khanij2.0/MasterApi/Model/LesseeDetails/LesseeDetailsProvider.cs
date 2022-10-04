// ***********************************************************************
//  Class Name               : LesseeDetailsProvider
//  Desciption               : Lessee Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 July 2021
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

namespace MasterApi.Model.LesseeDetails
{
    public class LesseeDetailsProvider : RepositoryBase, ILesseeDetailsProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LesseeDetailsProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To bind Lessee Profile Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public LesseeInfoModel GetLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel)
        {
            LesseeInfoModel ObjLesseeDetails = new LesseeInfoModel();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeInfoModel.CREATED_BY,
                    SP_MODE = "GETDATA"
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<LesseeInfoModel>("[USP_CRUD_LESSEEPROFILEDETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLesseeDetails = result.FirstOrDefault();
                }
                return ObjLesseeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Lessee Type Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public List<LesseeInfoModel> GetLesseeTypeList(LesseeInfoModel objLesseeInfoModel)
        {
            List<LesseeInfoModel> ObjLesseeTypeList = new List<LesseeInfoModel>();
            try
            {
                var paramList = new
                {
                    Check = "0"
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<LesseeInfoModel>("GetLesseeLicenseeTypeMasters", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLesseeTypeList = result.ToList();
                }
                return ObjLesseeTypeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Auction Type Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public List<LesseeInfoModel> GetAuctionTypeList(LesseeInfoModel objLesseeInfoModel)
        {
            List<LesseeInfoModel> ObjAuctionypeList = new List<LesseeInfoModel>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<LesseeInfoModel>("[USP_GET_AUCTION_APPLICATIONTYPE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjAuctionypeList = result.ToList();
                }
                return ObjAuctionypeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update Lesse Profile details
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public MessageEF UpdateLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("USER_ID", objLesseeInfoModel.CREATED_BY);
                p.Add("SP_MODE", "SAVEDATA");
                p.Add("APPLICATION_TYPE_ID", objLesseeInfoModel.APPLICATION_TYPE_ID);
                p.Add("APPLICATION_NUMBER", objLesseeInfoModel.APPLICATION_NUMBER);
                p.Add("MINE_CODE", objLesseeInfoModel.MINE_CODE);
                //------------------------------------------------------------------//
                p.Add("APPLICATION_FORM_COPY_FILE_PATH", objLesseeInfoModel.APPLICATION_FORM_FILE_PATH);
                p.Add("APPLICATION_FORM_COPY_FILE_NAME", objLesseeInfoModel.APPLICATION_FORM_FILE_NAME);
                p.Add("RECONNAISSANCE_LICENSE_NAME", objLesseeInfoModel.RECONNAISSANCE_LICENSE_NAME);
                p.Add("RECONNAISSANCE_LICENSE_ADDRESS", objLesseeInfoModel.RECONNAISSANCE_LICENSE_ADDRESS);
                p.Add("PROSPECTING_VALIDITY_FROM", objLesseeInfoModel.PROSPECTING_VALIDITY_FROM);
                p.Add("PROSPECTING_VALIDITY_TO", objLesseeInfoModel.PROSPECTING_VALIDITY_TO);
                p.Add("PAN_CARD_NO", objLesseeInfoModel.PAN_CARD_NO);
                p.Add("PAN_CARD_COPY_FILE_PATH", objLesseeInfoModel.PAN_CARD_COPY_FILE_PATH);
                p.Add("PAN_CARD_COPY_FILE_NAME", objLesseeInfoModel.PAN_CARD_COPY_FILE_NAME);
                p.Add("ADHAR_CARD", objLesseeInfoModel.ADHAR_CARD);
                p.Add("ADHAR_CARD_SCAN_COPY_FILE_PATH", objLesseeInfoModel.ADHAR_CARD_SCAN_COPY_FILE_PATH);
                p.Add("ADHAR_CARD_SCAN_COPY_FILE_NAME", objLesseeInfoModel.ADHAR_CARD_SCAN_COPY_FILE_NAME);
                p.Add("TIN_CARD", objLesseeInfoModel.TIN_CARD);
                p.Add("TIN_CARD_SCAN_COPY_FILE_PATH", objLesseeInfoModel.TIN_CARD_SCAN_COPY_FILE_PATH);
                p.Add("TIN_CARD_SCAN_COPY_FILE_NAME", objLesseeInfoModel.TIN_CARD_SCAN_COPY_FILE_NAME);
                p.Add("FIRMREGISTRATION_DEED_NUMBER", objLesseeInfoModel.FIRMREGISTRATION_DEED_NUMBER);
                p.Add("FIRM_REGISTRATION_DEED_FILE_PATH", objLesseeInfoModel.FIRM_REGISTRATION_DEED_FILE_PATH);
                p.Add("FIRM_REGISTRATION_DEED_FILE_NAME", objLesseeInfoModel.FIRM_REGISTRATION_DEED_FILE_NAME);
                p.Add("CERTIFICATE_OF_INCORPORATION_NUMBER", objLesseeInfoModel.CERTIFICATE_OF_INCORPORATION_NUMBER);
                p.Add("CERTIFICATE_OF_INCORPORATION_DOC_FILE_PATH", objLesseeInfoModel.CERTIFICATE_OF_INCORPORATION_DOC_FILE_PATH);
                p.Add("CERTIFICATE_OF_INCORPORATION_DOC_FILE_NAME", objLesseeInfoModel.CERTIFICATE_OF_INCORPORATION_DOC_FILE_NAME);
                p.Add("AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_PATH", objLesseeInfoModel.AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_PATH);
                p.Add("AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_NAME", objLesseeInfoModel.AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_NAME);
                p.Add("POWER_OF_ATORNY_FILE_PATH", objLesseeInfoModel.POWER_OF_ATORNY_FILE_PATH);
                p.Add("POWER_OF_ATORNY_FILE_NAME", objLesseeInfoModel.POWER_OF_ATORNY_FILE_NAME);
                p.Add("MAP_PLAN_OF_APPLIED_AREA_FILE_PATH", objLesseeInfoModel.MAP_PLAN_OF_APPLIED_AREA_FILE_PATH);
                p.Add("MAP_PLAN_OF_APPLIED_AREA_FILE_NAME", objLesseeInfoModel.MAP_PLAN_OF_APPLIED_AREA_FILE_NAME);
                p.Add("KHASARA_PANCHSALA_FILE_PATH", objLesseeInfoModel.KHASARA_PANCHSALA_FILE_PATH);
                p.Add("KHASARA_PANCHSALA_FILE_NAME", objLesseeInfoModel.KHASARA_PANCHSALA_FILE_NAME);
                p.Add("REVENUE_OFFICER_REPORT_FILE_PATH", objLesseeInfoModel.REVENUE_OFFICER_REPORT_FILE_PATH);
                p.Add("REVENUE_OFFICER_REPORT_FILE_NAME", objLesseeInfoModel.REVENUE_OFFICER_REPORT_FILE_NAME);
                p.Add("FOREST_REPORT_FILE_PATH", objLesseeInfoModel.FOREST_REPORT_FILE_PATH);
                p.Add("FOREST_REPORT_FILE_NAME", objLesseeInfoModel.FOREST_REPORT_FILE_NAME);
                p.Add("MINING_INSPECTOR_REPORT_FILE_PATH", objLesseeInfoModel.MINING_INSPECTOR_REPORT_FILE_PATH);
                p.Add("MINING_INSPECTOR_REPORT_FILE_NAME", objLesseeInfoModel.MINING_INSPECTOR_REPORT_FILE_NAME);
                p.Add("SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_PATH", objLesseeInfoModel.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_PATH);
                p.Add("SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_NAME", objLesseeInfoModel.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_NAME);
                p.Add("GRAM_PANCHAYAT_PROPOSAL_FILE_PATH", objLesseeInfoModel.GRAM_PANCHAYAT_PROPOSAL_FILE_PATH);
                p.Add("GRAM_PANCHAYAT_PROPOSAL_FILE_NAME", objLesseeInfoModel.GRAM_PANCHAYAT_PROPOSAL_FILE_NAME);
                p.Add("APPLICATION_FEES", objLesseeInfoModel.APPLICATION_FEES);
                if (objLesseeInfoModel.APPLICATION_FEES_DATE != null)
                {
                    p.Add("APPLICATION_FEES_DATE", Convert.ToDateTime(objLesseeInfoModel.APPLICATION_FEES_DATE).ToString("dd/MM/yyyy"));
                }
                p.Add("APPLICATION_FEES_COPY_FILE_PATH", objLesseeInfoModel.APPLICATION_FEES_COPY_FILE_PATH);
                p.Add("APPLICATION_FEES_COPY_FILE_NAME", objLesseeInfoModel.APPLICATION_FEES_COPY_FILE_NAME);
                p.Add("CHALLAN_DD_AMOUNT", objLesseeInfoModel.CHALLAN_DD_AMOUNT);
                if (objLesseeInfoModel.CHALLAN_DD_AMOUNT_DATE != null)
                {
                    p.Add("CHALLAN_DD_AMOUNT_DATE", Convert.ToDateTime(objLesseeInfoModel.CHALLAN_DD_AMOUNT_DATE).ToString("dd/MM/yyyy"));
                }
                p.Add("CHALLAN_DD_AMOUNT_COPY_FILE_PATH", objLesseeInfoModel.CHALLAN_DD_AMOUNT_COPY_FILE_PATH);
                p.Add("CHALLAN_DD_AMOUNT_COPY_FILE_NAME", objLesseeInfoModel.CHALLAN_DD_AMOUNT_COPY_FILE_NAME);
                p.Add("BANK_GUARRANTEE_AMOUNT", objLesseeInfoModel.BANK_GUARRANTEE_AMOUNT);
                if (objLesseeInfoModel.BANK_GUARRANTEE_DATE != null)
                {
                    p.Add("BANK_GUARRANTEE_DATE", Convert.ToDateTime(objLesseeInfoModel.BANK_GUARRANTEE_DATE).ToString("dd/MM/yyyy"));
                }
                p.Add("BANK_GUARRANTEE_COPY_FILE_PATH", objLesseeInfoModel.BANK_GUARRANTEE_COPY_FILE_PATH);
                p.Add("BANK_GUARRANTEE_COPY_FILE_NAME", objLesseeInfoModel.BANK_GUARRANTEE_COPY_FILE_NAME);
                p.Add("SURITY_BOND_AMOUNT", objLesseeInfoModel.SURITY_BOND_AMOUNT);
                if (objLesseeInfoModel.SURITY_BOND_DATE != null)
                {
                    p.Add("SURITY_BOND_DATE", Convert.ToDateTime(objLesseeInfoModel.SURITY_BOND_DATE).ToString("dd/MM/yyyy"));
                }
                p.Add("SURITY_BOND_COPY_FILE_PATH", objLesseeInfoModel.SURITY_BOND_COPY_FILE_PATH);
                p.Add("SURITY_BOND_COPY_FILE_NAME", objLesseeInfoModel.SURITY_BOND_COPY_FILE_NAME);
                p.Add("STATUS", objLesseeInfoModel.STATUS);
                p.Add("TRANSFER_GRANT_ORDER_COPY_FILE_NAME", objLesseeInfoModel.TRANSFER_GRANT_ORDER_COPY_FILE_NAME);
                p.Add("TRANSFER_GRANT_ORDER_COPY_FILE_PATH", objLesseeInfoModel.TRANSFER_GRANT_ORDER_COPY_FILE_PATH);
                p.Add("TRANSFER_LEASE_DEED_COPY_FILE_NAME", objLesseeInfoModel.TRANSFER_LEASE_DEED_COPY_FILE_NAME);
                p.Add("TRANSFER_LEASE_DEED_COPY_FILE_PATH", objLesseeInfoModel.TRANSFER_LEASE_DEED_COPY_FILE_PATH);
                p.Add("NAME_OF_TRANSFEREE", objLesseeInfoModel.NAME_OF_TRANSFEREE);
                p.Add("ADDRESS_OF_TRANSFEREE", objLesseeInfoModel.ADDRESS_OF_TRANSFEREE);
                p.Add("DATE_OF_TRANSFER", objLesseeInfoModel.DATE_OF_TRANSFER);
                p.Add("UpfrontPaymentDeposited", objLesseeInfoModel.UpfrontPaymentDeposited);
                p.Add("TillDateBalanceUpfrontPayment", objLesseeInfoModel.TillDateBalanceUpfrontPayment);
                p.Add("IsInterNetConnectionAtDistpatch", objLesseeInfoModel.IsInterNetConnectionAtDistpatch);               
                p.Add("MonthlyPeriodAmountRate", objLesseeInfoModel.MonthlyPeriodicAmtRate);
                p.Add("FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_NAME", objLesseeInfoModel.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_NAME);
                p.Add("FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_PATH", objLesseeInfoModel.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_PATH);
                p.Add("File_Minor_Mineral", objLesseeInfoModel.MinorMineralFormAttachment_FILE);
                p.Add("Path_Minor_Mineral", objLesseeInfoModel.MinorMineralFormAttachment_PATH);             
                p.Add("File_FinancialAssurance", objLesseeInfoModel.FinancialAssuranceAttachment_FILE);
                p.Add("Path_FinancialAssurance", objLesseeInfoModel.FinancialAssuranceAttachment_PATH);                                        
                p.Add("SecurityDeposit", objLesseeInfoModel.SecurityDeposit);
                p.Add("FinancialAmountAssurance", objLesseeInfoModel.FinancialAmountAssurance);                  
                p.Add("StorageCrusher", objLesseeInfoModel.StorageCrusher);
                if (objLesseeInfoModel.StorageCrusher == "No")
                {
                    objLesseeInfoModel.CrusherInstalled = "";
                }
                p.Add("CrusherInstalled", objLesseeInfoModel.CrusherInstalled);
                if (objLesseeInfoModel.CrusherInstalled == "Yes")
                {
                    objLesseeInfoModel.StorageCrusherAttachment_FILE = "";
                    objLesseeInfoModel.StorageCrusherAttachment_PATH = "";
                }
                p.Add("File_StorageCrusher", objLesseeInfoModel.StorageCrusherAttachment_FILE);
                p.Add("Path_StorageCrusher", objLesseeInfoModel.StorageCrusherAttachment_PATH);
                p.Add("AdjustCessFromRoyalty", objLesseeInfoModel.AdjustCess);
                if(objLesseeInfoModel.AdjustCess=="No")
                {
                    objLesseeInfoModel.OrderOf = "0";
                    objLesseeInfoModel.OrderNo = "0";
                    objLesseeInfoModel.OrderAttachment_File = "";
                    objLesseeInfoModel.OrderAttachment_Path = "";
                }
                p.Add("OrderNo", objLesseeInfoModel.OrderNo);
                p.Add("OrderOf", objLesseeInfoModel.OrderOf);
                p.Add("OrderDate", objLesseeInfoModel.OrderDate);
                p.Add("OrderAttachment_File", objLesseeInfoModel.OrderAttachment_File);
                p.Add("OrderAttachment_Path", objLesseeInfoModel.OrderAttachment_Path);
                string mineralid = "";
                if (objLesseeInfoModel.MineralCount != null)
                {
                    if (objLesseeInfoModel.MineralCount.Count > 0)
                    {
                        for (int i = 0; i < objLesseeInfoModel.MineralCount.Count; i++)
                        {
                            mineralid += objLesseeInfoModel.MineralCount[i].ToString();
                            mineralid += ",";
                        }
                    }
                }
                p.Add("AuctionTypeId", objLesseeInfoModel.AuctionTypeId);
                if(objLesseeInfoModel.AuctionTypeId!=2)
                {
                    objLesseeInfoModel.BidPremium = 0;
                    objLesseeInfoModel.MonthlyPeriodicAmt ="0";
                    objLesseeInfoModel.AmountOfDD = 0;
                    objLesseeInfoModel.PaymentModeType = "";
                    objLesseeInfoModel.PerformanceSecurity_FILE = "";
                    objLesseeInfoModel.PerformanceSecurity_PATH = "";
                }
                p.Add("MINERAL_ID_LIST", mineralid);
                p.Add("WBInstalled", objLesseeInfoModel.WBInstalled);
                if (objLesseeInfoModel.WBInstalled == "1")
                {
                    p.Add("WBStampDate", objLesseeInfoModel.WBStampDate);
                    p.Add("WBValidUpto", objLesseeInfoModel.WBValidUpto);
                }
                p.Add("WBExemption_FILE", objLesseeInfoModel.WBExemption_FILE);
                p.Add("WBExemption_PATH", objLesseeInfoModel.WBExemption_PATH);
                p.Add("LabEstablished", objLesseeInfoModel.LabEstablished);
                if(objLesseeInfoModel.LabEstablished=="2")
                {
                    objLesseeInfoModel.LabExemption_FILE = "";
                    objLesseeInfoModel.LabExemption_PATH = "";
                }
                p.Add("LabExemption_FILE", objLesseeInfoModel.LabExemption_FILE);
                p.Add("LabExemption_PATH", objLesseeInfoModel.LabExemption_PATH);
                p.Add("LeasePurpose", objLesseeInfoModel.LeasePurpose);
                p.Add("Remarks", objLesseeInfoModel.Remarks);
                p.Add("MonthlyPeriodicAmount", objLesseeInfoModel.MonthlyPeriodicAmt);
                p.Add("BidPremium", objLesseeInfoModel.BidPremium);
                p.Add("PaymentModeType", objLesseeInfoModel.PaymentModeType);
                if (objLesseeInfoModel.PaymentModeType == "BG")
                {
                    objLesseeInfoModel.AmountOfDD = 0;
                }
                p.Add("BG_ValidityUpto", objLesseeInfoModel.BG_ValidityUpto);
                p.Add("AmountOfDD", objLesseeInfoModel.AmountOfDD);
                p.Add("File_PerformanceSecurity", objLesseeInfoModel.PerformanceSecurity_FILE);
                p.Add("Path_PerformanceSecurity", objLesseeInfoModel.PerformanceSecurity_PATH);
                if (objLesseeInfoModel.BANK_GUARRANTEE_VALIDITY != null)
                {
                    p.Add("BANK_GUARRANTEE_VALIDITY", Convert.ToDateTime(objLesseeInfoModel.BANK_GUARRANTEE_VALIDITY).ToString("dd/MM/yyyy"));
                }
                if (objLesseeInfoModel.dtCaptive != null && objLesseeInfoModel.dtCaptive.Rows.Count > 0)
                {
                    p.Add("BULK_PRODUCTION", objLesseeInfoModel.dtCaptive, DbType.Object);
                }
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_CRUD_LESSEEPROFILEDETAILS", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// To bind Lessee Profile Log Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public List<LesseeInfoModel> GetLesseeProfileLogList(LesseeInfoModel objLesseeInfoModel)
        {
            List<LesseeInfoModel> ObjLesseeTypeList = new List<LesseeInfoModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeInfoModel.CREATED_BY,
                    SP_MODE = "GETLOGDATA"
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<LesseeInfoModel>("USP_CRUD_LESSEEPROFILEDETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLesseeTypeList = result.ToList();
                }
                return ObjLesseeTypeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Lessee Profile Request Data in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public List<LesseeProfileRequestModel> GetLesseeProfileRequestData(LesseeProfileRequestModel objLesseeProfileRequestModel)
        {
            List<LesseeProfileRequestModel> ObjLesseeProfileRequestList = new List<LesseeProfileRequestModel>();
            try
            {
                var paramList = new
                {
                    REQUEST = objLesseeProfileRequestModel.REQUEST,
                    UserID = objLesseeProfileRequestModel.USER_ID,
                    LesseeUserId = objLesseeProfileRequestModel.ID
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<LesseeProfileRequestModel>("[USP_LESSEE_PROFILE_APPROVAL_REQUEST_GRID]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLesseeProfileRequestList = result.ToList();
                }
                return ObjLesseeProfileRequestList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Last approved Lessee Profile Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public List<LesseeInfoModel> GetLesseeProfileCompareDetails(LesseeInfoModel objLesseeInfoModel)
        {
            List<LesseeInfoModel> ObjLesseeDetails = new List<LesseeInfoModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeInfoModel.CREATED_BY,
                    SP_MODE = "COMPARE"
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<LesseeInfoModel>("[USP_CRUD_LESSEEPROFILEDETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLesseeDetails = result.ToList();
                }
                return ObjLesseeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Profile details by DD
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("APPROVED_BY", objLesseeInfoModel.UserId);
                p.Add("SP_MODE", "APPROVE");
                p.Add("MonthlyPeriodicAmount", objLesseeInfoModel.MonthlyPeriodicAmt);
                p.Add("MonthlyPeriodAmountRate", objLesseeInfoModel.MonthlyPeriodicAmtRate);
                p.Add("OrderNo", objLesseeInfoModel.OrderNo);
                p.Add("OrderOf", objLesseeInfoModel.OrderOf);
                p.Add("USER_ID", objLesseeInfoModel.CREATED_BY);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_CRUD_LESSEEPROFILEDETAILS", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// To Reject Lesse Profile details by DD
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("REJECTED_BY", objLesseeInfoModel.UserId);
                p.Add("SP_MODE", "REJECT");
                p.Add("MonthlyPeriodicAmount", objLesseeInfoModel.MonthlyPeriodicAmt);
                p.Add("Remarks", objLesseeInfoModel.MonthlyPeriodicAmtRate);
                p.Add("USER_ID", objLesseeInfoModel.CREATED_BY);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_CRUD_LESSEEPROFILEDETAILS", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// To Delete Lesse Profile details
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "DELETE");
                p.Add("USER_ID", objLesseeInfoModel.CREATED_BY);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_CRUD_LESSEEPROFILEDETAILS]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// To Bind the User Type Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeInfoModel>> GetUserTypeList(LesseeInfoModel objLesseeInfoModel)
        {
            List<LesseeInfoModel> ObjAuctionypeList = new List<LesseeInfoModel>();
            try
            {
                var paramList = new
                {
                    ACTION="R"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeInfoModel>("[USP_FILL_COMMON_DATA]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjAuctionypeList = result.ToList();
                }
                return ObjAuctionypeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the User Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeInfoModel>> GetUserList(LesseeInfoModel objLesseeInfoModel)
        {
            List<LesseeInfoModel> ObjAuctionypeList = new List<LesseeInfoModel>();
            try
            {
                var paramList = new
                {
                    ACTION="S",
                    UserTypeId=objLesseeInfoModel.UserTypeId,
                    StateId=objLesseeInfoModel.StateId,
                    DistrictId =objLesseeInfoModel.DistrictId
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeInfoModel>("[USP_FILL_COMMON_DATA]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjAuctionypeList = result.ToList();
                }
                return ObjAuctionypeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Captive Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeInfoModel>> GetCaptiveList(LesseeInfoModel objLesseeInfoModel)
        {
            List<LesseeInfoModel> ObjList = new List<LesseeInfoModel>();
            try
            {
                var paramList = new
                {
                    SP_MODE = "GETCAPTIVE",
                    USER_ID= objLesseeInfoModel.CREATED_BY
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeInfoModel>("USP_CRUD_LESSEEPROFILEDETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjList = result.ToList();
                }
                return ObjList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To bind Captive purpose details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public async Task<List<CaptivePurposeModel>> GetPurposeDetails(CaptivePurposeModel objLesseeInfoModel)
        {
            List<CaptivePurposeModel> Objlist = new List<CaptivePurposeModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeInfoModel.CREATED_BY,
                    SP_MODE = "GETPURPOSE"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<CaptivePurposeModel>("[USP_CRUD_LESSEEPROFILEDETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    Objlist = result.ToList();
                }
                return Objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Lessee Captive purpose log details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeInfoModel>> GetCaptivePurposeLogDetails(LesseeInfoModel objLesseeInfoModel)
        {
            List<LesseeInfoModel> ObjECLogDetails = new List<LesseeInfoModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeInfoModel.CREATED_BY,
                    SP_MODE = "GETPURPOSELOG"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeInfoModel>("[USP_CRUD_LESSEEPROFILEDETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjECLogDetails = result.ToList();
                }
                return ObjECLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Captive purpose log history details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeInfoModel>> GetCaptivePurposeLogDetailsView(LesseeInfoModel objLesseeInfoModel)
        {
            List<LesseeInfoModel> ObjECLogDetails = new List<LesseeInfoModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeInfoModel.CREATED_BY,
                    MODIFIED_ON = objLesseeInfoModel.MODIFIED_ON,
                    APPLICATION_ID = objLesseeInfoModel.APPLICATION_ID,
                    STATUS = objLesseeInfoModel.STATUS,
                    SP_MODE = "GETPURPOSELOGHISTORY"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeInfoModel>("[USP_CRUD_LESSEEPROFILEDETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjECLogDetails = result.ToList();
                }
                return ObjECLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Captive purpose compare details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public async Task<List<CaptivePurposeModel>> GetCaptivePurposeLogDetailsCompareDetails(CaptivePurposeModel objLesseeInfoModel)
        {
            List<CaptivePurposeModel> ObjECLogDetails = new List<CaptivePurposeModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeInfoModel.CREATED_BY,
                    SP_MODE = "COMPAREPURPOSE"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<CaptivePurposeModel>("[USP_CRUD_LESSEEPROFILEDETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjECLogDetails = result.ToList();
                }
                return ObjECLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
