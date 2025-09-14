using MediatR;
using Resume.Application.Features.SocialMedia.Requests.Commands;
using Resume.Application.UnitOfWork;
using Resume.Application.ViewModels.SocialMedia.Validators;
using Resume.Application.ViewModels.SocialMedia;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.SocialMedia.Handlers.Commands;

public class DeleteSocialCommandRequestHandler : IRequestHandler<DeleteSocialCommandRequest, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public DeleteSocialCommandRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<bool> Handle(DeleteSocialCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSocialMediaValidator();
        var validationResult = await validator.ValidateAsync(new DeleteSocialMediaViewModel() { Id = request.Id}, cancellationToken);
        if (validationResult.IsValid == false)
        {
            throw new Exception();
        }

        var socialMedia = await _unitOfWork.GenericRepository<Resume.Domain.Entity.SocialMedia>().GetAsync(request.Id, cancellationToken);
        _unitOfWork.GenericRepository<Resume.Domain.Entity.SocialMedia>().Delete(socialMedia);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
