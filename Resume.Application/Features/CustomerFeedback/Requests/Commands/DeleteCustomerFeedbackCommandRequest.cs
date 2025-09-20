using MediatR;
using Resume.Application.Responses;

namespace Resume.Application.Features.CustomerFeedback.Requests.Commands;

public record DeleteCustomerFeedbackCommandRequest(long Id): IRequest<BaseCommandResponse>
{
}