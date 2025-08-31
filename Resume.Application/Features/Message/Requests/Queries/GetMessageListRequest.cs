using MediatR;
using Resume.Domain.ViewModels.Message;
using Resume.Domain.ViewModels.Pagination;

namespace Resume.Application.Features.Message.Requests.Queries;

public record GetMessageListRequest(int page = 1, int pageSize = 10) : IRequest<PagedResult<MessageViewModel>>
{
}
