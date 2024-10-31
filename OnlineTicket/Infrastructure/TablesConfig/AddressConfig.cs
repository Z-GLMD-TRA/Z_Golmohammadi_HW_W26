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
    public class AddressConfig : BaseEntityConfig<Address,int>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.RequireTraceable = true;
            base.UseForTraceable = true;
            base.ValueGeneratedForKey = false;

            builder.ToTable(nameof(Address));

            builder.HasOne(e => e.Province)
                .WithOne(e => e.Address)
                .HasForeignKey<Address>(e => e.ProvinceId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.City)
                .WithOne(e => e.Address)
                .HasForeignKey<Address>(e => e.CityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.User)
                .WithMany(e => e.Addresses)
                .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);
            base.Configure(builder);

        }
    }
}

