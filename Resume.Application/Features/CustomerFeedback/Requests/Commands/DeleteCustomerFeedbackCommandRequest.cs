using MediatR;

namespace Resume.Application.Features.CustomerFeedback.Requests.Commands;

public record DeleteCustomerFeedbackCommandRequest(long Id): IRequest<bool>
{
}