using AutoMapper;
using MediatR;
using Resume.Application.Features.Experience.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Experience.Handlers.Commands;

public class EditExperienceCommandRequestHandler : IRequestHandler<EditExperienceCommandRequest, Unit>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public EditExperienceCommandRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<Unit> Handle(EditExperienceCommandRequest request, CancellationToken cancellationToken)
    {
        var experience = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Experience>().GetAsync(request.Id, cancellationToken);
        _mapper.Map(request.EditExperienceViewModel, experience);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Experience>().Update(experience);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
