using MasterApp.Models.Utility;
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.MineralSize
{
    public class MineralSizeMasterModel : IMineralSizeMasterModel
    {
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Add Mineral Size
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>
        public MineralSizeMasterModel(IHttpWebClients httpWebClients)
        {
            _objIHttpWebClients = httpWebClients;
        }
        public MessageEF AddMineralSize(MineralSizeMaster mineralSizeMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralSize/Add", JsonConvert.SerializeObject(mineralSizeMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete Mineral Size
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>

        public MessageEF DeleteMineralSize(MineralSizeMaster mineralSizeMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralSize/Delete", JsonConvert.SerializeObject(mineralSizeMaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Edit Mineral Size
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>

        public MineralSizeMaster EditMineralSize(MineralSizeMaster mineralSizeMaster)
        {
            try
            {
                mineralSizeMaster = JsonConvert.DeserializeObject<MineralSizeMaster>(_objIHttpWebClients.PostRequest("MineralSize/Edit", JsonConvert.SerializeObject(mineralSizeMaster)));
                return mineralSizeMaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       /// <summary>
       /// Update Mineral Size
       /// </summary>
       /// <param name="mineralSizeMaster"></param>
       /// <returns></returns>
        
        public MessageEF UpdateMineralSize(MineralSizeMaster mineralSizeMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralSize" +
                    "/Update", JsonConvert.SerializeObject(mineralSizeMaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// View Mineral Size
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>

        public List<MineralSizeMaster> ViewMineralSize(MineralSizeMaster mineralSizeMaster)
        {
            try
            {
                List<MineralSizeMaster> listMineralSizeMaster = new List<MineralSizeMaster>();
                listMineralSizeMaster = JsonConvert.DeserializeObject<List<MineralSizeMaster>>(_objIHttpWebClients.PostRequest("MineralSize/ViewDetails", JsonConvert.SerializeObject(mineralSizeMaster)));
                return listMineralSizeMaster;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
