using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationApp.Areas.Contractor.Models.ContractorBuilders
{
    public interface IContractorBuilder
    {
        MessageEF AddContractorBuilder(ContractorBuilderModel contractorBuilderModel);
        MessageEF UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel);
        ContractorBuilderModel GetContractorBuilderUserDetailsByUserId(ContractorBuilderModel contractorBuilderModel);
    }
}
