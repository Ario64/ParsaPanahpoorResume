using AutoMapper;
using MediatR;
using Resume.Application.Features.Message.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Message;
using Resume.Domain.ViewModels.Pagination;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Message.Handlers.Queries;

public class GetMessageListRequestHandler : IRequestHandler<GetMessageListRequest, PagedResult<MessageViewModel>>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMessageListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<PagedResult<MessageViewModel>> Handle(GetMessageListRequest request, CancellationToken cancellationToken)
    {
        var messages = await _unitOfWork.GenericRepository<Domain.Entity.Message>()
                                        .GetAllPagedAsync(request.page, request.pageSize, cancellationToken);

        var  items = _mapper.Map<IReadOnlyList<MessageViewModel>>(messages.Items);

        return new PagedResult<MessageViewModel>
        {
            Items = items,
            TotalCount = messages.TotalCount,
            TotalPages = messages.TotalPages,
            Page = request.page,
            PageSize = request.pageSize
        };
    }
}
