using AutoMapper;
using MediatR;
using Resume.Application.Features.Experience.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Experience.Handlers.Commands;

public class CreateExperienceCommandRequestHandler : IRequestHandler<CreateExperienceCommandRequest, Unit>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateExperienceCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;   
        _mapper = mapper;
    }

    #endregion

    public async Task<Unit> Handle(CreateExperienceCommandRequest request, CancellationToken cancellationToken)
    {
        var experinece = _mapper.Map<Resume.Domain.Entity.Experience>(request.CreateExperienceViewModel);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Experience>().Add(experinece);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
