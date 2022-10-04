﻿// ***********************************************************************
// Assembly         : Khanij
// Author           : Kumar jeevan jyoti
// Created          : 28-dec-2020
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MineralConcessionApp.Web
{
    /// <summary>
    /// Extension methods to set and get serializable objects
    /// </summary>
    public static class SessionExtensions
    {
        /// <summary>
        /// Set the object by session key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        /// <summary>
        /// Get the serialized object by session key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
    /******************* USAGE OF ABOVE EXTENSION METHOD *********************/
    // Requires you add the Set and Get extension method mentioned in the topic.
    //if (HttpContext.Session.Get<DateTime>(SessionKeyTime) == default(DateTime))
    //{
    //    HttpContext.Session.Set<DateTime>(SessionKeyTime, currentTime);
    //}
}
