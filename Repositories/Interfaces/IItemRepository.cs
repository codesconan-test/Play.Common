using System.Linq.Expressions;
using Play.Common.Entities;

namespace Play.Common.Repositories.Interfaces;

/// <summary>
/// Interface for a repository that handles CRUD operations for entities that implement IEntity.
/// </summary>
/// <typeparam name="T">The type of entity that implements IEntity.</typeparam>
public interface IItemRepository<T> where T : IEntity
{
    /// <summary>
    /// Retrieves all items from the repository.
    /// </summary>
    /// <returns>An enumerable collection of items.</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Retrieves all items from the repository that match the specified filter.
    /// </summary>
    /// <param name="filter">The filter to apply to the items.</param>
    /// <returns>An enumerable collection of items that match the filter.</returns>
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);

    /// <summary>
    /// Adds a new item to the repository.
    /// </summary>
    /// <param name="item">The item to add.</param>
    Task CreateAsync(T item);

    /// <summary>
    /// Retrieves an item from the repository by its ID.
    /// </summary>
    /// <param name="id">The ID of the item to retrieve.</param>
    /// <returns>The retrieved item, or null if no item was found with the specified ID.</returns>
    Task<T?> GetAsync(Guid id);

    /// <summary>
    /// Retrieves an item from the repository that matches the specified filter.
    /// </summary>
    /// <param name="filter">The filter to apply to the items.</param>
    /// <returns>The retrieved item, or null if no item was found that matches the filter.</returns>
    Task<T?> GetAsync(Expression<Func<T, bool>> filter);

    /// <summary>
    /// Updates an item in the repository.
    /// </summary>
    /// <param name="id">The ID of the item to update.</param>
    /// <param name="item">The updated item.</param>
    /// <returns>True if the item was updated successfully, false otherwise.</returns>
    Task<bool> UpdateAsync(Guid id, T item);

    /// <summary>
    /// Deletes an item from the repository.
    /// </summary>
    /// <param name="id">The ID of the item to delete.</param>
    /// <returns>True if the item was deleted successfully, false otherwise.</returns>
    Task<bool> DeleteAsync(Guid id);
}