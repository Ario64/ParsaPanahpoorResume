using MediatR;
using Resume.Application.ViewModels.ThingIDo;

namespace Resume.Application.Features.ThingIdo.Requests.Queries;

public record GetThingIDoRequest(long? Id) : IRequest<ThingIdoViewModel>
{
   
}
