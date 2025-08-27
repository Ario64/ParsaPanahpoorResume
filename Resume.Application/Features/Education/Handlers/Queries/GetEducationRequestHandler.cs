using AutoMapper;
using MediatR;
using Resume.Application.Features.Education.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Education;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Education.Handlers.Queries;

public class GetEducationRequestHandler : IRequestHandler<GetEducationRequest, EducationViewModel>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEducationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<EducationViewModel> Handle(GetEducationRequest request, CancellationToken cancellationToken)
    {
        var education = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Education>().GetAsync(request.Id, cancellationToken);
        return _mapper.Map<EducationViewModel>(education);
    }
}
