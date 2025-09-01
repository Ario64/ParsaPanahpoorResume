using MediatR;

namespace Resume.Application.Features.Experience.Requests.Commands;

public record DeleteExperienceCommandRequest(long Id) : IRequest<Unit>
{
}
