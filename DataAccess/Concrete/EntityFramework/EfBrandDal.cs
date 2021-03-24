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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            //using ile context'i, blok bitince Garbage Collector ile bellekten hemen atmasını istiyoruz.
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var addedEntity = context.Entry(entity);    //Referansı yakala
                addedEntity.State = EntityState.Added;      //Ekleme durumu olarak set et
                context.SaveChanges();                      //Ekle şimdi
            }
        }

        public void Delete(Brand entity)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var deletedEntity = context.Entry(entity);      //Referansı yakala
                deletedEntity.State = EntityState.Deleted;      //Silme durumu olarak set et
                context.SaveChanges();                          //Sil şimdi
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            //Tek bir Brand nesnesi getirmek
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            //Filtre yoksa tüm Brand nesnelerini, filtre varsa uygun Brand nesnelerini getirmek
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
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
