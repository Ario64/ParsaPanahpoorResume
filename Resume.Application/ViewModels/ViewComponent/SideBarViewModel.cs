using Resume.Application.ViewModels.Information;
using Resume.Application.ViewModels.SocialMedia;
using System.Collections.Generic;

namespace Resume.Application.ViewModels.ViewComponent
{
    public class SideBarViewModel
    {
        public IReadOnlyList<SocialMediaViewModel> SocialMedias { get; set; }

        public InformationViewModel information { get; set; }

    }
}
