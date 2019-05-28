using Microsoft.EntityFrameworkCore;
using MyHospitalizationPal.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext db;
        public Repository(DbContext dbContext)
        {
            db = dbContext;
        }

        //public void Add(T entity)
        //{
        //    db.Set<T>().Add(entity);
        //}

        //public void Delete(T entity)
        //{
        //    T existing = db.Set<T>().Find(entity);
        //    if (existing != null) db.Set<T>().Remove(existing);
        //}

        //public IEnumerable<T> Get()
        //{
        //    return db.Set<T>().AsEnumerable<T>();
        //}

        ////E de sters
        //public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        //{
        //    return db.Set<T>().Where(predicate).AsEnumerable<T>();
        //}

        //public void Update(T entity)
        //{
        //    db.Entry(entity).State = EntityState.Modified;
        //    db.Set<T>().Attach(entity);
        //}
    }
}
