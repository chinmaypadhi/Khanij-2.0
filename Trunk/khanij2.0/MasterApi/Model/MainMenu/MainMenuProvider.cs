using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.MainMenu
{
    public class MainMenuProvider : RepositoryBase, IMainMenuProvider
    {
        public MainMenuProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        /// <summary>
        /// Add Main Menu
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        public async Task<MessageEF> AddMainMenu(MainMenuMaster mainMenuMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 1);
                p.Add("@MmenuID", mainMenuMaster.MmenuID);
                p.Add("@MainMenuName", mainMenuMaster.MainMenuName);
                p.Add("@ModuleId", mainMenuMaster.ModuleId);
                p.Add("@icon", mainMenuMaster.icon);
                p.Add("@LinkPath", mainMenuMaster.LinkPath);
                p.Add("@Slno", mainMenuMaster.Slno);
                p.Add("@CreatedBy", mainMenuMaster.CreatedBy);
                p.Add("@SvgPath", mainMenuMaster.SvgPath);
                p.Add("@divclass", mainMenuMaster.divclass);
                p.Add("@UserloginId", mainMenuMaster.CreatedBy);
                p.Add("@IsActive", mainMenuMaster.IsActive == null ? true : mainMenuMaster.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("uspMainMenuMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// Delete Main Menu
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        public async Task<MessageEF> DeleteMainMenu(MainMenuMaster mainMenuMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "@MmenuID",mainMenuMaster.MmenuID,
                        "@operation",3,
                        "@CreatedBy",mainMenuMaster.CreatedBy,
                        "@UserLoginId",mainMenuMaster.CreatedBy
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = await Connection.QueryAsync<string>("uspMainMenuMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Edit Main Menu
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        public async Task<MainMenuMaster> EditMainMenu(MainMenuMaster mainMenuMaster)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@MmenuID ", mainMenuMaster.MmenuID);
                var result = await Connection.QueryAsync<MainMenuMaster>("uspMainMenuMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    mainMenuMaster = result.FirstOrDefault();
                }
                return mainMenuMaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                mainMenuMaster = null;
            }
        }

        /// <summary>
        /// Update Main Menu
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        public async Task<MessageEF> UpdateMainMenu(MainMenuMaster mainMenuMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation",2);
                p.Add("@MmenuID", mainMenuMaster.MmenuID);
                p.Add("@MainMenuName", mainMenuMaster.MainMenuName);
                p.Add("@ModuleId", mainMenuMaster.ModuleId);
                p.Add("@icon", mainMenuMaster.icon);
                p.Add("@LinkPath", mainMenuMaster.LinkPath);
                p.Add("@Slno", mainMenuMaster.Slno);
                p.Add("@CreatedBy", mainMenuMaster.CreatedBy);
                p.Add("@SvgPath", mainMenuMaster.SvgPath);
                p.Add("@divclass", mainMenuMaster.divclass);
                p.Add("@UserloginId", mainMenuMaster.CreatedBy);
                p.Add("@UserloginId", mainMenuMaster.CreatedBy);
                p.Add("@IsActive", mainMenuMaster.IsActive == null ? true : mainMenuMaster.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("uspMainMenuMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// View Main Menu
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        public async Task<List<MainMenuMaster>> ViewMainMenu(MainMenuMaster mainMenuMaster)
        {
            List<MainMenuMaster> listMainMenuMaster = new List<MainMenuMaster>();
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                var result = await Connection.QueryAsync<MainMenuMaster>("uspMainMenuMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listMainMenuMaster = result.ToList();
                }

                return listMainMenuMaster; 
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listMainMenuMaster = null;
            }
        }
    }
}
