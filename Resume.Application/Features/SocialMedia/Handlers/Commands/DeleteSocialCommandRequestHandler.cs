using MediatR;
using Resume.Application.Features.SocialMedia.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.SocialMedia.Handlers.Commands;

public class DeleteSocialCommandRequestHandler : IRequestHandler<DeleteSocialCommandRequest, Unit>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public DeleteSocialCommandRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<Unit> Handle(DeleteSocialCommandRequest request, CancellationToken cancellationToken)
    {
        var socialMedia = await _unitOfWork.GenericRepository<Resume.Domain.Entity.SocialMedia>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.SocialMedia>().Delete(socialMedia);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
