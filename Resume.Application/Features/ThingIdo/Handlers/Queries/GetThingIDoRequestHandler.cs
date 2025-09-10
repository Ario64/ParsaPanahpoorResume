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
        if (request.Id == null || request.Id == 0)
        {
           var thingIdoViewModel = new ThingIdoViewModel();
            return thingIdoViewModel;
        }

        var thingIDo = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ThingIDo>()
                                        .GetAsync(request.Id, cancellationToken);

        var mappedThingIDo =  _mapper.Map<ThingIdoViewModel>(thingIDo);

        return mappedThingIDo;
    }
}
