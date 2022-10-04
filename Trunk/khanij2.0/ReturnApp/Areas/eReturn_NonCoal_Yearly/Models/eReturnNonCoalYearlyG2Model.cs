using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ReturnApp.Models.Utility;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApp.Areas.eReturn_NonCoal_Yearly.Models
{
    public class eReturnNonCoalYearlyG2Model : IeReturnNonCoalYearlyG2Model
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public eReturnNonCoalYearlyG2Model(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        #region Yearly Return Non Coal Details
        /// <summary>
        /// To Bind Yearly Return Non Coal Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public List<YearlyReturnModel> GetYearlyReturnDetails(YearlyReturnModel yearlyReturnModel)
        {
            try
            {
                List<YearlyReturnModel> lstYearlyReturnModel = new List<YearlyReturnModel>();
                lstYearlyReturnModel = JsonConvert.DeserializeObject<List<YearlyReturnModel>>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetYearlyReturnDetails",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lstYearlyReturnModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Part One H2
        #region Lessee Mine Details
        /// <summary>
        /// To Bind Lessee Mine Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public MineDetailsModel GetLesseMineDeatils(YearlyReturnModel yearlyReturnModel)
        {
            try
            {
                MineDetailsModel mineDetailsModel = new MineDetailsModel();
                mineDetailsModel = JsonConvert.DeserializeObject<MineDetailsModel>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetLesseMineDeatils",JsonConvert.SerializeObject(yearlyReturnModel)));
                return mineDetailsModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Agency Of Mine
        /// <summary>
        /// To Bind Agency Of Mine Details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<YearlyReturnModel> GetAgencyOfMine(int? UserId)
        {
            try
            {
                List<YearlyReturnModel> lstYearlyReturnModel = new List<YearlyReturnModel>();
                lstYearlyReturnModel = JsonConvert.DeserializeObject<List<YearlyReturnModel>>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetAgencyOfMine",JsonConvert.SerializeObject(UserId)));
                return lstYearlyReturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Other Mine Details
        #region Get Mine Other Details
        /// <summary>
        /// To Get Mine Other Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public AnnualReturnH1ViewModel GetMineOtherDetails(YearlyReturnModel yearlyReturnModel)
        {
            try
            {
                AnnualReturnH1ViewModel annualReturnH1ViewModel = new AnnualReturnH1ViewModel();
                annualReturnH1ViewModel = JsonConvert.DeserializeObject<AnnualReturnH1ViewModel>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetMineOtherDetails",JsonConvert.SerializeObject(yearlyReturnModel)));
                return annualReturnH1ViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Other Mine Details 
        /// <summary>
        /// To Update Mine Other Details
        /// </summary>
        /// <param name="annualReturnH1ViewModel"></param>
        /// <returns></returns>
        public MessageEF UpdateMineOtherDetails(AnnualReturnH1ViewModel annualReturnH1ViewModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateMineOtherDetails", JsonConvert.SerializeObject(annualReturnH1ViewModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Mine Other Details
        /// <summary>
        /// To Add Mine Other Details
        /// </summary>
        /// <param name="annualReturnH1ViewModel"></param>
        /// <returns></returns>
        public MessageEF AddMineOtherDetails(AnnualReturnH1ViewModel annualReturnH1ViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddMineOtherDetails", JsonConvert.SerializeObject(annualReturnH1ViewModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Particulars Of Area
        #region Get Particulars Of Area
        /// <summary>
        /// To Get Particulars Of Area
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public ParticularsofArea GetParticularsofArea(YearlyReturnModel yearlyReturnModel)
        {
            try
            {
                ParticularsofArea particularsofArea = new ParticularsofArea();
                particularsofArea = JsonConvert.DeserializeObject<ParticularsofArea>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetParticularsofArea",JsonConvert.SerializeObject(yearlyReturnModel)));
                return particularsofArea;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Particulars Of Area
        /// <summary>
        /// To Update Particulars Of Area
        /// </summary>
        /// <param name="particularsofArea"></param>
        /// <returns></returns>
        public MessageEF UpdateParticularsofArea(ParticularsofArea particularsofArea)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateParticularsofArea",JsonConvert.SerializeObject(particularsofArea)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Particulars Of Area
        /// <summary>
        /// To Add Particulars Of Area
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddParticularsofArea(ParticularsofArea objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddParticularsofArea",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Lease Area
        #region Get Lease Area
        /// <summary>
        /// To Get Lease Area
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public LeaseArea GetLeasearea(YearlyReturnModel yearlyReturnModel)
        {
            try
            {
                LeaseArea leaseArea = new LeaseArea();
                leaseArea = JsonConvert.DeserializeObject<LeaseArea>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetLeasearea",JsonConvert.SerializeObject(yearlyReturnModel)));
                return leaseArea;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Lease Area
        /// <summary>
        /// To Update Lease Area
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateLeasearea(LeaseArea objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateLeasearea",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Lease Area
        /// <summary>
        /// To Add Lease Area
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddLeasearea(LeaseArea objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddLeasearea",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #endregion

        #region Part Two H2
        #region Staff Details
        #region Get Staff Details
        /// <summary>
        /// To Get Staff and Work Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public StaffandWorkModel GetStaffandWork(YearlyReturnModel yearlyReturnModel)
        {
            StaffandWorkModel staffandWorkModel = new StaffandWorkModel();
            try
            {
                staffandWorkModel = JsonConvert.DeserializeObject<StaffandWorkModel>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetStaffandWork",JsonConvert.SerializeObject(yearlyReturnModel)));
                return staffandWorkModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Staff Details
        /// <summary>
        /// To Update Staff Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateStaffandWork(StaffandWorkModel objModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateStaffandWork",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region Add Staff Details
        /// <summary>
        /// To Add Staff Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddStaffandWork(StaffandWorkModel objModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddStaffandWork",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Work Details
        #region Get Work Details
        /// <summary>
        /// To Get Work Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public WorkModel GetWorkDetails(YearlyReturnModel yearlyReturnModel)
        {
            WorkModel workModel = new WorkModel();
            try
            {
                workModel = JsonConvert.DeserializeObject<WorkModel>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetWorkDetails",JsonConvert.SerializeObject(yearlyReturnModel)));
                return workModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Update Work Details
        /// <summary>
        /// To Update Work Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateWorkDetails(WorkModel objModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateWorkDetails",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Work Details
        /// <summary>
        /// To Add Work Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddWorkDetails(WorkModel objModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddWorkDetails",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Salary/Wages Paid
        #region Get Salary/Wages
        /// <summary>
        /// To Get Salary/Wages
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public SalaryWagesPaidModel GetSalaryWagesPaid(YearlyReturnModel yearlyReturnModel)
        {
            SalaryWagesPaidModel salaryWagesPaidModel = new SalaryWagesPaidModel();
            try
            {
                salaryWagesPaidModel = JsonConvert.DeserializeObject<SalaryWagesPaidModel>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetSalaryWagesPaid",JsonConvert.SerializeObject(yearlyReturnModel)));
                return salaryWagesPaidModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update SalaryWages
        /// <summary>
        /// To Update SalaryWages
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateSalaryWagesPaid(SalaryWagesPaidModel objModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateSalaryWagesPaid",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add SalaryWages
        /// <summary>
        /// To Add SalaryWages
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddSalaryWagesPaid(SalaryWagesPaidModel objModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddSalaryWagesPaid",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Part II-A(Capital Structure)
        #region Get Capital Structure
        /// <summary>
        /// To Get Capital Structure
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public CapitalStructure GetCapitalStructure(YearlyReturnModel yearlyReturnModel)
        {
            CapitalStructure capitalStructure = new CapitalStructure();
            try
            {
                capitalStructure = JsonConvert.DeserializeObject<CapitalStructure>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetCapitalStructure",JsonConvert.SerializeObject(yearlyReturnModel)));
                return capitalStructure;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Capital Structure
        /// <summary>
        /// To Update Capital Structure
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateCapitalStructure(CapitalStructure objModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateCapitalStructure",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Capital Structure
        /// <summary>
        /// To Add Capital Structure
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddCapitalStructure(CapitalStructure objModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddCapitalStructure",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Part-II A(Source Of Finance/Interest and Rent)
        #region Get Source Of Finance/Interest and Rent
        /// <summary>
        /// To Get Source Of Finance/Interest and Rent
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public SourceOfFinance GetSourceOfFinance(YearlyReturnModel yearlyReturnModel)
        {
            SourceOfFinance sourceOfFinance = new SourceOfFinance();
            try
            {
                sourceOfFinance = JsonConvert.DeserializeObject<SourceOfFinance>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetSourceOfFinance",JsonConvert.SerializeObject(yearlyReturnModel)));
                return sourceOfFinance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Source Of Finance/Interest and Rent
        /// <summary>
        /// To Update Source Of Finance/Interest and Rent
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateSourceOfFinance(SourceOfFinance objModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateSourceOfFinance",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Source Of Finance/Interest and Rent
        /// <summary>
        /// To Add Source Of Finance/Interest and Rent
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddSourceOfFinance(SourceOfFinance objModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddSourceOfFinance",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion


        #endregion

        #region Part Three H2
        #region Quantity and Cost of Material Consumed
        #region Get Material Consumed
        /// <summary>
        /// To Get Material Consumed
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public MaterialConsumed GetMaterialConsumed(YearlyReturnModel yearlyReturnModel)
        {
            MaterialConsumed materialConsumed = new MaterialConsumed();
            try
            {
                materialConsumed = JsonConvert.DeserializeObject<MaterialConsumed>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetMaterialConsumed",JsonConvert.SerializeObject(yearlyReturnModel)));
                return materialConsumed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Material Consumed
        /// <summary>
        /// To Update Material Consumed
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateMaterialConsumed(MaterialConsumed objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateMaterialConsumed",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Material Consumed
        /// <summary>
        /// To Add Material Consumed
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddMaterialConsumed(MaterialConsumed objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddMaterialConsumed",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Royalty,Rents and Payments
        #region Get Royalty and Rents
        /// <summary>
        /// To Get Royalty and Rent
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public RoyaltyandRents GetRoyaltyandRent(YearlyReturnModel yearlyReturnModel)
        {
            RoyaltyandRents royaltyandRents = new RoyaltyandRents();
            try
            {
                royaltyandRents = JsonConvert.DeserializeObject<RoyaltyandRents>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetRoyaltyandRent",JsonConvert.SerializeObject(yearlyReturnModel)));
                return royaltyandRents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Royalty and Rent
        /// <summary>
        /// To Update Royalty and Rent
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateRoyaltyandRent(RoyaltyandRents objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateRoyaltyandRent",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Royalty and Rent
        /// <summary>
        /// To Add Royalty and Rent
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddRoyaltyandRent(RoyaltyandRents objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddRoyaltyandRent",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion
        #endregion

        #region Part Four H2
        #region Update Consumption Of Explosives
        /// <summary>
        /// To Update Consumption Of Explosives
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateExplosives(AnnualReturnH1PartFourModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateExplosives",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Consumption Of Explosives
        /// <summary>
        /// To Add Consumption Of Explosives
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddExplosives(AnnualReturnH1PartFourModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddExplosives",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Consumption Of Explosives
        /// <summary>
        /// To Get Consumption Of Explosives
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public AnnualReturnH1PartFourModel GetExplosives(YearlyReturnModel yearlyReturnModel)
        {
            AnnualReturnH1PartFourModel annualReturnH1PartFourModel = new AnnualReturnH1PartFourModel();
            try
            {
                annualReturnH1PartFourModel = JsonConvert.DeserializeObject<AnnualReturnH1PartFourModel>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetExplosives",JsonConvert.SerializeObject(yearlyReturnModel)));
                return annualReturnH1PartFourModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Unit
        /// <summary>
        /// To Bind Unit
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public List<UnitType> GetUnitTypeList(YearlyReturnModel yearlyReturnModel)
        {
            List<UnitType> lstUnit = new List<UnitType>();
            try
            {
                lstUnit = JsonConvert.DeserializeObject<List<UnitType>>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetUnitTypeList",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lstUnit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Part Five H2
        #region Exploration
        #region Update Exploration
        /// <summary>
        /// To Update Exploration
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateExploration(Exploration objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateExploration",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Exploration
        /// <summary>
        /// To Add Exploration
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddExploration(Exploration objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddExploration",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Exploration
        /// <summary>
        /// To Get Exploration
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public Exploration GetExploration(YearlyReturnModel yearlyReturnModel)
        {
            Exploration exploration = new Exploration();
            try
            {
                exploration = JsonConvert.DeserializeObject<Exploration>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetExploration",JsonConvert.SerializeObject(yearlyReturnModel)));
                return exploration;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region Reserves and Resources estimated
        #region Update Reserves and Resources
        /// <summary>
        /// To Update Reserves and Resources
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateResources(ReservesAndResources objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateResources",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Reserves and Resources
        /// <summary>
        /// To Add Reserves and Resources
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddResources(ReservesAndResources objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddResources",JsonConvert.SerializeObject(objModel)));
                return messageEF;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Reserves and Resources
        /// <summary>
        /// To Get Reserves and Resources
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public ReservesAndResources GetResources(YearlyReturnModel yearlyReturnModel)
        {
            ReservesAndResources reservesAndResources = new ReservesAndResources();
            try
            {
                reservesAndResources = JsonConvert.DeserializeObject<ReservesAndResources>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetResources",JsonConvert.SerializeObject(yearlyReturnModel)));
                return reservesAndResources;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Reject,Waste,Trees Planted/survival
        #region Update Reject Waste
        /// <summary>
        /// To Update Reject Waste
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateRejectWaste(RejectWasteTreesPlanted objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateRejectWaste",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Reject Waste
        /// <summary>
        /// To Add Reject Waste
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddRejectWaste(RejectWasteTreesPlanted objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddRejectWaste",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Reject Waste
        /// <summary>
        /// To Get Reject Waste
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public RejectWasteTreesPlanted GetRejectWasteTreesPlanted(YearlyReturnModel yearlyReturnModel)
        {
            RejectWasteTreesPlanted rejectWasteTreesPlanted = new RejectWasteTreesPlanted();
            try
            {
                rejectWasteTreesPlanted = JsonConvert.DeserializeObject<RejectWasteTreesPlanted>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetRejectWasteTreesPlanted",JsonConvert.SerializeObject(yearlyReturnModel)));
                return rejectWasteTreesPlanted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Details Of Mineral Treatment Plant
        #region Update Details Of Mineral
        /// <summary>
        /// To Update Details Of Mineral
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateFurnishDetails(FurnishDetails objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateFurnishDetails",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Details Of Mineral
        /// <summary>
        /// To Add Details Of Mineral
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddFurnishDetails(FurnishDetails objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddFurnishDetails",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Details Of Mineral
        /// <summary>
        /// To Get Details Of Mineral
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public FurnishDetails GetFurnishDetails(YearlyReturnModel yearlyReturnModel)
        {
            FurnishDetails furnishDetails = new FurnishDetails();
            try
            {
                furnishDetails = JsonConvert.DeserializeObject<FurnishDetails>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetFurnishDetails",JsonConvert.SerializeObject(yearlyReturnModel)));
                return furnishDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Type Of Machinery
        #region Add Machinery
        /// <summary>
        /// To Add Machinery
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddMachineryDetails(MachineryDetails objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddMachineryDetails",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Machinery
        /// <summary>
        /// To Update Machinery
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateMachineryDetails(MachineryDetails objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateMachineryDetails",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete Machinery
        /// <summary>
        /// To Delete Machinery
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF DeleteMachineryDetails(MachineryDetails objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/DeleteMachineryDetails",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
                return messageEF;
            }
        }
        #endregion

        #region Machinery Details
        /// <summary>
        /// To Get Machinery Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public List<MachineryDetails> GetMachineryDetails(YearlyReturnModel yearlyReturnModel)
        {
            List<MachineryDetails> lstMachineryDetails = new List<MachineryDetails>();
            try
            {
                lstMachineryDetails = JsonConvert.DeserializeObject<List<MachineryDetails>>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetMachineryDetails",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lstMachineryDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Type Of Machinery
        /// <summary>
        /// To Get Type Of Machinery Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public List<TypeOfMachinery> GetTypeOfMachineryDetails(YearlyReturnModel yearlyReturnModel)
        {
            List<TypeOfMachinery> lstTypeOfMachinery = new List<TypeOfMachinery>();
            try
            {
                lstTypeOfMachinery = JsonConvert.DeserializeObject<List<TypeOfMachinery>>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetTypeOfMachineryDetails",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lstTypeOfMachinery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion
        #endregion

        #region Part Six H2
        #region Mineral Info
        /// <summary>
        /// To Get Mineral Info
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public MineralInfo GetMineralInfo(YearlyReturnModel yearlyReturnModel)
        {
            MineralInfo mineralInfo = new MineralInfo();
            try
            {
                mineralInfo = JsonConvert.DeserializeObject<MineralInfo>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetMineralInfo",JsonConvert.SerializeObject(yearlyReturnModel)));
                return mineralInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Production and Stocks
        #region Update Production and Stocks
        /// <summary>
        /// To Update Production and Stocks
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateProductionandStocks(ProductionandStocksModel objModel)
        {

            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateProductionandStocks",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Production and Stocks
        /// <summary>
        /// To Add Production and Stocks
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddProductionandStocks(ProductionandStocksModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddProductionandStocks",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Production and Stocks
        /// <summary>
        /// To Get Production and Stocks
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public ProductionandStocksModel GetProductionandStocks(YearlyReturnModel yearlyReturnModel)
        {
            ProductionandStocksModel productionandStocksModel = new ProductionandStocksModel();
            try
            {
                productionandStocksModel = JsonConvert.DeserializeObject<ProductionandStocksModel>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetProductionandStocks",JsonConvert.SerializeObject(yearlyReturnModel)));
                return productionandStocksModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Details of Deduction
        #region Update Details of Deduction
        /// <summary>
        /// To Update Details of Deduction
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateDetails_of_deductions(Details_of_deductions objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateDetails_of_deductions",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Details of Deduction
        /// <summary>
        /// To Add Details of Deduction
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddDetails_of_deductions(Details_of_deductions objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddDetails_of_deductions",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Details of Deduction
        /// <summary>
        /// To Get Details of Deduction
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public Details_of_deductions GetDetails_of_deductions(YearlyReturnModel yearlyReturnModel)
        {
            Details_of_deductions details_Of_Deductions = new Details_of_deductions();
            try
            {
                details_Of_Deductions = JsonConvert.DeserializeObject<Details_of_deductions>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetDetails_of_deductions",JsonConvert.SerializeObject(yearlyReturnModel)));
                return details_Of_Deductions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Reason for Increase/Decrease
        #region Update Reason for Increase/Decrease
        /// <summary>
        /// To Update Reason for Increase/Decrease
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateReasonForInDc(Reason_Inc_Dec objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateReasonForInDc",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Reason for Increase/Decrease
        /// <summary>
        /// To Add Reason for Increase/Decrease
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddReasonForInDc(Reason_Inc_Dec objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddReasonForInDc",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Reason for Increase/Decrease
        /// <summary>
        /// To Get Reason for Increase/Decrease
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public Reason_Inc_Dec GetReason_Inc_Dec(YearlyReturnModel yearlyReturnModel)
        {
            Reason_Inc_Dec reason_Inc_Dec = new Reason_Inc_Dec();
            try
            {
                reason_Inc_Dec = JsonConvert.DeserializeObject<Reason_Inc_Dec>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetReason_Inc_Dec",JsonConvert.SerializeObject(yearlyReturnModel)));
                return reason_Inc_Dec;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Recoveries at Concentrator Mill/Plant
        #region Add Recoveries
        /// <summary>
        /// To Add Recoveries
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddRecoveries(RecoveriesModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddRecoveries",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Recoveries
        /// <summary>
        /// To Update Recoveries
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateRecoveries(RecoveriesModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateRecoveries",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
            }
            return messageEF;
        }
        #endregion

        #region Delete Recoveries
        /// <summary>
        /// To Delete Recoveries
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF DeleteRecoveries(RecoveriesModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/DeleteRecoveries",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                messageEF.Satus = "3";
            }
            return messageEF;
        }
        #endregion

        #region Get Recoveries
        /// <summary>
        /// To Get Recoveries
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public List<RecoveriesModel> GetRecoveries(YearlyReturnModel yearlyReturnModel)
        {
            List<RecoveriesModel> lstRecoveriesModel = new List<RecoveriesModel>();
            try
            {
                lstRecoveriesModel = JsonConvert.DeserializeObject<List<RecoveriesModel>>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetRecoveries",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lstRecoveriesModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #endregion

        #region Recovery at the Smelter/Mill/Plant
        #region Add Recovery at the Smelter
        /// <summary>
        /// To Add Recovery at the Smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddRecoveriesSmelter",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Update Recovery at the Smelter
        /// <summary>
        /// To Update Recovery at the Smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateRecoveriesSmelter",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Delete Recovery at the Smelter
        /// <summary>
        /// To Delete Recovery at the Smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF DeleteRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/DeleteRecoveriesSmelter",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Get Recovery at the Smelter
        /// <summary>
        /// To Delete Recovery at the Smelter
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public List<Recovery_atSmelterModel> GetRecoveriesSmelter(YearlyReturnModel yearlyReturnModel)
        {
            List<Recovery_atSmelterModel> lstRecovery_atSmelterModel = new List<Recovery_atSmelterModel>();
            try
            {
                lstRecovery_atSmelterModel = JsonConvert.DeserializeObject<List<Recovery_atSmelterModel>>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetRecoveriesSmelter",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lstRecovery_atSmelterModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
             
        }
        #endregion
        #endregion

        #region Sales During the month
        #region Add Sales During the month
        /// <summary>
        /// To Add Sales During the month
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddSaleProduct(SaleProductModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddSaleProduct",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Sales During the month
        /// <summary>
        /// To Update Sales During the month
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateSaleProduct(SaleProductModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateSaleProduct",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        #endregion

        #region Delete Sales During the month
        /// <summary>
        /// To Delete Sales During the month
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF DeleteSaleProduct(SaleProductModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/DeleteSaleProduct",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        #endregion

        #region Get Sales During the month
        /// <summary>
        /// To Get Sales During the month
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public List<SaleProductModel> GetSaleProduct(YearlyReturnModel yearlyReturnModel)
        {
            List<SaleProductModel> lstSaleProductModel = new List<SaleProductModel>();
            try
            {
                lstSaleProductModel = JsonConvert.DeserializeObject<List<SaleProductModel>>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetSaleProduct",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lstSaleProductModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion

        #region Get Mineral Grade
        /// <summary>
        /// To Get Mineral Grade
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public List<MineralGrade> GetMineralGradeForTinMineral(YearlyReturnModel yearlyReturnModel)
        {
            List<MineralGrade> lstMineralGrade = new List<MineralGrade>();
            try
            {
                lstMineralGrade = JsonConvert.DeserializeObject<List<MineralGrade>>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetMineralGradeForTinMineral",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lstMineralGrade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Closing Stock
        /// <summary>
        /// To Get Closing Stock
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns> 
        public OpeningStockandDispatch Get_G2_ClosingStock(YearlyReturnModel yearlyReturnModel)
        {
            OpeningStockandDispatch openingStockandDispatch = new OpeningStockandDispatch();
            try
            {
                openingStockandDispatch = JsonConvert.DeserializeObject<OpeningStockandDispatch>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/Get_G2_ClosingStock",JsonConvert.SerializeObject(yearlyReturnModel)));
                return openingStockandDispatch;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Dispatch
        /// <summary>
        /// To Get Dispatch
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public OpeningStockandDispatch GetDispatch_Form2_Annual(YearlyReturnModel yearlyReturnModel)
        {
            OpeningStockandDispatch openingStockandDispatch = new OpeningStockandDispatch();
            try
            {
                openingStockandDispatch = JsonConvert.DeserializeObject<OpeningStockandDispatch>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetDispatch_Form2_Annual",JsonConvert.SerializeObject(yearlyReturnModel)));
                return openingStockandDispatch;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Sales/Dispatches
        #region Add Sales/Dispatches
        /// <summary>
        /// To Add Sales/Dispatches
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddSaleDispatch",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update Sales/Dispatches
        /// <summary>
        /// To Update Sales/Dispatches
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateSaleDispatch",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        #endregion

        #region Delete Sales/Dispatches
        /// <summary>
        /// To Delete Sales/Dispatches
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF DeleteSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/DeleteSaleDispatch",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        #endregion

        #region Get Sales/Dispatches
        /// <summary>
        /// To Get Sales/Dispatches
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public List<SalesDispatchOf_OreModel> GetSaleDispatch(YearlyReturnModel yearlyReturnModel)
        {
            List<SalesDispatchOf_OreModel> lstSalesDispatchOf_OreModel = new List<SalesDispatchOf_OreModel>();
            try
            {
                lstSalesDispatchOf_OreModel = JsonConvert.DeserializeObject<List<SalesDispatchOf_OreModel>>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetSaleDispatch",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lstSalesDispatchOf_OreModel;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        #endregion

        #region Get Mineral Form
        /// <summary>
        /// To Get Mineral Form
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public List<MineralInfo> GetMineralForm(YearlyReturnModel yearlyReturnModel)
        {
            List<MineralInfo> lstMineralInfo = new List<MineralInfo>();
            try
            {
                lstMineralInfo = JsonConvert.DeserializeObject<List<MineralInfo>>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetMineralForm",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lstMineralInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion

        #region Get Mineral Grade
        /// <summary>
        /// To Get Mineral Grade
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public List<MineralGrade> GetMineralGrade(YearlyReturnModel yearlyReturnModel)
        {
            List<MineralGrade> lstMineralGrade = new List<MineralGrade>();
            try
            {
                lstMineralGrade = JsonConvert.DeserializeObject<List<MineralGrade>>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetMineralGrade",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lstMineralGrade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstMineralGrade = null;
            }
        }
        #endregion

        #region Nature Of Dispatch
        /// <summary>
        /// To GetNature Of Dispatch
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public List<MineralInfo> GetNatureOfDispatch(YearlyReturnModel yearlyReturnModel)
        {
            List<MineralInfo> lstMineralInfo = new List<MineralInfo>();
            try
            {
                lstMineralInfo = JsonConvert.DeserializeObject<List<MineralInfo>>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetNatureOfDispatch",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lstMineralInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion

        #region Purchaser Consignee
        /// <summary>
        /// To Get Purchaser Consignee
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public List<MineralInfo> GetPurchaserConsignee(YearlyReturnModel yearlyReturnModel)
        {
            List<MineralInfo> lstMineralInfo = new List<MineralInfo>();
            try
            {
                lstMineralInfo = JsonConvert.DeserializeObject<List<MineralInfo>>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetPurchaserConsignee",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lstMineralInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstMineralInfo = null;
            }
        }
        #endregion
        #endregion
        #endregion

        #region Part Seven H2
        #region Update CostOfProduction
        /// <summary>
        /// To Update Cost Of Production
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateCostOfProduction(CostOfProduction_Annual objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/UpdateCostOfProduction",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Add Cost Of Production
        /// <summary>
        /// To Add Cost Of Production
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF AddCostOfProduction(CostOfProduction_Annual objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/AddCostOfProduction",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Final Submit Cost Of Production
        /// <summary>
        /// To Final Submit Cost Of Production
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF Update_FinalSubmit(CostOfProduction_Annual objModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/Update_FinalSubmit",JsonConvert.SerializeObject(objModel)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Cost Of Production
        /// <summary>
        /// To Get Cost Of Production
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public CostOfProduction_Annual GetCostOfProduction(YearlyReturnModel yearlyReturnModel)
        {
            CostOfProduction_Annual costOfProduction_Annual = new CostOfProduction_Annual();
            try
            {
                costOfProduction_Annual = JsonConvert.DeserializeObject<CostOfProduction_Annual>(_objIHttpWebClients.PostRequest("eReturnYearlyNonCoalG2/GetCostOfProduction",JsonConvert.SerializeObject(yearlyReturnModel)));
                return costOfProduction_Annual;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion
    }
}
