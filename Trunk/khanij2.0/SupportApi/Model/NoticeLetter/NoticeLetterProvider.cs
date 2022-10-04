using Dapper;

using SupportApi.Factory;
using SupportApi.Repository;
using SupportEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SupportApi.Model.NoticeLetter
{
    public class NoticeLetterProvider : RepositoryBase, INoticeLetterProvider
    {
        public NoticeLetterProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF SendNoticeLetter(NoticeLetterEF objNotice)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                //DataTable dt = new DataTable("MultipleFileUpload");
                //dt =(DataTable) objNotice.MultipleFile;
                //  p.Add("UserID", objNotice.);
                p.Add("UserID", objNotice.User_ID);
                p.Add("NoticeSubject", objNotice.NoticeSubject);
                p.Add("NoticeDescription", objNotice.NoticeDescription);
                p.Add("UploadedFilesCount", objNotice.FileCount);
                p.Add("UsersCount", Convert.ToInt32(objNotice.UsersCount));
                //p.Add("TermsAndConditionIds", objNotice.LeaseTypeCode);
                p.Add("CreatedBy", objNotice.CreatedBy);
                p.Add("IsDraft", objNotice.IsDraft);
                p.Add("UserLoginId", objNotice.UserLoginId);
                p.Add("Chk", 1);
                if (objNotice.MultipleFile != null)
                {
                    DataTable _dt = new DataTable("MultipleFileUpload");
                    _dt = (DataTable)objNotice.MultipleFile;
                    if (_dt.Rows.Count > 0)
                    {
                        p.Add("MultipleFile", _dt, DbType.Object);
                    }
                }
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspUserInformationNoticeOperation", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        //public List<NoticeLetterEF> ViewUserType(NoticeLetterEF objNoticeType)
        //{
        //    List<NoticeLetterEF> ListuserType = new List<NoticeLetterEF>();
        //    try
        //    {
        //        var paramList = new
        //        {
        //            UserId = objNoticeType.UserID,
                    

        //        };
        //        DynamicParameters param = new DynamicParameters();

        //        var result = Connection.Query<NoticeLetterEF>("uspGetRoleTypeMasterForNotice/Letter", paramList, commandType: System.Data.CommandType.StoredProcedure);

        //        if (result.Count() > 0)
        //        {

        //            ListuserType = result.ToList();
        //        }

        //        return ListuserType;



        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {

        //        ListuserType = null;
        //    }



        //}
        public List<NoticeLetterEF> GetSubmittedNotice(NoticeLetterEF objNotice)
        {
            List<NoticeLetterEF> ListuserType = new List<NoticeLetterEF>();
            try
            {
                var paramList = new
                {
                    UserId = objNotice.UserID,
                    NoticeID= objNotice.NoticeID,
                    chk=3
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<NoticeLetterEF>("uspUserInformationNoticeOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    ListuserType = result.ToList();
                }
                return ListuserType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListuserType = null;
            }
        }
        public List<NoticeLetterEF> GetSendNotice(NoticeLetterEF objNotice)
        {
            List<NoticeLetterEF> ListSendNotice = new List<NoticeLetterEF>();
            try
            {
                var paramList = new
                {
                    UserId = objNotice.UserID,
                    NoticeID = objNotice.NoticeID,
                    chk = 5
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<NoticeLetterEF>("uspUserInformationNoticeOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListSendNotice = result.ToList();
                }
                return ListSendNotice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListSendNotice = null;
            }
        }
        public List<NoticeLetterEF> GetUploadedFilesByNoticeID(NoticeLetterEF objNotice)
        {
            List<NoticeLetterEF> ListSendNotice = new List<NoticeLetterEF>();
            try
            {
                var paramList = new
                {
                    UserId = objNotice.UserID,
                    NoticeID = objNotice.NoticeID,
                    chk = 4
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<NoticeLetterEF>("uspUserInformationNoticeOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListSendNotice = result.ToList();
                }
                return ListSendNotice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListSendNotice = null;
            }
        }
        public async Task<Result<List<NoticeLetterEF>>> ManageUserTypeView(NoticeLetterEF objNotice)
        {            
           // UserTypeResult ObjResult = new UserTypeResult();
            //  SqlHelperClass gObjSqlHelper = new SqlHelperClass();
            DataTable ObjDt = new DataTable();
            List<NoticeLetterEF> ObjUserTypeList = new List<NoticeLetterEF>();
            NoticeLetterEF noticeLetterEF = new NoticeLetterEF();
           Result<List<NoticeLetterEF>> r = new Result<List<NoticeLetterEF>>();

            try
            {
                var paramList = new
                {
                    UserId = objNotice.UserID,
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<NoticeLetterEF>("[uspGetRoleTypeMasterForNotice/Letter]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    foreach (NoticeLetterEF dr in result)
                    {
                        ObjUserTypeList.Add(new NoticeLetterEF()
                        {
                            RoleTypeId = Convert.ToInt32(dr.RoleTypeId.ToString()),
                            RoleTypeName = dr.RoleTypeName.ToString(),                          
                        }); 
                        

                    }

                    //r1 = ObjUserTypeList;
                   // ObjResult.UserTypeLst = ObjUserTypeList;
                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();
                    r.Data = ObjUserTypeList; 
                    r.Status = true;
                    r.Message = new List<string>() { "Successfull!" };
                }
                else
                {
                    r.Data = null;
                    r.Status = false;
                    r.Message = new List<string>() { "Failed!" };

                }
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            return r;
        }
        public async Task<Result<List<NoticeLetterEF>>> GetUserListByRoleType(NoticeLetterEF objNotice)
        {
            UserTypeResult ObjResult = new UserTypeResult();
            //  SqlHelperClass gObjSqlHelper = new SqlHelperClass();
            DataTable ObjDt = new DataTable();
            List<NoticeLetterEF> ObjUserTypeList = new List<NoticeLetterEF>();
            NoticeLetterEF noticeLetterEF = new NoticeLetterEF();
            Result<List<NoticeLetterEF>> r = new Result<List<NoticeLetterEF>>();
            try
            {
                var paramList = new
                {
                    UserId = objNotice.UserID,
                    RoleTypeId=objNotice.RoleTypeId
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<NoticeLetterEF>("[uspGetUserListByRoleType]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    foreach (NoticeLetterEF dr in result)
                    {
                        ObjUserTypeList.Add(new NoticeLetterEF()
                        {
                            UserID = Convert.ToInt32(dr.UserID.ToString()),
                            ApplicantName = dr.ApplicantName.ToString(),
                            MobileNo = dr.MobileNo,
                            EMailId=dr.EMailId
                        });
                    }
                    ObjResult.UserTypeLst = ObjUserTypeList;
                    r.Data = ObjUserTypeList;
                    //ObjResult.UserTypeLst = result.ToList();
                    // ListLeaseType = result.ToList();                   
                    r.Status = true;
                    r.Message = new List<string>() { "Successfull!" };
                }
                else
                {
                    r.Data = null;
                    r.Status = false;
                    r.Message = new List<string>() { "Failed!" };

                }
            }
            catch (Exception ex)
            {
                r.Status = false;
                r.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return r;
            }
            return r;
        }
        public ReplyNotice Reply_GetUploadedFiles(NoticeLetterEF objNotice)
        {
            UserTypeResult ObjResult = new UserTypeResult();
            //  SqlHelperClass gObjSqlHelper = new SqlHelperClass();
            DataTable ObjDt = new DataTable();
            List<NoticeLetterEF> ObjUserTypeList = new List<NoticeLetterEF>();
            NoticeLetterEF noticeLetterEF = new NoticeLetterEF();
            ReplyNotice replyNotice = new ReplyNotice();
            try
            {
                var paramList = new
                {
                    UserId = objNotice.UserID,
                    CreatedBy= objNotice.UserID,
                    NoticeId=objNotice.NoticeID,
                    chk = 9
                };
                DynamicParameters param = new DynamicParameters();

                //var result = Connection.Query<NoticeLetterEF>("[uspUserInformationNoticeOperation]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var result = Connection.QueryMultiple("[uspUserInformationNoticeOperation]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var UserType = result.Read<NoticeLetterEF>().ToList();
                var FileType = result.Read<NoticeLetterEF>().ToList();              
                replyNotice.UserTypeLst = UserType;
                replyNotice.FileType = FileType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return replyNotice;
        }
        public MessageEF InsertNoticeReplay(NoticeLetterEF objNotice)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                DataTable dt = new DataTable("MultipleFileUpload");
                dt = (DataTable)objNotice.MultipleFile;
                //  p.Add("UserID", objNotice.);
                p.Add("UserID", objNotice.UserID);
                p.Add("NoticeID", objNotice.NoticeID);
                p.Add("NoticeDescription", objNotice.NoticeDescription);
                p.Add("@MultipleFile", dt);
                // p.Add("UploadedFilesCount", objNotice.FileCount);
                //  p.Add("UsersCount", Convert.ToInt32(objNotice.UsersCount));
                //p.Add("TermsAndConditionIds", objNotice.LeaseTypeCode);
                p.Add("CreatedBy", objNotice.UserID);               
                p.Add("UserLoginId", objNotice.UserLoginId);
                p.Add("Chk", 6);









                if (objNotice.MultipleFile != null && objNotice.MultipleFile.Rows.Count > 0)
                {
                    p.Add("MultipleFile", dt, DbType.Object);
                    //p.Add("MultipleFile",dt );
                }
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("uspUserInformationNoticeOperation", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
                else
                {
                    objMessage.Satus = "0";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public List<NoticeLetterEF> GetNoticeReply(NoticeLetterEF objNotice)
        {
            List<NoticeLetterEF> ListSendNotice = new List<NoticeLetterEF>();
            try
            {
                var paramList = new
                {
                    UserId = objNotice.UserID,
                    NoticeID = objNotice.NoticeID,
                    chk = 7
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<NoticeLetterEF>("uspUserInformationNoticeOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListSendNotice = result.ToList();
                }
                return ListSendNotice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListSendNotice = null;
            }
        }
        public ReplyNotice Reply_GetRepliedData(NoticeLetterEF objNotice)
        {
            UserTypeResult ObjResult = new UserTypeResult();
            //  SqlHelperClass gObjSqlHelper = new SqlHelperClass();
            DataTable ObjDt = new DataTable();
            List<NoticeLetterEF> ObjUserTypeList = new List<NoticeLetterEF>();
            NoticeLetterEF noticeLetterEF = new NoticeLetterEF();
            ReplyNotice replyNotice = new ReplyNotice();
            try
            {
                var paramList = new
                {
                    UserId = objNotice.UserID,
                    CreatedBy = objNotice.UserID,
                    NoticeId = objNotice.NoticeID,
                    chk = 9
                };
                DynamicParameters param = new DynamicParameters();
                //var result = Connection.Query<NoticeLetterEF>("[uspUserInformationNoticeOperation]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var result = Connection.QueryMultiple("[uspUserInformationNoticeOperation]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var UserType = result.Read<NoticeLetterEF>().ToList();
                var FileType = result.Read<NoticeLetterEF>().ToList();
                replyNotice.UserTypeLst = UserType;
                replyNotice.FileType = FileType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return replyNotice;
        }
        public MessageEF UpdateStatusResult(NoticeLetterEF objNotice)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
               // DataTable dt = new DataTable("MultipleFileUpload");
               // dt = (DataTable)objNotice.MultipleFile;
                //  p.Add("UserID", objNotice.);
                p.Add("CreatedBy", objNotice.UserID);
                p.Add("NoticeID", objNotice.NoticeID);
                p.Add("Status_Type", objNotice.Status_Type);
                p.Add("SuspensionDate", objNotice.SuspensionDate);
                p.Add("SuspensionCopy", objNotice.SuspensionCopy);
                p.Add("PenaltyAmount", objNotice.PenaltyAmount);
                p.Add("PenaltyDate", objNotice.PenaltyDate);
                p.Add("FileCopy", objNotice.FileCopy);
                p.Add("FilePath", objNotice.FilePath);
               // p.Add("UserLoginId", objNotice.UserLoginId);
                p.Add("chk", 8);              
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("uspUserInformationNoticeOperation", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";
                }
                else
                {
                    objMessage.Satus = "0";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public List<NoticeLetterEF> GetNoticePenaltyReplyGrid(NoticeLetterEF objNotice)
        {
            List<NoticeLetterEF> ListuserType = new List<NoticeLetterEF>();
            try
            {
                var paramList = new
                {
                    UserId = objNotice.UserID,
                    chk = 12
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<NoticeLetterEF>("uspUserInformationNoticeOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListuserType = result.ToList();
                }
                return ListuserType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListuserType = null;
            }
        }
    }
}
