using MediatR;

namespace Resume.Application.Features.SocialMedia.Requests.Commands;

public record DeleteSocialCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
}
