using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //using ile context'i, blok bitince Garbage Collector ile bellekten hemen atmasını istiyoruz.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);    //Referansı yakala
                addedEntity.State = EntityState.Added;      //Ekleme durumu olarak set et
                context.SaveChanges();                      //Şimdi ekle
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);      //Referansı yakala
                deletedEntity.State = EntityState.Deleted;      //Silme durumu olarak set et
                context.SaveChanges();                          //Şimdi sil
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            //Tek bir nesneyi getirmek
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //Filtre yoksa tüm nesneleri, filtre varsa uygun nesneleri getirmek
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);      //Referansı yakala
                updatedEntity.State = EntityState.Modified;     //Güncelleme durumu olarak set et
                context.SaveChanges();                          //Şimdi güncelle
            }
        }
    }
}
