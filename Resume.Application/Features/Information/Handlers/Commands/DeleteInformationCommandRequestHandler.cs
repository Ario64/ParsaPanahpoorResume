using MediatR;
using Resume.Application.Features.Information.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Information.Handlers.Commands;

public class DeleteInformationCommandRequestHandler : IRequestHandler<DeleteInformationCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public DeleteInformationCommandRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<bool> Handle(DeleteInformationCommandRequest request, CancellationToken cancellationToken)
    {
        var information = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Information>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Information>().Delete(information);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
