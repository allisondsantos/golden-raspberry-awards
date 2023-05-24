namespace Golden.Raspberry.Awards.WebAPI.Infra.Management
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;
        private Dictionary<Type, object>? _repositories;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            int totalChanges = 0;
            if (_dbContext is not null)
            {
                totalChanges += await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return totalChanges;
        }

        public void Dispose()
        {
            _dbContext.Dispose();

            GC.SuppressFinalize(obj: this);

        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            _repositories ??= new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(_dbContext);
            }

            return (IRepository<TEntity>)_repositories[type];
        }
    }
}
