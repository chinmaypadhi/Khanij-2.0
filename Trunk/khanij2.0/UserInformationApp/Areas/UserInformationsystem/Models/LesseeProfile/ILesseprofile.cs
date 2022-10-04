using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UserInformationEF;

namespace UserInformationApp.Models.LesseeProfile
{
    public interface ILesseprofile 
    {
        List<LeaseApplicationModel> GetCompMasterData(LeaseApplicationModel objRaiseTicket);
        MessageEF Add(LeaseApplicationModel model);
        LeaseApplicationModel GetlesseEditdata(LeaseApplicationModel objRaiseTicket);
    }
}
