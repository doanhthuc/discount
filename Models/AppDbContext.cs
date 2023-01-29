using Microsoft.EntityFrameworkCore;

namespace DiscountAPI.Models;

public class AppDbContext : DbContext
{

  public AppDbContext()
  {
  }
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {

  }

  public DbSet<Discount> Discounts { get; set; }
  public DbSet<DiscountProduct> DiscountProducts { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Discount>().HasKey(d => d.id);
    modelBuilder.Entity<Discount>().Property(d => d.id).HasDefaultValueSql("uuid_generate_v4()");
    modelBuilder.Entity<Discount>().Ignore(x => x.listProductId);

    modelBuilder.Entity<DiscountProduct>().HasKey(d => new { d.discountId, d.productId });
  }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();
      var connectionString = configuration.GetConnectionString("defaultConnection");
      optionsBuilder.UseNpgsql(connectionString);
    }
  }
}
