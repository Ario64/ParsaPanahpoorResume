using AutoMapper;
using MediatR;
using Resume.Application.Features.ThingIdo.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.SocialMedia.Validators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.SocialMedia.Handlers.Commands;

public class CreateSocialMediaCommandRequestHandler : IRequestHandler<CreateSocialMediaCommandRequest, bool>
{
    #region Constructor

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSocialMediaCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<bool> Handle(CreateSocialMediaCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSocialMediaValidator();
        var validationResult = await  validator.ValidateAsync(request.SocialMediaViewModel, cancellationToken);
        if (validationResult.IsValid == false)
        {
            throw new Exception();
        }
        var social = _mapper.Map<Resume.Domain.Entity.SocialMedia>(request.SocialMediaViewModel);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.SocialMedia>().Add(social);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
