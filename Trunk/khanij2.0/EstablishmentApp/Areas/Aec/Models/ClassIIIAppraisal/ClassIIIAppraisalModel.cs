using EstablishmentApp.Models.Utility;
using EstablishmentEf;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.Aec.Models.ClassIIIAppraisal
{
    public class ClassIIIAppraisalModel: IClassIIIAppraisalModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;

        public ClassIIIAppraisalModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        //IHttpWebClients _objHttpWebClients;
        //public ClassIIIAppraisalModel(IHttpWebClients objHttpWebClients)
        //{
        //    _objHttpWebClients = objHttpWebClients;
        //}
        public  List<ClassIIIAppraisalEF> GetList(ClassIIIAppraisalEF objClassIIIAppraisalEF)
        {
            List<ClassIIIAppraisalEF> objListClassIIIAppraisalEF = new List<ClassIIIAppraisalEF>();
            try
            {
                objListClassIIIAppraisalEF = JsonConvert.DeserializeObject<List<ClassIIIAppraisalEF>>(_objIHttpWebClients.PostRequest("ClassIIIApprai/GetList", JsonConvert.SerializeObject(objClassIIIAppraisalEF)));

                //objListClassIIIAppraisalEF = JsonConvert.DeserializeObject<List<ClassIIIAppraisalEF>>(_objHttpWebClients.PostRequest("ClassIIIApprai/GetList", objClassIIIAppraisalEF));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objListClassIIIAppraisalEF;
        }
        public ClassIIIAppraisalEF GetDetails(ClassIIIAppraisalEF objClassIIIAppraisalEF)
        {

            try
            {
                objClassIIIAppraisalEF = JsonConvert.DeserializeObject<ClassIIIAppraisalEF>(_objIHttpWebClients.PostRequest("ClassIIIApprai/GetDetails", JsonConvert.SerializeObject(objClassIIIAppraisalEF)));

                //objClassIIIAppraisalEF = JsonConvert.DeserializeObject<ClassIIIAppraisalEF>(_objHttpWebClients.PostRequest("ClassIIIApprai/GetDetails", objClassIIIAppraisalEF));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objClassIIIAppraisalEF;
        }
       public  MessageEF AddPersonaldetails(ClassIIIAppraisalEF objClassIIIAppraisalEF)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("ClassIIIApprai/AddPersonaldetails", JsonConvert.SerializeObject(objClassIIIAppraisalEF)));
                //objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objHttpWebClients.PostRequest("ClassIIIApprai/AddPersonaldetails", objClassIIIAppraisalEF));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }
        public List<EmpDropDown> Dropdown(EmpDropDown objEmpDropDown)
        {
            List<EmpDropDown> ListofficeLevelEF = new List<EmpDropDown>();
            try
            {
                ListofficeLevelEF = JsonConvert.DeserializeObject<List<EmpDropDown>>(_objIHttpWebClients.PostRequest("EmpProfile/Dropdown", JsonConvert.SerializeObject(objEmpDropDown)));

                //ListofficeLevelEF = JsonConvert.DeserializeObject<List<EmpDropDown>>(_objHttpWebClients.PostRequest("EmpProfile/Dropdown", objEmpDropDown));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListofficeLevelEF;
        }
    }
}
