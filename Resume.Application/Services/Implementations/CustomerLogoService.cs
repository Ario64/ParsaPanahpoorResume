using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.CustomerLogo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resume.Application.UnitOfWork;
using Resume.Domain.Entity;

namespace Resume.Application.Services.Implementations
{
    public class CustomerLogoService : ICustomerLogoService
    {
        #region Constructor

        private readonly IUnitOfWork _unitOfWork;

        public CustomerLogoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        public async Task<List<CustomerLogo>> GetCustomerLogosForIndexPage()
        {
            IReadOnlyList<CustomerLogo> customerLogos = await _unitOfWork.GenericRepository<CustomerLogo>().GetAllAsync();
               customerLogos.OrderBy(c => c.Order)
                .Select(c => new CustomerLogoListViewModel()
                {
                    Id = c.Id,
                    Link = c.Link,
                    Logo = c.Logo,
                    LogoAlt = c.LogoAlt,
                    Order = c.Order
                })
                .ToListAsync();

            return customerLogos;
        }


    }
}
