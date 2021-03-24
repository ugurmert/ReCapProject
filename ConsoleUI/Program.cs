using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2020, DailyPrice = 450.5, Description = "Egea" });
            carManager.Add(new Car { Id = 2, BrandId = 1, ColorId = 1, ModelYear = 2016, DailyPrice = 378, Description = "Egea" });
            carManager.Add(new Car { Id = 3, BrandId = 2, ColorId = 2, ModelYear = 2019, DailyPrice = 390, Description = "Corsa" });
            carManager.Add(new Car { Id = 4, BrandId = 3, ColorId = 3, ModelYear = 2015, DailyPrice = 355.5, Description = "I10" });
            carManager.Add(new Car { Id = 5, BrandId = 4, ColorId = 2, ModelYear = 2019, DailyPrice = 430.5, Description = "A" });
            carManager.Add(new Car { Id = 6, BrandId = 3, ColorId = 1, ModelYear = 2018, DailyPrice = 0, Description = "I10" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "- " + car.Description + " " + car.ModelYear + " " + car.DailyPrice);
            }
        }
    }
}
