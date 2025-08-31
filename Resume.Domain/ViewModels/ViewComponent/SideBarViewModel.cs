using Resume.Domain.ViewModels.Information;
using Resume.Domain.ViewModels.Pagination;
using Resume.Domain.ViewModels.SocialMedia;
using System.Collections.Generic;

namespace Resume.Domain.ViewModels.ViewComponent
{
    public class SideBarViewModel
    {
        public PagedResult<SocialMediaViewModel> SocialMedias { get; set; }

        public InformationViewModel information { get; set; }

    }
}
