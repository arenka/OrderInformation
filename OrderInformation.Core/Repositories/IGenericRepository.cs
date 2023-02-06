using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void Add(T entity);
        void Update(T entity);//durum değiştirdiği için asenkron methodu bulunmuyor.
        Task<T> GetByIdAsync(int id);
        T GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
        T FirstOrDefault(Expression<Func<T, bool>> expression);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
    }
}
