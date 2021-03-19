using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear=2019, DailyPrice=445.28, Description="Citroen C Elysee" },
                new Car{Id=2, BrandId=2, ColorId=2, ModelYear=2019, DailyPrice=438, Description="Renault Clio" },
                new Car{Id=3, BrandId=1, ColorId=3, ModelYear=2021, DailyPrice=475.32, Description="Citroen C3" },
                new Car{Id=4, BrandId=3, ColorId=1, ModelYear=2020, DailyPrice=448.97, Description="Hyundai I10" },
                new Car{Id=5, BrandId=4, ColorId=3, ModelYear=2018, DailyPrice=344.10, Description="Fiat Egea" },
                new Car{Id=6, BrandId=5, ColorId=3, ModelYear=2021, DailyPrice=481.76, Description="Opel Corsa" },
                new Car{Id=7, BrandId=6, ColorId=4, ModelYear=2020, DailyPrice=459.51, Description="Peugeot 208" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
