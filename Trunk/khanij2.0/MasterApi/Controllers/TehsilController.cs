using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.Tehsil;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class TehsilController : ControllerBase
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        private readonly ITehsilProvider tehsilProvider;

        #region Constructor
        public TehsilController(ITehsilProvider tehsilProvider)
        {
            this.tehsilProvider = tehsilProvider;
        }
        #endregion

        #region Add
        
        [HttpPost]
        public MessageEF Add(TehsilModel tehsilModel)
        {
            return tehsilProvider.AddTehsil(tehsilModel);
        }
        #endregion

        #region View
        [HttpPost]
        public List<TehsilModel> ViewDetails(TehsilModel tehsilModel)
        {
            return tehsilProvider.ViewTehsil(tehsilModel);
        }
        #endregion

        #region Edit
        [HttpPost]
        public TehsilModel Edit(TehsilModel tehsilModel)
        {
            return tehsilProvider.EditTehsil(tehsilModel);
        }
        #endregion

        #region Delete 
        [HttpPost]
        public MessageEF Delete(TehsilModel tehsilModel)
        {
            return tehsilProvider.DeleteTehsil(tehsilModel);
        }
        #endregion

        #region Update
        [HttpPost]
        public MessageEF Update(TehsilModel tehsilModel)
        {
            return tehsilProvider.UpdateTehsil(tehsilModel);
        }
        #endregion
    }
}