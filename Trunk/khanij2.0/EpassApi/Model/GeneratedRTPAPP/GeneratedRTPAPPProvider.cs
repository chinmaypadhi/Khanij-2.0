using Dapper;
using EpassApi.Factory;
using EpassApi.Repository;
using EpassEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace EpassApi.Model.GeneratedRTPAPP
{
    public class GeneratedRTPAPPProvider: RepositoryBase, IGeneratedRTPAPPProvider
    {
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
        public GeneratedRTPAPPProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<List<FinalForwadingNoteEF>> GetDGDMOFN(FinalForwadingNoteModelEF objtran)
        {
            List<FinalForwadingNoteEF> objList = new List<FinalForwadingNoteEF>();
            DynamicParameters param = null;
            int myfinal=3;
            if (objtran.final == 0)
            {
                myfinal = 1;
            }
            if (objtran.final == 2)
            {
                myfinal = 2;
            }
            if (objtran.final == 3)
            {
                myfinal = 3;
            }
            if (objtran.final == 4)
            {
                myfinal = 4;

            }

            try
            {
                var paramList = new
            {
                FromDate1 = objtran.From,
                ToDate1 = objtran.To,
                CreatedBy = objtran.userid,
                Status = myfinal

                };
            param = new DynamicParameters();
            var result = await Connection.ExecuteReaderAsync("uspGetAllForwardingNote", paramList, commandType: System.Data.CommandType.StoredProcedure);
            var ds = ConvertDataReaderToDataSet(result);
            var data = ds.Tables[0];
            
            if (data != null && data.Rows.Count > 0)
            {
                int sn = 1;
                FinalForwadingNoteEF model;
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    try
                    {
                        model = new FinalForwadingNoteEF();
                        model.SRNO = sn;
                        model.ForwardingNoteId = Convert.ToInt32(data.Rows[i]["ForwardingNoteId"]);
                        model.ForwardingTransacationId = Convert.ToString(data.Rows[i]["ForwardingTransacationId"]);
                        model.ForwardingNoteNumber = Convert.ToString(data.Rows[i]["ForwardingNote"]);
                        model.BulkPermitId = Convert.ToInt32(data.Rows[i]["BulkPermitId"]);
                        model.BulkPermitNumber = Convert.ToString(data.Rows[i]["BulkPermitNo"]);
                        model.RailwayId = Convert.ToInt32(data.Rows[i]["RailwayId"]);
                        model.RailwaySliding = Convert.ToString(data.Rows[i]["RailwaySlidingName"]);
                        model.DateofSubmitedRTPRequest = Convert.ToDateTime(data.Rows[i]["CreatedOn"]);
                        model.MineralName = Convert.ToString(data.Rows[i]["MineralName"]);
                        model.MineralId = Convert.ToInt32(data.Rows[i]["MineralID"]);
                        model.MineralGrade = Convert.ToString(data.Rows[i]["MineralGrade"]);
                        model.MineralGradeId = Convert.ToInt32(data.Rows[i]["MineralGradeId"]);
                        model.MineralNature = Convert.ToString(data.Rows[i]["MineralNature"]);
                        model.MineralNatureId = Convert.ToInt32(data.Rows[i]["MineralNatureId"]);
                        model.EndUserId = Convert.ToInt32(data.Rows[i]["EndUserId"]);
                        model.EndUser = Convert.ToString(data.Rows[i]["EndUserName"]);
                        model.ReqQty = Convert.ToDecimal(data.Rows[i]["ReqQty"]);
                        model.ApprovedQty = !string.IsNullOrEmpty(data.Rows[i]["ApprovedQty"].ToString()) ? Convert.ToDecimal(data.Rows[i]["ApprovedQty"]) : 0;
                        model.Status = Convert.ToInt32(data.Rows[i]["Status"]);
                        model.GrantOrderDate = Convert.ToString(data.Rows[i]["DateOfGrant"]);
                        model.GrantOrderNo = Convert.ToString(data.Rows[i]["GrantOrderNo"]);
                        model.LeaseFrom = Convert.ToString(data.Rows[i]["PeriodOfLeaseFrom"]);
                        model.LeaseTo = Convert.ToString(data.Rows[i]["PeriodOfLeaseTo"]);
                        model.LicenseeId = Convert.ToInt32(data.Rows[i]["LicenseeId"]);
                        model.Consigner = Convert.ToString(data.Rows[i]["Name"]);
                        model.Address = Convert.ToString(data.Rows[i]["Address"]);
                        model.TelephoneNo = Convert.ToString(data.Rows[i]["ContactNumber"]);
                        model.UnitName = Convert.ToString(data.Rows[i]["UnitName"]);
                        model.UnitId = Convert.ToInt32(data.Rows[i]["UnitId"]);
                        model.Remarks = Convert.ToString(data.Rows[i]["Remark"]);

                        model.NoofRTP = Convert.ToInt32(data.Rows[i]["NoofRTP"]);


                        if (!string.IsNullOrEmpty(data.Rows[i]["ApprovedQty"].ToString()) && !string.IsNullOrEmpty(data.Rows[i]["ReqQty"].ToString()))
                        {
                            if (Convert.ToDecimal(data.Rows[i]["ReqQty"].ToString()) - Convert.ToDecimal(data.Rows[i]["ApprovedQty"].ToString()) == 0)
                            {
                                model.isLable = 0;
                            }
                            else
                            {
                                model.isLable = 1;
                                model.DiffDisplay = Convert.ToDecimal(data.Rows[i]["ReqQty"].ToString()) - (Convert.ToDecimal(data.Rows[i]["ReqQty"].ToString()) - Convert.ToDecimal(data.Rows[i]["ApprovedQty"].ToString()));
                            }


                        }
                        model.ViewUserType = objtran.UserType;

                        model.PendingQty = Convert.ToDecimal(data.Rows[i]["PendingQty"]);
                        model.TransportationMode = Convert.ToString(data.Rows[i]["TransportationMode"]);

                        if (!string.IsNullOrEmpty(data.Rows[i]["IndividualtakenRTP"].ToString()) && Convert.ToDecimal(data.Rows[i]["IndividualtakenRTP"]) > 0)
                        {
                            model.TotalDispatchedQty = Convert.ToDecimal(data.Rows[i]["IndividualtakenRTP"]);
                            model.BalanceQty = Convert.ToDecimal(data.Rows[i]["RTPAppliedQty"]);
                        }
                        else
                        {
                            if (model.TransportationMode.ToUpper() == "INSIDE RAILWAY SIDING")
                            {
                                model.TotalDispatchedQty = Convert.ToDecimal(data.Rows[i]["DispatchedQty"]);
                                model.BalanceQty = Convert.ToDecimal(data.Rows[i]["RTPAppliedQty"]);
                            }
                            else
                            {
                                model.TotalDispatchedQty = Convert.ToDecimal(data.Rows[i]["DispatchedQty"]);
                                model.BalanceQty = Convert.ToDecimal(data.Rows[i]["RTPAppliedQty"]);
                            }

                            // model.TotalDispatchedQty = Convert.ToDecimal(data.Rows[i]["DispatchedQty"]);
                            // model.BalanceQty = Convert.ToDecimal(data.Rows[i]["ApprovedQty"]) - Convert.ToDecimal(data.Rows[i]["RTPAppliedQty"]);
                        }






                        if (data.Columns.Contains("RTPPassNo"))
                        {
                            model.RTPPassNo = Convert.ToString(data.Rows[i]["RTPPassNo"]);
                        }

                        if (data.Columns.Contains("DispatchStatus"))
                        {
                            model.DispatchedQty = Convert.ToDecimal(data.Rows[i]["DispatchStatus"]);
                        }

                        if (model.Status == 1)
                        {
                            model.Request_Status = "Pending For Forwarding";
                        }
                        else if (model.Status == 2)
                        {
                            if (objtran.UserType.ToUpper() != "LESSEE" && objtran.UserType.ToUpper() != "Licensee")
                            {
                                model.Request_Status = "New Forwarding Note";
                            }
                            else
                            {
                                model.Request_Status = "Forward To DD/DMO";
                            }
                        }
                        else if (model.Status == 3)
                        {
                            //model.Request_Status = "Accepted";
                            model.Request_Status = "Approved";
                        }
                        else if (model.Status == 4)
                        {
                            model.Request_Status = "Rejected";
                        }
                        else if (model.Status == 5)
                        {
                            model.Request_Status = "RTP Reqested";
                        }
                        else if (model.Status == 6)
                        {
                            model.Request_Status = "Accepted";
                        }


                        model.CloseTripStatus = Convert.ToInt32(data.Rows[i]["CloseTripStatus"]);
                        model.GenerateRTPStatus = Convert.ToInt32(data.Rows[i]["GenerateRTPStatus"]);
                        model.CloseRTPStatus = Convert.ToInt32(data.Rows[i]["CloseRTPStatus"]);
                        model.TripStatus = Convert.ToInt32(data.Rows[i]["TripStatus"]);

                        model.EDRMNumber = Convert.ToString(data.Rows[i]["EDRMNumber"]);
                        model.EDRMDate = Convert.ToString(data.Rows[i]["EDRMDate"]);

                        if (data.Rows[i]["EDRMCopyPath"].ToString() != "" && data.Rows[i]["EDRMCopyPath"].ToString() != null)
                        {
                                //Shyam Sir updated for file
                                // model.EDRMCopyPath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + Convert.ToString(data.Rows[i]["EDRMCopyPath"]);

                                model.EDRMCopyPath =Convert.ToString(data.Rows[i]["EDRMCopyPath"]);
                            }
                        objList.Add(model);
                        sn++;
                    }
                    catch { }
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
    }
}
