using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendStrongmanDudlBLOG.DB;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> oOptions) : base(oOptions) { }
    
    public DbSet<LoginEntity> Login { get; set; }

    protected override void OnModelCreating(ModelBuilder oModelBuilder)
    {
        base.OnModelCreating(oModelBuilder);

        oModelBuilder.Entity<LoginEntity>(entity =>
        {
            entity.ToTable("Login");

            entity.HasKey(e => e.nID);
            entity.Property(e => e.sUsername).HasColumnName("Username");
            entity.Property(e => e.sEMail).HasColumnName("EMail");
            entity.Property(e => e.sPassword).HasColumnName("Password");
        });
    }
}