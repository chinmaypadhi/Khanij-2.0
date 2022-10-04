using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

using PermitApi.Factory;
using PermitApi.Repository;
using PermitEF;

namespace PermitApi.Model.LTP
{
    public class LTPProvider : RepositoryBase, ILTPProvider
    {
        public LTPProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Get the details of RTP pass Number
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<List<LTPInfo>> GetRTPPassList(LTPInfo objLease)
        {
           // LTPInfo ObjResult = new LTPInfo();
            List<LTPInfo> ObjUserTypeList = new List<LTPInfo>();
            try
            {
                var paramList = new
                {
                    UserID = objLease.UserID,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<LTPInfo>("uspGetRTPPassNumber", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (LTPInfo dr in result)
                    {
                        ObjUserTypeList.Add(new LTPInfo()
                        {
                            RTPPassID = Convert.ToInt32(dr.RTPPassID.ToString()),
                            RTPPassNo = dr.RTPPassNo.ToString(),
                        });
                    }
                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjUserTypeList;
        }
        /// <summary>
        /// Get the mineral LIst
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<LTPInfo>> GetCascadeMineral(LTPInfo objLease)
        {
            List<LTPInfo> ObjUserTypeList = new List<LTPInfo>();
            try
            {
                var paramList = new
                {
                    UserID = objLease.UserID,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<LTPInfo>("upsGetMineralByUserID", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (LTPInfo dr in result)
                    {
                        ObjUserTypeList.Add(new LTPInfo()
                        {
                            MineralId = Convert.ToInt32(dr.MineralId.ToString()),
                            MineralName = dr.MineralName.ToString(),
                        });
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjUserTypeList;
        }
        /// <summary>
        /// Get the mineral Nature list
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<LTPInfo>> GetMineralNatureList(LTPInfo objLease)
        {
            List<LTPInfo> ObjUserTypeList = new List<LTPInfo>();
            try
            {
                var paramList = new
                {
                    UserID = objLease.UserID,
                    MineralId=objLease.MineralId,
                    Check=1,
                };
                DynamicParameters param = new DynamicParameters();
                
                var result =await Connection.QueryAsync<LTPInfo>("upsGetMineralByUserID", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (LTPInfo dr in result)
                    {
                        ObjUserTypeList.Add(new LTPInfo()
                        {
                            MineralNatureId = Convert.ToInt32(dr.MineralNatureId.ToString()),
                            MineralNature = dr.MineralNature.ToString(),
                        });
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjUserTypeList;
        }
        /// <summary>
        /// Get the mineral Grade list
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<LTPInfo>> GetMineralGradList(LTPInfo objLease)
        {
            List<LTPInfo> ObjUserTypeList = new List<LTPInfo>();
            try
            {
                var paramList = new
                {
                    UserID = objLease.UserID,
                    MineralNatureId = objLease.MineralNatureId,
                    Check = 2,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<LTPInfo>("upsGetMineralByUserID", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (LTPInfo dr in result)
                    {
                        ObjUserTypeList.Add(new LTPInfo()
                        {
                            MineralGradeId = Convert.ToInt32(dr.MineralGradeId.ToString()),
                            MineralGrade = dr.MineralGrade.ToString(),
                            ClosingStock=Convert.ToDecimal(dr.TotalStock.ToString()),
                            ECQuantity = Convert.ToDecimal(dr.ECQuantity.ToString()),
                        });
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjUserTypeList;
        }
        /// <summary>
        /// Bind the dropdown of Railway siding Sourse
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<LTPInfo>> GetRailwaySiding(LTPInfo objUser)
        {
            List<LTPInfo> ObjUserTypeList = new List<LTPInfo>();
            try
            {
                var paramList = new
                {
                    ACTION = 'E',

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<LTPInfo>("USP_FILL_COMMON_DATA", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (LTPInfo dr in result)
                    {
                        ObjUserTypeList.Add(new LTPInfo()
                        {
                            RailwayID = Convert.ToInt32(dr.RailwayID.ToString()),
                            RailwaySlidingName = dr.RailwaySlidingName.ToString(),
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjUserTypeList;
        }
        /// <summary>
        /// Bind the dropdown of Railway siding Destination
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<LTPInfo>> GetRailwaySidingDestination(LTPInfo objUser)
        {
            List<LTPInfo> ObjUserTypeList = new List<LTPInfo>();
            try
            {
                var paramList = new
                {
                    ACTION = 'E',

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<LTPInfo>("USP_FILL_COMMON_DATA", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (LTPInfo dr in result)
                    {
                        ObjUserTypeList.Add(new LTPInfo()
                        {
                            DestinationRailwayId = Convert.ToInt32(dr.RailwayID.ToString()),
                            DestinationRailwaySiding = dr.RailwaySlidingName.ToString(),
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjUserTypeList;
        }
        /// <summary>
        /// Get all RTP data
        /// </summary>
        /// <param name="BulkPermitId"></param>
        /// <returns></returns>
        public async Task<List<LTPInfo>> GetuserDetailsUsingRTP(LTPInfo objUser)
        {
            List<LTPInfo> ObjUserTypeList = new List<LTPInfo>();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,
                    RTPPassID = objUser.RTPPassID,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<LTPInfo>("uspGetDetailsUsingRTPPassNUmber", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Get all RTP data based on LTP permit number
        /// </summary>
        /// <param name="BulkPermitId"></param>
        /// <returns></returns>
        public async Task<List<LTPInfo>> getAddLTPDetails(LTPInfo objUser)
        {
            List<LTPInfo> ObjUserTypeList = new List<LTPInfo>();
            try
            {
                var paramList = new
                {
                    LTPPermitId = objUser.LTPPermitId,
                    Check=1,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<LTPInfo>("uspLTPPermit", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Get all RTP default data 
        /// </summary>
        /// <param name="BulkPermitId"></param>
        /// <returns></returns>
        public async Task<List<LTPInfo>> getLTPDetails(LTPInfo objUser)
        {
            List<LTPInfo> ObjUserTypeList = new List<LTPInfo>();
            try
            {
                var paramList = new
                {
                    CreatedBy = objUser.UserID,
                    Check = 5,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<LTPInfo>("uspLTPPermit", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Save LTP application
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddLTPApplication(LTPInfo model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
               
                p.Add("RTPPassId", model.RTPPassId);
                p.Add("ReceivedFrom", model.ReceivedFrom);
                p.Add("CreatedBy", model.UserID);
                //p.Add("LicenseId", SessionWrapper.UserId);
                p.Add("qtybyRailway", model.qtybyRailway);
                p.Add("FromRailwaySidingId", model.FromRailwaySidingId);
                p.Add("ToRailwaySidingId", model.WhereRailwaySidingId);

                p.Add("NameoftheRecieptMineralId", model.NameoftheRecieptMineralId);
                p.Add("Purpose", model.Purpose);
                p.Add("DestinationAddress", model.DestinationAddress);

                p.Add("TransportationRoute", model.TransportationRoute);
                p.Add("ForwardingReceiptName", model.ForwardingReceiptName);
                p.Add("ForwardingReceiptFilePath", model.ForwardingReceiptFilePath);

                p.Add("ApprovedQty", model.ApprovedQty);
                p.Add("Remark", model.Remark);
                p.Add("IsApproved", model.IsApproved);
                p.Add("IsReject", model.IsReject);
                p.Add("OtherDetails", model.OtherDetails);
                p.Add("DetailOfRailwayReceipt", model.DetailsofRailwayReciept);
                p.Add("MineralNatureId", model.MineralNatureId);
                p.Add("MineralGradeId", model.MineralGradeId);
                p.Add("ExpectedNoOfLtp", model.ExpectedNoOfLtp);


                p.Add("MineralId", model.MineralId);
                p.Add("ActiveStatus", 1);
                if (model.UserType == "Licensee")
                {
                    p.Add("LicenseId", model.UserID);
                }
                p.Add("Check", 2);
                // p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.ExecuteScalarAsync<string>("uspLTPPermit", p, commandType: CommandType.StoredProcedure);
                // int response = p.Get<int>("RESULT");

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
        /// <summary>
        /// Download LTP application
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        /// 
        public async Task<List<ListofLTP>> DownloadLTP(ListofLTP model)
        {
            List<ListofLTP> ObjUserTypeList = new List<ListofLTP>();
            try
            {
                var paramList = new
                {
                    CreatedBy = model.UserID,
                    LTPPermitId=model.LTPPermitId,

                    Check = 4,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<ListofLTP>("uspLTPPermit", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Get Pendig LTP List 
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        /// 
        public async Task<List<ListofLTP>> GetPendigLTPList(ListofLTP model)
        {
            List<ListofLTP> ObjUserTypeList = new List<ListofLTP>();
            try
            {
                var paramList = new
                {
                    CreatedBy = model.UserID,
                    LTPPermitId = model.LTPPermitId,
                    FromDate=model.FromDATE,
                    ToDate=model.ToDATE,
                    Check = 4,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<ListofLTP>("uspLTPPermit", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
    }
}
