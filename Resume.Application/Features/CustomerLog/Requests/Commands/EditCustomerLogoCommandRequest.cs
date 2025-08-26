using MediatR;
using Resume.Domain.ViewModels.CustomerLogo;

namespace Resume.Application.Features.CustomerLog.Requests.Commands;

public record EditCustomerLogoCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
    public EditCustomerLogoViewModel editCustomerLogoViewModel { get; set; }
}
