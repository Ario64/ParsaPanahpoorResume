using Resume.Application.Services.Interfaces;
using Resume.Application.UnitOfWork;
using Resume.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implementations
{
    public class CustomerFeedbackService : ICustomerFeedbackService
    {
        #region Constructor

        private readonly IUnitOfWork _unitOfWork;

        public CustomerFeedbackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        //Get customer feedback by ID
        public async Task<CustomerFeedback> GetCustomerFeedbackById(ulong id)
        {
            return await _unitOfWork.GenericRepository<CustomerFeedback>().GetAsync(id);
        }

        //Get customer feedback list
        public async Task<IReadOnlyList<CustomerFeedback>> GetCustomerFeedbackList()
        {
            var customerFeedbackList = await _unitOfWork.GenericRepository<CustomerFeedback>().GetAllAsync();
            return customerFeedbackList;
        }

        //Create customer feedback
        public async Task CreateCustomerFeedback(CustomerFeedback customerFeedback)
        {
            await _unitOfWork.GenericRepository<CustomerFeedback>().Add(customerFeedback);
        }

        //Edit customer feedback
        public async Task EditCustomerFeedback(ulong id)
        {
            var customerFeedback = await GetCustomerFeedbackById(id);
            await _unitOfWork.GenericRepository<CustomerFeedback>().UpdateAsync(customerFeedback);
        }

        //Delete customer feedback
        public async Task DeleteCustomerFeedback(ulong id)
        {
            var customerFeedback = await GetCustomerFeedbackById(id);
            await _unitOfWork.GenericRepository<CustomerFeedback>().DeleteAsync(customerFeedback);
        }
    }
}
