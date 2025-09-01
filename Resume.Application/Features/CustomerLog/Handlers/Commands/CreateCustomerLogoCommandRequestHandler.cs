using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerLog.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Domain.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerLog.Handlers.Commands;

public class CreateCustomerLogoCommandRequestHandler : IRequestHandler<CreateCustomerLogoCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCustomerLogoCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(CreateCustomerLogoCommandRequest request, CancellationToken cancellationToken)
    {
        var customerLogo = _mapper.Map<CustomerLogo>(request.CustomerLogoViewModel);
        _unitOfWork.GenericRepository<CustomerLogo>().Add(customerLogo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
