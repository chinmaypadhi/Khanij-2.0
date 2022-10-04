using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

using PermitApi.Factory;
using PermitApi.Repository;
using PermitEF;

namespace PermitApi.Model.CoalGrade
{
    public class CoalGradeProvider : RepositoryBase, ICoalGradeProvider
    {
        public CoalGradeProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<List<SampleGradeModel>> CoalGradeDetailsByUserID(SampleGradeModel obj)
        {
            List<SampleGradeModel> objlist = new List<SampleGradeModel>();
            try
            {
                var paramList = new
                {
                    CreatedBy = obj.LesseeId,
                    Check = 1
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<SampleGradeModel>("uspSampleGrade_Master", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    objlist = result.ToList();
                }

            }

            catch (Exception ex)
            {
                throw;
            }
            return objlist;
        }
        public async Task<ePermitModel> CoalGradeDetailsByPermitID(ePermitModel obj)
        {
            ePermitModel objmodel = new ePermitModel();
            try
            {
                var paramList = new
                {
                    BulkPermitId = obj.BulkPermitId,
                    UserID = obj.UserID,
                    Check=5
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryFirstAsync<ePermitModel>("uspSampleGrade_Master", paramList, commandType: System.Data.CommandType.StoredProcedure);
                objmodel = result;
            }
            catch (Exception ex)
            {
                throw;
            }
            return objmodel;
        }
        public async Task<List<ePermitModel>> GetMineralGradeCascadFromMineralNature(ePermitModel obj)
        {
            List<ePermitModel> objlist = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    UserId = obj.UserID,
                    MineralNatureId = obj.MineralNatureId
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<ePermitModel>("GetCoalMineralGradeList", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objlist = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objlist;
        }

        public async Task<List<ePaymentData>> RevisedPayableRoyaltyRate(RevisedPayableRoyaltyRate obj)
        {
            List<ePaymentData> objlist = new List<ePaymentData>();
            ePaymentData model = new ePaymentData();
            try
            {
                if (obj.UserType == "Tailing Dam")
                {

                }
                else
                {
                    var paramList = new
                    {
                        UserID = obj.UserID,
                        MineralNatureId = obj.MineralNatureId,
                        MineralGradeId = obj.MineralGradeId,
                        MineralId = obj.MineralId,
                        Quantity = obj.Quantity,
                        RoyaltyRate = obj.RoyaltyRate,
                        BulkPermitId = obj.BulkPermitId,
                        AluminaContent = obj.AluminaContent,
                        TinContent = obj.TinContent
                    };
                    DynamicParameters param = new DynamicParameters();
                    //var result = await Connection.QueryAsync<ePaymentData>("RoyaltyCalculationForBulkPermit_Revised", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    IDataReader dr = await Connection.ExecuteReaderAsync("RoyaltyCalculationForBulkPermit_Revised", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    DataSet ds = new DataSet();
                    ds = ConvertDataReaderToDataSet(dr);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            model = new ePaymentData();

                            if (Convert.ToString(dt.Rows[i]["MappingCount"]) == "0")
                            {
                                break;
                            }
                            else
                            {
                                model.PaymentTypeID = Convert.ToString(dt.Rows[i]["PaymentTypeID"]);
                                model.PaymentType = Convert.ToString(dt.Rows[i]["PaymentType"]);
                                model.CalType = Convert.ToString(dt.Rows[i]["CalType"]);
                                model.CalValue = Convert.ToString(dt.Rows[i]["CalValue"]);
                                model.MappingValue = Convert.ToString(dt.Rows[i]["MappingValue"]);
                                model.HeadAccount = Convert.ToString(dt.Rows[i]["HeadAccount"]);


                                if (dt.Rows[i]["IsApplicable"] != DBNull.Value)
                                {
                                    model.IsApplicable = Convert.ToBoolean(dt.Rows[i]["IsApplicable"]);
                                }
                                else
                                {
                                    model.IsApplicable = false;
                                }

                                if (i == 0 && dt.Rows.Count > 1)
                                {
                                    model.RoyaltyRate = Convert.ToString(dt.Rows[i]["RoyaltyRate"]);
                                    model.PayableRoyalty = Convert.ToString(dt.Rows[i]["MappingValue"]);
                                    model.BasisRate = Convert.ToString(dt.Rows[i]["BasicPrice"]);
                                    model.TotalPayableAmount = Convert.ToString(dt.Rows[i + 1]["TotalPayableAmount"]);
                                }
                                //Mukesh RoyaltyWithAdditional150PerInclusion Added 12-Oct-2021
                                //Begin
                                else if (dt.Rows[i]["PaymentType"].ToString().Equals("Additional Amount"))
                                {
                                    model.RoyaltyRate = Convert.ToString(dt.Rows[i]["RoyaltyRate"]);
                                    model.PayableRoyalty = Convert.ToString(dt.Rows[i]["MappingValue"]);
                                    model.BasisRate = Convert.ToString(dt.Rows[i]["BasicPrice"]);
                                    model.TotalPayableAmount = Convert.ToString(dt.Rows[i]["TotalPayableAmount"]);
                                }
                                //End
                                else
                                {
                                    model.RoyaltyRate = Convert.ToString(dt.Rows[0]["RoyaltyRate"]);
                                    model.PayableRoyalty = Convert.ToString(dt.Rows[0]["MappingValue"]);
                                    model.BasisRate = Convert.ToString(dt.Rows[0]["BasicPrice"]);
                                    model.TotalPayableAmount = Convert.ToString(dt.Rows[0]["TotalPayableAmount"]);
                                }
                                //Mukesh RoyaltyWithAdditional150PerInclusion Added 12-Oct-2021
                                //Begin
                                model.AdditionalRoyalty = Convert.ToString(dt.Rows[i]["AdditionalRoyalty"]);
                                //End

                                objlist.Add(model);
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
            return objlist;
        }
        /// <summary>
        /// Method Convert datareader to dataset
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
    }
}
