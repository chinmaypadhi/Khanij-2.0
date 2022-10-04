
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MasterApp.Areas.Master.Models.StateMaster
{
     public interface IStateMasterModel
    {
        MessageEF Add(Statemaster objStatemaster);
        MessageEF Update(Statemaster objStatemaster);
        List<Statemaster> View(Statemaster objStatemaster);
        MessageEF Delete(Statemaster objStatemaster);
        Statemaster Edit(Statemaster objStatemaster);
    }
}
