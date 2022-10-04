using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ReturnEF;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using ReturnApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace ReturnApp.Areas.eReturn_NonCoal.Models
{
    public class eReturnNonCoalModel : IeReturnNonCoalModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public eReturnNonCoalModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        public DDLResult GetFyDDL(MonthlyReturnModelNonCoal objDD)
        {
            try
            {
                
                return JsonConvert.DeserializeObject<DDLResult>(_objIHttpWebClients.PostRequest("eReturnNonCoal/ViewFYDDL", JsonConvert.SerializeObject(objDD)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<MonthlyReturnModelNonCoal> ViewLst(MonthlyReturnModelNonCoal model)
        {
            try
            {
                List<MonthlyReturnModelNonCoal> objlist = new List<MonthlyReturnModelNonCoal>();

                objlist = JsonConvert.DeserializeObject<List<MonthlyReturnModelNonCoal>>(_objIHttpWebClients.PostRequest("eReturnNonCoal/ViewData", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public GetFormF1DetailsModel GetLesseMineDeatils(MonthlyReturnModelNonCoal model)
        {
            try
            {
                GetFormF1DetailsModel objlist = new GetFormF1DetailsModel();

                  objlist = JsonConvert.DeserializeObject<GetFormF1DetailsModel>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetLesseMineDeatils", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public GetFormF1DetailsModel GeteReturnSubmittedDetails(MonthlyReturnModelNonCoal model)
        {
            try
            {
                GetFormF1DetailsModel objlist = new GetFormF1DetailsModel();

                objlist = JsonConvert.DeserializeObject<GetFormF1DetailsModel>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GeteReturnSubmittedDetails", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public GetRentRoyaltyDetailsModel GetRentRoyalty(MonthlyReturnModelNonCoal model)
        {
            try
            {
                GetRentRoyaltyDetailsModel objlist = new GetRentRoyaltyDetailsModel();

                objlist = JsonConvert.DeserializeObject<GetRentRoyaltyDetailsModel>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetRentRoyalty", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddRoyaltyDetails(GetFormF1DetailsModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/AddRoyaltyDetails", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF UpdateRoyaltyDetails(GetFormF1DetailsModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/UpdateRoyaltyDetails", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public GetFormF1DetailsModel GetMineralInfo(MonthlyReturnModelNonCoal model)
        {
            try
            {
                GetFormF1DetailsModel objlist = new GetFormF1DetailsModel();

                objlist = JsonConvert.DeserializeObject<GetFormF1DetailsModel>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetMineralInfo", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ProductionModel_Monthly GetProduction(MonthlyReturnModelNonCoal model)
        {
            try
            {
                ProductionModel_Monthly objlist = new ProductionModel_Monthly();

                objlist = JsonConvert.DeserializeObject<ProductionModel_Monthly>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetProduction", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Details_of_deductions_Monthly GetDetails_of_deductions(GetFormF1DetailsModel model)
        {
            try
            {
                Details_of_deductions_Monthly objlist = new Details_of_deductions_Monthly();

                objlist = JsonConvert.DeserializeObject<Details_of_deductions_Monthly>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetDetails_of_deductions", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Reason_Inc_Dec_Monthly GetReason_Inc_Dec(GetFormF1DetailsModel model)
        {
            try
            {
                Reason_Inc_Dec_Monthly objlist = new Reason_Inc_Dec_Monthly();

                objlist = JsonConvert.DeserializeObject<Reason_Inc_Dec_Monthly>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetReason_Inc_Dec", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Details_of_deductions_Monthly Getpulverization(GetFormF1DetailsModel model)
        {
            try
            {
                Details_of_deductions_Monthly objlist = new Details_of_deductions_Monthly();

                objlist = JsonConvert.DeserializeObject<Details_of_deductions_Monthly>(_objIHttpWebClients.PostRequest("eReturnNonCoal/Getpulverization", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ProductionModel_Monthly OpeningStock(GetFormF1DetailsModel model)
        {
            try
            {
                ProductionModel_Monthly objlist = new ProductionModel_Monthly();

                objlist = JsonConvert.DeserializeObject<ProductionModel_Monthly>(_objIHttpWebClients.PostRequest("eReturnNonCoal/OpeningStock", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DDLResult GetMineralForm(MonthlyReturnModelNonCoal objDD)
        {
            try
            {

                return JsonConvert.DeserializeObject<DDLResult>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetMineralForm", JsonConvert.SerializeObject(objDD)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public DDLResult GetMineralGrade(MonthlyReturnModelNonCoal objDD)
        {
            try
            {

                return JsonConvert.DeserializeObject<DDLResult>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetMineralGrade", JsonConvert.SerializeObject(objDD)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF ADDGradewise_ROM(Gradewise_ROMModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/ADDGradewise_ROM", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Gradewise_ROMModel> GetGradewise_ROM(MonthlyReturnModelNonCoal model)
        {
            try
            {
                List<Gradewise_ROMModel> objlist = new List<Gradewise_ROMModel>();

                objlist = JsonConvert.DeserializeObject<List<Gradewise_ROMModel>>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetGradewise_ROM", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF UpdateGradewise_ROM(Gradewise_ROMModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/UpdateGradewise_ROM", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF DeleteGradewise_ROM(Gradewise_ROMModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/DeleteGradewise_ROM", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DDLResult GetMineralFormProduction(MonthlyReturnModelNonCoal objDD)
        {
            try
            {

                return JsonConvert.DeserializeObject<DDLResult>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetMineralFormProduction", JsonConvert.SerializeObject(objDD)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF ADDGradewise_Production(Grade_WiseProduction objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/ADDGradewise_Production", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Grade_WiseProduction> GetGrade_WiseProduction(MonthlyReturnModelNonCoal model)
        {
            try
            {
                List<Grade_WiseProduction> objlist = new List<Grade_WiseProduction>();

                objlist = JsonConvert.DeserializeObject<List<Grade_WiseProduction>>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetGrade_WiseProduction", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF UpdateGradewise_Prod(Grade_WiseProduction objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/UpdateGradewise_Prod", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF DeleteGradewise_Prod(Grade_WiseProduction objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/DeleteGradewise_Prod", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<SalesDispatchModel> GetNatureOfDispatch(SalesDispatchModel model)
        {
            try
            {
                List<SalesDispatchModel> objlist = new List<SalesDispatchModel>();

                objlist = JsonConvert.DeserializeObject<List<SalesDispatchModel>>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetNatureOfDispatch", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<SalesDispatchModel> GetPurchaserConsignee(MonthlyReturnModelNonCoal model)
        {
            try
            {
                List<SalesDispatchModel> objlist = new List<SalesDispatchModel>();

                objlist = JsonConvert.DeserializeObject<List<SalesDispatchModel>>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetPurchaserConsignee", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF AddSaleDispatch(SalesDispatchModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/AddSaleDispatch", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<SalesDispatchModel> GetSalesDespatch(MonthlyReturnModelNonCoal model)
        {
            try
            {
                List<SalesDispatchModel> objlist = new List<SalesDispatchModel>();

                objlist = JsonConvert.DeserializeObject<List<SalesDispatchModel>>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetSalesDespatch", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF UpdateSaleDispatch(SalesDispatchModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/UpdateSaleDispatch", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF DeleteSaleDispatch(SalesDispatchModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/DeleteSaleDispatch", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF AddPulverization(Mineral_PulverizedModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/Addpulverization", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Mineral_PulverizedModel> GetMineral_Pulverized(MonthlyReturnModelNonCoal model)
        {
            try
            {
                List<Mineral_PulverizedModel> objlist = new List<Mineral_PulverizedModel>();

                objlist = JsonConvert.DeserializeObject<List<Mineral_PulverizedModel>>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetMineral_Pulverized", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF UpdateMineral_Pulverized(Mineral_PulverizedModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/UpdateMineral_Pulverized", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF DeleteeMineral_Pulverized(Mineral_PulverizedModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/DeleteeMineral_Pulverized", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF AddReasonForInDc(Reason_Inc_Dec_Monthly objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/AddReasonForInDc", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF AddDeductionMade(Details_of_deductions_Monthly objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/AddDeductionMade", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF UpdateReasonForInDc(Reason_Inc_Dec_Monthly objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/UpdateReasonForInDc", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF UpdateDetails_of_deductions(Details_of_deductions_Monthly objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/UpdateDetails_of_deductions", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF AddTypeProductionPartTwo(ProductionModel_Monthly objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/AddTypeProductionPartTwo", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF UpdateTypeProductionPartTwo(ProductionModel_Monthly objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/UpdateTypeProductionPartTwo", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF Update_FinalSubmit(Reason_Inc_Dec_Monthly objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/Update_FinalSubmit", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF Addpulverization1(Details_of_deductions_Monthly objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/Addpulverization1", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF Updatepulverization(Details_of_deductions_Monthly objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/Updatepulverization", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public GetFormF1DetailsModel GetFormF1Part1ForPrint(MonthlyReturnModelNonCoal objModel)
        {
            try
            {
                GetFormF1DetailsModel objlist = new GetFormF1DetailsModel();

                objlist = JsonConvert.DeserializeObject<GetFormF1DetailsModel>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetFormF1Part1ForPrint", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Working_of_Mine> GetMineWorkDetails(MonthlyReturnModelNonCoal model)
        {
            try
            {
                List<Working_of_Mine> objlist = new List<Working_of_Mine>();

                objlist = JsonConvert.DeserializeObject<List<Working_of_Mine>>(_objIHttpWebClients.PostRequest("eReturnNonCoal/GetMineWorkDetails", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF Update_Filepath(MonthlyReturnModelNonCoal objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoal/Update_Filepath", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
