using AutoMapper;
using MediatR;
using Resume.Application.Features.Education.Requests.Commands;
using Resume.Application.ICacheService;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Education.Handlers.Commands;

public class CreateEducationCommandRequestHandler : IRequestHandler<CreateEducationCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheServices _cache;

    public CreateEducationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheServices cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache;
    }

    #endregion

    public async Task<bool> Handle(CreateEducationCommandRequest request, CancellationToken cancellationToken)
    {
        var education = _mapper.Map<Resume.Domain.Entity.Education>(request.CreateEducationViewModel);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Education>().Add(education);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        //Set data in redis cache
        var cacheKey = $"Education:{education.Id}";
        var educationViewModel = _mapper.Map<Domain.ViewModels.Education.EducationViewModel>(education);
        await _cache.SetAsync(cacheKey, educationViewModel, System.TimeSpan.FromMinutes(10));

        return true;
    }
}
