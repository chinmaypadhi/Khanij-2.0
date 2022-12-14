using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeRequestAPI.Models
{
    public interface IEntity
    {
    }
    /// <summary>
    /// Class BaseEntity.
    /// </summary>
    /// <seealso cref="CIMS.Domain.IEntity" />
    public abstract class BaseEntity : IEntity
    {
    }
    /// <summary>
    /// Class BaseEntity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="CIMS.Domain.BaseEntity" />
    /// <seealso cref="CIMS.Domain.IEntity" />
    public abstract class BaseEntity<T> : BaseEntity, IEntity
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public abstract T Key { get; set; }
    }
}
