
using System;
using NAd.Framework.Domain;
using NAd.Framework.Persistence;
using NAd.Framework.Persistence.Abstractions;
using NAd.Framework.Persistence.RepositoryPattern;

namespace NAd.Framework.Hive
{
    public sealed class NAdUnitOfWork : UnitOfWork
    {
        public NAdUnitOfWork(IDataMapper mapper) : base(mapper)
        {

        }

        public IQueryableRepository<Classified, Guid> Classifieds
        {
            get { return Mapper.GetRepository<Classified, Guid>(); }
        }

        //public Repository<Product> Products
        //{
        //    get { return Mapper.GetRepository<Product>(); }
        //}
    }
}