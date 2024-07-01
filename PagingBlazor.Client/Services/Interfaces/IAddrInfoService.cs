using PagingBlazor.Client.Services.Generate;

namespace PagingBlazor.Client.Services.Interfaces
{
    public interface IAddrInfoService
    {
        Task<AddrInfoModelPaginatedListViewModel> GetAddrInfoModelAsync(PageableInfo info);
    }
}
