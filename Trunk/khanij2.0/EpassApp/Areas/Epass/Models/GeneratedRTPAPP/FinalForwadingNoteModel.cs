using EpassApp.Models.Utility;
using EpassEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.GeneratedRTPAPP
{
    public class FinalForwadingNoteModel : IFinalForwadingNoteModel
    {
        IHttpWebClients _objIHttpWebClients;
        public FinalForwadingNoteModel(IHttpWebClients objIHttpWebClients)
        {

            _objIHttpWebClients = objIHttpWebClients;
        }
        public List<FinalForwadingNoteEF> FinalForwadingNoteData(FinalForwadingNoteModelEF objtran)
        {
            List<FinalForwadingNoteEF> ListFinalForwadingNote = new List<FinalForwadingNoteEF>();
            try
            {
                ListFinalForwadingNote = JsonConvert.DeserializeObject<List<FinalForwadingNoteEF>>(_objIHttpWebClients.PostRequest("GeneratedRTPAPP/GeneratedRTPAPPData", JsonConvert.SerializeObject(objtran)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListFinalForwadingNote;
        }

      
    }
}
