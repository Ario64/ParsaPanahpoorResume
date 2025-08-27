using MediatR;

namespace Resume.Application.Features.Experience.Requests.Commands;

public record DeleteExperienceCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
}
