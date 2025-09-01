using MediatR;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Application.Features.Experience.Requests.Commands;

public record CreateExperienceCommandRequest(CreateExperienceViewModel CreateExperienceViewModel) : IRequest<bool>
{
  
}
