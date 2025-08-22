using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Entity;
using Resume.Domain.ViewModels.CustomerFeedback;
using Resume.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.IRepository.CustomerFeedback;

namespace Resume.Application.Services.Implementations
{
    public class CustomerFeedbackService : ICustomerFeedbackService
    {
        #region Constructor

        private readonly ICustomerFeedbackRepository _customerFeedbackRepository;

        public CustomerFeedbackService(ICustomerFeedbackRepository customerFeedbackRepository)
        {
            _customerFeedbackRepository = customerFeedbackRepository;
        }

        #endregion

        //Get customer feedback by ID
        public async Task<CustomerFeedback> GetCustomerFeedbackById(ulong id)
        {
            return await _customerFeedbackRepository.GetAsync(id);
        }

        public Task<List<CustomerFeedback>> GetCustomerFeedbackListForIndex()
        {
            throw new NotImplementedException();
        }

        //Get customer feedback list
        public async Task<IReadOnlyList<CustomerFeedback>> GetCustomerFeedbackList()
        {
            var customerFeedbackList = await _customerFeedbackRepository.GetAllAsync();
            return customerFeedbackList;
        }

        //Create customer feedback
        public async Task CreateCustomerFeedback(CustomerFeedback customerFeedback)
        {
            await _customerFeedbackRepository.Add(customerFeedback);
        }

        //Edit customer feedback
        public async Task EditCustomerFeedback(ulong id)
        {
            var customerFeedback = await GetCustomerFeedbackById(id);
            await _customerFeedbackRepository.UpdateAsync(customerFeedback);
        }

        //Delete customer feedback
        public async Task DeleteCustomerFeedback(ulong id)
        {
            var customerFeedback = await GetCustomerFeedbackById(id);
            await _customerFeedbackRepository.DeleteAsync(customerFeedback);
        }
    }
}
