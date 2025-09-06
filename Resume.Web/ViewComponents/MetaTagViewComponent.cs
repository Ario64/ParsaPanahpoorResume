using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Resume.Web.ViewComponents
{
    public class MetaTagViewComponent : ViewComponent
    {

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult<IViewComponentResult>(View("MetaTag"));
        }
    }
}
