using Resume.Application.ViewModels.Pagination;
using Resume.Domain.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Interface;

public interface IEducationReadRepository
{
    Task<PagedResult<Education>> GetAllEducationPagedAsync(int page, int pageSize, CancellationToken cancellationToken = default);
}




