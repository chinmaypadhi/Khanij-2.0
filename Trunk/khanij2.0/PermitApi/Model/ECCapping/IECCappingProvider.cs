using PermitApi.Repository;
using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApi.Model.ECCapping
{
    public interface IECCappingProvider : IDisposable, IRepository
    {
        Task<ECCappingEF> GetAllStocks(ECCappingEF objUser);

        Task<ECCappingEF> GetGradeWiseOpeningStockById(ECCappingEF objUser);
        Task<ECCappingEF> GetECCapingFinancialYears();
        
             Task<List<ECCappingEF>> GetAllApprovalData(ECCappingEF objUser);
        Task<List<ECCappingEF>>GetAllCappingData(ECCappingEF objUser);

        Task<List<ECCappingEF>> GetAllPreviousYearECDetails(ECCappingEF objUser);
        

        Task<MessageEF> SaveApprovalData(ECCappingEF objUser);
        Task<MessageEF> AddAllECcappingStocks(ECCappingEF objUser);


        Task<MessageEF> UpdateAllECcappingStocks(ECCappingEF objUser);
        
    }
}
