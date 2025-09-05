using AutoMapper;
using MediatR;
using Resume.Application.Features.ReservationDate.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.ReservationDateTime;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ReservationDateTime.Handlers.Queries;

public class GetReservationDateTimeListRequestHandler : IRequestHandler<GetReservationDateTimeListRequest, IReadOnlyList<ReservationDateTimeViewModel>>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetReservationDateTimeListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<IReadOnlyList<ReservationDateTimeViewModel>> Handle(GetReservationDateTimeListRequest request, CancellationToken cancellationToken)
    {
        var reservationDateTime = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDateTime>()
                                             .GetAllAsync( cancellationToken);

        var reservationDateTimeViewModel = _mapper.Map<IReadOnlyList<ReservationDateTimeViewModel>>(reservationDateTime);

        return reservationDateTimeViewModel;
    }

}
