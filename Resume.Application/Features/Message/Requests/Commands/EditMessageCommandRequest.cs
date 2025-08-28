using MediatR;
using Resume.Domain.ViewModels.Message;

namespace Resume.Application.Features.Message.Requests.Commands;

public record EditMessageCommandRequest : IRequest<Unit>
{
    public ulong Id { get; init; }
    public EditMessageViewModel EditMessageViewModel { get; init; }
}
