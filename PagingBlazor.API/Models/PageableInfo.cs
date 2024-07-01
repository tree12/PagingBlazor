using System.Text.Json.Serialization;

namespace PagingBlazor.API.Models
{
    public class PageableInfo
    {
        public bool? IsPageChange { get; set; } = null;
        public int? TotalRecords { get; set; } = null;

        public bool SortDirection { get; set; }
        public string SortColumn { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; } = 1;
        public string Filter { get; set; }

        [JsonIgnore]
        public bool HasFilter => !string.IsNullOrEmpty(this.Filter);
        public List<KeyValuePair<string, string>> ColumnFilters { get; set; }
    }
}
