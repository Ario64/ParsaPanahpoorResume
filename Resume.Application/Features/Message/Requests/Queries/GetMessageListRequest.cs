using MediatR;
using Resume.Application.ViewModels.Message;
using Resume.Application.ViewModels.Pagination;

namespace Resume.Application.Features.Message.Requests.Queries;

public record GetMessageListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<MessageViewModel>>
{
}
