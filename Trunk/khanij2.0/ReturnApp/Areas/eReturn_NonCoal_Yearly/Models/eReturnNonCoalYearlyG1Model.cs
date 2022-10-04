using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReturnEF;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using ReturnApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace ReturnApp.Areas.eReturn_NonCoal_Yearly.Models
{
    public class eReturnNonCoalYearlyG1Model: IeReturnNonCoalYearlyG1Model
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public eReturnNonCoalYearlyG1Model(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        public List<YearlyReturnModel> GetYearlyReturnDetails(MonthlyReturnModelNonCoal model)
        {
            try
            {
                List<YearlyReturnModel> objlist = new List<YearlyReturnModel>();

                objlist = JsonConvert.DeserializeObject<List<YearlyReturnModel>>(_objIHttpWebClients.PostRequest("AnnualReturnG1/GetYearlyReturnDetails", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public AnnualReturnH1ViewModel GetMineOtherDetails(MonthlyReturnModelNonCoal model)
        {
            try
            {
                AnnualReturnH1ViewModel objlist = new AnnualReturnH1ViewModel();

                objlist = JsonConvert.DeserializeObject<AnnualReturnH1ViewModel>(_objIHttpWebClients.PostRequest("AnnualReturnG1/GetMineOtherDetails", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ParticularsofArea GetParticularsofArea(MonthlyReturnModelNonCoal model)
        {
            try
            {
                ParticularsofArea objlist = new ParticularsofArea();

                objlist = JsonConvert.DeserializeObject<ParticularsofArea>(_objIHttpWebClients.PostRequest("AnnualReturnG1/GetParticularsofArea", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public LeaseArea GetLeasearea(MonthlyReturnModelNonCoal model)
        {
            try
            {
                LeaseArea objlist = new LeaseArea();

                objlist = JsonConvert.DeserializeObject<LeaseArea>(_objIHttpWebClients.PostRequest("AnnualReturnG1/GetLeasearea", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MineDetailsModel GetLesseMineDeatils(MonthlyReturnModelNonCoal model)
        {
            try
            {
                MineDetailsModel objlist = new MineDetailsModel();

                objlist = JsonConvert.DeserializeObject<MineDetailsModel>(_objIHttpWebClients.PostRequest("AnnualReturnG1/GetLesseMineDeatils", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<GetDDL> GetAgencyOfMine(MonthlyReturnModelNonCoal model)
        {
            try
            {
                List<GetDDL> objlist = new List<GetDDL>();

                objlist = JsonConvert.DeserializeObject<List<GetDDL>>(_objIHttpWebClients.PostRequest("AnnualReturnG1/GetAgencyOfMine", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddMineOtherDetails(AnnualReturnH1ViewModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/AddMineOtherDetails", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddParticularsofArea(AnnualReturnH1ViewModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/AddParticularsofArea", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddLeasearea(AnnualReturnH1ViewModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/AddLeasearea", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF UpdateMineOtherDetails(AnnualReturnH1ViewModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/UpdateMineOtherDetails", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF UpdateParticularsofArea(AnnualReturnH1ViewModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/UpdateParticularsofArea", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF UpdateLeasearea(AnnualReturnH1ViewModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/UpdateLeasearea", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public StaffandWorkModel GetStaffandWork(MonthlyReturnModelNonCoal model)
        {
            try
            {
                StaffandWorkModel objlist = new StaffandWorkModel();

                objlist = JsonConvert.DeserializeObject<StaffandWorkModel>(_objIHttpWebClients.PostRequest("AnnualReturnG1/GetStaffandWork", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public SalaryWagesPaidModel GetSalaryWagesPaid(MonthlyReturnModelNonCoal model)
        {
            try
            {
                SalaryWagesPaidModel objlist = new SalaryWagesPaidModel();

                objlist = JsonConvert.DeserializeObject<SalaryWagesPaidModel>(_objIHttpWebClients.PostRequest("AnnualReturnG1/GetSalaryWagesPaid", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public CapitalStructure GetCapitalStructure(MonthlyReturnModelNonCoal model)
        {
            try
            {
                CapitalStructure objlist = new CapitalStructure();

                objlist = JsonConvert.DeserializeObject<CapitalStructure>(_objIHttpWebClients.PostRequest("AnnualReturnG1/GetCapitalStructure", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public SourceOfFinance GetSourceOfFinance(MonthlyReturnModelNonCoal model)
        {
            try
            {
                SourceOfFinance objlist = new SourceOfFinance();

                objlist = JsonConvert.DeserializeObject<SourceOfFinance>(_objIHttpWebClients.PostRequest("AnnualReturnG1/GetSourceOfFinance", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public WorkModel GetWorkDetails(MonthlyReturnModelNonCoal model)
        {
            try
            {
                WorkModel objlist = new WorkModel();

                objlist = JsonConvert.DeserializeObject<WorkModel>(_objIHttpWebClients.PostRequest("AnnualReturnG1/GetWorkDetails", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddStaffandWork(AnnualReturnH1PartTwoModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/AddStaffandWork", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddWorkDetails(AnnualReturnH1PartTwoModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/AddWorkDetails", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddSalaryWagesPaid(AnnualReturnH1PartTwoModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/AddSalaryWagesPaid", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddCapitalStructure(AnnualReturnH1PartTwoModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/AddCapitalStructure", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddSourceOfFinance(AnnualReturnH1PartTwoModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/AddSourceOfFinance", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF UpdateStaffandWork(AnnualReturnH1PartTwoModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/UpdateStaffandWork", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF UpdateWorkDetails(AnnualReturnH1PartTwoModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/UpdateWorkDetails", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF UpdateSalaryWagesPaid(AnnualReturnH1PartTwoModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/UpdateSalaryWagesPaid", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF UpdateCapitalStructure(AnnualReturnH1PartTwoModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/UpdateCapitalStructure", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF UpdateSourceOfFinance(AnnualReturnH1PartTwoModel model)
        {
            try
            {
                MessageEF objlist = new MessageEF();

                objlist = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AnnualReturnG1/UpdateSourceOfFinance", JsonConvert.SerializeObject(model)));
                return objlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
