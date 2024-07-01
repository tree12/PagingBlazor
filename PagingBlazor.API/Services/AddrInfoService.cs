
using PagingBlazor.API.Interfaces;
using PagingBlazor.API.Models;
using PagingBlazor.Entities.Data.Entities;
using System;
using System.Linq.Expressions;

namespace PagingBlazor.API.Services
{
    public class AddrInfoService : BaseService, IAddrInfoService
    {
        public AddrInfoService(IServiceProvider services) : base(services)
        {
        }

        public async Task<PaginatedListViewModel<AddrInfoModel>> GetAddrInfoModelsAsync(PageableInfo info)
        {
            Expression<Func<AddrInfo, bool>> filter = null;
            var entities = await GetPagedAsync(
                 filter,
                 x => x.OrderBy(a => a.AddrId),
                 null,
                 info.PageSize,
                 info.PageNumber,
                 info.IsPageChange,
                 info.TotalRecords);

            List<AddrInfoModel> addrInfoModels = new List<AddrInfoModel>();
            entities.ToList().ForEach(x =>
            {
                addrInfoModels.Add(new AddrInfoModel()
                {
                    AddrId = x.AddrId,
                    ProvinceEng = x.ProvinceEng,
                    DistrictEng = x.DistrictEng,
                    SubdisEng = x.SubdisEng,
                    Zip = x.Zip,
                    Note = x.Note,
                    Active = x.Active
                });
            }

                );

            return new PaginatedListViewModel<AddrInfoModel>(addrInfoModels, entities.TotalRecords, entities.PageIndex, entities.TotalPages);
        }
    }
}
