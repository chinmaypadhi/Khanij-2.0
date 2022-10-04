// ***********************************************************************
//  Class Name               : ConnectionFactory
//  Desciption               : Connection Factory
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Dec 2020
// ***********************************************************************
using System.Data;
using System.Data.SqlClient;

namespace GeologyApi.Factory
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
