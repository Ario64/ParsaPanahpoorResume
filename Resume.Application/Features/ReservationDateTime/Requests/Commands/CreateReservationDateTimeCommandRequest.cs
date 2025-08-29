using MediatR;
using Resume.Domain.ViewModels.ReservationDateTime;

namespace Resume.Application.Features.ReservationDateTime.Requests.Commands;

public record CreateSkillCommandRequest : IRequest<Unit>
{
    public CreateReservationDateTimeViewModel CreateReservationDateTimeViewModel { get; init; }
}
