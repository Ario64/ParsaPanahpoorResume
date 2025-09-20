using AutoMapper;
using MediatR;
using Resume.Application.Exceptions;
using Resume.Application.Features.PersonSelectedReservation.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.PersonSelectedReservation.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PersonSelectedReservation.Handlers.Commands
{
    public class EditPersonSelectedReservationCommandRequestHandler : IRequestHandler<EditPersonSelectedReservationCommandRequest, bool>
    {
        #region Constructor

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EditPersonSelectedReservationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        public async Task<bool> Handle(EditPersonSelectedReservationCommandRequest request, CancellationToken cancellationToken)
        {
            var validator = new EditPersonSelectedReservationValidator();
            var validationResult = await validator.ValidateAsync(request.EditPersonSelectedReservationViewModel, cancellationToken);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var person = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Reservation.PersonSelectedReservation>()
                                          .GetAsync(request.Id, cancellationToken);

            _mapper.Map(request.EditPersonSelectedReservationViewModel, person);
            _unitOfWork.GenericRepository<Resume.Domain.Entity.Reservation.PersonSelectedReservation>().Update(person);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
