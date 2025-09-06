using Resume.Domain.ViewModels.CustomerFeedback;
using Resume.Domain.ViewModels.CustomerLogo;
using Resume.Domain.ViewModels.ThingIDo;
using System.Collections.Generic;

namespace Resume.Domain.ViewModels.Page
{
    public class IndexPageViewModel
    {
        public IReadOnlyList<ThingIdoViewModel> ThingIDoList { get; set; }

        public IReadOnlyList<CustomerFeedbackViewModel> CustomerFeedbakcList { get; set; }

        public IReadOnlyList<CustomerLogoViewModel> CustomerLogoList { get; set; }
    }
}
