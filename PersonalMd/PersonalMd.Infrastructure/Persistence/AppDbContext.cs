using Microsoft.EntityFrameworkCore;
using PersonalMd.Domain.Entities;

namespace PersonalMd.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
                entity.Property(e => e.CreatedAt).IsRequired();
            });


            //modelBuilder.Entity<SymptomQuery>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.UserId).IsRequired();
            //    entity.Property(e => e.ResultJson).HasMaxLength(4000);
            //    entity.Property(e => e.CreatedAt).IsRequired();

            //    // Configure relationship if ConditionResult belongs to SymptomQuery
            //    entity.HasMany<ConditionResult>()
            //          .WithOne()
            //          .HasForeignKey("SymptomQueryId")
            //          .OnDelete(DeleteBehavior.Cascade);
            //});

            //modelBuilder.Entity<ConditionResult>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Name).IsRequired();
            //    entity.Property(e => e.Likelihood).IsRequired();
            //});
        }
    }
}
