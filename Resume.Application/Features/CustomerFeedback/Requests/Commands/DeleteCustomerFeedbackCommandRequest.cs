using MediatR;

namespace Resume.Application.Features.CustomerFeedback.Requests.Commands;

public record DeleteCustomerFeedbackCommandRequest(ulong Id): IRequest<bool>
{
}