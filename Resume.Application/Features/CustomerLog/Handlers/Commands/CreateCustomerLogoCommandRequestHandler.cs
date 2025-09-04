using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerLog.Requests.Commands;
using Resume.Application.ICacheService;
using Resume.Application.UnitOfWork;
using Resume.Domain.Entity;
using Resume.Domain.ViewModels.CustomerLogo;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerLog.Handlers.Commands;

public class CreateCustomerLogoCommandRequestHandler : IRequestHandler<CreateCustomerLogoCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheServices _cache;

    public CreateCustomerLogoCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheServices cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache; 
    }

    #endregion

    public async Task<bool> Handle(CreateCustomerLogoCommandRequest request, CancellationToken cancellationToken)
    {
        var customerLogo = _mapper.Map<CustomerLogo>(request.CustomerLogoViewModel);
        _unitOfWork.GenericRepository<CustomerLogo>().Add(customerLogo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Cache the newly created CustomerLogo
        var cacheKey = $"CustomerLogo:{customerLogo.Id}";
        var cachedCustomerLogo =  _mapper.Map<CustomerLogoViewModel>(customerLogo);
        await _cache.SetAsync<CustomerLogoViewModel>(cacheKey, cachedCustomerLogo, TimeSpan.FromMinutes(10));

        return true;
    }
}
