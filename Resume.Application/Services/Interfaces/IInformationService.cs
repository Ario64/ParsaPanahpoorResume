using Resume.Domain.Models;
using Resume.Domain.ViewModels.Information;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface IInformationService
    {
        Task<InformationViewModel> GetInformation();
        Task<Information> GetInformationModel();
        Task<EditInformationViewModel> FillCreateOrEditInformationViewModel();
        Task<bool> CreateOrEditInformation(EditInformationViewModel information);
    }
}
