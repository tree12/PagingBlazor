namespace PagingBlazor.API.Models
{
    public class AddrInfoModel
    {
        public int AddrId { get; set; }

        //public string Geo { get; set; } = null!;

        //public string? Province { get; set; }

        //public string? District { get; set; }

        //public string? Subdis { get; set; }

        public string? Zip { get; set; }

        public string? ProvinceEng { get; set; }

        public string? DistrictEng { get; set; }

        public string? SubdisEng { get; set; }

        public string? Note { get; set; }

        public bool? Active { get; set; }
    }
}
