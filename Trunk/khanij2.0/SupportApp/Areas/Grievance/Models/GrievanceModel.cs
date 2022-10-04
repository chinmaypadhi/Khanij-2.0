using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportEF;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using SupportApp.Models.Utility;

namespace SupportApp.Areas.Grievance.Models
{
    public class GrievanceModel: IGrievanceModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIHttpWebClients"></param>
        public GrievanceModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To Get district
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>FillDDl Class</returns>
        public FillDDl GetDist(PublicGrievanceModel ObjEU)
        {
          
            try
            {
                Result<FillDDl> r = new Result<FillDDl>();
                r= JsonConvert.DeserializeObject<Result<FillDDl>>(_objIHttpWebClients.PostRequest("Grievance/fillDist", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// To Get Complaint Type
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>FillDDl Class</returns>
        public FillDDl GetCtype(PublicGrievanceModel ObjEU)
        {
            try
            {
                Result<FillDDl> r = new Result<FillDDl>();
                r= JsonConvert.DeserializeObject<Result<FillDDl>>(_objIHttpWebClients.PostRequest("Grievance/fillCtype", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// To Get OTP
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>PublicGrievanceModel Class</returns>
        public PublicGrievanceModel GetOTPModel(PublicGrievanceModel ObjEU)
        {
            try
            {
                Result<PublicGrievanceModel> r = new Result<PublicGrievanceModel>();
                r = JsonConvert.DeserializeObject<Result<PublicGrievanceModel>>(_objIHttpWebClients.PostRequest("Grievance/GetOTP", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// To Verify OTP
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF Class</returns>
        //public MessageEF VerifyOTP(PublicGrievanceModel ObjEU)
        //{
        //    try
        //    {
        //        Result<MessageEF> r = new Result<MessageEF>();
        //        r= JsonConvert.DeserializeObject <Result<MessageEF>>(_objIHttpWebClients.PostRequest("Grievance/OTPVerify", JsonConvert.SerializeObject(ObjEU)));
        //        return r.Data;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        ObjEU = null;
        //    }

        //}
        /// <summary>
        /// To Add Public Grievance 
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF Class</returns>
        public MessageEF AddPublicGrievance(PublicGrievanceModel ObjEU)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Grievance/AddPGrievance", JsonConvert.SerializeObject(ObjEU)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// To Get all state
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>FillDDl Class</returns>
        public  FillDDl GetState(PublicGrievanceModel ObjEU)
        {
            try
            {
                Result<FillDDl> r = new Result<FillDDl>();

                r= JsonConvert.DeserializeObject<Result<FillDDl>>(_objIHttpWebClients.PostRequest("Grievance/fillState", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// To Get all User Details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>PublicGrievanceModel Class</returns>
        public PublicGrievanceModel GetUDetails(PublicGrievanceModel ObjEU)
        {
            try
            {
                Result<PublicGrievanceModel> r = new Result<PublicGrievanceModel>();
                r = JsonConvert.DeserializeObject<Result<PublicGrievanceModel>>(_objIHttpWebClients.PostRequest("Grievance/GetUserData", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// To Add Grievance
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF Class</returns>
        public MessageEF AddGrievance(PublicGrievanceModel ObjEU)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Grievance/AddGrievance", JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ObjEU = null;
            }
        }
        /// <summary>
        /// To Public Grievance
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of PublicGrievanceModel Class</returns>
        public List<PublicGrievanceModel> GetLst(PublicGrievanceModel ObjEU)
        {
            try
            {
                Result<List<PublicGrievanceModel>> r = new Result<List<PublicGrievanceModel>>();
                List<PublicGrievanceModel> objlistEU = new List<PublicGrievanceModel>();
                r = JsonConvert.DeserializeObject<Result<List<PublicGrievanceModel>>>(_objIHttpWebClients.PostRequest("Grievance/GetList", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// To Particular Grievance data
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>PublicGrievanceModel Class</returns>
        public PublicGrievanceModel GetSingleData(PublicGrievanceModel ObjEU)
        {
            try
            {
                Result<PublicGrievanceModel> r = new Result<PublicGrievanceModel>();
                r = JsonConvert.DeserializeObject<Result<PublicGrievanceModel>>(_objIHttpWebClients.PostRequest("Grievance/GetData", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ObjEU = null;
            }
        }
        /// <summary>
        /// Get User Type
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>FillDDl Class</returns>
        public FillDDl GetUtype(PublicGrievanceModel ObjEU)
        {
            try
            {
                Result<FillDDl> r = new Result<FillDDl>();

                r= JsonConvert.DeserializeObject<Result<FillDDl>>(_objIHttpWebClients.PostRequest("Grievance/UTDDLLoad", JsonConvert.SerializeObject(ObjEU)));

                return r.Data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// Get User by Type
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>FillDDl Class</returns>
        public FillDDl GetUByType(PublicGrievanceModel ObjEU)
        {
            try
            {
                Result<FillDDl> r = new Result<FillDDl>();
                r= JsonConvert.DeserializeObject<Result<FillDDl>>(_objIHttpWebClients.PostRequest("Grievance/GetName", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// Get Complaint
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>FillDDl Class</returns>
        public FillDDl CComplaint(PublicGrievanceModel ObjEU)
        {
            try
            {
                Result<FillDDl> r = new Result<FillDDl>();
                r= JsonConvert.DeserializeObject<Result<FillDDl>>(_objIHttpWebClients.PostRequest("Grievance/CComplaint", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// Forward Complaint to DD
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF Class</returns>
        public MessageEF FFOrwordDD(PublicGrievanceModel ObjEU)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Grievance/FDD", JsonConvert.SerializeObject(ObjEU)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// Get Complaint List
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of PublicGrievanceModel Class</returns>
        public List<PublicGrievanceModel> GetGCLst(PublicGrievanceModel ObjEU)
        {
            List<PublicGrievanceModel> objlistEU = new List<PublicGrievanceModel>();
            Result<List<PublicGrievanceModel>> r = new Result<List<PublicGrievanceModel>>();
            try
            {
                r = JsonConvert.DeserializeObject<Result<List<PublicGrievanceModel>>>(_objIHttpWebClients.PostRequest("Grievance/GetGCList", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ObjEU = null;
                objlistEU = null;
            }

        }
        /// <summary>
        /// Add DGM Grievance
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF Class</returns>
        public MessageEF AddDGMGrievance(PublicGrievanceModel ObjEU)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Grievance/AddDGMGrievance", JsonConvert.SerializeObject(ObjEU)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ObjEU = null;
            }
        }
        /// <summary>
        /// Get MI List
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of PublicGrievanceModel Class</returns>
        public List<PublicGrievanceModel> GetLstMI(PublicGrievanceModel ObjEU)
        {
            Result<List<PublicGrievanceModel>> objlistEU = new Result<List<PublicGrievanceModel>>();
            Result<List<PublicGrievanceModel>> r = new Result<List<PublicGrievanceModel>>();
            try
            {      
                
                r = JsonConvert.DeserializeObject<Result<List<PublicGrievanceModel>>>(_objIHttpWebClients.PostRequest("Grievance/GetMIList", JsonConvert.SerializeObject(ObjEU)));
              return  r.Data;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objlistEU = null;
                ObjEU = null;
            }

        }
        /// <summary>
        /// MI Forward to DD 
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF Class</returns>
        public MessageEF MIFFOrwordDD(ForwardMItoDD ObjEU)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Grievance/MIFDD", JsonConvert.SerializeObject(ObjEU)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// Close Grievance
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>PublicGrievanceModel Class</returns>
        public PublicGrievanceModel CloseGR(CloseComplain ObjEU)
        {
            PublicGrievanceModel objmodel = new PublicGrievanceModel();
            try
            {
                Result<PublicGrievanceModel> r = new Result<PublicGrievanceModel>();
                r = JsonConvert.DeserializeObject<Result<PublicGrievanceModel>>(_objIHttpWebClients.PostRequest("Grievance/CloseGrievance", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ObjEU = null;
                objmodel = null;
            }
        }
        #region Verify Mobile No
        /// <summary>
        /// To Verify Mobile No
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public MessageEF VerifyMobile(PublicGrievanceModel GrievanceModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Grievance/VerifyMobile1", JsonConvert.SerializeObject(GrievanceModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region Get OTP
        /// <summary>
        /// Get OTP to Validate Mobile No
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public MessageEF GetOTP(PublicGrievanceModel GrievanceModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Grievance/OTPDetails1", JsonConvert.SerializeObject(GrievanceModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region Verify OTP
        /// <summary>
        /// To Verify OTP
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public MessageEF VerifyOTP(PublicGrievanceModel GrievanceModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Grievance/OTPVerification1", JsonConvert.SerializeObject(GrievanceModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}
