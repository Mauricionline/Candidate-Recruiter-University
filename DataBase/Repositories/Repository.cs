using Candidate_Recruiter.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Candidate_Recruiter.DataBase.Context;
using Microsoft.EntityFrameworkCore;

namespace Candidate_Recruiter.DataBase.Repositories
{
    /// <summary>
    /// Repository base
    /// </summary>
    /// <typeparam name="TEntity">Type of the value to be returned</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Context database
        /// </summary>
        protected readonly IDataContext affiliationContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="affiliationContext">Context database.</param>
        public Repository(IDataContext affiliationContext)
        {
            this.affiliationContext = affiliationContext;
        }

        /// <summary>
        /// Get all values
        /// </summary>
        /// <returns>List all</returns>
        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return this.affiliationContext.SetEntity<TEntity>().AsNoTracking();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <returns>Get By Id</returns>
        public async Task<TEntity> GetByID(Guid id)
        {
            try
            {
                return await this.affiliationContext.SetEntity<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        /// <summary>
        /// Add value
        /// </summary>
        /// <returns>New value</returns>
        /// <param name="entity">New value.</param>
        public async Task<TEntity> Add(TEntity entity, bool commitChanges = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            try
            {
                this.affiliationContext.AddEntity(entity);
                if (commitChanges)
                {
                    await this.affiliationContext.SaveChangesAsync();
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        /// <summary>
        /// Add values
        /// </summary>
        /// <returns>New value</returns>
        /// <param name="entities">New values.</param>
        public async Task<List<TEntity>> AddList(List<TEntity> entities, bool commitChanges = true)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            try
            {
                this.affiliationContext.AddRangeEntity(entities);
                if (commitChanges)
                {
                    await this.affiliationContext.SaveChangesAsync();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entities)} could not be saved: {ex.Message}");
            }
        }

        /// <summary>
        /// Update value
        /// </summary>
        /// <returns>updated value</returns>
        /// <param name="entity">New to update.</param>
        public async Task<TEntity> Update(TEntity entity, bool commitChanges = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Update)} entity must not be null");
            }

            try
            {
                this.affiliationContext.UpdateEntity(entity);
                if (commitChanges)
                {
                    await this.affiliationContext.SaveChangesAsync();
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        /// <summary>
        /// Add value
        /// </summary>
        /// <param name="entity">New value.</param>
        public async Task<TEntity> Remove(TEntity entity, bool commitChanges = true)
        {
            try
            {
                this.affiliationContext.RemoveEntity(entity);
                if (commitChanges)
                {
                    await this.affiliationContext.SaveChangesAsync();
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        /// <summary>
        /// Validate if exists entity by id.
        /// </summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Returns an instance of an entity class.</returns>
        public bool CheckIfExists(string Id)
        {
            return GetAll().Where(entity => entity.GetType().GetProperty("Id").GetValue(entity).ToString() == Id) != null;
        }

        /// <summary>
        /// Saves the changes made
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await this.affiliationContext.SaveChangesAsync();
        }

        /// <summary>
        /// Initialize a transaction, and also a savepoint for this transaction.
        /// </summary>
        /// <param name="nameSavepoint"> Name of the savepoint to initialize </param>
        /// <returns> The transaction initialized with a savepoint. </returns>
        public IDbContextTransaction StartTransaction(string nameSavepoint)
        {
            return this.affiliationContext.StartTransaction(nameSavepoint);
        }

        /// <summary>
        /// Opens a database connection.
        /// </summary>
        public void OpenDatabaseConnection()
        {
            this.affiliationContext.OpenDatabaseConnection();
        }

        /// <summary>
        /// Closes and disposes the current database connection.
        /// </summary>
        public void CloseDatabaseConnection()
        {
            this.affiliationContext.CloseDatabaseConnection();
        }
    }
}
