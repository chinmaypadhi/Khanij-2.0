// ***********************************************************************
//  Interface Name           : IConnectionFactory
//  Desciption               : Connection Factory
//  Created By               : Lingaraj Dalai
//  Created On               : 04 Feb 2022
// ***********************************************************************
using System.Data;

namespace DashboardApi.Factory
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
