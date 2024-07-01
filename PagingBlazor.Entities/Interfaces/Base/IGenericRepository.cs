using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagingBlazor.Entities.Interfaces.Base
{
    public interface IGenericRepository<T, TId> : IViewRepository<T, TId> where T : class
    {
        Task Add(T entity);
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T> Update(T entity);
        Task AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
