using MediatR;
using Resume.Domain.ViewModels.Information;

namespace Resume.Application.Features.Information.Requests.Queries;

public record GetInformationRequest : IRequest<InformationViewModel>
{
    public ulong Id { get; set; }
}
