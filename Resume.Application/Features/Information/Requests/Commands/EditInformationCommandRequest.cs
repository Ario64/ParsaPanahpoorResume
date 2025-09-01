using MediatR;
using Resume.Domain.ViewModels.Information;

namespace Resume.Application.Features.Information.Requests.Commands;

public record EditInformationCommandRequest(long Id, EditInformationViewModel EditInformationViewModel) : IRequest<bool>
{
 
}
