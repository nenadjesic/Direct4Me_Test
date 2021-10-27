using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Direct4Me_Test.Entities;

namespace Direct4Me_Test.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<DeliveryService> DeliveryServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().ToTable("Articles");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<DeliveryService>().ToTable("DeliveryServices");

            modelBuilder.Entity<Article>()
        .HasKey(bc => new { bc.DeliveryServiceId, bc.Id });
            modelBuilder.Entity<Article>()
                .HasOne(bc => bc.DeliveryService)
                .WithMany(b => b.Articles)
                .HasForeignKey(bc => bc.Id);
            modelBuilder.Entity<Article>()
                .HasOne(bc => bc.DeliveryService)
                .WithMany(c => c.Articles)
                .HasForeignKey(bc => bc.DeliveryServiceId);


        }

}
}