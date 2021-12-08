namespace TicketSystem.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Services;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using TicketSystem.Data.Models.Base;

    public class ApplicationDbContext : IdentityDbContext
    {
        public readonly ICurrentUserService currentUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUser)
            : base(options)
        {
            this.currentUser = currentUser;
        }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditIformation();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.ApplyAuditIformation();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // one ticket belongs to one user
            // one user can have multiple tickets
            builder
                .Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // one comment belongs to one user
            // one user can have many comments
            builder
                .Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
            this.AddIdentityRoles(builder);
        }

        private void AddIdentityRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Junior",
                    NormalizedName = "JUNIOR",
                    Id = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Mid",
                    NormalizedName = "MID",
                    Id = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Senior",
                    NormalizedName = "SENIOR",
                    Id = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "OfficeSupport",
                    NormalizedName = "OFFICESUPPORT",
                    Id = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "TechSupport",
                    NormalizedName = "TECHSUPPORT",
                    Id = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Id = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });

        }

        private void ApplyAuditIformation()
        {
            this.ChangeTracker
                .Entries()
                .ToList()
                .ForEach(entry =>
                {
                    if (entry.Entity is IEntity entity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedOn = DateTime.UtcNow;
                            entity.UserId = currentUser.GetId();
                        }
                    }
                });
        }
    }
}
