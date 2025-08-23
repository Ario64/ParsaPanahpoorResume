using MediatR;

namespace Resume.Application.Features.CustomerFeedback.Requests.Commands;

public class DeleteCustomerFeedbackCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
}