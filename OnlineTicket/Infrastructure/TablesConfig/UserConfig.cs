using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System.Data;


namespace Infrastructure.TablesConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            // Apply base entity configurations
            //base.RequireTraceable = true;
            //base.UseForTraceable = true;
            //base.GeneratedValueForKey = false;
            //base.Configure(builder);

            // Define properties
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Phone)
                .HasMaxLength(20);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);

            //builder.Property(u => u.Password)
            //    .IsRequired();

            builder.Property(u => u.IsActived)
                .HasDefaultValue(true);




            builder.HasOne(x => x.CreatorUser).WithMany().HasForeignKey(x => x.CreatorUserId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.EditorUser).WithMany().HasForeignKey(x => x.EditorUserId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
