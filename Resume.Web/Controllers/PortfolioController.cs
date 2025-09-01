using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Features.Portfolio.Requests.Queries;
using Resume.Application.Features.PortfolioCategory.Requests.Queries;
using Resume.Domain.ViewModels.Page;
using System.Threading.Tasks;

namespace Resume.Web.Controllers
{
    public class PortfolioController : Controller
    {
        #region Constructor

        private readonly IMediator _mediator;

        public PortfolioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task<IActionResult> Index()
        {

            PortfolioPageViewModel model = new PortfolioPageViewModel()
            {
                Portfolios = await _mediator.Send(new GetPortfolioListRequest()),
                PortfolioCategories = await _mediator.Send(new GetPortfolioCategoryListRequest())
            };

            return View(model);
        }
    }
}
