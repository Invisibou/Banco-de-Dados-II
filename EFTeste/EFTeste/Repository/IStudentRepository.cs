using EFTeste.Models;

namespace EFTeste.Repository
{
	public interface IStudentRepository
	{
		public Task Create(Student student);
		public Task Update(Student student);
		public Task Delete(Student student);
		public Task<Student?> GetById(int id);
		public Task<List<Student>> GetAll();
		public Task<List<Student>> GetAllNotEnrolled(); //método que retorna uma lista de estudantes que não estão matriculados em nenhum curso.
		public Task<List<Student>> GetByName(string name);
	}
}
