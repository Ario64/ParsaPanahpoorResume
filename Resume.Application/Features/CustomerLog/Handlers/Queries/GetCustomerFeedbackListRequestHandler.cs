using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Resume.Application.Features.CustomerLog.Requests.Queries;
using Resume.Application.UnitOfWork;
using Resume.Domain.Entity;
using Resume.Domain.ViewModels.CustomerLogo;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Resume.Application.Features.CustomerLog.Handlers.Queries;

public class GetCustomerFeedbackListRequestHandler : IRequestHandler<GetCustomerLogoListRequest, List<CustomerLogoViewModel>>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCustomerFeedbackListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #endregion

    public async Task<List<CustomerLogoViewModel>> Handle(GetCustomerLogoListRequest request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.GenericRepository<CustomerLogo>().GetAll(cancellationToken);
        int skip = (request.pageId - 1) * request.pageSize;
        int take = request.pageSize;

        var result = await query.OrderByDescending(o=>o.Id)
                                .Skip(skip)
                                .Take(take)
                                .ProjectTo<CustomerLogoViewModel>(_mapper.ConfigurationProvider)
                                .ToListAsync(cancellationToken);
        return result;
    }
}