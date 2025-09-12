using MediatR;
using Resume.Application.ViewModels.Experience;

namespace Resume.Application.Features.Experience.Requests.Commands;

public record CreateExperienceCommandRequest(CreateExperienceViewModel CreateExperienceViewModel) : IRequest<bool>
{
  
}
