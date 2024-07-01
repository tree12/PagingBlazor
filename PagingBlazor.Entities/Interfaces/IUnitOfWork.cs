using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagingBlazor.Entities.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext context { get; }
        IAddrInfoRepository addrInfoRepository { get; }
        int Complete();
    }
}
