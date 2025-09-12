using MediatR;
using Resume.Application.ViewModels.Information;

namespace Resume.Application.Features.Information.Requests.Queries;

public record GetInformationRequest() : IRequest<InformationViewModel>
{
   
}
