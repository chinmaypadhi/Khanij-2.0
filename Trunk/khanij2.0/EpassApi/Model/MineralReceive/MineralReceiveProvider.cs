using Dapper;
using EpassApi.Factory;
using EpassApi.Repository;
using EpassEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Model.MineralReceive
{
    public class MineralReceiveProvider : RepositoryBase, IMineralReceiveProvider
    {
   
        public MineralReceiveProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

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


                        if (!(dt.Rows[0]["MineralIdList"] is DBNull))
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

        public async Task<List<EndUser_ETransitPassModel>> GetGridData(EndUser_ETransitPassModel objtran)
        {
            List<EndUser_ETransitPassModel> List = new List<EndUser_ETransitPassModel>();

            DynamicParameters param = null;
            int MineralGradeId = 0; int MineralNatureId = 0; int userid = 0;
            decimal TotalStock = 0;
            decimal EcQuantity = 0;
            userid = (int)objtran.userid;
            try
            {

                var paramList = new
                {
                    check = "4",
                    ProfileUserId = objtran.userid,
                    TransitPassNo = objtran.TransitPassNo
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
                p.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                //update start Shyam sir 16-3-22
                // p.Add("@result", dbType: DbType.Int64, direction: ParameterDirection.Output);
                //update end Shyam sir 16-3-22
                Response = await Connection.ExecuteScalarAsync<string>("uspReceiveMineralReceiptDetails", p, commandType: System.Data.CommandType.StoredProcedure);
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

        public async Task<List<EndUser_ETransitPassModel>> GetClosedGridData(MineralReceiveModel objtran)
        {
            List<EndUser_ETransitPassModel> List = new List<EndUser_ETransitPassModel>();
            try
            {
                var paramList = new
                {
                    UserId = objtran.userid,
                    TripsStatus = objtran.Trips_Status,
                    FromDate = objtran.fdate,
                    ToDate = objtran.tdate,
                    VNumber = objtran.vehicleNumber
                };

                string sp = "";
                if (objtran.UserType == "Licensee")
                    sp = "uspGetLicenseeOperationReport";
                else
                    sp = "uspGetEndUserOperationReport";

                var result = await Connection.ExecuteReaderAsync(sp, paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);


                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        EndUser_ETransitPassModel model = new EndUser_ETransitPassModel();
                        model.TransitPassID = Convert.ToInt32(dt.Rows[i]["TransitPassID"]);
                        model.TransitPassNo = Convert.ToString(dt.Rows[i]["TransitPassNo"]);
                        model.MineralName = Convert.ToString(dt.Rows[i]["MineralName"]);
                        model.UnitName = Convert.ToString(dt.Rows[i]["UnitName"]);
                        model.MineralNature = Convert.ToString(dt.Rows[i]["MineralNature"]);
                        model.MineralGradeName = Convert.ToString(dt.Rows[i]["MineralGrade"]);
                        model.TransportationMode = Convert.ToString(dt.Rows[i]["TransportationMode"]);

                        model.LesseeName = Convert.ToString(dt.Rows[i]["LesseeName"]);
                        model.MiningArea = Convert.ToString(dt.Rows[i]["MiningArea"]);

                        model.VehicleNumber = Convert.ToString(dt.Rows[i]["VehicleNumber"]);
                        model.VehicleTypeName = Convert.ToString(dt.Rows[i]["VehicleTypeName"]);
                        model.DateOfDispatche = Convert.ToDateTime(dt.Rows[i]["DateOfDispatche"]);
                        model.ReceivedWeight = Convert.ToDecimal(dt.Rows[i]["ReceivedWeight"]);
                        model.WashedCoal = Convert.ToDecimal(dt.Rows[i]["WashedCoal"]);
                        model.RejectedCoal = Convert.ToDecimal(dt.Rows[i]["RejectedCoal"]);
                        model.TripRemark = Convert.ToString(dt.Rows[i]["TripRemark"]);
                        model.To_RailwaySliding = Convert.ToString(dt.Rows[i]["RailwaySlidingName"]);
                        model.ReceivedDateTime = Convert.ToString(dt.Rows[i]["ReceivedDateTime"]);
                        List.Add(model);
                    }
                }



            }
            catch (Exception)
            {
                return null;
            }

            int index = 1;

            var ListPart = List.Select(x => new EndUser_ETransitPassModel
            {
                srNo = index++,
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
                DateOfDispatche = x.DateOfDispatche,
                DriverName = x.DriverName,
                TareWeight = x.TareWeight,
                TareTime = x.TareTime,
                GrossWeight = x.GrossWeight,
                GrossTime = x.GrossTime,
                NetWeight = x.NetWeight,
                ReceivedWeight = x.ReceivedWeight,
                TripStatus = x.TripStatus,
                TripRemark = x.TripRemark,
                MineralNature = x.MineralNature,
                UnitName = x.UnitName,
                MiningArea = x.MiningArea,
                To_RailwaySliding = x.To_RailwaySliding,
                ReceivedDateTime = x.ReceivedDateTime
            }).ToList();

            return ListPart;
        }
    }
}
