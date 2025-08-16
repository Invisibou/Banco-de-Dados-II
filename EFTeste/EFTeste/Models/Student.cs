using System.ComponentModel.DataAnnotations;

namespace EFTeste.Models
{
	public class Student
	{
		[Key]
		public int ID { get; set; }
		public string? LastName { get; set; }
		public string? FirstMidName { get; set; }
		public DateTime EnrollmentDate { get; set; }
		public List<StudentCourses>? StudentCourses { get; set; } // Para dizer que em um objeto da classe student, podemos ter vários cursos com o student matriculado, por isso em formato de lista e por isso estar na classe student
	}
}
