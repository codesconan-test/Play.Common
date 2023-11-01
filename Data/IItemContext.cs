using MongoDB.Driver;
using Play.Catalog.Entities;

namespace Play.Catalog.Data.Interfaces;

public interface IItemContext<T> where T : IEntity
{
    /// <summary>
    /// Represents a MongoDB collection of items.
    /// </summary>
    IMongoCollection<T> Items { get; }
    
}