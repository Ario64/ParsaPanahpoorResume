using MediatR;
using Resume.Domain.ViewModels.SocialMedia;

namespace Resume.Application.Features.SocialMedia.Requests.Queries;

public record GetThingIDoRequest : IRequest<SocialMediaViewModel>
{
    public ulong Id { get; init; }
}
