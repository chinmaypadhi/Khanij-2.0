using EpassApp.Areas.Epass.Models.GeneratedRTPAPP;
using EpassApp.KhanijSecurity;
using EpassApp.Web;
using EpassEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Controllers
{
    [Area("EPass")]
    public class GeneratedRTPAPPController : Controller
    {
        private IFinalForwadingNoteModel _objIFinalForwadingNote;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly KhanijIDataProtection protector;
        int userid = 0;//194;//387;
        string usertype = string.Empty;//  "Licensee";

        public GeneratedRTPAPPController(IFinalForwadingNoteModel objIFinalForwadingNote, IHostingEnvironment hostingEnvironment, KhanijIDataProtection khanijIDataProtection)
        {
            protector = khanijIDataProtection;
            _objIFinalForwadingNote = objIFinalForwadingNote;

            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult FinalForwadingNote()
        {
            List<FinalForwadingNoteEF> objtransit = new List<FinalForwadingNoteEF>();
            FinalForwadingNoteModelEF objmodel = new FinalForwadingNoteModelEF();
            try
            {

                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                userid = Convert.ToInt32(profile.UserId);
                usertype = profile.UserType;
                objmodel.userid = userid;
                objmodel.final = 3;
                objmodel.UserType = usertype;
                objtransit = _objIFinalForwadingNote.FinalForwadingNoteData(objmodel);



                return View(objtransit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                objtransit = null;

            }
           // return View(objtransit);
        }
    }
}
