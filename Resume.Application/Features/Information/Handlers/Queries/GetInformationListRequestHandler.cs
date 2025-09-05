using AutoMapper;
using MediatR;
using Resume.Application.Features.Information.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Information;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Information.Handlers.Queries;

public class GetInformationListRequestHandler : IRequestHandler<GetInformationListRequest, IReadOnlyList<InformationViewModel>>
{
    #region

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetInformationListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<IReadOnlyList<InformationViewModel>> Handle(GetInformationListRequest request, CancellationToken cancellationToken)
    {
        var informationList = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Information>()
                                               .GetAllAsync(cancellationToken);

        var informationListViewModel = _mapper.Map<IReadOnlyList<InformationViewModel>>(informationList);

        return informationListViewModel;

    }  
}      
       