using MediatR;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Application.Features.ThingIdo.Requests.Commands;

public record CreateThingIDoCommandRequest : IRequest<Unit>
{
    public CreateThingIDoViewModel CreateThingIDoViewModel { get; init; }
}
