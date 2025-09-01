using AutoMapper;
using MediatR;
using Resume.Application.Features.ReservationDate.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ReservationDate.Handlers.Commands;

public class CreateReservationDateTimeCommandRequestHandler : IRequestHandler<CreateReservationDateTimeCommandRequest, bool>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReservationDateTimeCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(CreateReservationDateTimeCommandRequest request, CancellationToken cancellationToken)
    {
        var reservationDate = _mapper.Map<Resume.Domain.Entity.ReservationDate>(request.CreateReservationDateViewModel);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDate>().Add(reservationDate);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
