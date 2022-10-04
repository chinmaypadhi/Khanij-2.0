// ***********************************************************************
//  Model Name               : LesseProfile
//  Desciption               : Used to manage lessee profile
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 11-apr-2021
// ***********************************************************************

using Dapper;
using MineralConcessionApi.Factory;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineralConcessionApi.Repository;
using MineralConcessionEF;
using Appkey;

namespace MineralConcessionApi.Model.LesseeProfile
{
    public class Lesseprofile : RepositoryBase, ILesseprofile
    {
       
        public Lesseprofile(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Added by suroj on 18-apr-2021 to get company master detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<LeaseApplicationModel> GetCompMasterData(LeaseApplicationModel model)
        {

            List<LeaseApplicationModel> objraise = new List<LeaseApplicationModel>();
            try
            {
                var paramList = new
                {
                    Check = "2", //objRaiseTicket.User,


                };
                var result = Connection.ExecuteReader("GetDistrictDataForUser", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = new LeaseApplicationModel();

                    model.CompanyId = Convert.ToInt16(dt.Rows[i]["CompanyId"]);
                    model.CompanyName = dt.Rows[i]["CompanyName"].ToString();
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
        /// Added by suroj on 19-apr-2021 to add profile creation
        /// </summary>
        /// <param name="model"></param>
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
                P.Add("@TypeOfLand", model.Lands);
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
                if (model.DocumentName != null)
                {
                    DataTable _dt = new DataTable("BulkInsertion");
                    _dt = (DataTable)model.DocumentName;
                    if (_dt.Rows.Count > 0)
                    {
                        P.Add("@BulkInsertion", _dt, DbType.Object);
                    }
                }
                if (model.dt != null)
                {
                    DataTable _dt1 = new DataTable("tblSingleInteger");
                    _dt1 = (DataTable)model.dt;
                    if (_dt1.Rows.Count > 0)
                    {
                        P.Add("@tblSingleInteger", _dt1, DbType.Object);
                    }
                }

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
                if (objMessage.Satus != "0")
                {
                    objMessage.Msg = "Profile  Created successfully";

                }
                //else if (objMessage.Satus == "Reject")
                //{
                //    objMessage.Msg = "Data reject successfully";

                //}
                //else if (objMessage.Satus == "Approve")
                //{
                //    objMessage.Msg = "Data approve successfully";

                //}
                //else if (objMessage.Satus == "Forward")
                //{
                //    objMessage.Msg = "Data Forward successfully";

                //}

                //else if (objMessage.Satus == "Record Exist")
                //{
                //    objMessage.Msg = "Record Exist";

                //}
                else if (objMessage.Satus == "0")
                {
                    objMessage.Msg = "Mobile number and Email id already exist.Please register with new Mobile number and Email id and try again!";
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
                
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Added by  suroj on  20-apr-2021 to convert datareader to dataset
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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
        /// Added by suroj on 25-sep-2021 to edit lesse data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LeaseApplicationModel GetlesseEditdata(LeaseApplicationModel model)
        {
            List<PreferredBidder> objraise = new List<PreferredBidder>();
            LeaseApplicationModel objModel = new LeaseApplicationModel();
            try
            {
                var paramList = new
                {

                    UserID = model.UserId,
                    LesseeLOI = model.LesseeLOI,
                    FOR = model.FOR,
                    SPMode = model.SpMode,
                };
                var result = Connection.ExecuteReader("uspSubmissionOfStatutoryClearance", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var ds = ConvertDataReaderToDataSet(result);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //if (id != null && id != 0)
                    model.SubmissionID = model.LesseeLOI;
                    if (!(ds.Tables[0].Rows[0]["DateOfLOI"] is DBNull))
                        model.DateOfLOI = Convert.ToString(ds.Tables[0].Rows[0]["DateOfLOI"]);
                    if (!(ds.Tables[0].Rows[0]["StatusOfLessee"] is DBNull))
                        model.CategoryOfLicensee = Convert.ToString(ds.Tables[0].Rows[0]["StatusOfLessee"]);
                    if (!(ds.Tables[0].Rows[0]["FirmAs"] is DBNull))
                        model.FirmAs = Convert.ToString(ds.Tables[0].Rows[0]["FirmAs"]);
                    if (!(ds.Tables[0].Rows[0]["CompanyAs"] is DBNull))
                        model.CompanyAs = Convert.ToString(ds.Tables[0].Rows[0]["CompanyAs"]);
                    if (!(ds.Tables[0].Rows[0]["ModeOfGrant"] is DBNull))
                        model.modeOfGrant = Convert.ToString(ds.Tables[0].Rows[0]["ModeOfGrant"]);
                    if (!(ds.Tables[0].Rows[0]["CompanyId"] is DBNull))
                        model.CompanyId = Convert.ToInt32(ds.Tables[0].Rows[0]["CompanyId"]);
                    if (!(ds.Tables[0].Rows[0]["NameOfApplicant"] is DBNull))
                        model.NameOfApplicant = Convert.ToString(ds.Tables[0].Rows[0]["NameOfApplicant"]);
                    if (!(ds.Tables[0].Rows[0]["ApplicantMobileNo"] is DBNull))
                        model.ApplicantMobileNo = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantMobileNo"]);
                    if (!(ds.Tables[0].Rows[0]["ApplicantEmailId"] is DBNull))
                        model.ApplicantEmailId = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantEmailId"]);
                    if (!(ds.Tables[0].Rows[0]["Designation"] is DBNull))
                        model.Designation = Convert.ToString(ds.Tables[0].Rows[0]["Designation"]);
                    if (!(ds.Tables[0].Rows[0]["AddressOfApplicant"] is DBNull))
                        model.AddressOfApplicant = Convert.ToString(ds.Tables[0].Rows[0]["AddressOfApplicant"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["PAN_Card"])))
                        model.File_PAN_Card = Convert.ToString(ds.Tables[0].Rows[0]["PAN_Card"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["TIN_Card"])))
                        model.File_TIN_Card = Convert.ToString(ds.Tables[0].Rows[0]["TIN_Card"]);
                    if (!(ds.Tables[0].Rows[0]["StateID"] is DBNull))
                        model.StateID = Convert.ToInt32(ds.Tables[0].Rows[0]["StateID"]);
                    if (!(ds.Tables[0].Rows[0]["DistrictID"] is DBNull))
                        model.DistrictID = Convert.ToInt32(ds.Tables[0].Rows[0]["DistrictID"]);
                    if (!(ds.Tables[0].Rows[0]["TehsilID"] is DBNull))
                        model.TehsilID = Convert.ToInt32(ds.Tables[0].Rows[0]["TehsilID"]);
                    if (!(ds.Tables[0].Rows[0]["VillageID"] is DBNull))
                        model.VillageID = Convert.ToInt32(ds.Tables[0].Rows[0]["VillageID"]);

                    if (!(ds.Tables[0].Rows[0]["StateName"] is DBNull))
                        model.StateName = ds.Tables[0].Rows[0]["StateName"].ToString();
                    if (!(ds.Tables[0].Rows[0]["DistrictName"] is DBNull))
                        model.DistrictName = ds.Tables[0].Rows[0]["DistrictName"].ToString();
                    if (!(ds.Tables[0].Rows[0]["TehsilName"] is DBNull))
                        model.TehsilName = ds.Tables[0].Rows[0]["TehsilName"].ToString();
                    if (!(ds.Tables[0].Rows[0]["VillageName"] is DBNull))
                        model.VillageName = ds.Tables[0].Rows[0]["VillageName"].ToString();

                    if (!(ds.Tables[0].Rows[0]["MineralType"] is DBNull))
                        model.MineralType = ds.Tables[0].Rows[0]["MineralType"].ToString();
                    if (!(ds.Tables[0].Rows[0]["MineralName"] is DBNull))
                        model.MineralName = ds.Tables[0].Rows[0]["MineralName"].ToString();
                    if (!(ds.Tables[0].Rows[0]["LeaseTypeName"] is DBNull))
                        model.LeaseType = ds.Tables[0].Rows[0]["LeaseTypeName"].ToString();

                    if (!(ds.Tables[0].Rows[0]["BlockForestRange"] is DBNull))
                    {
                        model.BlockForestRange = Convert.ToString(ds.Tables[0].Rows[0]["BlockForestRange"]);
                    }
                    else { model.BlockForestRange = Convert.ToString(ds.Tables[0].Rows[0]["BlockName"]); }
                    if (!(ds.Tables[0].Rows[0]["Pincode"] is DBNull))
                        model.Pincode = Convert.ToString(ds.Tables[0].Rows[0]["Pincode"]);
                    if (!(ds.Tables[0].Rows[0]["AreaInHect"] is DBNull))
                        model.AreaInHect = Convert.ToString(ds.Tables[0].Rows[0]["AreaInHect"]);
                    if (!(ds.Tables[0].Rows[0]["TypeOfLand"] is DBNull))
                    {
                        string[] lst = Convert.ToString(ds.Tables[0].Rows[0]["TypeOfLand"]).Split(',');
                        List<ChekcboxListModel> chkList = new List<ChekcboxListModel>();

                        if (lst.Contains("Government"))
                            chkList.Add(new ChekcboxListModel() { IsSelected = true, Text = "Government", Value = "Government", id = "GovernmentLand" });
                        else
                            chkList.Add(new ChekcboxListModel() { IsSelected = false, Text = "Government", Value = "Government", id = "GovernmentLand" });

                        if (lst.Contains("Private"))
                            chkList.Add(new ChekcboxListModel() { IsSelected = true, Text = "Private", Value = "Private", id = "PrivateLand" });
                        else
                            chkList.Add(new ChekcboxListModel() { IsSelected = false, Text = "Private", Value = "Private", id = "PrivateLand" });

                        model.TypeOfLand = chkList;
                    }
                    if (!(ds.Tables[0].Rows[0]["GovernmentAs"] is DBNull))
                        model.GovernmentAs = Convert.ToString(ds.Tables[0].Rows[0]["GovernmentAs"]);
                    if (!(ds.Tables[0].Rows[0]["PrivatAs"] is DBNull))
                        model.PrivateAs = Convert.ToString(ds.Tables[0].Rows[0]["PrivatAs"]);
                    if (!(ds.Tables[0].Rows[0]["AreaGovernmentAs"] is DBNull))
                        model.AreaGovernmentAs = Convert.ToString(ds.Tables[0].Rows[0]["AreaGovernmentAs"]);
                    if (!(ds.Tables[0].Rows[0]["AreaPrivateAs"] is DBNull))
                        model.AreaPrivateAs = Convert.ToString(ds.Tables[0].Rows[0]["AreaPrivateAs"]);
                    if (!(ds.Tables[0].Rows[0]["AreaForestAs"] is DBNull))
                        model.AreaForestAs = Convert.ToString(ds.Tables[0].Rows[0]["AreaForestAs"]);
                    if (!(ds.Tables[0].Rows[0]["TopoSheetNo"] is DBNull))
                    {
                        model.TopoSheetNo = Convert.ToString(ds.Tables[0].Rows[0]["TopoSheetNo"]);
                        //ViewBag.hidTopoSheetNo = model.TopoSheetNo;
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["KhasraNo"])))
                    {
                        model.KhasraNo = Convert.ToString(ds.Tables[0].Rows[0]["KhasraNo"]);
                        //ViewBag.hidKhasraNo = model.KhasraNo;
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Coordinates"])))
                    {
                        model.Coordinates = Convert.ToString(ds.Tables[0].Rows[0]["Coordinates"]);
                        //ViewBag.hidCoordinates = model.Coordinates;
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DemarcationReport"])))
                        model.File_DemarcationReport = Convert.ToString(ds.Tables[0].Rows[0]["DemarcationReport"]);

                    if (!(ds.Tables[0].Rows[0]["EVR"] is DBNull))
                        model.EVR = Convert.ToDecimal(ds.Tables[0].Rows[0]["EVR"]);
                    if (!(ds.Tables[0].Rows[0]["FinalPriceOffer"] is DBNull))
                    {
                        model.FinalPriceOffer = Convert.ToDecimal(ds.Tables[0].Rows[0]["FinalPriceOffer"]);
                    }
                    else { model.FinalPriceOffer = Convert.ToDecimal(ds.Tables[0].Rows[0]["BidFinal"]); }
                    if (!(ds.Tables[0].Rows[0]["TotalUpfrontPayment"] is DBNull))
                        model.TotalUpfrontPayment = Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalUpfrontPayment"]);
                    if (!(ds.Tables[0].Rows[0]["PerformanceSecurity"] is DBNull))
                        model.PerformanceSecurity = Convert.ToDecimal(ds.Tables[0].Rows[0]["PerformanceSecurity"]);
                    if (!(ds.Tables[0].Rows[0]["AuctionMoney"] is DBNull))
                        model.AuctionMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["AuctionMoney"]);
                    if (!(ds.Tables[0].Rows[0]["First_Installment_Amount"] is DBNull))
                        model.First_Installment_Amount = Convert.ToString(ds.Tables[0].Rows[0]["First_Installment_Amount"]);
                    if (!(ds.Tables[0].Rows[0]["Second_Installment_Amount"] is DBNull))
                        model.Second_Installment_Amount = Convert.ToString(ds.Tables[0].Rows[0]["Second_Installment_Amount"]);
                    if (!(ds.Tables[0].Rows[0]["Third_Installment_Amount"] is DBNull))
                        model.Third_Installment_Amount = Convert.ToString(ds.Tables[0].Rows[0]["Third_Installment_Amount"]);
                    if (!(ds.Tables[0].Rows[0]["PerformanceSecurity_Installment_Amount"] is DBNull))
                        model.PerformanceSecurity_Installment_Amount = Convert.ToString(ds.Tables[0].Rows[0]["PerformanceSecurity_Installment_Amount"]);
                    if (!(ds.Tables[0].Rows[0]["First_Installment_ScheduleDate"] is DBNull))
                        model.First_Installment_ScheduleDate = Convert.ToString(ds.Tables[0].Rows[0]["First_Installment_ScheduleDate"]);
                    if (!(ds.Tables[0].Rows[0]["Second_Installment_ScheduleDate"] is DBNull))
                        model.Second_Installment_ScheduleDate = Convert.ToString(ds.Tables[0].Rows[0]["Second_Installment_ScheduleDate"]);
                    if (!(ds.Tables[0].Rows[0]["Third_Installment_ScheduleDate"] is DBNull))
                        model.Third_Installment_ScheduleDate = Convert.ToString(ds.Tables[0].Rows[0]["Third_Installment_ScheduleDate"]);
                    if (!(ds.Tables[0].Rows[0]["PerformanceSecurity_Installment_ScheduleDate"] is DBNull))
                        model.PerformanceSecurity_Installment_ScheduleDate = Convert.ToString(ds.Tables[0].Rows[0]["PerformanceSecurity_Installment_ScheduleDate"]);
                    if (!(ds.Tables[0].Rows[0]["First_Installment_DateOfDiposite"] is DBNull))
                        model.First_Installment_DateOfDiposite = Convert.ToString(ds.Tables[0].Rows[0]["First_Installment_DateOfDiposite"]);
                    if (!(ds.Tables[0].Rows[0]["Second_Installment_DateOfDiposite"] is DBNull))
                        model.Second_Installment_DateOfDiposite = Convert.ToString(ds.Tables[0].Rows[0]["Second_Installment_DateOfDiposite"]);
                    if (!(ds.Tables[0].Rows[0]["Third_Installment_DateOfDiposite"] is DBNull))
                        model.Third_Installment_DateOfDiposite = Convert.ToString(ds.Tables[0].Rows[0]["Third_Installment_DateOfDiposite"]);
                    if (!(ds.Tables[0].Rows[0]["PerformanceSecurity_Installment_SubmissionDate"] is DBNull))
                        model.PerformanceSecurity_Installment_SubmissionDate = Convert.ToString(ds.Tables[0].Rows[0]["PerformanceSecurity_Installment_SubmissionDate"]);

                    if (!(ds.Tables[0].Rows[0]["MajorMineral_CL_Reserve"] is DBNull))
                        model.MajorMineral_CL_Reserve = Convert.ToDecimal(ds.Tables[0].Rows[0]["MajorMineral_CL_Reserve"]);
                    if (!(ds.Tables[0].Rows[0]["MajorMineral_CL_EVR"] is DBNull))
                        model.MajorMineral_CL_EVR = Convert.ToDecimal(ds.Tables[0].Rows[0]["MajorMineral_CL_EVR"]);
                    if (!(ds.Tables[0].Rows[0]["MajorMineral_CL_FinalPriceOffer"] is DBNull))
                        model.MajorMineral_CL_FinalPriceOffer = Convert.ToDecimal(ds.Tables[0].Rows[0]["MajorMineral_CL_FinalPriceOffer"]);
                    if (!(ds.Tables[0].Rows[0]["MajorMineral_CL_PerformanceSecurity_Installment_Amount"] is DBNull))
                        model.MajorMineral_CL_PerformanceSecurity_Installment_Amount = Convert.ToDecimal(ds.Tables[0].Rows[0]["MajorMineral_CL_PerformanceSecurity_Installment_Amount"]);
                    if (!(ds.Tables[0].Rows[0]["MajorMineral_CL_PerformanceSecurity_Installment_ScheduleDate"] is DBNull))
                        model.MajorMineral_CL_PerformanceSecurity_Installment_ScheduleDate = Convert.ToString(ds.Tables[0].Rows[0]["MajorMineral_CL_PerformanceSecurity_Installment_ScheduleDate"]);
                    if (!(ds.Tables[0].Rows[0]["MajorMineral_CL_PerformanceSecurity_Installment_SubmissionDate"] is DBNull))
                        model.MajorMineral_CL_PerformanceSecurity_Installment_SubmissionDate = Convert.ToString(ds.Tables[0].Rows[0]["MajorMineral_CL_PerformanceSecurity_Installment_SubmissionDate"]);

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["First_Installment_FilePath"])))
                        model.First_Installment_FilePath = Convert.ToString(ds.Tables[0].Rows[0]["First_Installment_FilePath"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Second_Installment_FileName"])))
                        model.Second_Installment_FilePath = Convert.ToString(ds.Tables[0].Rows[0]["Second_Installment_FileName"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Third_Installment_FileName"])))
                        model.Third_Installment_FilePath = Convert.ToString(ds.Tables[0].Rows[0]["Third_Installment_FileName"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["PerformanceSecurity_Installment_FileName"])))
                        model.PerformanceSecurity_Installment_FilePath = Convert.ToString(ds.Tables[0].Rows[0]["PerformanceSecurity_Installment_FileName"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["MajorMineral_CL_PerformanceSecurity_Installment_FileName"])))
                        model.MajorMineral_CL_PerformanceSecurity_Installment__FilePath = Convert.ToString(ds.Tables[0].Rows[0]["MajorMineral_CL_PerformanceSecurity_Installment_FileName"]);



                    if (!(ds.Tables[0].Rows[0]["MineralTypeID"] is DBNull))
                        model.MineralTypeID = Convert.ToInt32(ds.Tables[0].Rows[0]["MineralTypeID"]);
                    if (!(ds.Tables[0].Rows[0]["MineralId"] is DBNull))
                        model.MineralID = Convert.ToInt32(ds.Tables[0].Rows[0]["MineralId"]);
                    if (!(ds.Tables[0].Rows[0]["LeaseTypeId"] is DBNull))
                        model.LeaseTypeId = Convert.ToInt32(ds.Tables[0].Rows[0]["LeaseTypeId"]);
                    if (!(ds.Tables[0].Rows[0]["Reserve"] is DBNull))
                        model.Reserve = Convert.ToInt32(ds.Tables[0].Rows[0]["Reserve"]);
                    if (!(ds.Tables[0].Rows[0]["ActiveStatus"] is DBNull))
                    {
                        model.ActiveStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["ActiveStatus"]);
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["SchemeofProspecting"])))
                        model.SchemeofProspecting = Convert.ToString(ds.Tables[0].Rows[0]["SchemeofProspecting"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["FCLetter"])))
                        model.FCLetter = Convert.ToString(ds.Tables[0].Rows[0]["FCLetter"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DGPSLetter"])))
                        model.DGPSLetter = Convert.ToString(ds.Tables[0].Rows[0]["DGPSLetter"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["LandLetter"])))
                        model.LandLetter = Convert.ToString(ds.Tables[0].Rows[0]["LandLetter"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["GrantOrderCopy"])))
                        model.GrantOrderCopy = Convert.ToString(ds.Tables[0].Rows[0]["GrantOrderCopy"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["MajorMineralCLGrantOrderCopy"])))
                        model.MajorMineralCLGrantOrderCopy = Convert.ToString(ds.Tables[0].Rows[0]["MajorMineralCLGrantOrderCopy"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DocumentofLicenseDeed"])))
                        model.DocumentofLicenseDeed = Convert.ToString(ds.Tables[0].Rows[0]["DocumentofLicenseDeed"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DocumentofPermissionofCLArea"])))
                        model.DocumentofPermissionofCLArea = Convert.ToString(ds.Tables[0].Rows[0]["DocumentofPermissionofCLArea"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DocumentofProspectingOperation"])))
                        model.DocumentofProspectingOperation = Convert.ToString(ds.Tables[0].Rows[0]["DocumentofProspectingOperation"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DocumentofDrillingOperation"])))
                        model.DocumentofDrillingOperation = Convert.ToString(ds.Tables[0].Rows[0]["DocumentofDrillingOperation"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DateofProgressReport_Upload"])))
                        model.DateofProgressReport_Upload = Convert.ToString(ds.Tables[0].Rows[0]["DateofProgressReport_Upload"]);

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["FinalReport"])))
                        model.FinalReport = Convert.ToString(ds.Tables[0].Rows[0]["FinalReport"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["MLApplication"])))
                        model.MLApplication = Convert.ToString(ds.Tables[0].Rows[0]["MLApplication"]);

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["BankGaurrantyLetter"])))
                        model.BankGaurrantyLetter = Convert.ToString(ds.Tables[0].Rows[0]["BankGaurrantyLetter"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["IBM_ReceivingCopy"])))
                        model.IBM_ReceivingCopy = Convert.ToString(ds.Tables[0].Rows[0]["IBM_ReceivingCopy"]);


                    // Start

                    if (!(ds.Tables[0].Rows[0]["PS_BankName"] is DBNull))
                        model.PS_BankName = ds.Tables[0].Rows[0]["PS_BankName"].ToString();

                    if (!(ds.Tables[0].Rows[0]["PS_BankGaurrantyNo"] is DBNull))
                        model.PS_BankGaurrantyNo = ds.Tables[0].Rows[0]["PS_BankGaurrantyNo"].ToString();

                    if (!(ds.Tables[0].Rows[0]["PS_BankGuarantyDate"] is DBNull))
                        model.PS_BankGuarantyDate = ds.Tables[0].Rows[0]["PS_BankGuarantyDate"].ToString();

                    if (!(ds.Tables[0].Rows[0]["PS_ValidityUpto"] is DBNull))
                        model.PS_ValidityUpto = ds.Tables[0].Rows[0]["PS_ValidityUpto"].ToString();

                    if (!(ds.Tables[0].Rows[0]["MP_ApprovalOrderNo"] is DBNull))
                        model.MP_ApprovalOrderNo = ds.Tables[0].Rows[0]["MP_ApprovalOrderNo"].ToString();

                    if (!(ds.Tables[0].Rows[0]["MP_ValidFrom"] is DBNull))
                        model.MP_ValidFrom = ds.Tables[0].Rows[0]["MP_ValidFrom"].ToString();

                    if (!(ds.Tables[0].Rows[0]["MP_ValidUpto"] is DBNull))
                        model.MP_ValidUpto = ds.Tables[0].Rows[0]["MP_ValidUpto"].ToString();

                    if (!(ds.Tables[0].Rows[0]["EC_OrderDate"] is DBNull))
                        model.EC_OrderDate = ds.Tables[0].Rows[0]["EC_OrderDate"].ToString();

                    if (!(ds.Tables[0].Rows[0]["EC_OrderNo"] is DBNull))
                        model.EC_OrderNo = ds.Tables[0].Rows[0]["EC_OrderNo"].ToString();

                    if (!(ds.Tables[0].Rows[0]["EC_AnnualCapacity"] is DBNull))
                        model.EC_AnnualCapacity = float.Parse(ds.Tables[0].Rows[0]["EC_AnnualCapacity"].ToString());

                    if (!(ds.Tables[0].Rows[0]["EC_ValidUpto"] is DBNull))
                        model.EC_ValidUpto = ds.Tables[0].Rows[0]["EC_ValidUpto"].ToString();

                    if (!(ds.Tables[0].Rows[0]["CTE_OrderDate"] is DBNull))
                        model.CTE_OrderDate = ds.Tables[0].Rows[0]["CTE_OrderDate"].ToString();

                    if (!(ds.Tables[0].Rows[0]["CTE_OrderNo"] is DBNull))
                        model.CTE_OrderNo = ds.Tables[0].Rows[0]["CTE_OrderNo"].ToString();

                    if (!(ds.Tables[0].Rows[0]["CTE_ValidUpto"] is DBNull))
                        model.CTE_ValidUpto = ds.Tables[0].Rows[0]["CTE_ValidUpto"].ToString();

                    if (!(ds.Tables[0].Rows[0]["CTO_OrderDate"] is DBNull))
                        model.CTO_OrderDate = ds.Tables[0].Rows[0]["CTO_OrderDate"].ToString();

                    if (!(ds.Tables[0].Rows[0]["CTO_OrderNo"] is DBNull))
                        model.CTO_OrderNo = ds.Tables[0].Rows[0]["CTO_OrderNo"].ToString();

                    if (!(ds.Tables[0].Rows[0]["FC_OrderDate"] is DBNull))
                        model.FC_OrderDate = ds.Tables[0].Rows[0]["FC_OrderDate"].ToString();

                    if (!(ds.Tables[0].Rows[0]["FC_OrderNo"] is DBNull))
                        model.FC_OrderNo = ds.Tables[0].Rows[0]["FC_OrderNo"].ToString();

                    if (!(ds.Tables[0].Rows[0]["ApprovaDateMiningPlan"] is DBNull))
                        model.ApprovaDateMiningPlan = ds.Tables[0].Rows[0]["ApprovaDateMiningPlan"].ToString();

                    if (!(ds.Tables[0].Rows[0]["First_Year_PQty"] is DBNull))
                        model.First_Year_PQty = Decimal.Parse(ds.Tables[0].Rows[0]["First_Year_PQty"].ToString());

                    if (!(ds.Tables[0].Rows[0]["Second_Year_PQty"] is DBNull))
                        model.Second_Year_PQty = Decimal.Parse(ds.Tables[0].Rows[0]["Second_Year_PQty"].ToString());

                    if (!(ds.Tables[0].Rows[0]["Third_Year_PQty"] is DBNull))
                        model.Third_Year_PQty = Decimal.Parse(ds.Tables[0].Rows[0]["Third_Year_PQty"].ToString());

                    if (!(ds.Tables[0].Rows[0]["Fourth_Year_PQty"] is DBNull))
                        model.Fourth_Year_PQty = Decimal.Parse(ds.Tables[0].Rows[0]["Fourth_Year_PQty"].ToString());

                    if (!(ds.Tables[0].Rows[0]["Fifth_Year_PQty"] is DBNull))
                        model.Fifth_Year_PQty = Decimal.Parse(ds.Tables[0].Rows[0]["Fifth_Year_PQty"].ToString());

                    // End


                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["MPSOMLetter"])))
                        model.MPSOMLetter = Convert.ToString(ds.Tables[0].Rows[0]["MPSOMLetter"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["ProposedProductionLetter"])))
                        model.ProposedProductionLetter = Convert.ToString(ds.Tables[0].Rows[0]["ProposedProductionLetter"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["ECLetter"])))
                        model.ECLetter = Convert.ToString(ds.Tables[0].Rows[0]["ECLetter"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["CTELetter"])))
                        model.CTELetter = Convert.ToString(ds.Tables[0].Rows[0]["CTELetter"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["CTOLetter"])))
                        model.CTOLetter = Convert.ToString(ds.Tables[0].Rows[0]["CTOLetter"]);


                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["FCLetter"])))
                        model.FCLetter = Convert.ToString(ds.Tables[0].Rows[0]["FCLetter"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DGPSLetter"])))
                        model.DGPSLetter = Convert.ToString(ds.Tables[0].Rows[0]["DGPSLetter"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["LandLetter"])))
                        model.LandLetter = Convert.ToString(ds.Tables[0].Rows[0]["LandLetter"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["RevenueLetter"])))
                        model.RevenueLetter = Convert.ToString(ds.Tables[0].Rows[0]["RevenueLetter"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["GramPanchayatLetter"])))
                        model.GramPanchayatLetter = Convert.ToString(ds.Tables[0].Rows[0]["GramPanchayatLetter"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["MDPA"])))
                        model.MDPA = Convert.ToString(ds.Tables[0].Rows[0]["MDPA"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["LeaseDeedAgreement"])))
                        model.LeaseDeedAgreement = Convert.ToString(ds.Tables[0].Rows[0]["LeaseDeedAgreement"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["WorkingPermission"])))
                        model.WorkingPermission = Convert.ToString(ds.Tables[0].Rows[0]["WorkingPermission"]);
                    if (!(ds.Tables[0].Rows[0]["MiningPlanDueDate"] is DBNull))
                        model.MiningPlanDueDate = Convert.ToString(ds.Tables[0].Rows[0]["MiningPlanDueDate"]);
                    if (!(ds.Tables[0].Rows[0]["OtherDocumentName"] is DBNull))
                        model.OtherDocumentName = Convert.ToString(ds.Tables[0].Rows[0]["OtherDocumentName"]);
                    if (!(ds.Tables[0].Rows[0]["ThirdPaymentDate"] is DBNull))
                        model.ThirdPaymentDate = Convert.ToString(ds.Tables[0].Rows[0]["ThirdPaymentDate"]);
                    if (!(ds.Tables[0].Rows[0]["Revenue"] is DBNull))
                        model.Revenue = Convert.ToBoolean(ds.Tables[0].Rows[0]["Revenue"]);
                    if (!(ds.Tables[0].Rows[0]["Area_Revenue"] is DBNull))
                        model.txtRevenue = Convert.ToString(ds.Tables[0].Rows[0]["Area_Revenue"]);
                    if (!(ds.Tables[0].Rows[0]["RevenueForest"] is DBNull))
                        model.RevenueForest = Convert.ToBoolean(ds.Tables[0].Rows[0]["RevenueForest"]);
                    if (!(ds.Tables[0].Rows[0]["Area_RevenueForest"] is DBNull))
                        model.txtRevenueForest = Convert.ToString(ds.Tables[0].Rows[0]["Area_RevenueForest"]);
                    if (!(ds.Tables[0].Rows[0]["Nistar"] is DBNull))
                        model.Nistar = Convert.ToBoolean(ds.Tables[0].Rows[0]["Nistar"]);
                    if (!(ds.Tables[0].Rows[0]["Area_Nistar"] is DBNull))
                        model.txtNistar = Convert.ToString(ds.Tables[0].Rows[0]["Area_Nistar"]);
                    if (!(ds.Tables[0].Rows[0]["Forest"] is DBNull))
                        model.Forest = Convert.ToBoolean(ds.Tables[0].Rows[0]["Forest"]);
                    if (!(ds.Tables[0].Rows[0]["Area_Forest"] is DBNull))
                        model.txtForest = Convert.ToString(ds.Tables[0].Rows[0]["Area_Forest"]);
                    if (!(ds.Tables[0].Rows[0]["Tribal"] is DBNull))
                        model.Tribal = Convert.ToBoolean(ds.Tables[0].Rows[0]["Tribal"]);
                    if (!(ds.Tables[0].Rows[0]["Area_Tribal"] is DBNull))
                        model.txtTribal = Convert.ToString(ds.Tables[0].Rows[0]["Area_Tribal"]);
                    if (!(ds.Tables[0].Rows[0]["NonTribal"] is DBNull))
                        model.NonTribal = Convert.ToBoolean(ds.Tables[0].Rows[0]["NonTribal"]);
                    if (!(ds.Tables[0].Rows[0]["Area_NonTribal"] is DBNull))
                        model.txtNonTribal = Convert.ToString(ds.Tables[0].Rows[0]["Area_NonTribal"]);

                    model.WorkingPermissionUploadedOn = Convert.ToString(ds.Tables[0].Rows[0]["WorkingPermissionUploadedOn"]);
                    model.MDPAUploadedDate = Convert.ToString(ds.Tables[0].Rows[0]["MDPAUploadedDate"]);
                    model.LeaseDeedUploadedOn = Convert.ToString(ds.Tables[0].Rows[0]["LeaseDeedUploadedOn"]);

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["ExcelKharsaName"])))
                    {
                        model.ExcelKhasraNo_FilePath = Convert.ToString(ds.Tables[0].Rows[0]["ExcelKharsaName"]);
                        //ViewBag.hidExcelKhasraNo_FilePath = model.ExcelKhasraNo_FilePath;
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["ExcelCoordinatesPath"])))
                    {
                        model.ExcelCoordinates_FilePath = Convert.ToString(ds.Tables[0].Rows[0]["ExcelCoordinatesName"]);
                        //ViewBag.hidExcelCoordinates_FilePath = model.ExcelCoordinates_FilePath;
                    }
                    //ViewBag.UnitName = Convert.ToString(ds.Tables[0].Rows[0]["UnitName"]);
                    model.Status = Convert.ToInt16(ds.Tables[0].Rows[0]["Status"]);

                }
                List<string> otherdocument = new List<string>();
                if (ds != null && ds.Tables[2].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        otherdocument.Add(Convert.ToString(ds.Tables[2].Rows[i]["DocName"]));
                    }
                    model.OtherDocumentName = Convert.ToString(ds.Tables[2].Rows[0]["OtherDocumentName"]);
                }
                model.otherdocs = otherdocument;
                List<System.Web.Mvc.SelectListItem> LOI_StatutoryDocuments = new List<System.Web.Mvc.SelectListItem>();



                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        System.Web.Mvc.SelectListItem item = new System.Web.Mvc.SelectListItem();
                        item.Value = Convert.ToString(ds.Tables[1].Rows[i]["DocId"]);
                        item.Text = Convert.ToString(ds.Tables[1].Rows[i]["DocName"]);
                        item.Selected = Convert.ToInt16(ds.Tables[1].Rows[i]["IsSelected"]) == 1 ? true : false;
                        LOI_StatutoryDocuments.Add(item);
                    }
                    model.LOI_StatutoryDocuments = LOI_StatutoryDocuments;
                }
                else
                {
                    var paramList1 = new
                    {

                        UserID = model.UserId,

                    };
                    var result1 = Connection.ExecuteReader("uspGetLOI_StatutoryDocuments", paramList1, commandType: System.Data.CommandType.StoredProcedure);
                    DataTable dt = new DataTable();
                    dt.Load(result1);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        System.Web.Mvc.SelectListItem item = new System.Web.Mvc.SelectListItem();
                        item.Value = Convert.ToString(dt.Rows[0]["DocId"]);
                        item.Text = Convert.ToString(dt.Rows[0]["DocName"]);

                        LOI_StatutoryDocuments.Add(item);
                    }

                    model.LOI_StatutoryDocuments = LOI_StatutoryDocuments;

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
                //ViewBag.DocList = DocList;
                if (ds != null && ds.Tables[3].Rows.Count > 0)
                {
                    model.RemarksHistory = ds.Tables[3];
                }
                if (ds != null && ds.Tables[4].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("DocId");
                    dt.Columns.Add("LesseeLoiId");
                    dt.Columns.Add("DocName");
                    dt.Columns.Add("DocPath");
                    for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
                    {

                        dt.Rows.Add(ds.Tables[4].Rows[i]["DocId"], ds.Tables[4].Rows[i]["LesseeLoiId"], ds.Tables[4].Rows[i]["DocName"], Convert.ToString(ds.Tables[4].Rows[i]["DocPath"]) == "" ? "" : ds.Tables[4].Rows[i]["DocPath"]);
                    }
                    model.OtherDocHistory = dt;
                }

                //model.FOR = FOR;
                if (model.FOR == "ApplyForMajorMineral")
                {
                    model.MineralTypeID = 1;
                }
                else if (model.FOR == "PreferredBidder")
                {
                    model.MineralTypeID = 1;
                    model.LeaseTypeId = 1;
                    model.LesseeLOI = Convert.ToInt32(model.LesseeLOI);

                }

                else if (model.FOR == "ApplyForMinorMineral")
                {
                    model.MineralTypeID = 2;
                }
                return model;
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

       
    }
}
