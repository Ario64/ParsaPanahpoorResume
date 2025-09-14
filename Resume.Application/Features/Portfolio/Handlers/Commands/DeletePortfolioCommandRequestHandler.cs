using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.Portfolio.Validators;
using Resume.Application.ViewModels.Portfolio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Portfolio.Handlers.Commands;

public class DeletePortfolioCommandRequestHandler : IRequestHandler<DeletePortfolioCommandRequest, bool>
{

    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePortfolioCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(DeletePortfolioCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new DeletePortfolioValidator();
        var validationResult = await validator.ValidateAsync(new DeletePortfolioViewModel() { Id = request.Id}, cancellationToken);
        if (validationResult.IsValid == false)
        {
            throw new Exception();
        } 

        var portfolio = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Portfolio>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Portfolio>().Delete(portfolio);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
