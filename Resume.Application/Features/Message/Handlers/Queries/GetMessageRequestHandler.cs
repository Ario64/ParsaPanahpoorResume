using AutoMapper;
using MediatR;
using Resume.Application.Features.Message.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Message;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Message.Handlers.Queries;

public class GetMessageRequestHandler : IRequestHandler<GetMessageRequest, MessageViewModel>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMessageRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<MessageViewModel> Handle(GetMessageRequest request, CancellationToken cancellationToken)
    {
        var message = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Message>().GetAsync(request.Id, cancellationToken);
        return _mapper.Map<MessageViewModel>(message);
    }
}
