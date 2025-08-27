using MediatR;
using Resume.Application.Features.Education.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Education.Handlers.Commands;

public class DeleteEducationCommandRequestHandler : IRequestHandler<DeleteEducationCommandRequest, Unit>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public DeleteEducationCommandRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<Unit> Handle(DeleteEducationCommandRequest request, CancellationToken cancellationToken)
    {
        var education = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Education>().GetAsync(request.Id);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Education>().Delete(education);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
