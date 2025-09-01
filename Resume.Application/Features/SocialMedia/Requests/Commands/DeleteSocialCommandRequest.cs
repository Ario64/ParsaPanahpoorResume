using MediatR;

namespace Resume.Application.Features.SocialMedia.Requests.Commands;

public record DeleteSocialCommandRequest(long Id) : IRequest<bool>
{
}
