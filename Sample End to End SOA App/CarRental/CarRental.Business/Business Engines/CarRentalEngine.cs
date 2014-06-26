using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using CarRental.Business.Common;
using CarRental.Business.Entities;
using CarRental.Data.Contracts;
using Core.Common.Contracts;

namespace CarRental.Business
{
    [Export(typeof(ICarRentalEngine))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CarRentalEngine : ICarRentalEngine
    {
        [ImportingConstructor]
        public CarRentalEngine(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        IDataRepositoryFactory _DataRepositoryFactory;

        public bool IsCarCurrentlyRented(int carId, int accountId)
        {
            bool rented = false;

            IRentalRepository rentalRepository = _DataRepositoryFactory.GetDataRepository<IRentalRepository>();

            var currentRental = rentalRepository.GetCurrentRentalByCar(carId);
            if (currentRental != null && currentRental.AccountId == accountId)
                rented = true;

            return rented;
        }

        public bool IsCarCurrentlyRented(int carId)
        {
            bool rented = false;

            IRentalRepository rentalRepository = _DataRepositoryFactory.GetDataRepository<IRentalRepository>();

            var currentRental = rentalRepository.GetCurrentRentalByCar(carId);
            if (currentRental != null)
                rented = true;

            return rented;
        }

        public bool IsCarAvailableForRental(int carId, DateTime pickupDate, DateTime returnDate, 
                                            IEnumerable<Rental> rentedCars, IEnumerable<Reservation> reservedCars)
        {
            bool available = true;
            
            Reservation reservation = reservedCars.Where(item => item.CarId == carId).FirstOrDefault();
            if (reservation != null && (
                (pickupDate >= reservation.RentalDate && pickupDate <= reservation.ReturnDate) ||
                (returnDate >= reservation.RentalDate && returnDate <= reservation.ReturnDate)))
            {
                available = false;
            }

            if (available)
            {
                Rental rental = rentedCars.Where(item => item.CarId == carId).FirstOrDefault();
                if (rental != null && (pickupDate <= rental.DateDue))
                    available = false;
            }

            return available;
        }
    }
}
