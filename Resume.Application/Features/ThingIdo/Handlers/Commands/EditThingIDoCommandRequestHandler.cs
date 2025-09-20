using AutoMapper;
using MediatR;
using Resume.Application.Exceptions;
using Resume.Application.Features.ThingIdo.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.ThingIDo.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.ThingIdo.Handlers.Commands;

public class EditThingIDoCommandRequestHandler : IRequestHandler<EditThingIDoCommandRequest, bool>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public EditThingIDoCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(EditThingIDoCommandRequest request, CancellationToken cancellationToken)
    {

        var validator = new EditThingIDoValidator();
        var validationResult = await validator.ValidateAsync(request.EditThingIdoViewModel, cancellationToken);
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var thingIDo = await _unitOfWork.GenericRepository<Resume.Domain.Entity.ThingIDo>().GetAsync(request.Id, cancellationToken);
        _mapper.Map(request.EditThingIdoViewModel, thingIDo);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.ThingIDo>().Update(thingIDo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
