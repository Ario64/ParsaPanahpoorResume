using MediatR;
using Resume.Domain.ViewModels.Message;

namespace Resume.Application.Features.Message.Requests.Commands;

public record CreateMessageCommandRequest : IRequest<Unit>
{
    public CreateMessageViewModel CreateMessageViewModel { get; set; }
}
