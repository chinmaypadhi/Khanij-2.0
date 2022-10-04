using EstablishmentApp.Models.Utility;
using EstablishmentEf;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.EmpPro.Models.Section
{
    public class SectionModel: ISectionModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;

        public SectionModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }


        //IHttpWebClients _objHttpWebClients;
        //public SectionModel(IHttpWebClients objHttpWebClients)
        //{
        //    _objHttpWebClients = objHttpWebClients;
        //}
        public MessageEF AddUpdateDelete(SectionEF Section)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralUnit/AddUpdateDelete", JsonConvert.SerializeObject(Section)));
                //objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objHttpWebClients.PostRequest("MineralUnit/AddUpdateDelete", Section));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }
        public List<SectionEF> GetOfficeLevel(SectionEF Section)
        {
            List<SectionEF> ListSectionEF = new List<SectionEF>();
            try
            {
                ListSectionEF = JsonConvert.DeserializeObject<List<SectionEF>>(_objIHttpWebClients.PostRequest("MineralUnit/GetOfficeLevel", JsonConvert.SerializeObject(Section)));
                //ListSectionEF = JsonConvert.DeserializeObject<List<SectionEF>>(_objHttpWebClients.PostRequest("MineralUnit/GetOfficeLevel", Section));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListSectionEF;
        }
        public SectionEF EditOfficeLevel(SectionEF Section)
        {
            SectionEF objSectionEF = new SectionEF();
            try
            {
                objSectionEF = JsonConvert.DeserializeObject<SectionEF>(_objIHttpWebClients.PostRequest("MineralUnit/EditOfficeLevel", JsonConvert.SerializeObject(Section)));
                //objSectionEF = JsonConvert.DeserializeObject<SectionEF>(_objHttpWebClients.PostRequest("MineralUnit/EditOfficeLevel", Section));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objSectionEF;
        }

        public async Task<List<SectionDropDown>> BindSection(SectionDropDown objLeaveDropDown)
        {
            List<SectionDropDown> listDropDown = new List<SectionDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<SectionDropDown>>(await _objIHttpWebClients.AwaitPostRequest("Section/BindSection", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<SectionDropDown>> BindSectionOfficer(SectionDropDown objLeaveDropDown)
        {
            List<SectionDropDown> listDropDown = new List<SectionDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<SectionDropDown>>(await _objIHttpWebClients.AwaitPostRequest("Section/BindSectionOfficer", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<SectionDropDown>> BindSectionOfficer2(SectionDropDown objLeaveDropDown)
        {
            List<SectionDropDown> listDropDown = new List<SectionDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<SectionDropDown>>(await _objIHttpWebClients.AwaitPostRequest("Section/BindSectionOfficer2", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF AddSectionOfficerTagging(SectionOfficerTaggingEF objSection)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Section/AddSectionOfficerTagging", JsonConvert.SerializeObject(objSection)));
                //objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objHttpWebClients.PostRequest("MineralUnit/AddUpdateDelete", Section));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }

        public async Task<List<SectionOfficerTaggingQueryEF>> ViewSectionOfficerTagging(SectionOfficerTaggingQueryEF objSectionOfficer)
        {
            List<SectionOfficerTaggingQueryEF> listDropDown = new List<SectionOfficerTaggingQueryEF>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<SectionOfficerTaggingQueryEF>>(await _objIHttpWebClients.AwaitPostRequest("Section/ViewSectionOfficerTagging", JsonConvert.SerializeObject(objSectionOfficer)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SectionOfficerTaggingEF> ViewSectionOfficerTaggingDetails(SectionOfficerTaggingEF objSectionOfficer)
        {
            SectionOfficerTaggingEF listDropDown = new SectionOfficerTaggingEF();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<SectionOfficerTaggingEF>(await _objIHttpWebClients.AwaitPostRequest("Section/ViewSectionOfficerTaggingDetails", JsonConvert.SerializeObject(objSectionOfficer)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteSectionOfficerTagging(SectionOfficerTaggingEF objSection)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Section/DeleteSectionOfficerTagging", JsonConvert.SerializeObject(objSection)));
                //objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objHttpWebClients.PostRequest("MineralUnit/AddUpdateDelete", Section));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }
    }
}
