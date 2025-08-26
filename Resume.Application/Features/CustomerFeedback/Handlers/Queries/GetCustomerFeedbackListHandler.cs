using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.CustomerFeedback;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Queries;

public class GetCustomerFeedbackListRequestHandler : IRequestHandler<GetCustomerFeedbackListRequest, List<CustomerFeedbackViewModel>>
{
    #region Constructort

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCustomerFeedbackListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async  Task<List<CustomerFeedbackViewModel>> Handle(GetCustomerFeedbackListRequest request, CancellationToken cancellationToken)
    {
        var customerFeedbackList = _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>().GetAll(cancellationToken);
        return _mapper.Map<List<CustomerFeedbackViewModel>>(customerFeedbackList);
    }
}