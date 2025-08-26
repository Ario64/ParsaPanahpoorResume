using MediatR;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Application.Features.CustomerFeedback.Requests.Commands;

public class EditCustomerFeedbackCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
    public EditCustomerFeedbackViewModel CustomerFeedbackViewModel { get; set; }
}