using EpassApp.Models.Utility;
using EpassEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.eCancel
{
    public class eCancel:IeCancel
    {
        IHttpWebClients _objIHttpWebClients;
        public eCancel(IHttpWebClients objIHttpWebClients)
        {

            _objIHttpWebClients = objIHttpWebClients;
        }

        public List<eCancelModel> eCancelPermit(eCancelModel objOpenModel)
        {
            //throw new NotImplementedException();
            
            try
            {
                List<eCancelModel> objListOpenPermit = new List<eCancelModel>();// Api controller name;method name inside the Api 
                objListOpenPermit = JsonConvert.DeserializeObject<List<eCancelModel>>(_objIHttpWebClients.PostRequest("eCancel/eCancelPermit", JsonConvert.SerializeObject(objOpenModel)));
                return objListOpenPermit;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DD> ddmodule(DD objOpenModel)
        {
            try
            {
                List<DD> objListOpenPermit = new List<DD>();// Api controller name;method name inside the Api 
                objListOpenPermit = JsonConvert.DeserializeObject<List<DD>>(_objIHttpWebClients.PostRequest("eCancel/ddmodule", JsonConvert.SerializeObject(objOpenModel)));
                return objListOpenPermit;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Dinesh 26Apr        
        public List<TPCancelModelEF> GetTP_Cancel(TPCancelModelEF objOpenModel)
        {
            try
            {
                List<TPCancelModelEF> objListOpenPermit = new List<TPCancelModelEF>();// Api controller name;method name inside the Api 
                objListOpenPermit = JsonConvert.DeserializeObject<List<TPCancelModelEF>>(_objIHttpWebClients.PostRequest("TPCancel/GetTP_Cancel", JsonConvert.SerializeObject(objOpenModel)));
                return objListOpenPermit;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
