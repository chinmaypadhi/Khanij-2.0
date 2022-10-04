using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using HomeApi.Factory;
using HomeApi.Repository;
using HomeEF;

namespace HomeApi.Model.WebsiteGallery
{
    public class WebsiteGarlleryProvider: RepositoryBase,IWebsiteGarlleryProvider
    {
        public WebsiteGarlleryProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<List<ViewGalleryWebsite>> ViewGallery(ViewGalleryWebsite objViewBannerModel)
        {
            List<ViewGalleryWebsite> objGalleryList = new List<ViewGalleryWebsite>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<ViewGalleryWebsite>("USP_WEB_GALLERY_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objGalleryList = result.ToList();
                }
                return objGalleryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
