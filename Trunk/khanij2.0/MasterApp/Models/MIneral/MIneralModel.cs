using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Models.Utility;
using MasterEF;
using Newtonsoft.Json;

namespace MasterApp.Models.MIneral
{

    public class MIneralModel:IMIneralModel
    {
        IHttpWebClients _objIHttpWebClients;
        public MIneralModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public MessageEF Add(MineralCategory objMineralCategory)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Mineral/Add", JsonConvert.SerializeObject(objMineralCategory)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF Update(MineralCategory objMineralCategory)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Mineral/Update", JsonConvert.SerializeObject(objMineralCategory)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public List<MineralCategory> View(MineralCategory objMineralCategory)
        {
            try
            {
                List<MineralCategory> objlistMineralCategory = new List<MineralCategory>();
                objlistMineralCategory = JsonConvert.DeserializeObject<List<MineralCategory>>(_objIHttpWebClients.PostRequest("Mineral/View", JsonConvert.SerializeObject(objMineralCategory)));
                return objlistMineralCategory;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF Delete(MineralCategory objMineralCategory)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Mineral/Delete", JsonConvert.SerializeObject(objMineralCategory)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MineralCategory Edit(MineralCategory objMineralCategory)
        {
            try
            {
                objMineralCategory = JsonConvert.DeserializeObject<MineralCategory>(_objIHttpWebClients.PostRequest("Mineral/Edit", JsonConvert.SerializeObject(objMineralCategory)));
                return objMineralCategory;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
