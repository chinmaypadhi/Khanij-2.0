// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 2-Feb-2021
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

namespace MasterApi.Model.RoyaltyMapping
{
    public class RoyaltyMappingProvider:RepositoryBase, IRoyaltyMappingProvider
    {
        public RoyaltyMappingProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddRoyaltyMappingmaster(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            MessageEF objMessage = new MessageEF();
            var CalType = "";
            var CalValue = "";
            var PaymentType = "";
            var CheckIds = "";
            if (objRoyaltyMappingmaster.CalcChecked.Count() > 0)
            {
                for (int i = 0; i < objRoyaltyMappingmaster.CalcChecked.Count(); i++)
                {
                    CheckIds += objRoyaltyMappingmaster.CalcChecked[i].ToString();
                    CheckIds += ",";
                }
            }

            if (objRoyaltyMappingmaster.CalcVal.Count() > 0)
            {
                for (int i = 0; i < objRoyaltyMappingmaster.CalcVal.Count(); i++)
                {
                    CalValue += objRoyaltyMappingmaster.CalcVal[i].ToString();
                    CalValue += ",";
                }
            }

            if (objRoyaltyMappingmaster.CalcType.Count() > 0)
            {
                for (int i = 0; i < objRoyaltyMappingmaster.CalcType.Count(); i++)
                {
                    CalType += objRoyaltyMappingmaster.CalcType[i].ToString();
                    CalType += ",";
                }
            }
            if (objRoyaltyMappingmaster.PaymentType.Count() > 0)
            {
                for (int i = 0; i < objRoyaltyMappingmaster.PaymentType.Count(); i++)
                {
                    PaymentType += objRoyaltyMappingmaster.PaymentType[i].ToString();
                    PaymentType += ",";
                }
            }
            try
            {
                var p = new DynamicParameters();
                p.Add("MappingID", objRoyaltyMappingmaster.MappingID);
                p.Add("LeaseTypeID", objRoyaltyMappingmaster.ID);
                p.Add("UnitId", objRoyaltyMappingmaster.UnitId);
                p.Add("MineralId", objRoyaltyMappingmaster.MineralId);
                p.Add("GrantOrderDate", objRoyaltyMappingmaster.GrantOrderDate);
                p.Add("AuctionName", objRoyaltyMappingmaster.AuctionName);
                p.Add("RoyaltyRateID", objRoyaltyMappingmaster.RoyaltyId);
                p.Add("MineralGradeId", objRoyaltyMappingmaster.MineralGradeId);
                p.Add("RoyaltyRateTypeId", objRoyaltyMappingmaster.RoyaltyRateTypeId);
                p.Add("GrantType", objRoyaltyMappingmaster.IsGrantType);
                //p.Add("UserLogIn", objRoyaltyMappingmaster.UserLoginId);
                //p.Add("UserId", objRoyaltyMappingmaster.UserId);
                p.Add("MineralTypeID", objRoyaltyMappingmaster.MineralTypeId);
                p.Add("MineralScheduleID", objRoyaltyMappingmaster.MineralScheduleId);
                p.Add("MineralSchedulePartID", objRoyaltyMappingmaster.MineralSchedulePartId);
                p.Add("MineralNatureId", objRoyaltyMappingmaster.MineralNatureId);
                p.Add("CalType",CalType);
                p.Add("CalValue", CalValue);
                p.Add("PaymentType", PaymentType);
                p.Add("CheckIds", CheckIds);
                p.Add("Check", "0");
                string response = Connection.QueryFirst<string>("uspInsertRoyaltyRateMappingData", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response == "2")
                {
                    objMessage.Satus = "3";

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
        public List<RoyaltyMappingmaster> ViewRoyaltyMappingmaster(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            List<RoyaltyMappingmaster> ListRoyaltyMappingmaster = new List<RoyaltyMappingmaster>();
            try
            {
                var paramList = new
                {
                    MappingId=objRoyaltyMappingmaster.MappingID
                };
                var result = Connection.Query<RoyaltyMappingmaster>("uspRoyaltyMappingDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListRoyaltyMappingmaster = result.ToList();
                }

                return ListRoyaltyMappingmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListRoyaltyMappingmaster = null;
            }



        }
        public RoyaltyMappingmaster EditRoyaltyMappingmaster(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            RoyaltyMappingmaster LobjRoyaltyMappingmaster = new RoyaltyMappingmaster();
            try
            {
                var paramList = new
                {
                    MappingId = objRoyaltyMappingmaster.MappingID,
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<RoyaltyMappingmaster>("uspRoyaltyMappingDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjRoyaltyMappingmaster = result.FirstOrDefault();
                }

                return LobjRoyaltyMappingmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjRoyaltyMappingmaster = null;
            }
        }
        public MessageEF DeleteRoyaltyMappingmaster(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("MappingID", objRoyaltyMappingmaster.MappingID);
                p.Add("Check", "1");
                string response = Connection.QueryFirst<string>("uspInsertRoyaltyRateMappingData", p, commandType: CommandType.StoredProcedure);
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
        public List<RoyaltyMappingmaster> ViewPaymentType(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            List<RoyaltyMappingmaster> ListPaymentType = new List<RoyaltyMappingmaster>();
            try
            {
                var paramList = new
                {
                    MappingId=objRoyaltyMappingmaster.MappingID
                };
                var result = Connection.Query<RoyaltyMappingmaster>("uspPaymentTypeMasterDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListPaymentType = result.ToList();
                }

                return ListPaymentType;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListPaymentType = null;
            }
        }
        public List<RoyaltyMappingmaster> ViewRoyaltyType(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            List<RoyaltyMappingmaster> ListRoyaltyType = new List<RoyaltyMappingmaster>();
            try
            {
                var paramList = new
                {
                    MineralGrade = objRoyaltyMappingmaster.MineralGradeId
                };
                var result = Connection.Query<RoyaltyMappingmaster>("uspRoyaltyDropDownDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListRoyaltyType = result.ToList();
                }

                return ListRoyaltyType;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListRoyaltyType = null;
            }
        }
    }
}
