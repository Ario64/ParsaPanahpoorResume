using Resume.Domain.Entity;
using Resume.Domain.ViewModels.ThingIDo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface IThingIDoService
    {
        Task<ThingIDo> GetThingIDoById(long id);
        Task<List<ThingIDoListViewModel>> GetAllThingIDoForIndex();
        Task<bool> CreateOrEditThingIDo(CreateThingIDoViewModel thingIDo);
        Task<CreateThingIDoViewModel> FillCreateOrEditThingIDoViewModel(long id);
        Task<bool> DeleteThingIDo(long id);

    }
}
