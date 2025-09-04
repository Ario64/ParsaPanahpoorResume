using AutoMapper;
using MediatR;
using Resume.Application.Features.Education.Requests.Queries;
using Resume.Application.ICacheService;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Education;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Education.Handlers.Queries;

public class GetEducationRequestHandler : IRequestHandler<GetEducationRequest, EducationViewModel>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheServices _cache;

    public GetEducationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheServices cache)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _cache = cache;
    }

    #endregion

    public async Task<EducationViewModel> Handle(GetEducationRequest request, CancellationToken cancellationToken)
    {
        var cacheKey = $"Education:{request.Id}";
        var cachedEducation = await _cache.GetAsync<EducationViewModel>(cacheKey);

        // Return cached education if available
        if (cachedEducation != null)
        {
            return cachedEducation;
        }

        var education = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Education>()
                                         .GetAsync(request.Id, cancellationToken);

        var mappedEducation =  _mapper.Map<EducationViewModel>(education);
        if (education != null)
        {
            await _cache.SetAsync(cacheKey, mappedEducation, TimeSpan.FromMinutes(10));
        }

        return mappedEducation;
    }
}
