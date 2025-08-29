using AutoMapper;
using MediatR;
using Resume.Application.Features.ReservationDate.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.ReservationDate;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ReservationDate.Handlers.Queries;

public class GetReservationDateTimeRequestHandler : IRequestHandler<GetReservationDateTimeRequest, ReservationDateViewModel>
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

    public async Task<ReservationDateViewModel> Handle(GetReservationDateTimeRequest request, CancellationToken cancellationToken)
    {
        var reservationDate = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDate>().GetAsync(request.Id, cancellationToken);
        return _mapper.Map<ReservationDateViewModel>(reservationDate);
    }
}
