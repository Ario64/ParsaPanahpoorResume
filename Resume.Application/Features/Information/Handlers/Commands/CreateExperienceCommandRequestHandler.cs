using AutoMapper;
using MediatR;
using Resume.Application.Features.Information.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Information.Handlers.Commands;

public class CreateInformationCommandRequestHandler : IRequestHandler<CreateInformationCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateInformationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(CreateInformationCommandRequest request, CancellationToken cancellationToken)
    {
        var information = _mapper.Map<Resume.Domain.Entity.Information>(request.CreateInformationViewModel);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Information>().Add(information);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
