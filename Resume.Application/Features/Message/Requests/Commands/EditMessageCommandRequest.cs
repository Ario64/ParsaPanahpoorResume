using MediatR;
using Resume.Domain.ViewModels.Message;

namespace Resume.Application.Features.Message.Requests.Commands;

public record EditMessageCommandRequest (long Id, EditMessageViewModel EditMessageViewModel) : IRequest<bool>
{
}
