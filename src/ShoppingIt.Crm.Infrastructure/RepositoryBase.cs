using AutoMapper;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using ShoppingIt.Crm.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Infrastructure
{
    /// <summary>
    /// Defines the base repository, abstracting away the db commands.
    /// </summary>
    public class RepositoryBase : IRepositoryBase
    {
        private readonly DbContext context;
        public readonly IMapper mapper;

        public RepositoryBase(DbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Returns the first result from the query defined in <paramref name="where"/>. 
        /// If there is no data, return null.
        /// </summary>
        /// <typeparam name="TEntity">The entity to search.</typeparam>
        /// <typeparam name="TResult">The mapped result.</typeparam>
        /// <param name="where">Define the where clause in linq.</param>
        /// <returns>Returns the mapped result.</returns>
        public async Task<TResult> FirstOrDefaultAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default) where TEntity : class
        {
            var result = await this.context.Set<TEntity>().FirstOrDefaultAsync(where, cancellationToken);

            return this.mapper.Map<TResult>(result);
        }

        public ValueTask<TEntity> FindAsync<TEntity>(object id, CancellationToken cancellationToken = default) where TEntity : class
        {
            return this.context.Set<TEntity>().FindAsync(id);
        }

        public Task<int> SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }

        public Task<TResult[]> GetArrayAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default) where TEntity : class
        {
            return this.context.Set<TEntity>().Where(where).Select(x => mapper.Map<TResult>(x)).ToArrayAsync(cancellationToken);
        }

        public Task<TResult[]> GetArrayAsync<TEntity, TResult>(CancellationToken cancellationToken = default) where TEntity : class
        {
            return this.context.Set<TEntity>().Select(x => mapper.Map<TResult>(x)).ToArrayAsync(cancellationToken);
        }

        /// <summary>
        /// Adds new record to the database.
        /// </summary>
        /// <typeparam name="TEntity">The entity to add to the database.</typeparam>
        /// <typeparam name="TResult">The mapped response from the database.</typeparam>
        /// <param name="entity">The entity to save to the database.</param>
        /// <returns>Returns the newrly created entity as the mapped response.<w/returns>
        public async Task<TResult> AddAsync<TEntity, TResult>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class
        {
            var newEntity = await this.context.Set<TEntity>().AddAsync(entity, cancellationToken);

            await this.SaveChangesAsync();

            return this.mapper.Map<TResult>(newEntity.Entity);
        }

        /// <summary>
        /// Adds multiple rows to database.
        /// </summary>
        /// <typeparam name="TEntity">The entity to add, these are founds in domains.</typeparam>
        /// <param name="entity">THe list of entities to add.</param>
        /// <returns>Returns number of rows added.</returns>
        public async Task<int> AddRangeAsync<TEntity>(TEntity[] entity, CancellationToken cancellationToken = default) where TEntity : class
        {
            await this.context.Set<TEntity>().AddRangeAsync(entity, cancellationToken);

            return await this.context.SaveChangesAsync();
        }

        public Task StartTransactionAsync()
        {
            return this.context.Database.BeginTransactionAsync();
        }

        public Task CommitTransactionAsync()
        {
            return this.context.Database.CommitTransactionAsync();
        }

        public Task RollbackAsync()
        {
            return this.context.Database.RollbackTransactionAsync();
        }
    }
}