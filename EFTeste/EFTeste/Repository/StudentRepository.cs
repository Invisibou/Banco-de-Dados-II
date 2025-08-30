using EFTeste.Data;
using EFTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTeste.Repository
{
	public class StudentRepository : IStudentRepository //A minha classe StudentRepository implementa a interface IStudentReposutiry,  intarface tem relação com compatibilidade e flexibilidade
	{
		private readonly SchoolContext _context;
		public StudentRepository(SchoolContext context)
		{
			_context = context;
		}
		public async Task Create(Student student)
		{
			await _context.Students.AddAsync(student);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Student student)
		{
			_context.Students.Remove(student);
			await _context.SaveChangesAsync();
		}
		public async Task Update(Student student)
		{
			_context.Students.Update(student);
			await _context.SaveChangesAsync();
		}

		public async Task<List<Student>> GetAll()
		{
			var students = await _context
						  .Students
						  .ToListAsync();
			return students;
		}

		public async Task<Student?> GetById(int id)
		{
			var student = await _context
						  .Students
						  .Where(s => s.ID == id)
						  .FirstOrDefaultAsync();
			return student;
		}

		public async Task<List<Student>> GetByName(string name)
		{
			var students = await _context
						  .Students
						  .Where(s => s.FirstMidName!.ToLower().Contains(name.ToLower()))
						  .ToListAsync();
			return students;
		}
	}
}
