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
    public class ProvinceConfig : BaseEntityConfig<Province, int>
    {
        public override void Configure(EntityTypeBuilder<Province> builder)
        {
            base.RequireTraceable = false;
            base.UseForTraceable = false;
            base.ValueGeneratedForKey = false;

            builder.ToTable(nameof(Province));

           
            base.Configure(builder);
        }
    }
}
