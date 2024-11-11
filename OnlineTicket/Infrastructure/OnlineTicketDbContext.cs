using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System.Reflection;

namespace Infrastructure
{
    public class OnlineTicketDbContext : IdentityDbContext<User,Role,Guid>
    {
        public OnlineTicketDbContext() { }

        public OnlineTicketDbContext(DbContextOptions<OnlineTicketDbContext> dbContext) : base(dbContext) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=OnlineTicketDb;TrustServerCertificate=True;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
