using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Features.ThingIdo.Requests.Commands;
using Resume.Application.Features.ThingIdo.Requests.Queries;
using Resume.Domain.ViewModels.ThingIDo;
using Resume.Web.Areas.Controllers;
using System.Threading.Tasks;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ThingIDoController : AdminBaseController
    {
        #region Constructor

        private readonly IMediator _mediator;

        public ThingIDoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetThingIDoListRequest()));
        }

        public async Task<IActionResult> LoadThingIDoFormModal(long? id)
        {
            var result = await _mediator.Send(new GetThingIDoRequest(id));

            return PartialView("_ThingIDoFormModalPartial", result);
        }

        public async Task<IActionResult> SubmitThingIDoFormModal(EditThingIdoViewModel model)
        {
            bool result;

            if (model.Id == 0)
            {
                var createModel = new CreateThingIDoViewModel()
                {
                    Title = model.Title,
                    ColumnLg = model.ColumnLg,
                    Description = model.Description,
                    Icon = model.Icon,
                    Order = model.Order
                };

                result = await _mediator.Send(new CreateThingIDoCommandRequest(createModel));
            }
            else
            {
                result = await _mediator.Send(new EditThingIDoCommandRequest(model, model.Id));
            }

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteThingIDO(long id)
        {
            var result = await _mediator.Send(new DeleteThingIDoCommandRequest(id));

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }


    }
}
