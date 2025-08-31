using AutoMapper;
using MediatR;
using Resume.Application.Features.SocialMedia.Requests.Commands;
using Resume.Application.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.SocialMedia.Handlers.Commands;

public class EditSocialMediaCommandRequestHandler : IRequestHandler<EditSocialMediaCommandRequest, bool>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public EditSocialMediaCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(EditSocialMediaCommandRequest request, CancellationToken cancellationToken)
    {
        var socialMedia = await _unitOfWork.GenericRepository<Resume.Domain.Entity.SocialMedia>().GetAsync(request.Id, cancellationToken);
        _mapper.Map(request.EditSocialMediaViewModel, socialMedia);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.SocialMedia>().Update(socialMedia);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
