using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.ContractorBuilder
{
    public interface IContractorBuilderProvider : IDisposable, IRepository
    {
        Task<MessageEF> AddContractorBuilder(ContractorBuilderModel contractorBuilderModel);
        Task<MessageEF> EditContractorBuilder(ContractorBuilderModel contractorBuilderModel);
        Task<ContractorBuilderModel> GetContractorBuilderUserDetailsByUserId(ContractorBuilderModel contractorBuilderModel);
    }
}
