using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.PaymentHead
{
    public class SinglePaymentHeadProvider : RepositoryBase, ISinglePaymentHeadProvider
    {
        public SinglePaymentHeadProvider(IConnectionFactory connectionFactory):base(connectionFactory)
        {

        }

        #region Add
        public MessageEF AddSinglePaymentHead(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            { 

                var p = new DynamicParameters();
                p.Add("@Check", 1);
                p.Add("@PaymentTypeId", singlePaymentHeadModel.PaymentTypeId);
                p.Add("@AccountType", singlePaymentHeadModel.AccountType);
                p.Add("@DistrictID", singlePaymentHeadModel.DistrictId);
                p.Add("@HeadOFAccount", singlePaymentHeadModel.HeadOFAccount);
                p.Add("@SBISchemeCode", singlePaymentHeadModel.SBISchemeCode);
                p.Add("@HDFCSchemeCode", singlePaymentHeadModel.HDFCSchemeCode);
                p.Add("@ICICISchemeCode", singlePaymentHeadModel.ICICISchemeCode);
                p.Add("@UserID", singlePaymentHeadModel.CreatedBy); 
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("UspForPaymentHeadMaster", p, commandType: CommandType.StoredProcedure);
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

        #region Delete
        public MessageEF DeleteSinglePaymentHead(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            { 

                object[] objArray = new object[] {
                        "@PaymentHeadId",singlePaymentHeadModel.PaymentHeadId,
                        "@Check",singlePaymentHeadModel.Check,
                        "@userID",singlePaymentHeadModel.CreatedBy,
                        "@AccountType",singlePaymentHeadModel.AccountType
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("UspForPaymentHeadMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
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
        public SinglePaymentHeadModel EditSinglePaymentHead(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            try
            { 

                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@PaymentHeadId", singlePaymentHeadModel.PaymentHeadId);

                var result = Connection.Query<SinglePaymentHeadModel>("USPGetPaymentHead", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    singlePaymentHeadModel = result.FirstOrDefault();
                }

                return singlePaymentHeadModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                singlePaymentHeadModel = null;
            }
        }
         
        #endregion

        #region Update
        public MessageEF UpdateSinglePaymentHead(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@Check", 2);
                p.Add("@PaymentHeadId", singlePaymentHeadModel.PaymentHeadId);
                p.Add("@PaymentTypeId", singlePaymentHeadModel.PaymentTypeId);
                p.Add("@AccountType", singlePaymentHeadModel.AccountType);
                p.Add("@DistrictID", singlePaymentHeadModel.DistrictId);
                p.Add("@HeadOFAccount", singlePaymentHeadModel.HeadOFAccount);
                p.Add("@SBISchemeCode", singlePaymentHeadModel.SBISchemeCode);
                p.Add("@HDFCSchemeCode", singlePaymentHeadModel.HDFCSchemeCode);
                p.Add("@ICICISchemeCode", singlePaymentHeadModel.ICICISchemeCode);
                p.Add("@UserID", singlePaymentHeadModel.CreatedBy);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("UspForPaymentHeadMaster", p, commandType: CommandType.StoredProcedure);
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
        public List<SinglePaymentHeadModel> ViewSinglePaymentHead(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            List<SinglePaymentHeadModel> listSinglePaymentHeadModel = new List<SinglePaymentHeadModel>(); 
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", singlePaymentHeadModel.Check);
                var result = Connection.Query<SinglePaymentHeadModel>("USPGetPaymentHead", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                { 
                    listSinglePaymentHeadModel = result.ToList();
                }

                return listSinglePaymentHeadModel; 
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listSinglePaymentHeadModel = null;
            }
        }

        public List<SinglePaymentHeadModel> GetDistrict(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            List<SinglePaymentHeadModel> listDistrict = new List<SinglePaymentHeadModel>();


            try
            {

                DynamicParameters param = new DynamicParameters(); 
                var result = Connection.Query<SinglePaymentHeadModel>("GetDistrict", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listDistrict = result.ToList();
                }

                return listDistrict;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listDistrict = null;
            }
        }

        public List<SinglePaymentHeadModel> GetHeadData(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            List<SinglePaymentHeadModel> listSinglePaymentHeadModel = new List<SinglePaymentHeadModel>(); 
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 3);
                param.Add("@AccountType", singlePaymentHeadModel.AccountType);
                var result = Connection.Query<SinglePaymentHeadModel>("USPGetPaymentHead", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    listSinglePaymentHeadModel = result.ToList(); 

                }

                return listSinglePaymentHeadModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listSinglePaymentHeadModel = null;
            }
        }
        #endregion
    }
}
