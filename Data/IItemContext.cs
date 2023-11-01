using MongoDB.Driver;
using Play.Common.Entities;

namespace Play.Common.Data;

public interface IItemContext<T> where T : IEntity
{
    /// <summary>
    /// Represents a MongoDB collection of items.
    /// </summary>
    IMongoCollection<T> Items { get; }
    
}