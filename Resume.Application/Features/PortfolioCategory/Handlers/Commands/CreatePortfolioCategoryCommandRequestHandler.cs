using AutoMapper;
using MediatR;
using Resume.Application.Features.PortfolioCategory.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Portfolio.Validators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PortfolioCategory.Handlers.Commands;

public class CreatePortfolioCategoryCommandRequestHandler : IRequestHandler<CreatePortfolioCategoryCommandRequest, bool>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePortfolioCategoryCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(CreatePortfolioCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreatePortfolioCategoryValidator();
        var validationResult = await validator.ValidateAsync(request.CreatePortfolioCategoryViewModel, cancellationToken);
        if (validationResult.IsValid == false)
        {
            throw new Exception();
        }

        var porfolio = _mapper.Map<Resume.Domain.Entity.PortfolioCategory>(request.CreatePortfolioCategoryViewModel);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.PortfolioCategory>().Add(porfolio);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
