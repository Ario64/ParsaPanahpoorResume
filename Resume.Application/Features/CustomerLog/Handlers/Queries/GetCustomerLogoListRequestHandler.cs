using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerLog.Requests.Queries;
using Resume.Application.ICacheService;
using Resume.Application.UnitOfWork;
using Resume.Domain.Entity;
using Resume.Domain.ViewModels.CustomerLogo;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerLog.Handlers.Queries;

public class GetCustomerLogoListRequestHandler : IRequestHandler<GetCustomerLogoListRequest, IReadOnlyList<CustomerLogoViewModel>>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheServices _cache;

    public GetCustomerLogoListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheServices cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache;
    }

    #endregion

    public async Task<IReadOnlyList<CustomerLogoViewModel>> Handle(GetCustomerLogoListRequest request, CancellationToken cancellationToken)
    {
        var cacheKey = "CustomerLogoList";
        var cachedCustomerLogoList = await _cache.GetAsync<IReadOnlyList<CustomerLogoViewModel>>(cacheKey);

        //If list exists in cache then return it
        if (cachedCustomerLogoList != null)
        {
            return cachedCustomerLogoList;
        }

        var customerLogoList = await _unitOfWork.GenericRepository<CustomerLogo>()
                                                .GetAllAsync( cancellationToken);

        var customerLogoListViewModel = _mapper.Map<IReadOnlyList<CustomerLogoViewModel>>(customerLogoList);

        if(customerLogoList != null)
        {
           await  _cache.SetAsync<IReadOnlyList<CustomerLogoViewModel>>(cacheKey, customerLogoListViewModel, TimeSpan.FromMinutes(10));
        }

        return customerLogoListViewModel;
    }
}