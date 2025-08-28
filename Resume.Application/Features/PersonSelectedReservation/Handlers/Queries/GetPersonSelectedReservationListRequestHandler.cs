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

public class GetPersonSelectedReservationListRequestHandler : IRequestHandler<GetPersonSelectedReservationListRequest, PagedResult<PersonSelectedReservationViewModel>>
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

    public async Task<PagedResult<PersonSelectedReservationViewModel>> Handle(GetPersonSelectedReservationListRequest request, CancellationToken cancellationToken)
    {
        var people = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Reservation.PersonSelectedReservation>()
                                      .GetAllAsync(request.page, request.pageSize, cancellationToken);

        var items = _mapper.Map<IReadOnlyList<PersonSelectedReservationViewModel>>(people.Items);

        return new PagedResult<PersonSelectedReservationViewModel>
        {
            Items = items,
            TotalCount = people.TotalCount,
            Page = request.page,
            PageSize = request.pageSize,
            TotalPages = people.TotalPages
        };
    }
}
