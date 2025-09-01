using MediatR;

namespace Resume.Application.Features.Education.Requests.Commands;

public record DeleteEducationCommandRequest(long Id): IRequest<bool>
{
   
}
