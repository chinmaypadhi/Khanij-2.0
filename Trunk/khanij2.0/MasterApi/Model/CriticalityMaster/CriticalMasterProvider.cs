// ***********************************************************************
//  Class Name               : CriticalityMasterProvider
//  Description              : Add,View,Edit,Update,Delete Criticality details
//  Created By               : Akshaya Dalei
//  Created On               : 15 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;

namespace MasterApi.Model.CriticalityMasters
{
    public class CriticalMasterProvider : RepositoryBase, ICriticalityMasterProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public CriticalMasterProvider(IConnectionFactory connectionFactory):base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        #region Add
        public MessageEF AddCriticalityMaster(CriticalityMaster objCriticalityMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            { 
                var p = new DynamicParameters();
                p.Add("@CriticalityName", objCriticalityMaster.CriticalityName);
                p.Add("@Status", objCriticalityMaster.IsActive);
                p.Add("@UserId", objCriticalityMaster.CreatedBy);
                p.Add("@UserloginId", objCriticalityMaster.UserLoginID);
                p.Add("@chk", "Insert");
                //p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                int newID= Connection.QueryFirstOrDefault<int>("Helpdesk_CriticalityMasterOperation", p, commandType: CommandType.StoredProcedure);
               // int newID = p.Get<int>("Result");

 

                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion
        /// <summary>
        /// Delete Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        #region Delete
        public MessageEF DeleteCriticalityMaster(CriticalityMaster objCriticalityMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
            
                DynamicParameters _param = new DynamicParameters();
                _param.Add("@CriticalityMasterId", objCriticalityMaster.CriticalityMasterId);
                _param.Add("@Chk", "Delete"); 
                int result = Connection.QueryFirstOrDefault<int>("Helpdesk_CriticalityMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
              
                if (result.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion
        /// <summary>
        /// Edit Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        #region Edit
        public CriticalityMaster EditCriticalityMaster(CriticalityMaster objCriticalityMaster)
        {
            CriticalityMaster objCriticalityMasters = new CriticalityMaster();


            try
            {
                //var paramList = new
                //{
                //    CriticalityMasterId = objCriticalityMaster.CriticalityMasterId,
                //    Chk = "Update",

                //};
                DynamicParameters param = new DynamicParameters();
                param.Add("@Chk", "Getdata");
                param.Add("@CriticalityMasterId", objCriticalityMaster.CriticalityMasterId);

                var result = Connection.Query<CriticalityMaster>("Helpdesk_CriticalityMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objCriticalityMasters = result.FirstOrDefault();
                }

                return objCriticalityMasters;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objCriticalityMasters = null;
            }
        }
        #endregion
        /// <summary>
        /// Udpate Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        #region Update
        public MessageEF UpdateCriticalityMaster(CriticalityMaster objCriticalityMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                 

                var p = new DynamicParameters();
                p.Add("@CriticalityMasterId", objCriticalityMaster.CriticalityMasterId);
                p.Add("@CriticalityName", objCriticalityMaster.CriticalityName);
                p.Add("@Status", objCriticalityMaster.IsActive);
                p.Add("@UserLoginId", objCriticalityMaster.UserLoginID);
                p.Add("@Chk", "Update");
                //p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                int newID= Connection.QueryFirstOrDefault<int>("Helpdesk_CriticalityMasterOperation", p, commandType: CommandType.StoredProcedure);
               // int newID = p.Get<int>("Result"); 

                string response = newID.ToString();

                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;

        }

        #endregion
        /// <summary>
        /// View Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        #region View 
        public List<CriticalityMaster> ViewCriticalityMaster(CriticalityMaster criticalityMaster)
        {
            List<CriticalityMaster> listCriticalityMaster = new List<CriticalityMaster>();


            try
            {
                
                DynamicParameters param = new DynamicParameters();
                param.Add("@chk", "Getdata");

                var result = Connection.Query<CriticalityMaster>("Helpdesk_CriticalityMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listCriticalityMaster = result.ToList();
                }

                return listCriticalityMaster;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listCriticalityMaster = null;
            }

        }
        #endregion
    }
}
