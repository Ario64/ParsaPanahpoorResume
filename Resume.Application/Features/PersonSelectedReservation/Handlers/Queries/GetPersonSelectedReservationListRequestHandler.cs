using AutoMapper;
using MediatR;
using Resume.Application.Features.PersonSelectedReservation.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.PersonSelectedReservation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.PersonSelectedReservation.Handlers.Queries;

public class GetPersonSelectedReservationListRequestHandler : IRequestHandler<GetPersonSelectedReservationListRequest, IReadOnlyList<PersonSelectedReservationViewModel>>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPersonSelectedReservationListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<IReadOnlyList<PersonSelectedReservationViewModel>> Handle(GetPersonSelectedReservationListRequest request, CancellationToken cancellationToken)
    {
        var people = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Reservation.PersonSelectedReservation>()
                                      .GetAllAsync(cancellationToken);

        var peopleViewModel = _mapper.Map<IReadOnlyList<PersonSelectedReservationViewModel>>(people);

        return peopleViewModel;
    }
}
