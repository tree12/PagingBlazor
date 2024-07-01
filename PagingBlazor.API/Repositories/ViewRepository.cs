using Microsoft.EntityFrameworkCore;
using PagingBlazor.Entities.Interfaces.Base;
using PagingBlazor.Entities;
using System.Linq.Expressions;
using PagingBlazor.API.Interfaces;

namespace PagingBlazor.API.Repositories
{
    public abstract class ViewRepository<T, TId> : IViewRepository<T, TId>, IBaseRepository where T : class
    {
        protected readonly ApplicationDbContext _context;
        public ViewRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", bool isTracking = true, int? pageIndex = null, int? take = null)

        {
            int count;
            int index = 1; ;
            int GetMaxPage(int c, int p) => Math.Max(1, (int)Math.Ceiling((double)c / (double)p));
            IQueryable<T> query = _context.Set<T>();

            if (expression != null)
            {
                query = isTracking ? query.Where(expression) : query.Where(expression).AsNoTracking();
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!string.IsNullOrWhiteSpace(includeProperty))
                        query = query.Include(includeProperty.Trim());
                }
            }

            count = await query.CountAsync();
            int maxPage = 0;
            if (take != null)
            {
                maxPage = GetMaxPage(count, take.Value);
                index = Math.Max(1, pageIndex > maxPage ? maxPage : pageIndex ?? 1);

            }


            if (orderBy != null)
            {
                return take == null ? orderBy(query).ToList() : orderBy(query).Skip((index - 1) * take.Value).Take(take.Value).ToList();
            }
            else
            {
                return take == null ? query.ToList() : query.Skip((index - 1) * take.Value).Take(take.Value).ToList();
            }
        }

        public async Task<IEnumerable<T>> GetAll(string includeProperties = "")
        {

            if (!string.IsNullOrEmpty(includeProperties))
            {
                return await Find(null, null, includeProperties: includeProperties);
            }
            return await _context.Set<T>().ToListAsync();
        }


        public async Task<T> GetById(params object[] keyValues)
        {
            return await _context.Set<T>().FindAsync(keyValues);
        }
    }
}
