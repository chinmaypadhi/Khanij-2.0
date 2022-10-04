using Dapper;
using EpassApi.Factory;
using EpassApi.Repository;
using EpassEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Model.eCancel
{
    public class eCancelProvider : RepositoryBase, IeCancelProvider
    {
        public eCancelProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        //public async Task<List<DD>> ddmodule(DD objOpenPermit)
        //{
        //    List<DD> List = new List<DD>();

        //    var p = new DynamicParameters();
        //    var Output = await Connection.QueryAsync<DD>("uspGetLesseeWisePassDetails", p, commandType: CommandType.StoredProcedure);
        //    if (Output.Count() > 0)
        //    {
        //        List = Output.ToList();
        //    }

        //    return List;
        //}

        //    //var result = await Connection.ExecuteReaderAsync("uspGetLesseeWisePassDetails", p, commandType: System.Data.CommandType.StoredProcedure);
        //    //DataTable dt = new DataTable();
        //    //dt.Load(result);

        //    //if (dt != null && dt.Rows.Count > 0)
        //    //{
        //    //    for (int i = 0; i < dt.Rows.Count; i++)
        //    //    {
        //    //     DD Obj = new DD();

        //    //        Obj.SrNo = (i + 1);
                   

        //    //        if (!(dt.Rows[i]["DateOfDispatche"] is DBNull))
        //    //        {
        //    //            //Obj.Mineral_DateOfDispatch = Convert.ToDateTime(dt.Rows[i]["DateOfDispatche"]);
        //    //            Obj.str_DateOfDispatch = Convert.ToString(dt.Rows[i]["DateOfDispatche"]);
        //    //        }

                   
                   
        //    //        Obj.TransitPassNumber = Convert.ToString(dt.Rows[i]["TransitPassNo"]);
        //    //        Obj.BulkPermitNo = Convert.ToString(dt.Rows[i]["BulkPermitNo"]);
        //    //        Obj.PurchaserConsigneeName = Convert.ToString(dt.Rows[i]["PurchaserConsigneeName"]);
        //    //        Obj.DriverName = Convert.ToString(dt.Rows[i]["DriverName"]);
        //    //        Obj.DONumber = Convert.ToString(dt.Rows[i]["DONumber"]);
        //    //        Obj.Remarks = Convert.ToString(dt.Rows[i]["Remarks"]);
        //    //        if (!(dt.Rows[i]["TareWeight"] is DBNull))
        //    //        {
        //    //            Obj.TareWeight_Qty = Convert.ToDecimal(dt.Rows[i]["TareWeight"]);
        //    //        }
        //    //        if (!(dt.Rows[i]["GrossWeight"] is DBNull))
        //    //        {
        //    //            Obj.GrossWeight_Qty = Convert.ToDecimal(dt.Rows[i]["GrossWeight"]);
        //    //        }
        //    //        if (!(dt.Rows[i]["TransporterId"] is DBNull))
        //    //        {
        //    //            Obj.TransporterId = Convert.ToInt32(dt.Rows[i]["TransporterId"]);
        //    //        }
        //    //        if (!(dt.Rows[i]["TransportationModeId"] is DBNull))
        //    //        {
        //    //            Obj.TransportationModeId = Convert.ToInt32(dt.Rows[i]["TransportationModeId"]);
        //    //        }
        //    //        Obj.VehicleNumber = Convert.ToString(dt.Rows[i]["VehicleNumber"]);
        //    //        Obj.VehicleTypeName = Convert.ToString(dt.Rows[i]["VehicleTypeName"]);
        //    //        if (!(dt.Rows[i]["NetWeight"] is DBNull))
        //    //        {
        //    //            Obj.NetWeight_Qty = Convert.ToDecimal(dt.Rows[i]["NetWeight"]);
        //    //        }
        //    //        Obj.MineralName = Convert.ToString(dt.Rows[i]["MineralName"]);
        //    //        Obj.MineralNature = Convert.ToString(dt.Rows[i]["MineralNature"]);
        //    //        Obj.UnitName = Convert.ToString(dt.Rows[i]["UnitName"]);
        //    //        Obj.MineralGradeName = Convert.ToString(dt.Rows[i]["MineralGradeName"]);

        //    //        Obj.TPMode = !string.IsNullOrEmpty(dt.Rows[i]["TRANSPORTATIONMODE"].ToString()) ? Convert.ToString(dt.Rows[i]["TRANSPORTATIONMODE"]) : "";
        //    //        Obj.IntTripStatus = !string.IsNullOrEmpty(dt.Rows[i]["INTTRIPSTATUS"].ToString()) ? Convert.ToString(dt.Rows[i]["INTTRIPSTATUS"]) : "";
        //    //        Obj.TripStatus = !string.IsNullOrEmpty(dt.Rows[i]["TRIPSTATUS"].ToString()) ? Convert.ToString(dt.Rows[i]["TRIPSTATUS"]) : "";

        //    //        if (dt.Columns.Contains("RePrintStatus"))
        //    //        {
        //    //            Obj.RePrintStatus = !string.IsNullOrEmpty(dt.Rows[i]["RePrintStatus"].ToString()) ? Convert.ToString(dt.Rows[i]["RePrintStatus"]) : "";
        //    //        }

        //    //        if (dt.Columns.Contains("CancelStatus"))
        //    //        {
        //    //            Obj.CancelStatus = Convert.ToInt32(dt.Rows[i]["CancelStatus"]);
        //    //        }

        //    //        if (dt.Columns.Contains("CancellationDateTime"))
        //    //        {
        //    //            Obj.CancellationDateTime = !string.IsNullOrEmpty(dt.Rows[i]["CancellationDateTime"].ToString()) ? dt.Rows[i]["CancellationDateTime"].ToString() : "-";
        //    //        }

        //    //        if (dt.Columns.Contains("ApproveRejectDateTime"))
        //    //        {
        //    //            Obj.ApproveRejectDateTime = !string.IsNullOrEmpty(dt.Rows[i]["ApproveRejectDateTime"].ToString()) ? dt.Rows[i]["ApproveRejectDateTime"].ToString() : "-";
        //    //        }

        //    //        //List.Add(Obj);
        //    //        //return model.ToString();

        //    //        Obj.ToString();
        //    //        //return Obj;


        //    //    }


        //    //}
        //    //return List;

        //    //throw new NotImplementedException();
     

        //public async Task<List<eCancelModel>> eCancel(eCancelModel objtran)
        //{
            
        //    List<eCancelModel> List = new List<eCancelModel>();
            
        //    var p = new DynamicParameters();

        //    p.Add("@UserId", objtran.Id);
        //    p.Add("@SubUserID", 4);
        //    p.Add("@PassType", objtran.ePassType);
        //    p.Add("@BulkPermitNo", "ePermit");           
                       

        //    var result = await Connection.ExecuteReaderAsync("uspGetLesseeWisePassDetails", p, commandType: System.Data.CommandType.StoredProcedure);
        //    DataTable dt = new DataTable();
        //    dt.Load(result);


        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            LesseeTransitPassModel Obj = new LesseeTransitPassModel();
                    
        //            Obj.SrNo = (i + 1);
        //            if (!(dt.Rows[i]["TransitPassID"] is DBNull))
        //            {
        //                Obj.TransitPassId = Convert.ToInt32(dt.Rows[i]["TransitPassID"]);
        //            }

        //            if (!(dt.Rows[i]["DateOfDispatche"] is DBNull))
        //            {
        //                //Obj.Mineral_DateOfDispatch = Convert.ToDateTime(dt.Rows[i]["DateOfDispatche"]);
        //                Obj.str_DateOfDispatch = Convert.ToString(dt.Rows[i]["DateOfDispatche"]);
        //            }

        //            if (!(dt.Rows[i]["PurchaserConsigneeId"] is DBNull))
        //            {
        //                Obj.PurchaserConsigneeId = Convert.ToInt32(dt.Rows[i]["PurchaserConsigneeId"]);
        //            }
        //            if (!(dt.Rows[i]["BulkPermitID"] is DBNull))
        //            {
        //                Obj.BulkPermitId = Convert.ToInt32(dt.Rows[i]["BulkPermitID"]);
        //            }
        //            Obj.TransitPassNumber = Convert.ToString(dt.Rows[i]["TransitPassNo"]);
        //            Obj.BulkPermitNo = Convert.ToString(dt.Rows[i]["BulkPermitNo"]);
        //            Obj.PurchaserConsigneeName = Convert.ToString(dt.Rows[i]["PurchaserConsigneeName"]);
        //            Obj.DriverName = Convert.ToString(dt.Rows[i]["DriverName"]);
        //            Obj.DONumber = Convert.ToString(dt.Rows[i]["DONumber"]);
        //            Obj.Remarks = Convert.ToString(dt.Rows[i]["Remarks"]);
        //            if (!(dt.Rows[i]["TareWeight"] is DBNull))
        //            {
        //                Obj.TareWeight_Qty = Convert.ToDecimal(dt.Rows[i]["TareWeight"]);
        //            }
        //            if (!(dt.Rows[i]["GrossWeight"] is DBNull))
        //            {
        //                Obj.GrossWeight_Qty = Convert.ToDecimal(dt.Rows[i]["GrossWeight"]);
        //            }
        //            if (!(dt.Rows[i]["TransporterId"] is DBNull))
        //            {
        //                Obj.TransporterId = Convert.ToInt32(dt.Rows[i]["TransporterId"]);
        //            }
        //            if (!(dt.Rows[i]["TransportationModeId"] is DBNull))
        //            {
        //                Obj.TransportationModeId = Convert.ToInt32(dt.Rows[i]["TransportationModeId"]);
        //            }
        //            Obj.VehicleNumber = Convert.ToString(dt.Rows[i]["VehicleNumber"]);
        //            Obj.VehicleTypeName = Convert.ToString(dt.Rows[i]["VehicleTypeName"]);
        //            if (!(dt.Rows[i]["NetWeight"] is DBNull))
        //            {
        //                Obj.NetWeight_Qty = Convert.ToDecimal(dt.Rows[i]["NetWeight"]);
        //            }
        //            Obj.MineralName = Convert.ToString(dt.Rows[i]["MineralName"]);
        //            Obj.MineralNature = Convert.ToString(dt.Rows[i]["MineralNature"]);
        //            Obj.UnitName = Convert.ToString(dt.Rows[i]["UnitName"]);
        //            Obj.MineralGradeName = Convert.ToString(dt.Rows[i]["MineralGradeName"]);

        //            Obj.TPMode = !string.IsNullOrEmpty(dt.Rows[i]["TRANSPORTATIONMODE"].ToString()) ? Convert.ToString(dt.Rows[i]["TRANSPORTATIONMODE"]) : "";
        //            Obj.IntTripStatus = !string.IsNullOrEmpty(dt.Rows[i]["INTTRIPSTATUS"].ToString()) ? Convert.ToString(dt.Rows[i]["INTTRIPSTATUS"]) : "";
        //            Obj.TripStatus = !string.IsNullOrEmpty(dt.Rows[i]["TRIPSTATUS"].ToString()) ? Convert.ToString(dt.Rows[i]["TRIPSTATUS"]) : "";

        //            if (dt.Columns.Contains("RePrintStatus"))
        //            {
        //                Obj.RePrintStatus = !string.IsNullOrEmpty(dt.Rows[i]["RePrintStatus"].ToString()) ? Convert.ToString(dt.Rows[i]["RePrintStatus"]) : "";
        //            }

        //            if (dt.Columns.Contains("CancelStatus"))
        //            {
        //                Obj.CancelStatus = Convert.ToInt32(dt.Rows[i]["CancelStatus"]);
        //            }

        //            if (dt.Columns.Contains("CancellationDateTime"))
        //            {
        //                Obj.CancellationDateTime = !string.IsNullOrEmpty(dt.Rows[i]["CancellationDateTime"].ToString()) ? dt.Rows[i]["CancellationDateTime"].ToString() : "-";
        //            }

        //            if (dt.Columns.Contains("ApproveRejectDateTime"))
        //            {
        //                Obj.ApproveRejectDateTime = !string.IsNullOrEmpty(dt.Rows[i]["ApproveRejectDateTime"].ToString()) ? dt.Rows[i]["ApproveRejectDateTime"].ToString() : "-";
        //            }

        //            //List.Add(Obj);
        //            //return model.ToString();

        //            Obj.ToString();
        //            //return Obj;


        //        }
                

        //    }
        //    return List;
        //}


        ////Dinesh  19Apr22
        public async Task<List<TPCancelModelEF>> GetTP_Cancel(TPCancelModelEF objtran)
        {

            List<TPCancelModelEF> objlistmodel = new List<TPCancelModelEF>();
            try
            {
                var paramlist = new
                {
                    UserId = objtran.UserID,
                    Check = objtran.Check,
                    FromDate = objtran.FromDate,
                    ToDate = objtran.ToDate
                    //p.Add("@UserID", "27805");
                    //p.Add("@Check", 2);
                    //p.Add("@FromDate", "01/03/2018");
                    //p.Add("@ToDate", "19/04/2022");

                };
             var result = await Connection.QueryAsync<TPCancelModelEF>("TPCancellationProcess", paramlist, commandType: System.Data.CommandType.StoredProcedure);
                //DataTable dt = new DataTable();
                //dt.Load(result);
                if (result.Count() > 0)
                {
                    objlistmodel = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objlistmodel; 
            
        }


    }
}
