using AutoMapper;
using FluentValidation;
using MediatR;
using Resume.Application.Features.PersonSelectedReservation.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.PersonSelectedReservation.Validators;
using Resume.Domain.ViewModels.PersonSelectedReservation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PersonSelectedReservation.Handlers.Commands;

public class DeletePersonSelectedReservationCommandRequestHandler : IRequestHandler<DeletePersonSelectedReservationCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeletePersonSelectedReservationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(DeletePersonSelectedReservationCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new DeletePersonSelectedReservationValidator();
        var validationResult = await validator.ValidateAsync(new DeletePersonSelectedReservationViewModel() { Id = request.Id}, cancellationToken);
        if (validationResult.IsValid == false)
        {
            throw new Exception();
        }

        var person = await _unitOfWork.GenericRepository<Domain.Entity.Reservation.PersonSelectedReservation>()
                                     .GetAsync(request.Id, cancellationToken);

        _unitOfWork.GenericRepository<Domain.Entity.Reservation.PersonSelectedReservation>().Delete(person);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
