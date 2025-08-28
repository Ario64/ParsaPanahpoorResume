using MediatR;
using Resume.Domain.ViewModels.Message;

namespace Resume.Application.Features.Message.Requests.Queries;

public record GetMessageRequest : IRequest<MessageViewModel>
{
    public int Id { get; set; }
}
