using NAd.Querying.Core.Domain;
using NAd.Querying.Core.Persistency.Common;
using NAd.Querying.Core.Persistency.RepositoryPattern;

namespace NAd.Querying.Core.Persistency
{
    public sealed class NAdUnitOfWork : UnitOfWork
    {
        public NAdUnitOfWork(IDataMapper mapper) : base(mapper)
        {

        }

        public Repository<Classified> Classifieds
        {
            get { return Mapper.GetRepository<Classified>(); }
        }

        //public Repository<Product> Products
        //{
        //    get { return Mapper.GetRepository<Product>(); }
        //}
    }
}