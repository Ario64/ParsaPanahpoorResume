using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Queries;
using Resume.Application.ICacheService;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.CustomerFeedback;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Queries;

public class GetCustomerFeedbackRequestHandler : IRequestHandler<GetCustomerFeedbackRequest, CustomerFeedbackViewModel>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
   private readonly ICacheServices _cache;

    public GetCustomerFeedbackRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheServices cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache;
    }

    #endregion

    public async Task<CustomerFeedbackViewModel> Handle(GetCustomerFeedbackRequest request, CancellationToken cancellationToken)
    {
        var cacheKey = $"CustomerFeedback:{request.Id}";
        var cacheCustomerFeedback = await _cache.GetAsync<CustomerFeedbackViewModel>(cacheKey);

        //If exist in redis then return it
        if (cacheCustomerFeedback != null)
        {
            return cacheCustomerFeedback;
        }

        var customerFeedback = await _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>()
                                                .GetAsync(request.Id, cancellationToken);

        var customerViewModel = _mapper.Map<CustomerFeedbackViewModel>(customerFeedback);

        //Save in redis
        if (customerFeedback != null) 
        {
            await _cache.SetAsync(cacheKey, customerViewModel, TimeSpan.FromMinutes(10));//Save it for 10 minutes
        }

        return customerViewModel;
    }
}