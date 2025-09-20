using AutoMapper;
using MediatR;
using Resume.Application.Exceptions;
using Resume.Application.Features.ReservationDate.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.ReservationDate;
using Resume.Application.ViewModels.ReservationDate.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ReservationDate.Handlers.Commands;

public class DeleteReservationDateTimeCommandRequestHandler : IRequestHandler<DeleteReservationDateTimeCommandRequest, bool>
{

    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReservationDateTimeCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(DeleteReservationDateTimeCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new DeleteReservationDateValidator();
        var validationResult = await validator.ValidateAsync(new DeleteReservationDateViewModel() { Id = request.Id}, cancellationToken);
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var reservationDate = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDate>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDate>().Delete(reservationDate);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
