using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GreenHouse.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace GreenHouse.Data
{
	public class PlantContext : DbContext
	{
		public PlantContext(DbContextOptions<PlantContext> options) : base(options)
		{

		}
		public DbSet<Plant> Plants { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Plant>().ToTable("Plant");
		}
	}
}
