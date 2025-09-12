using MediatR;
using Resume.Application.ViewModels.Pagination;
using Resume.Domain.ViewModels.Message;

namespace Resume.Application.Features.Message.Requests.Queries;

public record GetMessageListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<MessageViewModel>>
{
}
