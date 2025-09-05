using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.SocialMedia;
using System.Collections.Generic;

namespace Resume.Application.Features.SocialMedia.Requests.Queries;

public record GetSocialMediaListRequest() : IRequest<IReadOnlyList<SocialMediaViewModel>>
{
}
