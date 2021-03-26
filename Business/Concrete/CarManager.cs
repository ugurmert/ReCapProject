using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            var result = _carDal.GetAll().Any(c => c.Id == car.Id);
            if (result == false)
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);
                    Console.WriteLine("Added");
                }
                else
                {
                    Console.WriteLine("Hata! Araba günlük fiyatı 0'dan büyük olmalıdır.");
                }
            }
            else
            {
                Console.WriteLine("Hata! Eklemeye çalıştığınız araba mevcut");
            }
        }

        public void Delete(Car car)
        {
            var result = _carDal.GetAll().Any(c => c.Id == car.Id);
            if (result)
            {
                _carDal.Delete(car);
            }
            else
            {
                Console.WriteLine("Hata! Silmek istediğiniz araba mevcut değil");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c => c.Id == carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public List<Car> GetCarsByModelId(int id)
        {
            return _carDal.GetAll(c => c.ModelId == id);
        }

        public void Update(Car car)
        {
            var result = _carDal.GetAll().Any(c => c.Id == car.Id);
            if (result)
            {
                _carDal.Update(car);
            }
            else
            {
                Console.WriteLine("Hata! Güncellemek istediğiniz araba mevcut değil");
            }
        }
    }
}

/* Düzeltilmesi Gerekenler:
 * 
 * - GetById metoduna mevcut olmayan Id girilmesi
 * - Update ve Delete metodların mevcut olmayan Id ile işlem yapamaması
 * 
 */
