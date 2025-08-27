using AutoMapper;
using MediatR;
using Resume.Application.Features.Experience.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.Entity;
using Resume.Domain.ViewModels.Experience;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Experience.Handlers.Queries;

public class GetExperienceRequestHandler : IRequestHandler<GetExperienceRequest, ExperienceViewModel>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetExperienceRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<ExperienceViewModel> Handle(GetExperienceRequest request, CancellationToken cancellationToken)
    {
        var experience = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Experience>()
                                          .GetAsync(request.Id);

        return _mapper.Map<ExperienceViewModel>(experience);
    }
}
