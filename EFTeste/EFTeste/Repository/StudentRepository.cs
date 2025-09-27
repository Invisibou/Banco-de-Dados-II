using EFTeste.Data;
using EFTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTeste.Repository
{
	public class StudentRepository : IStudentRepository //A minha classe StudentRepository implementa a interface IStudentReposutiry,  intarface tem relação com compatibilidade e flexibilidade
														//Minha interface garante que todos os métodos que estão na interface, estejam implementados no meu repository.
														//Se tiver algum método que não esteja implementado, o C# já avisa na hora que tem algo errado.
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
						  .Include(sc => sc.StudentCourses!)
							.ThenInclude(c => c.Course) //ThenInclude é usado para incluir propriedades de navegação adicionais em uma consulta encadeada.
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

		public async Task<List<Student>> GetAllNotEnrolled()
		{
			var enrolledStudentsIds = _context.StudentCourses
											.Select(sc => sc.StudentID)
											.Distinct();
			var data = await _context.Students
						  .Include(sc => sc.StudentCourses!)
							.ThenInclude(c => c.Course) 
							.Where( w => !enrolledStudentsIds.Contains(w.ID))
							.OrderBy(s => s.FirstMidName)
						  .ToListAsync();	
			return data;
		}
	}
}
