
using PagingBlazor.Client.Services.Generate;
using PagingBlazor.Client.Services.Interfaces;

namespace PagingBlazor.Client.Services
{
    public class AddrInfoService : Base.BaseService, IAddrInfoService
    {
        private readonly AddrInfoContollercsClient addrInfoContollercsClient;
        public AddrInfoService(HttpClient httpClient) : base(httpClient)
        {
            addrInfoContollercsClient = new AddrInfoContollercsClient(httpClient.BaseAddress?.AbsoluteUri, httpClient);
        }

        public async Task<AddrInfoModelPaginatedListViewModel> GetAddrInfoModelAsync(PageableInfo info)
        {
             return await addrInfoContollercsClient.GetAddrInfoModelsAsync(info);
        }
    }
}
