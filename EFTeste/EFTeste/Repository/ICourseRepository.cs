using EFTeste.Models;

namespace EFTeste.Repository
{
	public interface ICourseRepository
	{
			public Task Create(Course Course);
			public Task Edit(Course Course);
			public Task Delete(Course Course);
			public Task<Course?> GetById(int id);
			public Task<List<Course>> GetAll();
			public Task<List<Course>> GetByName(string name);
	}
}