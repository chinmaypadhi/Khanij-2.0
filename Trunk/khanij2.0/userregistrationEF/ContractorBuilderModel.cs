using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class ContractorBuilderModel
    {
        public int? ContractorBuilderId { get; set; }
        public string RegistrationType { get; set; }
        public string ContractorBuilderName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string ContractorBuilderAddress { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string PINCode { get; set; }
        public string IDProofType { get; set; }
        public string IDProofNumber { get; set; }
        public IFormFile IDProof { get; set; }
        public string UploadIDProof { get; set; }
        public string UploadIDProofPath { get; set; }
        public string RERARegistrationNo { get; set; }
        public IFormFile RERARegistration { get; set; }
        public string UploadRERARegistration { get; set; }
        public string UploadRERARegistrationPath { get; set; }
        public string RegistrationNo { get; set; }
        public bool? ActiveStatus { get; set; }
        public string Status { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
