using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using PermitApi.Factory;
using PermitApi.Repository;
using PermitEF;

namespace PermitApi.Model.Transit
{
    public class TransitProvider : RepositoryBase, ITransitProvider
    {
        public TransitProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Bind the dropdown of Bulk Permit Id of RTP Permit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<eTransitResult> GetBulkPermitForwarding(ForwardingNoteModel objUser)
        {
            eTransitResult ObjResult = new eTransitResult();
            List<BulkPermitModel> ObjUserTypeList = new List<BulkPermitModel>();
            ePermitModel LeaseEF = new ePermitModel();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<BulkPermitModel>("uspGetBulkPermitForForwardingNote", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    foreach (BulkPermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new BulkPermitModel()
                        {
                            BulkPermitId = Convert.ToInt32(dr.BulkPermitId.ToString()),
                            BulkPermitNumber = dr.BulkPermitNo.ToString(),
                            StockQty = Convert.ToDecimal(dr.PendingQty.ToString()),
                        });
                    }
                    ObjResult.PermitLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Bind the dropdown of PurchaserConsinee of selected Permit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<eTransitResult> GetConsigerListForwardingNote(ForwardingNoteModel objLease)
        {
            eTransitResult ObjResult = new eTransitResult();
            List<PurchaseConsignee> ObjUserTypeList = new List<PurchaseConsignee>();
            ePermitModel LeaseEF = new ePermitModel();
            try
            {
                var paramList = new
                {
                    UserId = objLease.UserID,
                    BulkPermitID = objLease.BulkPermitId,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<PurchaseConsignee>("GetPurchaseConsigneedForForwardingNote", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    foreach (PurchaseConsignee dr in result)
                    {
                        ObjUserTypeList.Add(new PurchaseConsignee()
                        {
                            PurchaserConsigneeId = Convert.ToInt32(dr.PCId.ToString()),
                            PurchaserConsigneeName = dr.ApplicantName.ToString(),
                            Address = dr.Address.ToString(),
                        });
                    }
                    ObjResult.PurchaseConsigneeLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Bind the dropdown of Railway siding Sourse
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<eTransitResult> GetRailwaySiding(ForwardingNoteModel objUser)
        {

            eTransitResult ObjResult = new eTransitResult();

            DataTable ObjDt = new DataTable();
            List<ForwardingNoteModel> ObjUserTypeList = new List<ForwardingNoteModel>();
            ePermitModel LeaseEF = new ePermitModel();

            try
            {
                var paramList = new
                {
                    ACTION = 'E',

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ForwardingNoteModel>("USP_FILL_COMMON_DATA", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ForwardingNoteModel dr in result)
                    {
                        ObjUserTypeList.Add(new ForwardingNoteModel()
                        {
                            RailwayId = Convert.ToInt32(dr.RailwayID.ToString()),
                            RailwaySlidingName = dr.RailwaySlidingName.ToString(),
                        });
                    }
                    ObjResult.RailwaySidingLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Bind the dropdown of Railway siding Destination
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<eTransitResult> GetRailwaySidingDestination(ForwardingNoteModel objUser)
        {

            eTransitResult ObjResult = new eTransitResult();

            DataTable ObjDt = new DataTable();
            List<ForwardingNoteModel> ObjUserTypeList = new List<ForwardingNoteModel>();
            ePermitModel LeaseEF = new ePermitModel();

            try
            {
                var paramList = new
                {
                    ACTION = 'E',

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ForwardingNoteModel>("USP_FILL_COMMON_DATA", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ForwardingNoteModel dr in result)
                    {
                        ObjUserTypeList.Add(new ForwardingNoteModel()
                        {
                            DestinationRailwayId = Convert.ToInt32(dr.RailwayID.ToString()),
                            DestinationRailwaySiding = dr.RailwaySlidingName.ToString(),
                        });
                    }
                    ObjResult.RailwaySidingDestinationLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Get the details of Licenseee RTP Permit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ForwardingNoteModel>> GetForwardingNoteView(ForwardingNoteModel objUser)
        {
            List<ForwardingNoteModel> ObjUserTypeList = new List<ForwardingNoteModel>();
            try
            {
                var paramList = new
                {
                    UserID = objUser.UserID,
                    ForwardingNoteId = objUser.ForwardingNoteId,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<ForwardingNoteModel>("uspForwardingNoteByForwardingNoteId", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjUserTypeList = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjUserTypeList;

        }
        /// <summary>
        /// Get the details of Licenseee Grant order of RTP Permit 
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ForwardingNoteModel>> GetGrantOrderExpiry(ForwardingNoteModel objUser)
        {
            List<ForwardingNoteModel> ObjUserTypeList = new List<ForwardingNoteModel>();
            try
            {
                var paramList = new
                {
                    CreatedBy = objUser.UserID,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<ForwardingNoteModel>("uspLicensee_CheckGrantOrderExpiry", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjUserTypeList = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjUserTypeList;

        }
        /// <summary>
        /// Get the details of Licenseee Forwarding Note Preview Data 
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<eTransitResult> getFNPreviewData(ForwardingNoteModel objUser)
        {
            eTransitResult ObjResult = new eTransitResult();
            try
            {
                var paramList = new
                {
                    UserID = objUser.UserID,
                    BulkPermitId = objUser.BulkPermitId,
                    MineralID = objUser.MineralId,
                    MineralGradeId = objUser.MineralGradeId,
                    RailwayID = objUser.RailwayId,
                    EndUserId = objUser.EndUserId
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryMultipleAsync("sp_getFNPreviewData", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var PreviewPermit = result.Read<ForwardingNoteModel>().ToList();
                var PreviewMineral = result.Read<ForwardingNoteModel>().ToList();
                var PreviewMineralGrade = result.Read<ForwardingNoteModel>().ToList();
                var PreviewRailway = result.Read<ForwardingNoteModel>().ToList();
                var PreviewEndUser = result.Read<ForwardingNoteModel>().ToList();
                ObjResult.PermitPreviewLst = PreviewPermit;
                ObjResult.MineralPreviewLst = PreviewMineral;
                ObjResult.MineralGradePreviewLst = PreviewMineralGrade;
                ObjResult.RailwaySidingLst = PreviewRailway;
                ObjResult.EndUserPreviewLst = PreviewEndUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Add RTP Application
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddRTPApplication(ForwardingNoteModel model)
        {
            MessageEF objMessage = new MessageEF();
            List<ForwardingNoteModel> ObjUserTypeList = new List<ForwardingNoteModel>();
            string proc = "uspForwardingNote";

            try
            {
                var p = new DynamicParameters();
                if (model != null && model.ForwardingNoteId > 0)
                {
                    p.Add("ForwardingNoteId", model.ForwardingNoteId);
                    p.Add("Check", 33);
                }
                else
                {
                    p.Add("Check", 2);
                }
                p.Add("BulkPermitId", model.BulkPermitId);
                p.Add("MineralId", model.MineralId);//model.LeaseInfoId
                p.Add("MineralGradeId", model.MineralGradeId);
                p.Add("ReqQty", model.ReqQty);
                p.Add("RailwayId", model.RailwayId);
                p.Add("EndUserId", model.EndUserId);
                p.Add("UnitId", model.UnitId);
                p.Add("ToDate", model.LeaseTo);
                p.Add("FromDate", model.LeaseFrom);
                p.Add("UserLoginId", model.UserLoginId);
                p.Add("CreatedBy", model.UserID);
                p.Add("NoofRTP", model.NoofRTP);
                p.Add("isForwarded", model.isForwarded);
                p.Add("SubUserId", model.SubUserID);            //model.LesseeId
                p.Add("EDRMNumber", model.EDRMNumber);
                p.Add("EDRMDate", model.EDRMDate);
                p.Add("EDRMCopyPath", model.EDRMCopyPath);
                p.Add("EDRMQty", model.EDRMQty);
                p.Add("DestinationRailwayId", model.DestinationRailwayId);

                var result =await Connection.ExecuteScalarAsync<string>(proc, p, commandType: CommandType.StoredProcedure);
                // int response = p.Get<int>("RESULT");

                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Msg = result.ToString();
                    objMessage.Satus = "1";
                    if (model.isForwarded == 1)
                    {
                        objMessage.Satus = "FN" + Convert.ToInt32(objMessage.Msg);
                        //Comment by sanjay kumar due to not implement DSC
                        //if (model.DSCResponse != null && model.DSCResponse != "")
                        //{
                        //    // saved DSCResponse with Forwarding note id
                        //    CHiMMS_MVC.Controllers.DSCResponse objDSCResponse = new CHiMMS_MVC.Controllers.DSCResponse();
                        //    objDSCResponse.getDSCResponse(model.DSCResponse, "ForwardingNote-Forward", Convert.ToInt32(retID)); // Response, For which purpose DSC Used , Return ID
                        //                                                                                                        //END
                        //}
                        var mobile = "";
                        var email = "";
                        var TransactionId = "";
                        if (model.ForwardingNoteId != 0)
                        {
                            var paramList = new
                            {
                                CreatedBy = model.UserID,
                                Check = 10,
                                ForwardingNoteId = model.ForwardingNoteId,
                            };
                            DynamicParameters param = new DynamicParameters();
                            var result1 =await Connection.QueryAsync<ForwardingNoteModel>("uspForwardingNote", paramList, commandType: System.Data.CommandType.StoredProcedure);
                            if (result1.Count() > 0)
                            {
                                ObjUserTypeList = result1.ToList();
                                foreach (ForwardingNoteModel dr in result1)
                                {
                                    mobile = dr.MobileNo;
                                    email = dr.EMailId;
                                    TransactionId = dr.TransactionalId;
                                    string message = "Your Railway Transit Pass Application has been Generated Successfully and Your Transaction Reference ID " + TransactionId + " Dated " + System.DateTime.Now + " . ";
                                    //comment by sanjay kumar due to not send email
                                    //  SMSHttpPostClient.Main(mobile, message);
                                    // MailService mail = new MailService();
                                    // mail.SendMail_BulkPermitApplication(TransactionId, email);

                                }
                            }
                        }
                        else
                        {
                            var paramList = new
                            {
                                CreatedBy = model.UserID,
                                Check = 10,
                                ForwardingNoteId = objMessage.Msg,
                            };
                            DynamicParameters param = new DynamicParameters();
                            var result1 =await Connection.QueryAsync<ForwardingNoteModel>("uspForwardingNote", paramList, commandType: System.Data.CommandType.StoredProcedure);
                            if (result1.Count() > 0)
                            {
                                ObjUserTypeList = result1.ToList();
                                foreach (ForwardingNoteModel dr in result1)
                                {
                                    mobile = dr.MobileNo;
                                    email = dr.EMailId;
                                    TransactionId = dr.TransactionalId;
                                    string message = "Your Railway Transit Pass Application has been Generated Successfully and Your Transaction Reference ID " + TransactionId + " Dated " + System.DateTime.Now + " . ";
                                    //comment by sanjay kumar due to not send email
                                    //  SMSHttpPostClient.Main(mobile, message);
                                    // MailService mail = new MailService();
                                    // mail.SendMail_BulkPermitApplication(TransactionId, email);

                                }

                            }
                        }
                        
                    }

                }
                else
                {
                    objMessage.Satus = "3";
                }
            }
            catch (Exception ex)
            {
                objMessage.Satus = "-1";
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Following method is used for get Forwading Transaction no
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ForwardingNoteModel>> GetForwadingTransactionNo(ForwardingNoteModel objUser)
        {
            List<ForwardingNoteModel> ObjUserTypeList = new List<ForwardingNoteModel>();
            try
            {
                var paramList = new
                {
                    USERID = objUser.UserID,
                    FNID= objUser.ForwardingNoteId,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<ForwardingNoteModel>("getFNTransactionNo", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjUserTypeList = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjUserTypeList;

        }
        /// <summary>
        /// Get all Available data
        /// </summary>
        /// <param name="BulkPermitId"></param>
        /// <returns></returns>
        public async Task<List<ForwardingNoteModel>> GetAvailableData(ForwardingNoteModel objUser)
        {
            List<ForwardingNoteModel> ObjUserTypeList = new List<ForwardingNoteModel>();
            try
            {
                var paramList = new
                {
                    CreatedBy = objUser.UserID,
                    BulkPermitId = objUser.BulkPermitId,
                    Check=1,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<ForwardingNoteModel>("uspForwardingNote", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjUserTypeList = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjUserTypeList;

        }
        /// <summary>
        /// To display the list after apply RTP permit
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public async Task<List<ForwardingNoteModel>> GetDGDMOFN(ForwardingNoteModel objUser)
        {
            List<ForwardingNoteModel> ObjUserTypeList = new List<ForwardingNoteModel>();
            int status=0;
            if(objUser.Status==0)
            {
                status = 1;
            }
           else if (objUser.Status == 2)
            {
                status = 2;
            }
            else if (objUser.Status == 3)
            {
                status = 3;
            }
            else if (objUser.Status == 4)
            {
                status = 4;
            }
            try
            {
                var paramList = new
                {
                    CreatedBy = objUser.UserID,
                    FromDate1 = objUser.From,
                    ToDate1 = objUser.To,
                    Status=status,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<ForwardingNoteModel>("uspGetAllForwardingNote", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjUserTypeList = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjUserTypeList;

        }
        /// <summary>
        /// Get the data and bind for generate RTP pass
        /// </summary>
        /// <param name="ForwardingNoteId"></param>
        /// <returns></returns>
        public async Task<List<ForwardingNoteModel>> GenerateRTPPass(ForwardingNoteModel objUser)
        {
            List<ForwardingNoteModel> ObjUserTypeList = new List<ForwardingNoteModel>();
           
            try
            {
                var paramList = new
                {
                    UserID = objUser.UserID,
                    ForwardingNoteId=objUser.ForwardingNoteId,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<ForwardingNoteModel>("uspGenerateRTPUsingForwardingNote", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjUserTypeList = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjUserTypeList;

        }
        /// <summary>
        /// Get the details of permit that to be close
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ForwardingNoteModel>> GetCloseRTPPassDetailsList(ForwardingNoteModel objUser)
        {
            List<ForwardingNoteModel> ObjUserTypeList = new List<ForwardingNoteModel>();

            try
            {
                var paramList = new
                {
                    UserID = objUser.UserID,
                    ForwardingNoteId = objUser.ForwardingNoteId,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<ForwardingNoteModel>("uspFinalForwardingNote_CLoseRTPIssuedPass", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjUserTypeList = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjUserTypeList;

        }
        /// <summary>
        /// Close Permit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> CloseRTPTripFor(ForwardingNoteModel model)
        {
            MessageEF objMessage = new MessageEF();
            List<ForwardingNoteModel> ObjUserTypeList = new List<ForwardingNoteModel>();
            string proc = "uspClosedAll_RPTPDetails";

            try
            {
                var p = new DynamicParameters();
                p.Add("UserId", model.UserID);
                p.Add("ForwardingNoteID", model.ForwardingNoteId);//model.LeaseInfoId
                p.Add("RTPPassId", model.RTP_Id);
                p.Add("RTPQty", model.ReqQty);
                p.Add("RTPDate", model.Date_OfExecution);
                p.Add("Chk", 3);
                p.Add("FilePath", model.EDRMCopyPath);
                p.Add("FileName", model.FileName);
                var result =await Connection.ExecuteScalarAsync<string>(proc, p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();

                }
                else
                {
                    objMessage.Satus = "FAILED";
                }
            }
            catch (Exception ex)
            {
                objMessage.Satus = "-1";
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Generate RTP pass and continue
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateRTPPass(ForwardingNoteModel model)
        {
            MessageEF objMessage = new MessageEF();
            List<ForwardingNoteModel> ObjUserTypeList = new List<ForwardingNoteModel>();
            try
            {
                var p = new DynamicParameters();
                p.Add("UserId", model.UserID);
                p.Add("ForwardingNoteID", model.ForwardingNoteId);//model.LeaseInfoId
                p.Add("SubUserId", model.SubUserID);
                p.Add("TrainNo", model.TrainNo);
                p.Add("RackNo", model.RackNo);
                p.Add("Chk", 1);
                p.Add("ApprovedQty", model.ApprovedQty);
                p.Add("PassClick", model.PassClick);
                p.Add("RecordSaved",dbType:DbType.Int32,direction:ParameterDirection.Output);
                var result =await Connection.ExecuteScalarAsync<string>("uspClosedAll_RPTPDetails", p, commandType: CommandType.StoredProcedure);
                int RecordSaved = p.Get<int>("RecordSaved");
                //if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                //{
                //    objMessage.Satus = result.ToString();

                //}
                if (!string.IsNullOrEmpty(Convert.ToString(RecordSaved)))
                {
                    objMessage.Satus = RecordSaved.ToString();

                }
            }
            catch (Exception ex)
            {
                objMessage.Satus = "-1";
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Get details of  RTP to generate and close
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<List<ForwardingNoteModel>> PrintAndCloseTP(ForwardingNoteModel model)
        {
            List<ForwardingNoteModel> ObjUserTypeList = new List<ForwardingNoteModel>();

            try
            {
                var paramList = new
                {
                    UserID = model.UserID,
                    ForwardingNoteId = model.ForwardingNoteId,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<ForwardingNoteModel>("uspGenerateRTPUsingForwardingNote", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjUserTypeList = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjUserTypeList;
        }
        /// <summary>
        /// Update status to generate Permit  
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> DSCPathUpdate(UpdateDSCPath model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("fileName", model.fileName);
                p.Add("ID", model.ID);
                p.Add("UpdateIn", model.UpdateIn);
                p.Add("UserId", model.UserId);
                p.Add("MonthYear", model.MonthYear);
                var result = await Connection.ExecuteScalarAsync<string>("UpdateDSCPath", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();

                }
                else
                {
                    objMessage.Satus = string.Empty;
                }
            }
            catch (Exception ex)
            {
                objMessage.Satus = "-1";
                throw ex;
            }
            return objMessage;
        }
        #region License Approval ACK Detail for MSG
        /// <summary>
        /// License Approval ACK Detail for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public async Task<LicenseFinalApproval> LICENSE_APP_ACK(UpdateDSCPath updateDSCPath)
        {
            LicenseFinalApproval licenseFinalApproval = new LicenseFinalApproval();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 7);
                param.Add("@UserId", updateDSCPath.UserId);
                param.Add("@LicenseAppId", updateDSCPath.ID);
                var result = await Connection.QueryAsync<LicenseFinalApproval>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    licenseFinalApproval = result.FirstOrDefault();
                }
                return licenseFinalApproval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region License App Grant Order detail for MSG
        /// <summary>
        /// License App Grant Order detail for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public async Task<LicenseFinalApproval> LICENSE_APP_GRANT_ORDER(UpdateDSCPath updateDSCPath)
        {
            LicenseFinalApproval licenseFinalApproval = new LicenseFinalApproval();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 9);
                param.Add("@UserId", updateDSCPath.UserId);
                param.Add("@LicenseAppId", updateDSCPath.ID);
                var result = await Connection.QueryAsync<LicenseFinalApproval>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    licenseFinalApproval = result.FirstOrDefault();
                }
                return licenseFinalApproval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Lessee ACK Detail for MSG
        /// <summary>
        /// License Approval ACK Detail for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public async Task<LesseeFinalApproval> LESSEE_BP(UpdateDSCPath updateDSCPath)
        {
            LesseeFinalApproval lesseeFinalApproval = new LesseeFinalApproval();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 18);
                param.Add("@BulkPermitId", updateDSCPath.ID);
                var result = await Connection.QueryAsync<LesseeFinalApproval>("uspCoalEPermit", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lesseeFinalApproval = result.FirstOrDefault();
                }
                return lesseeFinalApproval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
