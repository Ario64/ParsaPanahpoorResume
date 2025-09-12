using Microsoft.EntityFrameworkCore;
using Resume.Application.Interfaces;
using Resume.Application.ViewModels.Pagination;
using Resume.Domain.Entity;
using Resume.Infra.Data.Context;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Infra.Data.Repository;

public class MessageReadRepository : IMessageReadRepository
{
    //constructor
    private readonly AppDbContext _context;
    public MessageReadRepository(AppDbContext context)
    {
        _context = context;
    } 

    public async Task<PagedResult<Message>> GetAllPagedAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var skip = page - 1;
        var take = pageSize;

        var messages = _context.Messages.AsQueryable();

        var totalCount = await messages.CountAsync(cancellationToken);
        var totalPage = (int)(Math.Ceiling(totalCount / (double)take));

        var items = await messages.Skip(skip)
                                  .Take(take)
                                  .ToListAsync(cancellationToken);

        return new PagedResult<Message>()
        {
            Items = items,
            TotalPages = totalPage,
            Page = page,
            TotalCount = totalCount,
            PageSize = pageSize
        };
    }
}
