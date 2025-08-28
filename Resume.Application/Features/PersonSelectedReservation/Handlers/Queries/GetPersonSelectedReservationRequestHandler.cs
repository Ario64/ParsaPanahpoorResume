using AutoMapper;
using MediatR;
using Resume.Application.Features.PersonSelectedReservation.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.PersonSelectedReservation;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PersonSelectedReservation.Handlers.Queries;

public class GetPersonSelectedReservationRequestHandler : IRequestHandler<GetPersonSelectedReservationRequest, PersonSelectedReservationViewModel>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPersonSelectedReservationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<PersonSelectedReservationViewModel> Handle(GetPersonSelectedReservationRequest request, CancellationToken cancellationToken)
    {
        var person = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Reservation.PersonSelectedReservation>()
                                      .GetAsync(request.Id, cancellationToken);

        return _mapper.Map<PersonSelectedReservationViewModel>(person);
    }
}
