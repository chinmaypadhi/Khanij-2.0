// ***********************************************************************
//  Controller Name          : GeneratedFPOController
//  Desciption               : View Generated Field Program Order details
//  Created By               : Lingaraj Dalai
//  Created On               : 17 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using GeologyApp.ActionFilter;
using GeologyApp.Models.FPO;
using GeologyEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GeologyApp.Controllers
{
    [Area("Geology")]
    public class GeneratedFPOController : Controller
    {
        /// <summary>
        /// Global object and variable declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        IFPOModel _objFPOMasterModel;
        MessageEF objobjmodel = new MessageEF();
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objFPOMasterModel"></param>
        public GeneratedFPOController(IFPOModel objFPOMasterModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objFPOMasterModel = objFPOMasterModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// To bind generated Field Program Order list details data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public IActionResult ViewList(FPOOrdermaster objmodel)
        {
            try
            {
                List<FPOOrdermaster> lstFPOmaster = _objFPOMasterModel.ViewGeneratedFPO(objmodel);
                ViewBag.ViewList = lstFPOmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Download upload files
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public ActionResult DowuloadFPO(string filename, string filepath)
        {
            var absolutePath = filename;
            if (filename != null)
            {
                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFPOPath"));
                if (filepath == null)
                    filepath = Path.Combine(RootPath, filename);
                if (filename.Contains("_"))
                {
                    string[] splitFileName = filename.Split('_');
                    filename = splitFileName[1];
                }
                if (System.IO.File.Exists(filepath))
                {
                    return File(new FileStream(filepath, FileMode.Open), "application/octetstream", filename);
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}