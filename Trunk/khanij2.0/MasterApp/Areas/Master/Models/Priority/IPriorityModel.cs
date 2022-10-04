using System.Collections.Generic;
using MasterEF;

namespace MasterApp.Areas.Master.Models.Priority
{
    public interface IPriorityModel
    {
        MessageEF Add(Prioritymaster objPrioritymaster);
        MessageEF Update(Prioritymaster objPrioritymaster);
        List<Prioritymaster> View(Prioritymaster objPrioritymaster);
        MessageEF Delete(Prioritymaster objPrioritymaster);
        Prioritymaster Edit(Prioritymaster objPrioritymaster);
    }
}
