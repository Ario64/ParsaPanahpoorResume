using MediatR;
using Resume.Domain.ViewModels.Education;

namespace Resume.Application.Features.Education.Requests.Commands;

public record CreateEducationCommandRequest : IRequest<Unit>
{
    public CreateEducationViewModel CreateEducationViewModel { get; set; }
}
