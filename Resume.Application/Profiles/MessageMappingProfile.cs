using AutoMapper;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Message;

namespace Resume.Application.Profiles;

public class MessageMappingProfile : Profile
{
    public MessageMappingProfile()
    {
        #region Message Profile

        CreateMap<Message, MessageViewModel>();
        CreateMap<Message, CreateMessageViewModel>().ReverseMap();
        CreateMap<Message, DeleteMessageViewModel>().ReverseMap();
        CreateMap<Message, EditMessageViewModel>().ReverseMap();

        #endregion
    }
}