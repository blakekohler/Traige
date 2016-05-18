using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Triage.EntityFramework.Repositories
{
    public abstract class TriageRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<TriageDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected TriageRepositoryBase(IDbContextProvider<TriageDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class TriageRepositoryBase<TEntity> : TriageRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected TriageRepositoryBase(IDbContextProvider<TriageDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
