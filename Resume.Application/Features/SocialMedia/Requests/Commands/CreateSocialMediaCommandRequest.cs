using MediatR;
using Resume.Application.ViewModels.SocialMedia;

namespace Resume.Application.Features.ThingIdo.Requests.Commands;

public record CreateSocialMediaCommandRequest(SocialMediaViewModel SocialMediaViewModel) : IRequest<bool>
{
}
