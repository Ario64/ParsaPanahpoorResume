using AutoMapper;
using MediatR;
using Resume.Application.Features.ReservationDateTime.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ReservationDateTime.Handlers.Commands;

public class EditReservationDateTimeCommandRequestHandler : IRequestHandler<EditReservationDateTimeCommandRequest, bool>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public EditReservationDateTimeCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(EditReservationDateTimeCommandRequest request, CancellationToken cancellationToken)
    {
        var reservationDateTime = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDateTime>().GetAsync(request.Id, cancellationToken);
        _mapper.Map(request.EditReservationDateTimeViewModel, reservationDateTime);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDateTime>().Update(reservationDateTime);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
