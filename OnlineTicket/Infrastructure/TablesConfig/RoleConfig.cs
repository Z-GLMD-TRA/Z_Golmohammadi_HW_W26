using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace Infrastructure.TablesConfig
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Define table name
            builder.ToTable(nameof(Role));
            //base.RequireTraceable = true;
            //base.UseForTraceable = true;
            //base.GeneratedValueForKey = false;
            //// Call base configuration
            //base.Configure(builder);

            // Define property configurations
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.PersianName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.Description)
                .HasMaxLength(250);

            // Define relations
            //builder.HasMany(r => r.Users)
            //    .WithOne(u => u.Role)
            //    .HasForeignKey(u => u.RoleId)
            //    .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.CreatorUser).WithMany().HasForeignKey(x => x.CreatorUserId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.EditorUser).WithMany().HasForeignKey(x => x.EditorUserId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
