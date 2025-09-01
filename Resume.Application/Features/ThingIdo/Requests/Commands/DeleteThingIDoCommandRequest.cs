using MediatR;

namespace Resume.Application.Features.ThingIdo.Requests.Commands;

public record DeleteThingIDoCommandRequest(long Id) : IRequest<bool>
{
   
}
