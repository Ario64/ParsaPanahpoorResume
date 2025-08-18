﻿using Resume.Application.Services.Interfaces;
using Resume.Domain.Entity.Reservation;
using Resume.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Resume.Application.Convertors;
using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Reservation;

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

    public async Task<CreateOrUpdateReservationViewModel> FillCreateOrUpdateReservationViewModel(ulong id , 
        CancellationToken cancellationToken)
    {
        if (id == 0) 
            return new CreateOrUpdateReservationViewModel() { Id = 0 };

        ReservationDate reservationDate = await GetReservationDate(id , cancellationToken);

        if (reservationDate == null) 
            return new CreateOrUpdateReservationViewModel() { Id = 0 };

        return new CreateOrUpdateReservationViewModel()
        {
            Id = reservationDate.Id,
            ReservationDate = reservationDate.Date.ToShamsi(),
        };
    }

    public async Task<bool> CreateOrEditReservationDate(CreateOrUpdateReservationViewModel reservationDate ,
        CancellationToken cancellationToken)
    {
        if (reservationDate.Id == 0)
        {
            var newReservationDate = new ReservationDate()
            {
                Date = reservationDate.ReservationDate.ToMiladiDateTime()
            };

            await _reservationRepository.AddReservationDate(newReservationDate , cancellationToken);
            await _reservationRepository.SaveChangesAsync(cancellationToken);
            return true;
        }

        ReservationDate currentReservationDate = await GetReservationDate(reservationDate.Id , cancellationToken);

        if (currentReservationDate == null) 
            return false;

        currentReservationDate.Date = reservationDate.ReservationDate.ToMiladiDateTime();

        _reservationRepository.Update(currentReservationDate);
        await _reservationRepository.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteReservationDate(ulong id , CancellationToken cancellationToken)
    {
        ReservationDate reservationDate = await GetReservationDate(id , cancellationToken);
        if (reservationDate == null) 
            return false;

        reservationDate.IsDelete = true;

        _reservationRepository.Update(reservationDate);
        await _reservationRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}
