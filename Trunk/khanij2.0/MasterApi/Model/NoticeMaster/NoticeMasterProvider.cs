// ***********************************************************************
//  Class Name               : NoticeMasterProvider
//  Description              : Add,View,Edit,Update,Delete Notice Master details
//  Created By               : Debaraj Swain
//  Created On               : 08 Jan 2021
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.NoticeMaster
{
    public class NoticeMasterProvider : RepositoryBase, INoticeMasterProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public NoticeMasterProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        public MessageEF AddNoticeMaster(Noticemaster objNoticemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                //    object[] objArray = new object[] {                      
                //            "StateName"  ,objStatemaster.StateName,
                //            "CreatedBy"    ,objStatemaster.CreatedBy,
                //            "IsActive"     ,objStatemaster.IsActive,
                //            "UserLoginId"  ,objStatemaster.UserLoginID,
                //            "Chk",1
                //};
                //    DynamicParameters _param = new DynamicParameters();
                //    _param = objArray.ToDynamicParameters("Result");


                var p = new DynamicParameters();
                p.Add("NoticeText", objNoticemaster.NoticeText);
                p.Add("CreatedBy", objNoticemaster.CreatedOn);
                p.Add("IsActive", objNoticemaster.IsActive);
               // p.Add("UserLoginId", objStatemaster.UserLoginID);
                p.Add("Chk", "1");
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("Usp_NoticeMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");


                //var result = Connection.Query<string>("Usp_StateMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
                //    string response = _param.Get<string>("Result");

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
        /// <summary>
        /// View Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        public List<Noticemaster> ViewNoticeMaster(Noticemaster objNoticemaster)
        {

            List<Noticemaster> ListNoticemaster = new List<Noticemaster>();


            try
            {
                var paramList = new
                {
                    NoticeText = objNoticemaster.NoticeText,
                    Chk = "2",

                };


                var result = Connection.Query<Noticemaster>("Usp_NoticeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListNoticemaster = result.ToList();
                }

                return ListNoticemaster;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListNoticemaster = null;
            }



        }
        /// <summary>
        /// Edit Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        public Noticemaster EditNoticemaster(Noticemaster objNoticemasterr)
        {
            Noticemaster LobjMNoticemaster = new Noticemaster();


            try
            {
                var paramList = new
                {
                    NoticeID = objNoticemasterr.NoticeID,
                    Chk = "3",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<Noticemaster>("Usp_NoticeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjMNoticemaster = result.FirstOrDefault();
                }

                return LobjMNoticemaster;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjMNoticemaster = null;
            }
        }
        /// <summary>
        /// Delete Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        public MessageEF DeleteNoticemaster(Noticemaster objNoticemasterr)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "NoticeID",objNoticemasterr.NoticeID,
                        "Chk",5
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("Result");
                var result = Connection.Query<string>("Usp_NoticeMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("Result");
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
        /// <summary>
        /// Update Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        public MessageEF UpdateNoticemaster(Noticemaster objNoticemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                //    object[] objArray = new object[] {
                //            "StateName",objStatemaster.StateName,
                //            "StateID",objStatemaster.StateID,
                //            "ModifiedBy"   ,objStatemaster.CreatedBy,
                //            "UserLoginId"  ,objStatemaster.UserLoginID,
                //            "Chk",6
                //};
                //    DynamicParameters _param = new DynamicParameters();
                //    _param = objArray.ToDynamicParameters("Result");

                var p = new DynamicParameters();
                p.Add("NoticeText", objNoticemaster.NoticeText);
                p.Add("NoticeID", objNoticemaster.NoticeID);
                p.Add("ModifiedBy", objNoticemaster.ModifiedBy);
               // p.Add("UserLoginId", objStatemaster.UserLoginID);
                p.Add("Chk", "6");
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("Usp_NoticeMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");

                //var result = Connection.Query<string>("Usp_StateMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
                //string response = _param.Get<string>("Result");

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
    }
}
