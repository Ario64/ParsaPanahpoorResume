using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Commands;
using Resume.Application.ICacheService;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Commands;

public class EditCustomerFeedbackCommandRequestHandler : IRequestHandler<EditCustomerFeedbackCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheServices _cache;

    public EditCustomerFeedbackCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheServices cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache;
    }

    #endregion

    public async Task<bool> Handle(EditCustomerFeedbackCommandRequest request, CancellationToken cancellationToken)
    {
       
        var customerFeedback = await _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>()
                                                .GetAsync(request.Id, cancellationToken);

        _mapper.Map(request.CustomerFeedbackViewModel, customerFeedback);
        _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>().Update(customerFeedback);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        //Map updated entity to view model
        var customerFeedbackViewModel = _mapper.Map<CustomerFeedbackViewModel>(customerFeedback);
        var cacheKey = $"CustomerFeedback:{customerFeedbackViewModel.Id}";

        //Set updated data in cache
        await _cache.SetAsync<CustomerFeedbackViewModel>(cacheKey, customerFeedbackViewModel, TimeSpan.FromMinutes(10));
      
        return true;
    }
}