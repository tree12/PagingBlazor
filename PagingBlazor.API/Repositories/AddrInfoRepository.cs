using PagingBlazor.Entities.Data.Entities;
using PagingBlazor.Entities.Interfaces.Base;
using PagingBlazor.Entities.Interfaces;
using PagingBlazor.Entities;

namespace PagingBlazor.API.Repositories
{
    public class AddrInfoRepository : ViewRepository<AddrInfo, int>, IAddrInfoRepository
    {
        public AddrInfoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
