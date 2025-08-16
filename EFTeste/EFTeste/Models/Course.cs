namespace EFTeste.Models
{
	public class Course
	{
		public int ID { get; set; }
		public string? Name { get; set; }
		public List<StudentCourses>? StudentCourses { get; set; }
	}
}
