using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.TablesConfig
{
    public class TicketConfig : BaseEntityConfig<Ticket,Guid>
    {
        public override void Configure(EntityTypeBuilder<Ticket> builder)
        {
            base.RequireTraceable = true;
            base.UseForTraceable = true;
            base.ValueGeneratedForKey = false;

            builder.ToTable(nameof(Ticket));

            builder.HasOne(x => x.User).WithMany(x => x.Tickets).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Category).WithMany(x => x.Tickets).HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.BuyDate).IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.TicketNumber).IsRequired().HasMaxLength(5).HasDefaultValue(Ticket.NewTicketNumber());
            base.Configure(builder);
        }
    }
}
