using AutoMapper;
using MediatR;
using Resume.Application.Features.ThingIdo.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.ThingIDo;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ThingIdo.Handlers.Queries;

public class GetThingIDoRequestHandler : IRequestHandler<GetThingIDoRequest, ThingIdoViewModel>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetThingIDoRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<ThingIdoViewModel> Handle(GetThingIDoRequest request, CancellationToken cancellationToken)
    {
        var thingIDo = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ThingIDo>().GetAsync(request.Id, cancellationToken);
        return _mapper.Map<ThingIdoViewModel>(thingIDo);
    }
}
