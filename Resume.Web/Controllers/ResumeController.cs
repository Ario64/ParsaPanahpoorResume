using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Features.Education.Requests.Queries;
using Resume.Application.Features.Experience.Requests.Queries;
using Resume.Application.Features.Skill.Requests.Queries;
using Resume.Domain.ViewModels.Page;
using System.Threading.Tasks;

namespace Resume.Web.Controllers
{
    public class ResumeController : Controller
    {

        #region Constructor

        private readonly IMediator _mediator;

        public ResumeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            ResumePageViewModel model = new ResumePageViewModel()
            {
                Educations = await _mediator.Send(new GetEducationListRequest()),
                Experiences =await _mediator.Send(new GetExperienceListRequest()),
                Skills = await _mediator.Send(new GetSkillListRequest())
            };

            return View(model);
        }


    }
}
