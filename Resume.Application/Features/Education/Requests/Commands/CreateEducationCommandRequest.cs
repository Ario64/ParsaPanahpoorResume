using MediatR;
using Resume.Application.ViewModels.Education;

namespace Resume.Application.Features.Education.Requests.Commands;

public record CreateEducationCommandRequest(CreateEducationViewModel CreateEducationViewModel) : IRequest<bool>
{
 
}
