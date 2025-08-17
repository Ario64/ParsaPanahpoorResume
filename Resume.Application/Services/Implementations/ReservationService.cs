using Resume.Application.Services.Interfaces;
using Resume.Domain.Entity.Reservation;
using Resume.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Resume.Application.Convertors;

namespace Resume.Application.Services.Implementations;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    public ReservationService(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<List<ReservationDate>> GetListOfReservations(CancellationToken cancellationToken)
        => await _reservationRepository.GetListOfReservations(cancellationToken);

    public async Task<bool> CreateReservation(string date , 
        CancellationToken cancellationToken)
    {
        await _reservationRepository.AddReservationDate(new ReservationDate()
        {
            CreateDate = DateTime.Now , 
            Date = date.ToMiladiDateTime()
        } , cancellationToken);
        await _reservationRepository.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<ReservationDate> GetReservationDate(ulong reservationDateId,
        CancellationToken cancellationToken)
        => await _reservationRepository.GetReservationDate(reservationDateId, cancellationToken);

    public async Task<bool> EditReservationDate(ulong reservationDateId ,
        string date ,   
        CancellationToken cancellationToken)
    {
        //Find original record 
        var originalRecord = await _reservationRepository.GetReservationDate(reservationDateId , cancellationToken);
        if (originalRecord == null)
            return false;

        originalRecord.Date = date.ToMiladiDateTime();

        _reservationRepository.Update(originalRecord);
        await _reservationRepository.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteReservationDate(ulong reservationDateId,
        CancellationToken cancellationToken)
    {
        //Find original record 
        var originalRecord = await _reservationRepository.GetReservationDate(reservationDateId, cancellationToken);
        if (originalRecord == null)
            return false;

        originalRecord.IsDelete = true;

        _reservationRepository.Update(originalRecord);
        await _reservationRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}
