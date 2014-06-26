using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using CarRental.Client.Contracts;
using CarRental.Client.Entities;
using Core.Common.ServiceModel;

namespace CarRental.Client.Proxies
{
    [Export(typeof(IInventoryService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InventoryClient : UserClientBase<IInventoryService>, IInventoryService
    {
        public Car UpdateCar(Car car)
        {
            return Channel.UpdateCar(car);
        }

        public void DeleteCar(int carId)
        {
            Channel.DeleteCar(carId);
        }

        public Car GetCar(int carId)
        {
            return Channel.GetCar(carId);
        }

        public Car[] GetAllCars()
        {
            return Channel.GetAllCars();
        }

        public Car[] GetAvailableCars(DateTime pickupDate, DateTime returnDate)
        {
            return Channel.GetAvailableCars(pickupDate, returnDate);
        }
    }
}
