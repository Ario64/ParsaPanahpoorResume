using AutoMapper;
using MediatR;
using Resume.Application.Exceptions;
using Resume.Application.Features.Message.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Message.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Message.Handlers.Commands;

public class CreateMessageCommandRequestHandler : IRequestHandler<CreateMessageCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateMessageCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(CreateMessageCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateMessageValidator();
        var validationResult = await validator.ValidateAsync(request.CreateMessageViewModel, cancellationToken);
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var message = _mapper.Map<Domain.Entity.Message>(request.CreateMessageViewModel);
        _unitOfWork.GenericRepository<Domain.Entity.Message>().Add(message);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
