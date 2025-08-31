using MediatR;
using Resume.Domain.ViewModels.SocialMedia;

namespace Resume.Application.Features.ThingIdo.Requests.Commands;

public record CreateSocialMediaCommandRequest(SocialMediaViewModel SocialMediaViewModel) : IRequest<bool>
{
}
