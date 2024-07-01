using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagingBlazor.Entities.Data.Entities
{
    [Table("AddrInfo")]
    public partial class AddrInfo : BaseEntity<AddrInfo>
    {
        [Key]
        public int AddrId { get; set; }

        public string Geo { get; set; } = null!;

        public string? Province { get; set; }

        public string? District { get; set; }

        public string? Subdis { get; set; }

        public string? Zip { get; set; }

        public string? ProvinceEng { get; set; }

        public string? DistrictEng { get; set; }

        public string? SubdisEng { get; set; }

        public string? Note { get; set; }

        public bool? Active { get; set; }


        public override void Configure(EntityTypeBuilder<AddrInfo> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.District)
                    .HasMaxLength(100);
            builder.Property(e => e.DistrictEng)
                    .HasMaxLength(100);
            builder.Property(e => e.Geo)
                    .HasMaxLength(100);
            builder.Property(e => e.Note)
                    .HasMaxLength(100);
            builder.Property(e => e.Province)
                    .HasMaxLength(100);
            builder.Property(e => e.ProvinceEng)
                    .HasMaxLength(100);
            builder.Property(e => e.Subdis)
                    .HasMaxLength(100);
            builder.Property(e => e.SubdisEng)
                    .HasMaxLength(100);
            builder.Property(e => e.Zip)
                    .HasMaxLength(10);

        }
    }
}
