using MediatR;

namespace Resume.Application.Features.Education.Requests.Commands;

public record DeleteEducationCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
}
