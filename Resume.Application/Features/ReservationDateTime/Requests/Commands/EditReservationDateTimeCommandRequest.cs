using MediatR;
using Resume.Domain.ViewModels.ReservationDateTime;

namespace Resume.Application.Features.ReservationDateTime.Requests.Commands;

public record EditSkillCommandRequest : IRequest<Unit>
{
    public ulong Id { get; init; }
    public EditReservationDateTimeViewModel EditReservationDateTimeViewModel { get; init; }
}
