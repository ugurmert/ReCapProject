using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from ca in context.Cars
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             join m in context.Models
                             on ca.ModelId equals m.Id
                             join b in context.Brands
                             on m.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 ModelName = m.Name,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 DailyPrice = ca.DailyPrice
                             };
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarDetailsById(int carId)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from ca in context.Cars
                             join color in context.Colors
                             on ca.ColorId equals color.Id
                             join m in context.Models
                             on ca.ModelId equals m.Id
                             join b in context.Brands
                             on m.BrandId equals b.Id
                             join img in context.CarImages
                             on ca.Id equals img.CarId
                             where ca.Id == carId
                             select new CarDetailDto
                             {
                                 BrandName = b.Name,
                                 ModelName = m.Name,
                                 ColorName = color.Name,
                                 DailyPrice = ca.DailyPrice,
                                 ImagePath = img.ImagePath
                             };
                return result.ToList();

            }
        }
    }
}
