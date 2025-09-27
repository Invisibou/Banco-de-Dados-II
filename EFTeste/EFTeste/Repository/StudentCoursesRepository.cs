//Professor postou um artigo para vermos como que iremos implementar na VIEW, visualizar para fazer a tarefa.

using EFTeste.Data;
using EFTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTeste.Repository
{
	public class StudentCoursesRepository : IStudentCoursesRepository
	{
		private readonly SchoolContext _schoolContext;

		public StudentCoursesRepository(SchoolContext schoolContext)
		{
			_schoolContext = schoolContext;
		}
		public async Task Create(StudentCourses studentCourse)
		{
			await _schoolContext.StudentCourses.AddAsync(studentCourse);
			await _schoolContext.SaveChangesAsync();
		}
		public async Task Update(StudentCourses studentCourse)
		{
			_schoolContext.StudentCourses.Update(studentCourse);
			await _schoolContext.SaveChangesAsync();
		}

		public async Task Delete(StudentCourses studentCourse)
		{
			_schoolContext.Remove(studentCourse);
			await _schoolContext.SaveChangesAsync();
		}

		public async Task<StudentCourses?> Get(int studentId, int courseId)
		{
			var data = await _schoolContext.StudentCourses
							.Include(x => x.Course)
							.Include(x => x.Student)
							.Where(w => w.StudentID == studentId && w.CourseID == courseId) 
							.FirstOrDefaultAsync();
			return data;
		}

		public async Task<List<StudentCourses>> GetAll()
		{
			var data = await _schoolContext.StudentCourses
							.Include(x => x.Course)
							.Include(x => x.Student)
							.ToListAsync();

			return data;
		}

		public async Task<List<StudentCourses>?> GetByCourseId(int courseId)
		{
			{
				var data = await _schoolContext.StudentCourses
								.Include(x => x.Course)
								.Include(x => x.Student)
								.Where(w => w.CourseID == courseId)
								.ToListAsync();

				return data;
			}
		}
		public async Task<List<StudentCourses>> GetByCourseName(string name)
		{
			var data = await _schoolContext.StudentCourses
								.Include(x => x.Course)
								.Include(x => x.Student)
								.Where(w => w.Course!.Name!.ToLower().Contains(name.ToLower()))
								.ToListAsync();
			return data;
		}

		public async Task<List<StudentCourses>?> GetByStudentId(int studentId)
		{
			var data = await _schoolContext.StudentCourses
								.Include(x =>  x.Student)
								.ToListAsync();

			return data;
		}

		public async Task<List<StudentCourses>> GetByStudentName(string name)
		{
			var data = await _schoolContext.StudentCourses
								.Include(x => x.Course)
								.Include(x => x.Student)
								.Where(w => w.Student!.FirstMidName!.ToLower().Contains(name.ToLower()) || w.Student.LastName.ToLower().Contains(name.ToLower()))
								.ToListAsync();
			return data;
		}

		
	}
}
