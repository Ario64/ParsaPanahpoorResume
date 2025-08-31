using MediatR;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Application.Features.ThingIdo.Requests.Commands;

public record CreateThingIDoCommandRequest(CreateThingIDoViewModel CreateThingIDoViewModel) : IRequest<bool>
{

}
