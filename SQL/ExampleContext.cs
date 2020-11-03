using Labs.Entities;
using Microsoft.EntityFrameworkCore;

namespace SQL
{
    public partial class ExampleContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public ExampleContext()
        {
        }

        public ExampleContext(DbContextOptions<ExampleContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;User ID=postgres;Password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
            });

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
                {Id = 1, FirstName = "FirstName", LastName = "LastName"});
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
                {Id = 2, FirstName = "FirstName1", LastName = "LastName1"});
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}