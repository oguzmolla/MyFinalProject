using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    /* <T> bunu sadece veri tabanı imzası olan nesneler oluşturabilsin diye
     * imza tanımlıyacağz buna generic constraint denir
     class : demek referans tipli olması gerek diye imza koymus olduk
     IEntity verekte sadece veri tabanı referansı olanlar verilebilcektir
     new yazarakta interface değilde saddece new lenebilen nesnelere izin verdik*/

    // core katmanı hiçbirşeye bağlı olmamalı her projede kullanmak için
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
