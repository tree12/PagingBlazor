using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using PagingBlazor.Entities.Interfaces;
using System.Linq.Expressions;
using PagingBlazor.API.Models;

namespace PagingBlazor.API.Services
{
    public abstract class BaseService
    {
        protected IUnitOfWork unitOfWork;


        public BaseService(IServiceProvider services)
        {
            this.unitOfWork = services.GetService<IUnitOfWork>();
        }
        public virtual async Task<PaginatedList<T>> GetPagedAsync<T>(
   Expression<Func<T, bool>> filter = null,
   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
   Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null,
   int pageSize = 15,
   int pageIndex = 1,
   bool? isPageChange = null,
   int? totalRecords = null,
   string sql = null) where T : class
        {
            IQueryable<T> query = unitOfWork.context.Set<T>();

            if (sql != null)
            {
                query = unitOfWork.context.Set<T>().FromSqlRaw(sql);
            }

            if (includeProperties != null) // load entities ที่ขึ้นต่อกันที่ต้องการทั้งหมด 
            {
                query = includeProperties(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await PaginatedList<T>.CreateAsync(query.AsNoTracking(), pageIndex, pageSize,
                isPageChange, totalRecords);
        }


    }
}
