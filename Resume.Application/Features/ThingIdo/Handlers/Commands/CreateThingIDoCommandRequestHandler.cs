using AutoMapper;
using MediatR;
using Resume.Application.Features.ThingIdo.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ThingIdo.Handlers.Commands;

public class CreateThingIDoCommandRequestHandler : IRequestHandler<CreateThingIDoCommandRequest, Unit>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateThingIDoCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<Unit> Handle(CreateThingIDoCommandRequest request, CancellationToken cancellationToken)
    {
        var thingIDo = _mapper.Map<Resume.Domain.Entity.ThingIDo>(request.CreateThingIDoViewModel);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.ThingIDo>().Add(thingIDo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
