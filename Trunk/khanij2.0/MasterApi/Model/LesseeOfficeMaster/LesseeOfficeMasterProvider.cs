// ***********************************************************************
//  Class Name               : LesseeOfficeMasterProvider
//  Description              : Lessee Office Master View Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 13 July 2021
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

namespace MasterApi.Model.LesseeOfficeMaster
{
    public class LesseeOfficeMasterProvider: RepositoryBase, ILesseeOfficeMasterProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LesseeOfficeMasterProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To bind Company/Association details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        public async Task<List<OfficeMasterViewModel>> GetAssociationListDetails(OfficeMasterViewModel objOfficemasterModel)
        {
            List<OfficeMasterViewModel> objOfficemasterModelList = new List<OfficeMasterViewModel>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var result =await Connection.QueryAsync<OfficeMasterViewModel>("[USP_GET_COMPANY_DETAILS]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objOfficemasterModelList = result.ToList();
                }
                return objOfficemasterModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Office Master details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        public OfficeMasterViewModel GetOfficeMasterDetails(OfficeMasterViewModel objOfficemasterModel)
        {
            OfficeMasterViewModel ObjOfficeDetails = new OfficeMasterViewModel();
            try
            {
                var paramList = new
                {
                    USER_ID = objOfficemasterModel.User_Id,
                    OPERATION_MODE = "GETDATA",
                    mineraltypename=objOfficemasterModel.MineralTypeName
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<OfficeMasterViewModel>("[USP_CRUD_LESSEE_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjOfficeDetails = result.FirstOrDefault();
                }
                return ObjOfficeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Office details
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>/// <summary>
        public MessageEF UpdateOfficeMasterDetails(OfficeMasterViewModel objOfficemasterModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CORPORATE_NAME_PREFIX", objOfficemasterModel.CORPORATE_NAME_PREFIX);
                p.Add("CORPORATE_NAME", objOfficemasterModel.CORPORATE_NAME);
                p.Add("CORPORATE_ADDRESS", objOfficemasterModel.CORPORATE_ADDRESS);
                p.Add("CORPORATE_CONTACT_DETAILS", objOfficemasterModel.CORPORATE_CONTACT_DETAILS);
                p.Add("CORPORATE_DESIGNATION", objOfficemasterModel.CORPORATE_DESIGNATION);
                p.Add("CORPORATE_MAIL_ID", objOfficemasterModel.CORPORATE_MAIL_ID);
                p.Add("CORPORATE_LANDLINE_NO", objOfficemasterModel.CORPORATE_LANDLINE_NO);
                p.Add("CORPORATE_STATUS", objOfficemasterModel.CORPORATE_STATUS);
                p.Add("BRANCH_NAME_PREFIX", objOfficemasterModel.BRANCH_NAME_PREFIX);
                p.Add("BRANCH_NAME", objOfficemasterModel.BRANCH_NAME);
                p.Add("BRANCH_ADDRESS", objOfficemasterModel.BRANCH_ADDRESS);
                p.Add("BRANCH_CONTACT_DETAILS", objOfficemasterModel.BRANCH_CONTACT_DETAILS);
                p.Add("BRANCH_DESIGNATION", objOfficemasterModel.BRANCH_DESIGNATION);
                p.Add("BRANCH_MAIL_ID", objOfficemasterModel.BRANCH_MAIL_ID);
                p.Add("BRANCH_LANDLINE_NO", objOfficemasterModel.BRANCH_LANDLINE_NO);
                p.Add("BRANCH_STATUS", objOfficemasterModel.BRANCH_STATUS);
                p.Add("SITE_NAME_PREFIX", objOfficemasterModel.SITE_NAME_PREFIX);
                p.Add("SITE_NAME", objOfficemasterModel.SITE_NAME);
                p.Add("SITE_ADDRESS", objOfficemasterModel.SITE_ADDRESS);
                p.Add("SITE_CONTACT_DETAILS", objOfficemasterModel.SITE_CONTACT_DETAILS);
                p.Add("SITE_DESIGNATION", objOfficemasterModel.SITE_DESIGNATION);
                p.Add("SITE_MAIL_ID", objOfficemasterModel.SITE_MAIL_ID);
                p.Add("SITE_LANDLINE_NO", objOfficemasterModel.SITE_LANDLINE_NO);
                p.Add("Secondary_SITE_NAME_PREFIX", objOfficemasterModel.SECONDARY_SITE_NAME_PREFIX);
                p.Add("Secondary_SITE_NAME", objOfficemasterModel.SECONDARY_SITE_NAME);
                p.Add("Secondary_SITE_ADDRESS", objOfficemasterModel.SECONDARY_SITE_ADDRESS);
                p.Add("Secondary_SITE_CONTACT_DETAILS", objOfficemasterModel.SECONDARY_SITE_CONTACT_DETAILS);
                p.Add("Secondary_SITE_DESIGNATION", objOfficemasterModel.SECONDARY_SITE_DESIGNATION);
                p.Add("Secondary_SITE_MAIL_ID", objOfficemasterModel.SECONDARY_SITE_MAIL_ID);
                p.Add("Secondary_SITE_LANDLINE_NO", objOfficemasterModel.SECONDARY_SITE_LANDLINE_NO);
                p.Add("SITE_STATUS", objOfficemasterModel.SITE_STATUS);
                p.Add("AGENT_NAME_PREFIX", objOfficemasterModel.AGENT_NAME_PREFIX);
                p.Add("AGENT_NAME", objOfficemasterModel.AGENT_NAME);
                p.Add("AGENT_ADDRESS", objOfficemasterModel.AGENT_ADDRESS);
                p.Add("AGENT_CONTACT_DETAILS", objOfficemasterModel.AGENT_CONTACT_DETAILS);
                p.Add("AGENT_DESIGNATION", objOfficemasterModel.AGENT_DESIGNATION);
                p.Add("AGENT_MAIL_ID", objOfficemasterModel.AGENT_MAIL_ID);
                p.Add("AGENT_LANDLINE_NO", objOfficemasterModel.AGENT_LANDLINE_NO);
                p.Add("AGENT_STATUS", objOfficemasterModel.AGENT_STATUS);
                p.Add("CATEGORY_OF_LESSEE", objOfficemasterModel.CategoryOfLicensee);
                if(objOfficemasterModel.CategoryOfLicensee== "Individual/Proprietor")
                {
                    objOfficemasterModel.Firm = null;
                    objOfficemasterModel.Company = null;
                    objOfficemasterModel.CompanyId = 0;
                }
                else if(objOfficemasterModel.CategoryOfLicensee == "Firm")
                {
                    objOfficemasterModel.Company = null;
                }
                else if (objOfficemasterModel.CategoryOfLicensee == "Association")
                {
                    objOfficemasterModel.Firm = null;
                    objOfficemasterModel.Company = null;
                }
                else if (objOfficemasterModel.CategoryOfLicensee == "Company")
                {
                    objOfficemasterModel.Firm = null;
                }
                p.Add("FIRM", objOfficemasterModel.Firm);
                p.Add("COMPANY", objOfficemasterModel.Company);
                p.Add("COMPANYID", objOfficemasterModel.CompanyId);
                p.Add("VCH_FILE_PATH", objOfficemasterModel.LETTER_OF_APPOINTMENT_OF_AGENT_FILE_PATH);
                p.Add("VCH_FILE_NAME", objOfficemasterModel.LETTER_OF_APPOINTMENT_OF_AGENT_FILE_NAME);
                p.Add("USER_ID", objOfficemasterModel.User_Id);
                if (objOfficemasterModel.Company != "PSU")
                {
                    objOfficemasterModel.CollieryCode = "";
                }
                p.Add("VCH_COLLIERYCODE", objOfficemasterModel.CollieryCode);
                p.Add("VCH_GSTNO", objOfficemasterModel.GSTNo);
                p.Add("VCH_MINESTYPE", objOfficemasterModel.MinesType);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("OPERATION_MODE", "SAVE");
                Connection.Query<int>("[USP_CRUD_LESSEE_OFFICE]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To bind Last approved Lessee Office Details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        public List<OfficeMasterViewModel> GetLesseeOfficeMasterCompareDetails(OfficeMasterViewModel objOfficemasterModel)
        {
            List<OfficeMasterViewModel> ObjLesseeOfficeDetails = new List<OfficeMasterViewModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objOfficemasterModel.INT_CREATED_BY,
                    OPERATION_MODE = "COMPARE"
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<OfficeMasterViewModel>("[USP_CRUD_LESSEE_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLesseeOfficeDetails = result.ToList();
                }
                return ObjLesseeOfficeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Office details by DD
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeOfficeMasterDetails(OfficeMasterViewModel objOfficemasterModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("APPROVED_BY", objOfficemasterModel.User_Id);
                p.Add("OPERATION_MODE", "APPROVE");
                p.Add("LESSE_DETAIL_ID", objOfficemasterModel.INT_CREATED_BY);
                p.Add("Remarks", objOfficemasterModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_CRUD_LESSEE_OFFICE", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// To Reject Lesse Office details by DD
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeOfficeMasterDetails(OfficeMasterViewModel objOfficemasterModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("REJECTED_BY", objOfficemasterModel.User_Id);
                p.Add("OPERATION_MODE", "REJECT");
                p.Add("LESSE_DETAIL_ID", objOfficemasterModel.INT_CREATED_BY);
                p.Add("Remarks", objOfficemasterModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_CRUD_LESSEE_OFFICE", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// To bind Lessee Category Log Details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        public List<OfficeMasterViewModel> GetLesseeCategoryLogDetails(OfficeMasterViewModel objOfficemasterModel)
        {
            List<OfficeMasterViewModel> ObjLesseeOfficeDetails = new List<OfficeMasterViewModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objOfficemasterModel.INT_CREATED_BY,
                    OPERATION_MODE = "LESSEE CATEGORY"
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<OfficeMasterViewModel>("[USP_CRUD_LESSEE_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLesseeOfficeDetails = result.ToList();
                }
                return ObjLesseeOfficeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Lessee Corporate Office Log Details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        public List<OfficeMasterViewModel> GetLesseeCorporateOfficeLogDetails(OfficeMasterViewModel objOfficemasterModel)
        {
            List<OfficeMasterViewModel> ObjLesseeOfficeDetails = new List<OfficeMasterViewModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objOfficemasterModel.INT_CREATED_BY,
                    OPERATION_MODE = "CORPORATE OFFICE"
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<OfficeMasterViewModel>("[USP_CRUD_LESSEE_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLesseeOfficeDetails = result.ToList();
                }
                return ObjLesseeOfficeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Lessee Branch Office Log Details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        public List<OfficeMasterViewModel> GetLesseeBranchOfficeLogDetails(OfficeMasterViewModel objOfficemasterModel)
        {
            List<OfficeMasterViewModel> ObjLesseeOfficeDetails = new List<OfficeMasterViewModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objOfficemasterModel.INT_CREATED_BY,
                    OPERATION_MODE = "BRANCH OFFICE"
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<OfficeMasterViewModel>("[USP_CRUD_LESSEE_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLesseeOfficeDetails = result.ToList();
                }
                return ObjLesseeOfficeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Lessee Site Office Log Details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        public List<OfficeMasterViewModel> GetLesseeSiteOfficeLogDetails(OfficeMasterViewModel objOfficemasterModel)
        {
            List<OfficeMasterViewModel> ObjLesseeOfficeDetails = new List<OfficeMasterViewModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objOfficemasterModel.INT_CREATED_BY,
                    OPERATION_MODE = "SITE OFFICE"
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<OfficeMasterViewModel>("[USP_CRUD_LESSEE_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLesseeOfficeDetails = result.ToList();
                }
                return ObjLesseeOfficeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Lessee Agent Office Log Details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        public List<OfficeMasterViewModel> GetLesseeAgentOfficeLogDetails(OfficeMasterViewModel objOfficemasterModel)
        {
            List<OfficeMasterViewModel> ObjLesseeOfficeDetails = new List<OfficeMasterViewModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objOfficemasterModel.INT_CREATED_BY,
                    OPERATION_MODE = "AGENT OFFICE"
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<OfficeMasterViewModel>("[USP_CRUD_LESSEE_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLesseeOfficeDetails = result.ToList();
                }
                return ObjLesseeOfficeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete Lesse Office Master details
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeOfficeMasterDetails(OfficeMasterViewModel objOfficemasterModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK","DELETE");
                p.Add("LESSE_DETAIL_ID", objOfficemasterModel.INT_CREATED_BY);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_CRUD_LESSEE_OFFICE]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
    }
}
