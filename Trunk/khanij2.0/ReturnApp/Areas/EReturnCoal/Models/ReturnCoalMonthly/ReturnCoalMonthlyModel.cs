// ***********************************************************************
// Assembly         : Khanij
// Author           : Akshaya Dalei
// Created          : 22-June-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Options;
using Newtonsoft.Json; 
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ReturnApp.Models.Utility;

namespace ReturnApp.Areas.EReturnCoal.Models.ReturnCoalMonthly
{
    public class ReturnCoalMonthlyModel : IReturnCoalMonthlyModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public ReturnCoalMonthlyModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        #region Monthly Coal Return
        /// <summary>
        /// Monthly Coal Return Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>

        public List<MonthlyReturnModel> eReturnMonthlyDetails(MonthlyReturnModel monthlyReturnModel)
        {
            try
            {
                List<MonthlyReturnModel> lstMonthlyReturnModel = new List<MonthlyReturnModel>();
                lstMonthlyReturnModel = JsonConvert.DeserializeObject<List<MonthlyReturnModel>>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/MonthlyReturnDetails",JsonConvert.SerializeObject(monthlyReturnModel)));
                return lstMonthlyReturnModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #region Mine Details
        /// <summary>
        /// Mine Details Lessee
        /// </summary>
        /// <param name="coalMonthlyMineDetailsModel"></param>
        /// <returns></returns>

        public CoalMonthlyMineDetailsModel GetLesseMineDeatils(CoalMonthlyMineDetailsModel coalMonthlyMineDetailsModel)
        {
            try
            {

                coalMonthlyMineDetailsModel = JsonConvert.DeserializeObject<CoalMonthlyMineDetailsModel>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/LesseMonthlyCoalMineDeatils", JsonConvert.SerializeObject(coalMonthlyMineDetailsModel)));
                return coalMonthlyMineDetailsModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Mine Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>

        public CoalMonthlyMineDetailsModel Get_CoalMonthlyMineDetails(MonthlyReturnModel monthlyReturnModel)
        {
            try
            {
                CoalMonthlyMineDetailsModel coalMonthlyMineDetailsModel1 = new CoalMonthlyMineDetailsModel();
                coalMonthlyMineDetailsModel1 = JsonConvert.DeserializeObject<CoalMonthlyMineDetailsModel>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/CoalMonthlyMineDetails",JsonConvert.SerializeObject(monthlyReturnModel)));
                return coalMonthlyMineDetailsModel1;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Update Mine Details
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>

        public MessageEF Update_MineDetails(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/Update_MineDetails",JsonConvert.SerializeObject(coalMonthlyViewModel)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Add Mine Details
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>

        public MessageEF ADD_MineDetails(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/ADD_MineDetails",JsonConvert.SerializeObject(coalMonthlyViewModel)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Table A
        /// <summary>
        /// Add Table A
        /// </summary>
        /// <param name="tABLE_A_Model"></param>
        /// <returns></returns>

        public MessageEF AddCoal_TableAMonthly(TABLE_A_Model tABLE_A_Model)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/ADDCoalMonthly_eReturn",JsonConvert.SerializeObject(tABLE_A_Model)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Update Table A
        /// </summary>
        /// <param name="tABLE_A_Model"></param>
        /// <returns></returns>

        public MessageEF UpdateCoal_TableAMonthly(TABLE_A_Model tABLE_A_Model)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/UpdateCoalMonthly_eReturn",JsonConvert.SerializeObject(tABLE_A_Model)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Table A Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>

        public List<TABLE_A_Model> Coal_TableAMonthlyDetails(MonthlyReturnModel monthlyReturnModel)
        {
            try
            {
                List<TABLE_A_Model> lstTABLE_A_Model = new List<TABLE_A_Model>();
                lstTABLE_A_Model = JsonConvert.DeserializeObject<List<TABLE_A_Model>>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/GetCoal_TableAMonthlyDetails",JsonConvert.SerializeObject(monthlyReturnModel)));
                return lstTABLE_A_Model;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Opening Stock
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>

        public TABLE_A_Model Coal_TableAOpeningStock(MonthlyReturnModel monthlyReturnModel)
        {
            TABLE_A_Model tABLE_A_Model = new TABLE_A_Model();
            try
            {

                tABLE_A_Model = JsonConvert.DeserializeObject<TABLE_A_Model>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/GetCoal_OpeningStock",JsonConvert.SerializeObject(monthlyReturnModel)));
                return tABLE_A_Model;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Despatch Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>

        public List<TABLE_A_Model> GetCoal_TableADispatchDetails(MonthlyReturnModel monthlyReturnModel)
        {
            try
            {
                List<TABLE_A_Model> lstTABLE_A_Model = new List<TABLE_A_Model>();
                lstTABLE_A_Model = JsonConvert.DeserializeObject<List<TABLE_A_Model>>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/GetCoal_TableADispatchDetails",JsonConvert.SerializeObject(monthlyReturnModel)));
                return lstTABLE_A_Model;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete Table A
        /// </summary>
        /// <param name="tABLE_A_Model"></param>
        /// <returns></returns>

        public MessageEF DeleteCoal_TableAMonthly(TABLE_A_Model tABLE_A_Model)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/DeleteCoal_TableAMonthly",JsonConvert.SerializeObject(tABLE_A_Model)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Table B
        /// <summary>
        /// Add Table B
        /// </summary>
        /// <param name="tABLE_B_Model"></param>
        /// <returns></returns>
        
        public MessageEF AddMACHINERY_TableBMonthly(TABLE_B_Model tABLE_B_Model)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/ADDMACHINERYMonthly_eReturn",JsonConvert.SerializeObject(tABLE_B_Model)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Update Table B
        /// </summary>
        /// <param name="tABLE_B_Model"></param>
        /// <returns></returns>

        public MessageEF UpdateMACHINERY_TableBMonthly(TABLE_B_Model tABLE_B_Model)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/UpdateMACHINERYMonthly_eReturn",JsonConvert.SerializeObject(tABLE_B_Model)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete Table B
        /// </summary>
        /// <param name="tABLE_B_Model"></param>
        /// <returns></returns>

        public MessageEF DeleteMACHINERY_TableBMonthly(TABLE_B_Model tABLE_B_Model)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/DeleteMACHINERYMonthly_eReturn",JsonConvert.SerializeObject(tABLE_B_Model)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Table B Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        public List<TABLE_B_Model> GetMACHINERY_TableBMonthly(MonthlyReturnModel monthlyReturnModel)
        {
            try
            {
                List<TABLE_B_Model> lstTABLE_B_Model = new List<TABLE_B_Model>();
                lstTABLE_B_Model = JsonConvert.DeserializeObject<List<TABLE_B_Model>>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/GetMACHINERYMonthly_eReturn",JsonConvert.SerializeObject(monthlyReturnModel)));
                return lstTABLE_B_Model;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Table B Working Background Type
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        public List<TABLE_B_Model> GetWorkingBackGroungType(MonthlyReturnModel monthlyReturnModel)
        {
            try
            {
                List<TABLE_B_Model> lstTABLE_B_Model = new List<TABLE_B_Model>();
                lstTABLE_B_Model = JsonConvert.DeserializeObject<List<TABLE_B_Model>>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/WorkingBackgroundType",JsonConvert.SerializeObject(monthlyReturnModel)));
                return lstTABLE_B_Model;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Table C Men & Work
        /// <summary>
        /// Get Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        public CoalMonthlyModel Get_NumberOF_Work_TableCMonthly(MonthlyReturnModel monthlyReturnModel)
        {
            CoalMonthlyModel coalMonthlyModel = new CoalMonthlyModel();
            try
            {

                coalMonthlyModel = JsonConvert.DeserializeObject<CoalMonthlyModel>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/GetTableCDetails",JsonConvert.SerializeObject(monthlyReturnModel)));
                return coalMonthlyModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Update Table C
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        public MessageEF Update_NumberOF_Work_TableCMonthly(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/Update_NumberOF_Work_TableCMonthly",JsonConvert.SerializeObject(coalMonthlyViewModel)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Add Table C
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        public MessageEF ADD_NumberOF_Work_TableCMonthly(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/ADD_NumberOF_Work_TableCMonthly",JsonConvert.SerializeObject(coalMonthlyViewModel)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Table D
        /// <summary>
        /// Table D Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        public Table_D_Model Get_EarnDetails_TableDMonthly(MonthlyReturnModel monthlyReturnModel)
        {
            Table_D_Model table_D_Model = new Table_D_Model();
            try
            {

                table_D_Model = JsonConvert.DeserializeObject<Table_D_Model>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/GetEarnDetailsTableDMonthly",JsonConvert.SerializeObject(monthlyReturnModel)));
                return table_D_Model;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Update Table D
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        public MessageEF Update_Table_D(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/Update_Table_D",JsonConvert.SerializeObject(coalMonthlyViewModel)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Add Table D
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        public MessageEF ADD_Table_D(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/ADD_Table_D",JsonConvert.SerializeObject(coalMonthlyViewModel)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Final Submit
        /// <summary>
        /// Final Submit
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        public MessageEF Update_FinalSubmit(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/Update_FinalSubmit",JsonConvert.SerializeObject(coalMonthlyViewModel)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Previous Month Closing Stock
        /// <summary>
        /// Previous Month Closing Stock
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        public string PreviousMonthClosingStock(MonthlyReturnModel monthlyReturnModel)
        {
            
            try
            {

                return _objIHttpWebClients.PostRequest("eReturnMonthlyCoal/PreviousMonthClosingStock",JsonConvert.SerializeObject(monthlyReturnModel));
                  

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        #region Mineral Form & Grade
        /// <summary>
        /// Get Mineral Form
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        public List<MonthlyReturnModel> GetMineralNature(MonthlyReturnModel monthlyReturnModel)
        {
            List<MonthlyReturnModel> lstmonthlyReturnModels = new List<MonthlyReturnModel>();
            try
            {

                lstmonthlyReturnModels = JsonConvert.DeserializeObject<List<MonthlyReturnModel>>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/MineralNatureDetails",JsonConvert.SerializeObject(monthlyReturnModel)));
                return lstmonthlyReturnModels;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Mineral Grade
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        public List<MonthlyReturnModel> GetMineralGrade(MonthlyReturnModel monthlyReturnModel)
        {
            List<MonthlyReturnModel> lstmonthlyReturnModels = new List<MonthlyReturnModel>();
            try
            {

                lstmonthlyReturnModels = JsonConvert.DeserializeObject<List<MonthlyReturnModel>>(_objIHttpWebClients.PostRequest("eReturnMonthlyCoal/MineralGradeDetails",JsonConvert.SerializeObject(monthlyReturnModel)));
                return lstmonthlyReturnModels;

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
