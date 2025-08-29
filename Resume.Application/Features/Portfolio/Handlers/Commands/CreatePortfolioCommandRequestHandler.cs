using AutoMapper;
using MediatR;
using Resume.Application.Features.Portfolio.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Portfolio.Handlers.Commands;

public class CreatePortfolioCommandRequestHandler : IRequestHandler<CreatePortfolioCommandRequest, Unit>
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

    public async Task<Unit> Handle(CreatePortfolioCommandRequest request, CancellationToken cancellationToken)
    {
        var porfolio = _mapper.Map<Resume.Domain.Entity.Portfolio>(request.CreatePortfolioViewModel);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Portfolio>().Add(porfolio);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
