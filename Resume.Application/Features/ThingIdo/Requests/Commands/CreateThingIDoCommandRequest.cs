using MediatR;
using Resume.Application.ViewModels.ThingIDo;

namespace Resume.Application.Features.ThingIdo.Requests.Commands;

public record CreateThingIDoCommandRequest(CreateThingIDoViewModel CreateThingIDoViewModel) : IRequest<bool>
{

}
