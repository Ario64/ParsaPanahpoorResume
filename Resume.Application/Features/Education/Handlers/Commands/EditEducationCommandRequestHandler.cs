using AutoMapper;
using MediatR;
using Resume.Application.Features.Education.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Education.Handlers.Commands;

public class EditEducationCommandRequestHandler : IRequestHandler<EditEducationCommandRequest, Unit>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EditEducationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;   
    }

    #endregion

    public async Task<Unit> Handle(EditEducationCommandRequest request, CancellationToken cancellationToken)
    {
        var education = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Education>().GetAsync(request.Id);
        var editedEducation = _mapper.Map(request.EditEducationViewModel, education);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Education>().Update(editedEducation);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
