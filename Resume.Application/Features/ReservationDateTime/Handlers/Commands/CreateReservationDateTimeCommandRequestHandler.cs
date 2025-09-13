using AutoMapper;
using MediatR;
using Resume.Application.Features.ReservationDateTime.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.ReservationDateTime.Validators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ReservationDateTime.Handlers.Commands;

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
        var validator = new CreateReservationDateTimeValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.CreateReservationDateTimeViewModel, cancellationToken);
        if (validationResult.IsValid == false) 
        {
            throw new Exception();
        }

        var reservationDateTime = _mapper.Map<Resume.Domain.Entity.ReservationDateTime>(request.CreateReservationDateTimeViewModel);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.ReservationDateTime>().Add(reservationDateTime);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
