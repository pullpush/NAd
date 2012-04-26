
using System;
using System.Data.Services.Common;
using System.Collections.Generic;
using NAd.Framework.Persistence.Abstractions.Model;

namespace NAd.Framework.Persistence.Abstractions
{
    //public abstract class Entity { }

    [DataServiceKey(DatabaseConstants.IdentityColumn)]
    public abstract class Entity<TId> : PageModel, IEntity<TId>    //, IEquatable<Entity<TId>> //Entity,
        where TId : struct
    //, IComparable<TId>, IComparer<TId>, IComparable<TId>, IEquatable<TId>
    {
        public virtual TId Id { get; set; }

        //public string IdAsString { get { return Id.ToString(); } }

        //public override bool Equals(TId obj)
        //{
        //}

        //public static bool operator ==(TId x, TId y)
        //{
        //    if ((x == null || x is Nothing) && (y == null || y is Nothing))
        //        return true;

        //    return false;
        //}

        //#region IComparer<TId> Members

        //public int Compare(TId x, TId y)
        //{
        //    return x.ToString().CompareTo(y);
        //}

        //#endregion

        //#region IComparable<TId> Members

        //public int CompareTo(TId other)
        //{
        //    return this.Id.ToString().CompareTo(other);
        //}

        //#endregion

        //public bool CompareToId(TId id)
        //{
        //    return Id.ToString().Equals(id);
        //}

        //#region IEquatable<TId> Members

        //public bool Equals(Entity<TId> other)
        //{
        //    return this.Id.ToString().Equals(other.Id.ToString());
        //}

        //#endregion
    }
}
