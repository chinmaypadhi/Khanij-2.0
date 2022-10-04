using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.MineralSize
{
    public class MineralSizeProvider : RepositoryBase, IMineralSizeProvider
    {
        public MineralSizeProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        /// <summary>
        /// Add Mineral Size
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddMineralSize(MineralSizeMaster mineralSizeMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 1);
                p.Add("@MineralSize", mineralSizeMaster.MineralSize);
                p.Add("@MineralSizeId", 0);
                p.Add("@CreatedBy", mineralSizeMaster.CreatedBy);
                p.Add("@UserloginId", mineralSizeMaster.CreatedBy);
                p.Add("@IsActive", mineralSizeMaster.IsActive == null ? true : mineralSizeMaster.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("uspMineralSizeMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// Delete Mineral Size
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteMineralSize(MineralSizeMaster mineralSizeMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "@MineralSizeId",mineralSizeMaster.MineralSizeId,
                        "@operation",3,
                        "@CreatedBy",mineralSizeMaster.CreatedBy,
                        "@UserLoginId",mineralSizeMaster.CreatedBy
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = await Connection.QueryAsync<string>("uspMineralSizeMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Edit Mineral Size
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>
        public async Task<MineralSizeMaster> EditMineralSize(MineralSizeMaster mineralSizeMaster)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@MineralSizeId", mineralSizeMaster.MineralSizeId);
                var result = await Connection.QueryAsync<MineralSizeMaster>("uspMineralSizeMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    mineralSizeMaster = result.FirstOrDefault();
                }
                return mineralSizeMaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                mineralSizeMaster = null;
            }
        }

        /// <summary>
        /// Update Mineral Size
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateMineralSize(MineralSizeMaster mineralSizeMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@operation", 2);
                p.Add("@MineralSize", mineralSizeMaster.MineralSize);
                p.Add("@MineralSizeId", mineralSizeMaster.MineralSizeId);
                p.Add("@CreatedBy", mineralSizeMaster.CreatedBy);
                p.Add("@UserloginId", mineralSizeMaster.CreatedBy);
                p.Add("@IsActive", mineralSizeMaster.IsActive == null ? true : mineralSizeMaster.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("uspMineralSizeMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// View Mineral Size
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>
        public async Task<List<MineralSizeMaster>> ViewMineralSize(MineralSizeMaster mineralSizeMaster)
        {
            List<MineralSizeMaster> listMineralSizeMaster = new List<MineralSizeMaster>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                var result = await Connection.QueryAsync<MineralSizeMaster>("uspMineralSizeMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    listMineralSizeMaster = result.ToList();
                }
                return listMineralSizeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                listMineralSizeMaster = null;
            }
        }
    }
}
