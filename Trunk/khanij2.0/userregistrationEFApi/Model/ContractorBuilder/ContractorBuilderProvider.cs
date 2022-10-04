using Dapper;
using MasterApi.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.ContractorBuilder
{
    public class ContractorBuilderProvider : RepositoryBase, IContractorBuilderProvider
    {
        public ContractorBuilderProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        /// <summary>
        /// Add Contractor Builder
        /// </summary>
        /// <param name="contractorBuilderModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddContractorBuilder(ContractorBuilderModel contractorBuilderModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {


                var p = new DynamicParameters();
                p.Add("@Chk", 1);
                p.Add("@ContractorBuilderId", contractorBuilderModel.ContractorBuilderId);
                p.Add("@RegistrationType", contractorBuilderModel.RegistrationType);
                p.Add("@ContractorBuilderName", contractorBuilderModel.ContractorBuilderName);
                p.Add("@MobileNumber", contractorBuilderModel.MobileNumber);
                p.Add("@EmailId", contractorBuilderModel.EmailId);
                p.Add("@ContractorBuilderAddress", contractorBuilderModel.ContractorBuilderAddress);
                p.Add("@StateId", contractorBuilderModel.StateId);
                p.Add("@DistrictId", contractorBuilderModel.DistrictId);
                p.Add("@PINCode", contractorBuilderModel.PINCode);
                p.Add("@IDProofType", contractorBuilderModel.IDProofType);
                p.Add("@IDProofNumber", contractorBuilderModel.IDProofNumber);
                p.Add("@UploadIDProof", contractorBuilderModel.UploadIDProof);
                p.Add("@UploadIDProofPath", contractorBuilderModel.UploadIDProofPath);
                p.Add("@RERARegistrationNo", contractorBuilderModel.RERARegistrationNo);
                p.Add("@UploadRERARegistration", contractorBuilderModel.UploadRERARegistration);
                p.Add("@UploadRERARegistrationPath", contractorBuilderModel.UploadRERARegistrationPath);
                p.Add("@RegistrationNo", contractorBuilderModel.RegistrationNo);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("uspInsertContractorBuilderUserData", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");

                string response = newID.ToString();
                objMessage.Satus = response;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Edit Contractor Builder
        /// </summary>
        /// <param name="contractorBuilderModel"></param>
        /// <returns></returns>
        //public async Task<MessageEF> EditContractorBuilder(ContractorBuilderModel contractorBuilderModel)
        //{
        //    MessageEF objMessage = new MessageEF();
        //    try
        //    {


        //        var p = new DynamicParameters();
        //        p.Add("@Chk", 2);
        //        p.Add("@ContractorBuilderId", contractorBuilderModel.ContractorBuilderId);
        //        //p.Add("@ContractorBuilderName", contractorBuilderModel.ContractorBuilderName);
        //        //p.Add("@MobileNumber", contractorBuilderModel.MobileNumber);
        //        p.Add("@EmailId", contractorBuilderModel.EmailId);
        //        p.Add("@ContractorBuilderAddress", contractorBuilderModel.ContractorBuilderAddress);
        //        p.Add("@StateId", contractorBuilderModel.StateId);
        //        p.Add("@DistrictId", contractorBuilderModel.DistrictId);
        //        p.Add("@PINCode", contractorBuilderModel.PINCode);
        //        //p.Add("@IDProofType", contractorBuilderModel.IDProofType);
        //        //p.Add("@IDProofNumber", contractorBuilderModel.IDProofNumber);
        //        //p.Add("@UploadIDProof", contractorBuilderModel.UploadIDProof);
        //        //p.Add("@UploadIDProofPath", contractorBuilderModel.UploadIDProofPath);
        //        //p.Add("@RERARegistrationNo", contractorBuilderModel.RERARegistrationNo);
        //        //p.Add("@UploadRERARegistration", contractorBuilderModel.UploadRERARegistration);
        //        //p.Add("@UploadRERARegistrationPath", contractorBuilderModel.UploadRERARegistrationPath);
        //        //p.Add("@RegistrationNo", contractorBuilderModel.RegistrationNo);
        //        p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        await Connection.QueryAsync<int>("uspInsertContractorBuilderUserData", p, commandType: CommandType.StoredProcedure);
        //        int newID = p.Get<int>("result");

        //        string response = newID.ToString();
        //        objMessage.Satus = response;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    return objMessage;
        //}
        /// <summary>
        /// Get Contractor Builder User Details By UserId
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        public async Task<ContractorBuilderModel> GetContractorBuilderUserDetailsByUserId(ContractorBuilderModel contractorBuilderModel)
        {
            try
            {
                var paramList = new { ProfileUserId = contractorBuilderModel.UserId, Check = 1 };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<ContractorBuilderModel>("uspContractorBuilderUser", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    contractorBuilderModel = result.FirstOrDefault();
                }
                return contractorBuilderModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                contractorBuilderModel = null;
            }
        }

        /// <summary>
        /// Edit Contractor Builder
        /// </summary>
        /// <param name="contractorBuilderModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> EditContractorBuilder(ContractorBuilderModel contractorBuilderModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {


                var p = new DynamicParameters();
                p.Add("@Chk", 2);
                p.Add("@ContractorBuilderId", contractorBuilderModel.ContractorBuilderId);
                p.Add("@ContractorBuilderName", contractorBuilderModel.ContractorBuilderName);
                p.Add("@MobileNumber", contractorBuilderModel.MobileNumber);
                p.Add("@EmailId", contractorBuilderModel.EmailId);
                p.Add("@ContractorBuilderAddress", contractorBuilderModel.ContractorBuilderAddress);
                p.Add("@StateId", contractorBuilderModel.StateId);
                p.Add("@DistrictId", contractorBuilderModel.DistrictId);
                p.Add("@PINCode", contractorBuilderModel.PINCode);
                //p.Add("@IDProofType", contractorBuilderModel.IDProofType);
                //p.Add("@IDProofNumber", contractorBuilderModel.IDProofNumber);
                //p.Add("@UploadIDProof", contractorBuilderModel.UploadIDProof);
                //p.Add("@UploadIDProofPath", contractorBuilderModel.UploadIDProofPath);
                //p.Add("@RERARegistrationNo", contractorBuilderModel.RERARegistrationNo);
                //p.Add("@UploadRERARegistration", contractorBuilderModel.UploadRERARegistration);
                //p.Add("@UploadRERARegistrationPath", contractorBuilderModel.UploadRERARegistrationPath);
                //p.Add("@RegistrationNo", contractorBuilderModel.RegistrationNo);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("uspInsertContractorBuilderUserData", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");

                string response = newID.ToString();
                objMessage.Satus = response;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
    }
}
