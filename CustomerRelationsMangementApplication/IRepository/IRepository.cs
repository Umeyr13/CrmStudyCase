using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsMangementApplication.IRepository
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; }
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> method);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T model);
        bool Remove(T model);
        Task<bool> RemoveIdAsync(int id);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
