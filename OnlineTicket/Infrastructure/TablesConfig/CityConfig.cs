using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TablesConfig
{
    public class CityConfig : BaseEntityConfig<City, int>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            base.RequireTraceable = false;
            base.UseForTraceable = false;
            base.ValueGeneratedForKey = false;

            builder.ToTable(nameof(City));

            builder.HasOne(x => x.Province).WithMany(x => x.Cities).HasForeignKey(x => x.ProvinceId)
                .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
