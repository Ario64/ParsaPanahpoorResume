using MediatR;
using Resume.Domain.ViewModels.Education;

namespace Resume.Application.Features.Education.Requests.Commands;

public record EditEducationCommandRequest : IRequest<bool>
{
    public long Id { get; init; }
    public EditEducationViewModel EditEducationViewModel { get; init; }

    public EditEducationCommandRequest(long id, EditEducationViewModel editEducationViewModel)
    {
        Id = id;
        EditEducationViewModel = editEducationViewModel;
    }
}
