﻿using System.Linq.Expressions;
using MongoDB.Driver;
using Play.Common.Data;
using Play.Common.Entities;
using Play.Common.Repositories.Interfaces;

namespace Play.Common.Repositories;

/// <summary>
/// Repository class for managing items.
/// </summary>
public class ItemRepository<T> : IItemRepository<T> where T : IEntity
{
    private readonly IItemContext<T> _context;

    public ItemRepository(IItemContext<T> context)
    {
        _context = context;
    }


    public async Task<IEnumerable<T>> GetAsync()
    {
        if(_context.Items == null)
        {
            throw new ArgumentNullException(nameof(_context.Items));
        }
        return await _context.Items.Find(p => true).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        if(_context.Items == null)
        {
            throw new ArgumentNullException(nameof(_context.Items));
        }
        return await _context.Items.Find(p => true).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter)
    {
        if(_context.Items == null)
        {
            throw new ArgumentNullException(nameof(_context.Items));
        }
        
        return await _context.Items.Find(filter).ToListAsync();
    }

    public async Task CreateAsync(T item)
    {
       if (item == null)
       {
           throw new ArgumentNullException(nameof(item));
       }
       
       await _context.Items.InsertOneAsync(item);
    }

    public async Task<T?> GetAsync(Guid id)
    {
        if(id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id));
        }
        
        return await _context.Items.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
    {
        if(filter == null)
        {
            throw new ArgumentNullException(nameof(filter));
        }
        
        return await _context.Items.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateAsync(Guid id, T item)
    {
        if(id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id));
        }
        
        if(item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        
        var updateResult = await _context.Items.ReplaceOneAsync(filter: g => g.Id == id, replacement: item);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        if(id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id));
        }
        
        var filter = Builders<T>.Filter.Eq(p => p.Id, id);
        
        // delete item
        var deleteResult = await _context.Items.DeleteOneAsync(filter);
        
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}