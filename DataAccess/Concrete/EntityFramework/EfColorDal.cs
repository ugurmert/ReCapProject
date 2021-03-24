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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            //using ile context'i, blok bitince Garbage Collector ile bellekten hemen atmasını istiyoruz.
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var addedEntity = context.Entry(entity);    //Referansı yakala
                addedEntity.State = EntityState.Added;      //Ekleme durumu olarak set et
                context.SaveChanges();                      //Ekle şimdi
            }
        }

        public void Delete(Color entity)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var deletedEntity = context.Entry(entity);      //Referansı yakala
                deletedEntity.State = EntityState.Deleted;      //Silme durumu olarak set et
                context.SaveChanges();                          //Sil şimdi
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            //Tek bir Color nesnesi getirmek
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            //Filtre yoksa tüm Color nesnelerini, filtre varsa uygun Color nesnelerini getirmek
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
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
