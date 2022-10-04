using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.KhanijSecurity
{
    public class KhanijIDataProtection
    {
        private readonly IDataProtector protector;
        public KhanijIDataProtection(IDataProtectionProvider dataProtectionProvider, UniqueCode uniqueCode)
        {
            protector = dataProtectionProvider.CreateProtector(uniqueCode.BankIdRouteValue);
        }
        public  string Decode(string data)
        {
            return protector.Protect(data);
        }
        public string Encode(string data)
        {
            return protector.Unprotect(data);
        }
    }

    public class UniqueCode
    {
        public readonly string BankIdRouteValue = "KhanijIdRouteValue";
    }
}
