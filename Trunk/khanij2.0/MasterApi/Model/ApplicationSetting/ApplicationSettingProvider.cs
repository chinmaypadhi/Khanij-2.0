// ***********************************************************************
//  Class Name               : ApplicationSettingProvider
//  Description              : Add,View,Edit,Update,Delete Application Setting details
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Jan 2021
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MasterApi.Model.ApplicationSetting
{
    public class ApplicationSettingProvider : RepositoryBase, IApplicationSettingProvider
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public ApplicationSettingProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// View Setting details
        /// </summary>
        /// <param name="objApplicationSettingmaster"></param>
        /// <returns></returns>
        public List<ApplicationSettingmaster> ViewApplicationSettingmaster(ApplicationSettingmaster objApplicationSettingmaster)
        {
            List<ApplicationSettingmaster> ListApplicationSettingmaster = new List<ApplicationSettingmaster>();
            try
            {
                var paramList = new
                {
                    SP_MODE = "GET_DATA"
                };
                var result = Connection.Query<ApplicationSettingmaster>("USP_EXPIRY_DATE_ALERT", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListApplicationSettingmaster = result.ToList();
                }

                return ListApplicationSettingmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListApplicationSettingmaster = null;
            }



        }
        /// <summary>
        /// Edit Application Setting details
        /// </summary>
        /// <param name="objApplicationSettingmaster"></param>
        /// <returns></returns>
        public ApplicationSettingmaster EditApplicationSettingmaster(ApplicationSettingmaster objApplicationSettingmaster)
        {
            ApplicationSettingmaster LobjApplicationSettingmaster = new ApplicationSettingmaster();
            try
            {
                var paramList = new
                {
                    SP_MODE = "GET_DATA"

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<ApplicationSettingmaster>("USP_EXPIRY_DATE_ALERT", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjApplicationSettingmaster = result.FirstOrDefault();
                }

                return LobjApplicationSettingmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjApplicationSettingmaster = null;
            }
        }
        /// <summary>
        /// Update Application Setting details
        /// </summary>
        /// <param name="objApplicationSettingmaster"></param>
        /// <returns></returns>
        public MessageEF UpdateApplicationSettingmaster(ApplicationSettingmaster objApplicationSettingmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("USER_ID", objApplicationSettingmaster.UserId);
                p.Add("EXPIRY_DATE_ALERT_COUNT", objApplicationSettingmaster.EXPIRY_DATE_ALERT_COUNT);
                p.Add("TP_OFFLINE_NET_WEIGHT", objApplicationSettingmaster.TP_OFFLINE_NET_WEIGHT);
                p.Add("FORWARDINGNOTE_GRACE_WEIGHT", objApplicationSettingmaster.FORWARDINGNOTE_GRACE_WEIGHT);
                p.Add("TIMELINE_OF_REPLY_OF_NOTICE", objApplicationSettingmaster.TIMELINE_OF_REPLY_OF_NOTICE);
                p.Add("ValidityExpiredIntimation", objApplicationSettingmaster.EXPIRY_DATE_INTIMATION);
                p.Add("SMS_SENT", objApplicationSettingmaster.SMS_SENT);
                p.Add("EMAIL_SENT", objApplicationSettingmaster.EMAIL_SENT);
                p.Add("SP_MODE", "SAVE_DATA");
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_EXPIRY_DATE_ALERT", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Output");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response == "2")
                {
                    objMessage.Satus = "3";

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
    }
}
