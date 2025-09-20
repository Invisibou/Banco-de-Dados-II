using EFTeste.Models;
using EFTeste.Data;
using Microsoft.EntityFrameworkCore;

namespace EFTeste.Repository
{
	public class CourseRepository : ICourseRepository
	{
		private readonly SchoolContext _context;

		public CourseRepository(SchoolContext context)
		{
			_context = context;
		}

		public async Task Create(Course Course)
		{
			await _context.Courses.AddAsync(Course);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Course Course)
		{
			_context.Courses.Remove(Course);
			await _context.SaveChangesAsync();
		}

		public async Task<List<Course>> GetAll()
		{
			return await _context.Courses.ToListAsync();
		}

		public async Task<Course?> GetById(int id)
		{
			return await _context.Courses
				.Where(c => c.ID == id)
				.FirstOrDefaultAsync();
		}

		public async Task<List<Course>> GetByName(string name)
		{
			return await _context.Courses
				.Where(w => w.Name!.ToLower() == name.ToLower())
				.ToListAsync();
		}

		public async Task Update(Course Course)
		{
			_context.Courses.Update(Course);
			await _context.SaveChangesAsync();
		}
	}
}
