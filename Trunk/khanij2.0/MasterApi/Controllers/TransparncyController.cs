// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 25-Jan-2021
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterApi.Model.Transparncy;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class TransparncyController : ControllerBase
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        public ITransparncyProvider _objITransparncyProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="objTransparncyProvider"></param>
        public TransparncyController(ITransparncyProvider objTransparncyProvider)
        {
            _objITransparncyProvider = objTransparncyProvider;
        }
        /// <summary>
        /// To Add Transparncy
        /// </summary>
        /// <param name="objTransparncymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(Transparncymaster objTransparncymaster)
        {
            return _objITransparncyProvider.AddTransparncymaster(objTransparncymaster);
        }
        /// <summary>
        /// To View Transparncy
        /// </summary>
        /// <param name="objTransparncymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task< List<Transparncymaster>> View(Transparncymaster objTransparncymaster)
        {
            return await _objITransparncyProvider.ViewTransparncymaster(objTransparncymaster);
        }
        /// <summary>
        /// To Edit Transparncy
        /// </summary>
        /// <param name="objTransparncymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public Transparncymaster Edit(Transparncymaster objTransparncymaster)
        {
            return _objITransparncyProvider.EditTransparncymaster(objTransparncymaster);
        }
        /// <summary>
        /// To Delete Transparncy
        /// </summary>
        /// <param name="objTransparncymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(Transparncymaster objTransparncymaster)
        {
            return _objITransparncyProvider.DeleteTransparncymaster(objTransparncymaster);
        }
        /// <summary>
        /// To Update Transparncy
        /// </summary>
        /// <param name="objTransparncymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(Transparncymaster objTransparncymaster)
        {
            return _objITransparncyProvider.UpdateTransparncymaster(objTransparncymaster);
        }
        /// <summary>
        /// For Displaying Notice in Website
        /// </summary>
        /// <param name="objTransparncymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Transparncymaster> ViewNotice(Transparncymaster objTransparncymaster)
        {
            return _objITransparncyProvider.ViewNotice(objTransparncymaster);
        }
    }
}