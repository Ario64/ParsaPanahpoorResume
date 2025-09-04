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

public class EditCustomerLogoCommandRequestHandler : IRequestHandler<EditCustomerLogoCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheServices _cache;

    public EditCustomerLogoCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheServices cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache; 
    }

    #endregion

    public async Task<bool> Handle(EditCustomerLogoCommandRequest request, CancellationToken cancellationToken)
    {
        var customerLogo = await _unitOfWork.GenericRepository<CustomerLogo>().GetAsync(request.Id);
        _mapper.Map(request.EditCustomerLogoViewModel, customerLogo);
        _unitOfWork.GenericRepository<CustomerLogo>().Update(customerLogo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var cacheKey = $"CustomerLog:{customerLogo.Id}";
        var cachedCustomerLogo = _mapper.Map<CustomerLogoViewModel>(customerLogo);
        await _cache.SetAsync<CustomerLogoViewModel>(cacheKey, cachedCustomerLogo, TimeSpan.FromMinutes(10));

        return true;
    }
}
