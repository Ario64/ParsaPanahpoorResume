using AutoMapper;
using MediatR;
using Resume.Application.Features.ReservationDateTime.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.ReservationDateTime;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ReservationDateTime.Handlers.Queries;

public class GetReservationDateTimeRequestHandler : IRequestHandler<GetReservationDateTimeRequest, ReservationDateTimeViewModel>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetReservationDateTimeRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<ReservationDateTimeViewModel> Handle(GetReservationDateTimeRequest request, CancellationToken cancellationToken)
    {
        var reservationDateTime = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDateTime>().GetAsync(request.Id, cancellationToken);
        return _mapper.Map<ReservationDateTimeViewModel>(reservationDateTime);
    }
}
