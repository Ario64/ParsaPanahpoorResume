using System;
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
using Resume.Domain.ViewModels.Pagination;

namespace Resume.Application.Features.CustomerLog.Handlers.Queries;

public class GetCustomerFeedbackListRequestHandler : IRequestHandler<GetCustomerLogoListRequest, PagedResult<CustomerLogoViewModel>>
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

    public async Task<PagedResult<CustomerLogoViewModel>> Handle(GetCustomerLogoListRequest request, CancellationToken cancellationToken)
    {
       
    }
}