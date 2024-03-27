using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate_Recruiter.DataBase.Context
{
    public interface IDataContext
    {
        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>
        ///     A task that represents the asynchronous save operation. The task result contains the
        ///     number of state entries written to the database.
        /// </returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Opens a database connection.
        /// </summary>
        void OpenDatabaseConnection();

        /// <summary>
        /// Closes and disposes the current database connection.
        /// </summary>
        void CloseDatabaseConnection();

        /// <summary>
        /// Initialize a transaction, and also a savepoint for this transaction.
        /// </summary>
        /// <param name="nameSavepoint"> Name of the savepoint to initialize </param>
        /// <returns> The transaction initialized with a savepoint. </returns>
        IDbContextTransaction StartTransaction(string nameSavepoint);

        /// <summary>
        ///     Creates a <see cref="DbSet{TEntity}" /> that can be used to query and save instances of <typeparamref name="TEntity" />.
        /// </summary>
        /// <typeparam name="TEntity"> The type of entity for which a set should be returned. </typeparam>
        /// <returns> A set for the given entity type. </returns>
        DbSet<TEntity> SetEntity<TEntity>() where TEntity : class;

        /// <summary>
        /// Begins tracking the given entity, and any other reachable entities that are
        /// not already being tracked, in the <see cref="EntityState.Added" /> 
        /// </summary>
        /// <typeparam name="TEntity"> The type of the entity. </typeparam>
        /// <param name="entity"> The entity to add. </param>
        /// <returns>
        ///     The <see cref="EntityEntry{TEntity}" /> for the entity. The entry provides
        ///     access to change tracking information and operations for the entity.
        /// </returns>
        EntityEntry<TEntity> AddEntity<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        ///     Begins tracking the given entities, and any other reachable entities that are
        ///     not already being tracked, in the <see cref="EntityState.Added" />
        /// </summary>
        /// <param name="entities"> The entities to add. </param>
        void AddRangeEntity(params object[] entities);

        /// <summary>
        /// Begins tracking the given entity and entries reachable from the given entity using
        /// the <see cref="EntityState.Modified" /> state by default, but see below for cases
        /// when a different state will be used.
        /// </summary>
        /// <typeparam name="TEntity"> The type of the entity. </typeparam>
        /// <param name="entity"> The entity to update. </param>
        /// <returns>
        ///     The <see cref="EntityEntry{TEntity}" /> for the entity. The entry provides
        ///     access to change tracking information and operations for the entity.
        /// </returns>
        EntityEntry<TEntity> UpdateEntity<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        ///     Begins tracking the given entity in the <see cref="EntityState.Deleted" />
        /// </summary>
        /// <typeparam name="TEntity"> The type of the entity. </typeparam>
        /// <param name="entity"> The entity to remove. </param>
        /// <returns>
        ///     The <see cref="EntityEntry{TEntity}" /> for the entity. The entry provides
        ///     access to change tracking information and operations for the entity.
        /// </returns>
        EntityEntry<TEntity> RemoveEntity<TEntity>(TEntity entity) where TEntity : class;
    }
}
