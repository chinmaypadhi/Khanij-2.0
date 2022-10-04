using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;

namespace MasterApi.Model.UserInformation
{
    public class UserInformationProvider : RepositoryBase, IUserInformationProvider
    {
        public UserInformationProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public LesseeResult LeaseTypeView(UserInformationEF objLease)
        {

            LesseeResult ObjResult = new LesseeResult();

            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF LeaseEF = new UserInformationEF();

            try
            {
                var paramList = new
                {
                    ACTION = 1,
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<UserInformationEF>("USP_BIND_DROPDOWN", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (UserInformationEF dr in result)
                    {
                        ObjUserTypeList.Add(new UserInformationEF()
                        {
                            APPLICATION_TYPE_ID = Convert.ToInt32(dr.APPLICATION_TYPE_ID.ToString()),
                            APPLICATION_TYPE_Name = dr.APPLICATION_TYPE_Name.ToString(),


                        });
                    }
                    ObjResult.LesseeLst = ObjUserTypeList;


                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        public LesseeResult GetAuctionIDList(UserInformationEF objLease)
        {

            LesseeResult ObjResult = new LesseeResult();

            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF LeaseEF = new UserInformationEF();

            try
            {
                var paramList = new
                {
                    ACTION = 2,
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<UserInformationEF>("USP_BIND_DROPDOWN", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (UserInformationEF dr in result)
                    {
                        ObjUserTypeList.Add(new UserInformationEF()
                        {
                            AuctionTypeId = Convert.ToInt32(dr.AuctionTypeId.ToString()),
                            AuctionName = dr.AuctionName.ToString(),


                        });
                    }
                    ObjResult.LesseeLst = ObjUserTypeList;


                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        public ApplicationResult GetApplicationData(UserInformationEF objUser)
        {
            ApplicationResult ObjResult = new ApplicationResult();
            //  SqlHelperClass gObjSqlHelper = new SqlHelperClass();
            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF UserInfoEF = new UserInformationEF();
            ApplicationResult UserInfo = new ApplicationResult();
            try
            {
                var paramList = new
                {
                    USER_ID = objUser.UserID,
                    SP_MODE = "GETDATA"
                };
                DynamicParameters param = new DynamicParameters();

                //var result = Connection.Query<NoticeLetterEF>("[uspUserInformationNoticeOperation]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var result = Connection.QueryMultiple("[LESSEE_APPLICATION_DETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var ApplDetails = result.Read<UserInformationEF>().ToList();
                var MineralDetails = result.Read<UserInformationEF>().ToList();


                UserInfo.ApplicationLst = ApplDetails;
                UserInfo.MineralLst = MineralDetails;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        public MessageEF SaveApplication(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("USER_ID", model.UserID);
                p.Add("SP_MODE", "SAVEDATA");
                p.Add("APPLICATION_TYPE_ID", model.APPLICATION_TYPE_ID);
                p.Add("APPLICATION_NUMBER", model.APPLICATION_NUMBER);
                p.Add("MINE_CODE", model.MINE_CODE);
                p.Add("APPLICATION_FORM_COPY_FILE_PATH", model.APPLICATION_FORM_FILE_PATH);
                p.Add("APPLICATION_FORM_COPY_FILE_NAME", model.APPLICATION_FORM_FILE_NAME);
                p.Add("RECONNAISSANCE_LICENSE_NAME", model.RECONNAISSANCE_LICENSE_NAME);
                p.Add("RECONNAISSANCE_LICENSE_ADDRESS", model.RECONNAISSANCE_LICENSE_ADDRESS);
                p.Add("PROSPECTING_VALIDITY_FROM", model.PROSPECTING_VALIDITY_FROM);
                p.Add("PROSPECTING_VALIDITY_TO", model.PROSPECTING_VALIDITY_TO);
                p.Add("PAN_CARD_COPY_FILE_PATH", model.PAN_CARD_COPY_FILE_PATH);
                p.Add("PAN_CARD_COPY_FILE_NAME", model.PAN_CARD_COPY_FILE_NAME);

                p.Add("ADHAR_CARD", model.ADHAR_CARD);
                p.Add("ADHAR_CARD_SCAN_COPY_FILE_PATH", model.ADHAR_CARD_SCAN_COPY_FILE_PATH);
                p.Add("ADHAR_CARD_SCAN_COPY_FILE_NAME", model.ADHAR_CARD_SCAN_COPY_FILE_NAME);


                p.Add("TIN_CARD", model.TIN_CARD);
                p.Add("TIN_CARD_SCAN_COPY_FILE_PATH", model.TIN_CARD_SCAN_COPY_FILE_PATH);
                p.Add("TIN_CARD_SCAN_COPY_FILE_NAME", model.TIN_CARD_SCAN_COPY_FILE_NAME);


                p.Add("FIRMREGISTRATION_DEED_NUMBER", model.FIRMREGISTRATION_DEED_NUMBER);
                p.Add("FIRM_REGISTRATION_DEED_FILE_PATH", model.FIRM_REGISTRATION_DEED_FILE_PATH);
                p.Add("FIRM_REGISTRATION_DEED_FILE_NAME", model.FIRM_REGISTRATION_DEED_FILE_NAME);


                p.Add("CERTIFICATE_OF_INCORPORATION_NUMBER", model.CERTIFICATE_OF_INCORPORATION_NUMBER);
                p.Add("CERTIFICATE_OF_INCORPORATION_DOC_FILE_PATH", model.CERTIFICATE_OF_INCORPORATION_DOC_FILE_PATH);
                p.Add("CERTIFICATE_OF_INCORPORATION_DOC_FILE_NAME", model.CERTIFICATE_OF_INCORPORATION_DOC_FILE_NAME);

                p.Add("AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_PATH", model.AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_PATH);
                p.Add("AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_NAME", model.AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_NAME);

                p.Add("POWER_OF_ATORNY_FILE_PATH", model.POWER_OF_ATORNY_FILE_PATH);
                p.Add("POWER_OF_ATORNY_FILE_NAME", model.POWER_OF_ATORNY_FILE_NAME);

                p.Add("MAP_PLAN_OF_APPLIED_AREA_FILE_PATH", model.MAP_PLAN_OF_APPLIED_AREA_FILE_PATH);
                p.Add("MAP_PLAN_OF_APPLIED_AREA_FILE_NAME", model.MAP_PLAN_OF_APPLIED_AREA_FILE_NAME);

                p.Add("KHASARA_PANCHSALA_FILE_PATH", model.KHASARA_PANCHSALA_FILE_PATH);
                p.Add("KHASARA_PANCHSALA_FILE_NAME", model.KHASARA_PANCHSALA_FILE_NAME);

                p.Add("REVENUE_OFFICER_REPORT_FILE_PATH", model.REVENUE_OFFICER_REPORT_FILE_PATH);
                p.Add("REVENUE_OFFICER_REPORT_FILE_NAME", model.REVENUE_OFFICER_REPORT_FILE_NAME);

                p.Add("FOREST_REPORT_FILE_PATH", model.FOREST_REPORT_FILE_PATH);
                p.Add("FOREST_REPORT_FILE_NAME", model.FOREST_REPORT_FILE_NAME);

                p.Add("MINING_INSPECTOR_REPORT_FILE_PATH", model.MINING_INSPECTOR_REPORT_FILE_PATH);
                p.Add("MINING_INSPECTOR_REPORT_FILE_NAME", model.MINING_INSPECTOR_REPORT_FILE_NAME);

                p.Add("SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_PATH", model.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_PATH);
                p.Add("SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_NAME", model.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_NAME);

                p.Add("GRAM_PANCHAYAT_PROPOSAL_FILE_PATH", model.GRAM_PANCHAYAT_PROPOSAL_FILE_PATH);
                p.Add("GRAM_PANCHAYAT_PROPOSAL_FILE_NAME", model.GRAM_PANCHAYAT_PROPOSAL_FILE_NAME);

                p.Add("APPLICATION_FEES", model.APPLICATION_FEES);
                if (model.APPLICATION_FEES_DATE != null)
                {
                    p.Add("APPLICATION_FEES_DATE", model.APPLICATION_FEES_DATE.Value.ToString("dd/MM/yyyy"));
                }

                p.Add("APPLICATION_FEES_COPY_FILE_PATH", model.APPLICATION_FEES_COPY_FILE_PATH);
                p.Add("APPLICATION_FEES_COPY_FILE_NAME", model.APPLICATION_FEES_COPY_FILE_NAME);


                p.Add("CHALLAN_DD_AMOUNT", model.CHALLAN_DD_AMOUNT);
                if (model.CHALLAN_DD_AMOUNT_DATE != null)
                {
                    p.Add("CHALLAN_DD_AMOUNT_DATE", model.CHALLAN_DD_AMOUNT_DATE.Value.ToString("dd/MM/yyyy"));
                }

                p.Add("CHALLAN_DD_AMOUNT_COPY_FILE_PATH", model.CHALLAN_DD_AMOUNT_COPY_FILE_PATH);
                p.Add("CHALLAN_DD_AMOUNT_COPY_FILE_NAME", model.CHALLAN_DD_AMOUNT_COPY_FILE_NAME);


                p.Add("BANK_GUARRANTEE_AMOUNT", model.BANK_GUARRANTEE_AMOUNT);
                if (model.BANK_GUARRANTEE_DATE != null)
                {
                    p.Add("BANK_GUARRANTEE_DATE", model.BANK_GUARRANTEE_DATE.Value.ToString("dd/MM/yyyy"));
                }

                p.Add("BANK_GUARRANTEE_COPY_FILE_PATH", model.BANK_GUARRANTEE_COPY_FILE_PATH);
                p.Add("BANK_GUARRANTEE_COPY_FILE_NAME", model.BANK_GUARRANTEE_COPY_FILE_NAME);

                p.Add("SURITY_BOND_AMOUNT", model.SURITY_BOND_AMOUNT);
                if (model.SURITY_BOND_DATE != null)
                {
                    p.Add("SURITY_BOND_DATE", model.SURITY_BOND_DATE.Value.ToString("dd/MM/yyyy"));
                }

                p.Add("SURITY_BOND_COPY_FILE_PATH", model.SURITY_BOND_COPY_FILE_PATH);
                p.Add("SURITY_BOND_COPY_FILE_NAME", model.SURITY_BOND_COPY_FILE_NAME);

                p.Add("STATUS", model.STATUS);
                p.Add("TRANSFER_GRANT_ORDER_COPY_FILE_NAME", model.TRANSFER_GRANT_ORDER_COPY_FILE_NAME);
                p.Add("TRANSFER_GRANT_ORDER_COPY_FILE_PATH", model.TRANSFER_GRANT_ORDER_COPY_FILE_PATH);

                p.Add("TRANSFER_LEASE_DEED_COPY_FILE_NAME", model.TRANSFER_LEASE_DEED_COPY_FILE_NAME);
                p.Add("TRANSFER_LEASE_DEED_COPY_FILE_PATH", model.TRANSFER_LEASE_DEED_COPY_FILE_PATH);

                p.Add("NAME_OF_TRANSFEREE", model.NAME_OF_TRANSFEREE);
                p.Add("ADDRESS_OF_TRANSFEREE", model.ADDRESS_OF_TRANSFEREE);

                p.Add("DATE_OF_TRANSFER", model.DATE_OF_TRANSFER);

                p.Add("UpfrontPaymentDeposited", model.UpfrontPaymentDeposited);
                p.Add("TillDateBalanceUpfrontPayment", model.TillDateBalanceUpfrontPayment);
                p.Add("IsInterNetConnectionAtDistpatch", model.IsInterNetConnectionAtDistpatch);
                p.Add("MonthlyPeriodicAmount", model.MonthlyPeriodicAmt);
                p.Add("MonthlyPeriodAmountRate", model.MonthlyPeriodicAmtRate);


                p.Add("FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_NAME", model.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_NAME);
                p.Add("FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_PATH", model.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_PATH);

                p.Add("File_Minor_Mineral", model.MinorMineralFormAttachment_FILE);
                p.Add("Path_Minor_Mineral", model.MinorMineralFormAttachment_PATH);
                p.Add("File_PerformanceSecurity", model.PerformanceSecurity_FILE);
                p.Add("Path_PerformanceSecurity", model.PerformanceSecurity_PATH);
                p.Add("File_FinancialAssurance", model.FinancialAssuranceAttachment_FILE);
                p.Add("Path_FinancialAssurance", model.FinancialAssuranceAttachment_PATH);
                p.Add("CrusherInstalled", model.CrusherInstalled);
                p.Add("PaymentModeType", model.PaymentModeType);
                p.Add("BG_ValidityUpto", model.BG_ValidityUpto);
                p.Add("SecurityDeposit", model.SecurityDeposit);
                p.Add("FinancialAmountAssurance", model.FinancialAmountAssurance);
                p.Add("AmountOfDD", model.AmountOfDD);
                p.Add("StorageCrusher", model.StorageCrusher);
                p.Add("File_StorageCrusher", model.StorageCrusherAttachment_FILE);
                p.Add("Path_StorageCrusher", model.StorageCrusherAttachment_PATH);
                p.Add("AdjustCessFromRoyalty", model.AdjustCess);
                p.Add("OrderNo", model.OrderNo);
                p.Add("OrderOf", model.OrderOf);
                p.Add("OrderDate", model.OrderDate);
                p.Add("OrderAttachment_File", model.OrderAttachment_File);
                p.Add("OrderAttachment_Path", model.OrderAttachment_Path);


                //string mineralid = "";
                //if (MineralCount != null)
                //{
                //    if (MineralCount.Count > 0)
                //    {
                //        for (int i = 0; i < MineralCount.Count; i++)
                //        {
                //            mineralid += MineralCount[i].ToString();
                //            mineralid += ",";
                //        }
                //    }
                //}
                p.Add("AuctionTypeId", model.AuctionTypeId);
                p.Add("MINERAL_ID_LIST", model.MineralIdList);
                p.Add("WBStampDate", model.WBStampDate);
                p.Add("WBValidUpto", model.WBValidUpto);
                p.Add("WBInstalled", model.WBInstalled);
                p.Add("WBExemption_FILE", model.WBExemption_FILE);
                p.Add("WBExemption_PATH", model.WBExemption_PATH);
                p.Add("LabEstablished", model.LabEstablished);
                p.Add("LabExemption_FILE", model.LabExemption_FILE);
                p.Add("LabExemption_PATH", model.LabExemption_PATH);


                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_APPLICATION_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response.ToString() == "2")
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
        public MessageEF ApproveLesseeApplicationDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("SP_MODE", model.Actionstatus);
                p.Add("APPROVED_BY", model.UserID);
                p.Add("USER_ID", model.CREATED_BY);
                p.Add("Remarks", model.Remarks);
                p.Add("MonthlyPeriodicAmount", model.MonthlyPeriodicAmt);
                p.Add("MonthlyPeriodAmountRate", model.MonthlyPeriodicAmtRate);
                p.Add("OrderDate", model.OrderDate);
                p.Add("OrderNo", model.OrderNo);
                p.Add("OrderOf", model.OrderOf);

                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_APPLICATION_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF RejectLesseeApplicationDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("SP_MODE", model.Actionstatus);
                p.Add("REJECTED_BY", model.UserID);
                p.Add("USER_ID", model.CREATED_BY);
                p.Add("Remarks", model.Remarks);

                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_APPLICATION_DETAILS", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public ApplicationResult GetGrantOrder(UserInformationEF model)

        {
            // List<UserInformationEF> ListuserType = new List<UserInformationEF>();
            ApplicationResult UserInfo = new ApplicationResult();
            try
            {
                var paramList = new
                {
                    UserId = model.UserID,
                    Check = 4


                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<UserInformationEF>("LESSEE_GRANT", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    UserInfo.GrantOrderLst = result.ToList(); ;
                    //ListuserType = result.ToList();
                }

                return UserInfo;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                UserInfo = null;
            }



        }
        public ApplicationResult GetProfileCount(UserInformationEF model)

        {
            // List<UserInformationEF> ListuserType = new List<UserInformationEF>();
            ApplicationResult UserInfo = new ApplicationResult();
            try
            {
                var paramList = new
                {
                    USER_ID = model.UserID,
                    MineralType = model.MINERAL_NAME,
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<UserInformationEF>("LESSEE_PROFILE_COMPLETION_COUNT", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    UserInfo.ApplicationLst = result.ToList(); ;
                    //ListuserType = result.ToList();
                }

                return UserInfo;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                UserInfo = null;
            }



        }
        public MessageEF SaveGrantDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("Check", 1);
                p.Add("GrantOrderId", model.GrantOrderId);
                p.Add("GrantOrderNumber", model.GrantOrderNumber);
                if (model.GrantOrderDate != null)
                {
                    p.Add("GrantOrderDate", model.GrantOrderDate.Value.ToString("dd/MM/yyyy"));
                }
                if (model.FromValidity != null)
                {
                    p.Add("FromValidity", model.FromValidity.Value.ToString("dd/MM/yyyy"));
                }
                if (model.ToValidity != null)
                {
                    p.Add("ToValidity", model.ToValidity.Value.ToString("dd/MM/yyyy"));
                }

                p.Add("ExecutionOfDeedNumber", model.ExecutionOfDeedNumber);
                if (model.ExecutionOfDeedDate != null)
                {
                    p.Add("ExecutionOfDeedDate", model.ExecutionOfDeedDate.Value.ToString("dd/MM/yyyy"));
                }
                p.Add("GrantOrderFilePath", model.GrantOrderFilePath);
                p.Add("GrantOrderFileName", model.GrantOrderFileName);
                p.Add("ExecutionOfDeedFilePath", model.ExecutionOfDeedFilePath);
                p.Add("ExecutionOfDeedFileName", model.ExecutionOfDeedFileName);
                p.Add("Lease_Period", model.Lease_Period);
                p.Add("UserId", model.UserID);
                p.Add("UserLoginId", model.UserLoginId);
                p.Add("STATUS", model.STATUS);


                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_GRANT", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response.ToString() == "2")
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
        public MessageEF ApproveLesseeGrantDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("Check", 5);
                p.Add("APPROVED_BY", model.UserID);
                p.Add("UserId", model.CREATED_BY);
                p.Add("Remarks", model.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_GRANT", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF RejectLesseeGrantDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("Check", 6);
                p.Add("REJECTED_BY", model.UserID);
                p.Add("UserId", model.CREATED_BY);
                p.Add("Remarks", model.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_GRANT", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public ApplicationResult GetLeaseArea(UserInformationEF model)

        {
            ApplicationResult UserInfo = new ApplicationResult();
            try
            {
                var paramList = new
                {
                    SP_MODE = "GETDATA",
                    USER_ID = model.UserID,
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<UserInformationEF>("LESSEE_LICENSE_AREA", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    UserInfo.LeaseAreaDetailsLst = result.ToList(); ;
                    //ListuserType = result.ToList();
                }

                return UserInfo;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                UserInfo = null;
            }



        }
        public ApplicationResult GetLesseeProfileStatus(UserInformationEF model)

        {
            // List<UserInformationEF> ListuserType = new List<UserInformationEF>();
            ApplicationResult UserInfo = new ApplicationResult();
            try
            {
                var paramList = new
                {
                    SP_MODE = "GET_ALL_DETAILS",
                    USER_ID = model.UserID,
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<UserInformationEF>("LESSE_PROFILE_DASHBOARD", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    UserInfo.ApplicationLst = result.ToList(); ;
                    //ListuserType = result.ToList();
                }

                return UserInfo;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                UserInfo = null;
            }



        }
        public LesseeResult GetStateList(UserInformationEF objLease)
        {

            LesseeResult ObjResult = new LesseeResult();

            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF LeaseEF = new UserInformationEF();

            try
            {
                var paramList = new
                {
                    ACTION = 3,
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<UserInformationEF>("USP_BIND_DROPDOWN", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (UserInformationEF dr in result)
                    {
                        ObjUserTypeList.Add(new UserInformationEF()
                        {
                            STATE_ID = Convert.ToInt32(dr.STATE_ID.ToString()),
                            STATE_NAME = dr.STATE_NAME.ToString(),


                        });
                    }
                    ObjResult.StateLst = ObjUserTypeList;


                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        public LesseeResult GetDistrictList(UserInformationEF objLease)
        {

            LesseeResult ObjResult = new LesseeResult();

            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF LeaseEF = new UserInformationEF();

            try
            {
                var paramList = new
                {
                    ACTION = 4,
                    StateID = objLease.STATE_ID,
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<UserInformationEF>("USP_BIND_DROPDOWN", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (UserInformationEF dr in result)
                    {
                        ObjUserTypeList.Add(new UserInformationEF()
                        {
                            DISTRICT_ID = Convert.ToInt32(dr.DISTRICT_ID.ToString()),
                            DistrictName = dr.DistrictName.ToString(),


                        });
                    }
                    ObjResult.DistrictLst = ObjUserTypeList;


                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        public LesseeResult GetTehsilList(UserInformationEF objLease)
        {

            LesseeResult ObjResult = new LesseeResult();

            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF LeaseEF = new UserInformationEF();

            try
            {
                var paramList = new
                {
                    ACTION = 5,
                    StateID = objLease.STATE_ID,
                    DistID = objLease.DISTRICT_ID,
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<UserInformationEF>("USP_BIND_DROPDOWN", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (UserInformationEF dr in result)
                    {
                        ObjUserTypeList.Add(new UserInformationEF()
                        {
                            TEHSIL_FOREST_DIVISION = Convert.ToInt32(dr.TEHSIL_FOREST_DIVISION.ToString()),
                            TehsilName = dr.TehsilName.ToString(),


                        });
                    }
                    ObjResult.TehsilLst = ObjUserTypeList;


                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        public LesseeResult GetVillageList(UserInformationEF objLease)
        {

            LesseeResult ObjResult = new LesseeResult();

            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF LeaseEF = new UserInformationEF();

            try
            {
                var paramList = new
                {
                    ACTION = 6,
                    StateID = objLease.STATE_ID,
                    DistID = objLease.DISTRICT_ID,
                    TehsilID = objLease.TEHSIL_FOREST_DIVISION,
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<UserInformationEF>("USP_BIND_DROPDOWN", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (UserInformationEF dr in result)
                    {
                        ObjUserTypeList.Add(new UserInformationEF()
                        {
                            VILLAGE_ID = Convert.ToInt32(dr.VILLAGE_ID.ToString()),
                            VillageName = dr.VillageName.ToString(),


                        });
                    }
                    ObjResult.VillageLst = ObjUserTypeList;


                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        public MessageEF SaveLeaseArea(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();


                p.Add("USER_ID", model.UserID);
                p.Add("SP_MODE", "SAVEDATA");

                p.Add("LICENSE_AREA_ID", model.LICENSE_AREA_ID);
                p.Add("VILLAGE_ID", model.VILLAGE_ID);
                p.Add("BLOCK_FOREST_RANGE", model.BLOCK_FOREST_RANGE);
                p.Add("TEHSIL_FOREST_DIVISION", model.TEHSIL_FOREST_DIVISION);
                p.Add("DISTRICT_ID", model.DISTRICT_ID);
                p.Add("STATE_ID", model.STATE_ID);
                p.Add("PIN_CODE", model.PIN_CODE);
                p.Add("TYPE_OF_LAND", model.TYPE_OF_LAND);
                p.Add("AREA_IN_HECT", model.AREA_IN_HECT);
                p.Add("TOPOSHEET_NO", model.TOPOSHEET_NO);
                p.Add("COORDINATES", model.COORDINATES);
                p.Add("POLICE_STATION", model.POLICE_STATION);
                p.Add("GRAM_PANCHAYAT", model.GRAM_PANCHAYAT);
                p.Add("STATUS", model.STATUS);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("Forest", model.Forest);
                p.Add("RevenueForest", model.Revenue_Forest);
                p.Add("RevenueGovernmentLand", model.Revenue_Government_Land);
                p.Add("PrivateTribal", model.Private_Tribal);
                p.Add("PrivateNonTribal", model.Private_Non_Tribal);
                p.Add("LandUnderVidhansabhakshetra", model.Land_Under_Vidhansabha_kshetra);

                p.Add("DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH", model.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH);
                p.Add("DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME", model.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME);




                if (model.WORKING_PERMISSION_DATE != null)
                {
                    p.Add("WORKING_PERMISSION_DATE", model.WORKING_PERMISSION_DATE.Value.ToString("dd/MM/yyyy"));
                }

                p.Add("WORKING_PERMISSION_COPY_PATH", model.WORKING_PERMISSION_COPY_PATH);
                p.Add("WORKING_PERMISSION_COPY_NAME", model.WORKING_PERMISSION_COPY_NAME);


                if (model.COMENCEMENT_OF_MINING_DATE != null)
                {
                    p.Add("COMENCEMENT_OF_MINING_DATE", model.COMENCEMENT_OF_MINING_DATE.Value.ToString("dd/MM/yyyy"));
                }

                p.Add("COMENCEMENT_OF_MINING_FILE_PATH", model.COMENCEMENT_OF_MINING_FILE_PATH);
                p.Add("COMENCEMENT_OF_MINING_FILE_NAME", model.COMENCEMENT_OF_MINING_FILE_NAME);

                if (model.DATE_OF_EXECUTION != null)
                {
                    p.Add("DATE_OF_EXECUTION", model.DATE_OF_EXECUTION.Value.ToString("dd/MM/yyyy"));
                }



                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_LICENSE_AREA", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response.ToString() == "2")
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
        public MessageEF ApproveLesseeAreaDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("SP_MODE", "APPROVE");
                p.Add("APPROVED_BY", model.UserID);
                p.Add("USER_ID", model.CREATED_BY);
                p.Add("Remarks", model.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_LICENSE_AREA", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF RejectLesseeAreaDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("SP_MODE", "REJECT");
                p.Add("REJECTED_BY", model.UserID);
                p.Add("USER_ID", model.CREATED_BY);
                p.Add("Remarks", model.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_LICENSE_AREA", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public ApplicationResult GetMineralCategory(UserInformationEF objLease)
        {

            ApplicationResult ObjResult = new ApplicationResult();

            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF LeaseEF = new UserInformationEF();

            try
            {
                var paramList = new
                {
                    ACTION = 7,
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<UserInformationEF>("USP_BIND_DROPDOWN", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (UserInformationEF dr in result)
                    {
                        ObjUserTypeList.Add(new UserInformationEF()
                        {
                            MINERAL_CATEGORY_ID = Convert.ToInt32(dr.MINERAL_CATEGORY_ID.ToString()),
                            MINERAL_CATEGORY_NAME = dr.MINERAL_CATEGORY_NAME.ToString(),


                        });
                    }
                    ObjResult.MineralLst = ObjUserTypeList;


                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        public ApplicationResult GetMineralNameFromMineralType(UserInformationEF objLease)
        {

            ApplicationResult ObjResult = new ApplicationResult();

            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF LeaseEF = new UserInformationEF();

            try
            {
                var paramList = new
                {
                    UserId = objLease.UserID,
                    MineralTypeId = objLease.MINERAL_CATEGORY_ID,

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<UserInformationEF>("uspGetMineralNameFromMineralType", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (UserInformationEF dr in result)
                    {
                        ObjUserTypeList.Add(new UserInformationEF()
                        {
                            MINERALID = Convert.ToInt32(dr.MINERALID.ToString()),
                            MINERALNAME = dr.MINERALNAME.ToString(),


                        });
                    }
                    ObjResult.MineralLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        public ApplicationResult GetLicenseeIBMDetail(UserInformationEF model)

        {
            ApplicationResult UserInfo = new ApplicationResult();
            try
            {
                var paramList = new
                {
                    CHECK = "2",
                    CREATED_BY = model.UserID,
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<UserInformationEF>("LICENSEE_IBM_DETAILS_OFFICE", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    UserInfo.IBMDetailsLst = result.ToList(); ;
                    //ListuserType = result.ToList();
                }

                return UserInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                UserInfo = null;
            }



        }
        public MessageEF NewLicenseeIBMDetail(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("Check", 1);
                p.Add("CREATED_BY", model.UserID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);

                p.Add("IBM_APPLICATION_NUMBER", model.IBM_APPLICATION_NUMBER);
                p.Add("IBM_APPLICATON_DATE", model.IBM_APPLICATON_DATE);
                p.Add("IBM_NUMBER", model.IBM_NUMBER);
                p.Add("STATUS", model.STATUS);
                p.Add("IBM_REGISTRATION_FORM_PATH", model.IBM_REGISTRATION_FORM_PATH);
                p.Add("FILE_IBM_REGISTRATION_FORM", model.FILE_IBM_REGISTRATION_FORM);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_IBM_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response.ToString() == "2")
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
        public MessageEF UpdateLicenseeIBMDetail(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("Check", 3);
                p.Add("CREATED_BY", model.UserID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("LICENSEE_IBM_ID", model.LICENSEE_IBM_ID);
                p.Add("IBM_APPLICATION_NUMBER", model.IBM_APPLICATION_NUMBER);
                p.Add("IBM_APPLICATON_DATE", model.IBM_APPLICATON_DATE);
                p.Add("IBM_NUMBER", model.IBM_NUMBER);
                p.Add("STATUS", model.STATUS);
                p.Add("IBM_REGISTRATION_FORM_PATH", model.IBM_REGISTRATION_FORM_PATH);
                p.Add("FILE_IBM_REGISTRATION_FORM", model.FILE_IBM_REGISTRATION_FORM);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_IBM_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response.ToString() == "2")
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
        public MessageEF ApproveLicenseeIBMDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 4);
                p.Add("APPROVED_BY", model.UserID);
                p.Add("LICENSEE_IBM_ID", model.LICENSEE_IBM_ID);

                p.Add("Remarks", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_IBM_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Remarks");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response.ToString() == "2")
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
        public MessageEF RejectLicenseeIBMDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 5);
                p.Add("REJECTED_BY", model.UserID);
                p.Add("LICENSEE_IBM_ID", model.LICENSEE_IBM_ID);

                p.Add("Remarks", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_IBM_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Remarks");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response.ToString() == "2")
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
        public LesseeResult GetMiningPlanYearList(UserInformationEF objLease)
        {

            LesseeResult ObjResult = new LesseeResult();

            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF LeaseEF = new UserInformationEF();

            try
            {
                var paramList = new
                {
                    SP_MODE = "GET_MINING_PLAN_YEAR",
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<UserInformationEF>("LESSEE_MININGPLAN", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (UserInformationEF dr in result)
                    {
                        ObjUserTypeList.Add(new UserInformationEF()
                        {
                            Srno = Convert.ToInt32(dr.Srno.ToString()),
                            YEAR = dr.YEAR.ToString(),


                        });
                    }
                    ObjResult.YearLst = ObjUserTypeList;


                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        public ApplicationResult GetMiningPlanData(UserInformationEF objUser)
        {
            ApplicationResult ObjResult = new ApplicationResult();
            //  SqlHelperClass gObjSqlHelper = new SqlHelperClass();
            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF UserInfoEF = new UserInformationEF();
            ApplicationResult UserInfo = new ApplicationResult();
            try
            {
                var paramList = new
                {
                    USER_ID = objUser.UserID,
                    SP_MODE = "GET_DATA"
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.QueryMultiple("[LESSEE_MININGPLAN]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var MiningDetails = result.Read<UserInformationEF>().ToList();
                var ProductDetails = result.Read<ProductionModel>().ToList();


                UserInfo.MiningPlanDetailsLst = MiningDetails;
                UserInfo.MiningPlanProductLst = ProductDetails;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        public MessageEF SaveMiningPlanData(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {                
                DataTable dataTable = new DataTable("LESSEE_MINING_PLAN_YEAR_WISE_PRODUCTION");
                //we create column names as per the type in DB 
                dataTable.Columns.Add("ID", typeof(string));
                dataTable.Columns.Add("YEAR", typeof(string));
                dataTable.Columns.Add("PRODUCTION", typeof(Int64));
                dataTable.Columns.Add("Units", typeof(string));
                dataTable.Columns.Add("CREATED_BY", typeof(Int32));
                var p = new DynamicParameters();


                p.Add("USER_ID", model.UserID);
                p.Add("SP_MODE", "SAVE_DATA");
                if (model.MP_APPROVE_DATE != null)
                {
                    p.Add("MP_APPROVE_DATE", model.MP_APPROVE_DATE.Value.ToString("dd/MM/yyyy"));
                }
                if (model.MP_EXPIRY_DATE != null)
                {
                    p.Add("MP_EXPIRY_DATE", model.MP_EXPIRY_DATE.Value.ToString("dd/MM/yyyy"));
                }
                if (model.MP_VALID_FORM != null)
                {
                    p.Add("MP_VALID_FORM", model.MP_VALID_FORM.Value.ToString("dd/MM/yyyy"));
                }
                if (model.MP_VALID_TO != null)
                {
                    p.Add("MP_VALID_TO", model.MP_VALID_TO.Value.ToString("dd/MM/yyyy"));
                }
                p.Add("STATUS", model.STATUS);
                p.Add("MP_APPROVAL_NO", model.MP_APPROVAL_NO);
                p.Add("MP_SOM_FilePath", model.MP_SOM_FilePath);
                p.Add("MP_SOM_FileName", model.MP_SOM_FileName);
                for (var i = 0; i < model.Product.Count; i++)
                {
                    string[] strData = model.Product[i].YEAR.Split('-');
                    if (model.Product[i].YEAR != null && model.Product[i].PRODUCTION != 0 && model.Product[i].Units != null)
                    {
                        dataTable.Rows.Add(i + 1, model.Product[i].YEAR, model.Product[i].PRODUCTION, model.Product[i].Units, 58);
                    }
                }

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    p.Add("BULK_PRODUCTION", dataTable.AsTableValuedParameter());                    
                }

                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_MININGPLAN", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response.ToString() == "2")
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
        public MessageEF ApproveLesseeMiningDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("SP_MODE", "APPROVE");
                p.Add("APPROVED_BY", model.UserID);
                p.Add("USER_ID", model.CREATED_BY);
                p.Add("Remarks", model.Remarks);

                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_MININGPLAN", p, commandType: CommandType.StoredProcedure);
                // int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF RejectLesseeMiningDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("SP_MODE", "REJECT");
                p.Add("REJECTED_BY", model.UserID);
                p.Add("USER_ID", model.CREATED_BY);
                p.Add("Remarks", model.Remarks);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_MININGPLAN", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public ApplicationResult GetForestClearence(UserInformationEF objUser)
        {
            ApplicationResult ObjResult = new ApplicationResult();
            //  SqlHelperClass gObjSqlHelper = new SqlHelperClass();
            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF UserInfoEF = new UserInformationEF();
            ApplicationResult UserInfo = new ApplicationResult();
            try
            {
                var paramList = new
                {
                    USER_ID = objUser.UserID,
                    SP_MODE = "GET_DATA"
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<UserInformationEF>("LESSEE_FOREST_CLEARANCE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.ForestClearenceLst = result.ToList(); ;
                    //ListuserType = result.ToList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        public MessageEF SaveForestClearenceDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("USER_ID", model.UserID);
                p.Add("SP_MODE", "SAVE_DATA");
                p.Add("FC_APPROVAL_NUMBER", model.FC_APPROVAL_NUMBER);
                if (model.FC_APPROVAL_DATE != null)
                {
                    p.Add("FC_APPROVAL_DATE", model.FC_APPROVAL_DATE.Value.ToString("dd/MM/yyyy"));
                }
                if (model.VALID_FROM != null)
                {
                    p.Add("VALID_FROM", model.VALID_FROM.Value.ToString("dd/MM/yyyy"));
                }
                if (model.VALID_TO != null)
                {
                    p.Add("VALID_TO", model.VALID_TO.Value.ToString("dd/MM/yyyy"));
                }

                p.Add("STATUS", model.STATUS);

                p.Add("FC_LETTER_FILE_path", model.FC_LETTER_FILE_PATH);
                p.Add("FC_LETTER_FILE_NAME", model.FC_LETTER_FILE_NAME);

                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_FOREST_CLEARANCE", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response.ToString() == "2")
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
        public MessageEF ApproveLesseeForestDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("SP_MODE", "APPROVE");
                p.Add("APPROVED_BY", model.UserID);
                p.Add("USER_ID", model.CREATED_BY);
                p.Add("Remarks", model.Remarks);

                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_FOREST_CLEARANCE", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response.ToString() == "2")
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
        public MessageEF RejectLesseeForestDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("SP_MODE", "REJECT");
                p.Add("REJECTED_BY", model.UserID);
                p.Add("USER_ID", model.CREATED_BY);
                p.Add("Remarks", model.Remarks);

                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LESSEE_FOREST_CLEARANCE", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("RESULT");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response.ToString() == "2")
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
        public ApplicationResult GetLicenseeEnvDetail(UserInformationEF objUser)
        {
            ApplicationResult ObjResult = new ApplicationResult();
            //  SqlHelperClass gObjSqlHelper = new SqlHelperClass();
            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF UserInfoEF = new UserInformationEF();
            ApplicationResult UserInfo = new ApplicationResult();
            try
            {
                var paramList = new
                {
                    CHECK = 2,
                    CREATED_BY = objUser.UserID,
                 };
            DynamicParameters param = new DynamicParameters();

            var result = Connection.Query<UserInformationEF>("LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE", paramList, commandType: System.Data.CommandType.StoredProcedure);
            if (result.Count() > 0)
            {
                UserInfo.EnvClearenceLst = result.ToList(); ;
                //ListuserType = result.ToList();
            }
        }
    
            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

       }
        public MessageEF NewLicenseeEnvDetail(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 1);
                p.Add("CREATED_BY",model.UserID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                    p.Add("EC_ORDRER_NUMBER", model.EC_ORDRER_NUMBER);
                    p.Add("EC_APPROVED_CAPACITY", model.EC_APPROVED_CAPACITY);
                    p.Add("ApplicationDateOfEC", model.EC_APPLICATON_DATE);
                p.Add("EC_VALID_TO", model.EC_VALID_TO);

                p.Add("STATUS", model.STATUS);
                p.Add("EC_CLEARANCE_PATH", model.EC_CLEARANCE_PATH);
                p.Add("FILE_EC_CLEARANCE", model.FILE_EC_CLEARANCE);

              //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF UpdateLicenseeEnvironmentDetail(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 3);
                p.Add("CREATED_BY", model.UserID);
                p.Add("LICENSEE_EC_ID", model.LICENSEE_EC_ID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("EC_ORDRER_NUMBER", model.EC_ORDRER_NUMBER);
                p.Add("EC_APPROVED_CAPACITY", model.EC_APPROVED_CAPACITY);
                p.Add("ApplicationDateOfEC", model.EC_APPLICATON_DATE);
                p.Add("EC_VALID_TO", model.EC_VALID_TO);
                p.Add("EC_VALID_FROM", model.EC_VALID_FROM);
                p.Add("STATUS", model.STATUS);
                p.Add("EC_CLEARANCE_PATH", model.EC_CLEARANCE_PATH);
                p.Add("FILE_EC_CLEARANCE", model.FILE_EC_CLEARANCE);
                p.Add("Mineralid", model.MineralId);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF ApproveLicenseeECDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 4);
                p.Add("APPROVED_BY", model.UserID);
                p.Add("LICENSEE_EC_ID", model.LICENSEE_EC_ID);
               
                p.Add("Remarks", model.Remarks);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF RejectLicenseeECDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 5);
                p.Add("REJECTED_BY", model.UserID);
                p.Add("LICENSEE_EC_ID", model.LICENSEE_EC_ID);

                p.Add("Remarks", model.Remarks);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_ENVIRONMENTCLEARANCE_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public ApplicationResult GetLicenseeCTEDetail(UserInformationEF objUser)
        {
            ApplicationResult ObjResult = new ApplicationResult();
            //  SqlHelperClass gObjSqlHelper = new SqlHelperClass();
            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF UserInfoEF = new UserInformationEF();
            ApplicationResult UserInfo = new ApplicationResult();
            try
            {
                var paramList = new
                {
                    CHECK = 2,
                    CREATED_BY = objUser.UserID,
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<UserInformationEF>("LICENSEE_CTE_DETAILS_OFFICE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.CTEDetailsLst = result.ToList(); ;
                    //ListuserType = result.ToList();
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        public MessageEF NewLicenseeCTEDetail(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 1);
                p.Add("CREATED_BY", model.UserID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("CTE_ORDER_NO", model.CTE_ORDER_NO);
                p.Add("CTE_ORDER_DATE", model.CTE_ORDER_DATE);
                p.Add("CTE_VALID_FROM", model.CTE_VALID_FROM);
                p.Add("CTE_VALID_TO", model.CTE_VALID_TO);

                p.Add("STATUS", model.STATUS);
                p.Add("CTE_LETTER_PATH", model.CTE_LETTER_PATH);
                p.Add("FILE_CTE_LETTER", model.FILE_CTE_LETTER);

                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_CTE_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF UpdateLicenseeCTEDetail(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 3);
                p.Add("MODIFIED_BY", model.UserID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("CTE_ID", model.CTE_ID);
                p.Add("CTE_ORDER_NO", model.CTE_ORDER_NO);
                p.Add("CTE_ORDER_DATE", model.CTE_ORDER_DATE);
                p.Add("CTE_VALID_FROM", model.CTE_VALID_FROM);
                p.Add("CTE_VALID_TO", model.CTE_VALID_TO);
                p.Add("STATUS", model.STATUS);
                p.Add("CTE_LETTER_PATH", model.CTE_LETTER_PATH);
                p.Add("FILE_CTE_LETTER", model.FILE_CTE_LETTER);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_CTE_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF ApproveLicenseeCTEDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 4);
                p.Add("APPROVED_BY", model.UserID);
                p.Add("CTE_ID", model.CTE_ID);

                p.Add("Remarks", model.Remarks);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_CTE_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF RejectLicenseeCTEDetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 5);
                p.Add("REJECTED_BY", model.UserID);
                p.Add("CTE_ID", model.CTE_ID);

                p.Add("Remarks", model.Remarks);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_CTE_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public ApplicationResult GetLicenseeCTODetail(UserInformationEF objUser)
        {
            ApplicationResult ObjResult = new ApplicationResult();
            //  SqlHelperClass gObjSqlHelper = new SqlHelperClass();
            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF UserInfoEF = new UserInformationEF();
            ApplicationResult UserInfo = new ApplicationResult();
            try
            {
                var paramList = new
                {
                    CHECK = 2,
                    CREATED_BY = objUser.UserID,
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<UserInformationEF>("LICENSEE_CTO_DETAILS_OFFICE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.CTODetailsLst = result.ToList(); ;
                    //ListuserType = result.ToList();
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        public MessageEF NewLicenseeCTODetail(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 1);
                p.Add("CREATED_BY", model.UserID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("CTO_ORDER_NO", model.CTO_ORDER_NO);
                p.Add("CTO_ORDER_DATE", model.CTO_ORDER_DATE);
                p.Add("CTO_VALID_FROM", model.CTO_VALID_FROM);
                p.Add("CTO_VALID_TO", model.CTO_VALID_TO);

                p.Add("STATUS", model.STATUS);
                p.Add("CTO_LETTER_PATH", model.CTO_LETTER_PATH);
                p.Add("FILE_CTO_LETTER", model.FILE_CTO_LETTER);

                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_CTO_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF UpdateLicenseeCTODetail(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 3);
                p.Add("CREATED_BY", model.UserID);
                p.Add("USER_LOGIN_ID", model.UserLoginId);
                p.Add("CTO_ID", model.CTO_ID);
                p.Add("CTO_ORDER_NO", model.CTO_ORDER_NO);
                p.Add("CTO_ORDER_DATE", model.CTO_ORDER_DATE);
                p.Add("CTO_VALID_FROM", model.CTO_VALID_FROM);
                p.Add("CTO_VALID_TO", model.CTO_VALID_TO);
                p.Add("STATUS", model.STATUS);
                p.Add("CTO_LETTER_PATH", model.CTO_LETTER_PATH);
                p.Add("FILE_CTO_LETTER", model.FILE_CTO_LETTER);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_CTO_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF ApproveLicenseeCTODetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 4);
                p.Add("APPROVED_BY", model.UserID);
                p.Add("CTO_ID", model.CTO_ID);

                p.Add("Remarks", model.Remarks);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_CTO_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF RejectLicenseeCTODetails(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 5);
                p.Add("REJECTED_BY", model.UserID);
                p.Add("CTO_ID", model.CTO_ID);

                p.Add("Remarks", model.Remarks);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("LICENSEE_CTO_DETAILS_OFFICE", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public ApplicationResult GetAssesmentReport(UserInformationEF objUser)
        {
            ApplicationResult ObjResult = new ApplicationResult();
            //  SqlHelperClass gObjSqlHelper = new SqlHelperClass();
            DataTable ObjDt = new DataTable();
            List<UserInformationEF> ObjUserTypeList = new List<UserInformationEF>();
            UserInformationEF UserInfoEF = new UserInformationEF();
            ApplicationResult UserInfo = new ApplicationResult();
            try
            {
                var paramList = new
                {
                    CHECK = 2,
                    CreatedBy = objUser.UserID,
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<UserInformationEF>("SP_AssessmentData", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.AssessmentRptLst = result.ToList(); ;
                    //ListuserType = result.ToList();
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        public MessageEF NewAssesmentReport(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 1);
                p.Add("CreatedOn", DateTime.Now);
                p.Add("UserLoginID", model.UserLoginId);
                p.Add("CreatedBy", model.UserID);
                p.Add("Assessmentdate", model.Assessmentdate);
                p.Add("HalfYearAssesmentDate", model.HalfYearAssesmentDate);
                p.Add("Status", model.STATUS);

                p.Add("RecoveryReportFilePath", model.RecoveryReportFilePath);
                p.Add("RecoveryReportFileName", model.RecoveryReportFileName);
                p.Add("HalfyearassesmentFilePath", model.HalfyearassesmentFilePath);
                p.Add("HalfyearassesmentFileName", model.HalfyearassesmentFileName);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("SP_AssessmentData", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF UpdateAssessmentReport(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 1);
                p.Add("CreatedOn", DateTime.Now);
                p.Add("CreatedBy", model.UserID);
                p.Add("UserLoginID", model.UserLoginId);
                p.Add("AssessmentID", model.AssessmentID);
                p.Add("Assessmentdate", model.Assessmentdate);
                p.Add("HalfYearAssesmentDate", model.HalfYearAssesmentDate);
                p.Add("Status", model.STATUS);
                p.Add("RecoveryReportFilePath", model.RecoveryReportFilePath);
                p.Add("RecoveryReportFileName", model.RecoveryReportFileName);
                p.Add("HalfyearassesmentFilePath", model.HalfyearassesmentFilePath);
                p.Add("HalfyearassesmentFileName", model.HalfyearassesmentFileName);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("SP_AssessmentData", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF ApproveAssessmentReport(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 4);
                p.Add("ApprovedBy", model.UserID);
                p.Add("UserLoginID", model.UserLoginId);
                p.Add("AssessmentID", model.AssessmentID);
                p.Add("Remarks", model.Remarks);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("SP_AssessmentData", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF RejectAssessmentReport(UserInformationEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("CHECK", 5);
                p.Add("RejectedBy", model.UserID);
                p.Add("AssessmentID", model.AssessmentID);
                p.Add("UserLoginID", model.UserLoginId);
                p.Add("Remarks", model.Remarks);
                //  p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("SP_AssessmentData", p, commandType: CommandType.StoredProcedure);
                //int response = p.Get<int>("RESULT");
                int response = 1;
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
    }
}
