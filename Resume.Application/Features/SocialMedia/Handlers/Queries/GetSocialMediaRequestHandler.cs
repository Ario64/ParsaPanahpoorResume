using AutoMapper;
using MediatR;
using Resume.Application.Features.SocialMedia.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.SocialMedia;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.SocialMedia.Handlers.Queries;

public class GetSocialMediaRequestHandler : IRequestHandler<GetSocialMediaRequest, SocialMediaViewModel>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetSocialMediaRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<SocialMediaViewModel> Handle(GetSocialMediaRequest request, CancellationToken cancellationToken)
    {
        var socialMedia = await _unitOfWork.GenericRepository<Resume.Domain.Entity.SocialMedia>().GetAsync(request.Id, cancellationToken);
        return _mapper.Map<SocialMediaViewModel>(socialMedia);
    }
}
