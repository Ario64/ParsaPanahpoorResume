using Resume.Domain.ViewModels.Information;
using Resume.Domain.ViewModels.SocialMedia;
using System.Collections.Generic;

namespace Resume.Domain.ViewModels.ViewComponent
{
    public class SideBarViewModel
    {
        public IReadOnlyList<SocialMediaViewModel> SocialMedias { get; set; }

        public InformationViewModel information { get; set; }

    }
}
