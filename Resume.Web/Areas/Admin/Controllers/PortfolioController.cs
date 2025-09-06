using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Eetensions;
using Resume.Application.Features.Portfolio.Requests.Commands;
using Resume.Application.Features.Portfolio.Requests.Queries;
using Resume.Application.Generator;
using Resume.Application.StaticTools;
using Resume.Domain.ViewModels.Portfolio;
using Resume.Web.Areas.Controllers;
using System.IO;
using System.Threading.Tasks;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class PortfolioController : AdminBaseController
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
            return View(await _mediator.Send(new GetPortfolioListRequest()));
        }

        public async Task<IActionResult> LoadPortfolioFormModal(long id)
        {
            var result = await _mediator.Send(new GetPortfolioRequest(id));
            return PartialView("_PortfolioFormModalPartial", result);
        }

        public async Task<IActionResult> SubmitPortfolioFormModal(CreatePortfolioViewModel portfolio)
        {
            var result = await _mediator.Send(new CreatePortfolioCommandRequest(portfolio));
            if (result) return new JsonResult(new { status = "Success" });
            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeletePortfolio(long id)
        {
            var result = await _mediator.Send(new DeletePortfolioCommandRequest(id));
            if (result) return new JsonResult(new { status = "Success" });
            return new JsonResult(new { status = "Error" });
        }

        [HttpPost]
        public async Task<IActionResult> UploadPortfolioImageAjax(IFormFile file)
        {
            if (file != null)
            {
                if (Path.GetExtension(file.FileName) == ".png" || Path.GetExtension(file.FileName) == ".jpeg" || Path.GetExtension(file.FileName) == ".jpg")
                {
                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(file.FileName);
                    await file.AddImageAjaxToServer(imageName, FilePaths.PortfolioServer);
                    return new JsonResult(new { status = "Success", imageName = imageName });

                }
                else
                {
                    return new JsonResult(new { status = "Error" });
                }
            }
            else
            {
                return new JsonResult(new { status = "Error" });
            }
        }

    }
}
