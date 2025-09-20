using AutoMapper;
using MediatR;
using Resume.Application.Features.CustomerFeedback.Requests.Commands;
using Resume.Application.ICacheService;
using Resume.Application.Responses;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.CustomerFeedback;
using Resume.Application.ViewModels.CustomerFeedback.Validators;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.CustomerFeedback.Handlers.Commands;

public class EditCustomerFeedbackCommandRequestHandler : IRequestHandler<EditCustomerFeedbackCommandRequest, BaseCommandResponse>
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

    public async Task<BaseCommandResponse> Handle(EditCustomerFeedbackCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new EditCustomerFeedbackValidator();
        var validationResult = await validator.ValidateAsync(request.CustomerFeedbackViewModel, cancellationToken);

        if (validationResult.IsValid == false)
        {
            //throw new ValidationException(validationResult);
            response.IsSuccess = false;
            response.Message = "عملیات با شکست مواجه شد !";
            response.Errors = validationResult.Errors.Select(s => s.ErrorMessage).ToList();
        }


        var customerFeedback = await _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>()
                                                .GetAsync(request.Id, cancellationToken);

        _mapper.Map(request.CustomerFeedbackViewModel, customerFeedback);
        _unitOfWork.GenericRepository<Domain.Entity.CustomerFeedback>().Update(customerFeedback);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        //Remove list to update it
        await _cache.RemoveByPatternAsync("CustomerFeedbackList");

        //Map updated entity to view model
        var customerFeedbackViewModel = _mapper.Map<CustomerFeedbackViewModel>(customerFeedback);
        var cacheKey = $"CustomerFeedback:{customerFeedbackViewModel.Id}";

        //Set updated data in cache
        await _cache.SetAsync<CustomerFeedbackViewModel>(cacheKey, customerFeedbackViewModel, TimeSpan.FromMinutes(10));

        response.IsSuccess = true;
        response.Message = "عملیات با موفقیت انجام شد.";
        response.Id = customerFeedback.Id;

        return response;
    }
}