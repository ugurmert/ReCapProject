using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void AddCar(Car car)
        {
            //9'dan fazla araç kayıtlıysa veya 2018 yılından eski model yılına sahipse eklemek istemiyoruz.

            int numberOfCar = _carDal.GetAll().Count + 1;

            if (numberOfCar > 9 || car.ModelYear < 2018)
            {
                Console.WriteLine("Not added: " + car.Id + " " + car.Description + " " + car.ModelYear);
            }
            else
            {
                _carDal.Add(car);
                Console.WriteLine("Added: " + car.Id + " " + car.Description + " " + car.ModelYear);
            }
        }

        public void DeleteCar(int carId)
        {
            if (_carDal.GetAll().Any(c => c.Id == carId))
            {
                _carDal.Delete(_carDal.GetByCarId(carId));
                Console.WriteLine("Deleted: " + carId);
            }
            else
            {
                Console.WriteLine("Not deleted: " + carId);
            }
        }
    }
}
