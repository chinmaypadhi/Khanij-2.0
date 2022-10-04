// ***********************************************************************
//  Class Name               : PaymentTypeMasterProvider
//  Description              : Add,View,Edit,Update,Delete Payment Type details
//  Created By               : Debaraj Swain
//  Created On               : 08 Jan 2021
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace MasterApi.Model.PaymentTypeMaster
{
    public class PaymentTypeMasterProvider : RepositoryBase, IPaymentTypeMasterProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public PaymentTypeMasterProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        public MessageEF AddPaymentTypeMaster(PaymenttypeMaster objPaymentTypemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("PaymentTypeId", objPaymentTypemaster.PaymentTypeId);
                p.Add("PaymentType", objPaymentTypemaster.PaymentType);
                p.Add("UserID", objPaymentTypemaster.CreatedBy);
                p.Add("IsActive", objPaymentTypemaster.IsActive);
                p.Add("RoyaltyMapping", objPaymentTypemaster.RoyaltyMaping);
                p.Add("OnlinePayment", objPaymentTypemaster.IsOnline);
                p.Add("Chk", "1");
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("InsertUpdatePaymentTypeMaster", p, commandType: CommandType.StoredProcedure);
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
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// View Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        public List<PaymenttypeMaster> ViewPaymentTypeMaster(PaymenttypeMaster objPaymentTypemaste)
        {
            List<PaymenttypeMaster> ListPaymenttypeMaster = new List<PaymenttypeMaster>();
            try
            {
                var paramList = new
                {
                    PaymentType = objPaymentTypemaste.PaymentType,
                    Chk = "0",
                };
                var result = Connection.Query<PaymenttypeMaster>("InsertUpdatePaymentTypeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListPaymenttypeMaster = result.ToList();
                }
                return ListPaymenttypeMaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListPaymenttypeMaster = null;
            }



        }
        /// <summary>
        /// Edit Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        public PaymenttypeMaster EditPaymentTypemaster(PaymenttypeMaster objPaymentTypemaste)
        {
            PaymenttypeMaster LobjPaymenttypeMaster = new PaymenttypeMaster();


            try
            {
                var paramList = new
                {
                    PaymentTypeId = objPaymentTypemaste.PaymentTypeId,
                    Chk = "4",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<PaymenttypeMaster>("InsertUpdatePaymentTypeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjPaymenttypeMaster = result.FirstOrDefault();
                }

                return LobjPaymenttypeMaster;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// Delete Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        public MessageEF DeletePaymentTypemaster(PaymenttypeMaster objPaymentTypemaste)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "PaymentTypeId",objPaymentTypemaste.PaymentTypeId,
                        "Chk",3
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("Result");
                var result = Connection.Query<string>("InsertUpdatePaymentTypeMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("Result");
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
        /// <summary>
        /// Update Payment Type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        public MessageEF UpdatePaymentTypemaster(PaymenttypeMaster objPaymentTypemaste)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("PaymentTypeId", objPaymentTypemaste.PaymentTypeId);
                p.Add("PaymentType", objPaymentTypemaste.PaymentType);
                p.Add("UserID", objPaymentTypemaste.CreatedBy);
                p.Add("IsActive",objPaymentTypemaste.IsActive);
                p.Add("RoyaltyMapping", objPaymentTypemaste.RoyaltyMaping);
                p.Add("OnlinePayment", objPaymentTypemaste.IsOnline);
                p.Add("Chk", "2");
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("InsertUpdatePaymentTypeMaster", p, commandType: CommandType.StoredProcedure);
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
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;

        }
    }
}
