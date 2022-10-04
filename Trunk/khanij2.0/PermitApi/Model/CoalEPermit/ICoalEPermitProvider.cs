using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;
using PermitApi.Repository;

namespace PermitApi.Model.CoalEPermit
{
   public interface ICoalEPermitProvider : IDisposable, IRepository
    {
        Task<ePermitResult> GetTypeOfCoal(ePermitModel objUser);
        Task<ePermitResult> CheckTotalPermitByUser(ePermitModel objUser);
        Task<ePermitResult> GetPermitDetailsByUserID(ePermitModel objUser);
        Task<ePermitResult> GetPermitOperation(ePermitModel objUser);
        Task<ePermitResult> GetPermitOperationByBulkId(ePermitModel objUser);
        Task<ePermitResult> GetePermitPayment(ePermitModel objUser);
       Task< List<ListCoalPermit>> GetSavedCoalPermit(ePermitModel objUser);
        Task<MessageEF> DeleteCoalData(ePermitModel objUser);
        Task<ePermitResult> GetPermitViewWithoutDSC(ePermitModel objUser);
        Task<MessageEF> CheckOutPayment(ePermitModel objUser);
        Task<ePermitResult> GetCheckOutPermitPayment(ePermitModel objUser);
        Task<List<ePaymentData>> GetDetailsOfConfig(ePermitModel objUser);
        Task<MessageEF> UpgradeMineral(ePermitModel objUser);
        Task<ePermitModel> GetDetailsOfUpgrade(ePermitModel objUser);
        Task<ePermitResult> GetMinesDetails(ePermitModel objUser);
        Task<ePermitModel> GetComapny(ePermitModel objUser);
        Task<ePermitModel> GetCoalRoyalty(ePermitModel objUser);
        Task<List<ePaymentData>> GetPaymentStatus(ePermitModel objUser);
    }
}
