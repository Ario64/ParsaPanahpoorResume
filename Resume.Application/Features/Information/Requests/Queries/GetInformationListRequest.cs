using MediatR;
using Resume.Domain.ViewModels.Information;
using Resume.Domain.ViewModels.Pagination;
using System.Collections.Generic;

namespace Resume.Application.Features.Information.Requests.Queries;

public record GetInformationListRequest() : IRequest<IReadOnlyList<InformationViewModel>>
{
}
