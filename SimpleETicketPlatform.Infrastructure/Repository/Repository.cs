using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleETicketPlatform.Infrastructure.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }
        private DbSet<T> GetDbSet<T>() where T : class
        {
            return context.Set<T>();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await GetDbSet<T>().AddAsync(entity);
        }

        public IQueryable<T?> All<T>() where T : class
        {
            return GetDbSet<T>();
        }

        public IQueryable<T?> AllReadOnly<T>() where T : class
        {
            return GetDbSet<T>().AsNoTracking();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            GetDbSet<T>().Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            return await GetDbSet<T>().FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
