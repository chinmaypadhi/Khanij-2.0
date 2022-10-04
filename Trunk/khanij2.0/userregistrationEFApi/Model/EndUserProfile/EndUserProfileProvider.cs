using Dapper;
using MasterApi.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;
using userregistrationEFApi.Utility;

namespace userregistrationEFApi.Model.EndUserProfile
{
    public class EndUserProfileProvider : RepositoryBase, IEndUserProfileProvider
    {
        public EndUserProfileProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<Result<List<EndUserProfileViewModel>>> ViewProfile(EndUserProfileViewModel endUserProfile)
        {
            //EndUserProfileViewModel endUserProfileViewModel = new EndUserProfileViewModel();
            Result<List<EndUserProfileViewModel>> result = new Result<List<EndUserProfileViewModel>>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("ProfileUserId", endUserProfile.UserId);
                param.Add("Check", "1");
                var res= await Connection.QueryAsync<EndUserProfileViewModel>("uspEndUser", param, commandType: System.Data.CommandType.StoredProcedure);
                if (res.Count() > 0)
                {
                    result.Data = res.ToList();
                    result.Status = true;
                    result.Message = new List<string>() { "Successfull!" };
                }
                else
                {
                    result.Data = null;
                    result.Status = false;
                    result.Message = new List<string>() { "Failed!" };

                }
                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return result;
            }
        }
        public async Task<EndUserModel> EditEndUserProfile(EndUserModel endUserProfile)
        {
            EndUserModel endUserProfileViewModel = new EndUserModel();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("ProfileId", endUserProfile.UserId);
                param.Add("DispatchId",endUserProfile.DispatchId);
                var result = await Connection.QueryAsync<EndUserModel>("uspSelectEndUserData", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    endUserProfileViewModel = result.FirstOrDefault();
                }
                return endUserProfileViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<MessageEF> UpdateEndUserProfile(EndUserModel objER)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Mode", "FORWARD PROFILE");
                p.Add("TransactionDate", DateTime.Now);
                p.Add("TransactionType", "NEW");
                p.Add("IsCompleted", 0);

                p.Add("EndUserId", objER.EndUserId);
                p.Add("EndUserName", objER.ApplicantName);
                p.Add("CompanyName", objER.CompanyName);
                p.Add("BussinessActivity", objER.BussinessActivity);
                //p.Add("UserTypeId", objER.UserTypeId);
                //p.Add("UserType", objER.UserType);
                p.Add("Designation", objER.Designation);
                p.Add("Address", objER.Address);
                p.Add("OfficeAddress", objER.OfficeAddress);

                p.Add("DistrictId", objER.DistrictId);
                p.Add("StateId", objER.StateId);
                p.Add("PinCode", objER.PinCode);

                p.Add("DistrictId_O", objER.DistrictId_O);
                p.Add("StateId_O", objER.StateId_O);
                p.Add("PinCode_O", objER.PinCode_O);

                p.Add("ExciseRegNo", objER.ExciseRegNo);
                p.Add("Pop_Mineral", objER.PurposeOfPurchaseMineral);
                p.Add("SQAns", objER.SQAnswer);
                p.Add("AddedBy", objER.UserId);
                p.Add("AddedOn", DateTime.Now);
                p.Add("EndUserTypeStatus", objER.EndUserTypeStatus);
                //p.Add("UpdatedBy", objER.UpdatedBy);                
                p.Add("AadhaarNo", objER.AadhaarNumber);
                p.Add("Firm", objER.Firm);
                p.Add("Company", objER.Company);
                p.Add("UserCode", objER.UserCode);
                p.Add("UserName", objER.UserName);
                p.Add("Password", objER.Password);
                p.Add("MobileNo", objER.MobileNo);
                p.Add("EMailId", objER.EMailId);
                p.Add("SecurityQueID", objER.SQuestionId);
                p.Add("TransactionalId", objER.TransactionalID);
                p.Add("GSTNO", objER.GSTNO);
                p.Add("PAN", objER.PAN);
                p.Add("PANPath", objER.PANPath);
                p.Add("SecurityQue", objER.SQuestion);

                if (objER.TINNo != "")
                {
                    p.Add("TINNo", objER.TINNo);
                }

                if (objER.MineralId != "")
                {
                    p.Add("MineralCount", objER.MineralCnt);
                    p.Add("MineralID", objER.MineralId);
                }

                if (objER.MineralFormId != "")
                {
                    p.Add("MineralFormCount", objER.MineralFormCnt);
                    p.Add("MineralFormID", objER.MineralFormId);
                }
                if (objER.MineralGradeId != "")
                {
                    p.Add("MineralGradeCount", objER.MineralGradeCnt);
                    p.Add("MineralGradeID", objER.MineralGradeId);
                }
                //p.Add("ChallanNumber", objER.ChallanNumber);
                //p.Add("ChallanDate", objER.ChallanDate);
                //p.Add("Doc", objER.Doc);
                p.Add("UserLoginId", objER.UserId);
                p.Add("RegFees", objER.RegistrationFees);
                //p.Add("RegistrationFeesId", objER.RegistrationFeesId);
                p.Add("NatureOfBusiness", objER.NatureOfBusiness);
                p.Add("EUPTypeId", objER.EUPTypeId);
                p.Add("MineralUse", objER.MineralUse);


                p.Add("Aadhaar_FILE_PATH", objER.Aadhaar_FILE_PATH);
                p.Add("Aadhaar_FILE_NAME", objER.Aadhaar_FILE_NAME);

                p.Add("PAN_FILE_PATH", objER.PAN_FILE_PATH);
                p.Add("PAN_FILE_NAME", objER.PAN_FILE_NAME);

                p.Add("TIN_FILE_PATH", objER.TIN_FILE_PATH);
                p.Add("TIN_FILE_NAME", objER.TIN_FILE_NAME);

                p.Add("GST_FILE_PATH", objER.GST_FILE_PATH);
                p.Add("GST_FILE_NAME", objER.GST_FILE_NAME);

                p.Add("CTO_FILE_PATH", objER.CTO_FILE_PATH);
                p.Add("CTO_FILE_NAME", objER.CTO_FILE_NAME);

                p.Add("ProductionCertificate_FILE_PATH", objER.ProductionCertificate_FILE_PATH);
                p.Add("ProductionCertificate_FILE_NAME", objER.ProductionCertificate_FILE_NAME);

                p.Add("ElectricityBill_FILE_PATH", objER.ElectricityBill_FILE_PATH);
                p.Add("ElectricityBill_FILE_NAME", objER.ElectricityBill_FILE_NAME);

                p.Add("RegistrationCopy_FILE_PATH", objER.RegistrationCopy_FILE_PATH);
                p.Add("RegistrationCopy_FILE_NAME", objER.RegistrationCopy_FILE_NAME);

                p.Add("CTOApprovalNumber", objER.CTOApprovalNumber);

                if (!string.IsNullOrEmpty(objER.CTOOrderDate))
                {
                    p.Add("CTOOrderDate", DateTimeStandard.SetDateFormat(objER.CTOOrderDate));
                }
                else { p.Add("CTOOrderDate", DateTime.Now); }
                if (!string.IsNullOrEmpty(objER.CTOValidityFrom))
                {
                    p.Add("CTOValidityFrom", DateTimeStandard.SetDateFormat(objER.CTOValidityFrom));
                }
                else { p.Add("CTOValidityFrom", DateTime.Now); }
                if (!string.IsNullOrEmpty(objER.CTOValidityTo))
                {
                    p.Add("CTOValidityTo", DateTimeStandard.SetDateFormat(objER.CTOValidityTo));
                }
                else { p.Add("CTOValidityTo", DateTime.Now); }
                p.Add("RegistrationNo","");
                p.Add("IBMRegistrationNo", objER.IBMRegistrationNo);
                p.Add("Other_IndustryType", objER.Other_IndustryType);
               // p.Add("IsExisting", 0);
               // p.Add("IsApprove", 0);
               // p.Add("IsForwarded", 1);
                p.Add("Remarks", objER.Remarks);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result= await Connection.ExecuteScalarAsync<int>("uspEndUserProfileVerification", p, commandType: CommandType.StoredProcedure);
                //int newID = p.Get<int>("result");

                //string response = newID.ToString();

                objMessage.Satus = result.ToString();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
    }
}
