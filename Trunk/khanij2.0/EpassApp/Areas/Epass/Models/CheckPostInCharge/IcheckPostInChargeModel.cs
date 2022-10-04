using EpassEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.CheckPostInCharge
{
  public  interface IcheckPostInChargeModel
    {
        List<CheckPostIrrgModel> GetTPInfromation(CheckPostIrrgModel checkPostIrrgModel);
        List<CheckPostIrrgModel> ExcessMineralForCheckPost(CheckPostIrrgModel checkPostIrrgModel);
    }
}
