using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Candidate_Recruiter.DataBase.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Get all values
        /// </summary>
        /// <returns>List all</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <returns>Get By Id</returns>
        Task<TEntity> GetByID(Guid id);

        /// <summary>
        /// Add value
        /// </summary>
        /// <returns>New value</returns>
        /// <param name="entity">New value.</param>
        Task<TEntity> Add(TEntity entity, bool commitChanges = true);

        /// <summary>
        /// Add values
        /// </summary>
        /// <returns>New value</returns>
        /// <param name="entities">New value.</param>
        Task<List<TEntity>> AddList(List<TEntity> entities, bool commitChanges = true);

        /// <summary>
        /// Update value
        /// </summary>
        /// <returns>updated value</returns>
        /// <param name="entity">New to update.</param>
        Task<TEntity> Update(TEntity entity, bool commitChanges = true);

        /// <summary>
        /// Remove one table by Id
        /// </summary>
        /// <param name="entity">Entity to remove.</param>
        Task<TEntity> Remove(TEntity entity, bool commitChanges = true);

        /// <summary>
        /// Validate if exists entity by id.
        /// </summary>
        /// <param name="Id">Entity id.</param>
        /// <returns>Returns an instance of an entity class.</returns>
        bool CheckIfExists(string Id);

        /// <summary>
        /// Saves the changes made
        /// </summary>
        Task SaveChangesAsync();

        /// <summary>
        /// Initialize a transaction, and also a savepoint for this transaction.
        /// </summary>
        /// <param name="nameSavepoint"> Name of the savepoint to initialize </param>
        /// <returns> The transaction initialized with a savepoint. </returns>
        IDbContextTransaction StartTransaction(string nameSavepoint);

        /// <summary>
        /// Opens a database connection.
        /// </summary>        
        void OpenDatabaseConnection();

        /// <summary>
        /// Closes and disposes the current database connection.
        /// </summary>
        void CloseDatabaseConnection();
    }

}
