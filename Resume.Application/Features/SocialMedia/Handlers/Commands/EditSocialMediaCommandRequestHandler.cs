using AutoMapper;
using MediatR;
using Resume.Application.Features.SocialMedia.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.SocialMedia.Handlers.Commands;

public class EditThingIDoCommandRequestHandler : IRequestHandler<EditThingIDoCommandRequest, Unit>
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

    public async Task<Unit> Handle(EditThingIDoCommandRequest request, CancellationToken cancellationToken)
    {
        var socialMedia = await _unitOfWork.GenericRepository<Resume.Domain.Entity.SocialMedia>().GetAsync(request.Id, cancellationToken);
        _mapper.Map(request.EditSocialMediaViewModel, socialMedia);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.SocialMedia>().Update(socialMedia);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
