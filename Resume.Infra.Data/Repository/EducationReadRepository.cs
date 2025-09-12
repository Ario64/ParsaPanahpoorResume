using Microsoft.EntityFrameworkCore;
using Resume.Application.Interface;
using Resume.Application.ViewModels.Education;
using Resume.Application.ViewModels.Pagination;
using Resume.Domain.Entity;
using Resume.Infra.Data.Context;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Infra.Data.Repository;

public class EducationReadRepository : IEducationReadRepository
{
    //constructor
    private readonly AppDbContext _context;
    public EducationReadRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<Education>> GetAllEducationPagedAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var skip = page - 1;
        var take = pageSize;

        var educations =  _context.Educations.AsQueryable();
   
        var totalCount = await educations.CountAsync(cancellationToken);
        var totalPage = (int)(Math.Ceiling(totalCount / (double)take));

        var items = await educations.Skip(skip)
                                    .Take(take)
                                    .ToListAsync(cancellationToken);

        return new PagedResult<Education>()
        {
            Items =  items,
            TotalPages = totalPage,
            Page = page,
            TotalCount = totalCount,
            PageSize = pageSize
        };
    }
}
