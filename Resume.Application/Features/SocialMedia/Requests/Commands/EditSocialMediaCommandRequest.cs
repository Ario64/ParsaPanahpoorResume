using MediatR;
using Resume.Application.ViewModels.SocialMedia;

namespace Resume.Application.Features.SocialMedia.Requests.Commands;

public record EditSocialMediaCommandRequest : IRequest<bool>
{
    public long Id { get; init; }
    public SocialMediaViewModel EditSocialMediaViewModel { get; init; }

    public EditSocialMediaCommandRequest(long id, SocialMediaViewModel socialMediaViewModel)
    {
        Id = id;
        EditSocialMediaViewModel = socialMediaViewModel;
    }
}
