using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EFTeste.Models;

namespace EFTeste.Data
{
	public class SchoolContext : DbContext
	{
		public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) 
		{

		}

		public DbSet<Student> Students { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>().ToTable("Student");
		}
	}
}
