using Newtonsoft.Json;
using PermitApp.Models.Utility;
using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApp.Areas.ECCapping.Models.ECCapping
{
    public class ECCappingModel : IECCappingModel
    {
        IHttpWebClients _objIHttpWebClients;

        public ECCappingModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public ECCappingEF GetAllGradeWiseOpeningStock(ECCappingEF objUser)
        {
            try
            {
                return JsonConvert.DeserializeObject<ECCappingEF>(_objIHttpWebClients.PostRequest("ecCapping/GetECCapingStocks", JsonConvert.SerializeObject(objUser)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ECCappingEF GetYear(ECCappingEF objUser)
        {
            try
            {
                return JsonConvert.DeserializeObject<ECCappingEF>(_objIHttpWebClients.PostRequest("ecCapping/GetECCapingFinancialYears", JsonConvert.SerializeObject(objUser)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ECCappingEF> GetAllCappingData(ECCappingEF objUser)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ECCappingEF>>(_objIHttpWebClients.PostRequest("ecCapping/GetAllCappingData", JsonConvert.SerializeObject(objUser)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ECCappingEF> GetAllPreviousDetails(ECCappingEF objUser)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ECCappingEF>>(_objIHttpWebClients.PostRequest("ecCapping/GetAllPreviousYearECDetails", JsonConvert.SerializeObject(objUser)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        




        public List<ECCappingEF> GetAllApprovalCappingData(ECCappingEF objUser)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ECCappingEF>>(_objIHttpWebClients.PostRequest("ecCapping/GetAllApprovalData", JsonConvert.SerializeObject(objUser)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

      





        public MessageEF AddEccapping(ECCappingEF objUser)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("ecCapping/AddAllECcappingStocks", JsonConvert.SerializeObject(objUser)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public MessageEF SubmitApproval(ECCappingEF objUser)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("ecCapping/SaveApprovalData", JsonConvert.SerializeObject(objUser)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

      


        public MessageEF UpdateEccapping(ECCappingEF objUser)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("ecCapping/UpdateAllECcappingStocks", JsonConvert.SerializeObject(objUser)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        

             public ECCappingEF GetGradeOpeningStockById(ECCappingEF objUser)
            {
                try
                {
                    return JsonConvert.DeserializeObject<ECCappingEF>(_objIHttpWebClients.PostRequest("ecCapping/GetGradeWiseOpeningStocks", JsonConvert.SerializeObject(objUser)));

                }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
