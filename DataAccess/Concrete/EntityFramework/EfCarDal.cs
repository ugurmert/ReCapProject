using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            //using ile context'i, blok bitince Garbage Collector ile bellekten hemen atmasını istiyoruz.
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var addedEntity = context.Entry(entity);    //Referansı yakala
                addedEntity.State = EntityState.Added;      //Ekleme durumu olarak set et
                context.SaveChanges();                      //Ekle şimdi
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var deletedEntity = context.Entry(entity);      //Referansı yakala
                deletedEntity.State = EntityState.Deleted;      //Silme durumu olarak set et
                context.SaveChanges();                          //Sil şimdi
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            //Tek bir Car nesnesi getirmek
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            //Filtre yoksa tüm Car nesnelerini, filtre varsa uygun Car nesnelerini getirmek
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var updatedEntity = context.Entry(entity);      //Referansı yakala
                updatedEntity.State = EntityState.Modified;     //Güncelleme durumu olarak set et
                context.SaveChanges();                          //Güncelle şimdi
            }
        }
    }
}
