using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleETicketPlatform.Infrastructure.Repository
{
    public interface IRepository 
    {
        Task AddAsync<T>(T entity) where T: class;
        Task DeleteAsync<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();
        Task<T?> GetByIdAsync<T>(object id) where T : class;
        IQueryable<T?> All<T>() where T : class;
        IQueryable<T?> AllReadOnly<T>() where T : class;

    }
}
