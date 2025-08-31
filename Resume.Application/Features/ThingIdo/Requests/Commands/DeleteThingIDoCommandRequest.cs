using MediatR;

namespace Resume.Application.Features.ThingIdo.Requests.Commands;

public record DeleteThingIDoCommandRequest(ulong Id) : IRequest<bool>
{
   
}
