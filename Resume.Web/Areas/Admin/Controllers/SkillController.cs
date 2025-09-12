using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Features.Skill.Requests.Commands;
using Resume.Application.Features.Skill.Requests.Queries;
using Resume.Application.ViewModels.Skill;
using Resume.Web.Areas.Controllers;
using System.Threading.Tasks;

namespace Resume.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : AdminBaseController
    {
        #region Constructor

        private readonly IMediator _mediator;

        public SkillController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetSkillListRequest()));
        }

        public async Task<IActionResult> LoadSkillFormModal(long? id)
        {
            var resutlt = await _mediator.Send(new GetSkillRequest(id));
            return PartialView("_SkillFormModalPartial", resutlt);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitSkillFormModal(EditSkillViewModel skill)
        {
            bool result;
            if (skill.Id == 0)
            {
                var createSkill = new CreateSkillViewModel()
                {
                    Title = skill.Title,
                    Percent = skill.Percent,
                    Order = skill.Order
                };

                result = await _mediator.Send(new CreateSkillCommandRequest(createSkill));
                if (result) return new JsonResult(new { status = "Success" });
                return new JsonResult(new { status = "Error" });
            }

            result = await _mediator.Send(new EditSkillCommandRequest(skill.Id, skill));
            if (result) return new JsonResult(new { status = "Success" });
            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteSkill(long id)
        {
            var result = await _mediator.Send(new DeleteSkillCommandRequest(id));

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });

        }

    }
}
