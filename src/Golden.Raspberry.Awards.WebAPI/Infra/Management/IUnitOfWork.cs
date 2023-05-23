﻿namespace Golden.Raspberry.Awards.WebAPI.Infra.Management
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() 
            where TEntity : class;
    }
}
