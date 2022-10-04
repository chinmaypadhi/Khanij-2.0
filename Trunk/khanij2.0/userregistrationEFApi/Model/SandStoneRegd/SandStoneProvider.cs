using Dapper;
using MasterApi.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.SandStoneRegd
{
    public class SandStoneProvider : RepositoryBase, ISandStoneProvider
    {
        public SandStoneProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// AddEndUserData
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<MessageEF> SubmitSandStoneRegd(SandStoneModels SandStoneModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("@ACTIONCODE", "Submit");
                p.Add("@ApplicationID", SandStoneModel.ApplicationID);
                p.Add("@Name", SandStoneModel.Name);
                p.Add("@MobileNo", SandStoneModel.MobileNo);
                p.Add("@EmailID", SandStoneModel.EmailID);
                p.Add("@Address", SandStoneModel.Address);
                p.Add("@Pincode", SandStoneModel.Pincode);
                p.Add("@StateId", SandStoneModel.StateId);
                p.Add("@DistrictID", SandStoneModel.DistrictID);
                p.Add("@BlockId", SandStoneModel.BlockId);
                p.Add("@MineralNatureId", SandStoneModel.MineralNatureId);
                p.Add("@MineralId", SandStoneModel.MineralId);
                p.Add("@UserTypeId", SandStoneModel.UserTypeId);
                p.Add("@LesseeLicenseeId", SandStoneModel.LesseeLicenseeId);
                p.Add("@MineralQty", SandStoneModel.MineralQty);
                p.Add("@Purpose", SandStoneModel.Purpose);
                p.Add("@IsSMS", 1);
                p.Add("@IsMailed", 1);
                //p.Add("@CreatedDate", SandStoneModel.CreatedDate);
                p.Add("@MSGOUT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_POST_SAND_STONE_USER_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("MSGOUT");
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
        /// GetState
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<List<SandStoneModels>> GetState(SandStoneModels SandStoneModel)
        {
            List<SandStoneModels> LobjDP = new List<SandStoneModels>();
            try
            {
                var paramList = new
                {
                    P_Acction = "State",
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<SandStoneModels>("UspBindDropDownsandstone", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjDP = result.ToList();
                }

                return LobjDP;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjDP = null;
            }
        }
        /// <summary>
        /// GetDistrict
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public async Task<List<SandStoneModels>> GetDistrict(SandStoneModels SandStoneModel)
        {
            List<SandStoneModels> LobjDP = new List<SandStoneModels>();
            try
            {
                var paramList = new
                {
                    P_StateId = SandStoneModel.StateId,
                    P_Acction = "District",

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<SandStoneModels>("UspBindDropDownsandstone", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjDP = result.ToList();
                }

                return LobjDP;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjDP = null;
            }
        }
        /// <summary>
        /// Get Block
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public async Task<List<SandStoneModels>> GetBlock(SandStoneModels SandStoneModel)
        {
            List<SandStoneModels> LobjDP = new List<SandStoneModels>();
            try
            {
                var paramList = new
                {
                    P_StateId = SandStoneModel.StateId,
                    P_DistrictId = SandStoneModel.DistrictID,
                    P_Acction = "Tehsil"
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<SandStoneModels>("UspBindDropDownsandstone", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjDP = result.ToList();
                }

                return LobjDP;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjDP = null;
            }
        }
        /// <summary>
        /// Get Mineral Name
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public async Task<List<SandStoneModels>> GetMineralName(SandStoneModels SandStoneModel)
        {
            List<SandStoneModels> LobjDP = new List<SandStoneModels>();
            try
            {
                var paramList = new
                {
                    P_Acction = "MineralName",
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<SandStoneModels>("UspBindDropDownsandstone", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjDP = result.ToList();
                }

                return LobjDP;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjDP = null;
            }
        }
        /// <summary>
        /// GetDistrict
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public async Task<List<SandStoneModels>> GetUserType(SandStoneModels SandStoneModel)
        {
            List<SandStoneModels> LobjDP = new List<SandStoneModels>();
            try
            {
                var paramList = new
                {
                    UserTypeId = SandStoneModel.UserTypeId,
                    P_Acction = "UserType",
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<SandStoneModels>("UspBindDropDownsandstone", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjDP = result.ToList();
                }

                return LobjDP;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjDP = null;
            }
        }
        /// <summary>
        /// GetKo_Id
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public async Task<List<SandStoneModels>> GetKo_Id(SandStoneModels SandStoneModel)
        {
            List<SandStoneModels> LobjDP = new List<SandStoneModels>();
            try
            {
                var paramList = new
                {
                    @UserTypeId = SandStoneModel.UserTypeId,
                    @P_DistrictId = SandStoneModel.Dist,
                    P_Acction = "KoId",

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<SandStoneModels>("UspBindDropDownsandstone", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjDP = result.ToList();
                }

                return LobjDP;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjDP = null;
            }
        }
        /// <summary>
        /// GetMineralForm
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public async Task<List<SandStoneModels>> GetMineralForm(SandStoneModels SandStoneModel)
        {
            List<SandStoneModels> LobjDP = new List<SandStoneModels>();
            try
            {
                var paramList = new
                {
                    P_Acction = "MineralForm",

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<SandStoneModels>("UspBindDropDownsandstone", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    LobjDP = result.ToList();
                }

                return LobjDP;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjDP = null;
            }
        }
        /// <summary>
        /// GetMineralForm
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public async Task<SandStoneModels> GetSandStoneNamePass(SandStoneModels SandStoneModel)
        {
            SandStoneModels SandStoneModels = new SandStoneModels();
            try
            {
                var paramList = new
                {
                    P_Acction = "GetIdPass",
                    ApplicationID = SandStoneModel.ApplicationID
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<SandStoneModels>("UspBindDropDownsandstone", paramList, commandType: System.Data.CommandType.StoredProcedure);

                return SandStoneModels;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}