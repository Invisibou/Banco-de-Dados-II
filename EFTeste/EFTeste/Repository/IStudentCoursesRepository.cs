//kiss - Keep It Simple, Stupid
//yagni - You Aren't Gonna Need It 

using EFTeste.Models;

namespace EFTeste.Repository
{
	public interface IStudentCoursesRepository
	{
		public Task Create(StudentCourses studentCourse);
		public Task Update(StudentCourses studentCourse);
		public Task Delete(StudentCourses studentCourse);
		public Task<List<StudentCourses>?> GetByStudentId(int studentId);
		public Task<List<StudentCourses>?> GetByCourseId(int courseId);
		public Task<StudentCourses> Get(int studentId, int courseId);
		public Task<List<StudentCourses>> GetAll();
		public Task<List<StudentCourses>> GetByCourseName(string name);
		public Task<List<StudentCourses>> GetByStudentName(string name);
	}
}