// ***********************************************************************
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
using Dapper;
using System;
using System.IO;
using System.Xml.Serialization;

namespace SupportApi.Repository
{
    /// <summary>
    /// Common Extension
    /// </summary>
    public static class CommonExtension
    {
        /// <summary>
        /// To convert object array to dynamicparameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DynamicParameters ToDynamicParameters(this object[] parameters)
        {
            if (parameters.Length % 2 == 1)
                throw new ArgumentException("Invalid parameters");
            DynamicParameters param = new DynamicParameters();
            for (int i = 0; i < parameters.Length / 2; i++)
            {
                param.Add(parameters[2 * i].ToString(), parameters[(2 * i) + 1].ToString());
            }

            return param;
        }
        /// <summary>
        /// To convert object array to dynamicparameters and attach output parameter with default string size
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="outParameter"></param>
        /// <returns></returns>
        public static DynamicParameters ToDynamicParameters(this object[] parameters, string outParameter)
        {
            if (parameters.Length % 2 == 1)
                throw new Exception("Invalid parameters");
            DynamicParameters param = new DynamicParameters();
            for (int i = 0; i < parameters.Length / 2; i++)
            {
                param.Add(parameters[2 * i].ToString(), parameters[(2 * i) + 1].ToString());
            }
            param.Add(outParameter, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 5215585);
            return param;
        }
        /// <summary>
        /// To convert object array to dynamicparameters and attach output parameter with user defined string size
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="outParameter"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static DynamicParameters ToDynamicParameters(this object[] parameters, string outParameter, int size)
        {
            if (parameters.Length % 2 == 1)
                throw new Exception("Invalid parameters");
            DynamicParameters param = new DynamicParameters();
            for (int i = 0; i < parameters.Length / 2; i++)
            {
                param.Add(parameters[2 * i].ToString(), parameters[(2 * i) + 1].ToString());
            }
            param.Add(outParameter, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: size);
            return param;
        }
     

        public static string SerializeToXMLString<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
            StringWriter textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }

    }
}
