using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpassEF;

namespace EpassApi.Model.CaseOfIrregularity
{
    public interface ICaseOfIrregularityProvider
    {
        Task<List<CheckPostIrrgModel>> ExcessMineralForCheckPost(CheckPostIrrgModel checkPostIrrgModel);
        Task<List<CheckPostIrrgModel>> GetDetailsFromTP(CheckPostIrrgModel checkPostIrrgModel);
       
    }
}
