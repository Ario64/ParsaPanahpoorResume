using MediatR;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Application.Features.ThingIdo.Requests.Commands;

public record EditThingIDoCommandRequest : IRequest<bool>
{
    public long Id { get; init; }
    public EditThingIdoViewModel EditThingIdoViewModel { get; init; }

    public EditThingIDoCommandRequest(EditThingIdoViewModel editThingIdoViewModel, long id)
    {
        Id = id;
        EditThingIdoViewModel = editThingIdoViewModel;
    }
}
