using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstablishmentApi.Model.Section;
using EstablishmentEf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

namespace EstablishmentApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class SectionController : ControllerBase
    {
        public ISectionProvider _objISectionProvider;
        public SectionController(ISectionProvider objIOfficeLevelProvider)
        {
            _objISectionProvider = objIOfficeLevelProvider;
        }
        [HttpPost]
        public MessageEF AddUpdateDelete(SectionEF Section)
        {
            return _objISectionProvider.AddUpdateDelete(Section);
        }
        [HttpPost]
        public List<SectionEF> GetOfficeLevel(SectionEF Section)
        {
            return _objISectionProvider.GetOfficeLevel(Section);
        }
        [HttpPost]
        public SectionEF EditOfficeLevel(SectionEF Section)
        {
            return _objISectionProvider.EditOfficeLevel(Section);
        }

        #region section officer tagging
        [HttpPost]
        public async Task<List<SectionDropDown>> BindSection(SectionDropDown objLeaveDropDown)
        {
            return await _objISectionProvider.BindSection(objLeaveDropDown);
        }
        [HttpPost]
        public async Task<List<SectionDropDown>> BindSectionOfficer(SectionDropDown objLeaveDropDown)
        {
            return await _objISectionProvider.BindSectionOfficer(objLeaveDropDown);
        }
        [HttpPost]
        public async Task<List<SectionDropDown>> BindSectionOfficer2(SectionDropDown objLeaveDropDown)
        {
            return await _objISectionProvider.BindSectionOfficer2(objLeaveDropDown);
        }
        [HttpPost]
        public MessageEF AddSectionOfficerTagging(SectionOfficerTaggingEF objSection)
        {
            return _objISectionProvider.AddSectionOfficerTagging(objSection);
        }

        [HttpPost]
        public async Task<List<SectionOfficerTaggingQueryEF>> ViewSectionOfficerTagging(SectionOfficerTaggingQueryEF objSectionOfficer)
        {
            return await _objISectionProvider.ViewSectionOfficerTagging(objSectionOfficer);
        }
        [HttpPost]
        public async Task<SectionOfficerTaggingEF> ViewSectionOfficerTaggingDetails(SectionOfficerTaggingEF objSectionOfficer)
        {
            return await _objISectionProvider.ViewSectionOfficerTaggingDetails(objSectionOfficer);
        }
        [HttpPost]

        public MessageEF DeleteSectionOfficerTagging(SectionOfficerTaggingEF objSection)
        {
            return _objISectionProvider.DeleteSectionOfficerTagging(objSection);
        }
        #endregion
    }
}