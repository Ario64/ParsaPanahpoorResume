using MediatR;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Application.Features.Experience.Requests.Commands;

public record EditExperienceCommandRequest : IRequest<bool>
{
    public long Id { get; init; }
    public EditExperienceViewModel  EditExperienceViewModel { get; init; }

    public EditExperienceCommandRequest(long id, EditExperienceViewModel editExperienceViewModel )
    {
        Id = id;
        EditExperienceViewModel =  editExperienceViewModel;
    }
}
