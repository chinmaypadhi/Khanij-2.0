
using HomeEF;
using HomeLApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLApi.Model.Login
{
    public interface ILoginProvider:IDisposable, IRepository
    {
        UserLoginSession UserLogin(LoginEF obj);
    }
}
