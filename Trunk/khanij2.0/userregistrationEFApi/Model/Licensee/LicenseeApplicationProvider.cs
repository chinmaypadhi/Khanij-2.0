using Dapper;
using MasterApi.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.Licensee
{
    public class LicenseeApplicationProvider : RepositoryBase, ILicenseeApplicationProvider
    {
        public LicenseeApplicationProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        #region Add License Application
        /// <summary>
        /// To Add License Application
        /// </summary>
        /// <param name="MessageEF"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddLicenseApplication(CreateLicenseApplication createLicenseApplication)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@DistrictId", createLicenseApplication.DistrictId);
                p.Add("@StorageCapicity", createLicenseApplication.StorageCapicity);
                p.Add("@Period", createLicenseApplication.Period);
                p.Add("@Place", createLicenseApplication.Place);
                if (createLicenseApplication.dataTable.Rows.Count > 0)
                {
                    DataTable dt = new DataTable("Mineral_Wise_Capacity_Quantity");
                    dt = createLicenseApplication.dataTable;
                    if (dt.Rows.Count > 0)
                    {
                        p.Add("@MineralCapacity", dt, DbType.Object);
                    }
                }

                p.Add("@MINERAL_Count_String", createLicenseApplication._mineralId);
                p.Add("@MINERAL_FORM_String", createLicenseApplication._mineralForm);
                p.Add("@MINERAL_GRADE_String", createLicenseApplication._mineralGrade);
                p.Add("@ApplicantName", createLicenseApplication.ApplicantName);
                p.Add("@CompleteAddress", createLicenseApplication.CompleteAddress);
                p.Add("@AppDistrictId", createLicenseApplication.AppDistrictId);
                p.Add("@AppTehsilId", createLicenseApplication.TehsilID);
                p.Add("@AppVillageId", createLicenseApplication.VillageID);
                p.Add("@ApplicantTypeId", createLicenseApplication.ApplicantTypeId);
                p.Add("@NatureofBusiness", createLicenseApplication.NatureofBusiness);
                p.Add("@IntendMineralProductName", createLicenseApplication.IntendMineralProductName);
                p.Add("@Panchayat", createLicenseApplication.Panchayat);
                p.Add("@PoliceStation", createLicenseApplication.PoliceStation);
                p.Add("@LATEST_REVENEW_CERTIFICATE_FILE_PATH", createLicenseApplication.LATEST_REVENEW_CERTIFICATE_FILE_PATH);
                p.Add("@LATEST_REVENEW_CERTIFICATE_FILE_NAME", createLicenseApplication.LATEST_REVENEW_CERTIFICATE_FILE_NAME);
                p.Add("@NO_MINING_DUE_CERTIFICATE_FILE_PATH", createLicenseApplication.NO_MINING_DUE_CERTIFICATE_FILE_PATH);
                p.Add("@NO_MINING_DUE_CERTIFICATE_FILE_NAME", createLicenseApplication.NO_MINING_DUE_CERTIFICATE_FILE_NAME);
                p.Add("@AFFIDAVITE_FILE_PATH", createLicenseApplication.AFFIDAVITE_FILE_PATH);
                p.Add("@AFFIDAVITE_FILE_NAME", createLicenseApplication.AFFIDAVITE_FILE_NAME);
                p.Add("@AFFIDAVITE_JOINTLY_FILE_PATH", createLicenseApplication.AFFIDAVITE_JOINTLY_FILE_PATH);
                p.Add("@AFFIDAVITE_JOINTLY_FILE_NAME", createLicenseApplication.AFFIDAVITE_JOINTLY_FILE_NAME);
                p.Add("@MAP_LAND_CERTIFICATE_FILE_PATH", createLicenseApplication.MAP_LAND_CERTIFICATE_FILE_PATH);
                p.Add("@MAP_LAND_CERTIFICATE_FILE_NAME", createLicenseApplication.MAP_LAND_CERTIFICATE_FILE_NAME);
                p.Add("@NOC_OTHER_CERTIFICATE_FILE_PATH", createLicenseApplication.NOC_OTHER_CERTIFICATE_FILE_PATH);
                p.Add("@NOC_OTHER_CERTIFICATE_FILE_NAME", createLicenseApplication.NOC_OTHER_CERTIFICATE_FILE_NAME);
                p.Add("@OWNER_LAND_CERTIFICATE_FILE_PATH", createLicenseApplication.OWNER_LAND_CERTIFICATE_FILE_PATH);
                p.Add("@OWNER_LAND_CERTIFICATE_FILE_NAME", createLicenseApplication.OWNER_LAND_CERTIFICATE_FILE_NAME);
                p.Add("@LicenseAppId", createLicenseApplication.LicenseAppId);
                p.Add("@MobileNo", createLicenseApplication.MobileNo);
                p.Add("@EmailAddress", createLicenseApplication.EmailAddress);
                p.Add("@ApplicationFor", createLicenseApplication.ApplicationFor);
                p.Add("@LicenseTypeId", createLicenseApplication.LicenseeTypeId);
                p.Add("@CompanyId", createLicenseApplication.CompanyId);
                p.Add("@CreatedBy", 1);
                p.Add("@MineralTypeID", createLicenseApplication.MineralTypeId);
                if (createLicenseApplication.LicenseAppId != null && createLicenseApplication.LicenseAppId > 0)
                {
                    p.Add("@Check", 2);
                }
                else
                {
                    p.Add("@Check", 1);
                }
                p.Add("@AppliedBy", createLicenseApplication.AppliedBy);
                p.Add("@AppliedName", createLicenseApplication.AppliedName);
                p.Add("msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("SP_FORM4", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("msg");
                if (!string.IsNullOrEmpty(rr.ToString()))
                {
                    objMessage.Satus = rr.ToString();
                }
                else
                {
                    objMessage.Satus = "0";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion

        #region Add License Uploaded Document
        /// <summary>
        /// To Add License Uploaded Document
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>MessageEF</returns>
        public async Task<MessageEF> AddLicenseeDocUpload(LicenseeDocUploadModel licenseeDocUploadModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@North", licenseeDocUploadModel.North);
                p.Add("@East", licenseeDocUploadModel.East);
                p.Add("@West", licenseeDocUploadModel.West);
                p.Add("@South", licenseeDocUploadModel.South);
                p.Add("@LicenseAppId", licenseeDocUploadModel.LicenseAppId);
                p.Add("@KhasraPanchsala", licenseeDocUploadModel.KhasraPanchsala);
                p.Add("@MapPlanofAppliedArea", licenseeDocUploadModel.MapPlanofAppliedArea);
                p.Add("@ForestReport", licenseeDocUploadModel.ForestReport);
                p.Add("@RevenueOfficerReport", licenseeDocUploadModel.RevenueOfficerReport);
                p.Add("@SpotInspectionAnalysisReport", licenseeDocUploadModel.SpotInspectionAnalysisReport);
                p.Add("@MiningInspectorReport", licenseeDocUploadModel.MiningInspectorReport);
                p.Add("@GramPanchayatProposal", licenseeDocUploadModel.GramPanchayatProposal);
                p.Add("@DemarcationReport", licenseeDocUploadModel.DemarcationReport);
                p.Add("@EnvironmentalClearanceLetter", licenseeDocUploadModel.EnvironmentalClearanceLetter);
                p.Add("@ConsentToOperateLetter", licenseeDocUploadModel.ConsentToOperateLetter);
                p.Add("@TotalAreaInHect", licenseeDocUploadModel.TotalAreaInHect);
                p.Add("@ECNumber", licenseeDocUploadModel.ECNumber);
                p.Add("@ECFromDate", licenseeDocUploadModel.ECFromDate);
                p.Add("@ECToDate", licenseeDocUploadModel.ECToDate);
                p.Add("@CTONumber", licenseeDocUploadModel.CTONumber);
                p.Add("@CTOOrderDate", licenseeDocUploadModel.CTOOrderDate);
                var rr = await Connection.ExecuteScalarAsync("USP_LicenseApplicationDocs", p, commandType: CommandType.StoredProcedure);
                if (!string.IsNullOrEmpty(rr.ToString()))
                {
                    if (Convert.ToInt32(rr.ToString()) > 0)
                    {
                        objMessage.Satus = rr.ToString();
                    }
                    else
                    {
                        objMessage.Satus = "0";
                    }
                }
                else
                {
                    objMessage.Satus = "0";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion

        #region Add Security Deposit
        /// <summary>
        /// To Add Security Deposit
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>MessageEF</returns>
        public async Task<MessageEF> AddSecurityDeposit(LicenseApplication licenseApplication)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@LicenseAppId", licenseApplication.LicenseAppId);
                p.Add("@UserId", licenseApplication.UserId);
                p.Add("@Check", 11);
                p.Add("@UserLoginId", licenseApplication.UserId);
                p.Add("@TotalPayment", licenseApplication.TotalPayment);
                p.Add("@SecurityAmountBank", licenseApplication.PaymentBank);
                p.Add("@SecurityAmountMode", licenseApplication.PaymentMode);
                var rr = await Connection.ExecuteScalarAsync("SP_FORM4", p, commandType: CommandType.StoredProcedure);
                objMessage.Satus = rr.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion

        #region Delete License Application
        public Task<MessageEF> DeleteLicenseApplication(LicenseApplication licenseApplication)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Edit License Application
        /// <summary>
        /// To Edit License Application
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public async Task<LicenseApplication> EditLicenseApplication(LicenseApplication licenseApplication)
        {
            try
            {
                List<LicenseApplication.CapacityQuantityModel> list = new List<LicenseApplication.CapacityQuantityModel>();
                List<LicenseApplication.CapacityQuantityModel> listDetails = new List<LicenseApplication.CapacityQuantityModel>();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 6);
                param.Add("@LicenseAppId", licenseApplication.LicenseAppId);
                param.Add("@UserId", licenseApplication.UserId);
                var result = await Connection.QueryAsync<LicenseApplication>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                var data = await Connection.QueryAsync<LicenseApplication.CapacityQuantityModel>("SELECT * FROM LicenseeMineralCapacity WITH(NOLOCK) where LicenseAppId = @LicenseAppId", param, commandType: System.Data.CommandType.Text);
                if (result.Count() > 0)
                {

                    licenseApplication = result.FirstOrDefault();
                    list = data.ToList();
                    if (licenseApplication.MineralIdList != null)
                    {
                        var str = (licenseApplication.MineralIdList.ToString()).Replace("[", "").Replace("]", "");
                        string[] array = str.Split(',');
                        var strName = licenseApplication.MineralName;
                        string[] NameArray = strName.Split(',');

                        // List<LicenseApplication.CapacityQuantityModel> list = new List<LicenseApplication.CapacityQuantityModel>();

                        for (int j = 0; j < array.Count(); j++)
                        {
                            LicenseApplication.CapacityQuantityModel m = new LicenseApplication.CapacityQuantityModel();
                            if (array[j] != "")
                                m.MineralId = Convert.ToInt32(array[j]);
                            m.MineralName = NameArray[j];
                            if (data != null && data.Count() > 0)
                            {
                                m.Quantity = Convert.ToDecimal(list[j].Quantity);
                            }
                            else
                            {
                                m.Quantity = Convert.ToDecimal(0);
                            }
                            listDetails.Add(m);
                        }
                        licenseApplication.QuantityList = listDetails;
                    }
                }

                return licenseApplication;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                licenseApplication = null;
            }
        }
        #endregion

        #region Form4 Review Details
        /// <summary>
        /// To Get Form4 Review Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public async Task<LicenseApplication> Form4Review(LicenseApplication licenseApplication)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 6);
                param.Add("@LicenseAppId", licenseApplication.StatusId);
                param.Add("@UserId", licenseApplication.UserId);
                var result = await Connection.QueryAsync<LicenseApplication>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    licenseApplication = result.FirstOrDefault();
                }
                return licenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                licenseApplication = null;
            }
        }
        #endregion

        #region Application Type
        /// <summary>
        /// To Get Application Type
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public async Task<List<LicenseApplication>> GetApplicantTypeForForm4(LicenseApplication licenseApplication)
        {
            List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LicenseApplication>("SELECT ApplicantTypeID ApplicantTypeId,ApplicantType ApplicantTypeName FROM ApplicantTypeMaster WHERE IsActive = 1 AND IsDelete = 0", param, commandType: System.Data.CommandType.Text);
                if (result.Count() > 0)
                {
                    lstLicenseApplication = result.ToList();
                }
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstLicenseApplication = null;
            }
        }
        #endregion

        #region Company List
        /// <summary>
        /// To Get Company List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public async Task<List<LicenseApplication>> GetCompanyList(LicenseApplication licenseApplication)
        {
            List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LicenseApplication>("select CompanyId,CompanyName from CompanyMaster where status=1", param, commandType: System.Data.CommandType.Text);
                if (result.Count() > 0)
                {
                    lstLicenseApplication = result.ToList();
                }
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstLicenseApplication = null;
            }
        }
        #endregion

        #region District List
        /// <summary>
        /// To Get District Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public async Task<List<LicenseApplication>> GetDistrictList(LicenseApplication licenseApplication)
        {
            List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LicenseApplication>("select DistrictID,DistrictName from DistrictMaster where IsDelete=0 and IsActive=1 order by DistrictName", param, commandType: System.Data.CommandType.Text);
                if (result.Count() > 0)
                {
                    lstLicenseApplication = result.ToList();
                }
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstLicenseApplication = null;
            }
        }
        #endregion

        #region Get District Form4
        /// <summary>
        /// To Get District Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public async Task<List<LicenseApplication>> GetDistrictListForm4(LicenseApplication licenseApplication)
        {
            List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LicenseApplication>("select DistrictID,DistrictName from DistrictMaster where IsDelete=0 and IsActive=1 and StateID=7 order by DistrictName", param, commandType: System.Data.CommandType.Text);
                if (result.Count() > 0)
                {
                    lstLicenseApplication = result.ToList();
                }
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstLicenseApplication = null;
            }
        }
        #endregion

        #region License Type
        /// <summary>
        /// To Get License Type
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public async Task<List<LicenseApplication>> GetLicenseeType(LicenseApplication licenseApplication)
        {
            List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LicenseApplication>("select LicenseeTypeId,LicenseeTypeName from LicenseeTypeMaster where IsActive=1 and IsDelete=0", param, commandType: System.Data.CommandType.Text);
                if (result.Count() > 0)
                {
                    lstLicenseApplication = result.ToList();
                }
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstLicenseApplication = null;
            }
        }
        #endregion

        #region Mineral Grade By MineralId List
        /// <summary>
        /// To Get Mineral Grade By MineralId List
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public async Task<List<LicenseApplication>> GetMineralGradeListFromMineralIdList(LicenseApplication licenseApplication)
        {
            List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 3);
                param.Add("@MineralIdList", licenseApplication.MineralIdList);
                param.Add("@MineralNatureId", licenseApplication.MineralNatureList);
                param.Add("@UserId", licenseApplication.UserId);
                var result = await Connection.QueryAsync<LicenseApplication>("uspGetMineralNature_GradeFromMineral", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstLicenseApplication = result.ToList();
                }
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstLicenseApplication = null;
            }
        }
        #endregion

        #region Mineral Name By Mineral Type
        /// <summary>
        /// To Get MineralName From Mineral Type
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public async Task<List<LicenseApplication>> GetMineralNameFromMineralType(LicenseApplication licenseApplication)
        {
            List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MineralTypeId", licenseApplication.MineralTypeId);
                param.Add("@UserId", licenseApplication.UserId);
                var result = await Connection.QueryAsync<LicenseApplication>("uspGetMineralNameFromMineralType", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstLicenseApplication = result.ToList();

                    lstLicenseApplication[13].MineralName = lstLicenseApplication[13].MineralName.Replace("\"", "");
                    //lstLicenseApplication[47].MineralName = lstLicenseApplication[13].MineralName.Replace("\"", "");
                }
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstLicenseApplication = null;
            }
        }
        #endregion

        #region Mineral Nature By MineralId
        /// <summary>
        /// To Get Mineral Nature By MineralId
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public async Task<List<LicenseApplication>> GetMineralNatureListFromMineralIdList(LicenseApplication licenseApplication)
        {
            List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 2);
                param.Add("@MineralIdList", licenseApplication.MineralId);
                param.Add("@UserId", licenseApplication.UserId);
                var result = await Connection.QueryAsync<LicenseApplication>("uspGetMineralNature_GradeFromMineral", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstLicenseApplication = result.ToList();
                }
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstLicenseApplication = null;
            }
        }
        #endregion

        #region Mineral Type
        /// <summary>
        /// To Get Mineral Type Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public async Task<List<LicenseApplication>> GetMineralTypeList(LicenseApplication licenseApplication)
        {
            List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LicenseApplication>("select MineralTypeID,MineralType MINERALTYPE_NAME from MineralTypeMaster where IsActive=1 and IsDelete=0 order by MineralType", param, commandType: System.Data.CommandType.Text);
                if (result.Count() > 0)
                {
                    lstLicenseApplication = result.ToList();
                }
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstLicenseApplication = null;
            }
        }
        #endregion

        #region Security Deposit Details
        /// <summary>
        /// To Get Security Deposit Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public async Task<LicenseApplication> GetSecurityDepositDetail(LicenseApplication licenseApplication)
        {

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 10);
                param.Add("@LicenseAppId", licenseApplication.LicenseAppId);
                var result = await Connection.QueryAsync<LicenseApplication>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    licenseApplication = result.FirstOrDefault();
                }

                return licenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                licenseApplication = null;
            }
        }
        #endregion

        #region Tehsil By District Id
        /// <summary>
        /// To Get Tehsil By District Id
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public async Task<List<LicenseApplication>> GetTehsilListByDistrictID(LicenseApplication licenseApplication)
        {
            List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@DistrictID", licenseApplication.DistrictId);
                var result = await Connection.QueryAsync<LicenseApplication>("SELECT TehsilID,TehsilName  FROM TehsilMaster WHERE DistrictID=@DistrictID ORDER BY TehsilID", param, commandType: System.Data.CommandType.Text);
                if (result.Count() > 0)
                {
                    lstLicenseApplication = result.ToList();
                }
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstLicenseApplication = null;
            }
        }
        #endregion

        #region Village By Tehsil Id
        /// <summary>
        /// To Get Village From Tehsil Id
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public async Task<List<LicenseApplication>> GetvillageFromTehsilID(LicenseApplication licenseApplication)
        {
            List<LicenseApplication> lstLicenseApplication = new List<LicenseApplication>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@TehsilID", licenseApplication.TehsilID);
                var result = await Connection.QueryAsync<LicenseApplication>("select VillageID,VillageName from VillageMaster VM join TehsilMaster TM on VM.TehsilID=TM.TehsilID where VM.TehsilID =@TehsilID and VM.IsActive =1", param, commandType: System.Data.CommandType.Text);
                if (result.Count() > 0)
                {
                    lstLicenseApplication = result.ToList();
                }
                return lstLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstLicenseApplication = null;
            }
        }
        #endregion

        #region License Uploaded Document Details
        /// <summary>
        /// To Get License Uploaded Document Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public async Task<LicenseeDocUploadModel> LicenseeDocUpload(LicenseApplication licenseApplication)
        {
            LicenseeDocUploadModel licenseeDocUploadModel = new LicenseeDocUploadModel();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 6);
                param.Add("@LicenseAppId", licenseApplication.LicenseAppId);
                param.Add("@UserId", licenseApplication.UserId);
                param.Add("@UserLoginId", licenseApplication.UserId);
                var result = await Connection.QueryAsync<LicenseeDocUploadModel>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    licenseeDocUploadModel = result.FirstOrDefault();
                }
                return licenseeDocUploadModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                licenseeDocUploadModel = null;
            }
        }
        #endregion

        #region License Final Approval By DD
        /// <summary>
        /// License Final Approval By DD
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseFinalApproval</returns>
        public async Task<LicenseFinalApproval> LicenseFinalApprovalDetails(LicenseApplication licenseApplication)
        {
            LicenseFinalApproval licenseFinalApproval = new LicenseFinalApproval();
            try
            {
                var p = new DynamicParameters();
                p.Add("@LicenseAppId", licenseApplication.LicenseAppId);
                p.Add("@UserId", licenseApplication.UserId);
                p.Add("@UserLoginId", licenseApplication.UserLoginId);
                p.Add("@Check", 1);
                var rr = await Connection.ExecuteScalarAsync("CreateLicenseeFORM4", p, commandType: CommandType.StoredProcedure);
                if (!string.IsNullOrEmpty(rr.ToString()))
                {

                    var p2 = new DynamicParameters();
                    p2.Add("@LicenseAppId", licenseApplication.LicenseAppId);
                    p2.Add("@UserId", Convert.ToInt64(rr.ToString()));
                    p2.Add("@Check", 2);
                    var result = await Connection.QueryAsync<LicenseFinalApproval>("CreateLicenseeFORM4", p2, commandType: System.Data.CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {
                        licenseFinalApproval = result.FirstOrDefault();
                    }
                    licenseFinalApproval.Status = "SUCCESS";
                }
                else
                {
                    licenseFinalApproval.Status = "FAILED";
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                licenseFinalApproval.Status = "Please try again after sometime !";
            }
            return licenseFinalApproval;
        }
        #endregion

        #region License Registered List
        /// <summary>
        /// To Get License Registered Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public async Task<List<LicenseApplication>> LicenseRegisteredList(LicenseApplication licenseApplication)
        {
            List<LicenseApplication> listLicenseApplication = new List<LicenseApplication>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 5);
                param.Add("@FromDate1", licenseApplication.FromDate);
                param.Add("@ToDate1", licenseApplication.ToDate);
                param.Add("@UserId", licenseApplication.UserId);
                param.Add("@ActiveStatus", licenseApplication.StatusId);
                var result = await Connection.QueryAsync<LicenseApplication>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    listLicenseApplication = result.ToList();
                }
                return listLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                listLicenseApplication = null;
            }
        }
        #endregion

        #region Payment Process Details
        /// <summary>
        /// To Get Payment Process Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public async Task<LicenseApplication> PaymentProcessDetails(LicenseApplication licenseApplication)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 10);
                param.Add("@LicenseAppId", licenseApplication.LicenseAppId);
                param.Add("@UserId", licenseApplication.UserId);
                var result = await Connection.QueryAsync<LicenseApplication>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    licenseApplication = result.FirstOrDefault();
                }

                return licenseApplication;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                licenseApplication = null;
            }
        }
        #endregion

        #region Update License Application
        public Task<MessageEF> UpdateLicenseApplication(LicenseApplication licenseApplication)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region View Form7 Details
        /// <summary>
        /// To View Form7 Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>LicenseApplication</returns>
        public async Task<LicenseApplication> ViewForm7(LicenseApplication licenseApplication)
        {
            List<LicenseeCondition> lstLicenseeCondition = new List<LicenseeCondition>();
            List<string> lstString = new List<string>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 6);
                param.Add("@LicenseAppId", licenseApplication.LicenseAppId);
                param.Add("@UserId", licenseApplication.UserId);
                var result = await Connection.QueryAsync<LicenseApplication>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                var data = await Connection.QueryAsync<LicenseeCondition>("SELECT LicenseeCondition.LicenseeConditionId,LicenseeCondition.LicenseeConditionName  FROM LicenseeCondition WHERE Status=1;", param, commandType: System.Data.CommandType.Text);
                if (result.Count() > 0)
                {
                    licenseApplication = result.FirstOrDefault();
                }
                if (data.Count() > 0)
                {
                    lstLicenseeCondition = data.ToList();
                    foreach (var item in lstLicenseeCondition)
                    {
                        if (!string.IsNullOrEmpty(item.LicenseeConditionName))
                        {
                            string name = item.LicenseeConditionName.ToString();
                            lstString.Add(name);
                        }
                    }
                    licenseApplication.Conditions = lstString;
                }

                return licenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                licenseApplication = null;
            }
        }
        #endregion

        #region View License Application
        /// <summary>
        /// To View License Application
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        public async Task<List<LicenseApplication>> ViewLicenseApplication(LicenseApplication licenseApplication)
        {
            List<LicenseApplication> listLicenseApplication = new List<LicenseApplication>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 4);
                param.Add("@FromDate1", licenseApplication.FromDate);
                param.Add("@ToDate1", licenseApplication.ToDate);
                param.Add("@UserId", licenseApplication.UserId);
                var result = await Connection.QueryAsync<LicenseApplication>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    listLicenseApplication = result.ToList();
                }
                return listLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                listLicenseApplication = null;
            }
        }
        #endregion

        #region License Details By App Code
        /// <summary>
        /// License Details By App Code
        /// </summary>
        /// <param name="licenseMail"></param>
        /// <returns></returns>
        public async Task<LicenseMail> GetLicenseDetailsByAppCode(LicenseMail licenseMail)
        {

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 3);
                param.Add("@LICENSE_APP_CODE", licenseMail.LICENSE_APP_CODE);
                var result = await Connection.QueryAsync<LicenseMail>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    licenseMail = result.FirstOrDefault();
                }


                return licenseMail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                licenseMail = null;
            }
        }
        #endregion 

        #region Update DSC File Path
        /// <summary>
        /// Update DSC File Path
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdatedDSCPath(UpdateDSCPath updateDSCPath)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@fileName", updateDSCPath.fileName);
                param.Add("@ID", updateDSCPath.ID);
                param.Add("@UpdateIn", updateDSCPath.UpdateIn);
                param.Add("@UserId", updateDSCPath.UserId);
                param.Add("@MonthYear", updateDSCPath.MonthYear);
                var result = await Connection.ExecuteScalarAsync("UpdateDSCPath", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = result.ToString();
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region License Approval ACK Detail for MSG
        /// <summary>
        /// License Approval ACK Detail for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public async Task<LicenseFinalApproval> LICENSE_APP_ACK(UpdateDSCPath updateDSCPath)
        {
            LicenseFinalApproval licenseFinalApproval = new LicenseFinalApproval();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 7);
                param.Add("@UserId", updateDSCPath.UserId);
                param.Add("@LicenseAppId", updateDSCPath.ID);
                var result = await Connection.QueryAsync<LicenseFinalApproval>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    licenseFinalApproval = result.FirstOrDefault();
                }
                return licenseFinalApproval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region License App Grant Order detail for MSG
        /// <summary>
        /// License App Grant Order detail for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public async Task<LicenseFinalApproval> LICENSE_APP_GRANT_ORDER(UpdateDSCPath updateDSCPath)
        {
            LicenseFinalApproval licenseFinalApproval = new LicenseFinalApproval();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 9);
                param.Add("@UserId", updateDSCPath.UserId);
                param.Add("@LicenseAppId", updateDSCPath.ID);
                var result = await Connection.QueryAsync<LicenseFinalApproval>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    licenseFinalApproval = result.FirstOrDefault();
                }
                return licenseFinalApproval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Encrypt Password
        /// <summary>
        /// Update Encrypt Password
        /// </summary>
        /// <param name="updateEncryptPasswordModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserName",updateEncryptPasswordModel.UserName.Trim());
                param.Add("@EncryptPassword", updateEncryptPasswordModel.EncryptPassword.Trim());
                param.Add("@Check", 1);
                var result = await Connection.ExecuteScalarAsync("uspUpdateEncryptPassword", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = result.ToString();
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Lease Deed
        public async Task<MessageEF> LeaseDeedUpload(LeaseDeedModel leaseDeedModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 13);
                param.Add("@LicenseAppId", leaseDeedModel.LicenseAppId);
                param.Add("@UserId", leaseDeedModel.UserId);
                param.Add("@UserLoginId", leaseDeedModel.UserId);
                param.Add("@Lease_Deed_File_Name", leaseDeedModel.Lease_Deed_File_Name);
                param.Add("@Lease_Deed_File_Path", leaseDeedModel.Lease_Deed_File_Path);
                param.Add("@ExtendDeedNoOfDays", leaseDeedModel.ExtendDeedNoOfDays);
                param.Add("@ExtendedDeedStatus", leaseDeedModel.ExtendedDeedStatus);
                param.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                //var result = await Connection.QueryAsync<MessageEF>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                var rr = await Connection.QueryAsync("SP_FORM4", param, commandType: CommandType.StoredProcedure);
                int response = param.Get<Int32>("Result");
                if (response == 1)
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
        }
        public async Task<MessageEF> ApproveLeaseDeed(LeaseDeedModel leaseDeedModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 14);
                param.Add("@LicenseAppId", leaseDeedModel.LicenseAppId);
                param.Add("@UserId", leaseDeedModel.UserId);
                param.Add("@UserLoginId", leaseDeedModel.UserId);
                param.Add("@Lease_Deed_File_Name", leaseDeedModel.Lease_Deed_File_Name);
                param.Add("@Lease_Deed_File_Path", leaseDeedModel.Lease_Deed_File_Path);
                param.Add("@ApprovedDeedBy", leaseDeedModel.ApprovedDeedBy);
                param.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var rr = await Connection.QueryAsync("SP_FORM4", param, commandType: CommandType.StoredProcedure);
                int response = param.Get<Int32>("Result");
                if (response == 1)
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
        }
        #endregion
       
        #region Lease Deed Fine
        public async Task<MessageEF> AddLeaseDeedFine(LicenseApplication licenseApplication)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@LicenseAppId", licenseApplication.LicenseAppId);
                p.Add("@UserId", licenseApplication.UserId);
                p.Add("@Check", 15);
                p.Add("@UserLoginId", licenseApplication.UserId);
                p.Add("@TotalPayment", licenseApplication.TotalPayment);
                p.Add("@SecurityAmountBank", licenseApplication.PaymentBank);
                p.Add("@SecurityAmountMode", licenseApplication.PaymentMode);
                var rr = await Connection.ExecuteScalarAsync("SP_FORM4", p, commandType: CommandType.StoredProcedure);
                objMessage.Satus = rr.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion

        #region Extend Lease Deed Details
        /// <summary>
        /// Extend Lease Deed Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        public async Task<List<LicenseApplication>> ExtendLeaseDeedDetails(LicenseApplication licenseApplication)
        {
            List<LicenseApplication> listLicenseApplication = new List<LicenseApplication>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check",16); 
                param.Add("@UserId", licenseApplication.UserId); 
                var result = await Connection.QueryAsync<LicenseApplication>("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    listLicenseApplication = result.ToList();
                }
                return listLicenseApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                listLicenseApplication = null;
            }
        }
        #endregion

        #region Approve Extend Lease Deed Request
        /// <summary>
        /// Approve Extend Lease Deed Request
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        public async Task<MessageEF> ApproveExtendLeaseDeedDetails(LicenseApplication licenseApplication)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 17);
                param.Add("@UserId", licenseApplication.UserId);
                param.Add("@LicenseAppId", licenseApplication.LicenseAppId);
                var result = await Connection.ExecuteScalarAsync("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                
                messageEF.Satus=result.ToString();
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion

        #region Issue Grant Order
        /// <summary>
        /// Issue Grant Order
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        public async Task<MessageEF> IssueGrantOrder(LicenseApplication licenseApplication)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 18);
                param.Add("@UserId", licenseApplication.UserId);
                param.Add("@LicenseAppId", licenseApplication.LicenseAppId);
                var result = await Connection.ExecuteScalarAsync("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = result.ToString();
                return messageEF;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Object Extend Lease Deed Request
        /// <summary>
        /// Object Extend Lease Deed Request
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        public async Task<MessageEF> ObjectExtendLeaseDeedDetails(LicenseApplication licenseApplication)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Check", 19);
                param.Add("@UserId", licenseApplication.UserId);
                param.Add("@LicenseAppId", licenseApplication.LicenseAppId);
                param.Add("@Remarks", licenseApplication.Remarks);
                var result = await Connection.ExecuteScalarAsync("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);

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
