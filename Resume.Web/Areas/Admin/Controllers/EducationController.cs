using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Features.Education.Requests.Commands;
using Resume.Application.Features.Education.Requests.Queries;
using Resume.Application.ViewModels.Education;
using Resume.Web.Areas.Controllers;
using System.Threading.Tasks;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class EducationController : AdminBaseController
    {
        #region Constructor

        private readonly IMediator _meditor;

        public EducationController(IMediator meditor)
        {
            _meditor = meditor;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _meditor.Send(new GetEducationListRequest()));
        }

        public async Task<IActionResult> LoadEducationFormModal(long? id)
        {
            var result = await _meditor.Send(new GetEducationRequest(id));

            return PartialView("_EducationFormModalPartial", result);
        }

        public async Task<IActionResult> SubmitEducationFormModal(EditEducationViewModel education)
        {
            bool result;

            if (education.Id == 0)
            {
                var createdEducation = new CreateEducationViewModel()
                {
                    Title = education.Title,
                    Description = education.Description,
                    EndDate = education.EndDate,
                    Order = education.Order,
                    StartDate = education.StartDate
                };

                 result = await _meditor.Send(new CreateEducationCommandRequest(createdEducation));

                if (result) return new JsonResult(new { status = "Success" });

                return new JsonResult(new { status = "Error" });
            }

             result = await _meditor.Send(new EditEducationCommandRequest(education.Id, education));

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteEducation(long id)
        {
            var result = await _meditor.Send(new DeleteEducationCommandRequest(id));

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

    }
}
