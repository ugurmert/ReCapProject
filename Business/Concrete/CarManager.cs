using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            var result = _carDal.GetAll().Any(c => c.Id == car.Id);
            if (result == false)
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);
                    return new SuccessResult(Messages.CarAdded);
                }
                else
                {
                    return new ErrorResult(Messages.CarDailyPriceInvalid);
                }
            }
            else
            {
                return new ErrorResult(Messages.CarIdAvailable);
            }
        }

        public IResult Delete(Car car)
        {
            var result = _carDal.GetAll().Any(c => c.Id == car.Id);
            if (result)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
            else
            {
                return new ErrorResult(Messages.CarNotFound);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarsByModelId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelId == id));
        }

        public IResult Update(Car car)
        {
            var result = _carDal.GetAll().Any(c => c.Id == car.Id);
            if (result)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            else
            {
                return new ErrorResult(Messages.CarNotFound);
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
