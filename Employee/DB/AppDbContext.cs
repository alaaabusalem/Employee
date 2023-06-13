using Employee.DB.Extentions;
using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.DB
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Employees> _Employees { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {

			modelBuilder.seed();
		}
	}
}
