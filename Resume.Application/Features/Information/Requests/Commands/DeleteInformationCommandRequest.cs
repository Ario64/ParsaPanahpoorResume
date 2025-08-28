using MediatR;

namespace Resume.Application.Features.Information.Requests.Commands;

public record DeleteInformationCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
}
