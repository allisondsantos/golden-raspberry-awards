namespace Golden.Raspberry.Awards.WebAPI.Infra.Management
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);

        IQueryable<TEntity> GetAll();
    }
}
