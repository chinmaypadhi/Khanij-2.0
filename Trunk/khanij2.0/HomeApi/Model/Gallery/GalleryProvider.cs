// ***********************************************************************
//  Class Name               : GalleryProvider
//  Desciption               : Add,Select,Update,Delete Website Gallery Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Oct 2021
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


namespace HomeApi.Model.Gallery
{
    public class GalleryProvider: RepositoryBase, IGalleryProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public GalleryProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Website Gallery Details 
        /// </summary>
        /// <param name="objAddGalleryModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddGallery(AddGalleryModel objAddGalleryModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_CONTENT_TYPE", objAddGalleryModel.INT_CONTENT_TYPE);
                p.Add("P_VCH_THUMBNAIL_IMG_PATH", objAddGalleryModel.VCH_THUMBNAIL_IMG_PATH);
                p.Add("P_VCH_IMG_PATH", objAddGalleryModel.VCH_IMG_PATH);
                p.Add("P_VCH_THUMBNAIL_VIDEOIMG_PATH", objAddGalleryModel.VCH_THUMBNAIL_VIDEOIMG_PATH);
                p.Add("P_VCH_VIDEO_PATH", objAddGalleryModel.VCH_VIDEO_PATH);
                p.Add("P_VCH_VIDEO_URL", objAddGalleryModel.VCH_VIDEO_URL);
                p.Add("P_VCH_GALLERY_DESC", objAddGalleryModel.VCH_GALLERY_DESC);
                p.Add("P_INT_SEQUENCE", objAddGalleryModel.INT_SEQUENCE);
                p.Add("P_INT_USER_ID", objAddGalleryModel.INT_CREATED_BY);
                p.Add("P_BIT_STATUS", objAddGalleryModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_GALLERY_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Select Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public async Task<List<ViewGalleryModel>> ViewGallery(ViewGalleryModel objViewGalleryModel)
        {
            List<ViewGalleryModel> ListNotification = new List<ViewGalleryModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<ViewGalleryModel>("USP_WEB_GALLERY_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListNotification = result.ToList();
                }
                return ListNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Gallery Archive Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public async Task<List<ViewGalleryModel>> ViewGalleryArchive(ViewGalleryModel objViewGalleryModel)
        {
            List<ViewGalleryModel> ListNotification = new List<ViewGalleryModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECTARCHIVE",
                };
                var result = await Connection.QueryAsync<ViewGalleryModel>("USP_WEB_GALLERY_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListNotification = result.ToList();
                }
                return ListNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit Website Gallery Details
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public async Task<AddGalleryModel> EditGallery(AddGalleryModel objAddGalleryModel)
        {
            AddGalleryModel objaddGalleryModel = new AddGalleryModel();
            try
            {
                var paramList = new
                {
                    P_INT_GALLERY_ID = objAddGalleryModel.INT_GALLERY_ID,
                    P_VCH_ACTION = "IDSELECT",
                };
                var result = await Connection.QueryAsync<AddGalleryModel>("USP_WEB_GALLERY_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddGalleryModel = result.FirstOrDefault();
                }
                return objaddGalleryModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Archive Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> ArchiveGallery(ViewGalleryModel objViewGalleryModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "ARCHIVE");
                p.Add("P_INT_GALLERY_ID", objViewGalleryModel.INT_GALLERY_ID);
                p.Add("P_INT_USER_ID", objViewGalleryModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_GALLERY_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Delete Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteGallery(ViewGalleryModel objViewGalleryModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "DELETE");
                p.Add("P_INT_GALLERY_ID", objViewGalleryModel.INT_GALLERY_ID);
                p.Add("P_INT_USER_ID", objViewGalleryModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_GALLERY_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Update Website Gallery Details 
        /// </summary>
        /// <param name="objAddGalleryModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateGallery(AddGalleryModel objAddGalleryModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_GALLERY_ID", objAddGalleryModel.INT_GALLERY_ID);
                p.Add("P_INT_CONTENT_TYPE", objAddGalleryModel.INT_CONTENT_TYPE);
                p.Add("P_VCH_THUMBNAIL_IMG_PATH", objAddGalleryModel.VCH_THUMBNAIL_IMG_PATH);
                p.Add("P_VCH_IMG_PATH", objAddGalleryModel.VCH_IMG_PATH);
                p.Add("P_VCH_THUMBNAIL_VIDEOIMG_PATH", objAddGalleryModel.VCH_THUMBNAIL_VIDEOIMG_PATH);
                p.Add("P_VCH_VIDEO_PATH", objAddGalleryModel.VCH_VIDEO_PATH);
                p.Add("P_VCH_VIDEO_URL", objAddGalleryModel.VCH_VIDEO_URL);
                p.Add("P_VCH_GALLERY_DESC", objAddGalleryModel.VCH_GALLERY_DESC);
                p.Add("P_INT_SEQUENCE", objAddGalleryModel.INT_SEQUENCE);
                p.Add("P_INT_USER_ID", objAddGalleryModel.INT_CREATED_BY);
                p.Add("P_BIT_STATUS", objAddGalleryModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_GALLERY_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Publish Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> PublishGallery(ViewGalleryModel objViewGalleryModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "PUBLISH");
                p.Add("P_INT_GALLERY_ID", objViewGalleryModel.INT_GALLERY_ID);
                p.Add("P_INT_USER_ID", objViewGalleryModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_GALLERY_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Unpublish Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UnpublishGallery(ViewGalleryModel objViewGalleryModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "UNPUBLISH");
                p.Add("P_INT_GALLERY_ID", objViewGalleryModel.INT_GALLERY_ID);
                p.Add("P_INT_USER_ID", objViewGalleryModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_GALLERY_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Active Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> Active(ViewGalleryModel objViewGalleryModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "ACTIVE");
                p.Add("P_INT_GALLERY_ID", objViewGalleryModel.INT_GALLERY_ID);
                p.Add("P_INT_USER_ID", objViewGalleryModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_GALLERY_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Get Website Gallery Sequence count Details 
        /// </summary>
        /// <param name="objAddGalleryModel"></param>
        /// <returns></returns>s
        public async Task<AddGalleryModel> GetSequence(AddGalleryModel objAddGalleryModel)
        {
            AddGalleryModel objaddGalleryModel = new AddGalleryModel();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SEQUENCE",
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<AddGalleryModel>("USP_WEB_GALLERY_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddGalleryModel = result.FirstOrDefault();
                }
                return objaddGalleryModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        public async Task<List<ViewGalleryModel>> ViewWebsiteGallery(ViewGalleryModel objViewGalleryModel)
        {
            List<ViewGalleryModel> ListNotification = new List<ViewGalleryModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "WEBSITE",
                };
                var result = await Connection.QueryAsync<ViewGalleryModel>("USP_WEB_GALLERY_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListNotification = result.ToList();
                }
                return ListNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
