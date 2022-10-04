using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.EmpPro.Models.Section
{
    public interface ISectionModel
    {
        MessageEF AddUpdateDelete(SectionEF Section);
        List<SectionEF> GetOfficeLevel(SectionEF Section);
        SectionEF EditOfficeLevel(SectionEF Section);

        #region section officer tagging
        public Task<List<SectionDropDown>> BindSection(SectionDropDown objLeaveDropDown);
        public Task<List<SectionDropDown>> BindSectionOfficer(SectionDropDown objLeaveDropDown);
        public Task<List<SectionDropDown>> BindSectionOfficer2(SectionDropDown objLeaveDropDown);

        public MessageEF AddSectionOfficerTagging(SectionOfficerTaggingEF objSection);

        public Task<List<SectionOfficerTaggingQueryEF>> ViewSectionOfficerTagging(SectionOfficerTaggingQueryEF objSectionOfficer);
        public Task<SectionOfficerTaggingEF> ViewSectionOfficerTaggingDetails(SectionOfficerTaggingEF objSectionOfficer);

        public MessageEF DeleteSectionOfficerTagging(SectionOfficerTaggingEF objSection);
        #endregion
    }
}
