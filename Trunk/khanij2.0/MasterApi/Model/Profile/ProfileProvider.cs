// ***********************************************************************
//  Class Name               : ProfileProvider
//  Description              : View Lessee Profile details
//  Created By               : Lingaraj Dalai
//  Created On               : 10 Feb 2022
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Profile
{
    public class ProfileProvider : RepositoryBase, IProfileProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public ProfileProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Bind Profile Completion Count Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public async Task<LesseeInfoModel> GetProfileCompletionCount(LesseeInfoModel objLesseeInfoModel)
        {
            LesseeInfoModel ObjLesseeDetails = new LesseeInfoModel();
            try
            {
                var paramList = new
                {
                    USER_ID = objLesseeInfoModel.CREATED_BY,
                    MineralType = objLesseeInfoModel.MineralType
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeInfoModel>("[LESSEE_PROFILE_COMPLETION_COUNT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLesseeDetails = result.FirstOrDefault();
                }
                return ObjLesseeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Profile Completion Request Count Details in view
        /// </summary>
        /// <param name="objLesseeProfileIndividualCountModel"></param>
        /// <returns></returns>
        public async Task<LesseeProfileIndividualCountModel> GetLesseeProfileIndividualCountModel(LesseeProfileIndividualCountModel objLesseeProfileIndividualCountModel)
        {
            LesseeProfileIndividualCountModel ObjLesseeProfileIndividualCountModel = new LesseeProfileIndividualCountModel();
            try
            {
                var paramList = new
                {
                    UserID = objLesseeProfileIndividualCountModel.UserId,
                    IndividualId = objLesseeProfileIndividualCountModel.IndividualId
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeProfileIndividualCountModel>("[LESSEE_DGM_PROFILE_REQUEST_INDIVIDUAL_COUNT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLesseeProfileIndividualCountModel = result.FirstOrDefault();
                }
                return ObjLesseeProfileIndividualCountModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Lessee Licensee Users by District in view
        /// </summary>
        /// <param name="objLesseeProfileIndividualCountModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeProfileIndividualCountModel>> GetLesseeLicneseeUserByDistrict(LesseeProfileIndividualCountModel objLesseeProfileIndividualCountModel)
        {
            List<LesseeProfileIndividualCountModel> ObjlistLesseeProfileIndividualCountModel = new List<LesseeProfileIndividualCountModel>();
            try
            {
                var paramList = new
                {
                    UserId = objLesseeProfileIndividualCountModel.UserId,
                    UserTypeName = objLesseeProfileIndividualCountModel.UserTypeName
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeProfileIndividualCountModel>("[GetDistrictwiseLessee_Licensee]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjlistLesseeProfileIndividualCountModel = result.ToList();
                }
                return ObjlistLesseeProfileIndividualCountModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Lessee Users by User,Role type in view
        /// </summary>
        /// <param name="objLesseeListForDGMModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeListForDGMModel>> GetLesseeListDGM(LesseeListForDGMModel objLesseeListForDGMModel)
        {
            List<LesseeListForDGMModel> ObjLesseeListForDGMModel = new List<LesseeListForDGMModel>();
            try
            {
                var paramList = new
                {
                    DGMId = objLesseeListForDGMModel.UserId,
                    RoleTypeName = objLesseeListForDGMModel.RoleTypeName,
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeListForDGMModel>("[GetDetailsOnboard]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjLesseeListForDGMModel = result.ToList();
                }
                return ObjLesseeListForDGMModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
