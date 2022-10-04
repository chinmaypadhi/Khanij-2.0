using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Royalty
{
    public class RoyaltyProvider : RepositoryBase, IRoyaltyProvider
    {
        public RoyaltyProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        #region Add
        public MessageEF AddRoyalty(RoyaltyModel royaltyModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                var search = ViewRoyalty(royaltyModel).FirstOrDefault(x => x.IsDelete == false && x.MineralId == royaltyModel.MineralId && x.MineralGradeId == royaltyModel.MineralGradeId);
                if (search != null)
                {
                    p.Add("@CHK", 1);
                    p.Add("@Production_DispatchType", royaltyModel.Production_DispatchType??"primary");
                    p.Add("@IsActive", royaltyModel.IsActive == null ? true : royaltyModel.IsActive);
                    p.Add("@UnitId", royaltyModel.UnitId);
                    p.Add("@MineralId", royaltyModel.MineralId);
                    p.Add("@RateEffectiveFrom", royaltyModel.RateEffectiveFrom);
                    p.Add("@AverageSalePrice", royaltyModel.AverageSalePrice);
                    p.Add("@RoyaltyRate", royaltyModel.RoyaltyRate);
                    p.Add("@MineralGradeId", royaltyModel.MineralGradeId);
                    p.Add("@RoyaltyRateTypeId", royaltyModel.RoyaltyID);
                    p.Add("@Remarks", royaltyModel.Remarks);
                    p.Add("@UserLoginID", royaltyModel.CreatedBy);
                    p.Add("@CreatedBy", royaltyModel.CreatedBy);
                    p.Add("@MineralTypeId", royaltyModel.MineralTypeId);
                    p.Add("@MineralScheduleId", royaltyModel.MineralScheduleId);
                    p.Add("@MineralSchedulePartId", royaltyModel.MineralSchedulePartId);
                    p.Add("@MineralNatureId", royaltyModel.MineralNatureId);
                    p.Add("@CalculationType", royaltyModel.CalculationTypeId);
                    p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    Connection.Query<int>("uspInsertRoyaltyMasterData", p, commandType: CommandType.StoredProcedure);
                    int newID = p.Get<int>("result");
                    string response = newID.ToString();
                    if (response == "1")
                    {
                        objMessage.Satus = "1";
                    }
                    else
                    {
                        objMessage.Satus = "2";
                    }
                }
                else
                {
                    p.Add("@CHK", 1);
                    p.Add("@Production_DispatchType", royaltyModel.Production_DispatchType??"primary");
                    p.Add("@IsActive", (royaltyModel.IsActive == null ? royaltyModel.IsActive = true : royaltyModel.IsActive = royaltyModel.IsActive));
                    p.Add("@UnitId", royaltyModel.UnitId);
                    p.Add("@MineralId", royaltyModel.MineralId);
                    p.Add("@RateEffectiveFrom", royaltyModel.RateEffectiveFrom);
                    p.Add("@AverageSalePrice", royaltyModel.AverageSalePrice);
                    p.Add("@RoyaltyRate", royaltyModel.RoyaltyRate);
                    p.Add("@MineralGradeId", royaltyModel.MineralGradeId);
                    p.Add("@RoyaltyRateTypeId", royaltyModel.RoyaltyRateTypeId);
                    p.Add("@Remarks", royaltyModel.Remarks);
                    p.Add("@UserLoginId", royaltyModel.CreatedBy);
                    p.Add("@CreatedBy", royaltyModel.CreatedBy);
                    p.Add("@MineralTypeId", royaltyModel.MineralTypeId);
                    p.Add("@MineralScheduleId", royaltyModel.MineralScheduleId);
                    p.Add("@MineralSchedulePartId", royaltyModel.MineralSchedulePartId);
                    p.Add("@MineralNatureId", royaltyModel.MineralNatureId);
                    p.Add("@CalculationType", royaltyModel.CalculationTypeId);
                    p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    Connection.Query<int>("uspInsertRoyaltyMasterData", p, commandType: CommandType.StoredProcedure);
                    int newID = p.Get<int>("result");
                    string response = newID.ToString();
                    if (response == "1")
                    {
                        objMessage.Satus = "1";
                    }
                    else
                    {
                        objMessage.Satus = "2";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        #endregion

        #region Delete
        public MessageEF DeleteRoyalty(RoyaltyModel royaltyModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "@RoyaltyId",royaltyModel.RoyaltyID,
                        "@CHK",2,
                        "@CreatedBy",royaltyModel.CreatedBy,
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("uspInsertRoyaltyMasterData", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("result");
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
        #endregion

        #region Edit
        public RoyaltyModel EditRoyalty(RoyaltyModel royaltyModel)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@RoyaltyId", royaltyModel.RoyaltyID);
                param.Add("@chk",1);
                var result = Connection.Query<RoyaltyModel>("UspSelectRoyaltyRateData", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    royaltyModel = result.FirstOrDefault();
                }
                return royaltyModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                royaltyModel = null;
            }
        }
        #endregion

        #region Update
        public MessageEF UpdateRoyalty(RoyaltyModel royaltyModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@Production_DispatchType", royaltyModel.Production_DispatchType??"primary");
                p.Add("@IsActive", (royaltyModel.IsActive == null ? royaltyModel.IsActive = true : royaltyModel.IsActive = royaltyModel.IsActive));
                p.Add("@UnitId", royaltyModel.UnitId);
                p.Add("@MineralId", royaltyModel.MineralId);
                p.Add("@RateEffectiveFrom", royaltyModel.RateEffectiveFrom);
                p.Add("@AverageSalePrice", royaltyModel.AverageSalePrice);
                p.Add("@RoyaltyRate", royaltyModel.RoyaltyRate);
                p.Add("@MineralGradeId", royaltyModel.MineralGradeId);
                p.Add("@RoyaltyRateTypeId", royaltyModel.RoyaltyRateTypeId);
                p.Add("@Remarks", royaltyModel.Remarks);
                p.Add("@UserLoginId", royaltyModel.CreatedBy);
                p.Add("@ModifiedBy", royaltyModel.CreatedBy);
                p.Add("@RoyaltyId", royaltyModel.RoyaltyID);
                p.Add("@MineralTypeId", royaltyModel.MineralTypeId);
                p.Add("@MineralScheduleId", royaltyModel.MineralScheduleId);
                p.Add("@MineralSchedulePartId", royaltyModel.MineralSchedulePartId);
                p.Add("@MineralNatureId", royaltyModel.MineralNatureId);
                p.Add("@CalculationType", royaltyModel.CalculationTypeId);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspUpdateRoyaltyMasterData", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
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
        #endregion

        #region View
        public List<RoyaltyModel> ViewRoyalty(RoyaltyModel royaltyModel)
        {
            List<RoyaltyModel> listRoyaltyModel = new List<RoyaltyModel>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MineralSchedulePartId", royaltyModel.MineralSchedulePartId);
                param.Add("@MineralID", royaltyModel.MineralId); 
                param.Add("@chk", royaltyModel.chk);
                var result = Connection.Query<RoyaltyModel>("UspSelectRoyaltyRateData", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    listRoyaltyModel = result.ToList();
                }
                return listRoyaltyModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                listRoyaltyModel = null;
            }
        }
        #endregion
    }
}
