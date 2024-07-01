using PagingBlazor.API.Repositories;
using PagingBlazor.Entities;
using PagingBlazor.Entities.Interfaces;

namespace PagingBlazor.API.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext context { get; private set; }
        public IAddrInfoRepository addrInfoRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext context) {
            this.context = context;
            addrInfoRepository = new AddrInfoRepository(context);
        }
        public int Complete()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
