using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Features.Information.Requests.Queries;
using Resume.Application.Features.SocialMedia.Requests.Queries;
using Resume.Domain.ViewModels.ViewComponent;
using System.Threading.Tasks;

namespace Resume.Web.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        #region Constructor

        private readonly IMediator _mediator;

        public SideBarViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            SideBarViewModel model = new SideBarViewModel()
            {
                SocialMedias = await _mediator.Send(new GetSocialMediaListRequest()),
                information = await _mediator.Send(new GetInformationRequest())
            };

            return View("SideBar", model);
        }

    }
}
