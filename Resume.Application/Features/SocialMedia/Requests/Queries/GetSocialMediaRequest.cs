using MediatR;
using Resume.Application.ViewModels.SocialMedia;

namespace Resume.Application.Features.SocialMedia.Requests.Queries;

public record GetSocialMediaRequest(long Id) : IRequest<SocialMediaViewModel>
{
  
}
