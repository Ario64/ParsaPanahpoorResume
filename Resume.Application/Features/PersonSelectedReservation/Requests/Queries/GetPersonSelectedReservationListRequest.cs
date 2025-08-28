using MediatR;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.PersonSelectedReservation;

namespace Resume.Application.Features.PersonSelectedReservation.Requests.Queries;

public  record GetPersonSelectedReservationListRequest: IRequest<PagedResult<PersonSelectedReservationViewModel>>
{
    public int page { get; init; } = 1;
    public int pageSize { get; init; } = 10;
}
