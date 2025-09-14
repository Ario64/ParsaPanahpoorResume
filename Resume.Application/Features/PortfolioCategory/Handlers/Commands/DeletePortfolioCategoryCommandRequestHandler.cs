using AutoMapper;
using MediatR;
using Resume.Application.Features.PortfolioCategory.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Portfolio.Validators;
using Resume.Application.ViewModels.Portfolio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PortfolioCategory.Handlers.Commands;

public class DeletePortfolioCategoryCommandRequestHandler : IRequestHandler<DeletePortfolioCategoryCommandRequest, bool>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePortfolioCategoryCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(DeletePortfolioCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new DeletePortfolioCategoryValidator();
        var validationResult = await validator.ValidateAsync(new DeletePortfolioCategoryViewModel() { Id = request.Id }, cancellationToken);
        if (validationResult.IsValid == false)
        {
            throw new Exception();
        }

        var portfolioCategory = await _unitOfWork.GenericRepository<Resume.Domain.Entity.PortfolioCategory>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.PortfolioCategory>().Delete(portfolioCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
