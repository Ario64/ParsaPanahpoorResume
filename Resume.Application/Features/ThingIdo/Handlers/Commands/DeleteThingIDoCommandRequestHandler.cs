using MediatR;
using Resume.Application.Features.ThingIdo.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ThingIdo.Handlers.Commands;

public class DeleteThingIDoCommandRequestHandler : IRequestHandler<DeleteThingIDoCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public DeleteThingIDoCommandRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<bool> Handle(DeleteThingIDoCommandRequest request, CancellationToken cancellationToken)
    {
        var thingIDO = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ThingIDo>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.ThingIDo>().Delete(thingIDO);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
