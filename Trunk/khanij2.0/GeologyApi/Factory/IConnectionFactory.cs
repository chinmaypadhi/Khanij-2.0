// ***********************************************************************
//  Interface Name           : IConnectionFactory
//  Desciption               : Connection Factory
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Dec 2020
// ***********************************************************************
using System.Data;

namespace GeologyApi.Factory
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
