using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BuyMart.Data.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BuyMart.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbset = db.Set<T>();
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            dbset.RemoveRange(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }



    }
}
