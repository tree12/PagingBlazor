using Microsoft.EntityFrameworkCore;

namespace PagingBlazor.API.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalRecords { get; private set; }
        public int PageSize { get; private set; }

        public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);
        public bool HasPreviousPage => (PageIndex > 1);
        public bool HasNextPage => (PageIndex < TotalPages);

        public PaginatedList()
        {

        }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            TotalRecords = count;
            PageSize = pageSize;
            PageIndex = Math.Max(1, pageIndex > TotalPages ? TotalPages : pageIndex);

            this.AddRange(items);
        }


        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize,
            bool? isPageChange = null, int? totalRecords = null)
        {
            int count;
            int index;
            int GetMaxPage(int c, int p) => Math.Max(1, (int)Math.Ceiling((double)c / (double)p));

            if (isPageChange.HasValue)
            {
                if (isPageChange.Value)
                {
                    count = totalRecords.HasValue ? Math.Max(0, totalRecords.Value) : await source.CountAsync();
                    var maxPage = GetMaxPage(count, pageSize);
                    index = Math.Max(1, pageIndex > maxPage ? maxPage : pageIndex);
                }
                else
                {
                    count = await source.CountAsync();
                    index = 1;
                }
            }
            else
            {
                count = await source.CountAsync();
                var maxPage = GetMaxPage(count, pageSize);
                index = Math.Max(1, pageIndex > maxPage ? maxPage : pageIndex);
            }

            var items = await source.Skip((index - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, index, pageSize);
        }
    }
}
