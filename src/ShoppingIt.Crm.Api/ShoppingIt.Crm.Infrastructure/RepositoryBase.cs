using AutoMapper;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Infrastructure
{
    /// <summary>
    /// Defines the base repository, abstracting away the db commands.
    /// </summary>
    public class RepositoryBase
    {
        private readonly DbContext context;
        private readonly IMapper mapper;

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
        public async Task<TResult> FirstOrDefaultAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> where) where TEntity : class
        {
            var result = await this.context.Set<TEntity>().FirstOrDefaultAsync(where);

            return this.mapper.Map<TResult>(result);
        }

        public Task<TResult[]> GetArrayAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> where) where TEntity : class
        {
            return this.context.Set<TEntity>().Where(where).Select(x => mapper.Map<TResult>(x)).ToArrayAsync();
        }

        public Task<TResult[]> GetArrayAsync<TEntity, TResult>() where TEntity : class
        {
            return this.context.Set<TEntity>().Select(x => mapper.Map<TResult>(x)).ToArrayAsync();
        }

        /// <summary>
        /// Adds new record to the database.
        /// </summary>
        /// <typeparam name="TEntity">The entity to add to the database.</typeparam>
        /// <typeparam name="TResult">The mapped response from the database.</typeparam>
        /// <param name="entity">The entity to save to the database.</param>
        /// <returns>Returns the newrly created entity as the mapped response.</returns>
        public async Task<TResult> AddAsync<TEntity, TResult>(TEntity entity) where TEntity : class
        {
            var newEntity = await this.context.Set<TEntity>().AddAsync(entity);

            await this.context.SaveChangesAsync();

            return this.mapper.Map<TResult>(newEntity.Entity);
        }
    }
}
