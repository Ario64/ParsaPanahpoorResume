using Resume.Domain.Entity;
using Resume.Domain.ViewModels.CustomerFeedback;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface ICustomerFeedbackService
    {
        Task<CustomerFeedback> GetCustomerFeedbackById(ulong id);
        Task<IReadOnlyList<CustomerFeedback>> GetCustomerFeedbackList();
        Task CreateCustomerFeedback(CustomerFeedback customerFeedback);
        Task EditCustomerFeedback(ulong id);
        Task DeleteCustomerFeedback(ulong id);
    }
}
