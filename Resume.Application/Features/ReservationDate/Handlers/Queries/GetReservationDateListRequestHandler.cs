using AutoMapper;
using MediatR;
using Resume.Application.Features.ReservationDate.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.ReservationDate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ReservationDate.Handlers.Queries;

public class GetReservationDateListRequestHandler : IRequestHandler<GetReservationDateListRequest, IReadOnlyList<ReservationDateViewModel>>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetReservationDateListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<IReadOnlyList<ReservationDateViewModel>> Handle(GetReservationDateListRequest request, CancellationToken cancellationToken)
    {
        var portfolioCategoryList = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDate>()
                                             .GetAllAsync( cancellationToken);

        var portfolioCategoryListViewModel = _mapper.Map<IReadOnlyList<ReservationDateViewModel>>(portfolioCategoryList);

        return portfolioCategoryListViewModel;
    }

}
