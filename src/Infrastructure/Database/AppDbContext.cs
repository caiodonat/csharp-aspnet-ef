using Microsoft.EntityFrameworkCore;

using CAE.Domain.Entities;

namespace CAE.Infrastructure.Database;

public class AppDbContext : DbContext
{
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>()
			.HasIndex(et => et.Email)
			.IsUnique();
		base.OnModelCreating(modelBuilder);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseNpgsql("Host=db;Database=postgres;Username=postgres;Password=postgres");
	}

	public AppDbContext(
		DbContextOptions<AppDbContext> options
	) : base(options)
	{
	}

	public required DbSet<User> Users { get; set; }
}
