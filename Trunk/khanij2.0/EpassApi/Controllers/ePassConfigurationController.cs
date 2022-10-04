using EpassApi.Model.ePassConfiguration;
using EpassEF;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EpassApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class ePassConfigurationController : Controller
    {
        private IePassConfigurationProvider _objIPurchaserConsigneeProvider;
        public IActionResult Index()
        {
            return View();
        }
        public ePassConfigurationController(IePassConfigurationProvider objIePassConfigurationProvide)
        {
            _objIPurchaserConsigneeProvider = objIePassConfigurationProvide;
        }
        public async Task<List<ePassConfigurationEF>> GetDistrict(ePassConfigurationEF model)
        {
            return await _objIPurchaserConsigneeProvider.GetDistrict(model);
        }
        public async Task<List<ePassConfigurationEF>> GetUserType(ePassConfigurationEF model)
        {
            return await _objIPurchaserConsigneeProvider.GetUserType(model);
        }
        public async Task<List<ePassConfigurationEF>> GetMineralType(ePassConfigurationEF model)
        {
            return await _objIPurchaserConsigneeProvider.GetMineralType(model);
        }
        public async Task<List<ePassConfigurationEF>> GetUserName(ePassConfigurationEF model)
        {
            return await _objIPurchaserConsigneeProvider.GetUserName(model);
        }
        public async Task<List<ePassConfigurationEF>> GetMineralName(ePassConfigurationEF model)
        {
            return await _objIPurchaserConsigneeProvider.GetMineralName(model);
        }
        public async Task<List<ePassConfigurationEF>> GetTransportationMode(ePassConfigurationEF model)
        {
            return await _objIPurchaserConsigneeProvider.GetTransportationMode(model);
        }
        public async Task<List<ePassConfigurationEF>> GetAllowConsignee(ePassConfigurationEF model)
        {
            return await _objIPurchaserConsigneeProvider.GetAllowConsignee(model);
        }
        #region Add
        /// <summary>
        /// Add Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF AddEpassConfiguration(ePassConfigurationEF model)
        {
            return _objIPurchaserConsigneeProvider.AddEpassConfiguration(model);
        }
        #endregion
        #region View Configuration
        public async Task<List<ePassConfigurationEF>> ViewEpassConfiguration(ePassConfigurationEF model)
        {
            return await _objIPurchaserConsigneeProvider.ViewEpassConfiguration(model);
        }
        #endregion
        #region Edit View Configuration
        public ePassConfigurationEF EditViewConfig(ePassConfigurationEF model)
        {
            return _objIPurchaserConsigneeProvider.EditViewConfig(model);
        }
        #endregion
        #region Update View Configuration
        [HttpPost]
        public MessageEF UpdateEpassConfiguration(ePassConfigurationEF model)
        {
            return _objIPurchaserConsigneeProvider.UpdateEpassConfiguration(model);
        }
        #endregion

        #region Delete  Configuration
        [HttpPost]
        public MessageEF DeleteEpassConfiguration(ePassConfigurationEF model)
        {
            return _objIPurchaserConsigneeProvider.DeleteEpassConfiguration(model);
        }
        #endregion
    }
}
