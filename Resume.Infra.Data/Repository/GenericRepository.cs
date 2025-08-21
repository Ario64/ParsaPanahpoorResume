using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Domain.IRepository.GenericRepository;
using Resume.Infra.Data.Context;

namespace Resume.Infra.Data.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    #region ctor

    private readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    #endregion

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        var entityList = await _context.Set<T>().ToListAsync();
        return entityList;
    }

    public async Task<T> GetAsync(ulong id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        return entity;
    }

    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}