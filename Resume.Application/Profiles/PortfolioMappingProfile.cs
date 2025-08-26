using AutoMapper;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Profiles;

public class PortfolioMappingProfile: Profile
{
    public PortfolioMappingProfile()
    {
        #region Portfolio

        CreateMap<Portfolio, CreatePortfolioViewModel>().ReverseMap();
        CreateMap<Portfolio, EditPortfolioViewModel>().ReverseMap();
        CreateMap<Portfolio, DeletePortfolioViewModel>().ReverseMap();
        CreateMap<Portfolio, PortfolioViewModel>();

        #endregion

        #region Portfolio Category

        CreateMap<PortfolioCategory, CreatePortfolioCategoryViewModel>().ReverseMap();
        CreateMap<PortfolioCategory, EditPortfolioCategoryViewModel>().ReverseMap();
        CreateMap<PortfolioCategory, DeletePortfolioCategoryViewModel>().ReverseMap();
        CreateMap<PortfolioCategory, PortfolioCategoryViewModel>().ReverseMap();
        CreateMap<PortfolioCategory, PortfolioCategoryListViewModel>().ReverseMap();

        #endregion

    }
}