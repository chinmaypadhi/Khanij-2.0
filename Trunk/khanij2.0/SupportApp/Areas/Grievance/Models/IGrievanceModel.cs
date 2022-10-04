using SupportEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportApp.Areas.Grievance.Models
{
   public interface IGrievanceModel
    {
        FillDDl GetDist(PublicGrievanceModel ObjEU);
        FillDDl GetCtype(PublicGrievanceModel ObjEU);

        PublicGrievanceModel GetOTPModel(PublicGrievanceModel ObjEU);
        MessageEF VerifyOTP(PublicGrievanceModel ObjEU);
        MessageEF AddPublicGrievance(PublicGrievanceModel ObjEU);
        FillDDl GetState(PublicGrievanceModel ObjEU);
        PublicGrievanceModel GetUDetails(PublicGrievanceModel ObjEU);
        MessageEF AddGrievance(PublicGrievanceModel ObjEU);
        List<PublicGrievanceModel> GetLst(PublicGrievanceModel ObjEU);
        PublicGrievanceModel GetSingleData(PublicGrievanceModel ObjEU);
        FillDDl GetUtype(PublicGrievanceModel ObjEU);
        FillDDl GetUByType(PublicGrievanceModel ObjEU);
        FillDDl CComplaint(PublicGrievanceModel ObjEU);
        MessageEF FFOrwordDD(PublicGrievanceModel ObjEU);
        List<PublicGrievanceModel> GetGCLst(PublicGrievanceModel ObjEU);
        MessageEF AddDGMGrievance(PublicGrievanceModel ObjEU);
        List<PublicGrievanceModel> GetLstMI(PublicGrievanceModel ObjEU);
        MessageEF MIFFOrwordDD(ForwardMItoDD ObjEU);
        PublicGrievanceModel CloseGR(CloseComplain ObjEU);
        MessageEF VerifyMobile(PublicGrievanceModel GrievanceModel);
        MessageEF GetOTP(PublicGrievanceModel GrievanceModel);
    }
}
