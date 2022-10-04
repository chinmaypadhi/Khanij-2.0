// ***********************************************************************
//  Class Name               : TestimonialProvider
//  Desciption               : Add,Select,Update,Delete Website Testimonial Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 27 Oct 2021
// ***********************************************************************
using Dapper;
using HomeApi.Factory;
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Model.Testimonial
{
    public class TestimonialProvider: RepositoryBase, ITestimonialProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public TestimonialProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Website Testimonial Details 
        /// </summary>
        /// <param name="objAddTestimonialModel"></param>
        /// <returns></returns>
        public MessageEF AddTestimonial(AddTestimonialModel objAddTestimonialModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_TESTIMONIAL_MSG", objAddTestimonialModel.VCH_TESTIMONIAL_MSG);
                p.Add("P_VCH_TESTIMONIAL_NAME", objAddTestimonialModel.VCH_TESTIMONIAL_NAME);
                p.Add("P_VCH_TESTIMONIAL_DESG", objAddTestimonialModel.VCH_TESTIMONIAL_DESG);
                p.Add("P_VCH_TESTIMONIAL_LOCATION", objAddTestimonialModel.VCH_TESTIMONIAL_LOCATION);
                p.Add("P_VCH_IMG_PATH", objAddTestimonialModel.VCH_IMG_PATH);
                p.Add("P_INT_USER_ID", objAddTestimonialModel.INT_CREATED_BY);
                p.Add("P_BIT_STATUS", objAddTestimonialModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_TESTIMONIAL_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Select Website Testimonial Details 
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        public async Task<List<ViewTestimonialModel>> ViewTestimonial(ViewTestimonialModel objViewTestimonialModel)
        {
            List<ViewTestimonialModel> ListTestimonial = new List<ViewTestimonialModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<ViewTestimonialModel>("USP_WEB_TESTIMONIAL_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListTestimonial = result.ToList();
                }
                return ListTestimonial;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit Website Testimonial Details
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        public AddTestimonialModel EditTestimonial(AddTestimonialModel objAddTestimonialModel)
        {
            AddTestimonialModel objaddTestimonialModel = new AddTestimonialModel();
            try
            {
                var paramList = new
                {
                    P_INT_TESTIMONIAL_ID = objAddTestimonialModel.INT_TESTIMONIAL_ID,
                    P_VCH_ACTION = "IDSELECT",
                };
                var result = Connection.Query<AddTestimonialModel>("USP_WEB_TESTIMONIAL_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddTestimonialModel = result.FirstOrDefault();
                }
                return objaddTestimonialModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Website Testimonial Details 
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        public MessageEF DeleteTestimonial(ViewTestimonialModel objViewTestimonialModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "DELETE");
                p.Add("P_INT_TESTIMONIAL_ID", objViewTestimonialModel.INT_TESTIMONIAL_ID);
                p.Add("P_INT_USER_ID", objViewTestimonialModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_TESTIMONIAL_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Update Website Testimonial Details 
        /// </summary>
        /// <param name="objAddTestimonialModel"></param>
        /// <returns></returns>
        public MessageEF UpdateTestimonial(AddTestimonialModel objAddTestimonialModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_TESTIMONIAL_ID", objAddTestimonialModel.INT_TESTIMONIAL_ID);
                p.Add("P_VCH_TESTIMONIAL_MSG", objAddTestimonialModel.VCH_TESTIMONIAL_MSG);
                p.Add("P_VCH_TESTIMONIAL_NAME", objAddTestimonialModel.VCH_TESTIMONIAL_NAME);
                p.Add("P_VCH_TESTIMONIAL_DESG", objAddTestimonialModel.VCH_TESTIMONIAL_DESG);
                p.Add("P_VCH_TESTIMONIAL_LOCATION", objAddTestimonialModel.VCH_TESTIMONIAL_LOCATION);
                p.Add("P_VCH_IMG_PATH", objAddTestimonialModel.VCH_IMG_PATH);
                p.Add("P_INT_USER_ID", objAddTestimonialModel.INT_CREATED_BY);
                p.Add("P_BIT_STATUS", objAddTestimonialModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_TESTIMONIAL_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// Select Publish Website Testimonial Details 
        /// </summary>
        /// <param name="objViewTestimonialModel"></param>
        /// <returns></returns>
        public async Task<List<ViewTestimonialModel>> ViewPublishTestimonial(ViewTestimonialModel objViewTestimonialModel)
        {
            List<ViewTestimonialModel> ListTestimonial = new List<ViewTestimonialModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "WEBSITE",
                };
                var result = await Connection.QueryAsync<ViewTestimonialModel>("USP_WEB_TESTIMONIAL_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListTestimonial = result.ToList();
                }
                return ListTestimonial;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
