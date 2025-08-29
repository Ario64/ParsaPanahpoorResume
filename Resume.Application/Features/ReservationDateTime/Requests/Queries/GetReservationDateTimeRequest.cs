using MediatR;
using Resume.Domain.ViewModels.ReservationDateTime;

namespace Resume.Application.Features.ReservationDateTime.Requests.Queries;

public record GetSkillRequest : IRequest<ReservationDateTimeViewModel>
{
    public ulong Id { get; init; }
}
