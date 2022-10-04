// ***********************************************************************
//  Interface Name           : IEntity
//  Desciption               : Entity
//  Created By               : Lingaraj Dalai
//  Created On               : 04 Feb 2022
// ***********************************************************************
namespace DashboardApi.Model
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
