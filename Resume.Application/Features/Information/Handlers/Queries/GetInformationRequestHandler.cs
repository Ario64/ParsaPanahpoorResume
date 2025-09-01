using AutoMapper;
using MediatR;
using Resume.Application.Features.Information.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.ViewModels.Information;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Features.Information.Handlers.Queries;

public class GetInformationRequestHandler : IRequestHandler<GetInformationRequest, InformationViewModel>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetInformationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<InformationViewModel> Handle(GetInformationRequest request, CancellationToken cancellationToken)
    {

        if (request.Id == null)
        {
            var information = new InformationViewModel();
            return information;
        }

         var entity = await _unitOfWork.GenericRepository<Resume.Domain.Entity.Information>().GetAsync(request.Id, cancellationToken);
        return _mapper.Map<InformationViewModel>(entity);
    }
}
