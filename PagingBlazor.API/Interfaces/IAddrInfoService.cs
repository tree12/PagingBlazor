using PagingBlazor.API.Models;

namespace PagingBlazor.API.Interfaces
{
    public interface IAddrInfoService: IService
    {
        Task<PaginatedListViewModel<AddrInfoModel>> GetAddrInfoModelsAsync(PageableInfo info);
    }
}
