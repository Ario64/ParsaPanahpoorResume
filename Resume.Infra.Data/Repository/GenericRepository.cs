using Microsoft.EntityFrameworkCore;
using Resume.Domain.IRepository.GenericRepository;
using Resume.Domain.ViewModels.Pagination;
using Resume.Infra.Data.Context;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

    #region Get All Async

    public async Task<PagedResult<T>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        int skip = (page - 1) * pageSize;
        int take = pageSize;

        var query = _context.Set<T>().AsQueryable();

        var totalCount = await query.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalCount / (double)take);

        var items = await query.Skip(skip)
                               .Take(take)
                               .ToListAsync(cancellationToken);

        return new PagedResult<T>()
        {
            Items = items,
            TotalPages = totalPages,
            Page = page,
            TotalCount = totalCount,
            PageSize = pageSize
        };
    }

    #endregion

    #region GetAsync

    public async Task<T> GetAsync(object id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<T>().FindAsync(id, cancellationToken);
        return entity;
    }

    #endregion

    #region Add

    public void Add(T entity)
    {
         _context.Set<T>().Add(entity);
    }

    #endregion

    #region Update

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    #endregion

    #region Delete

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    #endregion

}