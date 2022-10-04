using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.LeaveManagement.Models.WorkFlowNotification
{
    public interface INotification
    {
        public void SendNotification(string contactId,string msg);
    }
}
