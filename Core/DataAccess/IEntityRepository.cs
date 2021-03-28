using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //class --> Referans tip olmalı
    //IEntity --> IEntity veya IEntity implement eden nesne olabilir
    //new() --> new'lenebilir olmalıdır. Soyut sınıfları kabul etmemek için kullanırız.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
