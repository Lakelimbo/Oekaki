using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Oekaki.Data.Models;

namespace Oekaki.Data;

public class ApplicationDbContext
    : IdentityDbContext<User, Role, string, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Oekaki");

        // Keep tables in alphabetical order
        // but "base" tables should come first
        // e.g. Roles before RoleClaims

        builder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles");

            entity
                .HasMany(e => e.UserRoles)
                .WithOne(role => role.Role)
                .HasForeignKey(userRole => userRole.RoleId)
                .IsRequired();
            entity
                .HasMany(e => e.RoleClaims)
                .WithOne(role => role.Role)
                .HasForeignKey(roleClaim => roleClaim.RoleId)
                .IsRequired();
        });
        builder.Entity<RoleClaim>().ToTable("RoleClaims");

        builder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.Property(e => e.Nickname).HasMaxLength(24).IsRequired();
            entity.HasIndex(e => e.URISlug).IsUnique();

            entity
                .HasMany(e => e.Claims)
                .WithOne(user => user.User)
                .HasForeignKey(claim => claim.UserId)
                .IsRequired();
            entity
                .HasMany(e => e.Logins)
                .WithOne(user => user.User)
                .HasForeignKey(login => login.UserId)
                .IsRequired();
            entity
                .HasMany(e => e.Tokens)
                .WithOne(user => user.User)
                .HasForeignKey(token => token.UserId)
                .IsRequired();
            entity
                .HasMany(e => e.UserRoles)
                .WithOne(user => user.User)
                .HasForeignKey(role => role.UserId)
                .IsRequired();
        });
        builder.Entity<UserClaim>().ToTable("UserClaims");
        builder.Entity<UserLogin>().ToTable("UserLogins");
        builder.Entity<UserRole>().ToTable("UserRoles");
        builder.Entity<UserToken>().ToTable("UserTokens");
    }

    public override int SaveChanges()
    {
        // for Users
        this.EnsureUniqueURISlugs();

        return base.SaveChanges();
    }

    public DbSet<Test> Tests => Set<Test>();
}
