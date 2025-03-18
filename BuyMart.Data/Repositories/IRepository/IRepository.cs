using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuyMart.Data.Repositories.IRepository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entity);
    }
}
