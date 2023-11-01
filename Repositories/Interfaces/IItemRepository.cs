using System.Linq.Expressions;
using Play.Common.Entities;

namespace Play.Common.Repositories;

/// <summary>
/// Interface for a repository that handles CRUD operations for entities that implement IEntity.
/// </summary>
/// <typeparam name="T">The type of entity that implements IEntity.</typeparam>
public interface IItemRepository<T> where T : IEntity
{
    
    Task<IEnumerable<T>> GetAllAsync();
    
    
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);


    Task CreateAsync(T item);
    
    // read
    Task<T?> GetAsync(Guid id);
    
    Task<T?> GetAsync(Expression<Func<T, bool>> filter);
    
    // update
    Task<bool> UpdateAsync(Guid id, T item);
    
    // delete
    Task<bool> DeleteAsync(Guid id);
}