// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 15-Jan-2021
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

namespace MasterApi.Model.PriorityMaster
{
    public class PriorityProvider : RepositoryBase, IPriorityProvider
    {
        public PriorityProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddPriorityMaster(Prioritymaster objPrioritymaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("PriorityName", objPrioritymaster.PriorityName);
                p.Add("CreatedBy", objPrioritymaster.CreatedBy);
                p.Add("Status", objPrioritymaster.IsActive);
                p.Add("UserLoginId", objPrioritymaster.UserLoginID);
                p.Add("Check", "INSERT");
                string response = Connection.QueryFirst<string>("uspHelpDesk_PriorityMaster", p, commandType: CommandType.StoredProcedure);
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
        public List<Prioritymaster> ViewPriorityMaster(Prioritymaster objPrioritymaster)
        {
            List<Prioritymaster> ListPrioritymaster = new List<Prioritymaster>();

            try
            {
                var paramList = new
                {
                    PriorityName = objPrioritymaster.PriorityName,
                    Check = "SELECT",

                };
                var result = Connection.Query<Prioritymaster>("uspHelpDesk_PriorityMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListPrioritymaster = result.ToList();
                }

                return ListPrioritymaster;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListPrioritymaster = null;
            }



        }
        public Prioritymaster EditPriorityMaster(Prioritymaster objPrioritymaster)
        {
            Prioritymaster LobjMPrioritymaster = new Prioritymaster();


            try
            {
                var paramList = new
                {
                    PriorityID = objPrioritymaster.PriorityID,
                    Check = "IDSELECT",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<Prioritymaster>("uspHelpDesk_PriorityMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjMPrioritymaster = result.FirstOrDefault();
                }

                return LobjMPrioritymaster;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjMPrioritymaster = null;
            }
        }
        public MessageEF DeletePriorityMaster(Prioritymaster objPrioritymaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("PriorityID", objPrioritymaster.PriorityID);
                p.Add("Check", "DELETE");
                string response = Connection.QueryFirst<string>("uspHelpDesk_PriorityMaster", p, commandType: CommandType.StoredProcedure);
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
        public MessageEF UpdatePriorityMaster(Prioritymaster objPrioritymaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("PriorityName", objPrioritymaster.PriorityName);
                p.Add("PriorityID", objPrioritymaster.PriorityID);
                p.Add("ModifiedBy", objPrioritymaster.CreatedBy);
                p.Add("Status", objPrioritymaster.IsActive);
                p.Add("UserLoginId", objPrioritymaster.UserLoginID);
                p.Add("Check", "UPDATE");
                string response = Connection.QueryFirst<string>("uspHelpDesk_PriorityMaster", p, commandType: CommandType.StoredProcedure);

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
