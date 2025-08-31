using Resume.Domain.ViewModels.CustomerFeedback;
using Resume.Domain.ViewModels.CustomerLogo;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Domain.ViewModels.Page
{
    public class IndexPageViewModel
    {
        public PagedResult<ThingIdoViewModel> ThingIDoList { get; set; }

        public PagedResult<CustomerFeedbackViewModel> CustomerFeedbakcList { get; set; }

        public PagedResult<CustomerLogoViewModel> CustomerLogoList { get; set; }
    }
}
