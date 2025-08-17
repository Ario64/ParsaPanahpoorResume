using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Implementations;
using Resume.Application.Services.Interfaces;
using Resume.Web.Areas.Controllers;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Web.Areas.Admin.Controllers;

public class ReservationController : AdminBaseController
{
    private readonly IReservationService _reservationService;
    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<IActionResult> ListOfReservationDate(CancellationToken cancellationToken = default)
        => View(await _reservationService.GetListOfReservations(cancellationToken));

    //Create (Show form , Insert Data)


    //Update (Show form , Insert Data)
    //Delete (Show form , Insert Data)
}
