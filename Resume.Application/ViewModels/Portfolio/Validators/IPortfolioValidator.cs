using FluentValidation;
using Resume.Application.UnitOfWork;

namespace Resume.Application.ViewModels.Portfolio.Validators;

public class IPortfolioValidator : AbstractValidator<IPortfolioViewModel>
{
    private readonly IUnitOfWork _unitOfWork; 

    public IPortfolioValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(r => r.Title).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !")
                             .MaximumLength(100)
                             .WithMessage("{PropertyName} نباید بیشتر از 100 کاراکتر باشد !");

        RuleFor(r => r.Link).MaximumLength(1000)
                            .WithMessage("{PropertyName نباید بیشتر از {MaxLength} کاراکتر باشد !}");

        RuleFor(r => r.Image).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !");

        RuleFor(r => r.ImageAlt).NotEmpty()
                                .WithMessage("{PropertyName} را وارد کنید !");

        RuleFor(r => r.Order).NotEmpty()
                             .WithMessage("{PropertyName} را وارد کنید !")
                             .GreaterThan(0)
                             .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !");

        RuleFor(r => r.PortfolioCategoryId).NotEmpty()
                                           .WithMessage("{PropertyName} را وارد کنید !")
                                           .GreaterThan(0)
                                           .WithMessage("{PropertyName} باید بزرگتر از 0 باشد !")
                                           .MustAsync(async (id, token) =>
                                           {
                                               var portfilioCategory = await _unitOfWork.PortfolioRepository.IsExist(id);
                                               return portfilioCategory;
                                           })
                                           .WithMessage("{PropertyName وجود ندارد !}");
    }
}
