using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("----- Vehicle features -----");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "- " + car.Description + " " + car.ModelYear + " " + car.DailyPrice);
            }

            carManager.AddCar(new Car { Id = 8, BrandId = 4, ColorId = 1, ModelYear = 2020, DailyPrice = 450.5, Description = "Fiat Egea" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "- " + car.Description + " " + car.ModelYear + " " + car.DailyPrice);
            }

            carManager.AddCar(new Car { Id = 9, BrandId = 4, ColorId = 1, ModelYear = 2016, DailyPrice = 450.5, Description = "Fiat Egea" });
            carManager.AddCar(new Car { Id = 10, BrandId = 5, ColorId = 2, ModelYear = 2019, DailyPrice = 350.5, Description = "Opel Corsa" });
            carManager.AddCar(new Car { Id = 11, BrandId = 3, ColorId = 4, ModelYear = 2015, DailyPrice = 450.5, Description = "Hyundai I10" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "- " + car.Description + " " + car.ModelYear + " " + car.DailyPrice);
            }
        }
    }
}
