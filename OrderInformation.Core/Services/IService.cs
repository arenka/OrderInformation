using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<T> AddAsync(T entity);
        T Add(T entity);
        void Update(T entity);
        Task<T> GetByIdAsync(int id);
        T GetById(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        T FirstOrDefault(Expression<Func<T, bool>> expression);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);

    }
}
