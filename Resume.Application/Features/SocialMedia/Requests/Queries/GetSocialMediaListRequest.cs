using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.SocialMedia;

namespace Resume.Application.Features.SocialMedia.Requests.Queries;

public record GetSocialMediaListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<SocialMediaViewModel>>
{
}
