// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 30-Apr-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using StarratingEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using StarratingApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace StarratingApp.Areas.Starrating.Models.AddFile
{
    public class AddFileModel:IAddFileModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public AddFileModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        public List<AddFilemaster> View(AddFilemaster objAddFilemaster)
        {
            try
            {
                List<AddFilemaster> objlistFPOmaster = new List<AddFilemaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<AddFilemaster>>(_objIHttpWebClients.PostRequest("AddFile/View", JsonConvert.SerializeObject(objAddFilemaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF Add(AddFilemaster objAddFilemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AddFile/Add", JsonConvert.SerializeObject(objAddFilemaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
