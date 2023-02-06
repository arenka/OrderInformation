using Microsoft.EntityFrameworkCore;
using OrderInformation.Core.Repositories;
using OrderInformation.Core.Services;
using OrderInformation.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Business.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public T Add(T entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
           return _repository.Any(expression);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return _repository.FirstOrDefault(expression);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.FirstOrDefaultAsync(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return  _repository.Where(expression);
        }
    }
}
