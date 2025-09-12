using Resume.Application.ViewModels.CustomerFeedback;
using Resume.Application.ViewModels.CustomerLogo;
using Resume.Application.ViewModels.ThingIDo;
using System.Collections.Generic;

namespace Resume.Application.ViewModels.Page
{
    public class IndexPageViewModel
    {
        public IReadOnlyList<ThingIdoViewModel> ThingIDoList { get; set; }

        public IReadOnlyList<CustomerFeedbackViewModel> CustomerFeedbakcList { get; set; }

        public IReadOnlyList<CustomerLogoViewModel> CustomerLogoList { get; set; }
    }
}
