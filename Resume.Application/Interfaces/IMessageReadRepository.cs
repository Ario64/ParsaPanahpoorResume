using Resume.Application.ViewModels.Pagination;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Interfaces;

public interface IMessageReadRepository
{
    Task<PagedResult<Resume.Domain.Entity.Message>> GetAllPagedAsync(int page, int pageSize, CancellationToken cancellationToken = default);
}
