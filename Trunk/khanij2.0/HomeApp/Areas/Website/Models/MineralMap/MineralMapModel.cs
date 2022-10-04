// ***********************************************************************
//  Class Name               : MineralMapModel
//  Desciption               : Mineral Map Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 14 April 2022
// ***********************************************************************
using HomeApp.Models.Utility;
using HomeEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.MineralMap
{
    public class MineralMapModel:IMineralMapModel
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public MineralMapModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// View Mineral Map Count details in view
        /// </summary>
        /// <param name="objViewMineralMapModel"></param>
        /// <returns></returns>
        public ViewMineralMapModel ViewMineralMapCount(ViewMineralMapModel objViewMineralMapModel)
        {
            try
            {
                ViewMineralMapModel objsequence = new ViewMineralMapModel();
                objsequence = JsonConvert.DeserializeObject<ViewMineralMapModel>(_objIHttpWebClients.PostRequest("MineralMap/ViewMineralMapCount", JsonConvert.SerializeObject(objViewMineralMapModel)));
                return objsequence;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind District details in view
        /// </summary>
        /// <param name="objViewMineralMapModel"></param>
        /// <returns></returns>
        public List<ViewMineralMapModel> View(ViewMineralMapModel objViewMineralMapModel)
        {
            try
            {
                List<ViewMineralMapModel> listDistrictModel = new List<ViewMineralMapModel>();
                listDistrictModel = JsonConvert.DeserializeObject<List<ViewMineralMapModel>>(_objIHttpWebClients.PostRequest("District/ViewDetails", JsonConvert.SerializeObject(objViewMineralMapModel)));
                return listDistrictModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
