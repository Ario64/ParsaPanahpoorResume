using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Queries;
using Resume.Application.ICacheService;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.CustomerFeedback;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Queries;

public class GetCustomerFeedbackListRequestHandler : IRequestHandler<GetCustomerFeedbackListRequest, IReadOnlyList<CustomerFeedbackViewModel>>
{
    #region Constructort

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheServices _cache;

    public GetCustomerFeedbackListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheServices cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache;
    }

    #endregion

    public async Task<IReadOnlyList<CustomerFeedbackViewModel>> Handle(GetCustomerFeedbackListRequest request, CancellationToken cancellationToken)
    {
        var cacheKey = $"CustomerFeedbackList_List";
        var customerFeedbackListCached = await _cache.GetAsync<IReadOnlyList<CustomerFeedbackViewModel>>(cacheKey);

        //If list exists in redis then return it
        if (customerFeedbackListCached != null)
        {
            return customerFeedbackListCached;
        }

        var customerFeedbackList = await _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>()
                                                    .GetAllAsync(cancellationToken);

        var mappedCustomerFeedbackList = _mapper.Map<IReadOnlyList<CustomerFeedbackViewModel>>(customerFeedbackList);

        //Save in redis
        if(customerFeedbackList != null)
        {
            await _cache.SetAsync<IReadOnlyList<CustomerFeedbackViewModel>>(cacheKey, mappedCustomerFeedbackList, TimeSpan.FromMinutes(5));
        }

        return mappedCustomerFeedbackList;

    }
}