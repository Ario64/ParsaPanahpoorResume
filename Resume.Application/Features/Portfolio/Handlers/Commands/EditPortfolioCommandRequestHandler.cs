using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Portfolio.Handlers.Commands;

public class EditPortfolioCommandRequestHandler : IRequestHandler<EditPortfolioCommandRequest, bool>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public EditPortfolioCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(EditPortfolioCommandRequest request, CancellationToken cancellationToken)
    {
        var portfolio = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Portfolio>().GetAsync(request.Id, cancellationToken);
        _mapper.Map(request.EditPortfolioViewModel, portfolio);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Portfolio>().Update(portfolio);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
