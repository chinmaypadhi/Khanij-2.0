using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Country
{
    public class CountryProvider : RepositoryBase, ICountryProvider
    {
        public CountryProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        /// <summary>
        /// Add Country details
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>

        public async Task<MessageEF> AddCountry(CountryMaster countryMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 1);
                p.Add("@CountryName", countryMaster.CountryName);
                p.Add("@CountryId", 0);
                p.Add("@CreatedBy", countryMaster.CreatedBy);
                p.Add("@UserloginId", countryMaster.CreatedBy);
                p.Add("@IsActive", countryMaster.IsActive == null ? true : countryMaster.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("uspCountryMasterOperation", p, commandType: CommandType.StoredProcedure);
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

        /// <summary>
        /// Delete Country
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>

        public async Task<MessageEF> DeleteCountry(CountryMaster countryMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "@CountryId",countryMaster.CountryId,
                        "@operation",3,
                        "@CreatedBy",countryMaster.CreatedBy,
                        "@UserLoginId",countryMaster.CreatedBy
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = await Connection.QueryAsync<string>("uspCountryMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
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

        /// <summary>
        /// Edit Country
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>

        public async Task<CountryMaster> EditCountry(CountryMaster countryMaster)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@CountryId", countryMaster.CountryId);
                var result = await Connection.QueryAsync<CountryMaster>("uspCountryMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    countryMaster = result.FirstOrDefault();
                }
                return countryMaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                countryMaster = null;
            }
        }

        /// <summary>
        /// Update Country
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>

        public async Task<MessageEF> UpdateCountry(CountryMaster countryMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@operation", 2);
                p.Add("@CountryName", countryMaster.CountryName);
                p.Add("@CountryId", countryMaster.CountryId);
                p.Add("@CreatedBy", countryMaster.CreatedBy);
                p.Add("@UserloginId", countryMaster.CreatedBy);
                p.Add("@IsActive", countryMaster.IsActive == null ? true : countryMaster.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("uspCountryMasterOperation", p, commandType: CommandType.StoredProcedure);
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

        /// <summary>
        /// View Country
        /// </summary>
        /// <param name="countryMaster"></param>
        /// <returns></returns>

        public async Task<List<CountryMaster>> ViewCountry(CountryMaster countryMaster)
        {
            List<CountryMaster> listCountry = new List<CountryMaster>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                var result =await Connection.QueryAsync<CountryMaster>("uspCountryMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listCountry = result.ToList();
                }

                return listCountry;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listCountry = null;
            }
        }

    }
}
