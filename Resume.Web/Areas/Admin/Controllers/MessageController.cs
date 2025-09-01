using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Features.Message.Requests.Commands;
using Resume.Application.Features.Message.Requests.Queries;
using Resume.Web.Areas.Controllers;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class MessageController : AdminBaseController
    {
        #region Constructor

        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetMessageListRequest()));
        }

        public async Task<IActionResult> DeleteMessage(long id)
        {
            var result = await _mediator.Send(new DeleteMessageCommandRequest(id));

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });

        }

    }
}
