
using Dapper;

using HomeEF;
using HomeLApi.Factory;
using HomeLApi.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace HomeLApi.Model.Login
{
    public class LoginProvider: RepositoryBase,ILoginProvider
    {

        public LoginProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public UserLoginSession UserLogin(LoginEF model)
        {
           
            UserLoginSession objUserLoginSession = new UserLoginSession();
            try
            {
               

                var paramList = new
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    LoginUserType = model.UserType,
                    Check = "1",
                    RemoteIp = model.Remoteid,
                    LocalIp = model.Localip,
                    UserAgent = model.Browserinfo
                };
                    DynamicParameters param = new DynamicParameters();
                
                      var result = Connection.Query<UserLoginSession>("uspValidateUser", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objUserLoginSession = result.FirstOrDefault();
                }
                
                return objUserLoginSession;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                
                objUserLoginSession = null;
            }



        }
    }
}
