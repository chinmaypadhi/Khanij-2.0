 // ***********************************************************************
//  Model Name               : eTransitpassProvider
//  Desciption               : Add ,Fetch Etransit Pass Details
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 07-jul-2021
// ************************************************************************

using Dapper;
using EpassApi.Factory;
using EpassApi.Repository;
using EpassEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Model.eTransitpass
{
    public class eTransitpassprovider : RepositoryBase, IeTransitpassprovider
    {
        public eTransitpassprovider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Added by suroj on 7-jul-2021  to fetch Permit No
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        public async Task<List<TransitPassModel>> GetApprovedBulkPermitList(TransitPassModel objOpenModel)
        {
            List<TransitPassModel> LtPermit = new List<TransitPassModel>();
            try
            {
                var paramList = new
                {
                    UserID = objOpenModel.userid,

                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<TransitPassModel>("GetBulkPermitDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);

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
        /// <summary>
        /// Method used to convert datareader to dataset
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
        /// Added by suroj on 7-jul-2021 to fetch Lessee basic details like District,Tehsil,village in Etransit Pass Page
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        public async Task<TransitPassModel> getTransitpassdtls(TransitPassModel objOpenModel)
        {
            string _procedure = string.Empty;
            DynamicParameters param = null;
            try
            {
                if (objOpenModel.Usertype.ToUpper() == "TAILING DAM")
                {
                    _procedure = "getDetailsByTailingDamUserID";
                }
                else
                {
                    _procedure = "getDetailsByUserID";
                }
                var paramList = new
                {
                    UserID = objOpenModel.userid,

                };
                param = new DynamicParameters();
                var result = await Connection.ExecuteReaderAsync(_procedure, paramList, commandType: System.Data.CommandType.StoredProcedure);
                var ds = ConvertDataReaderToDataSet(result);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    objOpenModel.DistrictId = Convert.ToInt32(ds.Tables[0].Rows[0]["DistrictId"].ToString());
                    objOpenModel.DistrictName = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
                    objOpenModel.VillageId = Convert.ToInt32(ds.Tables[0].Rows[0]["VILLAGE_ID"].ToString());
                    objOpenModel.VillageName = Convert.ToString(ds.Tables[0].Rows[0]["VillageName"]);
                    objOpenModel.TehsilID = Convert.ToInt32(ds.Tables[0].Rows[0]["TehsilID"].ToString());
                    objOpenModel.TehsilName = Convert.ToString(ds.Tables[0].Rows[0]["TehsilName"]);
                    objOpenModel.MineralType = Convert.ToString(ds.Tables[0].Rows[0]["MineralType"]);
                    objOpenModel.MineralType = Convert.ToString(ds.Tables[0].Rows[0]["MineralType"]);
                    objOpenModel.IsLowGrade = Convert.ToString(ds.Tables[0].Rows[0]["IsLowGrade"]);
                    if (objOpenModel.MineralType == "Minor Mineral" || objOpenModel.IsLowGrade == "Low Grade - Limestone")
                    {

                        var paramlist1 = new
                        {
                            UserID = objOpenModel.userid,

                        };

                        var subresult = await Connection.ExecuteReaderAsync("uspMinorMineralOfflineQuantity", paramlist1, commandType: System.Data.CommandType.StoredProcedure);
                        DataTable _dt = new DataTable();
                        _dt.Load(subresult);


                        if (_dt != null && _dt.Rows.Count > 0)
                        {
                            objOpenModel.OfflineQty = Convert.ToDecimal(_dt.Rows[0]["TPOfflineQty"]);
                        }

                    }

                    if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        objOpenModel.Errormsg = "TPStoppedByDD";
                        //return RedirectToAction("TPStoppedByDD", "ValidityExpired", new { Area = "" });
                    }
                }
                else
                {
                    if (objOpenModel.Usertype.ToUpper() != "LICENSEE")
                    {
                        objOpenModel.Errormsg = "ValidityExpired";

                        //return RedirectToAction("ValidityExpired", "ValidityExpired", new { Area = "" });
                    }
                }
                return objOpenModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objOpenModel = null;
            }
        }

        /// <summary>
        /// Added by suroj on 08-jul-2021 to fetch details like mineral name,address agaiinst permit number in Transit Pass
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        public async Task<TransitPassModel> getBulkPermitDataByBulkPermitId(TransitPassModel objTP)
        {

            DynamicParameters param = null;
            try
            {

                var paramList = new
                {
                    BulkPermitId = objTP.BulkPermitId,

                };
                param = new DynamicParameters();
                var result = await Connection.ExecuteReaderAsync("uspGetBulkPermitDetails_ByBulkPermitId", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable data = new DataTable();
                data.Load(result);
                if (data != null && data.Rows.Count > 0)
                {
                    objTP.Lessee_Licensee_Name = data.Rows[0]["LesseeName"].ToString();

                    if (!(data.Rows[0]["LeaseFrom"] is DBNull))
                    {
                        //shyam sir Date Convertion Change
                        objTP.LeaseValidity_From =DateTime.ParseExact(data.Rows[0]["LeaseFrom"].ToString(), "dd/MM/yyyy", null);
                        //objTP.LeaseValidity_From = Convert.ToDateTime(data.Rows[0]["LeaseFrom"].ToString());
                    }

                    if (!(data.Rows[0]["LeaseTo"] is DBNull))
                    { //shyam sir Date Convertion Change
                        objTP.LeaseValidity_To=DateTime.ParseExact(data.Rows[0]["LeaseTo"].ToString(), "dd/MM/yyyy", null);
                       // objTP.LeaseValidity_To = Convert.ToDateTime(data.Rows[0]["LeaseTo"].ToString());
                    }
                    if (!(data.Rows[0]["LeaseFrom"] is DBNull))
                    { //shyam sir Date Convertion Change
                        objTP.LeaseFromDate = DateTime.ParseExact(data.Rows[0]["LeaseFrom"].ToString(), "dd/MM/yyyy", null).ToString("dd/MM/yyy");
                        //objTP.LeaseFromDate = Convert.ToDateTime(data.Rows[0]["LeaseFrom"].ToString()).ToString("dd/MM/yyy");
                    }
                    if (!(data.Rows[0]["LeaseTo"] is DBNull))
                    {//shyam sir Date Convertion Change
                        objTP.LeaseToDate = DateTime.ParseExact(data.Rows[0]["LeaseTo"].ToString(), "dd/MM/yyyy", null).ToString("dd/MM/yyy");
                        //objTP.LeaseToDate = Convert.ToDateTime(data.Rows[0]["LeaseTo"].ToString()).ToString("dd/MM/yyy");
                    }

                    objTP.MineralName = data.Rows[0]["MineralName"].ToString();
                    objTP.MineralId = Convert.ToInt32(data.Rows[0]["MineralId"]);
                    objTP.MineralGradeName = data.Rows[0]["MineralGrade"].ToString();
                    objTP.MineralGradeId = Convert.ToInt32(data.Rows[0]["MineralGradeId"]);
                    if (!(string.IsNullOrEmpty(Convert.ToString(data.Rows[0]["AverageSalePrice"]))))
                        objTP.Mineral_SaleValue = Convert.ToDecimal(data.Rows[0]["AverageSalePrice"]);
                    objTP.DONumber = Convert.ToString(data.Rows[0]["DONumber"]);
                    objTP.Remaining_Qty = Convert.ToDecimal(data.Rows[0]["RemainingStock"]);
                    objTP.Area = Convert.ToDecimal(data.Rows[0]["Area"]);
                    objTP.MineralNature = Convert.ToString(data.Rows[0]["MineralNature"]);
                    objTP.UnitName = Convert.ToString(data.Rows[0]["UnitName"]);
                    objTP.Hindi_UnitName = Convert.ToString(data.Rows[0]["Hindi_UnitName"]);
                    objTP.MineralType = Convert.ToString(data.Rows[0]["MineralType"]);
                }
                return objTP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTP = null;
            }
        }
        /// <summary>
        /// Added by suroj on 08-jul-2021 to bind Purchase/Consignee in eTransit Pass
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        public async Task<List<TransitPassModel>> GetCascadePurchaserConsignee(TransitPassModel objOpenModel)
        {
            List<TransitPassModel> LtPermit = new List<TransitPassModel>();
            try
            {
                var paramList = new
                {
                    UserID = objOpenModel.userid,
                    BulkPermitID = objOpenModel.BulkPermitId,
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.ExecuteReaderAsync ("GetPurchaseConsigneedForTP", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TransitPassModel obj = new TransitPassModel();

                        obj.PurchaserConsigneeId = Convert.ToInt32(dt.Rows[i]["PCId"]);
                        obj.PurchaserConsigneeName = Convert.ToString(dt.Rows[i]["ApplicantName"]);
                        obj.TransportationMode = Convert.ToString(dt.Rows[i]["TransportationMode"]);
                        LtPermit.Add(obj);
                    }
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
        /// <summary>
        /// Added by suroj on 08-jul-2021 to Get destination Against Purchase consignee ID
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>
        public async Task<TransitPassModel> GetDataByPurchaserConsigneeId(TransitPassModel objTP)
        {

            DynamicParameters param = null;
            try
            {

                var paramList = new
                {
                    BulkPermitId = objTP.BulkPermitId,
                    PurchaseConsigneeID = objTP.PurchaserConsigneeId,
                    UserID = objTP.userid
                };
                param = new DynamicParameters();
                var result = await Connection.ExecuteReaderAsync ("GetDetailsByPurchaseConsigneedForTP", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    objTP.Mineral_Destination = dt.Rows[0]["Destination"].ToString();
                    objTP.Mineral_PurchaserName = dt.Rows[0]["ApplicantName"].ToString();
                    //objTP.Area = Convert.ToDecimal(dt.Rows[0]["AREA_IN_HECT"].ToString());
                    objTP.TransportationModeId = Convert.ToInt32(dt.Rows[0]["TransportationModeId"].ToString());
                    objTP.RouteName = dt.Rows[0]["RouteName"].ToString();
                    objTP.OfflineQty = Convert.ToDecimal(dt.Rows[0]["TPOfflineQty"]);
                }
                return objTP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTP = null;
            }
        }


        /// <summary>
        /// Added by suroj on 11-jul-2021 to Get vehicle infomation in Transit Pass screen
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>
        public async Task<List<TPVehicleModel>> GetAllVehicleInformation(TransitPassModel objtran)
        {
            List<TPVehicleModel> objtrans = new List<TPVehicleModel>();

            DynamicParameters param = null;
            TPVehicleModel objTPVehicleModel = null;
            try
            {

                var paramList = new
                {
                    TransporterId = 0,
                    Check = "6",
                    VehicleNumber = objtran.VehicleNumber,
                    UserID = objtran.userid
                };
                param = new DynamicParameters();
                var result = await Connection.ExecuteReaderAsync ("uspGetBulkPermitMasterDataByBulkPermitId", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable data = new DataTable();
                data.Load(result);
                if (data != null && data.Rows.Count > 0)
                {
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        objTPVehicleModel = new TPVehicleModel();

                        objTPVehicleModel.VehicleId = Convert.ToInt32(data.Rows[i]["VehicleId"]);
                        objTPVehicleModel.VehicleNumber = Convert.ToString(data.Rows[i]["VehicleNumber"]);
                        objTPVehicleModel.MaxNetWeight = Convert.ToString(data.Rows[i]["MaxNetWeight"]);
                        objTPVehicleModel.CarryingCapacity = Convert.ToString(data.Rows[i]["CarryingCapacity"]);
                        objTPVehicleModel.VehicleTypeId = Convert.ToString(data.Rows[i]["VehicleTypeId"]);
                        objTPVehicleModel.VehicleTypeName = Convert.ToString(data.Rows[i]["VehicleTypeName"]);
                        objTPVehicleModel.VehicleOwner = Convert.ToString(data.Rows[i]["VehicleOwner"]);
                        objTPVehicleModel.CompanyName = Convert.ToString(data.Rows[i]["CompanyName"]);
                        objTPVehicleModel.VehicleOwnerId = Convert.ToString(data.Rows[i]["TransporterId"]);
                        objTPVehicleModel.TransporterAddress = Convert.ToString(data.Rows[i]["TransporterAddress"]);
                        objTPVehicleModel.TransporterMobile = Convert.ToString(data.Rows[i]["TransporterMobile"]);
                        objTPVehicleModel.GrossWeight = Convert.ToString(data.Rows[i]["GrossWeight"]);
                        objtrans.Add(objTPVehicleModel);
                    }
                }
                return objtrans;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objtrans = null;
            }
        }
        /// <summary>
        /// Added by suroj on 14-jul-2021 to add Etransit pass
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public ReturnOuputResult AddTransitPassDetails(TransitPassModel model)
        {
            ReturnOuputResult outputResult = new ReturnOuputResult();
            Int64 TPID = 0;
            string Response = "";
            string procedure = string.Empty;
            string purchaseconsignee = string.Empty;
            var p = new DynamicParameters();
            if (!string.IsNullOrEmpty(model.NumberOfTP))
            {
                procedure = "uspMultipleMineralOfflineInsertion";
                p.Add("NoOfTP", model.NumberOfTP);
            }
            else
            {
                procedure = "uspTPOpetarion";
            }
            

            if (model.PurchaserConsigneeName != null)
            {
                purchaseconsignee = model.PurchaserConsigneeName;
               
            }
            else
            {
                purchaseconsignee = model.Mineral_PurchaserName;
              
            }
           
            
            p.Add("Check", 2);
            p.Add("BulkPermitId", model.BulkPermitId);
            p.Add("PurchaserConsigneeId", model.PurchaserConsigneeId);
            p.Add("DateOfDispatche", Convert.ToDateTime(model.Mineral_DateOfDispatch).ToString("yyyy-MM-dd"));
            p.Add("TranspoterId", model.TransporterId);
            p.Add("TransportationModeId", model.TransportationModeId);
            p.Add("VehicleTypeId", model.VehicleTypeId);
            p.Add("VehicleId", model.VehicleId);
            p.Add("DriverName", model.DriverName);
            p.Add("DriverContactNumber", model.DriverContactNumber);
                p.Add("DONumber", model.DONumber);
            p.Add("Remark", model.Remarks);
                p.Add("TareWeight", model.TareWeight_Qty);
                p.Add("GrossWeight", model.GrossWeight_Qty);
            p.Add("NetWeight", model.NetWeight_Qty);
            p.Add("UserLoginId", model.userid);
            p.Add("UserId", model.userid);
            p.Add("MineralSaleValue",model.Mineral_SaleValue);
            p.Add("SubUserId", model.userid);
            p.Add("TransportationMode", model.TransportationMode);
            p.Add("TotalQty", model.TotalQty);
                p.Add("AddressofRailwaySliding", model.AddressofRailwaySliding);
                p.Add("RailwayId", model.RailwayId);
            p.Add("RTPQty", model.RailQty);
            p.Add("IsTPOffline", model.Tpoffline);
            p.Add("Destination", model.Mineral_Destination);
            p.Add("SaleValue", model.Mineral_SaleValue);
            p.Add("RouteName", model.RouteName);
            p.Add("PurchaserConsignee", purchaseconsignee);
                 if (model.PurchaserType == "Un-registered")
            {
                p.Add("@ForwardingNoteId", null);
                //if (string.IsNullOrEmpty(model.UnRegistredWithTractorVehicleOwner))
                if (!string.IsNullOrEmpty(model.UnRegistredWithoutTractorVehicleOwner))
                {
                    //cmd.Parameters.AddWithValue("@Minor_VehicleType", model.Minor_VehicleType);
                    p.Add("@Minor_VehicleOwner", model.UnRegistredWithoutTractorVehicleOwner);

                }
                else
                {
                    p.Add("@Minor_VehicleType", "Tractor");
                    p.Add("@Minor_VehicleNumber", model.UnRegistredWithTractorVehicleId);
                    p.Add("@Minor_VehicleOwner", model.UnRegistredWithTractorVehicleOwner);
                }
            }
            else
            {
                p.Add("@ForwardingNoteId", model.ForwardingNoteID);
                p.Add("@Minor_VehicleType", model.Minor_VehicleType);
                p.Add("@Minor_VehicleNumber", model.Minor_VehicleNumber);
                p.Add("@Minor_VehicleOwner", model.Minor_VehicleOwner);
            }

            p.Add("@PurchaserType", model.PurchaserType);
            p.Add("@PurchaserSubType", model.PurchaserSubType);
            p.Add("@PurchaserName", model.PurchaserName);
            p.Add("@PurchaserContactNumber", model.PurchaserContactNumber);
            p.Add("@UnRegistredVehicleTypeId", model.UnRegistredVehicleTypeId);
            p.Add("@UnRegistredWithoutTractorVehicleId", model.UnRegistredWithoutTractorVehicleId);
            p.Add("@UnRegistredWithoutTractorVehicleOwner", model.UnRegistredWithoutTractorVehicleOwner);
            p.Add("@UnRegistredWithTractorNumber", model.UnRegistredWithTractorVehicleId);
            p.Add("@UnRegistredWithTractorVehicleOwner", model.UnRegistredWithTractorVehicleOwner);
            p.Add("@DistrictId", model.DistrictId);
            p.Add("@DestinationBlock", model.DestinationBlock);
            p.Add("@ReturnIdentity", dbType: DbType.Int64, direction: ParameterDirection.Output);


            Response = Connection.ExecuteScalar<string>(procedure, p, commandType: System.Data.CommandType.StoredProcedure);
            TPID = p.Get<Int64>("ReturnIdentity");
            if (TPID > 0)
            {
                outputResult.OutputResult = "1";
                outputResult.TPID = TPID;
            }
            else
            {
                outputResult.OutputResult = "3";
                outputResult.TPID = 0;

            }
            return outputResult;
        }


        /// <summary>
        /// Added by Suroj on 15-jul-2021 to generate print eTransit Pass
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>
        public TransitPassModel PassReportDesignView(TransitPassModel model)
        {
            DynamicParameters param = null;

            try
            {

                var paramList = new
                {
                    TransitPassId = model.TransitPassId,
                    Check = "1",

                    UserID = model.userid
                };
                param = new DynamicParameters();
                var result = Connection.ExecuteReader("uspTPOpetarion", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    model.TransporterName = Convert.ToString(dt.Rows[0]["TransporterName"]);
                    model.TransporterMobile = Convert.ToString(dt.Rows[0]["TransporterMobile"]);
                    model.TransporterCHiMMSNo = Convert.ToString(dt.Rows[0]["TransporterCHiMMSNo"]);

                    model.BulkPermitNo = Convert.ToString(dt.Rows[0]["BulkPermitNo"]);
                    model.SchemeofCoal = Convert.ToString(dt.Rows[0]["TypeOfCoalDispatched"]);

                    model.PurchaserConsigneeName = Convert.ToString(dt.Rows[0]["EndUserName"]);

                    model.MineralGradeName = Convert.ToString(dt.Rows[0]["MineralGrade"]);
                    model.MineralNature = Convert.ToString(dt.Rows[0]["MineralNature"]);

                    model.UnitName = Convert.ToString(dt.Rows[0]["UnitName"]);

                    model.DONumber = Convert.ToString(dt.Rows[0]["DONumber"]);
                    model.DODate = Convert.ToString(dt.Rows[0]["DODate"]);


                    model.TransportationMode = Convert.ToString(dt.Rows[0]["TransportationMode"]);
                    model.IssueDateTime = Convert.ToDateTime(dt.Rows[0]["DateOfDispatche"]).ToString("dd/MM/yyyy");
                    model.IssueTime = Convert.ToDateTime(dt.Rows[0]["DateOfDispatche"]).ToString("hh:mm:ss tt");
                    model.TareWeight_Qty = Convert.ToDecimal(dt.Rows[0]["TareWeight"]);
                    model.GrossWeight_Qty = Convert.ToDecimal(dt.Rows[0]["GrossWeight"]);
                    model.NetWeight_Qty = Convert.ToDecimal(dt.Rows[0]["NetWeight"]);
                    model.Mineral_SaleValue = Convert.ToDecimal(dt.Rows[0]["AverageSalePrice"]);
                    model.VehicleNumber = Convert.ToString(dt.Rows[0]["VehicleNumber"]);
                    model.VehicleCHiMMSNo = Convert.ToString(dt.Rows[0]["VehicleCHiMMSNo"]);
                    model.DriverName = Convert.ToString(dt.Rows[0]["DriverName"]);
                    model.MineralName = Convert.ToString(dt.Rows[0]["MineralName"]);

                    model.VehicleTypeName = Convert.ToString(dt.Rows[0]["VehicleTypeName"]);
                    model.RouteName = Convert.ToString(dt.Rows[0]["RouteName"]);
                    model.Mineral_Destination = Convert.ToString(dt.Rows[0]["Destination"]);
                    model.TransitPassNumber = Convert.ToString(dt.Rows[0]["TransitPassNo"]);
                    model.TransitPassId = Convert.ToInt32(dt.Rows[0]["TransitPassID"]);
                    model.DistrictName = Convert.ToString(dt.Rows[0]["DistrictName"]);
                    model.VillageName = Convert.ToString(dt.Rows[0]["VillageName"]);
                    model.TehsilName = Convert.ToString(dt.Rows[0]["TehsilName"]);
                    //model. = Convert.ToDecimal(dt.Rows[0]["AreaDetails"]);
                    model.Area = Convert.ToDecimal(dt.Rows[0]["AreaHect"]);
                    model.LeaseFromDate = Convert.ToString(dt.Rows[0]["LeaseFrom"]);
                    model.LeaseToDate = Convert.ToString(dt.Rows[0]["LeaseTo"]);

                    model.LeaseValidity = Convert.ToString(dt.Rows[0]["Validity"]);

                    model.Lessee_Licensee_Name = Convert.ToString(dt.Rows[0]["LesseeName"]);
                    model.Remarks2 = Convert.ToString(dt.Rows[0]["Remarks"]);
                    model.Hindi_UnitName = Convert.ToString(dt.Rows[0]["Hindi_UnitName"]);
                    model.IsTailingDamLicensee = Convert.ToString(dt.Rows[0]["IsTailingDamLicensee"]);
                    if (!(dt.Rows[0]["RePrintCount"] is DBNull))
                        model.RePrintCount = Convert.ToString(dt.Rows[0]["RePrintCount"]);

                    if (dt.Columns.Contains("SystemDateTime"))
                    {
                        model.SystemDateTime = Convert.ToDateTime(dt.Rows[0]["SystemDateTime"]);
                    }
                    else
                    {
                        model.SystemDateTime = System.DateTime.Now;
                    }

                   
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                model = null;
            }
        }

        /// <summary>
        /// Added by suroj on 29-jul-2021 to fetch RTP Application no whose transportmode is inside railways and road-rail
        /// </summary>
        /// <param name="objtran"></param>
        /// <returns></returns>

        public async Task<List<TransitPassModel>> GetForwardingNote(TransitPassModel objtran)
        {
            List<TransitPassModel> objList = new List<TransitPassModel>();

            DynamicParameters param = null;
           
            try
            {

                var paramList = new
                {
                    BulkPermitID = objtran.BulkPermitId,
                    PurchaserConsigneeId =objtran.PurchaserConsigneeId,
                   
                    UserID = objtran.userid
                };
                param = new DynamicParameters();
                var result = await Connection.ExecuteReaderAsync ("GetForwardingNoteForBulkPermit", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TransitPassModel obj = new TransitPassModel();

                        obj.ForwardingNoteID = Convert.ToInt32(dt.Rows[i]["ForwardingNoteId"]);
                        obj.ForwardingNoteNo = Convert.ToString(dt.Rows[i]["ForwardingNote"]);
                        obj.NoteQty = Convert.ToString(dt.Rows[i]["PendingQty"]);
                        objList.Add(obj);
                    }
                }
                return objList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objList = null;
            }
        }



        /// <summary>
        /// Added by Suroj on 02-Aug-2021 to generate print Railway Transit  Pass
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>
        public TransitPassModel RailTPDataFetch(TransitPassModel model)
        {
            DynamicParameters param = null;

            try
            {

                var paramList = new
                {
                    TransitPassId = model.TransitPassId,
                    Check=1,
                    UserId = model.userid
                };
                param = new DynamicParameters();
                var result = Connection.ExecuteReader("uspTPOpetarion", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    model.TransporterName = Convert.ToString(dt.Rows[0]["TransporterName"]);
                    model.TransporterMobile = Convert.ToString(dt.Rows[0]["TransporterMobile"]);
                    model.TransporterCHiMMSNo = Convert.ToString(dt.Rows[0]["TransporterCHiMMSNo"]);

                    model.BulkPermitNo = Convert.ToString(dt.Rows[0]["BulkPermitNo"]);
                    model.SchemeofCoal = Convert.ToString(dt.Rows[0]["TypeOfCoalDispatched"]);
                    model.PurchaserConsigneeName = Convert.ToString(dt.Rows[0]["EndUserName"]);

                    model.MineralGradeName = Convert.ToString(dt.Rows[0]["MineralGrade"]);
                    model.MineralNature = Convert.ToString(dt.Rows[0]["MineralNature"]);


                    model.UnitName = Convert.ToString(dt.Rows[0]["UnitName"]);

                    model.DONumber = Convert.ToString(dt.Rows[0]["DONumber"]);
                    model.DODate = Convert.ToString(dt.Rows[0]["DODate"]);


                    model.TransportationMode = Convert.ToString(dt.Rows[0]["TransportationMode"]);
                    model.IssueDateTime = Convert.ToDateTime(dt.Rows[0]["DateOfDispatche"]).ToString("dd/MM/yyyy hh:mm:ss tt");
                    model.TareWeight_Qty = Convert.ToDecimal(dt.Rows[0]["TareWeight"]);
                    model.GrossWeight_Qty = Convert.ToDecimal(dt.Rows[0]["GrossWeight"]);
                    model.NetWeight_Qty = Convert.ToDecimal(dt.Rows[0]["NetWeight"]);
                    model.Mineral_SaleValue = Convert.ToDecimal(dt.Rows[0]["AverageSalePrice"]);
                    model.VehicleNumber = Convert.ToString(dt.Rows[0]["VehicleNumber"]);

                    model.VehicleCHiMMSNo = Convert.ToString(dt.Rows[0]["VehicleCHiMMSNo"]);

                    model.DriverName = Convert.ToString(dt.Rows[0]["DriverName"]);
                    model.MineralName = Convert.ToString(dt.Rows[0]["MineralName"]);

                    model.VehicleTypeName = Convert.ToString(dt.Rows[0]["VehicleTypeName"]);
                    model.RouteName = Convert.ToString(dt.Rows[0]["RouteName"]);
                    model.Mineral_Destination = Convert.ToString(dt.Rows[0]["Destination"]);
                    model.TransitPassNumber = Convert.ToString(dt.Rows[0]["TransitPassNo"]);
                    model.TransitPassId = Convert.ToInt32(dt.Rows[0]["TransitPassID"]);
                    model.DistrictName = Convert.ToString(dt.Rows[0]["DistrictName"]);
                    model.VillageName = Convert.ToString(dt.Rows[0]["VillageName"]);
                    model.TehsilName = Convert.ToString(dt.Rows[0]["TehsilName"]);
                    //model. = Convert.ToDecimal(dt.Rows[0]["AreaDetails"]);
                    model.Area = Convert.ToDecimal(dt.Rows[0]["AreaHect"]);
                    model.LeaseFromDate = Convert.ToString(dt.Rows[0]["LeaseFrom"]);
                    model.LeaseToDate = Convert.ToString(dt.Rows[0]["LeaseTo"]);

                    model.LeaseValidity = Convert.ToString(dt.Rows[0]["Validity"]);

                    model.Lessee_Licensee_Name = Convert.ToString(dt.Rows[0]["LesseeName"]);

                    model.ForwardingNoteNo = Convert.ToString(dt.Rows[0]["ForwardingNoteIdTransaction"]);

                    model.RailwayId = Convert.ToInt32(dt.Rows[0]["IsTPOffline"]);

                    model.Hindi_UnitName = Convert.ToString(dt.Rows[0]["Hindi_UnitName"]);
                    model.Remarks = Convert.ToString(dt.Rows[0]["Remarks"]);
                    model.IsTailingDamLicensee = Convert.ToString(dt.Rows[0]["IsTailingDamLicensee"]);
                    if (!(dt.Rows[0]["RePrintCount"] is DBNull))
                        model.RePrintCount = Convert.ToString(dt.Rows[0]["RePrintCount"]);
                    if (dt.Columns.Contains("SystemDateTime"))
                    {
                        model.SystemDateTime = Convert.ToDateTime(dt.Rows[0]["SystemDateTime"]);
                    }
                    else
                    {
                        model.SystemDateTime = System.DateTime.Now;
                    }
                   
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                model = null;
            }
        }
        /// <summary>
        /// Added by suroj on 03-aug-2021 to bind Epermit No in Mineral recieve page
        /// </summary>
        /// <param name="objtran"></param>
        /// <returns></returns>

        public async Task<List<EndUser_ETransitPassModel>> BindReceivePermit(EndUser_ETransitPassModel objtran)
        {
            List<EndUser_ETransitPassModel> objList = new List<EndUser_ETransitPassModel>();

            DynamicParameters param = null;

            try
            {

                var paramList = new
                {
                    check = "6",
                    ProfileUserId = objtran.userid
                };
                param = new DynamicParameters();
                var result = await Connection.ExecuteReaderAsync("uspEndUser", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        EndUser_ETransitPassModel obj = new EndUser_ETransitPassModel();
                        obj.VehicleId = Convert.ToInt32(dt.Rows[i]["Vehicleid"]);
                        obj.VehicleNumber = Convert.ToString(dt.Rows[i]["VehicleNumber"]);
                        obj.OfflineTp = Convert.ToString(dt.Rows[i]["IsTPOffline"]);
                        obj.OfflineFlag = Convert.ToString(dt.Rows[i]["IsTPOfflineFlag"]);
                        objList.Add(obj);
                    }
                }
                return objList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objList = null;
            }
        }

        /// <summary>
        /// Added by suroj on 04-Aug-2021 to fill Mineral Details on Permit No Change Event.
        /// </summary>
        /// <param name="objtran"></param>
        /// <returns></returns>
        public async Task<List<EndUser_ETransitPassModel>> GetGridData(EndUser_ETransitPassModel objtran)
        {
            List<EndUser_ETransitPassModel> List = new List<EndUser_ETransitPassModel>();

            DynamicParameters param = null;
            int MineralGradeId = 0;int MineralNatureId = 0;int userid = 0;
            decimal TotalStock = 0;
            decimal EcQuantity = 0;
            userid = (int)objtran.userid;
            try
            {

                var paramList = new
                {
                    check = "4",
                    ProfileUserId = objtran.userid,
                    TransitPassNo=objtran.TransitPassNo
                };
                param = new DynamicParameters();
                var result = await Connection.ExecuteReaderAsync("uspEndUser", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        EndUser_ETransitPassModel model = new EndUser_ETransitPassModel();

                        if (dt.Columns.Contains("StatusMsg") == true)
                        {
                            model.TransitPassID = 0;
                            model.TransitPass_Type = Convert.ToString(dt.Rows[i]["StatusMsg"]);
                        }
                        else
                        {
                            model.TotalReceivedQuantity = Convert.ToDecimal(dt.Rows[i]["TotalReceivedQuantity"]);
                            model.TotalECApprovedQuantity = Convert.ToDecimal(dt.Rows[i]["ECApprovedQuantity"]);
                            model.EcQuantity = Convert.ToDecimal(dt.Rows[i]["ECApprovedQuantity"]);

                            model.TransitPassID = Convert.ToInt32(dt.Rows[i]["TransitPassID"]);
                            model.TransitPassNo = Convert.ToString(dt.Rows[i]["TransitPassNo"]);
                            model.TransportationMode = Convert.ToString(dt.Rows[i]["TransportationMode"]);
                            model.TransportationModeId = Convert.ToInt32(dt.Rows[i]["TransportationModeId"]);
                            model.BulkPermitID = Convert.ToInt32(dt.Rows[i]["BulkPermitID"]);
                            model.BulkPermitNo = Convert.ToString(dt.Rows[i]["BulkPermitNo"]);
                            model.MineralId = Convert.ToInt32(dt.Rows[i]["MineralId"]);
                            model.MineralName = Convert.ToString(dt.Rows[i]["MineralName"]);
                            model.MineralGradeId = Convert.ToInt32(dt.Rows[i]["MineralGradeId"]);
                            model.MineralGradeName = Convert.ToString(dt.Rows[i]["MineralGrade"]);
                            model.LesseeId = Convert.ToInt32(dt.Rows[i]["SenderId"]);
                            model.LesseeName = Convert.ToString(dt.Rows[i]["SenderName"]);
                            model.VehicleId = Convert.ToInt32(dt.Rows[i]["VehicleId"]);
                            model.VehicleNumber = Convert.ToString(dt.Rows[i]["VehicleNumber"]);
                            model.VehicleTypeId = Convert.ToInt32(dt.Rows[i]["VehicleTypeId"]);
                            model.VehicleTypeName = Convert.ToString(dt.Rows[i]["VehicleTypeName"]);
                            model.DateOfDispatche = Convert.ToDateTime(dt.Rows[i]["DateOfDispatche"]);
                            model.DriverName = Convert.ToString(dt.Rows[i]["DriverName"]);
                            model.TareWeight = Convert.ToDecimal(dt.Rows[i]["TareWeight"]);
                            model.TareTime = Convert.ToDateTime(dt.Rows[i]["TareTime"]);
                            model.GrossWeight = Convert.ToDecimal(dt.Rows[i]["GrossWeight"]);
                            model.GrossTime = Convert.ToDateTime(dt.Rows[i]["GrosdTime"]);
                            model.NetWeight = Convert.ToDecimal(dt.Rows[i]["NetWeight"]);
                            model.ReceivedWeight = Convert.ToDecimal(dt.Rows[i]["ReceivedWeight"]);
                            model.PurchaserConsigneeName = Convert.ToString(dt.Rows[i]["ReceiverName"]);
                            model.TripStatus = Convert.ToInt32(dt.Rows[i]["TripStatus"]);
                            model.MineralSaleValue = Convert.ToString(dt.Rows[i]["MineralSaleValue"]);
                            model.TransporterName = Convert.ToString(dt.Rows[i]["TransporterName"]);
                            model.RouteName = Convert.ToString(dt.Rows[i]["RouteName"]);
                            model.Destination = Convert.ToString(dt.Rows[i]["Destination"]);

                            model.Address = Convert.ToString(dt.Rows[i]["Address"]);
                            model.Date_OF_Dispatche = Convert.ToString(dt.Rows[i]["DateOfDispatche"]);
                            model.TransitPass_Type = Convert.ToString(dt.Rows[i]["Type"]);

                            model.DONumber = Convert.ToString(dt.Rows[i]["DONumber"]);
                            model.DODate = Convert.ToString(dt.Rows[i]["DODate"]);
                            model.UnitName = Convert.ToString(dt.Rows[i]["UnitName"]);
                            model.TypeOfCoalDispatched = Convert.ToString(dt.Rows[i]["TypeOfCoalDispatched"]);
                            MineralNatureId = Convert.ToInt32(dt.Rows[i]["MineralNatureId"]);
                            MineralGradeId = Convert.ToInt32(dt.Rows[i]["MineralGradeId"]);
                        }

                        List.Add(model);
                    }
                }
                else
                {
                    EndUser_ETransitPassModel model = new EndUser_ETransitPassModel();
                    model.TransitPassID = 0;
                    model.TransitPass_Type = "No Information Found for this Vehicle";
                    List.Add(model);
                }
                try
                {
                    var paramList1 = new
                    {
                        MineralGradeId = MineralGradeId,
                        Check = "3",
                        UserID = userid
                    };
                    param = new DynamicParameters();
                    var result1 = Connection.ExecuteReader("upsGetMineralByUserID", paramList1, commandType: System.Data.CommandType.StoredProcedure);
                    DataTable dt1 = new DataTable();
                    dt1.Load(result1);
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        TotalStock = Convert.ToDecimal(dt1.Rows[0]["TotalStock"]);
                        EcQuantity = Convert.ToDecimal(dt1.Rows[0]["EcQuantity"]);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }

                var ListPart = List.Select(x => new EndUser_ETransitPassModel
                {
                    
                    TransitPassID = x.TransitPassID,
                    TransitPassNo = x.TransitPassNo,
                    TransportationModeId = x.TransportationModeId,
                    TransportationMode = x.TransportationMode,
                    BulkPermitID = x.BulkPermitID,
                    BulkPermitNo = x.BulkPermitNo,
                    MineralId = x.MineralId,
                    MineralName = x.MineralName,
                    MineralGradeId = x.MineralGradeId,
                    MineralGradeName = x.MineralGradeName,
                    LesseeId = x.LesseeId,
                    LesseeName = x.LesseeName,
                    VehicleTypeId = x.VehicleTypeId,
                    VehicleNumber = x.VehicleNumber,
                    VehicleTypeName = x.VehicleTypeName,
                    Date_OF_Dispatche = x.Date_OF_Dispatche,
                    DriverName = x.DriverName,
                    TareWeight = x.TareWeight,
                    TareTime = x.TareTime,
                    GrossWeight = x.GrossWeight,
                    GrossTime = x.GrossTime,
                    NetWeight = x.NetWeight,
                    ReceivedWeight = x.ReceivedWeight,
                    PurchaserConsigneeName = x.PurchaserConsigneeName,
                    TripStatus = x.TripStatus,
                    MineralSaleValue = x.MineralSaleValue,
                    TransporterName = x.TransporterName,
                    RouteName = x.RouteName,
                    Destination = x.Destination,
                    Address = x.Address,
                    
                    TransitPass_Type = x.TransitPass_Type,
                    DONumber = x.DONumber,
                    DODate = x.DODate,
                    UnitName = x.UnitName,
                    TypeOfCoalDispatched = x.TypeOfCoalDispatched,
                    TotalReceivedQuantity = TotalStock,
                    EcQuantity = EcQuantity
                }).ToList();


                return ListPart;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
               
            }
        }



        /// <summary>
        /// Added by suroj on 07-aug-2021 to update Mineral Recieve 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> UpdateMineralReceipt(EndUser_ETransitPassModel model)
        {
            string OutputResult = string.Empty;
            try
            {
                
                Int64 TPID = 0;
                string Response = "";
                string procedure = string.Empty;
                string purchaseconsignee = string.Empty;
                var p = new DynamicParameters();

                p.Add("@TransitPassID", model.TransitPassID);
                p.Add("@ReceivedWeight", model.ReceivedWeight);

                p.Add("@WashedCoal", model.WashedCoal);
                p.Add("@RejectedCoal", model.RejectedCoal);
                p.Add("@TransitPass_Type", model.TransitPass_Type);
                p.Add("@Remarks", model.Remarks);
                p.Add("@TypeOfCoalDispatched", model.TypeOfCoalDispatched);
                p.Add("@UpdatedBy", model.userid);
                p.Add("@ReceivedBy", model.userid);
                p.Add("@result", dbType: DbType.Int64, direction: ParameterDirection.Output);


                Response =await Connection.ExecuteScalarAsync<string>("uspReceiveMineralReceiptDetails", p, commandType: System.Data.CommandType.StoredProcedure);
                int result = p.Get<int>("result");
                if (result == 1)
                {
                    return OutputResult = "1";

                }
                else
                {
                    return OutputResult = "2";
                }
            }
            catch (Exception ex)
            {
                return OutputResult = "3";
            }
            
        }
        /// <summary>
        /// Added by suroj on 17-aug-2021 to Add Recieve mineral
        /// </summary>
        /// <param name="objtran"></param>
        /// <returns></returns>


        public async Task<List<EndUser_ETransitPassModel>> MineralReceiveData(EndUser_ETransitPassModel objtran)
        {
            List<EndUser_ETransitPassModel> list = new List<EndUser_ETransitPassModel>();

            DynamicParameters param = null;

            try
            {

                var paramList = new
                {
                    SP_MODE = "GET_FORCE_DATA_LICENSEE",
                    USER_ID = objtran.userid,
                    
                };
                param = new DynamicParameters();
                var result = await Connection.ExecuteReaderAsync("LESSEE_REGISTRATION_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var ds = ConvertDataReaderToDataSet(result);
               
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        

                        if (!(dt.Rows[0]["MineralIdList"] is DBNull) )
                        {
                            var str = (dt.Rows[0]["MineralIdList"].ToString()).Replace("[", "").Replace("]", "");
                            string[] array = str.Split(',');
                            var strName = dt.Rows[0]["MineralNameList"].ToString();
                            string[] NameArray = strName.Split(',');

                           

                            for (int j = 0; j < array.Count(); j++)
                            {
                                if (!string.IsNullOrEmpty(array[j]))
                                {
                                    EndUser_ETransitPassModel m = new EndUser_ETransitPassModel();
                                    m.MineralId = Convert.ToInt32(array[j]);
                                    m.MineralName = NameArray[j];
                                   
                                    if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                                    {
                                        m.EcQuantity = Convert.ToDecimal(ds.Tables[2].Rows[j]["ECQuantity"]);
                                        
                                    }
                                    else
                                    {
                                        m.EcQuantity = Convert.ToDecimal(0);
                                        
                                    }
                                    list.Add(m);
                                }
                            }
                            //data.QuantityList = list;
                        }

                        //List.Add(model);
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
            }
        }

        /// <summary>
        /// Added by suroj kumar pradhan on 23-aug-2021 to bind Permit No in RPTP
        /// </summary>
        /// <returns></returns>
        public async Task<List<RPTPModel>> GetApprovedBulkPermitListRPTP(RPTPModel objmodel)
        {
            List<RPTPModel> LtPermit = new List<RPTPModel>();
            try
            {
                var paramList = new
                {
                    UserID = objmodel.UserId,
                    
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.ExecuteReaderAsync("GetBulkPermitDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RPTPModel obj = new RPTPModel();

                        obj.BulkPermitId = Convert.ToString(dt.Rows[i]["RPTPBulkPermitId"]);
                        obj.BulkPermitNo = Convert.ToString(dt.Rows[i]["BulkPermitNo"]);

                        LtPermit.Add(obj);
                    }
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

        public DataTable getBulkPermitMasterDataByBulkPermitId(int? id, int? userid, int PCID = 0 )
        {
            var paramList = new
            {
                BulkPermitId = id,
                PCID=PCID,
                UserId= userid,
                Check=5
            };
            DynamicParameters param = new DynamicParameters();
            var result = Connection.ExecuteReader("uspGetBulkPermitMasterDataByBulkPermitId", paramList, commandType: System.Data.CommandType.StoredProcedure);
            
            DataTable dt = new DataTable();
            dt.Load(result);
            return dt;
        }
        /// <summary>
        /// Added by suroj on 24-Aug-2021 to fetch details against permitNO RPTP
        /// </summary>
        /// <param name="objRPTP"></param>
        /// <returns></returns>

        public RPTPModel GetDataByBulkPermitId(RPTPModel objRPTP)
        {
            List<TransitPassModel> LtPermit = new List<TransitPassModel>();
            try
            {
                var paramList = new
                {
                    UserID = objRPTP.UserId,
                    
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.ExecuteReader("uspGetLicenseeArea_InformationByUserId", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                DataTable data=getBulkPermitMasterDataByBulkPermitId(Convert.ToInt16(objRPTP.BulkPermitId), objRPTP.UserId, 0 );
                if (dt != null && dt.Rows.Count > 0)
                {
                            objRPTP.Address = dt.Rows[0]["Address"].ToString();
                       
                        foreach (DataRow i in data.Rows)
                        {
                            objRPTP.MineralName = i["MineralName"].ToString();
                            objRPTP.MineralGrade = i["MineralGrade"].ToString();
                            objRPTP.MineralGradeId = Convert.ToInt16(i["MineralGradeId"]);
                            objRPTP.ApprovedQty = Convert.ToInt16(i["ApprovedQty"]);
                            objRPTP.MineralTypeName = i["MineralType"].ToString();
                            objRPTP.MineralTypeId = Convert.ToInt16(i["MineralTypeId"]);
                            objRPTP.MineralSaleValue = Convert.ToDecimal(i["AverageSalePrice"]);
                            objRPTP.Remaining_Qty = Convert.ToDecimal(i["RemainingQty"]);
                            objRPTP.PurchaserConsigneeId = Convert.ToInt32(i["PurchaserConsigneeId"]);
                            objRPTP.PurchaserConsigneeName = Convert.ToString(i["PurchaserConsigneeName"]);

                        }
                     
                   
                }
                return objRPTP;
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

        /// <summary>
        /// Added by suroj on 08-jul-2021 to bind Purchase/Consignee in eTransit Pass RPTP
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        public async Task<List<RPTPModel>> GetCascadePurchaserConsigneeRPTP(RPTPModel objRPTP)
        {
            List<RPTPModel> LtPermit = new List<RPTPModel>();
            try
            {
                DataTable data = getBulkPermitMasterDataByBulkPermitId(Convert.ToInt16(objRPTP.BulkPermitId), objRPTP.UserId, 0);
               // DataTable dt = new DataTable();
                //dt.Load(result);
                if (data != null && data.Rows.Count > 0)
                {
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(data.Rows[i]["PurchaserConsigneeName"])))
                        {
                            RPTPModel obj = new RPTPModel();
                            obj.PurchaserConsigneeId = Convert.ToInt32(data.Rows[i]["PurchaserConsigneeId"]);
                            obj.PurchaserConsigneeName = Convert.ToString(data.Rows[i]["PurchaserConsigneeName"]) + "(" + Convert.ToString(data.Rows[i]["TransportationMode"]) + ")";
                            obj.TransportationMode = Convert.ToString(data.Rows[i]["TransportationMode"]);
                            LtPermit.Add(obj);
                        }
                    }
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
        /// <summary>
        /// Added by suroj on 08-jul-2021 to Get destination Against Purchase consignee ID RPTP
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>

        public RPTPModel GetDataByPurchaserConsigneeIdRPTP(RPTPModel objTP)
        {

            DynamicParameters param = null;
            try
            {

                var paramList = new
                {
                    BulkPermitId = objTP.BulkPermitId,
                    PCID = objTP.PurchaserConsigneeId,
                    UserID = objTP.UserId
                };
                param = new DynamicParameters();
                var result = Connection.ExecuteReader("uspGetDataByPurchaseConsigneeId", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    try
                    {
                        if (!(dt.Rows[0]["Route"] is DBNull))
                            objTP.Route = Convert.ToInt32(dt.Rows[0]["Route"].ToString());

                        if (!(dt.Rows[0]["TransportationModeId"] is DBNull))
                            objTP.ModeOfTransportationId = Convert.ToInt32(dt.Rows[0]["TransportationModeId"].ToString());

                        objTP.RouteName = dt.Rows[0]["RouteName"].ToString();
                        objTP.TransportationModeName = dt.Rows[0]["TransportationMode"].ToString();
                        objTP.Destination = dt.Rows[0]["Destination"].ToString();
                        objTP.Mineral_PurchaserName = dt.Rows[0]["ApplicantName"].ToString();
                    }
                    catch (Exception)
                    {

                    }
                }
                return objTP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTP = null;
            }
        }
        /// <summary>
        /// Added by suroj on 25-aug-2021 to add RPTP details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnOuputResultRPTP AddData(RPTPModel model)
        {
            ReturnOuputResultRPTP outputResult = new ReturnOuputResultRPTP();
            try
            {

                Int64 TPID = 0;
                string Response = "";
                string procedure = string.Empty;
                string purchaseconsignee = string.Empty;
                var p = new DynamicParameters();
                p.Add("@chk", 2);
                p.Add("@RoyaltyPaidTransitPassId", model.RoyaltyPaidTransitPassId);
                p.Add("@BulkPermitId ", model.BulkPermitId);
                p.Add("@MineralGradeId", model.MineralGradeId);
                p.Add("@PurchaserConsigneeId", model.PurchaserConsigneeId);
                p.Add("@UserId", model.UserId);
                p.Add("@MineralTypeId", model.MineralTypeId);
                p.Add("@DateOfDispatche", model.DateOfDispatche);
                p.Add("@ModeOfTransportationId", model.ModeOfTransportationId);
                p.Add("@CarrierOwnerId ", model.TransporterId);
                p.Add("@CarrierNo", model.VehicleId);
                p.Add("@NameOfCarrierDriver", model.NameOfCarrierDriver);
                p.Add("@DriverContactNumber", model.DriverContactNumber);
                p.Add("@TareWeight", model.TareWeight);

                if (model.GrossWeight != null && model.GrossWeight > 0)
                    p.Add("@GrossWeight", model.GrossWeight);
                else
                    p.Add("@GrossWeight", model.TotalQty);

                if (model.NetWeight != null && model.NetWeight > 0)
                    p.Add("@NetWeight", model.NetWeight);
                else
                    p.Add("@NetWeight", model.TotalQty);

                p.Add("@MineralSaleValue", model.MineralSaleValue);
                p.Add("@ParticularsOfLicense", model.ParticularOfLicensee);
                p.Add("@AddressOfLicenseHolder", model.Address);
                p.Add("@Remark", model.Remark);
                p.Add("@RailwayId", model.RailwayId);
                p.Add("@RTPQty", model.RailQty);
                p.Add("@AddressofRailwaySliding", model.AddressofRailwaySliding);
                p.Add("@IsTPOffline", model.Tpoffline);
                p.Add("@SubUserId", model.UserId);
                p.Add("@AddedBy", model.UserId);
                p.Add("@UserLoginId", model.UserId);
               
                p.Add("@Destination", model.Destination);
               
                p.Add("@Minor_PurchaserConsignee", model.Mineral_PurchaserName);
                if (model.PurchaserType == "Un-registered")
                {
                    p.Add("@ForwardingNoteId", null);
                    if (!string.IsNullOrEmpty(model.UnRegistredWithoutTractorVehicleOwner))
                    {
                        p.Add("@Minor_VehicleOwner", model.UnRegistredWithoutTractorVehicleOwner);
                    }
                    else
                    {
                        p.Add("@Minor_VehicleType", "Tractor");
                        p.Add("@Minor_VehicleNumber", model.UnRegistredWithTractorVehicleId);
                        p.Add("@Minor_VehicleOwner", model.UnRegistredWithTractorVehicleOwner);
                    }
                }
                else
                {
                    p.Add("@ForwardingNoteId", model.ForwardingNoteID);
                    p.Add("@Minor_VehicleType", model.Minor_VehicleType);
                    p.Add("@Minor_VehicleNumber", model.Minor_VehicleNumber);
                    p.Add("@Minor_VehicleOwner", model.Minor_VehicleOwner);
                }

                //p.Add("@PurchaserType", model.PurchaserType);
                //p.Add("@PurchaserSubType", model.PurchaserSubType);
                //p.Add("@PurchaserName", model.PurchaserConsigneeName);
                //p.Add("@PurchaserContactNumber", model.PurchaserContactNumber);
                //p.Add("@UnRegistredVehicleTypeId", model.UnRegistredVehicleTypeId);
                //p.Add("@UnRegistredWithoutTractorVehicleId", model.UnRegistredWithoutTractorVehicleId);
                //p.Add("@UnRegistredWithoutTractorVehicleOwner", model.UnRegistredWithoutTractorVehicleOwner);
                //p.Add("@UnRegistredWithTractorNumber", model.UnRegistredWithTractorVehicleId);
                //p.Add("@UnRegistredWithTractorVehicleOwner", model.UnRegistredWithTractorVehicleOwner);
                //p.Add("@DistrictId", model.DistrictId);
                //p.Add("@DestinationBlock", model.DestinationBlock);
                
                p.Add("@ReturnIdentity", SqlDbType.VarChar, direction: ParameterDirection.Output);


                Response = Connection.ExecuteScalar<string>("uspRTPTOperation", p, commandType: System.Data.CommandType.StoredProcedure);
                int result = p.Get<int>("ReturnIdentity");
                if (result!=0)
                {
                    outputResult.OutputResult = "1";
                    outputResult.RPTPID = result;
                   
                }
                else
                {
                    outputResult.OutputResult = "3";
                    outputResult.RPTPID = result;
                    
                }
            }
            catch (Exception ex)
            {
                outputResult.OutputResult = "3";
                outputResult.RPTPID = 0;
            }
            return outputResult;
        }
        /// <summary>
        /// Added by suroj on 26-08-21 to print RPTP
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RPTPModel getRecordForReport(RPTPModel model)
        {
            List<TransitPassModel> LtPermit = new List<TransitPassModel>();
            try
            {
                var paramList = new
                {
                    Id = model.RoyaltyPaidTransitPassId,
                    chk=1,
                    UserId= model.UserId

                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.ExecuteReader("uspRTPTOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                //DataTable data = getBulkPermitMasterDataByBulkPermitId(Convert.ToInt16(objRPTP.BulkPermitId), objRPTP.UserId, 0);
                try
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model.NameOfCarrierOwner = Convert.ToString(dt.Rows[0]["TransporterName"]);
                        model.VehicleType = Convert.ToString(dt.Rows[0]["VehicleTypeName"]);
                        //if (!(dt.Rows[0]["VehicleId"] is DBNull))
                        //{
                        //    model.VehicleId = Convert.ToInt32(dt.Rows[0]["VehicleId"]);
                        //}
                        model.VehicleCHiMMSNo = Convert.ToString(dt.Rows[0]["VehicleId"]);
                        if (!(dt.Rows[0]["RailwayId"] is DBNull))
                        {
                            model.RailwayId = Convert.ToInt32(dt.Rows[0]["RailwayId"]);
                            model.AddressofRailwaySliding = Convert.ToString(dt.Rows[0]["AddressofRailwaySliding"]);
                            model.RailQty = Convert.ToDecimal(dt.Rows[0]["RTPQty"]);
                            model.NameofRailwaySlidingName = Convert.ToString(dt.Rows[0]["RailwaySlidingName"]);
                            model.RailwayZoneName = Convert.ToString(dt.Rows[0]["RailwayZoneName"]);
                        }
                        model.UnitName = Convert.ToString(dt.Rows[0]["UnitName"]);
                        model.BulkPermitNo = Convert.ToString(dt.Rows[0]["BulkPermitNo"]);
                        model.PurchaserConsigneeName = Convert.ToString(dt.Rows[0]["EndUserName"]);
                        model.MineralGrade = Convert.ToString(dt.Rows[0]["MineralGrade"]);
                        model.TransportationMode = Convert.ToString(dt.Rows[0]["TransportationMode"]);
                        model.IssueDateTimeTp = Convert.ToDateTime(dt.Rows[0]["DateOfDispatche"]).ToString("dd/MM/yyyy hh:mm:ss tt");
                        model.TareWeight = Convert.ToDecimal(dt.Rows[0]["TareWeight"]);
                        model.GrossWeight = Convert.ToDecimal(dt.Rows[0]["GrossWeight"]);
                        model.NetWeight = Convert.ToDecimal(dt.Rows[0]["NetWeight"]);
                        model.MineralSaleValue = Convert.ToDecimal(dt.Rows[0]["MineralSaleValue"]);
                        model.VehicleNumber = Convert.ToString(dt.Rows[0]["VehicleNumber"]);
                        model.NameOfCarrierDriver = Convert.ToString(dt.Rows[0]["NameOfCarrierDriver"]);
                        model.MineralName = Convert.ToString(dt.Rows[0]["MineralName"]);
                        model.AddressOfLicenseHolder = Convert.ToString(dt.Rows[0]["AddressOfLicenseHolder"]);
                        model.ParticularOfLicensee = Convert.ToString(dt.Rows[0]["ParticularsOfLicense"]);
                        model.RouteName = Convert.ToString(dt.Rows[0]["Route"]);
                        model.Destination = Convert.ToString(dt.Rows[0]["Destination"]);
                        model.RoyaltyPaidTransitPassNo = Convert.ToString(dt.Rows[0]["RoyaltyPaidTransitPassNo"]);
                        model.RoyaltyPaidTransitPassId = Convert.ToInt32(dt.Rows[0]["RoyaltyPaidTransitPassId"]);
                        model.DistrictName = Convert.ToString(dt.Rows[0]["DistrictName"]);
                        model.VillageName = Convert.ToString(dt.Rows[0]["VillageName"]);
                        model.TehsilName = Convert.ToString(dt.Rows[0]["TehsilName"]);
                        model.ApplicantName = Convert.ToString(dt.Rows[0]["ApplicantName"]);
                        model.DateOfDispatcheString = Convert.ToString(dt.Rows[0]["Storage_DateOfDispatche"]);
                        model.RePrintCount = Convert.ToString(dt.Rows[0]["RePrintCount"]);
                        model.MineralTypeName = Convert.ToString(dt.Rows[0]["MineralType"]);
                        if (!(dt.Rows[0]["MineralSaleValue"] is DBNull))
                        {
                            model.MineralSaleValue = Convert.ToDecimal(dt.Rows[0]["MineralSaleValue"]);
                        }
                        else
                        {
                            model.MineralSaleValue = 0;
                        }

                        if (dt.Columns.Contains("SystemDateTime"))
                        {
                            model.SystemDateTime = Convert.ToDateTime(dt.Rows[0]["SystemDateTime"]);
                        }
                        else
                        {
                            model.SystemDateTime = System.DateTime.Now;
                        }

                        //return View(model);
                    }
                    else
                    {
                        //model.mes
                        //ViewData["Message"] = "Report Data Not Found";
                        //return RedirectToAction("RPTP", new { id = 0 });
                    }
                }
                catch (Exception)
                {
                    ///return RedirectToAction("RPTP", new { id = 0 });
                }
                return model;
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

        public async Task<ReturnOuputResult> AddUserWiseTPConfiguration(UserWiseTPConfigurationViewModel model)
        {
            ReturnOuputResult outputResult = new ReturnOuputResult();
            Int64 ID = 0;
            string Response = "";
            string procedure = string.Empty;
            var p = new DynamicParameters();
            procedure = "InsertUpdateUserwiseTripconfigmaster";
            p.Add("@ID", model.ID);
            p.Add("@DistrictID", model.DistrictID);
            p.Add("@UserTypeID", model.UserTypeID);
            p.Add("@UserID", model.UserID);
            p.Add("@TransportationModeID", model.TransportationModeID);
            p.Add("@WBIntegration", model.IntigrationWithWB);
            p.Add("@CheckStampingValidity", model.CheckStampingValidity);
            p.Add("@GenerationMode", model.eTPGenrationMode);
            p.Add("@CreatedBy", model.CreatedBy);
            p.Add("@Chk", model.Chk);
            p.Add("@ReturnIdentity", dbType: DbType.Int64, direction: ParameterDirection.Output);
            Response = await Connection.ExecuteScalarAsync<string>(procedure, p, commandType: System.Data.CommandType.StoredProcedure);
            ID = p.Get<Int64>("ReturnIdentity");
            if (ID > 0)
            {
                outputResult.OutputResult = "1";
                outputResult.TPID = ID;
            }
            else
            {
                outputResult.OutputResult = "3";
                outputResult.TPID = 0;

            }
            return outputResult;
        }
        public async Task<List<UserWiseTPConfigurationModel>> ListUserWiseTPConfiguration(UserWiseTPConfigurationModel model)
        {
            List<UserWiseTPConfigurationModel> outputResult = new List<UserWiseTPConfigurationModel>();
            var p = new DynamicParameters();
           
            p.Add("@ID", model.ID);

            
            var Output = await Connection.QueryAsync<UserWiseTPConfigurationModel>("GetUserwiseTripconfigmaster", p, commandType: CommandType.StoredProcedure);
            if (Output.Count() > 0)
            {

                outputResult = Output.ToList();
            }
            return outputResult;
        }
    }
}
