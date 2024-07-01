using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PagingBlazor.Entities.Interfaces.Base
{
    public interface IViewRepository<T, TId> where T : class
    {
        Task<T> GetById(params object[] keyValues);
        Task<IEnumerable<T>> GetAll(string includeProperties = "");
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          string includeProperties = "", bool isTracking = true, int? pageIndex = null, int? take = null);

    }
}
