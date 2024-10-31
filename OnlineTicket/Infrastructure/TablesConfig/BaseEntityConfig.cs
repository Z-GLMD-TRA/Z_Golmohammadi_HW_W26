using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Infrastructure.TablesConfig
{
    public class BaseEntityConfig<T, KeyTypeId> : IEntityTypeConfiguration<T>
        where T : BaseEntity<KeyTypeId> where KeyTypeId : struct
    {
        protected bool ValueGeneratedForKey { get; set; } = true;
        protected bool UseForTraceable { get; set; } = false;
        protected bool RequireTraceable { get; set; } = false;

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            if (ValueGeneratedForKey)
                builder.Property(x => x.Id).ValueGeneratedOnAdd();
            if (UseForTraceable == false)
            {
                builder.Ignore(x => x.Creator);
                builder.Ignore(x => x.CreatorId);
                builder.Ignore(x => x.CreatedAt);
                builder.Ignore(x => x.Editor);
                builder.Ignore(x => x.EditorId);
                builder.Ignore(x => x.EditedAt);
            }
            else
            {
                builder.Property(x => x.CreatedAt).IsRequired(RequireTraceable);
                builder.Property(x=>x.EditedAt).IsRequired(RequireTraceable);

                builder.HasOne(x => x.Creator).WithMany().HasForeignKey(x => x.CreatorId).IsRequired(RequireTraceable)
                    .OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(x => x.Editor).WithMany().HasForeignKey(x => x.EditorId).IsRequired(RequireTraceable)
                    .OnDelete(DeleteBehavior.NoAction);
            }
        }
    }
}
