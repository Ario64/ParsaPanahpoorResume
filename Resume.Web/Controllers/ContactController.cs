using GoogleReCaptcha.V3.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Features.Information.Requests.Queries;
using Resume.Application.Features.Message.Requests.Commands;
using Resume.Domain.ViewModels.Message;
using System.Threading.Tasks;

namespace Resume.Web.Controllers
{
    public class ContactController : Controller
    {
        #region Constructor

        private readonly IMediator _mediator;
        private readonly ICaptchaValidator _captchaValidator;
     

        public ContactController(ICaptchaValidator captchaValidator,  IMediator mediator)
        {
            _mediator = mediator;
            _captchaValidator = captchaValidator;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            ViewData["Information"] = await _mediator.Send(new GetInformationListRequest());
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CreateMessageViewModel message)
        {

            ViewData["Information"] = await _mediator.Send(new GetInformationListRequest());

            if (!await _captchaValidator.IsCaptchaPassedAsync(message.Captcha))
            {
                ViewData["FormSubmitResult"] = false;
                return View(message);
            }

            if (!ModelState.IsValid)
            {
                return View(message);
            }

            var result = await _mediator.Send(new CreateMessageCommandRequest(message));

            if (result)
            {
                ViewData["FormSubmitResult"] = true;
            }

            return View();
        }


    }
}
