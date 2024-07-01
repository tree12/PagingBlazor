namespace PagingBlazor.API.Models
{
    public class PaginatedListViewModel<T>
    {
        public int PageIndex { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public List<T> Entries { get; set; }

        public PaginatedListViewModel()
        {
        }
        public PaginatedListViewModel(List<T> items, int count, int pageIndex, int totalPages)
        {
            this.PageIndex = pageIndex;
            this.TotalRecords = count;
            this.Entries = items;
            this.TotalPages = totalPages;

        }
    }
}
