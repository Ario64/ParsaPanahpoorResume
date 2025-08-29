using MediatR;
using Resume.Domain.ViewModels.SocialMedia;

namespace Resume.Application.Features.SocialMedia.Requests.Commands;

public record EditThingIDoCommandRequest : IRequest<Unit>
{
    public ulong Id { get; init; }
    public SocialMediaViewModel EditSocialMediaViewModel { get; init; }
}
