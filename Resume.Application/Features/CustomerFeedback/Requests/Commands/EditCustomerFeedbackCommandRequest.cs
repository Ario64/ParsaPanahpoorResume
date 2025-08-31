using MediatR;
using Resume.Domain.ViewModels.CustomerFeedback;

namespace Resume.Application.Features.CustomerFeedback.Requests.Commands;

public class EditCustomerFeedbackCommandRequest : IRequest<bool>
{
    public ulong Id { get; set; }
    public EditCustomerFeedbackViewModel CustomerFeedbackViewModel { get; set; }

    public EditCustomerFeedbackCommandRequest(ulong id, EditCustomerFeedbackViewModel editCustomerFeedbackViewModel)
    {
        Id = id;
        CustomerFeedbackViewModel = editCustomerFeedbackViewModel;
    }
}