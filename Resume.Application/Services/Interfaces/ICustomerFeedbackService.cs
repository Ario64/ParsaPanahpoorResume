using Resume.Domain.Entity;
using Resume.Domain.ViewModels.CustomerFeedback;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface ICustomerFeedbackService
    {
        Task<CustomerFeedbackViewModel> GetCustomerFeedbackById(ulong id);
        Task<IReadOnlyList<CustomerFeedbackViewModel>> GetCustomerFeedbackList();
        Task CreateCustomerFeedback(CreateCustomerFeedbackViewModel customerFeedback);
        Task EditCustomerFeedback(ulong id);
        Task DeleteCustomerFeedback(ulong id);
    }
}
