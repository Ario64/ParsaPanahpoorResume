using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerLog.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.Entity;
using Resume.Domain.ViewModels.CustomerLogo;

namespace Resume.Application.Features.CustomerLog.Handlers.Queries;

public class GetCustomerLogoRequestHandler : IRequestHandler<GetCustomerLogoRequest, CustomerLogoViewModel>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetCustomerLogoRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<CustomerLogoViewModel> Handle(GetCustomerLogoRequest request, CancellationToken cancellationToken)
    {
        var customerLogo = await _unitOfWork.GenericRepository<CustomerLogo>().GetAsync(request.Id, cancellationToken);
        return _mapper.Map<CustomerLogoViewModel>(customerLogo);
    }
}