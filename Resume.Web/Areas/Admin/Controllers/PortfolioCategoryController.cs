using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Features.Portfolio.Requests.Commands;
using Resume.Application.Features.Portfolio.Requests.Queries;
using Resume.Application.Features.PortfolioCategory.Requests.Commands;
using Resume.Domain.ViewModels.Portfolio;
using Resume.Web.Areas.Controllers;
using System.Threading.Tasks;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class PortfolioCategoryController : AdminBaseController
    {
        #region Constructor

        private readonly IMediator _mediator;

        public PortfolioCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetPortfolioListRequest()));
        }

        public async Task<IActionResult> LoadPortfolioCategoryFormModal(CreatePortfolioCategoryViewModel portolioCategory)
        {
            var result = await _mediator.Send(new CreatePortfolioCategoryCommandRequest(portolioCategory));
            return PartialView("_PortfolioCategorFormModalPartial", result);
        }

        public async Task<IActionResult> SubmitPortfolioCategoryFormModal(ulong id, EditPortfolioCategoryViewModel portfolioCategory)
        {
            var result = await _mediator.Send(new EditPortfolioCategoryCommandRequest(id, portfolioCategory));

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeletePortfolioCategory(ulong id)
        {
            var result = await _mediator.Send(new DeletePortfolioCategoryCommandRequest(id));

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

    }
}
