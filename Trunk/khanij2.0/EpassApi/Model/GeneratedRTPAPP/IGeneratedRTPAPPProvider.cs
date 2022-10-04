using EpassEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Model.GeneratedRTPAPP
{
    public interface IGeneratedRTPAPPProvider
    {
        Task<List<FinalForwadingNoteEF>> GetDGDMOFN(FinalForwadingNoteModelEF objtran);
       
    }
}
