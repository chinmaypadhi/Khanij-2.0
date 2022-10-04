using Dapper;

using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Company
{
    public class CompanyProvider: RepositoryBase, ICompanyProvider
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public CompanyProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        public MessageEF AddCompany(CompanyMaster objCompanyMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CompanyName", objCompanyMaster.CompanyName);
                p.Add("CreatedBy", objCompanyMaster.CreatedBy);
                p.Add("Status", objCompanyMaster.IsActive);
                p.Add("UserLoginId", objCompanyMaster.UserLoginId);
                p.Add("OPERATION", "CREATE");
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("COMPANY_MASTER_OPERATION", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");
                objMessage.Satus = response.ToString();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// View Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        public List<CompanyMaster> ViewCompany(CompanyMaster objCompanyMaster)
        {
            List<CompanyMaster> ListCompanyMaster = new List<CompanyMaster>();
            try
            {
                var paramList = new
                {
                    CompanyName = objCompanyMaster.CompanyName,
                    OPERATION = "GET",
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<CompanyMaster>("COMPANY_MASTER_OPERATION", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    ListCompanyMaster = result.ToList();
                }
                return ListCompanyMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListCompanyMaster = null;
            }
        }
        /// <summary>
        /// Edit Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        public CompanyMaster EditCompany(CompanyMaster objCompanyMaster)
        {
            CompanyMaster LobjCompanyMaster = new CompanyMaster();


            try
            {
                var paramList = new
                {
                    companyId = objCompanyMaster.CompanyId,
                    OPERATION = "EDIT",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<CompanyMaster>("COMPANY_MASTER_OPERATION", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjCompanyMaster = result.FirstOrDefault();
                }

                return LobjCompanyMaster;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjCompanyMaster = null;
            }
        }
        /// <summary>
        /// Delete Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        public MessageEF UpdateCompnay(CompanyMaster objCompanyMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CompanyName", objCompanyMaster.CompanyName);
                p.Add("companyId", objCompanyMaster.CompanyId);
                p.Add("CreatedBy", objCompanyMaster.CreatedBy);
                p.Add("Status", objCompanyMaster.IsActive);
                p.Add("UserLoginId", objCompanyMaster.UserLoginId);
                p.Add("OPERATION", "UPDATE");
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("COMPANY_MASTER_OPERATION", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");
                objMessage.Satus = response.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Update Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        public MessageEF DeleteCompany(CompanyMaster objCompanyMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("companyId", objCompanyMaster.CompanyId);
                p.Add("CreatedBy", objCompanyMaster.CreatedBy);
                p.Add("UserLoginId", objCompanyMaster.UserLoginId);
                p.Add("OPERATION", "DELETE");
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("COMPANY_MASTER_OPERATION", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");
                objMessage.Satus = response.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
    }
}
