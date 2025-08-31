using MediatR;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Application.Features.ThingIdo.Requests.Queries;

public record GetThingIDoRequest(ulong Id) : IRequest<ThingIdoViewModel>
{
   
}
