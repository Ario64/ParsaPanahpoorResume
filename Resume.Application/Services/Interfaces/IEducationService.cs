using Resume.Domain.Models;
using Resume.Domain.ViewModels.Education;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface IEducationService
    {
        Task<Education> GetEducationById(long id);
        Task<List<EducationViewModel>> GetAllEducations();
        Task<CreateOrEditEducationViewModel> FillCreateOrEditEducationViewModel(long id);
        Task<bool> CreateOrEditEducation(CreateOrEditEducationViewModel education);

        Task<bool> DeleteEducation(long id);

    }
}
