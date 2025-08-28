using AutoMapper;
using MediatR;
using Resume.Application.Features.Experience.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Information.Handlers.Commands;

public class EditInformationCommandRequestHandler : IRequestHandler<EditInformationCommandRequest, Unit>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EditInformationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<Unit> Handle(EditInformationCommandRequest request, CancellationToken cancellationToken)
    {
        var information = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Information>().GetAsync(request.Id, cancellationToken);
        _mapper.Map( request.EditInformationViewModel, information);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Information>().Update(information);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
