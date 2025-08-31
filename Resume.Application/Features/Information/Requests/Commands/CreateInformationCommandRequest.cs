using MediatR;
using Resume.Domain.ViewModels.Information;

namespace Resume.Application.Features.Information.Requests.Commands;

public record CreateInformationCommandRequest(CreateInformationViewModel CreateInformationViewModel) : IRequest<bool>
{
    
}
