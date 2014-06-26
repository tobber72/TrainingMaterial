using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using CarRental.Client.Contracts;
using CarRental.Client.Entities;
using Core.Common.ServiceModel;

namespace CarRental.Client.Proxies
{
    [Export(typeof(IRentalService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RentalClient : UserClientBase<IRentalService>, IRentalService
    {
        public Rental RentCarToCustomer(string loginEmail, int carId, DateTime dateDueBack)
        {
            return Channel.RentCarToCustomer(loginEmail, carId, dateDueBack);
        }

        public Rental RentCarToCustomer(string loginEmail, int carId, DateTime rentalDate, DateTime dateDueBack)
        {
            return Channel.RentCarToCustomer(loginEmail, carId, rentalDate, dateDueBack);
        }

        public void AcceptCarReturn(int carId)
        {
            Channel.AcceptCarReturn(carId);
        }

        public IEnumerable<Rental> GetRentalHistory(string loginEmail)
        {
            return Channel.GetRentalHistory(loginEmail);
        }

        public Reservation GetReservation(int reservationId)
        {
            return Channel.GetReservation(reservationId);
        }

        public Reservation MakeReservation(string loginEmail, int carId, DateTime rentalDate, DateTime returnDate)
        {
            return Channel.MakeReservation(loginEmail, carId, rentalDate, returnDate);
        }

        public void ExecuteRentalFromReservation(int reservationId)
        {
            Channel.ExecuteRentalFromReservation(reservationId);
        }

        public void CancelReservation(int reservationId)
        {
            Channel.CancelReservation(reservationId);
        }

        public CustomerReservationData[] GetCurrentReservations()
        {
            return Channel.GetCurrentReservations();
        }

        public CustomerReservationData[] GetCustomerReservations(string loginEmail)
        {
            return Channel.GetCustomerReservations(loginEmail);
        }
        
        public Rental GetRental(int rentalId)
        {
            return Channel.GetRental(rentalId);
        }

        public CustomerRentalData[] GetCurrentRentals()
        {
            return Channel.GetCurrentRentals();
        }

        public Reservation[] GetDeadReservations()
        {
            return Channel.GetDeadReservations();
        }

        public bool IsCarCurrentlyRented(int carId)
        {
            return Channel.IsCarCurrentlyRented(carId);
        }
    }
}
