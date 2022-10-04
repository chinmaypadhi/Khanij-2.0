using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Model.SandStoneRegd;

namespace userregistrationEFApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class SandStoneController: ControllerBase
    {
        public ISandStoneProvider _objISandStoneModel;
        public SandStoneController(ISandStoneProvider objSandStoneProvider)
        {
            _objISandStoneModel = objSandStoneProvider;
        }
        /// <summary>
        /// SubmitSandStoneRegd
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> SubmitSandStoneRegd(SandStoneModels objEU)
        {
            return await _objISandStoneModel.SubmitSandStoneRegd(objEU);
        }
        /// <summary>
        /// Get State
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<SandStoneModels>> GetState(SandStoneModels SandStoneModel)
        {
            return await _objISandStoneModel.GetState(SandStoneModel);
        }
        /// <summary>
        /// Get District
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<SandStoneModels>> GetDistrict(SandStoneModels SandStoneModel)
        {
            return await _objISandStoneModel.GetDistrict(SandStoneModel);
        }
        /// <summary>
        /// Get Block
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<SandStoneModels>> GetBlock(SandStoneModels SandStoneModel)
        {
            return await _objISandStoneModel.GetBlock(SandStoneModel);
        }
        /// <summary>
        /// Get MineralName
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<SandStoneModels>> GetMineralName(SandStoneModels SandStoneModel)
        {
            return await _objISandStoneModel.GetMineralName(SandStoneModel);
        }
        /// <summary>
        /// Get UserType
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<SandStoneModels>> GetUserType(SandStoneModels SandStoneModel)
        {
            return await _objISandStoneModel.GetUserType(SandStoneModel);
        }
        /// <summary>
        /// Get Ko_Id
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<SandStoneModels>> GetKo_Id(SandStoneModels SandStoneModel)
        {
            return await _objISandStoneModel.GetKo_Id(SandStoneModel);
        }
        /// <summary>
        /// Get MineralForm
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<List<SandStoneModels>> GetMineralForm(SandStoneModels SandStoneModel)
        {
            return await _objISandStoneModel.GetMineralForm(SandStoneModel);
        }
        /// <summary>
        /// Get MineralForm
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns>List<LicenseApplication></returns>
        [HttpPost]
        public async Task<SandStoneModels> GetSandStoneNamePass(SandStoneModels SandStoneModel)
        {
            return await _objISandStoneModel.GetSandStoneNamePass(SandStoneModel);
        }
    }
}
