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
    public class eReturnNonCoalForm2Model: IeReturnNonCoalForm2Model
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public eReturnNonCoalForm2Model(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        public GetFormF1DetailsModel GetLesseMineDeatils(MonthlyReturnModelNonCoal model)
        {
            try
            {
                GetFormF1DetailsModel objlist = new GetFormF1DetailsModel();

                objlist = JsonConvert.DeserializeObject<GetFormF1DetailsModel>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetLesseMineDeatils", JsonConvert.SerializeObject(model)));
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

                objlist = JsonConvert.DeserializeObject<GetFormF1DetailsModel>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GeteReturnSubmittedDetails", JsonConvert.SerializeObject(model)));
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

                objlist = JsonConvert.DeserializeObject<GetRentRoyaltyDetailsModel>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetRentRoyalty", JsonConvert.SerializeObject(model)));
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

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/AddRoyaltyDetails", JsonConvert.SerializeObject(objModel)));
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

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/UpdateRoyaltyDetails", JsonConvert.SerializeObject(objModel)));
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

                objlist = JsonConvert.DeserializeObject<GetFormF1DetailsModel>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetMineralInfo", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF AddRecoveries(RecoveriesModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/AddRecoveries", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<RecoveriesModel> GetRecoveries(MonthlyReturnModelNonCoal model)
        {
            try
            {
                List<RecoveriesModel> objlist = new List<RecoveriesModel>();

                objlist = JsonConvert.DeserializeObject<List<RecoveriesModel>>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetRecoveries", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF UpdateRecoveries(RecoveriesModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/UpdateRecoveries", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF DeleteRecoveries(RecoveriesModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/DeleteRecoveries", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF AddRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/AddRecoveriesSmelter", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Recovery_atSmelterModel> GetRecoveriesSmelter(MonthlyReturnModelNonCoal model)
        {
            try
            {
                List<Recovery_atSmelterModel> objlist = new List<Recovery_atSmelterModel>();

                objlist = JsonConvert.DeserializeObject<List<Recovery_atSmelterModel>>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetRecoveriesSmelter", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF UpdateRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/UpdateRecoveriesSmelter", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF DeleteRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/DeleteRecoveriesSmelter", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Recovery_atSmelterModel> GetMineralGradeForTinMineral(MonthlyReturnModelNonCoal model)
        {
            try
            {
                List<Recovery_atSmelterModel> objlist = new List<Recovery_atSmelterModel>();

                objlist = JsonConvert.DeserializeObject<List<Recovery_atSmelterModel>>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetMineralGradeForTinMineral", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF AddSaleProduct(SaleProductModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/AddSaleProduct", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<SaleProductModel> GetSaleProduct(MonthlyReturnModelNonCoal model)
        {
            try
            {
                List<SaleProductModel> objlist = new List<SaleProductModel>();

                objlist = JsonConvert.DeserializeObject<List<SaleProductModel>>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetSaleProduct", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF UpdateSaleProduct(SaleProductModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/UpdateSaleProduct", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF DeleteSaleProduct(SaleProductModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/DeleteSaleProduct", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<SalesDispatchOf_OreModel> GetMineralFormProduction(MonthlyReturnModelNonCoal ObjMR)
        {
            try
            {

                return JsonConvert.DeserializeObject<List<SalesDispatchOf_OreModel>>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetMineralFormProduction", JsonConvert.SerializeObject(ObjMR)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<SalesDispatchModel> GetNatureOfDispatch(SalesDispatchModel ObjMR)
        {
            try
            {

                return JsonConvert.DeserializeObject<List<SalesDispatchModel>>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetNatureOfDispatch", JsonConvert.SerializeObject(ObjMR)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<SalesDispatchModel> GetPurchaserConsignee(MonthlyReturnModelNonCoal ObjMR)
        {
            try
            {

                return JsonConvert.DeserializeObject<List<SalesDispatchModel>>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetPurchaserConsignee", JsonConvert.SerializeObject(ObjMR)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/AddSaleDispatch", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<SalesDispatchOf_OreModel> GetSaleDispatch(MonthlyReturnModelNonCoal model)
        {
            try
            {
                List<SalesDispatchOf_OreModel> objlist = new List<SalesDispatchOf_OreModel>();

                objlist = JsonConvert.DeserializeObject<List<SalesDispatchOf_OreModel>>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetSaleDispatch", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF UpdateSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/UpdateSaleDispatch", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF DeleteSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/DeleteSaleDispatch", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddReasonForInDc(Reason_Inc_Dec_Monthly_FormF2 objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/AddReasonForInDc", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ProductionandStocksModel GetProductionandStocks(MonthlyReturnModelNonCoal objModel)
        {
            try
            {
                ProductionandStocksModel objlist = new ProductionandStocksModel();

                objlist = JsonConvert.DeserializeObject<ProductionandStocksModel>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetProductionandStocks", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF AddProductionandStocks(ProductionandStocksModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/AddProductionandStocks", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddDetails_of_deductions(Details_of_deductions_sale_computation objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/AddDetails_of_deductions", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Details_of_deductions_sale_computation GetDetails_of_deductions(MonthlyReturnModelNonCoal objModel)
        {
            try
            {
                Details_of_deductions_sale_computation objlist = new Details_of_deductions_sale_computation();

                objlist = JsonConvert.DeserializeObject<Details_of_deductions_sale_computation>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetDetails_of_deductions", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public Reason_Inc_Dec_Monthly_FormF2 GetReason_Inc_Dec(MonthlyReturnModelNonCoal objModel)
        {
            try
            {
                Reason_Inc_Dec_Monthly_FormF2 objlist = new Reason_Inc_Dec_Monthly_FormF2();

                objlist = JsonConvert.DeserializeObject<Reason_Inc_Dec_Monthly_FormF2>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetReason_Inc_Dec", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF UpdateProductionandStocks(ProductionandStocksModel objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/UpdateProductionandStocks", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF UpdateDetails_of_deductions(Details_of_deductions_sale_computation objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/UpdateDetails_of_deductions", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF UpdateReasonForInDc(Reason_Inc_Dec_Monthly_FormF2 objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/UpdateReasonForInDc", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF Update_FinalSubmit(Reason_Inc_Dec_Monthly_FormF2 objModel)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/Update_FinalSubmit", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public LesseeFormF2Part1Model GetFormF2ForPrint(MonthlyReturnModelNonCoal objModel)
        {
            try
            {
                LesseeFormF2Part1Model objlist = new LesseeFormF2Part1Model();

                objlist = JsonConvert.DeserializeObject<LesseeFormF2Part1Model>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetFormF2ForPrint", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Working_of_Mine> GetMineWorkDetails(MonthlyReturnModelNonCoal objModel)
        {
            try
            {
                List<Working_of_Mine> objlist = new List<Working_of_Mine>();

                objlist = JsonConvert.DeserializeObject<List<Working_of_Mine>>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetMineWorkDetails", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<RecoveriesModel> GetRecoveries_ConcentratorForPrint(MonthlyReturnModelNonCoal objModel)
        {
            try
            {
                List<RecoveriesModel> objlist = new List<RecoveriesModel>();

                objlist = JsonConvert.DeserializeObject<List<RecoveriesModel>>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/GetRecoveries_ConcentratorForPrint", JsonConvert.SerializeObject(objModel)));
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

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnNonCoalForm2/Update_Filepath", JsonConvert.SerializeObject(objModel)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
