using Dapper;
using MasterApi.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.TailingDam
{
    public class TailingDamProvider : RepositoryBase, ITailingDamProvider
    {
        public TailingDamProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        /// <summary>
        /// Add TailingDam
        /// </summary>
        /// <param name="tailingDam"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddTailingDam(cls_TailingDam tailingDam)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters(); 
                param.Add("@Mode", 2);
                param.Add("@ApplicantName", tailingDam.OwnerName);
                param.Add("@Designation", tailingDam.Designation);
                param.Add("@CompleteAddress", tailingDam.Address);
                param.Add("@MobileNo", tailingDam.MobileNo);
                param.Add("@EmailAddress", tailingDam.EmailID);
                param.Add("@Location", tailingDam.Location);
                param.Add("@Area", tailingDam.Area);
                param.Add("@CompanyId", tailingDam.CompanyId);
                param.Add("@DistrictID", tailingDam.DistrictId);
                param.Add("@TehsilID", tailingDam.TehsilId);
                param.Add("@VillageID", tailingDam.VillageId);
                param.Add("@MineralID", tailingDam.MineralId);
                param.Add("@MineralNatureID", tailingDam.MineralFormId);
                param.Add("@MineralGradeID", tailingDam.MineralGradeId);
                param.Add("@CurrentStock", tailingDam.CurrentStock);
                param.Add("@TypeOfSite", tailingDam.TypeOfSite);
                param.Add("@TailingCopyPath", tailingDam.TailingCopyPath);
                param.Add("@OrderNo", tailingDam.OrderNo);
                param.Add("@OrderDate", tailingDam.OrderDate);
                param.Add("@EncryptPassword", tailingDam.s1);
                param.Add("@ExistingUserName", tailingDam.ApplicantName);
                param.Add("@ExistingUserId", tailingDam.UserId);
                param.Add("@ExistingUserTypeId", tailingDam.UserTypeId);
                object result = await Connection.ExecuteScalarAsync("SP_GET_TailingDam_InitialLoad", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = result.ToString();
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Company List
        /// </summary>
        /// <param name="companyDetails"></param>
        /// <returns></returns>
        public async Task<List<CompanyDetails>> GetCompanyList(CompanyDetails companyDetails)
        {
            List<CompanyDetails> lstCompanyDetails = new List<CompanyDetails>();
            try
            {
                var paramList = new { };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<CompanyDetails>("select CompanyId,CompanyName from CompanyMaster where status=1", paramList, commandType: System.Data.CommandType.Text);

                if (result.Count() > 0)
                {
                    lstCompanyDetails = result.ToList();
                }
                return lstCompanyDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstCompanyDetails = null;
            }
        }

        /// <summary>
        /// Get State District List
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        public async Task<List<CommonAddressDetails>> GetStateDistrictList(CommonAddressDetails commonAddressDetails)
        {
            List<CommonAddressDetails> lstCommonAddressDetails = new List<CommonAddressDetails>();
            try
            {
                var paramList = new { };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<CommonAddressDetails>("GetDistrictDataForUser", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    lstCommonAddressDetails = result.ToList();
                }
                return lstCommonAddressDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstCommonAddressDetails = null;
            }
        }

        /// <summary>
        /// Get Tehsil List By DistrictID
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        public async Task<List<CommonAddressDetails>> GetTehsilListByDistrictID(CommonAddressDetails commonAddressDetails)
        {
            List<CommonAddressDetails> lstCommonAddressDetails = new List<CommonAddressDetails>();
            try
            {
                var paramList = new { };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<CommonAddressDetails>("SELECT TehsilID,TehsilName FROM TehsilMaster where DistrictID='" + commonAddressDetails.DistrictID + "'", paramList, commandType: System.Data.CommandType.Text);

                if (result.Count() > 0)
                {
                    lstCommonAddressDetails = result.ToList();
                }
                return lstCommonAddressDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstCommonAddressDetails = null;
            }
        }

        /// <summary>
        /// Get village From TehsilID
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        public async Task<List<CommonAddressDetails>> GetvillageFromTehsilID(CommonAddressDetails commonAddressDetails)
        {
            List<CommonAddressDetails> lstCommonAddressDetails = new List<CommonAddressDetails>();
            try
            {
                var paramList = new { };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<CommonAddressDetails>("SELECT VM.TehsilID,VM.VillageID,VM.VillageName from  VillageMaster VM join TehsilMaster TM on VM.TehsilID=TM.TehsilID where VM.TehsilID ='" + commonAddressDetails.TehsilID + "' AND VM.IsActive=1", paramList, commandType: System.Data.CommandType.Text);

                if (result.Count() > 0)
                {
                    lstCommonAddressDetails = result.ToList();
                }
                return lstCommonAddressDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstCommonAddressDetails = null;
            }
        }

        /// <summary>
        /// Get Type Of Site List
        /// </summary>
        /// <param name="messageEF"></param>
        /// <returns></returns>
        public async Task<List<TypeOfSite>> GetTypeOfSiteList(MessageEF messageEF)
        {
            List<TypeOfSite> lstTypeOfSite = new List<TypeOfSite>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Mode", 9);
                var result = await Connection.QueryAsync<TypeOfSite>("SP_GET_TailingDam_InitialLoad", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    lstTypeOfSite = result.ToList();
                }
                return lstTypeOfSite;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstTypeOfSite = null;
            }
        }

        /// <summary>
        /// Get MineralType List_TailingDam
        /// </summary>
        /// <param name="mineralType"></param>
        /// <returns></returns>
        public async Task<List<MineralType>> GetMineralTypeList_TailingDam(MineralType mineralType)
        {
            List<MineralType> lstMineralType = new List<MineralType>();
            try
            {
                lstMineralType.Add(new MineralType() { Text = "Major Mineral", Value = "1" });
                return await Task.FromResult(lstMineralType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstMineralType = null;
            }
        }

        /// <summary>
        /// Get Mineral Name By MineralTypeId
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetCascadeMineral(MineralDetails mineralDetails)
        {
            List<MineralDetails> lstMineralDetails = new List<MineralDetails>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Mode", 6);
                param.Add("@MineralTypeID", mineralDetails.MineralTypeId);
                var result = await Connection.QueryAsync<MineralDetails>("SP_GET_TailingDam_InitialLoad", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    lstMineralDetails = result.ToList();
                }
                return lstMineralDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstMineralDetails = null;
            }
        }

        /// <summary>
        /// Get Cascade MineralNature
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetCascadeMineralNature(MineralDetails mineralDetails)
        {
            List<MineralDetails> lstMineralDetails = new List<MineralDetails>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Mode", 4);
                param.Add("@MineralId", mineralDetails.MineralID);
                var result = await Connection.QueryAsync<MineralDetails>("SP_GET_TailingDam_InitialLoad", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    lstMineralDetails = result.ToList();
                }
                return lstMineralDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstMineralDetails = null;
            }
        }

        /// <summary>
        /// Get Cascade MineralGrade
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetCascadeMineralGrade(MineralDetails mineralDetails)
        {
            List<MineralDetails> lstMineralDetails = new List<MineralDetails>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Mode", 5);
                param.Add("@MineralNatureId", mineralDetails.MineralNatureId);
                var result = await Connection.QueryAsync<MineralDetails>("SP_GET_TailingDam_InitialLoad", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    lstMineralDetails = result.ToList();
                }
                return lstMineralDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstMineralDetails = null;
            }
        }
        #region Update Tailing dam profile details
        /// <summary>
        /// Bind Profile details in view
        /// </summary>
        /// <param name="objcls_TailingDam"></param>
        /// <returns></returns>
        public async Task<cls_TailingDam> GetProfileDetails(cls_TailingDam objcls_TailingDam)
        {
            cls_TailingDam objModel = new cls_TailingDam();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Mode", 1);
                param.Add("@UserId", objcls_TailingDam.UserId);
                var result = await Connection.QueryAsync<cls_TailingDam>("SP_GET_TailingDam_InitialLoad", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    objModel = result.FirstOrDefault();
                }
                return objModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objModel = null;
            }
        }
        /// <summary>
        /// Update TailingDam
        /// </summary>
        /// <param name="tailingDam"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateTailingDam(cls_TailingDam tailingDam)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Mode", 3);
                param.Add("@MobileNo", tailingDam.MobileNo);
                param.Add("@EmailAddress", tailingDam.EmailID);
                param.Add("@TailingDumplD", tailingDam.TailingDumpID);
                param.Add("@UserId", tailingDam.UserId);
                object result = await Connection.ExecuteScalarAsync("SP_GET_TailingDam_InitialLoad", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = result.ToString();
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Update Royalty details of Lessee/Licensee users
        /// <summary>
        /// Update Royalty pay details
        /// </summary>
        /// <param name="tailingDam"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateRoyaltyPay(cls_TailingDam tailingDam)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Mode", 16);
                param.Add("@IsRoyaltyPaid", tailingDam.IsRoyaltyPaid);
                param.Add("@SupportingDocs_FileName", tailingDam.SUPPORTING_DOCUMENTFILENAME);
                param.Add("@SupportingDocs_FilePath", tailingDam.SUPPORTING_DOCUMENTPath);
                param.Add("@Remarks", tailingDam.Remarks);
                param.Add("@TailingDumplD", tailingDam.TailingDumpID);
                param.Add("@UserId", tailingDam.UserId);
                object result = await Connection.ExecuteScalarAsync("SP_GET_TailingDam_InitialLoad", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = result.ToString();
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Existing User Details
        /// <summary>
        /// Get Existing user details in view
        /// </summary>
        /// <param name="objcls_TailingDam"></param>
        /// <returns></returns>
        public async Task<cls_TailingDam> GetExistingUserDetails(cls_TailingDam objcls_TailingDam)
        {
            cls_TailingDam objModel = new cls_TailingDam();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Mode", 17);
                param.Add("@UserName", objcls_TailingDam.UserName);
                param.Add("@Password", objcls_TailingDam.Password);
                var result = await Connection.QueryAsync<cls_TailingDam>("SP_GET_TailingDam_InitialLoad", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objModel = result.FirstOrDefault();
                }
                return objModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objModel = null;
            }
        }
        #endregion
        #region DD View/Approve Tailing Dam details
        /// <summary>
        /// Get TailingDumpDDApprove
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<cls_TailingDam>> ViewTailingDumpDDApprove(cls_TailingDam objTailingDumpDDApprove)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Mode", 18);
                param.Add("@UserId", objTailingDumpDDApprove.UserId);
                var query = "SP_GET_TailingDam_InitialLoad";
                var result = await Connection.QueryAsync<cls_TailingDam>(query, param, commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Approve Tailing dam details by DD
        /// </summary>
        /// <param name="tailingDam"></param>
        /// <returns></returns>
        public async Task<MessageEF> TailingDumpDDApprove(cls_TailingDam tailingDam)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Mode", 19);
                param.Add("@TailingDumplD", tailingDam.TailingDumpID);
                param.Add("@UserId", tailingDam.UserId);
                object result = await Connection.ExecuteScalarAsync("SP_GET_TailingDam_InitialLoad", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = result.ToString();
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
