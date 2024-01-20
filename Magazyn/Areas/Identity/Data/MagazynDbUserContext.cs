using Magazyn.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Magazyn.Areas.Identity.Data;

public class MagazynDbUserContext : IdentityDbContext<MagazynUser>
{
    public MagazynDbUserContext(DbContextOptions<MagazynDbUserContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new MagazynUserEntityConfiguration());
    }
}


public class MagazynUserEntityConfiguration : IEntityTypeConfiguration<MagazynUser>
{
     public void Configure(EntityTypeBuilder<MagazynUser> builder)
    {

        builder.Property(u => u.Imie).HasMaxLength(255);
        builder.Property(u => u.Nazwisko).HasMaxLength(255);
    }
}