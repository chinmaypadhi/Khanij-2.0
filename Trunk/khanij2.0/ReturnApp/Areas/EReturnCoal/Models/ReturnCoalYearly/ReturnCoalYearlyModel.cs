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
using ReturnApp.Models.Utility;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApp.Areas.EReturnCoal.Models.ReturnCoalYearly
{
    public class ReturnCoalYearlyModel : IReturnCoalYearlyModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public ReturnCoalYearlyModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        #region Yearly Coal Return Details
        /// <summary>
        /// Yearly Coal Return Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public List<YearlyReturnModel> GetYearlyReturnDetails(YearlyReturnModel yearlyReturnModel)
        {
            try
            {
                List<YearlyReturnModel> lstYearlyReturnModel = new List<YearlyReturnModel>();
                lstYearlyReturnModel = JsonConvert.DeserializeObject<List<YearlyReturnModel>>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/YearlyReturnCoalDetails",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lstYearlyReturnModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Mine Details
        /// <summary>
        /// Mine Lessee Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public CoalYearlyMineDetailsModel GetLesseMineDeatils(YearlyReturnModel yearlyReturnModel)
        {
            try
            {
                CoalYearlyMineDetailsModel coalYearlyMineDetailsModel = new CoalYearlyMineDetailsModel();
                coalYearlyMineDetailsModel = JsonConvert.DeserializeObject<CoalYearlyMineDetailsModel>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/LesseMineDeatils",JsonConvert.SerializeObject(yearlyReturnModel)));
                return coalYearlyMineDetailsModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Mine Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public CoalYearlyMineDetailsModel Get_CoalYearlyMineDetails(YearlyReturnModel yearlyReturnModel)
        {
            try
            {
                CoalYearlyMineDetailsModel coalYearlyMineDetailsModel = new CoalYearlyMineDetailsModel();
                coalYearlyMineDetailsModel = JsonConvert.DeserializeObject<CoalYearlyMineDetailsModel>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/CoalYearlyMineDetails",JsonConvert.SerializeObject(yearlyReturnModel)));
                return coalYearlyMineDetailsModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Add Mine Details
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public MessageEF ADD_MineDetails(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/ADDMineDetails",JsonConvert.SerializeObject(coalYearlyViewModel)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Update Mine Details
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public MessageEF Update_MineDetails(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/UpdateMineDetails",JsonConvert.SerializeObject(coalYearlyViewModel)));
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
        /// Get Employment
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public EMPLOYMENT Get_EMPLOYMENT(YearlyReturnModel yearlyReturnModel)
        {
            EMPLOYMENT eMPLOYMENT = new EMPLOYMENT();
            try
            {
                eMPLOYMENT = JsonConvert.DeserializeObject<EMPLOYMENT>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/GetEMPLOYMENT",JsonConvert.SerializeObject(yearlyReturnModel)));
                return eMPLOYMENT;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                eMPLOYMENT = null;
            }
        }

        /// <summary>
        /// Add Employment
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public MessageEF ADD_EMPLOYMENT(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/ADDEMPLOYMENT",JsonConvert.SerializeObject(coalYearlyViewModel)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
                coalYearlyViewModel = null;
            }
        }

        /// <summary>
        /// Update Employment
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public MessageEF Update_EMPLOYMENT(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/UpdateEMPLOYMENT",JsonConvert.SerializeObject(coalYearlyViewModel)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                coalYearlyViewModel = null;
            }
        }

        #endregion

        #region Table B
        /// <summary>
        /// To Get ELECTRICAL APPARTATUS Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public ELECTRICAL_APPARTATUS Get_ELECTRICAL_APPARTATUS(YearlyReturnModel yearlyReturnModel)
        {
            ELECTRICAL_APPARTATUS eLECTRICAL_APPARTATUS = new ELECTRICAL_APPARTATUS();
            try
            {
                eLECTRICAL_APPARTATUS = JsonConvert.DeserializeObject<ELECTRICAL_APPARTATUS>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/GetELECTRICAL_APPARTATUS",JsonConvert.SerializeObject(yearlyReturnModel)));
                return eLECTRICAL_APPARTATUS;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                eLECTRICAL_APPARTATUS = null;
                yearlyReturnModel = null;
            }
        }

        /// <summary>
        /// To Add ELECTRICAL APPARTATUS Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public MessageEF ADD_ELECTRICAL_APPARTATUS(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/ADDELECTRICAL_APPARTATUS",JsonConvert.SerializeObject(coalYearlyViewModel)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
                coalYearlyViewModel = null;
            }
        }

        /// <summary>
        /// To Update ELECTRICAL APPARTATUS Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public MessageEF Update_ELECTRICAL_APPARTATUS(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/UpdateELECTRICAL_APPARTATUS",JsonConvert.SerializeObject(coalYearlyViewModel)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {  
                coalYearlyViewModel = null;
            }
        }

        #endregion

        #region Table C
        /// <summary>
        /// To Get MACHINERY EQUIPMENT Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public MACHINERY_EQUIPMENT Get_MACHINERY_EQUIPMENT(YearlyReturnModel yearlyReturnModel)
        {
            MACHINERY_EQUIPMENT mACHINERY_EQUIPMENT = new MACHINERY_EQUIPMENT();
            try
            {
                mACHINERY_EQUIPMENT = JsonConvert.DeserializeObject<MACHINERY_EQUIPMENT>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/GetMACHINERY_EQUIPMENT",JsonConvert.SerializeObject(yearlyReturnModel)));
                return mACHINERY_EQUIPMENT;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                mACHINERY_EQUIPMENT = null;
                yearlyReturnModel = null;
            }
        }

        /// <summary>
        /// To ADD MACHINERY EQUIPMENT Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public MessageEF ADD_MACHINERY_EQUIPMENT(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            { 
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/ADDMACHINERY_EQUIPMENT",JsonConvert.SerializeObject(coalYearlyViewModel)));
                return messageEF; 
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
                coalYearlyViewModel = null;
            }
        }

        /// <summary>
        /// To UPDATE MACHINERY EQUIPMENT Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public MessageEF Update_MACHINERY_EQUIPMENT(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/UpdateMACHINERY_EQUIPMENT",JsonConvert.SerializeObject(coalYearlyViewModel)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                coalYearlyViewModel = null;
            }
        }

        #endregion

        #region Table D
        /// <summary>
        /// To Get MECHANICAL VENTILATORS Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public MECHANICAL_VENTILATORS Get_MECHANICAL_VENTILATORS(YearlyReturnModel yearlyReturnModel)
        {
            MECHANICAL_VENTILATORS mECHANICAL_VENTILATORS = new MECHANICAL_VENTILATORS();
           try
            {
                mECHANICAL_VENTILATORS = JsonConvert.DeserializeObject<MECHANICAL_VENTILATORS>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/GetMECHANICAL_VENTILATORS",JsonConvert.SerializeObject(yearlyReturnModel)));
                return mECHANICAL_VENTILATORS;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Add MECHANICAL VENTILATORS Details Data 
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public MessageEF ADD_MECHANICAL_VENTILATORS(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/ADDMECHANICAL_VENTILATORS",JsonConvert.SerializeObject(coalYearlyViewModel)));
                return messageEF;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Update MECHANICAL VENTILATORS Details Data 
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public MessageEF Update_MECHANICAL_VENTILATORS(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/UpdateMECHANICAL_VENTILATORS",JsonConvert.SerializeObject(coalYearlyViewModel)));
                return messageEF;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Table E(a)
        /// <summary>
        /// To Get E EXPLOSIVES Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public List<E_EXPLOSIVES> GetE_EXPLOSIVES(YearlyReturnModel yearlyReturnModel)
        {
            List<E_EXPLOSIVES> lste_EXPLOSIVEs = new List<E_EXPLOSIVES>();
            try
            {
                lste_EXPLOSIVEs = JsonConvert.DeserializeObject<List<E_EXPLOSIVES>>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/GetEEXPLOSIVES",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lste_EXPLOSIVEs;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Add E EXPLOSIVES Details Data 
        /// </summary>
        /// <param name="e_EXPLOSIVES"></param>
        /// <returns></returns>
        public MessageEF AddE_EXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/AddEEXPLOSIVES",JsonConvert.SerializeObject(e_EXPLOSIVES)));
                return messageEF;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Update E EXPLOSIVES Details Data 
        /// </summary>
        /// <param name="e_EXPLOSIVES"></param>
        /// <returns></returns>
        public MessageEF UpdateE_EXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/UpdateEEXPLOSIVES",JsonConvert.SerializeObject(e_EXPLOSIVES)));
                return messageEF;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Delete E EXPLOSIVES Details Data 
        /// </summary>
        /// <param name="e_EXPLOSIVES"></param>
        /// <returns></returns>
        public MessageEF DeleteE_EXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/DeleteEEXPLOSIVES",JsonConvert.SerializeObject(e_EXPLOSIVES)));
                return messageEF;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Get Mineral Grade Details Data 
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public List<E_EXPLOSIVES> GetMineralGarde(YearlyReturnModel yearlyReturnModel)
        {
            List<E_EXPLOSIVES> lste_EXPLOSIVEs = new List<E_EXPLOSIVES>();
            try
            {
                lste_EXPLOSIVEs = JsonConvert.DeserializeObject<List<E_EXPLOSIVES>>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/GetMineralGarde",JsonConvert.SerializeObject(yearlyReturnModel)));
                return lste_EXPLOSIVEs;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Get Details By Mineral Id Data 
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public E_EXPLOSIVES Change_MineralGrade(YearlyReturnModel yearlyReturnModel)
        {
            E_EXPLOSIVES e_EXPLOSIVES = new E_EXPLOSIVES();
            try
            {
                e_EXPLOSIVES = JsonConvert.DeserializeObject<E_EXPLOSIVES>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/ChangeMineralGrade",JsonConvert.SerializeObject(yearlyReturnModel)));
                return e_EXPLOSIVES;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region Table E(b)
        /// <summary>
        /// To Get E EXPLOSIVES b Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        public E_EXPLOSIVES_b Get_E_EXPLOSIVES_b(YearlyReturnModel yearlyReturnModel)
        {
            E_EXPLOSIVES_b e_EXPLOSIVES_B = new E_EXPLOSIVES_b();
            try
            {
                e_EXPLOSIVES_B = JsonConvert.DeserializeObject<E_EXPLOSIVES_b>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/GetEEXPLOSIVES_b",JsonConvert.SerializeObject(yearlyReturnModel)));
                return e_EXPLOSIVES_B;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Add E EXPLOSIVES b Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public MessageEF ADD_E_EXPLOSIVES_b(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/ADDEEXPLOSIVES_b",JsonConvert.SerializeObject(coalYearlyViewModel)));
                return messageEF;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Update E EXPLOSIVES b Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        public MessageEF Update_E_EXPLOSIVES_b(CoalYearlyViewModel coalYearlyViewModel)
        {
            MessageEF messageEF = new MessageEF();
           try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/UpdateEEXPLOSIVES_b",JsonConvert.SerializeObject(coalYearlyViewModel)));
                return messageEF;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region Final Submit
        /// <summary>
        /// Final Submit Of E Return Coal
        /// </summary>
        /// <param name="e_EXPLOSIVES_B"></param>
        /// <returns></returns>
        public MessageEF Update_FinalSubmit(E_EXPLOSIVES_b e_EXPLOSIVES_B)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("eReturnYearlyCoal/UpdateFinalSubmit",JsonConvert.SerializeObject(e_EXPLOSIVES_B)));
                return messageEF;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
