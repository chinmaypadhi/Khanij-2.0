// ***********************************************************************
//  Class Name               : SessionExtensions
//  Desciption               : Common extensions for implementing session
//  Created By               : sanjay kumar
//  Created On               : 28 Dec 2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PermitApp.Web
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
}
