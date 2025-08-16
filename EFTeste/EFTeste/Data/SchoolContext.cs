using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EFTeste.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace EFTeste.Data
{
	public class SchoolContext : DbContext
	{
		public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) 
		{

		}

		public DbSet<Student> Students { get; set; } // Get set = permissão de leitura e escrita
		public DbSet<Course> Courses { get; set; } //DbSet é criar um dado do tipo Tabela, toda tabela é uma lista, mas nem todo dado de lista é uma tabela.
		public DbSet<StudentCourses> StudentCourses { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>().ToTable("Student");
			modelBuilder.Entity<Course>().ToTable("Course"); //Aqui estamos somente convertendo o nome da tabela que criamos, para manter o padrão
		}
	}
}
