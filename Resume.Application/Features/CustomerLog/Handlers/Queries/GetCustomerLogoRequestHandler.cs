using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerLog.Requests.Queries;
using Resume.Application.ICacheService;
using Resume.Application.UnitOfWork;
using Resume.Domain.Entity;
using Resume.Domain.ViewModels.CustomerLogo;

namespace Resume.Application.Features.CustomerLog.Handlers.Queries;

public class GetCustomerLogoRequestHandler : IRequestHandler<GetCustomerLogoRequest, CustomerLogoViewModel>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheServices _cache;

    public GetCustomerLogoRequestHandler(IMapper mapper, IUnitOfWork unitOfWork, ICacheServices cache)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _cache = cache;
    }

    #endregion

    public async Task<CustomerLogoViewModel> Handle(GetCustomerLogoRequest request, CancellationToken cancellationToken)
    {
        var cacheKey = $"CustomerLogo:{request.Id}";
        var cachedCustomerLogo = await _cache.GetAsync<CustomerLogoViewModel>(cacheKey);

        //If data exists in cache, return it
        if ((cachedCustomerLogo != null))
        {
            return cachedCustomerLogo;
        }

        //Fetch data from database
        var customerLogo = await _unitOfWork.GenericRepository<CustomerLogo>()
                                            .GetAsync(request.Id, cancellationToken);

        //Mapping data
        var mappedCustomerLogo = _mapper.Map<CustomerLogoViewModel>(customerLogo);

        //Store data in cache for future requests
        await _cache.SetAsync<CustomerLogoViewModel>(cacheKey, mappedCustomerLogo, TimeSpan.FromMinutes(10));

        return mappedCustomerLogo;

    }
}