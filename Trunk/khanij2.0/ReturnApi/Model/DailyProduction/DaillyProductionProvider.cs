using Dapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReturnApi.Factory;
using ReturnApi.Repository;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Model.DailyProduction
{
    public class DaillyProductionProvider : RepositoryBase, IDailyProductionProvider
    {
        public DaillyProductionProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Dailly Production Details
        /// </summary>
        /// <param name="objDailyProductionr"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> AddDailyProduction(DailyProductionModel objDailyProductionr)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("UserId", objDailyProductionr.UserId);
                p.Add("DailyProduction", objDailyProductionr.DT);
                p.Add("Check", "Insert");
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("SP_IUDRuleMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else
                {
                    objMessage.Satus = "2";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
            }

        }

        /// <summary>
        /// Get List of Mineral Form
        /// </summary>
        /// <param name="objDailyProduction"></param>
        /// <returns>GetMineralResult class</returns>
        public async Task<GetMineralResult> ListOfMineralForm(DailyProductionModel objDailyProduction)
        {
            GetMineralResult objres = new GetMineralResult();
            List<DailyProductionModel> ListDP = new List<DailyProductionModel>();
            try
            {
                var paramList = new
                {
                    MineralId = objDailyProduction.MineralId,
                    UserId = objDailyProduction.UserId,
                    Check = 1,

                };
                var result = await Connection.QueryAsync<DailyProductionModel>("uspDailyProduction_MineralNature", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    foreach (DailyProductionModel dr in result)
                    {
                        ListDP.Add(new DailyProductionModel()
                        {
                            MineralFormID = dr.MineralFormID,
                            MineralForm = dr.MineralForm.ToString(),
                        });
                    }
                    objres.GetMineralLst = ListDP;
                }
                return objres;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objres = null;
                ListDP = null;
            }

        }

        /// <summary>
        /// List of Grade By Mineral form DDl
        /// </summary>
        /// <param name="objDailyProduction"></param>
        /// <returns>GetMineralResult class</returns>
        public async Task<GetMineralResult> ListOfGradeByMineralForm(DailyProductionModel objDailyProduction)
        {
            GetMineralResult objres = new GetMineralResult();
            List<DailyProductionModel> ListDP = new List<DailyProductionModel>();
            try
            {
                var paramList = new
                {
                    MineralNatureId = objDailyProduction.MineralNatureId,
                    Check = 2,
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<DailyProductionModel>("[uspDailyProduction_MineralNature]", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (DailyProductionModel dr in result)
                    {
                        ListDP.Add(new DailyProductionModel()
                        {
                            MineralGradeID = Convert.ToInt32(dr.MineralGradeID.ToString()),
                            MineralGrade = dr.MineralGrade.ToString(),
                        });
                    }
                    objres.GetMineralLst = ListDP;
                }
                return objres;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objres = null;
                ListDP = null;
            }

        }

        /// <summary>
        /// Get Mineral By User Id
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public async Task<DailyProductionModel> GetMineralByUserId(DailyProductionModel objDP)
        {
            DailyProductionModel LobjDP = new DailyProductionModel();
            try
            {
                var paramList = new
                {
                    UserId = objDP.UserId,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<DailyProductionModel>("uspGetMineralIdbyUser", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjDP = result.FirstOrDefault();
                }

                return LobjDP;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjDP = null;
            }
        }

        /// <summary>
        /// Insert Dailly Production Data
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> InsertDPData(DailyProductionModel objDP)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                DataTable dt = new DataTable("MultipleFileUpload");
                dt = (DataTable)objDP.DT;
                p.Add("UserId", objDP.UserId);
                string json = objDP.jsonSerialize;
                dt = JsonConvert.DeserializeObject<DataTable>(json);
                p.Add("DailyProduction", dt, DbType.Object);
                if (dt != null && dt.Rows.Count > 0)
                {
                    p.Add("DailyProduction", dt, DbType.Object);
                }
                p.Add("Check", "Insert");
                string response =await Connection.QueryFirstAsync<string>("uspDailyProduction_Insertion", p, commandType: CommandType.StoredProcedure);
                objMessage.Msg = response.ToString();
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
            }

        }

        /// <summary>
        /// Get Production Capacity
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public async Task<DailyProductionModel> GetProdCaacity(DailyProductionModel objDP)
        {
            DailyProductionModel LobjDP = new DailyProductionModel();
            try
            {
                var paramList = new
                {
                    UserId = objDP.UserId,
                    Check = 1,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<DailyProductionModel>("uspGetLesseDashboardData", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjDP = result.FirstOrDefault();
                }
                return LobjDP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjDP = null;
            }
        }

        /// <summary>
        /// View Dailly Production Summary
        /// </summary>
        /// <param name="OBJDP"></param>
        /// <returns>List of DailyProductionModel class</returns>
        public async Task<List<DailyProductionModel>> ViewDPSummary(DailyProductionModel OBJDP)
        {
            List<DailyProductionModel> ListDP = new List<DailyProductionModel>();
            try
            {
                var paramList = new
                {
                    UserId = OBJDP.UserId,
                };
                var result =await Connection.QueryAsync<DailyProductionModel>("uspGetDailyProductionSummary", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    ListDP = result.ToList();
                }
                return ListDP;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ListDP = null;
            }
        }

        /// <summary>
        /// Get Dailly Production Year
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public async Task<DailyProductionModel> GetProdYear(DailyProductionModel objDP)
        {
            DailyProductionModel LobjDP = new DailyProductionModel();
            try
            {
                var paramList = new
                {
                    UserId = objDP.UserId,
                    Check = 1,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<DailyProductionModel>("uspDailyProduction_GridFilter_ko02", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjDP = result.FirstOrDefault();
                }
                return LobjDP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjDP = null;
            }
        }

        /// <summary>
        /// Get Production Month
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public async Task<DailyProductionModel> GetProdMonth(DailyProductionModel objDP)
        {
            DailyProductionModel LobjDP = new DailyProductionModel();
            try
            {
                var paramList = new
                {
                    UserId = objDP.UserId,
                    Check = 2,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<DailyProductionModel>("GetFinancialYearList_KO20", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjDP = result.FirstOrDefault();
                }
                return LobjDP;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                LobjDP = null;
            }
        }

        /// <summary>
        /// View Dailly production Details
        /// </summary>
        /// <param name="OBJDP"></param>
        /// <returns>List of DailyProductionModel</returns>
        public async Task<List<DailyProductionModel>> ViewDPDetails(DailyProductionModel OBJDP)
        {
            List<DailyProductionModel> ListDP = new List<DailyProductionModel>();
            try
            {
                var paramList = new
                {
                    UserId = OBJDP.UserId,
                    FilterMonth = OBJDP.MonthYear,
                    Check = "Select",
                };
                var result =await Connection.QueryAsync<DailyProductionModel>("uspDailyProduction_Insertion", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListDP = result.ToList();
                }
                return ListDP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListDP = null;
            }
        }

        /// <summary>
        /// Delete Dailly Production
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> DeleteDP(DailyProductionModel objDP)
        {
            MessageEF objMessage = new MessageEF();
            var p = new DynamicParameters();
            try
            {
                p.Add("DailyProductionMasterId", objDP.DailyProductionMasterId);

                p.Add("UserId", objDP.UserId);
                p.Add("Check", "DeleteRecords");
                int response =await Connection.QueryFirstAsync<int>("uspDailyProduction_Insertion", p, commandType: CommandType.StoredProcedure);
                if (response > 0)
                {
                    objMessage.Satus = "1";
                }
                else
                {
                    objMessage.Satus = "2";
                }
                return objMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMessage = null;
            }

        }

        /// <summary>
        /// Submit Dailly Production
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> SubmitDP(DailyProductionModel objDP)
        {
            MessageEF objMessage = new MessageEF();
            var p = new DynamicParameters();
            try
            {
                p.Add("FilterYear", objDP.ProductionYear);
                p.Add("FilterMonth", objDP.ProductionMonth);
                p.Add("UserId", objDP.UserId);
                p.Add("Check", "SubmitRecords");
                string response =await Connection.QueryFirstAsync<string>("uspDailyProduction_Insertion", p, commandType: CommandType.StoredProcedure);
                objMessage.Msg = response.ToString();
                return objMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMessage = null;
            }

        }

        /// <summary>
        /// Get List Of Month
        /// </summary>
        /// <param name="objDailyProduction"></param>
        /// <returns>GetMonthResult class</returns>
        public async Task<GetMonthResult> ListOfMonth(DailyProductionModel objDailyProduction)
        {
            GetMonthResult objres = new GetMonthResult();
            List<DailyProductionModel> ListDP = new List<DailyProductionModel>();
            try
            {
                var paramList = new
                {
                    UserID = objDailyProduction.UserId,
                    Check = 2,
                };
                var result =await Connection.QueryAsync<DailyProductionModel>("GetFinancialYearList", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    foreach (DailyProductionModel dr in result)
                    {
                        ListDP.Add(new DailyProductionModel()
                        {
                            M_Id = dr.M_Id,
                            Months = dr.Months.ToString(),
                        });
                    }
                    objres.GetMonthLst = ListDP;

                }
                return objres;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objres = null;
                ListDP = null;

            }


        }

        /// <summary>
        /// Get List Of Years
        /// </summary>
        /// <param name="objDailyProduction"></param>
        /// <returns>GetYearResult class</returns>
        public async Task<GetYearResult> ListOfYear(DailyProductionModel objDailyProduction)
        {
            GetYearResult objres = new GetYearResult();
            List<DailyProductionModel> ListDP = new List<DailyProductionModel>();
            try
            {
                var paramList = new
                {
                    UserID = objDailyProduction.UserId,
                    Check = 1,
                };
                var result =await Connection.QueryAsync<DailyProductionModel>("uspDailyProduction_GridFilter", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    foreach (DailyProductionModel dr in result)
                    {
                        ListDP.Add(new DailyProductionModel()
                        {
                            Year = dr.Year.ToString(),
                        });
                    }
                    objres.GetYearLst = ListDP;
                }
                return objres;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objres = null;
                ListDP = null;

            }

        }

        /// <summary>
        /// Get Payment Details By User ID
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public async Task<DailyProductionModel> GetPaymentDetailsByUserId(DailyProductionModel objDP)
        {
            DailyProductionModel LobjDP = new DailyProductionModel();
            try
            {
                var paramList = new
                {
                    UserId = objDP.UserId,
                    Check = "PAYMENT",
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<DailyProductionModel>("uspDailyProduction_Insertion", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    LobjDP = result.FirstOrDefault();
                }
                return LobjDP;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                LobjDP = null;
            }
        }

        /// <summary>
        /// Get Payment Details By User ID and MInth Year
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public async Task<DailyProductionModel> GetPaymentDetailsByUserIdMOnthYear(DailyProductionModel objDP)
        {
            DailyProductionModel LobjDP = new DailyProductionModel();
            try
            {
                var paramList = new
                {
                    UserId = objDP.UserId,
                    Check = "PAYMENT",
                    FilterMonth = objDP.MonthYear,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<DailyProductionModel>("uspDailyProduction_Insertion", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjDP = result.FirstOrDefault();
                }
                return LobjDP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjDP = null;
            }
        }

        /// <summary>
        /// Get User ID
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public async Task<DailyProductionModel> GetUId(DailyProductionModel objDP)
        {
            DailyProductionModel LobjDP = new DailyProductionModel();
            try
            {
                var paramList = new
                {
                    UserId = objDP.UserId,
                    CHECK = 1,

                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<DailyProductionModel>("uspMAPUniqueID", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    LobjDP = result.FirstOrDefault();
                }
                return LobjDP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjDP = null;
            }
        }

        /// <summary>
        /// Get Payment Gateway Details
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>PaymentModel class</returns>
        public async Task<PaymentModel> GetPGateWay(DailyProductionModel objDP)
        {
            PaymentModel LobjPM = new PaymentModel();
            try
            {
                var paramList = new
                {
                    UserId = objDP.UserId,
                    Bank = objDP.PaymentBank,
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<PaymentModel>("getPaymentGateway", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    LobjPM = result.FirstOrDefault();
                }
                return LobjPM;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjPM = null;
            }
        }

        /// <summary>
        /// Insert Payment Request
        /// </summary>
        /// <param name="ObjPM"></param>
        /// <returns>MessageEF class</returns>
        public async Task<MessageEF> InsertPaymentRequest(PaymentModel ObjPM)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("PAYMENTFOR", 0);
                p.Add("UserId", ObjPM.UserMobileNumber);
                p.Add("RequestType", ObjPM.RequestType);
                p.Add("MerchantCode", ObjPM.MerchantCode);
                p.Add("MerchantTxnRefNumber", ObjPM.MerchantTxnRefNumber);
                p.Add("ITC", ObjPM.ITC);
                p.Add("CurrencyCode", "INR");
                p.Add("UniqueCustomerID", ObjPM.uniqueCustomerID);
                p.Add("TPSLTXNID", ObjPM.TPSLTXNID);
                p.Add("Shoppingcartdetails", ObjPM.Shoppingcartdetails);
                p.Add("TxnDate", ObjPM.TxnDate);
                p.Add("Email", ObjPM.Email);
                p.Add("MobileNo", ObjPM.mobileNo);
                p.Add("Bankcode", ObjPM.Bankcode);
                p.Add("CustomerName", ObjPM.customerName);
                p.Add("PaymentEncryptedData", ObjPM.finalSent);
                p.Add("PaymentMode", ObjPM.PaymentMode);
                string response =await Connection.QueryFirstAsync<string>("uspDailyProduction_Insertion", p, commandType: CommandType.StoredProcedure);
                objMessage.Msg = response.ToString();
                if (objMessage.Msg == "1")
                {
                    objMessage.Satus = "1";
                }
                else
                {
                    objMessage.Satus = "2";
                }
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objMessage = null;
            }

        }

        /// <summary>
        /// View Dailly Production Details Month Year Wise
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of DailyProductionModel</returns>
        public async Task<List<DailyProductionModel>> ViewDPDetailsMonthYearWise(DailyProductionModel model)
        {
            List<DailyProductionModel> ListDP = new List<DailyProductionModel>();
            try
            {
                var paramList = new
                {
                    UserId = model.UserId,
                    MonthYear = model.MonthYear,
                };
                var result =await Connection.ExecuteReaderAsync("uspGetDailyProduction", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = new DailyProductionModel();
                    model.SrNo = Convert.ToInt32(dt.Rows[i]["SrNo"]);
                    model.ApplicantName = Convert.ToString(dt.Rows[i]["ApplicantName"]);
                    model.DistrictName = Convert.ToString(dt.Rows[i]["DistrictName"]);
                    model.MineralName = Convert.ToString(dt.Rows[i]["MineralName"]);
                    model.Quantity = Convert.ToDecimal(dt.Rows[i]["Quantity"]);
                    model.ProductionDataAvailableStatus = Convert.ToString(dt.Rows[i]["ProductionDate"]);
                    model.PaymentStatus = Convert.ToString(dt.Rows[i]["PaymentStatus"]);
                    model.PaidAmount = Convert.ToDecimal(dt.Rows[i]["PaidAmount"]);
                    model.PaymentDate = Convert.ToString(dt.Rows[i]["PaymentDate"]);
                    model.UserCode = Convert.ToString(dt.Rows[i]["UserCode"]);
                    model.MineralForm = Convert.ToString(dt.Rows[i]["MineralNature"]);
                    model.MineralGrade = Convert.ToString(dt.Rows[i]["MineralGrade"]);
                    ListDP.Add(model);
                }
                return ListDP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListDP = null;
            }



        }

    }
}
