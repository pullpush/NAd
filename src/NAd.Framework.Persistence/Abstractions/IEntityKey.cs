
using System;

namespace NAd.Framework.Persistence.Abstractions
{
    public interface IEntityKey<out TKey>
        where TKey : struct
        //, IComparable<TKey>
    {
        /// <summary>
        /// Gets the unique identifier of this entity.
        /// </summary>
        TKey Id { get; }
    }
}
