using AutoMapper;
using MediatR;
using Resume.Application.Features.ThingIdo.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.ThingIDo;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ThingIdo.Handlers.Queries;

public class GetThingIDoListRequestHandler : IRequestHandler<GetThingIDoListRequest, IReadOnlyList<ThingIdoViewModel>>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetThingIDoListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<IReadOnlyList<ThingIdoViewModel>> Handle(GetThingIDoListRequest request, CancellationToken cancellationToken)
    {
        var thingIDoList = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ThingIDo>()
                                             .GetAllAsync(cancellationToken);

        var thingIDoListViewModel = _mapper.Map<IReadOnlyList<ThingIdoViewModel>>(thingIDoList);

        return thingIDoListViewModel;
    }

}
