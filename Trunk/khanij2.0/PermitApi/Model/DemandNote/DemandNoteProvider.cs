// ***********************************************************************
//  Class Name               : DemandNoteProvider
//  Desciption               : Demand & Credit Note summary data Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 12 July 2021
// ***********************************************************************
using Dapper;
using PermitApi.Factory;
using PermitApi.Repository;
using PermitEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApi.Model.DemandNote
{
    public class DemandNoteProvider : RepositoryBase, IDemandNoteProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public DemandNoteProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Bind Demand note summary data details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public async Task<List<DemandNoteCodePayment>> getDemandNoteSummaryData(DemandNoteCodePayment objmodel)
        {
            List<DemandNoteCodePayment> objlist = new List<DemandNoteCodePayment>();
            try
            {
                var paramList = new
                {
                    UserId = objmodel.UserID,
                    FromDate = objmodel.FromDate,
                    ToDate = objmodel.ToDate
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<DemandNoteCodePayment>("uspGetDemandNoteDataViaDemandNoteCode", paramList, commandType: System.Data.CommandType.StoredProcedure);
                objlist = result.ToList();
                return objlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Bind Credit note summary data details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public async Task<List<DemandNoteCodePayment>> getCreditNoteSummaryData(DemandNoteCodePayment objmodel)
        {
            List<DemandNoteCodePayment> objlist = new List<DemandNoteCodePayment>();
            try
            {
                var paramList = new
                {
                    Check="1",
                    UserId = objmodel.UserID,
                    FromDate = objmodel.FromDate,
                    ToDate = objmodel.ToDate
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<DemandNoteCodePayment>("uspGetDemandNoteDataViaDemandNoteCode", paramList, commandType: System.Data.CommandType.StoredProcedure);
                objlist = result.ToList();
                return objlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// Bind Credit note summary data details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public async Task<List<DemandNoteCodePayment>> viewPaymentDetails(DemandNoteCodePayment objmodel)
        {
            List<DemandNoteCodePayment> objlist = new List<DemandNoteCodePayment>();
            try
            {
                var paramList = new
                {
                 SpMode="GET_TRANSACTIONID_Status",
                 DemandNoteCode= objmodel.DemandNoteCode,
                 UserId= objmodel.UserID
            };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<DemandNoteCodePayment>("uspGetDemandNotePaymentList", paramList, commandType: System.Data.CommandType.StoredProcedure);
                objlist = result.ToList();
                return objlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// Bind Credit note summary data details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public async Task<List<DemandNotePaymentModel>> viewPaymentDetailsData(DemandNoteCodePayment objmodel)
        {
            List<DemandNotePaymentModel> objlist = new List<DemandNotePaymentModel>();
            try
            {
                var paramList = new
                {
                    DemandNoteCode = objmodel.DemandNoteCode,
                    UserId = objmodel.UserID,
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<DemandNotePaymentModel>("uspGetDemandNoteDataViaDemandNoteCode_Details", paramList, commandType: System.Data.CommandType.StoredProcedure);
                objlist = result.ToList();
                return objlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<DemandNoteCodePayment>> viewCreditNoteSummaryData(DemandNoteCodePayment objmodel)
        {
            List<DemandNoteCodePayment> objlist = new List<DemandNoteCodePayment>();
            try
            {
                var paramList = new
                {
                    UserId = objmodel.UserID,
                    Check = 1,
                    FromDate = objmodel.FromDate,
                    ToDate = objmodel.ToDate,
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<DemandNoteCodePayment>("uspGetDemandNoteDataViaDemandNoteCode", paramList, commandType: System.Data.CommandType.StoredProcedure);
                objlist = result.ToList();
                return objlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<List<CreditAmountModel>> viewCreditAmountData(DemandNoteCodePayment objmodel)
        {
            List<CreditAmountModel> objlist = new List<CreditAmountModel>();
            try
            {
                var paramList = new
                {
                    UserId = objmodel.UserID,
                    chk = 1,                    
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<CreditAmountModel>("CreditAmountOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                objlist = result.ToList();
                return objlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public MessageEF AddCreditAmount(CreditAmountModel objins)
        {
            MessageEF msg = new MessageEF();
            try
            {
                var P = new DynamicParameters();
                P.Add("@chk", 2);
                P.Add("@PaymentHeadTypeID", objins.PaymentTypeHeadId);
                P.Add("@UserId", objins.LesseeId);
                P.Add("@Ammount", objins.CreditedAmmount);
                P.Add("@UploadCopy", objins.AssessmentCopyName);
                P.Add("@UploadPath", objins.AssessmentCopyPath);
                P.Add("@CreatedBy", objins.UserId);
                P.Add("@UserLoginId", objins.UserLoginId);


                //P.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
               var a = Connection.Query<int>("CreditAmountOperation", P, commandType: CommandType.StoredProcedure).ToList();
                  msg.Msg = a[0].ToString();
                //int newID = P.Get<int>("Result");
                //string response = newID.ToString();
                //msg.Satus = response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msg;
        }


        public async Task<List<CreditAmountModel>> viewPaymentType(DemandNoteCodePayment objmodel)
        {
            List<CreditAmountModel> objlist = new List<CreditAmountModel>();
            try
            {
                var paramList = new
                {
                    UserId = objmodel.UserID,
                    
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<CreditAmountModel>("uspGetPaymentType", paramList, commandType: System.Data.CommandType.StoredProcedure);
                objlist = result.ToList();
                return objlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<CreditAmountModel>> viewLesseeName(DemandNoteCodePayment objmodel)
        {
            List<CreditAmountModel> objlist = new List<CreditAmountModel>();
            try
            {
                var paramList = new
                {
                    UserId = objmodel.UserID,
                    UserTypeId=7,
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<CreditAmountModel>("uspGetUserByUserType", paramList, commandType: System.Data.CommandType.StoredProcedure);
                objlist = result.ToList();
                return objlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
   

        public MessageEF VerifyDemandNoteS(objDemandListData objins)
        {
            MessageEF msg = new MessageEF();
            try
            {
            
                for (int x = 0; x < objins.objDemandListDataVal.Count; x++)
                {
                    var P = new DynamicParameters();
                    P.Add("@UserId", objins.UserID);
                    P.Add("@DemandNoteCode", objins.objDemandListDataVal[x].DemandNoteCode);
                   var a = Connection.Query<int>("uspVerifyDemandCreditNote", P, commandType: CommandType.StoredProcedure).ToList();
                    msg.Msg = a[x].ToString();
                }
               
            }
            catch (Exception ex)
            {
                msg.Msg = 0.ToString();
                throw ex;
            }
            return msg;
        }



    }
}
