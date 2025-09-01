using MediatR;
using Resume.Domain.ViewModels.CustomerLogo;

namespace Resume.Application.Features.CustomerLog.Requests.Commands;

public record EditCustomerLogoCommandRequest : IRequest<bool>
{
    public long Id { get; init; }
    public EditCustomerLogoViewModel EditCustomerLogoViewModel { get; init; }

    public EditCustomerLogoCommandRequest(long id, EditCustomerLogoViewModel editCustomerLogoViewModel)
    {
        Id = id;
        EditCustomerLogoViewModel = editCustomerLogoViewModel;
    }
}
