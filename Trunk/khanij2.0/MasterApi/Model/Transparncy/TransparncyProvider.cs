// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 25-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
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

namespace MasterApi.Model.Transparncy
{
    public class TransparncyProvider: RepositoryBase,ITransparncyProvider
    {
        public TransparncyProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddTransparncymaster(Transparncymaster objTransparncymaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("NoticeText", objTransparncymaster.NoticeText);
                p.Add("IsPublish", objTransparncymaster.IsPublished);
                p.Add("NoticeFileName", objTransparncymaster.NoticeFileName);
                p.Add("NoticeFilePath", objTransparncymaster.NoticeFilePath);
                p.Add("ImageUrlPath", objTransparncymaster.ImageUrlPath);
                p.Add("ActiveStatus", objTransparncymaster.IsActive);
                p.Add("CreatedBy", objTransparncymaster.CREATED_BY);
                p.Add("Check", "2");
                string response = Connection.QueryFirst<string>("USPTransparncyPortalNoticeMaster", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response == "0")
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
        public async Task<List<Transparncymaster>> ViewTransparncymaster(Transparncymaster objTransparncymaster)
        {
            List<Transparncymaster> ListTransparncymaster = new List<Transparncymaster>();
            try
            {
                var paramList = new
                {
                    DNId = objTransparncymaster.DNId,
                    Check = "5",
                };
                var Output =await Connection.QueryAsync<Transparncymaster>("USPTransparncyPortalNoticeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ListTransparncymaster = Output.ToList();
                }
                return ListTransparncymaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListTransparncymaster = null;
            }
        }
        public Transparncymaster EditTransparncymaster(Transparncymaster objTransparncymaster)
        {
            Transparncymaster LobjTransparncymaster = new Transparncymaster();
            try
            {
                var paramList = new
                {
                    DNId = objTransparncymaster.DNId,
                    Check = "5",
                };
                DynamicParameters param = new DynamicParameters();
                var Output = Connection.Query<Transparncymaster>("USPTransparncyPortalNoticeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    LobjTransparncymaster = Output.FirstOrDefault();
                }
                return LobjTransparncymaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjTransparncymaster = null;
            }
        }
        public MessageEF DeleteTransparncymaster(Transparncymaster objTransparncymaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("isDelete", objTransparncymaster.isDelete);
                p.Add("DNId", objTransparncymaster.DNId);
                p.Add("Check", "4");
                string response = Connection.QueryFirst<string>("USPTransparncyPortalNoticeMaster", p, commandType: CommandType.StoredProcedure);
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
        public MessageEF UpdateTransparncymaster(Transparncymaster objTransparncymaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("NoticeText", objTransparncymaster.NoticeText);
                p.Add("DNId", objTransparncymaster.DNId);
                p.Add("IsPublish", objTransparncymaster.IsPublished);
                p.Add("NoticeFileName", objTransparncymaster.NoticeFileName);
                p.Add("NoticeFilePath", objTransparncymaster.NoticeFilePath);
                p.Add("ImageUrlPath", objTransparncymaster.ImageUrlPath);
                p.Add("ActiveStatus", objTransparncymaster.IsActive);
                p.Add("Check", "3");
                string response = Connection.QueryFirst<string>("USPTransparncyPortalNoticeMaster", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response == "0")
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
        /// <summary>
        /// To Display Notice in Website
        /// </summary>
        /// <param name="objTransparncymaster"></param>
        /// <returns></returns>
        public List<Transparncymaster> ViewNotice(Transparncymaster objTransparncymaster)
        {
            List<Transparncymaster> ListTransparncymaster = new List<Transparncymaster>();
            try
            {
                var paramList = new
                {
                    DNId = objTransparncymaster.DNId,
                    Check = "6",
                };
                var Output = Connection.Query<Transparncymaster>("USPTransparncyPortalNoticeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {
                    ListTransparncymaster = Output.ToList();
                }

                return ListTransparncymaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ListTransparncymaster = null;
            }

        }
    }
}
