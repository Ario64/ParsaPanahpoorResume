using MediatR;

namespace Resume.Application.Features.Information.Requests.Commands;

public record DeleteInformationCommandRequest(long Id) : IRequest<bool>
{
    
}
