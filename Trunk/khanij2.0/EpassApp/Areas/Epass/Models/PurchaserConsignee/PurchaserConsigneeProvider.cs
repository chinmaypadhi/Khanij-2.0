using EpassEF;
using EpassEF.ViewModel;
using EpassApp.Models.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.PurchaserConsignee
{
    public class PurchaserConsigneeProvider : IPurchaserConsigneeProvider
    {
        IHttpWebClients _objIHttpWebClients;
        public PurchaserConsigneeProvider()
        {

          
        }
        public PurchaserConsigneeProvider(IHttpWebClients objIHttpWebClients)
        {

            _objIHttpWebClients = objIHttpWebClients;
        }
        public List<PurchaserConsigneeOpenEpermitModel> GetOpenEpermitDetails(PurchaserConsigneeOpenEpermitModel objOpenModel)
        {
            try
            {
                List<PurchaserConsigneeOpenEpermitModel> objListOpenPermit = new List<PurchaserConsigneeOpenEpermitModel>();
                objListOpenPermit = JsonConvert.DeserializeObject<List<PurchaserConsigneeOpenEpermitModel>>(_objIHttpWebClients.PostRequest("PurchaserConsignee/ReadOpenEpermitDetails", JsonConvert.SerializeObject(objOpenModel)));
                return objListOpenPermit;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public List<PurchaserConsigneeModelView> PurchaserConsigneeByPermitId(PurchaserConsigneeModelView purchaserConsignee)
        {
            try
            {
                List<PurchaserConsigneeModelView> purchaserConsigneeModel = new List<PurchaserConsigneeModelView>();
                purchaserConsigneeModel = JsonConvert.DeserializeObject<List<PurchaserConsigneeModelView>>(_objIHttpWebClients.PostRequest("PurchaserConsignee/getDataByPermitId", JsonConvert.SerializeObject(purchaserConsignee)));
                return purchaserConsigneeModel;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public PurchaserConsigneePermitModel getGridBulkPermitMasterDataByBulkPermitId(PurchaserConsigneePermitModel purchaserConsignee)
        {
            try
            {

                purchaserConsignee = JsonConvert.DeserializeObject<PurchaserConsigneePermitModel>(_objIHttpWebClients.PostRequest("PurchaserConsignee/getGridBulkPermitMasterDataByBulkPermitId", JsonConvert.SerializeObject(purchaserConsignee)));
                return purchaserConsignee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EmpDropDown> Dropdown(EmpDropDown objEmpDropDown)
        {
            List<EmpDropDown> ListofficeLevelEF = new List<EmpDropDown>();
            try
            {
                ListofficeLevelEF = JsonConvert.DeserializeObject<List<EmpDropDown>>(_objIHttpWebClients.PostRequest("PurchaserConsignee/Dropdown", JsonConvert.SerializeObject(objEmpDropDown)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListofficeLevelEF;
        }


        public List<PurchaseConsignee> GetEndUserLisenseeDetails(PurchaseConsignee objPurchaseConsignee)
        {
            List<PurchaseConsignee> ListofficeLevelEF = new List<PurchaseConsignee>();
            try
            {
                ListofficeLevelEF = JsonConvert.DeserializeObject<List<PurchaseConsignee>>(_objIHttpWebClients.PostRequest("PurchaserConsignee/GetEndUserLisenseeDetails", JsonConvert.SerializeObject(objPurchaseConsignee)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListofficeLevelEF;
        }

        public PurchaserConsigneePermitModel getDestinationByPurchaseConsigneeId(PurchaserConsigneePermitModel purchaserConsignee)
        {
            try
            {

                purchaserConsignee = JsonConvert.DeserializeObject<PurchaserConsigneePermitModel>(_objIHttpWebClients.PostRequest("PurchaserConsignee/getDestinationByPurchaseConsigneeId", JsonConvert.SerializeObject(purchaserConsignee)));
                return purchaserConsignee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<PurchaserConsigneePermitModel> GetTransportationModeList(PurchaserConsigneePermitModel objPurchaseConsignee)
        {
            List<PurchaserConsigneePermitModel> ListPurchaserConsignee = new List<PurchaserConsigneePermitModel>();
            try
            {
                ListPurchaserConsignee = JsonConvert.DeserializeObject<List<PurchaserConsigneePermitModel>>(_objIHttpWebClients.PostRequest("PurchaserConsignee/GetTransportationModeList", JsonConvert.SerializeObject(objPurchaseConsignee)));

            }

            catch (Exception ex)
            {
                throw;
            }
            return ListPurchaserConsignee;
        }


        public List<EmpDropDown> GetStateDistrictList()
        {
            List<EmpDropDown> ListPurchaserConsignee = new List<EmpDropDown>();
            try
            {
                ListPurchaserConsignee = JsonConvert.DeserializeObject<List<EmpDropDown>>(_objIHttpWebClients.PostRequest("PurchaserConsignee/GetStateDistrictList", ""));

            }

            catch (Exception ex)
            {
                throw;
            }
            return ListPurchaserConsignee;
        }
        public List<EmpDropDown> GetLicenseeTypeLists(PurchaserConsigneePermitModel objpurchase)
        {
            List<EmpDropDown> ListPurchaserConsignee = new List<EmpDropDown>();
            try
            {
                ListPurchaserConsignee = JsonConvert.DeserializeObject<List<EmpDropDown>>(_objIHttpWebClients.PostRequest("PurchaserConsignee/GetLicenseeTypeLists", JsonConvert.SerializeObject(objpurchase)));

            }

            catch (Exception ex)
            {
                throw;
            }
            return ListPurchaserConsignee;
        }


        public string GetCaptiveMineStatusOfLessee(PurchaserConsigneePermitModel objpurchase)
        {
            string result = string.Empty;
            try
            {
                result = JsonConvert.DeserializeObject<string>(_objIHttpWebClients.PostRequest("PurchaserConsignee/GetCaptiveMineStatusOfLessee", JsonConvert.SerializeObject(objpurchase)));

            }

            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public List<PurchaseConsignee> GetEndUserLisensee(PurchaserConsigneePermitModel objpurchase)
        {
            List<PurchaseConsignee> ListPurchaserConsignee = new List<PurchaseConsignee>();
            try
            {
                ListPurchaserConsignee = JsonConvert.DeserializeObject<List<PurchaseConsignee>>(_objIHttpWebClients.PostRequest("PurchaserConsignee/GetEndUserLisensee", JsonConvert.SerializeObject(objpurchase)));

            }

            catch (Exception ex)
            {
                throw;
            }
            return ListPurchaserConsignee;
        }

        public List<PurchaseConsignee> GetEndUserLisenseeTypeForWasheryDetails(PurchaserConsigneePermitModel objpurchase)
        {
            List<PurchaseConsignee> ListPurchaserConsignee = new List<PurchaseConsignee>();
            try
            {
                ListPurchaserConsignee = JsonConvert.DeserializeObject<List<PurchaseConsignee>>(_objIHttpWebClients.PostRequest("PurchaserConsignee/GetEndUserLisenseeTypeForWasheryDetails", JsonConvert.SerializeObject(objpurchase)));

            }

            catch (Exception ex)
            {
                throw;
            }
            return ListPurchaserConsignee;
        }


        public List<PurchaseConsignee> GetEndUserLisenseeWasheryDetails(PurchaserConsigneePermitModel objpurchase)
        {
            List<PurchaseConsignee> ListPurchaserConsignee = new List<PurchaseConsignee>();
            try
            {
                ListPurchaserConsignee = JsonConvert.DeserializeObject<List<PurchaseConsignee>>(_objIHttpWebClients.PostRequest("PurchaserConsignee/GetEndUserLisenseeWasheryDetails", JsonConvert.SerializeObject(objpurchase)));

            }

            catch (Exception ex)
            {
                throw;
            }
            return ListPurchaserConsignee;
        }


        public string AddData(PurchaserConsigneeModel objpurchase)
        {
            string result = string.Empty;
            try
            {
                result = JsonConvert.DeserializeObject<string>(_objIHttpWebClients.PostRequest("PurchaserConsignee/AddData", JsonConvert.SerializeObject(objpurchase)));

            }

            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public List<PurchaserConsigneeModel> GetGridData(PurchaserConsigneeModel objOpenModel)
        {
            try
            {
                List<PurchaserConsigneeModel> objListOpenPermit = new List<PurchaserConsigneeModel>();
                objListOpenPermit = JsonConvert.DeserializeObject<List<PurchaserConsigneeModel>>(_objIHttpWebClients.PostRequest("PurchaserConsignee/GetGridData", JsonConvert.SerializeObject(objOpenModel)));
                return objListOpenPermit;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string DeleteData(PurchaserConsigneeModel objpurchase)
        {
            string result = string.Empty;
            try
            {
                result = JsonConvert.DeserializeObject<string>(_objIHttpWebClients.PostRequest("PurchaserConsignee/DeleteData", JsonConvert.SerializeObject(objpurchase)));

            }

            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public List<PurchaseConsignee> GetOtherEndUserLisenseeDetails(PurchaseConsignee objPurchaseConsignee)
        {
            List<PurchaseConsignee> ListofficeLevelEF = new List<PurchaseConsignee>();
            try
            {
                ListofficeLevelEF = JsonConvert.DeserializeObject<List<PurchaseConsignee>>(_objIHttpWebClients.PostRequest("PurchaserConsignee/GetOtherEndUserLisenseeDetails", JsonConvert.SerializeObject(objPurchaseConsignee)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListofficeLevelEF;
        }
        public List<PurchaserConsigneeModel> Getcheckpost()
        {
            List<PurchaserConsigneeModel> ListofficeLevelEF = new List<PurchaserConsigneeModel>();
            try
            {
                ListofficeLevelEF = JsonConvert.DeserializeObject<List<PurchaserConsigneeModel>>(_objIHttpWebClients.PostRequest("PurchaserConsignee/Getcheckpost", ""));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListofficeLevelEF;
        }


       

    }
}
