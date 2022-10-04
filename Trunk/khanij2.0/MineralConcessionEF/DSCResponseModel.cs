using System;
using System.Collections.Generic;
using System.Text;

namespace MineralConcessionEF
{
    public class DSCResponseModel
    {
        public int DSCID { get; set; }

        public string Response { get; set; }
        public string DSCCommonName { get; set; }
        public string DSCSerialNo { get; set; }
        public string DSCIssuerCommonName { get; set; }
        public string DSCIssuedDate { get; set; }
        public string DSCExpiredDate { get; set; }
        public string DSCEmail { get; set; }
        public string DSCCountry { get; set; }
        public string DSCCertificateClass { get; set; }
        public string DSCFor { get; set; }

        public int DSCUsedBy { get; set; }
        public int DSCForId { get; set; }
        public int Userid { get; set; }

    }
    public class DSCResponse
    {
        string CommonName = string.Empty;
        string SerialNo = string.Empty;
        string IssuerCommonName = string.Empty;
        string IssuedDate = string.Empty;
        string ExpiryDate = string.Empty;
        string Email = string.Empty;
        string Country = string.Empty;
        string CertificateClass = string.Empty;
        string Signature = string.Empty;
        public DSCResponse()
        {

        }
    }
    }
