using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Features.Skill.Requests.Commands;
using Resume.Application.Features.Skill.Requests.Queries;
using Resume.Domain.ViewModels.Skill;
using Resume.Web.Areas.Controllers;
using System.Threading.Tasks;

namespace Resume.Web.Areas.Admin.Controllers
{
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

        public async Task<IActionResult> LoadSkillFormModal(long id)
        {
            var resutlt = await _mediator.Send(new GetSkillRequest(id));
            return PartialView("_SkillFormModalPartial", resutlt);
        }

        public async Task<IActionResult> SubmitSkillFormModal(CreateSkillViewModel skill)
        {
            var result = await _mediator.Send(new CreateSkillCommandRequest(skill));

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
