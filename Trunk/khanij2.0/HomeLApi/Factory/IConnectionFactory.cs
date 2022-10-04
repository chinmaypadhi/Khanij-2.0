// ***********************************************************************
// Assembly         : CIMS.Repository.Contract
// Author           : Manas Bej
// Created          : 31-JUL-2019
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="IConnectionFactory.cs" company="CSM technologies">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data;

namespace HomeLApi.Factory
{
    /// <summary>
    /// Interface IConnectionFactory
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// Gets the get connection.
        /// </summary>
        /// <value>The get connection.</value>
        IDbConnection GetConnection { get; }
    }
}
