using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Commands;
using Resume.Application.ICacheService;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.CustomerFeedback;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Commands;

public class CreateCustomerFeedbackCommandRequestHandler : IRequestHandler<CreateCustomerFeedbackCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheServices _cache;

    public CreateCustomerFeedbackCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheServices cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cache;
    }

    #endregion

    public async Task<bool> Handle(CreateCustomerFeedbackCommandRequest request, CancellationToken cancellationToken)
    {
        var customerFeedback = _mapper.Map<Domain.Entity.CustomerFeedback>(request.CreateCustomerFeedbackViewModel);
        _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>().Add(customerFeedback);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        //Map to view model to save in cache
        var customerFeedbackViewModel = _mapper.Map<Domain.ViewModels.CustomerFeedback.CustomerFeedbackViewModel>(customerFeedback);

        var cacheKey = $"CustomerFeedback_{customerFeedback.Id}";
        await _cache.SetAsync<CustomerFeedbackViewModel>(cacheKey, customerFeedbackViewModel, TimeSpan.FromMinutes(5));

        //Remove list from cache to get updated list
        await _cache.RemoveAsync("CustomerFeedbackList_List");

        return true;
    }
}