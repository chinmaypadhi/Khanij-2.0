using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;

namespace PermitApp.Areas.Permit.Models.CoalEPermit
{
   public interface ICoalEPermitModel
    {
        ePermitResult GetCoalMineralNatureList(ePermitModel objUser);
        ePermitResult GetTypeOfCoal(ePermitModel objUser);
        ePermitResult CheckTotalPermitByUser(ePermitModel objUser);
        ePermitResult GetPermitDetailsByUserID(ePermitModel objUser);
        ePermitResult GetPermitOperation(ePermitModel objUser);
        ePermitResult GetPermitOperationByBulkId(ePermitModel objUser);
        ePermitResult GetMineralGradeListOnNatureList(ePermitModel objUser);
        MessageEF AddBulkPermit(ePermitModel objUser);
        ePermitResult GetePermitPayment(ePermitModel objUser);
        List<ListCoalPermit> GetSavedCoalPermit(ePermitModel objUser);
        MessageEF DeleteCoalData(ePermitModel objUser);
        ePermitResult GetPermitViewWithoutDSC(ePermitModel objUser);
        MessageEF CheckOutPayment(ePermitModel objUser);
        ePermitResult GetCheckOutPermitPayment(ePermitModel objUser);
        List<ePaymentData> GetDetailsOfConfig(ePermitModel objUser);
        MessageEF UpgradeMineral(ePermitModel objUser);
        ePermitModel GetDetailsOfUpgrade(ePermitModel objUser);
        ePermitResult GetMinesDetails(ePermitModel objUser);
        ePermitModel GetComapny(ePermitModel objUser);
        ePermitModel GetCoalRoyalty(ePermitModel objUser);
        List<ePaymentData> GetPaymentStatus(ePermitModel objUser);
    }
}
