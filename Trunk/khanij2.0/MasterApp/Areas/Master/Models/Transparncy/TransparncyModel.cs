// ***********************************************************************
//  Class Name               : TransparncyModel
//  Description              : Add,View,Edit,Update,Delete Transparncy Details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MasterApp.Factory;
using MasterApp.Repository;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Transparncy
{
    public class TransparncyModel:ITransparncyModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary> 
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public TransparncyModel(IHttpWebClients objIHttpWebClients) 
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Transparncy details in view
        /// </summary>
        /// <param name="objTransparncymaster"></param>
        /// <returns></returns>
        public MessageEF Add(Transparncymaster objTransparncymaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Transparncy/Add", JsonConvert.SerializeObject(objTransparncymaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Transparncy details in view
        /// </summary>
        /// <param name="objTransparncymaster"></param>
        /// <returns></returns>
        public MessageEF Update(Transparncymaster objTransparncymaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Transparncy/Update", JsonConvert.SerializeObject(objTransparncymaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Transparncy details in view
        /// </summary>
        /// <param name="objTransparncymaster"></param>
        /// <returns></returns>
        public List<Transparncymaster> View(Transparncymaster objTransparncymaster)
        {
            try
            {
                List<Transparncymaster> objlistTransparncymaster = new List<Transparncymaster>();
                objlistTransparncymaster = JsonConvert.DeserializeObject<List<Transparncymaster>>(_objIHttpWebClients.PostRequest("Transparncy/View", JsonConvert.SerializeObject(objTransparncymaster)));
                return objlistTransparncymaster;

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw ex;
            }
            //List<Transparncymaster> ListTransparncymaster = new List<Transparncymaster>();
            //try
            //{
            //    var paramList = new
            //    {
            //        DNId = objTransparncymaster.DNId,
            //        Check = "5",
            //    };
            //    var Output = Connection.Query<Transparncymaster>("USPTransparncyPortalNoticeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

            //    if (Output.Count() > 0)
            //    {

            //        ListTransparncymaster = Output.ToList();
            //    }

            //    return ListTransparncymaster;
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            //finally
            //{

            //    ListTransparncymaster = null;
            //}

        }
        /// <summary>
        /// Delete Transparncy details in view
        /// </summary>
        /// <param name="objTransparncymaster"></param>
        /// <returns></returns>
        public MessageEF Delete(Transparncymaster objTransparncymaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Transparncy/Delete", JsonConvert.SerializeObject(objTransparncymaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit Transparncy details in view
        /// </summary>
        /// <param name="objTransparncymaster"></param>
        /// <returns></returns>
        public Transparncymaster Edit(Transparncymaster objTransparncymaster)
        {
            try
            {
                objTransparncymaster = JsonConvert.DeserializeObject<Transparncymaster>(_objIHttpWebClients.PostRequest("Transparncy/Edit", JsonConvert.SerializeObject(objTransparncymaster)));
                return objTransparncymaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            //Transparncymaster LobjTransparncymaster = new Transparncymaster();
            //try
            //{
            //    var paramList = new
            //    {
            //        DNId = objTransparncymaster.DNId,
            //        Check = "5",
            //    };
            //    DynamicParameters param = new DynamicParameters();

            //    var Output = Connection.Query<Transparncymaster>("USPTransparncyPortalNoticeMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

            //    if (Output.Count() > 0)
            //    {

            //        LobjTransparncymaster = Output.FirstOrDefault();
            //    }

            //    return LobjTransparncymaster;
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            //finally
            //{

            //    LobjTransparncymaster = null;
            //}
        }
    }
}
