using MediatR;

namespace Resume.Application.Features.Education.Requests.Commands;

public record DeleteEducationCommandRequest(ulong Id): IRequest<bool>
{
   
}
