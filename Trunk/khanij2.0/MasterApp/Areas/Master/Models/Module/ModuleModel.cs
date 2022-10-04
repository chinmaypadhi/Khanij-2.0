// ***********************************************************************
//  Class Name               : ModuleModel
//  Description              : Add,View,Edit,Update,Delete Module Master details
//  Created By               : Prakash Chandra Biswal
//  Created On               : 27 Dec 2021
// ***********************************************************************
using MasterApp.Models.Utility;
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Module
{
    public class ModuleModel : IModuleModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        // <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public ModuleModel(IHttpWebClients httpWebClients)
        {
            _objIHttpWebClients = httpWebClients;
        }
        /// <summary>
        /// To Add Module Name 
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        public MessageEF Add(ModuleMasterModel moduleMasterModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Module/Add", JsonConvert.SerializeObject(moduleMasterModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Module details in view
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        public MessageEF Update(ModuleMasterModel moduleMasterModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Module/Update", JsonConvert.SerializeObject(moduleMasterModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        ///  To View Module Names
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        public List<ModuleMasterModel> View(ModuleMasterModel moduleMasterModel)
        {
            try
            {
                List<ModuleMasterModel> objlistModule = new List<ModuleMasterModel>();
                objlistModule = JsonConvert.DeserializeObject<List<ModuleMasterModel>>(_objIHttpWebClients.PostRequest("Module/View", JsonConvert.SerializeObject(moduleMasterModel)));
                return objlistModule;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// To Delete Module Name
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        public MessageEF Delete(ModuleMasterModel moduleMasterModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Module/Delete", JsonConvert.SerializeObject(moduleMasterModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// To Edit Module Name
        /// </summary>
        /// <param name="objModuleMaster"></param>
        /// <returns></returns>
        public ModuleMasterModel Edit(ModuleMasterModel objModuleMaster)
        {
            try
            {
                objModuleMaster = JsonConvert.DeserializeObject<ModuleMasterModel>(_objIHttpWebClients.PostRequest("Module/Edit", JsonConvert.SerializeObject(objModuleMaster)));
                return objModuleMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
