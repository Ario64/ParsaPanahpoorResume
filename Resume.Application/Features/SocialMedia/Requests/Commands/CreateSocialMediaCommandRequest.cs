using MediatR;
using Resume.Domain.ViewModels.SocialMedia;

namespace Resume.Application.Features.SocialMedia.Requests.Commands;

public record CreateThingIDoCommandRequest : IRequest<Unit>
{
    public SocialMediaViewModel CreateSocialMediaViewModel { get; init; }
}
