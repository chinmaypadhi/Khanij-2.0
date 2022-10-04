using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using PermitApi.Factory;
using PermitApi.Repository;
using PermitEF;

namespace PermitApi.Model.PaymentConfig
{
    public class PaymentConfigProvider:RepositoryBase,IPaymentConfigProvider
    {
        public PaymentConfigProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Save fifth schedule data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> SaveFifthPaymentConfig(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("Description", model.Description);
                p.Add("AddtionalRate", model.AddtionalRate);
                p.Add("CreatedBy", model.UserID);
                p.Add("IsActive", model.IsActive);
                p.Add("MineralId", model.MineralId);
                p.Add("Check", 1);
                var result =await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
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
        /// View Fifth schedule
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> GetFifthSchedule(ePermitModel objUser)
        {
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,

                    Check = 2,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Get details for edit fifth schedule
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> EditFifthSchedule(ePermitModel objUser)
        {
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,
                    Id = objUser.FifthSchId,
                    Check = 10,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Update Fifth schedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateFifthPaymentConfig(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Id", model.FifthSchId);
                p.Add("Description", model.Description);
                p.Add("AddtionalRate", model.AddtionalRate);
                p.Add("CreatedBy", model.UserID);
                p.Add("IsActive", model.IsActive);
                p.Add("MineralId", model.MineralId);
                p.Add("Check", 9);
                var result =await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
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
        /// Delete Fifth Schedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteFifthPaymentConfig(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Id", model.FifthSchId);
                p.Add("CreatedBy", model.UserID);
                p.Add("Check", 11);
                var result =await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
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
        /// Save Sixth schedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> SaveSixthPaymentConfig(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("Description", model.Description);
                p.Add("AddtionalRate", model.AddtionalRate);
                p.Add("MineralId", model.MineralId);
                p.Add("MineralNatureId", model.MineralNatureId);
                p.Add("CreatedBy", model.UserID);
                p.Add("IsActive", model.IsActive);
                p.Add("Check", 3);
                var result =await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
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
        /// Update Sixth schedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateSixthPaymentConfig(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("Description", model.Description);
                p.Add("AddtionalRate", model.AddtionalRate);
                p.Add("MineralId", model.MineralId);
                p.Add("MineralNatureId", model.MineralNatureId);
                p.Add("CreatedBy", model.UserID);
                p.Add("IsActive", model.IsActive);
                p.Add("Id", model.SixthSchId);
                p.Add("Check", 8);
                var result =await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
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
        /// View Sixth schedule
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> GetSixthSchedule(ePermitModel objUser)
        {
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,

                    Check = 4,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Get details for edit sixth schedule
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> EditSixthSchedule(ePermitModel objUser)
        {
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,
                    Id = objUser.SixthSchId,
                    Check = 7,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Bind mineral grade
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetMineralGradeListOnNatureList(ePermitModel objLease)
        {
            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();

            try
            {
                var paramList = new
                {
                    MineralNatureId = objLease.MineralNatureId,
                    MineralId=objLease.MineralId,
                    Check =17,
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            MineralGradeId = Convert.ToInt32(dr.MineralGradeId.ToString()),
                            MineralGrade = dr.MineralGrade.ToString(),


                        });
                    }
                    ObjResult.MineralGradeLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Bind Mineral nature dropdownlist
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetMineralNatureList(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    MineralId = objLease.MineralId,
                    Check = 6,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            MineralNatureId = Convert.ToInt32(dr.MineralNatureId.ToString()),
                            MineralNature = dr.MineralNature.ToString(),


                        });
                    }
                    ObjResult.MineralNatureLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Bind mineral list
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetMineralList(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    MineralTypeId = objLease.MineralTypeId,
                    Check = 5,
                    
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            MineralId = Convert.ToInt32(dr.MineralId.ToString()),
                            MineralName = dr.MineralName.ToString(),


                        });
                    }
                    ObjResult.MineralLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Delete sixth schedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteSixthPaymentConfig(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Id", model.SixthSchId);
                p.Add("CreatedBy", model.UserID);
                p.Add("Check", 12);
                var result =await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
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
        /// Bind fifth schedule dropdown
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> BindFifthSchedule(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    Check = 13,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            FifthSchId = Convert.ToInt32(dr.FifthSchId.ToString()),
                            Description = dr.Description.ToString(),


                        });
                    }
                    ObjResult.FifthSchedule = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Bind sixth dropdown schedule
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> BindSixthSchedule(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    Check = 14,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            SixthSchId = Convert.ToInt32(dr.SixthSchId.ToString()),
                            Description = dr.Description.ToString(),


                        });
                    }
                    ObjResult.SixthSchedule = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> GetRiderList(ePermitModel objUser)
        {
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,
                    MineralId=objUser.MineralId,
                    MineralNatureId=objUser.MineralNatureId,
                    DistrictId = objUser.DistrictId,
                    UserTypeId = objUser.UserTypeId,
                    Check = 15,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Save PAYMENT CONFIG
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> SavePaymentConfig(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("MinesType", model.MinesType);
                p.Add("CaptiveType", model.Captive);
                p.Add("CompanyType", model.CompanyType);
                p.Add("LeaseExtend", model.LeaseExtend);
                p.Add("MineralId", model.MineralId);
                p.Add("MineralNatureId", model.MineralNatureId);
                p.Add("FifthSchId", model.FifthSchId);
                p.Add("SixthSchId", model.SixthSchId);
                p.Add("UserID", model.UserID);
                p.Add("Check", 16);
                var result =await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
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
        /// Fill User name
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> FillUserName(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    Check = 25,
                    UserTypeId=objLease.UserTypeId,
                    DistrictId=objLease.DistrictId,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            LesseeId = Convert.ToInt32(dr.LesseeId.ToString()),
                            ApplicantName = dr.ApplicantName.ToString(),


                        });
                    }
                    ObjResult.UserList = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Fill Lease type
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> FillLeaseType(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    Check = 23,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            LeaseTypeId = Convert.ToInt32(dr.LeaseTypeId.ToString()),
                            LeaseTypeName = dr.LeaseTypeName.ToString(),


                        });
                    }
                    ObjResult.LeaseTypeLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// GetDynamicConfigWithourId
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> GetDynamicConfigWithourId(ePermitModel objUser)
        {
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    Check = 24,
                    CreatedBy=objUser.CreatedBy,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Fill District
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> FillDistrict(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    ACTION = "H",
                   
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USP_FILL_COMMON_DATA", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            DistrictId = Convert.ToInt32(dr.DistrictId.ToString()),
                            DistrictName = dr.DistrictName.ToString(),


                        });
                    }
                    ObjResult.DistrictLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Get payment head type
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitPaymentHead>> GetPaymentTypeHead(ePermitModel objUser)
        {
            List<ePermitPaymentHead> ObjUserTypeList = new List<ePermitPaymentHead>();
            try
            {
                var paramList = new
                {
                    Check = 26,
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitPaymentHead>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Save PAYMENT CONFIG
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> SaveDynamicPaymentConfig(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                
                p.Add("DistrictId", model.DistrictId);
                p.Add("ConfigType", model.RiderType);
                p.Add("MineralId", model.MineralId);
                p.Add("UserTypeId", model.UserTypeId);
                p.Add("LesseeId", model.LesseeId);
                p.Add("LeaseTypeId", model.LeaseTypeId);
                p.Add("GrantDate", model.DateOfGrant);
                p.Add("Location", model.Location);
                p.Add("MinesType", model.MinesTypeId);
                p.Add("CaptiveType", model.IsCaptive);
                p.Add("LeaseExtend", model.IsLeaseExtend);
                p.Add("IsAdditionalAmount", model.IsAdditionalAmt);
                p.Add("MineralTypeId", model.MineralTypeId);
                p.Add("MLGrantedDate", model.MLGrantedDate);
                p.Add("IsSchedule", model.IsSchedule);
                if(model.IsSchedule==1)
                p.Add("FifthSchId", model.FifthSchId);
                else if (model.IsSchedule == 2)
                    p.Add("SixthSchId", model.SixthSchId);
                p.Add("IsPremium", model.IsPremium);
                p.Add("CalTypeId", model.CalTypeId);
                p.Add("CalValue", model.CalculationValue);
                p.Add("UserID", model.UserID);
                DataTable dt = new DataTable("Payment");
                dt.Columns.Add("PaymentApplicable", typeof(System.Int32));
                dt.Columns.Add("ScheduleId", typeof(System.Int32));
                dt.Columns.Add("CalTypeId", typeof(System.Int32));
                dt.Columns.Add("PaymentPercent", typeof(System.Decimal));
                dt.Columns.Add("MakePayment", typeof(System.Int32));
               
                dt.Columns.Add("PaymentTypeId", typeof(System.Int32));
                dt.Columns.Add("PayDeptId", typeof(System.Int32));
                dt.Columns.Add("AdjustableId", typeof(System.Int32));
                for (int i=0;i<model.datatable.Count;i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["PaymentApplicable"] = model.datatable[i].IsPaymentApplicable;
                    dr["ScheduleId"] = model.datatable[i].IsSchedule;
                    dr["CalTypeId"] = model.datatable[i].CalTypeId;
                    dr["PaymentPercent"] = model.datatable[i].PaymentPercent;
                    dr["MakePayment"] = model.datatable[i].IsMakePayment;
                  
                    dr["PaymentTypeId"] = model.datatable[i].PaymentTypeId;
                    dr["PayDeptId"] = model.datatable[i].PayDeptId;
                    dr["AdjustableId"] = model.datatable[i].IsAdjustable;
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
                System.IO.StringWriter strw = new System.IO.StringWriter();
                dt.WriteXml(strw);
                string strXML = strw.ToString();
                strw.Close();
                strw.Dispose();
                p.Add("xmlData", strXML);
                p.Add("Check", 27);
                var result = await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
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
        /// Bind Dynamic payment
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> ViewDynamicPayment(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            try
            {
                var paramList = new
                {
                    Check = 28,
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    
                    ObjResult.DynamicPaymnetLst = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Bind Dynamic payment
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> DetailsDynamicPayment(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            try
            {
                var paramList = new
                {
                    Check = 37,
                    Id=objLease.PaymentConfigID,
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitPaymentHead>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjResult.PermitPaymentHead = result.ToList();
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Delete dynamic payment schedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteDynamicPaymentConfig(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Id", model.PaymentConfigID);
                p.Add("CreatedBy", model.UserID);
                p.Add("Check", 29);
                var result = await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
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
        /// Fill payment head type
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> FillPaymentHeadType(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    Check = 26,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            PaymentTypeId = Convert.ToInt32(dr.PaymentTypeId.ToString()),
                            PaymentType = dr.PaymentType.ToString(),


                        });
                    }
                    ObjResult.PaymnetHeadLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Fill payment dept  type
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> FillPaymentDept(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    Check = 30,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            PayDeptId = Convert.ToInt32(dr.PayDeptId.ToString()),
                            PaymentDept = dr.PaymentDept.ToString(),


                        });
                    }
                    ObjResult.PayDeptLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Fill schedule  type
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> FillScheduleType(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    Check = 31,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            ScheduleId = Convert.ToInt32(dr.ScheduleId.ToString()),
                            ScheduleText = dr.ScheduleText.ToString(),


                        });
                    }
                    ObjResult.ScheduleLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Save  schedule rate master
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> SaveScheduleRateMaster(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("ScheduleId", model.ScheduleId);
                p.Add("Description", model.Description);
                p.Add("AddtionalRate", model.AddtionalRate);
                p.Add("MineralId", model.MineralId);
                p.Add("MineralNatureId", model.MineralNatureId);
                p.Add("CreatedBy", model.UserID);
                p.Add("IsActive", model.IsActive);
                p.Add("Check", 32);
                var result = await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
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
        /// Update  schedule rate master
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateScheduleRateMaster(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("ScheduleId", model.ScheduleId);
                p.Add("Description", model.Description);
                p.Add("AddtionalRate", model.AddtionalRate);
                p.Add("MineralId", model.MineralId);
                p.Add("MineralNatureId", model.MineralNatureId);
                p.Add("CreatedBy", model.UserID);
                p.Add("IsActive", model.IsActive);
                p.Add("Id", model.ScheduleRateId);
                p.Add("Check", 33);
                var result = await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
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
        /// View  schedule rate master
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> ViewScheduleRateMaster(ePermitModel objUser)
        {
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,

                    Check = 34,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Get details for edit schedule rate master
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> EditScheduleRateMaster(ePermitModel objUser)
        {
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,
                    Id = objUser.ScheduleRateId,
                    Check = 35,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Delete  Schedule rate master
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteScheduleRateMaster(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Id", model.ScheduleRateId);
                p.Add("CreatedBy", model.UserID);
                p.Add("Check", 36);
                var result = await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
                }
            }
            catch (Exception ex)
            {
                objMessage.Satus = "-1";
                throw ex;
            }
            return objMessage;
        }

        public async Task<List<ePermitModel>> GetMineralCategory(ePermitModel objUser)
        {
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    Check = 38,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
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

        public ePermitModel GetPaymentDetails(ePermitModel objUser)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 40);
                param.Add("@Id", objUser.PaymentConfigID);

                var result = Connection.Query<ePermitModel>("USPDYNAMICPAYMENTCONFIG", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objUser = result.FirstOrDefault();
                }

                return objUser;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objUser = null;
            }
        }

        public async Task<MessageEF> UpdateDynamicPaymentConfig(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("DistrictId", model.DistrictId);
                p.Add("ConfigType", model.RiderType);
                p.Add("MineralId", model.MineralId);
                p.Add("UserTypeId", model.UserTypeId);
                p.Add("LesseeId", model.LesseeId);
                p.Add("LeaseTypeId", model.LeaseTypeId);
                p.Add("GrantDate", model.DateOfGrant);
                p.Add("Location", model.Location);
                p.Add("MinesType", model.MinesTypeId);
                p.Add("CaptiveType", model.IsCaptive);
                p.Add("LeaseExtend", model.IsLeaseExtend);
                p.Add("IsAdditionalAmount", model.IsAdditionalAmt);
                p.Add("MineralTypeId", model.MineralTypeId);
                p.Add("MLGrantedDate", model.MLGrantedDate);
                p.Add("Id", model.PaymentConfigID);
                p.Add("IsSchedule", model.IsSchedule);
                if (model.IsSchedule == 1)
                    p.Add("FifthSchId", model.FifthSchId);
                else if (model.IsSchedule == 2)
                    p.Add("SixthSchId", model.SixthSchId);
                p.Add("IsPremium", model.IsPremium);
                p.Add("CalTypeId", model.CalTypeId);
                p.Add("CalValue", model.CalculationValue);
                p.Add("UserID", model.UserID);
                DataTable dt = new DataTable("Payment");
                dt.Columns.Add("PaymentApplicable", typeof(System.Int32));
                dt.Columns.Add("ScheduleId", typeof(System.Int32));
                dt.Columns.Add("CalTypeId", typeof(System.Int32));
                dt.Columns.Add("PaymentPercent", typeof(System.Decimal));
                dt.Columns.Add("MakePayment", typeof(System.Int32));

                dt.Columns.Add("PaymentTypeId", typeof(System.Int32));
                dt.Columns.Add("PayDeptId", typeof(System.Int32));
                dt.Columns.Add("AdjustableId", typeof(System.Int32));
                for (int i = 0; i < model.datatable.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["PaymentApplicable"] = model.datatable[i].IsPaymentApplicable;
                    dr["ScheduleId"] = model.datatable[i].IsSchedule;
                    dr["CalTypeId"] = model.datatable[i].CalTypeId;
                    dr["PaymentPercent"] = model.datatable[i].PaymentPercent;
                    dr["MakePayment"] = model.datatable[i].IsMakePayment;

                    dr["PaymentTypeId"] = model.datatable[i].PaymentTypeId;
                    dr["PayDeptId"] = model.datatable[i].PayDeptId;
                    dr["AdjustableId"] = model.datatable[i].IsAdjustable;
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
                System.IO.StringWriter strw = new System.IO.StringWriter();
                dt.WriteXml(strw);
                string strXML = strw.ToString();
                strw.Close();
                strw.Dispose();
                p.Add("xmlData", strXML);
                p.Add("Check", 42);
                var result = await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
                }
            }
            catch (Exception ex)
            {
                objMessage.Satus = "-1";
                throw ex;
            }
            return objMessage;
        }
    }
}
