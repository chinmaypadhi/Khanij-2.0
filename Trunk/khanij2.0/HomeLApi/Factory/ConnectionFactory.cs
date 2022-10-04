// ***********************************************************************
// Assembly         : CIMS.Repository
// Author           : Manas Bej
// Created          : 29-SEP-2018
//
// Last Modified By : Manas Bej
// Last Modified On : 29-SEP-2018
// ***********************************************************************
// <copyright file="ConnectionFactory.cs" company="CSM technologies">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Data;
using System.Data.SqlClient;

namespace HomeLApi.Factory
{
    /// <summary>
    /// Class ConnectionFactory.
    /// </summary>
    /// <seealso cref="CIMS.Repository.Contract.Factory.IConnectionFactory" />
    public class ConnectionFactory : IConnectionFactory
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionFactory"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Gets the get connection.
        /// </summary>
        /// <value>The get connection.</value>
        public IDbConnection GetConnection => new SqlConnection(_connectionString);
    }
}
