using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerLog.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Domain.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerLog.Handlers.Commands;

public class EditCustomerLogoCommandRequestHandler : IRequestHandler<EditCustomerLogoCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EditCustomerLogoCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(EditCustomerLogoCommandRequest request, CancellationToken cancellationToken)
    {
        var customerLogo = await _unitOfWork.GenericRepository<CustomerLogo>().GetAsync(request.Id);
        _mapper.Map(request.EditCustomerLogoViewModel, customerLogo);
        _unitOfWork.GenericRepository<CustomerLogo>().Update(customerLogo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
