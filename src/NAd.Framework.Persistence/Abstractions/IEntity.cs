
using System;

namespace NAd.Framework.Persistence.Abstractions
{
    public interface IEntity<out TKey> : IEntityKey<TKey>
        where TKey : struct
        //, IComparable<TKey>
    {
    }
}
