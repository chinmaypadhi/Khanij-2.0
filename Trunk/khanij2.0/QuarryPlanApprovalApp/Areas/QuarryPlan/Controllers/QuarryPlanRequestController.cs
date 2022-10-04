// ***********************************************************************
//  Controller Name          : QuarryPlanRequest
//  Desciption               : Quarry Plan Request Initiate 
//  Created By               : Ranjan kumar Behera
//  Created On               : 30 March 2022
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuarryPlanApprovalApp.Areas.QuarryPlan.Models;
using QuarryPlanApprovalEF;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuarryPlanApprovalApp.Web;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace QuarryPlanApprovalApp.Areas.QuarryPlan.Controllers
{
    [Area("QuarryPlan")]
    public class QuarryPlanRequestController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        IFinancialYear objIFinancialYear;
        QuarryPlanModel objquarryplanmodel = new QuarryPlanModel();
        List<QuarryPlanModel> objquarryplanmodellist = new List<QuarryPlanModel>();
        IQuarryPlanRequest objIquarryplanrequest;
        public QuarryPlanRequestController(IQuarryPlanRequest objIquarryplanrequest, IFinancialYear objIFinancialYear, IHostingEnvironment hostingEnvironment)
        {
            this.objIquarryplanrequest = objIquarryplanrequest;
            this.objIFinancialYear = objIFinancialYear;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult NewRequest()
        {
            objquarryplanmodel.Step = 1;
            //setting up empty data to form tables and dropdown fillup
            objquarryplanmodel.DtLeaseBoundary = new DataTable();
            ViewData["FinancialYear"] = objIFinancialYear.GetFinancialYear();
            ViewData["District"] = objquarryplanmodellist;
            return View(objquarryplanmodel);
        }
        public IActionResult ViewQuarryPlan()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objquarryplanmodel.LesseeID = profile.UserId;
            ViewData["QPView"] = objIquarryplanrequest.QPView(objquarryplanmodel);
            return View();
        }
        public IActionResult EditQuarryPlan(string QID)
        {
            objquarryplanmodel.DtLeaseBoundary = new DataTable();
            objquarryplanmodel.DtLeaseBoundary.Columns.Add("BoundaryType", typeof(string));
            objquarryplanmodel.DtLeaseBoundary.Columns.Add("Latitude", typeof(string));
            objquarryplanmodel.DtLeaseBoundary.Columns.Add("Longitude", typeof(string));
            objquarryplanmodel.DtLeaseBoundary.Rows.Add("Pillar1", "5.34343", "4.324343");
            objquarryplanmodel.DtLeaseBoundary.Rows.Add("Pillar2", "2.64354", "5.645345");
            return View("NewRequest", objquarryplanmodel);
        }
        [HttpPost]
        public IActionResult SaveStep1(QuarryPlanModel obj, IFormCollection collection)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.LesseeID = profile.UserId;

            //getting khasra and lease boundary data from html tables
            string[] KhasraNos = collection["KhasraNo"].ToString().Split(char.Parse(","));
            string[] Boundarytypes = collection["Boundarytype"].ToString().Split(char.Parse(","));
            string[] Latitudes = collection["Latitude"].ToString().Split(char.Parse(","));
            string[] Longitudes = collection["Longitude"].ToString().Split(char.Parse(","));
            DataTable dtkhasra = new DataTable();
            dtkhasra.Columns.Add("KhasraNo", typeof(string));
            for (int i = 0; i < KhasraNos.Length; i++)
            {
                if (string.IsNullOrEmpty(KhasraNos[i].ToString()) == false)
                {
                    dtkhasra.Rows.Add(KhasraNos[i]);
                }
            }
            obj.DtKhasra = dtkhasra;

            DataTable dtleaseboundary = new DataTable();
            dtleaseboundary.Columns.Add("BoundaryType", typeof(string));
            dtleaseboundary.Columns.Add("Latitude", typeof(string));
            dtleaseboundary.Columns.Add("Longitude", typeof(string));
            for (int i = 0; i < Boundarytypes.Length; i++)
            {
                if (string.IsNullOrEmpty(Boundarytypes[i].ToString()) == false)
                {
                    dtleaseboundary.Rows.Add(Boundarytypes[i], Latitudes[i], Longitudes[i]);
                }
            }
            obj.DtKhasra = dtkhasra;
            obj.DtLeaseBoundary = dtleaseboundary;

            if (obj.QID==0)
            {
                //Generating 8 digit random number and saving step1 data to database
                //Generating random number here in case user wants manual number in future..
                Random rnd = new Random();
                obj.QID = rnd.Next(10000000, 99999999);
                //obj.QID = 26677806;
                objIquarryplanrequest.QPStep1Save(obj);
                obj.Step = 2;
            }
            else
            {
                //updating step1 to database
                //code here
            }
            //setting up empty data to form tables and dropdown fillup
            obj.DtLeaseBoundary = new DataTable();
            ViewData["FinancialYear"] = objIFinancialYear.GetFinancialYear();
            ViewData["District"] = objquarryplanmodellist;
            return View("NewRequest", obj);
        }
        [HttpPost]
        public IActionResult SaveStep2(QuarryPlanModel obj)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.LesseeID = profile.UserId;
            objIquarryplanrequest.QPStep2Save(obj);
            obj.Step = 3;
            //setting up empty data to form tables and dropdown fillup
            obj.DtLeaseBoundary = new DataTable();
            ViewData["FinancialYear"] = objIFinancialYear.GetFinancialYear();
            ViewData["District"] = objquarryplanmodellist;
            return View("NewRequest", obj);
        }
        [HttpPost]
        public IActionResult SaveStep3(QuarryPlanModel obj, IFormCollection collection)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.LesseeID = profile.UserId;
            //getting mineral plan data in datatable from html tables
            string[] FinancialYears = collection["FinancialYear"].ToString().Split(char.Parse(","));
            string[] MineralQtys = collection["MineralQty"].ToString().Split(char.Parse(","));
            string[] MineralRemarks = collection["MineralRemark"].ToString().Split(char.Parse(","));
            DataTable dtmineralplan = new DataTable();
            dtmineralplan.Columns.Add("FinancialYear", typeof(string));
            dtmineralplan.Columns.Add("MineralQty", typeof(string));
            dtmineralplan.Columns.Add("MineralRemark", typeof(string));
            for (int i = 0; i < FinancialYears.Length; i++)
            {
                if (string.IsNullOrEmpty(FinancialYears[i].ToString()) == false)
                {
                    dtmineralplan.Rows.Add(FinancialYears[i], MineralQtys[i], MineralRemarks[i]);
                }
            }
            obj.DtMineralPlan = dtmineralplan;
            //uploading quarryplan files to server and generating filename
            string uniquequarryplancopy = "";
            string uniquequarryplanpath = "";
            if (obj.QuarryPlanCopy != null)
            {

                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/QuarryPlan");
                uniquequarryplancopy = Guid.NewGuid().ToString() + "_" + obj.QuarryPlanCopy.FileName;
                uniquequarryplanpath = Path.Combine(uploadsFolder, uniquequarryplancopy);
                obj.QuarryPlanCopy.CopyTo(new FileStream(uniquequarryplanpath, FileMode.Create));
            }
            obj.QuarryPlanCopy = null;
            obj.QuarryPlanFile = uniquequarryplancopy;
            //uploading supporting files to server and generating filename
            string uniquesupportingdoccopy = "";
            string uniquesupportingdoccopypath = "";
            if (obj.SupportingDocCopy != null)
            {

                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/QuarryPlan");
                uniquesupportingdoccopy = Guid.NewGuid().ToString() + "_" + obj.SupportingDocCopy.FileName;
                uniquesupportingdoccopypath = Path.Combine(uploadsFolder, uniquesupportingdoccopy);
                obj.SupportingDocCopy.CopyTo(new FileStream(uniquesupportingdoccopypath, FileMode.Create));
            }
            obj.SupportingDocCopy = null;
            obj.SupportingDocFile = uniquesupportingdoccopy;
            //saving step3
            objIquarryplanrequest.QPStep3Save(obj);
            obj.Step = 4;
            //setting up empty data to form tables and dropdown fillup
            obj.DtLeaseBoundary = new DataTable();
            ViewData["FinancialYear"] = objIFinancialYear.GetFinancialYear();
            ViewData["District"] = objIquarryplanrequest.ViewDistrict(objquarryplanmodel);
            return View("NewRequest", obj);
        }
        [HttpPost]
        public IActionResult SaveStep4(QuarryPlanModel obj)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.LesseeID = profile.UserId;
            string uniqueCertificatecopy = "";
            string uniqueCertificatepath = "";
            if (obj.RQPCertificateCopy != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/QuarryPlan");
                uniqueCertificatecopy = Guid.NewGuid().ToString() + "_" + obj.RQPCertificateCopy.FileName;
                uniqueCertificatepath = Path.Combine(uploadsFolder, uniqueCertificatecopy);
                obj.RQPCertificateCopy.CopyTo(new FileStream(uniqueCertificatepath, FileMode.Create));
            }
            obj.RQPCertificateCopy = null;
            obj.RQPCertificateFile = uniqueCertificatecopy;
            objIquarryplanrequest.QPStep4Save(obj);
            return View("ViewQuarryPlan");
        }
    }
}
