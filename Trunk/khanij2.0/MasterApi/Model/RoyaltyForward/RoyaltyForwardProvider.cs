// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 31-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace MasterApi.Model.RoyaltyForward
{
    public class RoyaltyForwardProvider : RepositoryBase, IRoyaltyForwardProvider
    {
        public RoyaltyForwardProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public List<RoyaltyForwardmaster> ViewRoyaltyForwardMaster(RoyaltyForwardmaster objRoyaltyForwardmaster)
        {
            List<RoyaltyForwardmaster> ListRoyaltyForwardmaster = new List<RoyaltyForwardmaster>();
            try
            {
                var paramList = new
                {
                    CHECK = objRoyaltyForwardmaster.Check,
                    CreatedBy = objRoyaltyForwardmaster.CreatedBy,
                    P_intModuleId = objRoyaltyForwardmaster.intModuleId,
                    P_intSubModuleId = objRoyaltyForwardmaster.intSubModuleId
                };
                var result = Connection.Query<RoyaltyForwardmaster>("Royalty_Forward_Details", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListRoyaltyForwardmaster = result.ToList();
                }

                return ListRoyaltyForwardmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListRoyaltyForwardmaster = null;
            }
        }
        public MessageEF Submit(RoyaltyForwardmaster objRoyaltyForwardmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "CHECK",objRoyaltyForwardmaster.Check,
                        "RoyaltyId",objRoyaltyForwardmaster.RoyaltyId,
                        "CreatedBy",objRoyaltyForwardmaster.CreatedBy,
                        "P_intModuleId",objRoyaltyForwardmaster.intModuleId,
                        "P_intSubModuleId",objRoyaltyForwardmaster.intSubModuleId
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("Output");
                var result = Connection.Query<string>("Royalty_Forward_Details", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("Output");
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public List<RoyaltyForwardmaster> DownloadRoyaltyForwardMaster(RoyaltyForwardmaster objRoyaltyForwardmaster)
        {
            List<RoyaltyForwardmaster> ListRoyaltyForwardmaster = new List<RoyaltyForwardmaster>();
            try
            {
                var paramList = new
                {
                    UserId = objRoyaltyForwardmaster.UserId,
                    chk = "4",
                    RoyaltyId = objRoyaltyForwardmaster.RoyaltyId
                };
                var result = Connection.Query<RoyaltyForwardmaster>("UspSelectRoyaltyRateData", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListRoyaltyForwardmaster = result.ToList();
                }

                return ListRoyaltyForwardmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListRoyaltyForwardmaster = null;
            }
        }


        public List<RoyaltyForwardmaster> RoyaltyInbox(RoyaltyForwardmaster objRoyaltyForwardmaster)
        {
            List<RoyaltyForwardmaster> ListRoyaltyForwardmaster = new List<RoyaltyForwardmaster>();
            try
            {
                var paramList = new
                {
                    CHECK = objRoyaltyForwardmaster.Check,
                    CreatedBy = objRoyaltyForwardmaster.CreatedBy,
                    P_intModuleId = objRoyaltyForwardmaster.intModuleId,
                    P_intSubModuleId = objRoyaltyForwardmaster.intSubModuleId
                };
                var result = Connection.Query<RoyaltyForwardmaster>("RoyaltyInBox", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListRoyaltyForwardmaster = result.ToList();
                }

                return ListRoyaltyForwardmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListRoyaltyForwardmaster = null;
            }
        }
        public MessageEF TakeAction(RoyaltyForwardmaster objRoyalty)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@CHECK", objRoyalty.Check);
                p.Add("@RoyaltyId", objRoyalty.RoyaltyId);
                p.Add("@IsApproved", objRoyalty.IsApproved);
                p.Add("@Remarks", objRoyalty.Remarks);
                p.Add("@ModifiedBy", objRoyalty.ModifiedBy);

                p.Add("@P_intModuleId", objRoyalty.intModuleId);
                p.Add("@P_intSubModuleId", objRoyalty.intSubModuleId);

                //Connection.Query<int>("Royalty_Approve_Details", p, commandType: CommandType.StoredProcedure);
                string responce = Connection.QueryFirst<string>("RoyaltyInBoxTakeAction", p, commandType: CommandType.StoredProcedure);
                if (responce == "1")
                {
                    objMessage.Satus = "1";
                    objMessage.Id = objRoyalty.RoyaltyId;
                }
                return objMessage;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RoyaltyApprovedLogEF> ViewRoyaltyActionHistory(RoyaltyApprovedLogEF objRoyalty)
        {
            List<RoyaltyApprovedLogEF> listRoyalty = new List<RoyaltyApprovedLogEF>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@CHECK", objRoyalty.Check);
                p.Add("@RoyaltyId", objRoyalty.RoyaltyId);
                var result = Connection.Query<RoyaltyApprovedLogEF>("RoyaltyInBox", p, commandType: CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    listRoyalty = result.ToList();

                }
                return listRoyalty;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                listRoyalty = null;

            }
        }

        public List<RoyaltyApprovedEF> RoyaltyInboxView(RoyaltyApprovedEF objRoyalty)
        {
            List<RoyaltyApprovedEF> listRoyalty = new List<RoyaltyApprovedEF>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@CHECK", objRoyalty.Check);
                p.Add("@CreatedBy", objRoyalty.CreatedBy);
                p.Add("@P_intModuleId", objRoyalty.intModuleId);
                p.Add("@P_intSubModuleId", objRoyalty.intSubModuleId);

                var result = Connection.Query<RoyaltyApprovedEF>("RoyaltyInBox", p, commandType: CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    listRoyalty = result.ToList();

                }
                return listRoyalty;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                listRoyalty = null;

            }
        }
    }
}
