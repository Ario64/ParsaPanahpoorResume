using MediatR;
using Resume.Domain.ViewModels.CustomerLogo;

namespace Resume.Application.Features.CustomerLog.Requests.Commands;

public record CreateCustomerLogoCommandRequest : IRequest<Unit>
{
    public CreateCustomerLogoViewModel CustomerLogoViewModel { get; set; }
}
