using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApi.Model.WebsiteGallery;
using HomeEF;

namespace HomeApi.Model.WebsiteGallery
{
    public interface IWebsiteGarlleryProvider
    {
        Task<List<ViewGalleryWebsite>> ViewGallery(ViewGalleryWebsite  viewGalleryWebsite);
    }
}
