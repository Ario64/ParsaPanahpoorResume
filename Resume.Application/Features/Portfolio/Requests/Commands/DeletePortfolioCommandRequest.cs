using MediatR;

namespace Resume.Application.Features.Portfolio.Requests.Commands;

public record DeletePortfolioCategoryCommandRequest : IRequest<Unit>
{
    public ulong Id { get; set; }
}
