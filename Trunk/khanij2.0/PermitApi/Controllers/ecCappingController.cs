using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermitApi.Model.ECCapping;
using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApi.Controllers
{

    [Route("api/{controller}/{action}")]
    [ApiController]
    //[Authorize]
    public class ecCappingController : Controller
    {
        public IECCappingProvider _objICappingProvider;
        public ecCappingController(IECCappingProvider objICappingProvider)
        {
            _objICappingProvider = objICappingProvider;
        }


        [HttpPost]
        public async Task<ECCappingEF> GetECCapingFinancialYears()
        {
            return await _objICappingProvider.GetECCapingFinancialYears();
        }


        [HttpPost]
        public async Task<ECCappingEF> GetECCapingStocks(ECCappingEF objmodel)
        {
            return await _objICappingProvider.GetAllStocks(objmodel);
        }


        [HttpPost]
        public async Task<MessageEF> AddAllECcappingStocks(ECCappingEF objmodel)
        {
            return await _objICappingProvider.AddAllECcappingStocks(objmodel);
        }



        [HttpPost]
        public async Task<MessageEF> UpdateAllECcappingStocks(ECCappingEF objmodel)
        {
            return await _objICappingProvider.AddAllECcappingStocks(objmodel);
        }



        [HttpPost]
        public async Task<List<ECCappingEF>>GetAllCappingData(ECCappingEF objmodel)
        {
           return await _objICappingProvider.GetAllCappingData(objmodel);
        }



        [HttpPost]
        public async Task<ECCappingEF> GetGradeWiseOpeningStocks(ECCappingEF objmodel)
        {
            return await _objICappingProvider.GetGradeWiseOpeningStockById(objmodel);
        }

        [HttpPost]
        public async Task<List<ECCappingEF>> GetAllApprovalData(ECCappingEF objmodel)
        {
            return await _objICappingProvider.GetAllApprovalData(objmodel);
        }



        [HttpPost]
        public async Task<MessageEF> SaveApprovalData(ECCappingEF objmodel)
        {
            return await _objICappingProvider.SaveApprovalData(objmodel);
        }


        [HttpPost]
        public async Task<List<ECCappingEF>> GetAllPreviousYearECDetails(ECCappingEF objmodel)
        {
            return await _objICappingProvider.GetAllPreviousYearECDetails(objmodel);
        }



        

    }
}
