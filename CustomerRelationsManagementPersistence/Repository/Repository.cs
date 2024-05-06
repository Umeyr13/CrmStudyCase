using CustomerRelationsMangementApplication.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsManagementPersistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CustomerRelationManagementDbContext _context;

        public Repository(CustomerRelationManagementDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> method)
        {
            return Table.Where(method);
        }

        public IQueryable<T> GetAll()
        {
            return Table.AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {

            return await Table.FindAsync(id);
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            return Table.AsQueryable().FirstOrDefaultAsync(method);
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveIdAsync(int id)
        {
            T model = await Table.FindAsync(id);
            return Remove(model);
        }


        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();
    }
}
