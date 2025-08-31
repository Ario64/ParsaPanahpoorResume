using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Features.CustomerFeedback.Requests.Queries;
using Resume.Application.Features.CustomerLog.Requests.Queries;
using Resume.Application.Features.ThingIdo.Requests.Queries;
using Resume.Domain.ViewModels.Page;
using System.Threading.Tasks;

namespace Resume.Web.Controllers
{
    public class HomeController : Controller
    {

        #region Constructor

        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task<IActionResult> Index()
        {

            IndexPageViewModel model = new IndexPageViewModel()
            {
                ThingIDoList = await _mediator.Send(new GetThingIDoListRequest()),
                CustomerFeedbakcList = await _mediator.Send(new GetCustomerFeedbackListRequest()),
                CustomerLogoList = await _mediator.Send(new GetCustomerLogoListRequest())
            };

            return View(model);

        }

    }
}
