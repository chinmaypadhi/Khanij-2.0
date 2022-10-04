using Dapper;
using EpassApi.Factory;
using EpassApi.Repository;
using EpassEF;
using EpassEF.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Model.PurchaserConsignee
{
    public class PurchaserConsigneeProvider : RepositoryBase, IPurchaserConsigneeProvider
    {
        public PurchaserConsigneeProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<List<PurchaserConsigneeOpenEpermitModel>> ReadOpenEpermitDetails(PurchaserConsigneeOpenEpermitModel objOpenModel)
        {
            List<PurchaserConsigneeOpenEpermitModel> LtPermit = new List<PurchaserConsigneeOpenEpermitModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objOpenModel.UserId,
                    SP_MODE = objOpenModel.ActionCode                   
                };
                DynamicParameters param = new DynamicParameters();
                var result =await  Connection.QueryAsync<PurchaserConsigneeOpenEpermitModel>("USP_GET_PURCHASER_CONSIGNEE", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LtPermit = result.ToList();
                }
                return LtPermit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LtPermit = null;
            }
        }


        public async Task<List<PurchaserConsigneeModelView>> getDataByPermitId(PurchaserConsigneeModelView purchaserConsignee)
        {
            List<PurchaserConsigneeModelView> ltPurchaser = new List<PurchaserConsigneeModelView>();
            List<PurchaserConsigneeModelView> lstPurchaser = new List<PurchaserConsigneeModelView>();
            try
            {                
                int Chk;
                if (purchaserConsignee.UserType == "End User")
                    Chk = 2;
                else
                    Chk = 1;
                var paramList = new
                {
                    PCId=0,
                    Check = Chk,
                    IsCoal=purchaserConsignee.IsCoal,
                    BulkPermitId =purchaserConsignee.BulkPermitId,                                    
                    UserId = purchaserConsignee.UserId                    
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<PurchaserConsigneeModelView>("uspGetPurchaserConsigneeMasterAndTranData", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if(result.Count()>0)
                {
                    ltPurchaser = result.ToList();
                }
                foreach(PurchaserConsigneeModelView purchaser in ltPurchaser)
                {
                    PurchaserConsigneeModelView objPC = new PurchaserConsigneeModelView();
                    objPC.PCId = Convert.ToInt32(purchaser.PCId);
                    objPC.RouteName = Convert.ToString(purchaser.RouteName);
                    objPC.TransportationMode = Convert.ToString(purchaser.TransportationMode);
                    objPC.BulkPermitNo = Convert.ToString(purchaser.BulkPermitNo);
                    objPC.BulkPermitId = Convert.ToInt32(purchaser.BulkPermitId);
                    objPC.PurchaserConsigneeId = Convert.ToInt32(purchaser.PurchaserConsigneeId);
                    objPC.TransportationModeId = Convert.ToInt32(purchaser.TransportationModeId);
                    objPC.Destination = Convert.ToString(purchaser.Destination);
                    objPC.LicenseeId = Convert.ToInt32(purchaser.LicenseeId);
                    objPC.PurchaserConsigneeName = Convert.ToString(purchaser.PurchaserConsigneeName);
                    objPC.StateId = Convert.ToInt32(purchaser.StateId);
                    objPC.LicenseeTypeId = Convert.ToInt32(purchaser.LicenseeTypeId);
                    objPC.CoalWashryId = !string.IsNullOrEmpty(purchaser.CoalWashryId.ToString()) ? Convert.ToInt32(purchaser.CoalWashryId) : 0;
                    objPC.CoalWashryAddress = Convert.ToString(purchaser.CoalWashryAddress);
                    objPC.PartyCode = Convert.ToString(purchaser.PartyCode);
                    objPC.PartyMobile = Convert.ToString(purchaser.PartyMobile);
                    objPC.PartyName = Convert.ToString(purchaser.PartyName);
                    objPC.OthersOption = Convert.ToString(purchaser.OthersOption);
                    objPC.IsOtherParty = Convert.ToString(purchaser.IsOtherParty);

                    objPC.ThroughCoalWasheryId = !string.IsNullOrEmpty(purchaser.ThroughCoalWasheryId.ToString()) ? Convert.ToInt32(purchaser.ThroughCoalWasheryId) : 0;
                    objPC.ThroughIsCoalWashery = !string.IsNullOrEmpty(purchaser.ThroughIsCoalWashery.ToString()) ? Convert.ToString(purchaser.ThroughIsCoalWashery) : "";
                    objPC.ThroughCoalWasheryDistrictId = !string.IsNullOrEmpty(purchaser.ThroughCoalWasheryDistrictId.ToString()) ? Convert.ToInt32(purchaser.ThroughCoalWasheryDistrictId) : 0;
                    objPC.Yes_No = Convert.ToString(purchaser.OtherYes_No);
                    objPC.DispatchType = Convert.ToString(purchaser.PurchaserType);
                    objPC.RCR_RTP_BY = Convert.ToString(purchaser.RCR_RTP_BY);                    

                    if (objPC.PurchaserConsigneeId > 0)
                    {

                        objPC.PurchaserConsigneeDistrictId = (purchaser.DistrictId is null) ? 0 : Convert.ToInt32(purchaser.DistrictId);
                        objPC.Route = Convert.ToInt32(purchaser.Route);
                    }
                    else if (objPC.LicenseeId > 0)
                    {
                        objPC.LicenseeDistrictId = Convert.ToInt32(purchaser.DistrictId);
                        objPC.Route1 = Convert.ToInt32(purchaser.Route);
                    }
                    if (objPC.Yes_No == "Yes" && objPC.DispatchType == "OTHERS")
                    {
                        if (objPC.DispatchType == "OTHERS")
                        {
                            objPC.DispatchType = "Others";
                        }
                        objPC.UserType = Convert.ToString(purchaser.UserType);
                        objPC.Other_StateId = Convert.ToInt32(purchaser.StateId);
                        objPC.Other_PurchaserConsigneeDistrictId = Convert.ToInt32(purchaser.DistrictId);
                        objPC.Other_Route = Convert.ToInt32(purchaser.Route);
                        if (objPC.UserType == "Licensee")
                        {
                            objPC.Other_PurchaserConsigneeId = Convert.ToInt32(purchaser.LicenseeId);
                        }
                        else
                        {
                            objPC.Other_PurchaserConsigneeId = Convert.ToInt32(purchaser.PurchaserConsigneeId);
                        }
                        objPC.PurchaserConsigneeId = null;
                        objPC.LicenseeId = null;
                        objPC.StateId = null;
                        objPC.DistrictId = null;
                        objPC.PurchaserConsigneeDistrictId = null;
                        objPC.Route = null;
                        objPC.Route1 = null;

                    }
                    lstPurchaser.Add(objPC);
                }
                for(int j=0;j< lstPurchaser.Count;j++)
                {
                    var paramLt = new
                    {
                        Check = 0,
                        PCID = lstPurchaser[j].PCId
                    };
                    List<PurchaserConsigneeModelView> ltPost = new List<PurchaserConsigneeModelView>();
                    var resultCheckPost = Connection.Query<PurchaserConsigneeModelView>("uspGetPurchaserConsigneeMasterAndTranData", paramLt, commandType: System.Data.CommandType.StoredProcedure);
                    if(resultCheckPost.Count()>0)
                    {
                        ltPost = resultCheckPost.ToList();
                    }
                    List<PurchaserConsigneeModelView.ChekpostAssignment> list = new List<PurchaserConsigneeModelView.ChekpostAssignment>();
                    List<string> list1 = new List<string>();

                    for (int i = 0; i < ltPost.Count; i++)
                    {
                        list.Add(new PurchaserConsigneeModelView.ChekpostAssignment { Value = Convert.ToInt32(ltPost[i].CheckPostId) });
                        //list1.Add(ltPost[i].CheckPostName.ToString());
                        lstPurchaser[j].CheckPostName = ltPost[i].CheckPostName.ToString() + ","+ lstPurchaser[j].CheckPostName;
                    }
                    //lstPurchaser[j].CheckPostName = lstPurchaser[j].CheckPostName.TrimEnd(',');
                    // objPurchaserConsignee.CheckPostCount = list;
                    lstPurchaser[j].CheckPostCount = list;
                }
                return lstPurchaser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ltPurchaser = null;
            }
        }



        public async Task<PurchaserConsigneePermitModel> getGridBulkPermitMasterDataByBulkPermitId(PurchaserConsigneePermitModel purchaserConsignee)
        {
            
            try
            {

                var paramList = new
                {
                    PCId = purchaserConsignee.PCId,
                    Check = purchaserConsignee.Check,
                    BulkPermitId = purchaserConsignee.BulkPermitId,
                    UserId = purchaserConsignee.UserId
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<PurchaserConsigneePermitModel>("uspGetBulkPermitMasterDataByBulkPermitId", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    purchaserConsignee = result.FirstOrDefault();
                    
                }
                return purchaserConsignee;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                purchaserConsignee = null;
            }
        }

        public async Task<List<EmpDropDown>> Dropdown(EmpDropDown objEmpDropDown)
        {
            List<EmpDropDown> objListEmpDropDown = new List<EmpDropDown>();
            try
            {
                var paramList = new
                {
                    P_Acction = objEmpDropDown.Action,
                    P_StartId = objEmpDropDown.Stateid
                };

                var result = await Connection.QueryAsync<EmpDropDown>("UspEpassBindDropDown", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objListEmpDropDown = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objListEmpDropDown;
        }

      
        public async Task<List<PurchaseConsignee>> GetEndUserLisenseeDetails(PurchaseConsignee objPurchaseConsignee)
        {
            List<PurchaseConsignee> objList = new List<PurchaseConsignee>();
            try
            {
                var paramiter1 = new
                {
                    LoginUserId = objPurchaseConsignee.LoginUserId,
                    chk = objPurchaseConsignee.chk
                };

                string LesseeCaptiveMineStatus = "";
                LesseeCaptiveMineStatus = await Connection.ExecuteScalarAsync<string>("uspCaptiveMinesOperation", paramiter1, commandType: System.Data.CommandType.StoredProcedure);
                // LesseeCaptiveMineStatus = GetCaptiveMineStatusOfLessee(objPurchaseConsignee.LoginUserId);

                var paramList = new
                {
                    BulkPermitId = objPurchaseConsignee.BulkPermitId,
                    DistrictID = objPurchaseConsignee.LicenseeDistrictId,
                    ApplicationTypeId = objPurchaseConsignee.ApplicationType_Id,
                    LesseeCaptiveMineStatus = LesseeCaptiveMineStatus,
                    UserID= objPurchaseConsignee.LoginUserId
                };

                var result = Connection.Query<PurchaseConsignee>("GetEndUserLisenseeDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objList = result.ToList();
                }

               
            }
            catch (Exception ex) {
                throw ex;
            }
            return objList;

            
        }

        public async Task<PurchaserConsigneePermitModel> getDestinationByPurchaseConsigneeId(PurchaserConsigneePermitModel purchaserConsignee)
        {
            try
            {
                var paramList = new
                {
                    PurchaserConsigneeId = purchaserConsignee.PurchaserConsigneeId,
                    BindedLicensee = purchaserConsignee.BindedLicensee,
                    BindedEnduser = purchaserConsignee.BindedEnduser,
                    BindedLicenseeType = purchaserConsignee.BindedLicenseeType,
                    EndUserType = purchaserConsignee.EndUserType,
                    Check = purchaserConsignee.Check,
                    UserId = purchaserConsignee.UserId
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<PurchaserConsigneePermitModel>("uspGetBulkPermitMasterDataByBulkPermitId", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    purchaserConsignee = result.FirstOrDefault();
                }
                return purchaserConsignee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                purchaserConsignee = null;
            }
        }

        public async Task<List<PurchaserConsigneePermitModel>> GetTransportationModeList(PurchaserConsigneePermitModel objPurchaseConsignee)
        {
            List<PurchaserConsigneePermitModel> objList = new List<PurchaserConsigneePermitModel>();
            try
            {
               
                var paramList = new
                {
                 
                    UserId = objPurchaseConsignee.UserId
                };

                var result = await Connection.QueryAsync<PurchaserConsigneePermitModel>("GetTransportationModeList", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objList = result.ToList();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objList;


        }

        /// <summary>
        /// Licensee District Bind
        /// </summary>
        /// <param name="objEmpDropDown"></param>
        /// <returns></returns>
        public async Task<List<EmpDropDown>> GetStateDistrictList()
        {
            List<EmpDropDown> objListEmpDropDown = new List<EmpDropDown>();
            try
            {
                var paramList = new
                {
                    
                };

                var result = await Connection.QueryAsync<EmpDropDown>("GetDistrictDataForUser", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objListEmpDropDown = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objListEmpDropDown;
        }
        /// <summary>
        /// To bind licenseetype in Purchaser Consignee Screen
        /// </summary>
        /// <param name="objpurchase"></param>
        /// <returns></returns>

        public async Task<List<EmpDropDown>> GetLicenseeTypeLists(PurchaserConsigneePermitModel objpurchase)
        {
            List<EmpDropDown> objList = new List<EmpDropDown>();
            try
            {

                var paramList = new
                {

                    UserId = objpurchase.UserId,
                    Check = "1",
                    BulkPermitId = objpurchase.BulkPermitId,
                };

                var result = await Connection.QueryAsync<EmpDropDown>("GetLesseeLicenseeTypeMasters", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objList = result.ToList();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objList;


        }


        public async Task<string> GetCaptiveMineStatusOfLessee(PurchaserConsigneePermitModel objpurchase)
        {
            string result = string.Empty;
            try
            {

                var paramList = new
                {
                    LoginUserId = objpurchase.UserId,
                    chk = "5",
                    
                };
                DynamicParameters param = new DynamicParameters();
                 result = await Connection.ExecuteScalarAsync<string>("uspCaptiveMinesOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                


                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                result = null;
            }
        }
        /// <summary>
        /// Get lisensee details accoding to lisencee type and district id for pirchaser consignee
        /// </summary>
        /// <param name="objpurchase"></param>
        /// <returns></returns>
        public async Task<List<PurchaseConsignee>> GetEndUserLisensee(PurchaserConsigneePermitModel objpurchase)
        {
            List<PurchaseConsignee> objList = new List<PurchaseConsignee>();
            try
            {

                var paramList = new
                {

                    BulkPermitID = objpurchase.BulkPermitId,
                    DistrictID = objpurchase.Districtid,
                    ApplicationTypeId = objpurchase.Applicationid,
                    LesseeCaptiveMineStatus = objpurchase.lesseecompstatus,
                    UserID = objpurchase.UserId,

                };

                var result = await Connection.ExecuteReaderAsync("GetEndUserLisenseeDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PurchaseConsignee objpurchase1 = new PurchaseConsignee();
                    
                     objpurchase1.PurchaserConsigneeId = Convert.ToInt32(dt.Rows[i]["EndUserId"]);
                    objpurchase1.PurchaserConsigneeName = Convert.ToString(dt.Rows[i]["EndUserName"]);
                    objpurchase1.Address = Convert.ToString(dt.Rows[i]["Address"]);
                    objList.Add(objpurchase1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objList;


        }


        /// <summary>
        /// Get lisensee details accoding to lisencee type and district id for pirchaser consignee
        /// </summary>
        /// <param name="objpurchase"></param>
        /// <returns></returns>
        public async Task<List<PurchaseConsignee>> GetEndUserLisenseeTypeForWasheryDetails(PurchaserConsigneePermitModel objpurchase)
        {
            List<PurchaseConsignee> objList = new List<PurchaseConsignee>();
            try
            {

                var paramList = new
                {

                    BulkPermitID = objpurchase.BulkPermitId,
                    MineralName = objpurchase.MineralName,
                    
                    UserID = objpurchase.UserId,

                };

                var result = await Connection.ExecuteReaderAsync("GetEndUserLisenseeWasheryDetailsType", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PurchaseConsignee objpurchase1 = new PurchaseConsignee();

                    objpurchase1.PurchaserConsigneeId = Convert.ToInt32(dt.Rows[i]["EndUserId"]);
                    objpurchase1.PurchaserConsigneeName = Convert.ToString(dt.Rows[i]["EndUserName"]);
                   
                    objList.Add(objpurchase1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objList;


        }


        /// <summary>
        /// Get lisensee details accoding to lisencee type and district id for pirchaser consignee
        /// </summary>
        /// <param name="objpurchase"></param>
        /// <returns></returns>
        public async Task<List<PurchaseConsignee>> GetEndUserLisenseeWasheryDetails(PurchaserConsigneePermitModel objpurchase)
        {
            List<PurchaseConsignee> objList = new List<PurchaseConsignee>();
            try
            {

                var paramList = new
                {

                    BulkPermitID = objpurchase.BulkPermitId,
                    LesseeCaptiveMineStatus = objpurchase.lesseecompstatus,
                    DistrictID=objpurchase.LicenseeDistrictId,
                    UserID = objpurchase.UserId,
                    LicenseeId=objpurchase.LicenseeId,
                    ApplicationTypeId=objpurchase.Applicationid,
                };

                var result = await Connection.ExecuteReaderAsync("GetEndUserLisenseeWasheryDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PurchaseConsignee objpurchase1 = new PurchaseConsignee();

                    objpurchase1.PurchaserConsigneeId = Convert.ToInt32(dt.Rows[i]["EndUserId"]);
                    objpurchase1.PurchaserConsigneeName = Convert.ToString(dt.Rows[i]["EndUserName"]);
                    objpurchase1.Address = Convert.ToString(dt.Rows[i]["Address"]);
                    objList.Add(objpurchase1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objList;


        }
        /// <summary>
        ///Added by suroj on 29-jun-2021 for save data in Purchase consignee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string OutputResult = "";
        public async Task<string> AddData(PurchaserConsigneeModel model)
        {
            string checkpostid = "";
            int? Route = 0;
            int? DistrictId = 0;

            string result = string.Empty;
            int Response = 0;
            if (model.DispatchType == "EndUser")
            {

                if (model.ThroughIsCoalWashery != null && model.ThroughIsCoalWashery == "1")
                {
                    if (model.ThroughCoalWasheryId == null || model.ThroughCoalWasheryDistrictId == null)
                    {
                        result = "NoSelection";
                    }
                }
                model.LicenseeTypeId = null;
                model.LicenseeId = null;
            }
            else if (model.DispatchType == "Licensee")
            {
                model.PurchaserConsigneeId = null;
                model.StateId = null;
                if (model.ThroughIsCoalWashery != null && model.ThroughIsCoalWashery == "1")
                {
                    if (model.ThroughCoalWasheryId == null || model.ThroughCoalWasheryDistrictId == null)
                    {
                        result = "NoSelection";
                    }
                }
            }
            else if (model.DispatchType == "Others") // for SECL Coal Related Changes
            {
                model.PurchaserConsigneeId = null;
                model.StateId = null;
                model.LicenseeTypeId = null;
                model.LicenseeId = null;

                if (model.Yes_No == "Yes")
                {


                    model.StateId = model.Other_StateId;
                    if (model.Other_PurchaserConsigneeEndUserDistrictId != null && model.Other_PurchaserConsigneeEndUserDistrictId > 0)
                    {
                        model.Other_PurchaserConsigneeDistrictId = model.Other_PurchaserConsigneeEndUserDistrictId;
                    }
                    if (model.Other_PurchaserConsigneeEnduserId != null && model.Other_PurchaserConsigneeEnduserId > 0)
                    {
                        model.Other_PurchaserConsigneeId = model.Other_PurchaserConsigneeEnduserId;
                    }

                    if (model.Other_RouteEndUser != null && model.Other_RouteEndUser > 0)
                    {
                        model.Other_Route = model.Other_RouteEndUser;
                    }

                    if (model.UserType == "Licensee" || string.IsNullOrEmpty(model.UserType))
                    {
                        model.LicenseeId = model.Other_PurchaserConsigneeId;
                        model.PurchaserConsigneeId = null;
                        model.LicenseeTypeId = model.Other_LicenseeTypeId;
                    }
                    else
                    {
                        model.PurchaserConsigneeId = model.Other_PurchaserConsigneeId;
                        model.LicenseeId = null;

                    }
                }
            }

            try
            {
               

                if (model.PurchaserConsigneeDistrictId != null)
                {
                    DistrictId = model.PurchaserConsigneeDistrictId;
                    Route = model.RouteId;
                }
                else if (model.DispatchType == "Others")
                {
                    if (model.Yes_No == "Yes")
                    {
                        DistrictId = model.Other_PurchaserConsigneeDistrictId;
                        Route = model.Other_Route;
                    }
                    else
                    {
                        Route = null;
                    }
                }
                else
                {
                    DistrictId = model.LicenseeDistrictId;
                    Route = model.Route1;
                }


                if (result != string.Empty)
                {
                    return OutputResult = "W"; // if Through Washery Select and Washery Name not select 
                }
                else
                {
                    string RCR_RTP = string.Empty;
                    if (!string.IsNullOrEmpty(model.RCR_RTP_BY))
                    {
                        RCR_RTP = model.RCR_RTP_BY.ToUpper();
                    }
                    else
                    {
                        RCR_RTP = model.RCR_RTP_BY;
                    }

                    if (model.DispatchType == "Licensee" && (model.LicenseeId == null || model.LicenseeId == 0))
                    {
                        return OutputResult = "L";
                    }
                    if (model.DispatchType == "EndUser" && (model.PurchaserConsigneeId == null || model.PurchaserConsigneeId == 0))
                    {
                        return OutputResult = "E";
                    }
                    if (model.DispatchType == "Others" && (string.IsNullOrEmpty(model.PartyCode) || string.IsNullOrEmpty(model.PartyName)) && model.UserType != "Licensee")
                    {
                        if (model.Yes_No == "No")
                        {
                            return OutputResult = "O";
                        }
                    }
                  
                    var paramList = new
                    {

                        PurchaserConsigneeId = model.PurchaserConsigneeId,
                        BulkPermitId = model.BulkPermitId,
                        TransportationModeId = model.TransportationModeId,
                        UserLoginId = model.UserId,
                        checkPostCount=model.CheckPostCount,
                    UserID = model.UserId,
                        Destination = model.Destination,
                        LicenseeTypeId=model.LicenseeTypeId,
                        LicenseeId=model.LicenseeId,
                        StateId=model.StateId,
                        DistrictId= DistrictId,
                        Route=Route,
                        CheckPostID=model.CheckPostName,
                        //IsCoal=IsCoal,
                        CoalWashryId=model.CoalWashryId,
                        SubUserId=194,//sub userid
                        IsOtherParty=model.IsOtherParty,
                        DispatchType=model.DispatchType,
                        PartyName=model.PartyName,
                        PartyCode=model.PartyCode,
                        PartyMobile=model.PartyMobile,
                        ThroughCoalWasheryDistrictId=model.ThroughCoalWasheryDistrictId,
                        ThroughCoalWasheryId=model.ThroughCoalWasheryId,
                        ThroughCoalWasheryLicenseeTypeId=model.ThroughCoalWasheryLicenseeTypeId,
                        OtherYes_No=model.Yes_No,
                        RCR_RTP_BY=RCR_RTP,
                   

                };
                    Response = await Connection.ExecuteScalarAsync<int>("InsertUpdatePurchaserConsigneeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                   
                    if (Response > 0)
                    {
                        return OutputResult = "1";
                    }
                    else
                    {
                        return OutputResult = "3";
                    }
                }
            }
            catch
            {
                return OutputResult = "3";
            }

        }

        /// <summary>
        /// Added by suroj on 29-jun-2021 Method used for edit Purchase Consignee Data
        /// </summary>
        /// <param name="objpurchase"></param>
        /// <returns></returns>

        public async Task<List<PurchaserConsigneeModel>> GetGridData(PurchaserConsigneeModel objpurchase)
        {
            string check = string.Empty;
            List<PurchaserConsigneeModel> data = new List<PurchaserConsigneeModel>();
            try
            {
                
               
                var paramList = new
                {

                    Check ="5",
                    BulkPermitId = objpurchase.BulkPermitId,
                    UserId = objpurchase.UserId,

                    PCID = objpurchase.PCId,
                    
                };

                var result = await Connection.ExecuteReaderAsync("uspGetBulkPermitMasterDataByBulkPermitId", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
               
                    if (dt != null)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            PurchaserConsigneeModel objPC = new PurchaserConsigneeModel();
                            objPC.PCId = Convert.ToInt32(dt.Rows[i]["PCId"]);
                            objPC.RouteName = Convert.ToString(dt.Rows[i]["RouteName"]);
                            objPC.TransportationMode = Convert.ToString(dt.Rows[i]["TransportationMode"]);
                            objPC.BulkPermitNo = Convert.ToString(dt.Rows[i]["BulkPermitNo"]);
                            objPC.BulkPermitId = Convert.ToInt32(dt.Rows[i]["BulkPermitId"]);
                            objPC.PurchaserConsigneeId = Convert.ToInt32(dt.Rows[i]["PurchaserConsigneeId"]);
                            objPC.TransportationModeId = Convert.ToInt32(dt.Rows[i]["TransportationModeId"]);
                            objPC.Destination = Convert.ToString(dt.Rows[i]["Destination"]);
                            objPC.LicenseeId = Convert.ToInt32(dt.Rows[i]["LicenseeId"]);
                            objPC.PurchaserConsigneeName = Convert.ToString(dt.Rows[i]["PurchaserConsigneeName"]);
                            objPC.StateId = Convert.ToInt32(dt.Rows[i]["StateId"]);
                            objPC.LicenseeTypeId = Convert.ToInt32(dt.Rows[i]["LicenseeTypeId"]);
                            objPC.CoalWashryId = !string.IsNullOrEmpty(dt.Rows[i]["CoalWashryId"].ToString()) ? Convert.ToInt32(dt.Rows[i]["CoalWashryId"]) : 0;
                            objPC.CoalWashryAddress = Convert.ToString(dt.Rows[i]["CoalWashryAddress"]);
                            objPC.PartyCode = Convert.ToString(dt.Rows[i]["PartyCode"]);
                            objPC.PartyMobile = Convert.ToString(dt.Rows[i]["PartyMobile"]);
                            objPC.PartyName = Convert.ToString(dt.Rows[i]["PartyName"]);
                            objPC.OtherOption = Convert.ToString(dt.Rows[i]["OthersOption"]);
                            objPC.IsOtherParty = Convert.ToString(dt.Rows[i]["IsOtherParty"]);

                            objPC.ThroughCoalWasheryId = !string.IsNullOrEmpty(dt.Rows[i]["ThroughCoalWasheryId"].ToString()) ? Convert.ToInt32(dt.Rows[i]["ThroughCoalWasheryId"]) : 0;
                            objPC.ThroughIsCoalWashery = !string.IsNullOrEmpty(dt.Rows[i]["ThroughIsCoalWashery"].ToString()) ? Convert.ToString(dt.Rows[i]["ThroughIsCoalWashery"]) : "";
                            objPC.ThroughCoalWasheryDistrictId = !string.IsNullOrEmpty(dt.Rows[i]["ThroughCoalWasheryDistrictId"].ToString()) ? Convert.ToInt32(dt.Rows[i]["ThroughCoalWasheryDistrictId"]) : 0;
                            objPC.Yes_No = Convert.ToString(dt.Rows[i]["OtherYes_No"]);
                            objPC.DispatchType = Convert.ToString(dt.Rows[i]["PurchaserType"]);
                            objPC.RCR_RTP_BY = Convert.ToString(dt.Rows[i]["RCR_RTP_BY"]);
                            //if (objPC.LicenseeTypeId == 0)
                            //{
                            //    objPC.PurchaserConsigneeDistrictId = (dt.Rows[i]["DistrictId"] is DBNull) ? 0 : Convert.ToInt32(dt.Rows[i]["DistrictId"]);
                            //    objPC.Route = Convert.ToInt32(dt.Rows[i]["Route"]);
                            //}
                            //else
                            //{
                            //    objPC.LicenseeDistrictId = Convert.ToInt32(dt.Rows[i]["DistrictId"]);
                            //    objPC.Route1 = Convert.ToInt32(dt.Rows[i]["Route"]);
                            //}

                            if (objPC.PurchaserConsigneeId > 0)
                            {

                                objPC.PurchaserConsigneeDistrictId = (dt.Rows[i]["DistrictId"] is DBNull) ? 0 : Convert.ToInt32(dt.Rows[i]["DistrictId"]);
                                objPC.Route = Convert.ToInt32(dt.Rows[i]["Route"]);
                            }
                            else if (objPC.LicenseeId > 0)
                            {
                                objPC.LicenseeDistrictId = Convert.ToInt32(dt.Rows[i]["DistrictId"]);
                                objPC.Route1 = Convert.ToInt32(dt.Rows[i]["Route"]);
                            }
                            if (objPC.Yes_No == "Yes" && objPC.DispatchType == "OTHERS")
                            {
                                if (objPC.DispatchType == "OTHERS")
                                {
                                    objPC.DispatchType = "Others";
                                }
                                objPC.UserType = Convert.ToString(dt.Rows[i]["UserType"]);
                                objPC.Other_StateId = Convert.ToInt32(dt.Rows[i]["StateId"]);
                                objPC.Other_PurchaserConsigneeDistrictId = Convert.ToInt32(dt.Rows[i]["DistrictId"]);
                                objPC.Other_Route = Convert.ToInt32(dt.Rows[i]["Route"]);
                                if (objPC.UserType == "Licensee")
                                {
                                    objPC.Other_PurchaserConsigneeId = Convert.ToInt32(dt.Rows[i]["LicenseeId"]);
                                }
                                else
                                {
                                    objPC.Other_PurchaserConsigneeId = Convert.ToInt32(dt.Rows[i]["PurchaserConsigneeId"]);
                                }
                                objPC.PurchaserConsigneeId = null;
                                objPC.LicenseeId = null;
                                objPC.StateId = null;
                                objPC.DistrictId = null;
                                objPC.PurchaserConsigneeDistrictId = null;
                                objPC.Route = null;
                                objPC.Route1 = null;

                            }
                            data.Add(objPC);
                        }
                    }

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;


        }


        public async Task<string> DeleteData(PurchaserConsigneeModel model)
        {
            int Response = 0;
            try
            {
                var paramList = new
                    {

                    UserId = model.UserId,
                    PCId = model.PCId,
                    UserLoginId = model.UserId,
                    };
                    Response =await Connection.ExecuteScalarAsync<int>("uspDeletePurchaserConsignee", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    if (Response > 0)
                    {
                        return OutputResult = "1";
                    }
                    else
                    {
                        return OutputResult = "3";
                    }
                
            }
            catch
            {
                return OutputResult = "3";
            }

        }

        public async Task<List<PurchaseConsignee>> GetOtherEndUserLisenseeDetails(PurchaseConsignee objPurchaseConsignee)
        {
            List<PurchaseConsignee> objList = new List<PurchaseConsignee>();
            try
            {
                var paramiter1 = new
                {
                    LoginUserId = objPurchaseConsignee.LoginUserId,
                    chk = objPurchaseConsignee.chk
                };

                string LesseeCaptiveMineStatus = "";
                LesseeCaptiveMineStatus = await Connection.ExecuteScalarAsync<string>("uspCaptiveMinesOperation", paramiter1, commandType: System.Data.CommandType.StoredProcedure);
                // LesseeCaptiveMineStatus = GetCaptiveMineStatusOfLessee(objPurchaseConsignee.LoginUserId);

                var paramList = new
                {
                    BulkPermitId = objPurchaseConsignee.BulkPermitId,
                    DistrictID = objPurchaseConsignee.LicenseeDistrictId,
                    ApplicationTypeId = objPurchaseConsignee.ApplicationType_Id,
                    LesseeCaptiveMineStatus = LesseeCaptiveMineStatus,
                    UserID = objPurchaseConsignee.LoginUserId,
                    OtherUserType=objPurchaseConsignee.Other_user
                };

                var result = await Connection.QueryAsync<PurchaseConsignee>("GetEndUserLisenseeDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objList = result.ToList();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objList;


        }
        /// <summary>
        /// Added by suroj on 01-jul-2021 to get checkpost names for other purchase consignee
        /// </summary>
        /// <param name="objpurchase"></param>
        /// <returns></returns>
        public async Task<List<PurchaserConsigneeModel>> Getcheckpost()
        {
            
            List<PurchaserConsigneeModel> data = new List<PurchaserConsigneeModel>();
            try
            {
                var paramList = new
                {
                    P_CHAR_ACTION = 'S',
                };

                var result = await Connection.ExecuteReaderAsync("USP_CHECKPOST_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PurchaserConsigneeModel objPC = new PurchaserConsigneeModel();

                        objPC.CheckPostId = Convert.ToInt16(dt.Rows[i]["CHECKPOSTID"]);
                        objPC.CheckPostName = Convert.ToString(dt.Rows[i]["CHECKPOSTNAME"]);

                        data.Add(objPC);
                    }

                }
                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data = null;
            }
            


        }

    }
}
