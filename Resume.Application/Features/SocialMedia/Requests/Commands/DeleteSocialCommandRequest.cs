using MediatR;

namespace Resume.Application.Features.SocialMedia.Requests.Commands;

public record DeleteSocialCommandRequest(ulong Id) : IRequest<bool>
{
}
