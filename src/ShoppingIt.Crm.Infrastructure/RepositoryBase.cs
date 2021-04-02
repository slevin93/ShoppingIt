// <copyright file="RepositoryBase.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Infrastructure
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Defines the base repository, abstracting away the db commands.
    /// </summary>
    public class RepositoryBase
    {
        private readonly DbContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase"/> class.
        /// </summary>
        /// <param name="context">The dbcontext.</param>
        /// <param name="mapper">The IMapper.</param>
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
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns the mapped result.</returns>
        public async Task<TResult> FirstOrDefaultAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            var result = await this.context.Set<TEntity>().FirstOrDefaultAsync(where, cancellationToken);

            return this.mapper.Map<TResult>(result);
        }

        /// <summary>
        /// Get entity by id where the provided id is equal to the entity id.
        /// </summary>
        /// <typeparam name="TEntity">The entity type to return.</typeparam>
        /// <param name="id">The entity id to return.</param>
        /// <returns>Returns entity id is equal to <paramref name="id"/>.</returns>
        public ValueTask<TEntity> FindAsync<TEntity>(object id)
            where TEntity : class
        {
            return this.context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Save changes to entity states.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns number of entities state updated.</returns>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return this.context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets array of entities where entity qualify for the provided <paramref name="where"/>.
        /// </summary>
        /// <typeparam name="TEntity">The entity to get from db.</typeparam>
        /// <typeparam name="TResult">The response type.</typeparam>
        /// <param name="where">The where clause to search entities against.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns entities where entity state matches the where clause.</returns>
        public Task<TResult[]> GetArrayAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            return this.context.Set<TEntity>().Where(where).Select(x => this.mapper.Map<TResult>(x)).ToArrayAsync(cancellationToken);
        }

        /// <summary>
        /// Get all items stored with provided type.
        /// </summary>
        /// <typeparam name="TEntity">The entity type to return.</typeparam>
        /// <typeparam name="TResult">The result to return.</typeparam>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns array of all items found in entity table.</returns>
        public Task<TResult[]> GetArrayAsync<TEntity, TResult>(CancellationToken cancellationToken = default)
            where TEntity : class
        {
            return this.context.Set<TEntity>().Select(x => this.mapper.Map<TResult>(x)).ToArrayAsync(cancellationToken);
        }

        /// <summary>
        /// Adds new record to the database.
        /// </summary>
        /// <typeparam name="TEntity">The entity to add to the database.</typeparam>
        /// <typeparam name="TResult">The mapped response from the database.</typeparam>
        /// <param name="entity">The entity to save to the database.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns the newrly created entity as the mapped response.</returns>
        public async Task<TResult> AddAsync<TEntity, TResult>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            var newEntity = await this.context.Set<TEntity>().AddAsync(entity, cancellationToken);

            await this.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<TResult>(newEntity.Entity);
        }

        /// <summary>
        /// Adds multiple rows to database.
        /// </summary>
        /// <typeparam name="TEntity">The entity to add, these are founds in domains.</typeparam>
        /// <param name="entity">THe list of entities to add.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns number of rows added.</returns>
        public async Task<int> AddRangeAsync<TEntity>(TEntity[] entity, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            await this.context.Set<TEntity>().AddRangeAsync(entity, cancellationToken);

            return await this.context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <typeparam name="TEntity">The entity to update.</typeparam>
        /// <typeparam name="TResult">The result type to return.</typeparam>
        /// <param name="id">The entity id.</param>
        /// <param name="entity">The new entity value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns number of rows updated.</returns>
        public async Task<TResult> UpdateAsync<TEntity, TResult>(object id, TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            var currentEntity = await this.FindAsync<TEntity>(id);

            this.context.Entry<TEntity>(currentEntity).CurrentValues.SetValues(entity);

            await this.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<TResult>(currentEntity);
        }
    }
}