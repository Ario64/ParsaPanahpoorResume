using AutoMapper;
using MediatR;
using Resume.Application.Features.Message.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Message.Handlers.Commands;

public class EditMessageCommandRequestHandler : IRequestHandler<EditMessageCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EditMessageCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(EditMessageCommandRequest request, CancellationToken cancellationToken)
    {
        var message = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Message>().GetAsync(request.Id, cancellationToken);
        _mapper.Map(request.EditMessageViewModel, message);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Message>().Update(message);
        return true;
    }
}
