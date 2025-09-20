using AutoMapper;
using MediatR;
using Resume.Application.Exceptions;
using Resume.Application.Features.Portfolio.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Portfolio.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Portfolio.Handlers.Commands;

public class CreatePortfolioCommandRequestHandler : IRequestHandler<CreatePortfolioCommandRequest, bool>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePortfolioCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(CreatePortfolioCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreatePortfolioValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.CreatePortfolioViewModel, cancellationToken);
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var porfolio = _mapper.Map<Resume.Domain.Entity.Portfolio>(request.CreatePortfolioViewModel);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Portfolio>().Add(porfolio);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
