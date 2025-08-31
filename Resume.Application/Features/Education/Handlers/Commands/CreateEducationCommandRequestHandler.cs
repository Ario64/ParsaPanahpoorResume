using AutoMapper;
using MediatR;
using Resume.Application.Features.Education.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Education.Handlers.Commands;

public class CreateEducationCommandRequestHandler : IRequestHandler<CreateEducationCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEducationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(CreateEducationCommandRequest request, CancellationToken cancellationToken)
    {
        var education = _mapper.Map<Resume.Domain.Entity.Education>(request.CreateEducationViewModel);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Education>().Add(education);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
