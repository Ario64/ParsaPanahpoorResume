using AutoMapper;
using MediatR;
using Resume.Application.Features.Experience.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Experience;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Experience.Handlers.Queries;

public class GetInformationRequestHandler : IRequestHandler<GetInformationRequest, ExperienceViewModel>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetInformationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<ExperienceViewModel> Handle(GetInformationRequest request, CancellationToken cancellationToken)
    {
        var experience = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Experience>()
                                          .GetAsync(request.Id);

        return _mapper.Map<ExperienceViewModel>(experience);
    }
}
