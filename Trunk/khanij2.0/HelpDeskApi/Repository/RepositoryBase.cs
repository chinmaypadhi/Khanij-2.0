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




using HelpDeskApi.Factory;
using System;
using System.Data;

namespace HelpDeskApi.Repository
{
    /// <summary>
    /// Class RepositoryBase.
    /// </summary>    
    /// <seealso cref="CIMS.Repository.Contract.IRepository" />
    public abstract class RepositoryBase : IRepository
    {
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>The connection.</value>
        protected IDbConnection Connection;

        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{TEntity}"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connection factory.</param>
        protected RepositoryBase(IConnectionFactory connectionFactory)
        {
            try
            {
                Connection = connectionFactory.GetConnection;
                //Not required to open the connection, it will automatically managed by DAPPER
                //Connection.Open();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }        

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {  
                    Connection?.Dispose();
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="RepositoryBase{TEntity}"/> class.
        /// </summary>
        ~RepositoryBase()
        {
            Dispose(false);
        }
    }

    
}
