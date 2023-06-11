using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VaultOfGames.Areas.Identity.Data;

namespace VaultOfGames.Data;

public class VaultOfGamesContext : IdentityDbContext<VaultOfGamesUser>
{
    public VaultOfGamesContext(DbContextOptions<VaultOfGamesContext> options)
        : base(options)
    {
    }

    public DbSet<Models.VogReview> VogReview { get; set; }
    public DbSet<Models.UserReview> UserReview { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
