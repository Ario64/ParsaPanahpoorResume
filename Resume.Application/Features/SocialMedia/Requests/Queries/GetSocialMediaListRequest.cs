using MediatR;
using Resume.Application.ViewModels.SocialMedia;
using System.Collections.Generic;

namespace Resume.Application.Features.SocialMedia.Requests.Queries;

public record GetSocialMediaListRequest() : IRequest<IReadOnlyList<SocialMediaViewModel>>
{
}
