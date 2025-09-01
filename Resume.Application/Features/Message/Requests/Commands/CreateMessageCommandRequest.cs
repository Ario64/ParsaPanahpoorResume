using MediatR;
using Resume.Domain.ViewModels.Message;

namespace Resume.Application.Features.Message.Requests.Commands;

public record CreateMessageCommandRequest(CreateMessageViewModel CreateMessageViewModel) : IRequest<bool>
{
}
