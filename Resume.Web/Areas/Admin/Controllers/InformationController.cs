using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Eetensions;
using Resume.Application.Features.Information.Requests.Commands;
using Resume.Application.Generator;
using Resume.Application.StaticTools;
using Resume.Domain.ViewModels.Information;
using Resume.Web.Areas.Controllers;
using System.IO;
using System.Threading.Tasks;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class InformationController : AdminBaseController
    {
        #region Constructor

        private readonly IMediator _mediator;

        public InformationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion


        public async Task<IActionResult> LoadInformationFormModal(CreateInformationViewModel information)
        {
            var result = await _mediator.Send(new CreateInformationCommandRequest(information));
            return View("_InformationFormModalPartial", result);
        }

        public async Task<IActionResult> SubmitInformationFormModal(ulong id, EditInformationViewModel information)
        {
            var result = await _mediator.Send(new EditInformationCommandRequest(id, information) );

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        [HttpPost]
        public async Task<IActionResult> UploadInformationAvatarAjax(IFormFile file)
        {
            if (file != null)
            {
                if (Path.GetExtension(file.FileName) == ".png" || Path.GetExtension(file.FileName) == ".jpeg" || Path.GetExtension(file.FileName) == ".jpg")
                {
                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(file.FileName);
                    await file.AddImageAjaxToServer(imageName, FilePaths.AvatarServer);
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

        [HttpPost]
        public async Task<IActionResult> UploadInformationResumeAjax(IFormFile file)
        {
            if (file != null)
            {
                if (Path.GetExtension(file.FileName) == ".pdf")
                {
                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(file.FileName);
                    await file.AddImageAjaxToServer(imageName, FilePaths.ResumeServer);
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
