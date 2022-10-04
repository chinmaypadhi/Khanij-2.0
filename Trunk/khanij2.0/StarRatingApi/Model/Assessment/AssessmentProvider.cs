// ***********************************************************************
//  Class Name               : AssessmentProvider
//  Desciption               : Starrating Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 14 April 2021
// ***********************************************************************
using Dapper;
using StarRatingApi.Factory;
using StarRatingApi.Repository;
using StarratingEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace StarRatingApi.Model.Assessment
{
    public class AssessmentProvider: RepositoryBase, IAssessmentProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public AssessmentProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        #region View Assessment List
        /// <summary>
        /// Bind Assessment List details
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        public List<AssessmentListmaster> ViewAssessmentListmaster(AssessmentListmaster objAssessmentListmaster)
        {
            List<AssessmentListmaster> ListAssessmentLisMaster = new List<AssessmentListmaster>();
            try
            {
                var paramList = new
                {
                    ApplicantName = objAssessmentListmaster.ApplicantName,
                    StateID = objAssessmentListmaster.StateId,
                    DistrictID = objAssessmentListmaster.DistrictId,
                    TehsilID = objAssessmentListmaster.TehsilID,
                    VillageID = objAssessmentListmaster.VillageID,
                    LStar = objAssessmentListmaster.LStar,
                    MIStar = objAssessmentListmaster.MIStar,
                    DDStar = objAssessmentListmaster.DDStar,
                    DGMStar = objAssessmentListmaster.DGMStar,
                    AssesmentID = objAssessmentListmaster.AssesmentID,
                    PageIndex = "1",
                    PageSize = "10",
                    ReportingYear=objAssessmentListmaster.ReportingYear,
                    Lesseecode = objAssessmentListmaster.Lessee_Code,
                };
                var Output = Connection.Query<AssessmentListmaster>("SP_Get_SR_Return_Assesment", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {
                    ListAssessmentLisMaster = Output.ToList();
                }
                return ListAssessmentLisMaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region Dropdowns
        /// <summary>
        /// To Bind the State Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        public List<AssessmentListmaster> GetStateList(AssessmentListmaster objAssessmentListmaster)
        {
            List<AssessmentListmaster> ObjStateList = new List<AssessmentListmaster>();
            try
            {
                var paramList = new
                {
                    Chk = "State",
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<AssessmentListmaster>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjStateList = Output.ToList();
                }
                return ObjStateList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the District Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        public List<AssessmentListmaster> GetDistrictList(AssessmentListmaster objAssessmentListmaster)
        {
            List<AssessmentListmaster> ObjDistrictList = new List<AssessmentListmaster>();
            try
            {
                var paramList = new
                {
                    Chk = "District",
                    StateID = objAssessmentListmaster.StateId
                };
                DynamicParameters param = new DynamicParameters();

                var Output = Connection.Query<AssessmentListmaster>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {
                    ObjDistrictList = Output.ToList();
                }
                return ObjDistrictList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Tehsil Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        public List<AssessmentListmaster> GetTehsilList(AssessmentListmaster objAssessmentListmaster)
        {
            List<AssessmentListmaster> ObjTehsilList = new List<AssessmentListmaster>();
            try
            {
                var paramList = new
                {
                    DistrictID = objAssessmentListmaster.DistrictId,
                    chk = "8"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<AssessmentListmaster>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjTehsilList = Output.ToList();
                }
                return ObjTehsilList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Village Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        public List<AssessmentListmaster> GetVillageList(AssessmentListmaster objAssessmentListmaster)
        {
            List<AssessmentListmaster> ObjVillageList = new List<AssessmentListmaster>();
            try
            {
                var paramList = new
                {
                    TehsilID = objAssessmentListmaster.TehsilID,
                    chk = "9"
                };
                DynamicParameters param = new DynamicParameters();

                var Output = Connection.Query<AssessmentListmaster>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {

                    ObjVillageList = Output.ToList();
                }

                return ObjVillageList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #endregion
        /// <summary>
        /// Bind Financial Year List details in view
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        public List<AssessmentListmaster> GetFYList(AssessmentListmaster objAssessmentListmaster)
        {
            List<AssessmentListmaster> ObjFYList = new List<AssessmentListmaster>();
            try
            {
                var paramList = new
                {
                    Check = 4
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<AssessmentListmaster>("[GetFinancialYearList]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjFYList = Output.ToList();
                }
                return ObjFYList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region View Assessment Template List
        /// <summary>
        /// To Bind the Assessment Template List Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        public AssessmentListmaster ViewAssessmentTemplateListmaster(AssessmentListmaster objAssessmentListmaster)
        {
            AssessmentListmaster objAssessmentListMaster = new AssessmentListmaster();
            try
            {
                var paramList = new
                {
                    UserID = objAssessmentListmaster.UserId,
                    ReportingYear = objAssessmentListmaster.Year,
                };
                var Output = Connection.Query<AssessmentListmaster>("SP_SelfAssementTemplate", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objAssessmentListMaster = Output.FirstOrDefault();
                }
                return objAssessmentListMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        
    }
}
