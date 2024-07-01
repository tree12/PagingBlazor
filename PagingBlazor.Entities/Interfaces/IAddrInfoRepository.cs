using PagingBlazor.Entities.Data.Entities;
using PagingBlazor.Entities.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagingBlazor.Entities.Interfaces
{
    public interface IAddrInfoRepository : IViewRepository<AddrInfo, int>
    {
    }
}
