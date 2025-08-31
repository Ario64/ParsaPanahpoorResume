using MediatR;
using Resume.Application.Features.Message.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Message.Handlers.Commands;

public class DeleteMessageCommandRequestHandler : IRequestHandler<DeleteMessageCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public DeleteMessageCommandRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<bool> Handle(DeleteMessageCommandRequest request, CancellationToken cancellationToken)
    {
        var message = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Message>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.Message>().Delete(message);
        await _unitOfWork.SaveChangesAsync(cancellationToken);  
        return true;
    }
}
