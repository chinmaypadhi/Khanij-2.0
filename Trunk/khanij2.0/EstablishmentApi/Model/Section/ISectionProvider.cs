using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EstablishmentApi.Repository;
using EstablishmentEf;

namespace EstablishmentApi.Model.Section
{
    public interface ISectionProvider : IDisposable, IRepository
    {
        MessageEF AddUpdateDelete(SectionEF Section);
        List<SectionEF> GetOfficeLevel(SectionEF Section);
        SectionEF EditOfficeLevel(SectionEF Section);

        #region SectionOfficer
        Task<List<SectionDropDown>> BindSection(SectionDropDown objLeaveDropDown);
        Task<List<SectionDropDown>> BindSectionOfficer(SectionDropDown objLeaveDropDown);
        Task<List<SectionDropDown>> BindSectionOfficer2(SectionDropDown objLeaveDropDown);

        MessageEF AddSectionOfficerTagging(SectionOfficerTaggingEF objSection);
        Task<List< SectionOfficerTaggingQueryEF>> ViewSectionOfficerTagging(SectionOfficerTaggingQueryEF objSectionOfficer);
        Task<SectionOfficerTaggingEF> ViewSectionOfficerTaggingDetails(SectionOfficerTaggingEF objSectionOfficer);
        MessageEF DeleteSectionOfficerTagging(SectionOfficerTaggingEF objSection);
        #endregion
    }
}
