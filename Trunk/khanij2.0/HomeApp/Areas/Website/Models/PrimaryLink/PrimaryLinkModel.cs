using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using HomeApp.Models.Utility;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace HomeApp.Areas.Website.Models.PrimaryLink
{
    
    public class PrimaryLinkModel: IPrimaryLinkModel
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor Dependency Injection
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="httpWebClients"></param>
        public PrimaryLinkModel(IOptions<KeyList> objKeyList, IHttpWebClients httpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = httpWebClients;
        }
        /// <summary>
        /// To add Primary Link Details
        /// </summary>
        /// <param name="primaryLinkModel"></param>
        /// <returns></returns>
        public MessageEF Add(AddPrimaryLinkModel primaryLinkModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PrimaryLink/Add", JsonConvert.SerializeObject(primaryLinkModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind About Us Submenus
        /// </summary>
        /// <param name="primaryLinkModel"></param>
        /// <returns></returns>
        public AddPrimaryLinkModel AboutUs(AddPrimaryLinkModel primaryLinkModel)
        {
            try
            {
                AddPrimaryLinkModel objPrimarylink = new AddPrimaryLinkModel();
                objPrimarylink = JsonConvert.DeserializeObject<AddPrimaryLinkModel>(_objIHttpWebClients.PostRequest("PrimaryLink/AboutUs", JsonConvert.SerializeObject(primaryLinkModel)));
                return objPrimarylink;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind Registration Submens
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        public AddPrimaryLinkModel Registrations(AddPrimaryLinkModel primaryLinkModel)
        {
            try
            {
                AddPrimaryLinkModel objPrimarylink = new AddPrimaryLinkModel();
                objPrimarylink = JsonConvert.DeserializeObject<AddPrimaryLinkModel>(_objIHttpWebClients.PostRequest("PrimaryLink/Registrations", JsonConvert.SerializeObject(primaryLinkModel)));
                return objPrimarylink;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind Statistical Reports
        /// </summary>
        /// <param name="primaryLinkModel"></param>
        /// <returns></returns>
        public AddPrimaryLinkModel StatisticalReports(AddPrimaryLinkModel primaryLinkModel)
        {
            try
            {
                AddPrimaryLinkModel objPrimarylink = new AddPrimaryLinkModel();
                objPrimarylink = JsonConvert.DeserializeObject<AddPrimaryLinkModel>(_objIHttpWebClients.PostRequest("PrimaryLink/StatisticalReports", JsonConvert.SerializeObject(primaryLinkModel)));
                return objPrimarylink;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Get Page List
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        public List<AddPrimaryLinkModel> GetPageList(AddPrimaryLinkModel objAddPrimaryLinkModel)
        {
            try
            {
                List<AddPrimaryLinkModel> objlistPage = new List<AddPrimaryLinkModel>();
                objlistPage = JsonConvert.DeserializeObject<List<AddPrimaryLinkModel>>(_objIHttpWebClients.PostRequest("PrimaryLink/GetPageList", JsonConvert.SerializeObject(objAddPrimaryLinkModel)));
                return objlistPage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Get Global Link list
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        public async Task<List<AddPrimaryLinkModel>> GetGlobalLinkList(AddPrimaryLinkModel addPrimaryLinkModel)
        {
            try
            {
                List<AddPrimaryLinkModel> objGlobalLinkList = new List<AddPrimaryLinkModel>();
                objGlobalLinkList = JsonConvert.DeserializeObject<List<AddPrimaryLinkModel>>(await _objIHttpWebClients.AwaitPostRequest("PrimaryLink/GetGlobalLinkList", JsonConvert.SerializeObject(addPrimaryLinkModel)));
                return objGlobalLinkList;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
