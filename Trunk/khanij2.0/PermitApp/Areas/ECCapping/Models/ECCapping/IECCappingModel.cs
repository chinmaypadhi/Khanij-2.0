using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApp.Areas.ECCapping.Models.ECCapping
{
    public interface IECCappingModel
    {
        ECCappingEF GetAllGradeWiseOpeningStock(ECCappingEF objUser);

        ECCappingEF GetYear(ECCappingEF objUser);
       // ECCappingEF GetAllCappingData(ECCappingEF objUser);
        List<ECCappingEF> GetAllCappingData(ECCappingEF objUser);

        List<ECCappingEF> GetAllApprovalCappingData(ECCappingEF objUser);
        MessageEF AddEccapping(ECCappingEF objUser );
        MessageEF UpdateEccapping(ECCappingEF objUser);

        MessageEF SubmitApproval(ECCappingEF objUser);

        ECCappingEF GetGradeOpeningStockById(ECCappingEF objUser);

        List<ECCappingEF> GetAllPreviousDetails(ECCappingEF objUser);

    }
}
