using Golden.Raspberry.Awards.WebAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Golden.Raspberry.Awards.WebAPI.Infra.Management
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(IDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _ = _dbSet.Add(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }
    }
}
