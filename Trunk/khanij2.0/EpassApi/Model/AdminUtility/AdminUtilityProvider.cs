using Dapper;
using EpassApi.Factory;
using EpassApi.Repository;
using EpassEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Model.AdminUtility
{
    public class AdminUtilityProvider : RepositoryBase, IAdminUtilityProvider
    {
        string OutputResult = "";
        MessageEF objmsgEF = new MessageEF();
        public AdminUtilityProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<MessageEF> CancleTPApproval(TPCancelModelEF objTPDetails)
        {
            List<TPCancelModelEF> objlistmodel = new List<TPCancelModelEF>();
            try
            {
                var paramlist = new
                {
                    TPid = objTPDetails.TPid,
                    Check = objTPDetails.Check,
                    Remarks = objTPDetails.Remarks,
                    UpdateIn = objTPDetails.UpdateIn,
                    UserID = objTPDetails.UserID,
                    UserLoginId = objTPDetails.UserLoginId
                };
                var result = await Connection.ExecuteScalarAsync("TPCancellationProcess", paramlist, commandType: System.Data.CommandType.StoredProcedure);
              
                Int32 ID = Convert.ToInt32(result);

                if (ID == 0) // 0 means Not used in Merge permit
                {

                    var paramlistApprove = new
                    {
                        TPid = objTPDetails.TPid,
                        Check = 2,
                        Remarks = objTPDetails.Remarks,
                        CancellationID = objTPDetails.CancellationId,
                        Action = objTPDetails.Action,
                        UserID = objTPDetails.UserID,
                        UserLoginId = objTPDetails.UserLoginId
                    };
                    var Approveresult = await Connection.ExecuteScalarAsync("AdminUtiltyMasterSP", paramlistApprove, commandType: System.Data.CommandType.StoredProcedure);
                    Int32 _ID = Convert.ToInt32(Approveresult);
                    if (_ID != null && _ID != 0)
                    {
                        var _returnId = string.Empty;
                        _returnId = Convert.ToInt32(_ID).ToString();
                        objmsgEF.Satus = _returnId;
                        #region Send SMS
                        try
                        {
                            string message = "";
                            string templateid = "";
                            //if (Action == "Approve")
                            //{
                            //    message = "You have Cancelled " + PassNo + " successfully.";
                            //}
                            //else
                            //{
                            //    message = "You have Rejected " + PassNo + " successfully.";
                            //}
                            if (objTPDetails.Action == "Approve")
                            {
                                message = "Your cancellation request for " + objTPDetails.TransitPassNo + " have been approved successfully by the district office. CHiMMS, GoCG";
                                templateid = "1307161883213679743";
                            }
                            else
                            {
                                message = "Your cancellation request for " + objTPDetails.TransitPassNo + " have been rejected by the district office. CHiMMS, GoCG";
                                templateid = "1307161883219593799";
                            }

                            //Modified by Avneesh on 12-04-2021

                            //SMSHttpPostClient.Main(SessionWrapper.MobileNumber, message, templateid);

                            //SMSHttpPostClient.Main(SessionWrapper.MobileNumber, message);
                        }
                        catch (Exception)
                        {

                        }
                        #endregion
                    }
                    else
                    {
                        objmsgEF.Satus = "";
                    }

                }
                else if (objTPDetails.Action == "Reject")
                {
                    var paramlistApprove = new
                    {
                        TPid = objTPDetails.TPid,
                        Check = 2,
                        Remarks = objTPDetails.Remarks,
                        CancellationID = objTPDetails.CancellationId,
                        Action = objTPDetails.Action,
                        UserID = objTPDetails.UserID,
                        UserLoginId = objTPDetails.UserLoginId
                    };
                    var Approveresult = await Connection.ExecuteScalarAsync("AdminUtiltyMasterSP", paramlistApprove, commandType: System.Data.CommandType.StoredProcedure);
                    Int32 _ID = Convert.ToInt32(Approveresult);
                    if (_ID != null && _ID != 0)
                    {
                        var _returnId = string.Empty;
                        _returnId = Convert.ToInt32(_ID).ToString();
                        objmsgEF.Satus = _returnId;
                        #region Send SMS
                        try
                        {
                            string message = "";
                            string templateid = "";
                            
                            if (objTPDetails.Action == "Approve")
                            {
                                message = "You have Cancelled " + objTPDetails.TransitPassNo + " successfully. CHiMMS, GoCG";
                                templateid = "1307161883226814692";
                            }
                            else
                            {
                                message = "You have Rejected " + objTPDetails.TransitPassNo + " successfully. CHiMMS, GoCG";
                                templateid = "1307161883231851023";
                               
                            }

                            //Modified by Avneesh on 12-04-2021

                            //SMSHttpPostClient.Main(SessionWrapper.MobileNumber, message, templateid);

                            //SMSHttpPostClient.Main(SessionWrapper.MobileNumber, message);
                        }
                        catch (Exception)
                        {

                        }
                        #endregion
                    }
                }

                    // if (result.Count() > 0){objlistmodel = result.ToList();}

                }
            catch (Exception ex)
            {
                throw ex;
            }
            return objmsgEF;
        }



    }
}
