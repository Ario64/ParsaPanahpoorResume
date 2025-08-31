using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Eetensions;
using Resume.Application.Features.CustomerFeedback.Requests.Commands;
using Resume.Application.Features.CustomerFeedback.Requests.Queries;
using Resume.Application.Generator;
using Resume.Application.StaticTools;
using Resume.Domain.ViewModels.CustomerFeedback;
using Resume.Web.Areas.Controllers;
using System.IO;
using System.Threading.Tasks;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class CustomerFeedbackController : AdminBaseController
    {
        #region Constructor

        private readonly IMediator _mediator;

        public CustomerFeedbackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetCustomerFeedbackListRequest(1,10)));
        }

        public async Task<IActionResult> LoadCustomrFeedbackFormModal(ulong id)
        {
            var result = await _mediator.Send(new GetCustomerFeedbackRequest(id));
            return PartialView("_CustomerFeedbackFormModalPartial", result);
        }

        public async Task<IActionResult> SubmitCustomerFeedbackFormModal(CreateCustomerFeedbackViewModel customerFeedback)
        {
            var result = await _mediator.Send(new CreateCustomerFeedbackCommandRequest(customerFeedback));

            if (result)
            {
                return new JsonResult(new { status = "Success" });
            }

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteCustomerFeedback(ulong id)
        {
            var result = await _mediator.Send(new DeleteCustomerFeedbackCommandRequest(id));

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        [HttpPost]
        public async Task<IActionResult> UploadCustomerFeedbackImageAjax(IFormFile file)
        {
            if (file !=null)
            {
                if (Path.GetExtension(file.FileName) == ".png" || Path.GetExtension(file.FileName) == ".jpeg" || Path.GetExtension(file.FileName) == ".jpg")
                {
                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(file.FileName);
                    await file.AddImageAjaxToServer(imageName, FilePaths.CustomerFeedbackAvatarServer);
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
