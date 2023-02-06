using Microsoft.EntityFrameworkCore;
using OrderInformation.Core.Repositories;
using OrderInformation.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _unitOfWork = unitOfWork;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _unitOfWork.Commit();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _unitOfWork.CommitAsync(); 
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return  _dbSet.Any(expression);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
