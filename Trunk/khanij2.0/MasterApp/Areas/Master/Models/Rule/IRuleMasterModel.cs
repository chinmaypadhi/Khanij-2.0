using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Rule
{
    public interface IRuleMasterModel
    {
        MessageEF Add(RuleMaster objRulemaster);
        MessageEF Update(RuleMaster objRulemaster);
        List<RuleMaster> View(RuleMaster objRulemaster);
        MessageEF Delete(RuleMaster objRulemaster);
        RuleMaster Edit(RuleMaster objRulemaster);
    }
}
