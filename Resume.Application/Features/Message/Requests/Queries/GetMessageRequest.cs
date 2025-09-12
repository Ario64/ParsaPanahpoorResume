using MediatR;
using Resume.Application.ViewModels.Message;

namespace Resume.Application.Features.Message.Requests.Queries;

public record GetMessageRequest(long Id) : IRequest<MessageViewModel>
{
   
}
