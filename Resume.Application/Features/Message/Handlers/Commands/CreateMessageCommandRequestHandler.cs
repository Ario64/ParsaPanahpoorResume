using AutoMapper;
using MediatR;
using Resume.Application.Features.Message.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Message.Handlers.Commands;

public class CreateMessageCommandRequestHandler : IRequestHandler<CreateMessageCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateMessageCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(CreateMessageCommandRequest request, CancellationToken cancellationToken)
    {
        var message = _mapper.Map<Domain.Entity.Message>(request.CreateMessageViewModel);
        _unitOfWork.GenericRepository<Domain.Entity.Message>().Add(message);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
