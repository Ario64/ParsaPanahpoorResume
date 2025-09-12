using MediatR;
using Resume.Application.ViewModels.Information;
using System.Collections.Generic;

namespace Resume.Application.Features.Information.Requests.Queries;

public record GetInformationListRequest() : IRequest<IReadOnlyList<InformationViewModel>>
{
}
