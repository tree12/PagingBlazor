using Microsoft.AspNetCore.Mvc;
using PagingBlazor.API.Interfaces;
using PagingBlazor.API.Models;

namespace PagingBlazor.API.Controllers
{
    public class AddrInfoContollercs : BaseController<IAddrInfoService>
    {
        public AddrInfoContollercs(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        [HttpPost("GetAddrInfoModels")]
        public async Task<PaginatedListViewModel<AddrInfoModel>> GetAddrInfoModelsAsync([FromBody]PageableInfo info)
        { 
            return await service.GetAddrInfoModelsAsync(info);
        }
    }
}
