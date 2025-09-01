using MediatR;
using Resume.Domain.ViewModels.SocialMedia;

namespace Resume.Application.Features.SocialMedia.Requests.Queries;

public record GetSocialMediaRequest(long Id) : IRequest<SocialMediaViewModel>
{
  
}
