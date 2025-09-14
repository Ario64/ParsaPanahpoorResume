using AutoMapper;
using MediatR;
using Resume.Application.Features.ReservationDate.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.ReservationDate.Validators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ReservationDate.Handlers.Commands;

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
        var validator = new EditReservationDateValidator();
        var validationResult = await validator.ValidateAsync(request.EditReservationDateViewModel, cancellationToken);
        if (validationResult.IsValid == false)
        {
            throw new Exception();
        } 

        var reservationDate = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDate>().GetAsync(request.Id, cancellationToken);
        _mapper.Map(request.EditReservationDateViewModel, reservationDate);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDate>().Update(reservationDate);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
