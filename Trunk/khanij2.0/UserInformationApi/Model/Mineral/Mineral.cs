// ***********************************************************************
//  Model Name               : Mineral.cs
//  Desciption               : Used to manage preferred Bidder information
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 11-may-2021
// ***********************************************************************

using Dapper;
using MasterApi.Factory;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInformationApi.Repository;
using UserInformationEF;
using Appkey;

namespace UserInformationApi.Model.Mineral
{
    public class Mineral : RepositoryBase, IMineral
    {

        public Mineral(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        /// <summary>
        /// Added by suroj 1-may-2021 to get Auction type
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public List<PreferredBidder> GetAuctionType(PreferredBidder model)
        {

            List<PreferredBidder> objraise = new List<PreferredBidder>();
            try
            {
                var paramList = new
                {
                    Userid = model.userid, //objRaiseTicket.User,
                   

                };
                var result = Connection.ExecuteReader("uspGetAuctionTypeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = new PreferredBidder();
                   
                        model.Auctiontypeid = Convert.ToInt16(dt.Rows[i]["AuctionId"]);
                        model.Type = dt.Rows[i]["Type"].ToString();
                    objraise.Add(model);
                }
              
                return objraise;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objraise = null;
            }



        }
        /// <summary>
        /// Added by suroj on21-apr-2021 to bind lease type
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<PreferredBidder> FetchLeaseType(PreferredBidder model)
        {
            List<PreferredBidder> objraise = new List<PreferredBidder>();
            try
            {
                var paramList = new
                {
                    Userid = model.userid, //objRaiseTicket.User,
                };
                var result = Connection.ExecuteReader("uspGetLeaseType", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = new PreferredBidder();

                    model.LeaseTypeID = Convert.ToInt16(dt.Rows[i]["LeaseTypeID"]);
                    model.LeaseTypeName = dt.Rows[i]["LeaseTypeName"].ToString();
                    objraise.Add(model);
                }

                return objraise;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objraise = null;
            }



        }
        /// <summary>
        /// Added by suroj 2-may-2021 to get Mineral list Non Coal
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public List<PreferredBidder> GetMineralNonCoal(PreferredBidder model)
        {
            List<PreferredBidder> objraise = new List<PreferredBidder>();
            try
            {
                var paramList = new
                {
                    Userid = model.userid, //objRaiseTicket.User,
                };
                var result = Connection.ExecuteReader("uspGetLOIMineral", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = new PreferredBidder();

                    model.MineralId = Convert.ToInt16(dt.Rows[i]["MineralID"]);
                    model.MineralName = dt.Rows[i]["MineralName"].ToString();
                    objraise.Add(model);
                }

                return objraise;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objraise = null;
            }



        }
        /// <summary>
        /// Added by suroj 4-may-2021 to get District list agnaist state id
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public List<PreferredBidder> GetDistrictListByState(PreferredBidder model)
        {
            List<PreferredBidder> objraise = new List<PreferredBidder>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = model.Action,
                    P_STATE_ID=model.Stateid,
                    P_INT_DISTRICTID=model.DistrictId
                };
                var result = Connection.ExecuteReader("USPGETLEASEDISTRICT", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = new PreferredBidder();

                    model.DistrictId = Convert.ToInt16(dt.Rows[i]["DISTRICTID"]);
                    model.DistrictName = dt.Rows[i]["DISTRICTNAME"].ToString();
                    objraise.Add(model);
                }

                return objraise;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objraise = null;
            }



        }
        /// <summary>
        /// Added by suroj 2-may-2021 to get tehsil list aganast district id
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public List<PreferredBidder> GetTehsilListByDistrict(PreferredBidder model)
        {
            List<PreferredBidder> objraise = new List<PreferredBidder>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = model.Action,
                    P_STATE_ID = model.Stateid,
                    P_INT_DISTRICTID = model.DistrictId
                };
                var result = Connection.ExecuteReader("USPGETLEASEDISTRICT", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = new PreferredBidder();

                    model.TehsilId = Convert.ToInt16(dt.Rows[i]["TehsilId"]);
                    model.TehsilName = dt.Rows[i]["TehsilName"].ToString();
                    objraise.Add(model);
                }

                return objraise;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objraise = null;
            }



        }
        /// <summary>
        /// Added by suroj 2-may-2021 to get village list against tehsil id
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>

        public List<PreferredBidder> GetVillageListByTehsil(PreferredBidder model)
        {
            List<PreferredBidder> objraise = new List<PreferredBidder>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = model.Action,
                    P_STATE_ID = model.Stateid,
                    P_INT_DISTRICTID = model.DistrictId,
                    P_INT_TEHSIL=model.TehsilId
                };
                var result = Connection.ExecuteReader("USPGETLEASEDISTRICT", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = new PreferredBidder();

                    model.VillageId = Convert.ToInt16(dt.Rows[i]["VillageID"]);
                    model.VillageName = dt.Rows[i]["VillageName"].ToString();
                    objraise.Add(model);
                }

                return objraise;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objraise = null;
            }



        }

        /// <summary>
        /// Added by suroj 2-may-2021 to Add preferred bidder request
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public MessageEF Add(LeaseApplicationModel model)
        {
            MessageEF objMessage = new MessageEF();
            StringBuilder sb = new StringBuilder();
            string Result;
            string Result_msg = null;
            string First_Installment_UploadPath = string.Empty;
            string First_Installment_UploadName = string.Empty;
            string Second_Installment_UploadPath = string.Empty;
            string Second_Installment_UploadName = string.Empty;
            string Third_Installment_UploadPath = string.Empty;
            string Third_Installment_UploadName = string.Empty;
            string PerformanceSecurity_Installment_UploadName = string.Empty;
            string PerformanceSecurity_Installment_UploadPath = string.Empty;
            string MajorMineral_CL_PerformanceSecurity_Installment_UploadName = string.Empty;
            string MajorMineral_CL_PerformanceSecurity_Installment_UploadPath = string.Empty;

            try
            {
                //if (model.TypeOfLands != null && TypeOfLands.Count > 0)
                //{
                //    foreach (var i in TypeOfLands)
                //    {
                //        sb.Append(i);
                //        sb.Append(",");
                //    }
                //    sb.Length--;
                //}

                var P = new DynamicParameters();

                if (model.MineralType == "Minor Mineral")
                {
                    if (model.LeaseType != "CL" || model.LeaseType != "2") //2 for CL
                    {
                        P.Add("@PerformanceSecurity_Installment_Amount ", model.PerformanceSecurity_Installment_Amount);
                        P.Add("@PerformanceSecurity_Installment_ScheduleDate ", model.PerformanceSecurity_Installment_ScheduleDate);
                        P.Add("@PerformanceSecurity_Installment_SubmissionDate ", model.PerformanceSecurity_Installment_SubmissionDate);
                        P.Add("@PerformanceSecurity_Installment_FileName ", PerformanceSecurity_Installment_UploadName);
                        P.Add("@PerformanceSecurity_Installment_FilePath", PerformanceSecurity_Installment_UploadPath);
                    }
                }
                else if (model.MineralType == "Major Mineral")
                {
                    P.Add("@PerformanceSecurity_Installment_ScheduleDate ", model.PerformanceSecurity_Installment_ScheduleDate);
                    P.Add("@PerformanceSecurity_Installment_SubmissionDate ", model.PerformanceSecurity_Installment_SubmissionDate);
                    P.Add("@PerformanceSecurity_Installment_FileName ", PerformanceSecurity_Installment_UploadName);
                    P.Add("@PerformanceSecurity_Installment_FilePath", PerformanceSecurity_Installment_UploadPath);
                    P.Add("@PerformanceSecurity_Installment_Amount ", model.PerformanceSecurity_Installment_Amount);
                    if (model.LeaseType != "CL" || model.LeaseType != "2") //2 for CL
                    {
                        P.Add("@MajorMineral_CL_DateOfLOI", model.DateOfLOI);
                    }
                    else
                    {
                        P.Add("@DateOfLOI", model.DateOfLOI);
                    }
                }
                P.Add("@SubmissionID", model.SubmissionID);
                P.Add("@StatusOfLessee", model.CategoryOfLicensee);
                P.Add("@FirmAs", model.FirmAs);
                P.Add("@CompanyAs", model.CompanyAs);
                P.Add("@ModeOfGrant", model.modeOfGrant);
                P.Add("@LesseeName", model.NameOfApplicant);
                P.Add("@MobileNo", model.ApplicantMobileNo);
                P.Add("@Email", model.ApplicantEmailId);
                P.Add("@Designation", model.Designation);
                P.Add("@Address", model.AddressOfApplicant);
                P.Add("@StateId", model.StateID);
                P.Add("@DistrictId", model.DistrictID);
                P.Add("@TehsilId", model.TehsilID);
                P.Add("@VillageId", model.VillageID);
                P.Add("@KharsaNo", model.KhasraNo);
                P.Add("@KharsaNo_FilePath", model.KhasraNo_FilePath);
                P.Add("@ExcelKharsaNo", model.ExcelKhasraNo);
                P.Add("@ExcelKharsaNo_FilePath", model.ExcelKhasraNo_FilePath);
                P.Add("@Block", model.BlockForestRange);
                P.Add("@PinCode", Convert.ToInt32(model.Pincode));
                P.Add("@AreaInHect", model.AreaInHect);
                P.Add("@TypeOfLand", Convert.ToString(sb));
                P.Add("@GovernmentAs", model.GovernmentAs);
                P.Add("@PrivatAs", model.PrivateAs);
                P.Add("@ToposheetNo", model.TopoSheetNo);
                P.Add("@Coordinates", model.Coordinates);
                P.Add("@Coordinates_FilePath", model.Coordinates_FilePath);
                P.Add("@ExcelCoordinates", model.ExcelCoordinates);
                P.Add("@ExcelCoordinates_FilePath", model.ExcelCoordinates_FilePath);
                P.Add("@MineralTypeId", model.MineralTypeID);
                P.Add("@MineralId", model.MineralID);
                P.Add("@PANFileName", model.File_PAN_Card);
                P.Add("@TINFileName", model.File_TIN_Card);
                P.Add("@DemarcationReportFileName", model.File_DemarcationReport);
                P.Add("@CompanyId", model.CompanyId);

                P.Add("@Reserve", model.Reserve);
                P.Add("@AreaGovernmentAs", model.AreaGovernmentAs);
                P.Add("@AreaForestAs", model.AreaForestAs);
                P.Add("@AreaPrivateAs", model.AreaPrivateAs);
                P.Add("@EVR ", model.EVR);
                P.Add("@FinalPriceOffer ", model.FinalPriceOffer);
                P.Add("@TotalUpfrontPayment ", model.TotalUpfrontPayment);
                P.Add("@PerformanceSecurity ", model.PerformanceSecurity);
                P.Add("@AuctionMoney ", model.AuctionMoney);
                P.Add("@First_Installment_Amount", model.First_Installment_Amount);
                P.Add("@Second_Installment_Amount", model.Second_Installment_Amount);
                P.Add("@Third_Installment_Amount", model.Third_Installment_Amount);

                P.Add("@First_Installment_ScheduleDate ", model.First_Installment_ScheduleDate);
                P.Add("@Second_Installment_ScheduleDate", model.Second_Installment_ScheduleDate);
                P.Add("@Third_Installment_ScheduleDate", model.Third_Installment_ScheduleDate);

                P.Add("@First_Installment_DateOfDiposite ", model.First_Installment_DateOfDiposite);
                P.Add("@Second_Installment_DateOfDiposite", model.Second_Installment_DateOfDiposite);
                P.Add("@Third_Installment_DateOfDiposite", model.Third_Installment_DateOfDiposite);

                P.Add("@First_Installment_FileName", First_Installment_UploadName);
                P.Add("@First_Installment_FilePath", First_Installment_UploadPath);
                P.Add("@Second_Installment_FileName ", Second_Installment_UploadName);
                P.Add("@Second_Installment_FilePath ", Second_Installment_UploadPath);
                P.Add("@Third_Installment_FileName", Third_Installment_UploadName);
                P.Add("@Third_Installment_FilePath ", Third_Installment_UploadPath);

                P.Add("@LeaseTypeId", model.LeaseTypeId);

                P.Add("@MajorMineral_CL_Reserve", model.MajorMineral_CL_Reserve);
                P.Add("@MajorMineral_CL_EVR", model.MajorMineral_CL_EVR);
                P.Add("@MajorMineral_CL_FinalPriceOffer ", model.MajorMineral_CL_FinalPriceOffer);
                P.Add("@MajorMineral_CL_PerformanceSecurity_Installment_Amount ", model.MajorMineral_CL_PerformanceSecurity_Installment_Amount);
                P.Add("@MajorMineral_CL_PerformanceSecurity_Installment_ScheduleDate", model.MajorMineral_CL_PerformanceSecurity_Installment_ScheduleDate);
                P.Add("@MajorMineral_CL_PerformanceSecurity_Installment_SubmissionDate", model.MajorMineral_CL_PerformanceSecurity_Installment_SubmissionDate);
                P.Add("@MajorMineral_CL_PerformanceSecurity_Installment_FileName ", MajorMineral_CL_PerformanceSecurity_Installment_UploadPath);

                P.Add("@MinorMineral_CL_PerformanceSecurity_Installment_Amount ", model.PerformanceSecurity_Installment_Amount);
                P.Add("@MinorMineral_CL_PerformanceSecurity_Installment_ScheduleDate", model.PerformanceSecurity_Installment_ScheduleDate);
                P.Add("@MinorMineral_CL_PerformanceSecurity_Installment_SubmissionDate", model.PerformanceSecurity_Installment_SubmissionDate);
                P.Add("@MinorMineral_CL_PerformanceSecurity_Installment_FileName ", PerformanceSecurity_Installment_UploadName);

                P.Add("@AuctionNo", model.AuctionNo);
                P.Add("@AuctionType", model.AuctionType);
                P.Add("@PeriodFrom", model.PeriodFrom);
                P.Add("@PeriodTo", model.PeriodTo);
                P.Add("@BidStart", model.BidStart);
                P.Add("@BidFinal", model.BidFinal);
                P.Add("@BlockName", model.BlockName);
                P.Add("@BidUnitId", model.BidUnitId);
                P.Add("@BidSheetFileName", model.BidSheetFileName);
                P.Add("@BidSheetFilePath", model.BidSheetFilePath);
                P.Add("@Remarks", model.Remarks);
                P.Add("@LesseeLOI", model.LesseeLOI);
                P.Add("@OtherDocumentName", model.OtherDocumentName);
                if (model.Particpantlist != null)
                {
                    DataTable _dt = new DataTable("BulkInsertion");
                    _dt = (DataTable)model.Particpantlist;
                    if (_dt.Rows.Count > 0)
                    {
                        P.Add("@BulkInsertion", _dt, DbType.Object);
                    }
                }
                ////if (model.dt != null)
                ////{
                //    DataTable _dt1 = new DataTable("tblSingleInteger");
                //    _dt1 = (DataTable)model.dt;
                //    //if (_dt.Rows.Count > 0)
                //    //{
                //        P.Add("@tblSingleInteger", _dt1, DbType.Object);
                //    //}
                ////}

                P.Add("@MiningPlanDueDate", model.MiningPlanDueDate);

                P.Add("@Revenue", model.Revenue);
                P.Add("@Area_Revenue", (model.Revenue == false) ? "0" : model.txtRevenue);
                P.Add("@RevenueForest", model.RevenueForest);
                P.Add("@Area_RevenueForest", (model.RevenueForest == false) ? "0" : model.txtRevenueForest);
                P.Add("@Nistar", model.Nistar);
                P.Add("@Area_Nistar", (model.Nistar == false) ? "0" : model.txtNistar);
                P.Add("@Forest", model.Forest);
                P.Add("@Area_Forest", (model.Forest == false) ? "0" : model.txtForest);
                P.Add("@Tribal", model.Tribal);
                P.Add("@Area_Tribal", (model.Tribal == false) ? "0" : model.txtTribal);
                P.Add("@NonTribal", model.NonTribal);
                P.Add("@Area_NonTribal", (model.NonTribal == false) ? "0" : model.txtNonTribal);
                P.Add("@Location", model.Location);
                P.Add("@UserId", model.UserId);
                P.Add("@UserLoginId", model.UserId);
                if (model.FOR == "PreferredBidder")
                {
                    P.Add("@chk", "ApplyForML");
                }
                else if (model.FOR == "ApplyForQL")
                {
                    P.Add("@chk", "ApplyForQL");
                }
                else if (model.FOR == "ApproveForML")
                {
                    P.Add("@chk", "ApproveForML");
                }
                else if (model.FOR == "ApproveForQL")
                {
                    P.Add("@chk", "ApproveForQL");
                }
                else if (model.FOR == "Insert")
                {
                    P.Add("@chk", "INSERT");
                }
                else if (model.FOR == "Approve")
                {
                    P.Add("@chk", "Approve");
                }
                else if (model.FOR == "Reject")
                {
                    P.Add("@chk", "Reject");
                }
                else if (model.FOR == "Forward")
                {
                    P.Add("@chk", "Forward");
                }
                else if (model.FOR == "View")
                {
                    P.Add("@chk", "DGMUpdate");
                }
                else
                {
                    P.Add("@chk", "INSERT");
                }

                var result = Connection.Query<string>("uspLesseeLOIOperation", P, commandType: CommandType.StoredProcedure);
                objMessage.Satus = result.First();
                if (objMessage.Satus == "SUCCESS")
                {
                    objMessage.Msg = "Data saved successfully";

                }
                else if (objMessage.Satus == "Reject")
                {
                    objMessage.Msg = "Data reject successfully";

                }
                else if (objMessage.Satus == "Approve")
                {
                    objMessage.Msg = "Data approve successfully";

                }
                else if (objMessage.Satus == "Forward")
                {
                    objMessage.Msg = "Data Forward successfully";

                }

                else if (objMessage.Satus == "Record Exist")
                {
                    objMessage.Msg = "Record Exist";

                }
                if (objMessage.Satus != "")
                {
                    //if (Convert.ToInt32(result.Count()) > 0)
                    //{
                    //    var D = new DynamicParameters();
                    //    D.Add("@chk", "GET_USERNAME_PASSWORD");

                    //    D.Add("@UserId", objMessage.Satus);
                    //    var _result = Connection.ExecuteReader("uspLesseeLOIOperation", D, commandType: CommandType.StoredProcedure);
                    //    DataTable dt = new DataTable();
                    //    dt.Load(_result);
                    //    for (int i = 0; i < dt.Rows.Count; i++)
                    //    {
                    //        model = new LeaseApplicationModel();

                    //        model.UserName = (dt.Rows[i]["UserName"]).ToString();
                    //        model.Password = dt.Rows[i]["Password"].ToString();
                    //        if (model.UserName != null && model.Password != null)
                    //        {
                    //            if (model.UserName != "" && model.Password != "")
                    //            {
                    //                #region Send SMS
                    //                try
                    //                {
                    //                    //string message = "You are successfully registered with Khanij Online Portal. Your Registration Number is " + model.UserCode + " Dated " + System.DateTime.Now + Environment.NewLine + Environment.NewLine +
                    //                    //                    "You can login into Khanij Online Portal using below login credential" + Environment.NewLine + Environment.NewLine +
                    //                    //                     "User Name : " + model.UserName + Environment.NewLine + "Password : " + model.Password + Environment.NewLine + Environment.NewLine +
                    //                    //                     "Please check your e-mail for details of registration";

                    //                    //SMSHttpPostClient.Main(model.ApplicantMobileNo, message);

                    //                    objMessage.Msg = "You are successfully registered with Khanij Online Portal." +
                    //                                        "You can login into Khanij Online Portal using below login credential " +
                    //                                         "User Name : " + model.UserName + " and Password : " + model.Password +
                    //                                         " Please check your e-mail for details of registration"; ;

                    //                }
                    //                catch (Exception)
                    //                {

                    //                }
                    //                #endregion

                    //                //#region Send Mail
                    //                //try
                    //                //{
                    //                //    UserMasterModel uModel = new UserMasterModel();
                    //                //    uModel.EMailId = model.ApplicantEmailId;
                    //                //    uModel.ApplicantName = model.NameOfApplicant;
                    //                //    uModel.UserName = model.UserName;
                    //                //    uModel.Password = model.Password;
                    //                //    uModel.UserCode = model.UserCode;
                    //                //    MailService mail = new MailService();
                    //                //    //mail.SendMail(uModel);
                    //                //    mail.SendMail_LOI(uModel, M_Name, B_Name, D_Name, Auction_No, Area);
                    //                //    //return RedirectToAction("ProfileView", "EndUserProfile");
                    //                //}
                    //                //catch (Exception)
                    //                //{
                    //                //    //TempData["AckMessage"] = "0";
                    //                //    //return RedirectToAction("ProfileView", "EndUserProfile");
                    //                //}
                    //                //#endregion
                    //            }
                    //        }
                    //    }
                    //}
                }
                else if (Convert.ToInt32(result.Count()) == 0)
                {
                    Result_msg = "Mobile number and Email id already exist.Please register with new Mobile number and Email id and try again!";
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// Added by suroj 6-may-2021 to get Auction No already present or not
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public int CheckAuctionNo(LeaseApplicationModel model)
        {
            List<PreferredBidder> objraise = new List<PreferredBidder>();
            try
            {
                var paramList = new
                {
                    chk = "ChkForAuctionNo",
                    AuctionNo = model.AuctionNo,
                   
                };
                int response = Connection.ExecuteScalar<int>("uspLesseeLOIOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objraise = null;
            }



        }

        /// <summary>
        /// Added by suroj 10-may-2021 to view preferred bidder request
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public List<LeaseApplicationModel> GetPreferredBidderRequest(LeaseApplicationModel model)
        {
            List<LeaseApplicationModel> objraise = new List<LeaseApplicationModel>();
            try
            {
                var paramList = new
                {
                    chk = "SELECT",
                    UserID = model.UserId,
                    
                };
                var result = Connection.ExecuteReader("uspLesseeLOIOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LeaseApplicationModel  objModel = new LeaseApplicationModel();

                    objModel.SrNo = Convert.ToInt16(dt.Rows[i]["SrNo"]);
                    objModel.LesseeLOI = Convert.ToInt16(dt.Rows[i]["LesseeLOI"]);
                    objModel.AuctionNo = Convert.ToString(dt.Rows[i]["AuctionNo"]);
                    objModel.AuctionType = Convert.ToString(dt.Rows[i]["AuctionType"]);
                    objModel.PeriodFrom = Convert.ToString(dt.Rows[i]["PeriodFrom"]);
                    objModel.PeriodTo = Convert.ToString(dt.Rows[i]["PeriodTo"]);
                    objModel.BidStart = Convert.ToString(dt.Rows[i]["BidStart"]);
                    objModel.BidFinal = Convert.ToString(dt.Rows[i]["BidFinal"]);
                    objModel.BlockName = Convert.ToString(dt.Rows[i]["BlockName"]);
                    objModel.BidUnitId = Convert.ToString(dt.Rows[i]["BidUnitId"]);
                    objModel.BidSheetFileName = Convert.ToString(dt.Rows[i]["BidSheetFileName"]);
                    objModel.BidSheetFilePath = Convert.ToString(dt.Rows[i]["BidSheetFilePath"]);
                    objModel.Remarks = Convert.ToString(dt.Rows[i]["Remarks"]);
                    objModel.Status = Convert.ToInt16(dt.Rows[i]["Status"]);
                    objModel.IsView = Convert.ToInt16(dt.Rows[i]["IsView"]);
                    objModel.StrStatus = Convert.ToString(dt.Rows[i]["StrStatus"]);
                    objModel.LeaseType = Convert.ToString(dt.Rows[i]["LeaseTypeName"]);
                    objModel.DistrictName = Convert.ToString(dt.Rows[i]["DistrictName"]);
                    objModel.MineralName = Convert.ToString(dt.Rows[i]["MineralName"]);
                    objModel.Location = Convert.ToString(dt.Rows[i]["Location"]) + " (" + objModel.DistrictName + ", Chhattisgarh)";
                    objraise.Add(objModel);
                }

                return objraise;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objraise = null;
            }



        }
       
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
        /// <summary>
        /// Added by suroj on 8-may-2021 to get Edit preferred bidder data
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public PreferredBidder GetEditPreferredBidderRequest(PreferredBidder model)
        {
            List<PreferredBidder> objraise = new List<PreferredBidder>();
            PreferredBidder objModel = new PreferredBidder();
            try
            {
                var paramList = new
                {
                    chk = "SELECT",
                    UserID = model.userid,
                    LesseeLOI = model.LesseeLOI,
                };
                var result = Connection.ExecuteReader("uspLesseeLOIOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var ds = ConvertDataReaderToDataSet(result);

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objModel.LesseeLOI = model.LesseeLOI;
                        objModel.AuctionNo = Convert.ToString(ds.Tables[0].Rows[0]["AuctionNo"]);
                        objModel.AuctionType = Convert.ToString(ds.Tables[0].Rows[0]["AuctionId"]);
                        objModel.PeriodFrom = Convert.ToString(ds.Tables[0].Rows[0]["PeriodFrom"]);
                        objModel.PeriodTo = Convert.ToString(ds.Tables[0].Rows[0]["PeriodTo"]);
                        objModel.BidStart = Convert.ToString(ds.Tables[0].Rows[0]["BidStart"]);
                        objModel.BidFinal = Convert.ToString(ds.Tables[0].Rows[0]["BidFinal"]);
                        objModel.BlockName = Convert.ToString(ds.Tables[0].Rows[0]["BlockName"]);
                        objModel.BidUnitId = Convert.ToString(ds.Tables[0].Rows[0]["BidUnitId"]);
                        objModel.BidSheetFileName = Convert.ToString(ds.Tables[0].Rows[0]["BidSheetFileName"]);
                        objModel.BidSheetFilePath = Convert.ToString(ds.Tables[0].Rows[0]["BidSheetFilePath"]);
                        //objModel.BidSheetFilePath = @"//10.195.82.91/khanij/Upload/Lessee/APPLICATION/BidSheetFile/636937814287982153_Untitled.png";
                        objModel.LeaseType = Convert.ToString(ds.Tables[0].Rows[0]["LeaseTypeId"]);
                        objModel.DistrictId = Convert.ToInt32(ds.Tables[0].Rows[0]["DistrictID"]);
                        objModel.AreaInHect = Convert.ToString(ds.Tables[0].Rows[0]["AreaInHect"]);
                        objModel.MineralId = Convert.ToInt32(ds.Tables[0].Rows[0]["MineralID"]);
                        objModel.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        objModel.Location = Convert.ToString(ds.Tables[0].Rows[0]["Location"]);
                        objModel.TehsilId = Int32.Parse(ds.Tables[0].Rows[0]["TehsilID"].ToString());
                        objModel.VillageId = Int32.Parse(ds.Tables[0].Rows[0]["VillageID"].ToString());
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objModel.ParticipatesTable = ds.Tables[1];
                        objModel.ParticipatesTable.Rows[0]["Gov_IsSelected"] = 1;
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

                objraise = null;
            }



        }

        /// <summary>
        /// First payment installisation data fetch added by suroj
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public LeaseApplicationModel GetFirstinstallment(LeaseApplicationModel model)
        {
            
            LeaseApplicationModel objModel = new LeaseApplicationModel();
            DataTable list = new DataTable();
            try
            {
                var paramList = new
                {
                    SpMode = "GET_TRANSACTIONID",
                    UserId = model.UserId,
                    LesseeLoi = model.LesseeLOI,
                };
                var result = Connection.ExecuteReader("uspSubmissionOfStatutoryClearance", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var ds = ConvertDataReaderToDataSet(result);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    list.Load(result);
                   
                }
                if (ds != null && ds.Tables[1].Rows.Count > 0)
                {
                    model.CategoryOfLicensee = Convert.ToString(ds.Tables[1].Rows[0]["StatusOfLessee"]);
                    model.CompanyName = Convert.ToString(ds.Tables[1].Rows[0]["CompanyName"]);
                    model.NameOfApplicant = Convert.ToString(ds.Tables[1].Rows[0]["LesseeName"]);
                    model.Status = Convert.ToInt16(ds.Tables[1].Rows[0]["Status"]);
                    model.First_Installment_Amount = Convert.ToString(ds.Tables[1].Rows[0]["First_Installment_Amount"]);
                    model.First_Installment_DateOfDiposite = Convert.ToString(ds.Tables[1].Rows[0]["First_Installment_DateOfDiposite"]);

                    model.MiningPlanDueDate = Convert.ToString(ds.Tables[1].Rows[0]["MiningPlanDueDate"]);
                    model.PerformanceSecurity_Installment_Amount = Convert.ToString(ds.Tables[1].Rows[0]["PerformanceSecurity_Installment_Amount"]);
                    model.PerformanceSecurity_Installment_ScheduleDate = Convert.ToString(ds.Tables[1].Rows[0]["PerformanceSecurity_Installment_ScheduleDate"]);
                    model.First_Installment_Amount = Convert.ToString(ds.Tables[1].Rows[0]["First_Installment_Amount"]);
                    model.First_Installment_ScheduleDate = Convert.ToString(ds.Tables[1].Rows[0]["First_Installment_ScheduleDate"]);
                    model.Second_Installment_Amount = Convert.ToString(ds.Tables[1].Rows[0]["Second_Installment_Amount"]);
                    model.Second_Installment_ScheduleDate = Convert.ToString(ds.Tables[1].Rows[0]["Second_Installment_ScheduleDate"]);
                    model.Third_Installment_Amount = Convert.ToString(ds.Tables[1].Rows[0]["Third_Installment_Amount"]);
                    model.Third_Installment_ScheduleDate = Convert.ToString(ds.Tables[1].Rows[0]["Third_Installment_ScheduleDate"]);

                    model.StrStatus = Convert.ToString(ds.Tables[1].Rows[0]["StrStatus"]);
                    model.DateOfLOI = Convert.ToString(ds.Tables[1].Rows[0]["IssueDate2"]);
                    model.IssueDate = Convert.ToString(ds.Tables[1].Rows[0]["IssueDate"]);
                    model.WorkingPermissionUploadedOn = Convert.ToString(ds.Tables[1].Rows[0]["BidderIssuance_Date"]);

                    //list = objCon.GetDataTable(cmd);
                }
                 List<string> DocList = new List<string>();
                if (ds != null && ds.Tables[2].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        DocList.Add(Convert.ToString(ds.Tables[2].Rows[i]["DocName"]));
                    }
                    //ViewBag.OtherDocumentName = Convert.ToString(ds.Tables[2].Rows[0]["OtherDocumentName"]);
                }
                if (ds != null && ds.Tables[3].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                    {
                        model.OtherDocHistory = ds.Tables[3];
                    }

                }
                model.doclist = DocList.ToList();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    model.ClientTransactionID = Convert.ToString(ds.Tables[0].Rows[0]["TransactionalId"]);
                    model.totalPayable = Convert.ToDecimal(ds.Tables[0].Rows[0]["EstimatedReserve"]);
                   
                }
                //ViewBag.DocList = DocList;
                return model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objModel = null;
            }



        }
        /// <summary>
        /// Added by suroj 13-may-2021 to submit payment data
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public MessageEF AddPayment(LeaseApplicationModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var P = new DynamicParameters();
                P.Add("@SubmissionDateMiningPlan ", model.SubmissionDateMiningPlan);
                P.Add("@BankGaurranty ", model.BankGaurrantyLetter);
                P.Add("@SubmissionDatePerformanceSecurity", model.SubmissionDatePerformanceSecurity);
                P.Add("@ProposedProduction", model.ProposedProductionLetter);
                P.Add("@DGPS", model.DGPSLetter);
                P.Add("@Land", model.LandLetter);
                P.Add("@Revenue", model.RevenueLetter);
                P.Add("@GramPanchayat", model.GramPanchayatLetter);
                P.Add("@DocumentofProspectingOperation", model.DocumentofProspectingOperation);
                P.Add("@SchemeofProspecting", model.SchemeofProspecting);
                P.Add("@MajorMineral_CL_FCApprovalLetter", model.MajorMineral_CL_FCApprovalLetter);
                P.Add("@MajorMineral_CL_DGPSReport", model.MajorMineral_CL_DGPSReport);
                P.Add("@MajorMineral_CL_PrivateLand", model.MajorMineral_CL_PrivateLand);
                P.Add("@SubmissionOfDraftOf_MiningPlanFilePath", model.SubmissionOfDraftOf_MiningPlanFilePath);
                P.Add("@SubmissionDateOfDraft_MiningPlan", model.SubmissionDateOfDraft_MiningPlan);
                P.Add("@UserId", model.UserId);
                P.Add("@UserLoginId", model.UserId);
                P.Add("@TotalPaidAmount", model.totalPayable);
                P.Add("@TransactionalID", model.ClientTransactionID);
                P.Add("@LeaseDeedCopy", model.LeaseDeedAgreement);
                P.Add("@WorkingPermissionCopy", model.WorkingPermission);
                P.Add("@Second_Installment_ScheduleDate", model.Second_Installment_ScheduleDate);
                P.Add("@Third_Installment_ScheduleDate", model.Third_Installment_ScheduleDate);
                P.Add("@PerformanceSecurity_Installment_ScheduleDate", model.PerformanceSecurity_Installment_ScheduleDate);
                P.Add("@Second_Installment_DateOfDiposite", model.Second_Installment_DateOfDiposite);
                P.Add("@Third_Installment_DateOfDiposite", model.Third_Installment_DateOfDiposite);
                P.Add("@PerformanceSecurity_Installment_SubmissionDate", model.PerformanceSecurity_Installment_SubmissionDate);
                P.Add("@Second_Installment_FileName", model.Second_Installment_UploadName);
                P.Add("@Second_Installment_FilePath", model.Second_Installment_UploadPath);
                P.Add("@Third_Installment_FileName", model.Third_Installment_UploadName);
                P.Add("@Third_Installment_FilePath", model.Third_Installment_UploadPath);
                P.Add("@PerformanceSecurity_Installment_FileName", model.PerformanceSecurity_Installment_UploadName);
                P.Add("@PerformanceSecurity_Installment_FilePath", model.PerformanceSecurity_Installment_UploadPath);
                P.Add("@LesseeLoi", model.LesseeLOI);
                P.Add("@DateOfLOI", model.DateOfLOI);
                P.Add("@MLApplication", model.MLApplication);
                P.Add("@WorkingPermissionUploadedOn", model.WorkingPermissionUploadedOn);
                P.Add("@MDPAUploadedDate", model.MDPAUploadedDate);
                P.Add("@MDPAFileName", model.MDPA);
                P.Add("@LeaseDeedUploadedOn", model.LeaseDeedUploadedOn);
                P.Add("@Remarks", model.Remarks);
                P.Add("@IBM_ReceivingCopy", model.IBM_ReceivingCopy);
                P.Add("@PS_BankName", model.PS_BankName);
                P.Add("@PS_BankGaurrantyNo", model.PS_BankGaurrantyNo);
                P.Add("@PS_BankGuarantyDate", model.PS_BankGuarantyDate);
                P.Add("@PS_ValidityUpto", model.PS_ValidityUpto);
                P.Add("@ApprovaDateMiningPlan", model.ApprovaDateMiningPlan);
                P.Add("@MPSOM", model.MPSOMLetter);
                P.Add("@MP_ApprovalOrderNo", model.MP_ApprovalOrderNo);
                P.Add("@MP_ValidFrom", model.MP_ValidFrom);
                P.Add("@MP_ValidUpto", model.MP_ValidUpto);
                P.Add("@EC", model.ECLetter);
                P.Add("@EC_OrderDate", model.EC_OrderDate);
                P.Add("@EC_OrderNo", model.EC_OrderNo);
                P.Add("@EC_AnnualCapacity", model.EC_AnnualCapacity);
                P.Add("@EC_ValidUpto", model.EC_ValidUpto);
                P.Add("@CTE", model.CTELetter);
                P.Add("@CTE_OrderDate", model.CTE_OrderDate);
                P.Add("@CTE_OrderNo", model.CTE_OrderNo);
                P.Add("@CTE_ValidUpto", model.CTE_ValidUpto);
                P.Add("@CTO", model.CTOLetter);
                P.Add("@CTO_OrderDate", model.CTO_OrderDate);
                P.Add("@CTO_OrderNo", model.CTO_OrderNo);
                P.Add("@FC", model.FCLetter);
                P.Add("@FC_OrderDate", model.FC_OrderDate);
                P.Add("@FC_OrderNo", model.FC_OrderNo);
                P.Add("@First_Year_PQty", model.First_Year_PQty);
                P.Add("@Second_Year_PQty", model.Second_Year_PQty);
                P.Add("@Third_Year_PQty", model.Third_Year_PQty);
                P.Add("@Fourth_Year_PQty", model.Fourth_Year_PQty);
                P.Add("@Fifth_Year_PQty", model.Fifth_Year_PQty);
                if (model.dt != null)
                {
                    DataTable _dt = new DataTable("BulkInsertion");
                    _dt = (DataTable)model.Particpantlist;
                    if (_dt.Rows.Count > 0)
                    {
                        P.Add("@BulkInsertion", _dt, DbType.Object);
                    }
                }
                if (model.SpMode == "FirstInstallment")
                {
                    P.Add("@SPMode", "FirstInstallment");
                }

                else if (model.SpMode == "DGMForward")
                {
                    P.Add("@SPMode", "DGMForward");
                }
                else if (model.SpMode == "GovApprove")
                {
                    P.Add("@SPMode", "GovApprove");
                }
                else if (model.SpMode == "GovReject")
                {
                    P.Add("@SPMode", "GovReject");
                }
                else if (model.SpMode == "Forward")
                {
                    P.Add("@SPMode", "Forward");
                }
                else if (model.SpMode == "Step1")
                {
                    P.Add("@SPMode", "Step1");
                }
                else if (model.SpMode == "Step2")
                {
                    P.Add("@SPMode", "Step2");
                }
                else if (model.SpMode == "SecondInstallment")
                {
                    P.Add("@SPMode", "SecondInstallment");
                }
                else if (model.SpMode == "Issuance Forwarding")
                {
                    P.Add("@SPMode", "Issuance Forwarding");
                }
                else if (model.SpMode == "Issuance Approval Approve")
                {
                    P.Add("@SPMode", "Issuance Approval Approve");
                }
                else if (model.SpMode == "Issuance Approval Reject")
                {
                    P.Add("@SPMode", "Issuance Approval Reject");
                }
                else if (model.SpMode == "Issuance")
                {
                    P.Add("@SPMode", "Issuance");
                }
                else if (model.SpMode == "MDPA")
                {
                    P.Add("@SPMode", "MDPA");
                }
                else if (model.SpMode == "ThirdInstallment")
                {
                    P.Add("@SPMode", "ThirdInstallment");
                }
                else if (model.SpMode == "LeaseDeed")
                {
                    P.Add("@SPMode", "LeaseDeed");
                }

                /////////////////////////////////////////////////////////////////////////////////////////////////////   
                else if (model.SpMode == "ThirdInstallment")
                {
                    P.Add("@SPMode", "THIRD_INSTALLMENTML");
                }
                else if (model.SpMode == "MajorMineralNonCoalCLStep1")
                {
                    P.Add("@SPMode", "MajorMineralNonCoalCLStepOne");
                }
                //else if (!string.IsNullOrEmpty(model.MajorMineral_CL_DGPSReport) && !string.IsNullOrEmpty(model.MajorMineral_CL_PrivateLand))
                else if (model.SpMode == "MajorMineralNonCoalCLStep2")
                {
                    P.Add("@SPMode", "MajorMineralNonCoalCLStepTwo");
                }
                //if (!string.IsNullOrEmpty(model.SubmissionDateMiningPlan) && !string.IsNullOrEmpty(model.BankGaurrantyLetter) && !string.IsNullOrEmpty(model.SubmissionDatePerformanceSecurity))
                else if (model.SpMode == "MajorMineralNonCoalMLStep1")
                {
                    P.Add("@SPMode", "MajorMineralNonCoalMLStepOne");
                }
                else if (model.SpMode == "MajorMineralNonCoalMLStep2")
                {
                    P.Add("@SPMode", "MajorMineralNonCoalMLStepTwo");
                }
                else if (model.SpMode == "MinorMineralMLStep1")
                {
                    P.Add("@SPMode", "MinorMineralMLStepOne");
                }
                else if (model.SpMode == "MinorMineralMLStep2")
                {
                    P.Add("@SPMode", "MinorMineralMLStepTwo");
                }
                else if (model.SpMode == "MinorMineralCLStep1")
                {
                    P.Add("@SPMode", "MinorMineralCLStepOne");
                }
                else if (model.SpMode == "MinorMineralCLStep2")
                {
                    P.Add("@SPMode", "MinorMineralCLStepTwo");
                }
                else if (model.SpMode == "WorkingPermission")
                {
                    P.Add("@SPMode", "WorkingPermission");
                }
                else if (model.SpMode == "LeaseDeed")
                {
                    P.Add("@SPMode", "LeaseDeed");
                }
                var result = Connection.Query<string>("uspSubmissionOfStatutoryClearance", P, commandType: CommandType.StoredProcedure);
                objMessage.Satus = result.First();
            }
            catch (Exception ex)
            {
            }
                return objMessage;
        }

        /// <summary>
        /// Added by suroj 21-may-2021 to get mineral TimeLine
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public DataTable GetTimeline(PreferredBidder model)
        {
            DataTable dt = new DataTable();
            try
            {
                var paramList = new
                {
                    Userid = model.userid, //objRaiseTicket.User,
                    LesseeLoi=model.LesseeLOI,
                    SPMode= "GetTimeLine",
                };
                var result = Connection.ExecuteReader("uspSubmissionOfStatutoryClearance", paramList, commandType: System.Data.CommandType.StoredProcedure);

                
                dt.Load(result);
                

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                dt = null;
            }



        }
        /// <summary>
        /// Added by suroj 23-may-2021 to add digital signature data
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>

        public int InsertDSCRespnseData(DSCResponseModel model)
        {


            MessageEF objmesg = new MessageEF();

            int result1;
            try
            {
                var paramList = new
                {
                    DSCCertificateClass = model.DSCCertificateClass, //objRaiseTicket.User,
                    DSCUsedBy = model.Userid,
                    DSCForId = model.DSCForId,
                    DSCFor= model.DSCFor,
                    Response= model.Response,
                    DSCIssuedDate= model.DSCIssuedDate,
                    DSCExpiredDate= model.DSCExpiredDate,
                    DSCEmail= model.DSCEmail,
                    DSCCountry= model.DSCCountry,
                    DSCIssuerCommonName= model.DSCIssuerCommonName,
                    DSCCommonName = model.DSCCommonName,
                    DSCSerialNo= model.DSCSerialNo

                };
                var result = Connection.Query<string>("InsertDSCResponseRecords", paramList, commandType: System.Data.CommandType.StoredProcedure);
                
                return result1=1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

               
            }
        }
    }
}
