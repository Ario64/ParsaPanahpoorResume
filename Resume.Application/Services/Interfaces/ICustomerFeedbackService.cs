using Resume.Domain.Entity;
using Resume.Domain.ViewModels.CustomerFeedback;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface ICustomerFeedbackService
    {

        Task<CustomerFeedback> GetCustomerFeedbackById(ulong id);
        Task<List<CustomerFeedbackViewModel>> GetCustomerFeedbackForIndex();
        Task<bool> CreateOrEditCustomerFeedback(CreateCustomerFeedbackViewModel customerFeedback);
        Task<CreateCustomerFeedbackViewModel> FillCreateOrEditCustomerFeedbackViewModel(ulong id);
        Task<bool> DeleteCustomerFeedback(ulong id);

    }
}
