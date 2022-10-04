using MasterApi.Model.MineralSize;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class MineralSizeController : ControllerBase
    {
        private readonly IMineralSizeProvider mineralSizeProvider;

        public MineralSizeController(IMineralSizeProvider mineralSizeProvider)
        {
            this.mineralSizeProvider = mineralSizeProvider;
        }

        /// <summary>
        /// Add Mineral Size
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<MessageEF> Add(MineralSizeMaster mineralSizeMaster)
        {
            return await mineralSizeProvider.AddMineralSize(mineralSizeMaster);
        }

        /// <summary>
        /// View Mineral Size
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<List<MineralSizeMaster>> ViewDetails(MineralSizeMaster mineralSizeMaster)
        {
            return await mineralSizeProvider.ViewMineralSize(mineralSizeMaster);
        }

        /// <summary>
        /// Edit Mineral Size
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<MineralSizeMaster> Edit(MineralSizeMaster mineralSizeMaster)
        {
            return await mineralSizeProvider.EditMineralSize(mineralSizeMaster);
        }

        /// <summary>
        /// Delete Mineral Size
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<MessageEF> Delete(MineralSizeMaster mineralSizeMaster)
        {
            return await mineralSizeProvider.DeleteMineralSize(mineralSizeMaster);
        }

        /// <summary>
        /// Update Mineral Size
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<MessageEF> Update(MineralSizeMaster mineralSizeMaster)
        {
            return await mineralSizeProvider.UpdateMineralSize(mineralSizeMaster);
        }
    }
}
