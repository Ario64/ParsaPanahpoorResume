using Resume.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface ICustomerLogoService
    {
        Task<List<CustomerLogo>> GetCustomerLogosForIndexPage();
    }
}
