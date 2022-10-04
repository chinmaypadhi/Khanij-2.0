// ***********************************************************************
//  Class Name               : BaseEntity
//  Created By               : Kumar jeevan jyoti
//  Created On               : 28-dec-2020
// ***********************************************************************
namespace MasterApi.Model
{
    /// <summary>
    /// Interface IEntity
    /// </summary>
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
