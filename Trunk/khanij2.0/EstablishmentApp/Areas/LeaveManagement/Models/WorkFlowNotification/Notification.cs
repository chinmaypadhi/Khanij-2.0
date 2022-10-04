using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.LeaveManagement.Models.WorkFlowNotification
{
    
    public class Notification
    {
       private INotification _notification;

        public Notification(INotification notification)
        {
            _notification = notification;
        }
        public void SendNotification(string contactId, string msg)
        {
            _notification.SendNotification( contactId,  msg);
        }
    }
}
