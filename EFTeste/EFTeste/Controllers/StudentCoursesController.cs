using EFTeste.Repository;
using EFTeste.ViewModels.StudentCourses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EFTeste.Controllers
{
	public class StudentCoursesController : Controller
	{
		private readonly ICourseRepository _courseRepository;
		private readonly IStudentRepository _studentRepository;
		private readonly IStudentCoursesRepository _studentCoursesRepository;

		public StudentCoursesController
			(
			ICourseRepository courseRepository,
			IStudentRepository studentRepository, 
			IStudentCoursesRepository studentCoursesRepository
			)
		{
			_courseRepository = courseRepository;
			_studentRepository = studentRepository;
			_studentCoursesRepository = studentCoursesRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Index() // Todos os alunos com seus cursos. async -> método passa a ser assincrono
												 // IActionResult -> tipo de retorno do método Index, ele pode retornar diferentes tipos de respostas HTTP, como o erro 404, erro 500, ou *uma página HTML*.
		{
			var data = await _studentRepository.GetAll(); // variável data passa a ser uma variável tipo lista de student.
			return View(data);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var viewModel = new StudentCoursesViewModel();

			viewModel.Students = await _studentRepository.GetAllNotEnrolled();

			viewModel.SetCourses(await _courseRepository.GetAll());

			return View(viewModel);
		}
<<<<<<< HEAD
		
=======
		[HttpGet]
		public async Task<IActionResult> Index() // Todos os alunos com seus cursos. async -> método passa a ser assincrono
												 // IActionResult -> tipo de retorno do método Index, ele pode retornar diferentes tipos de respostas HTTP, como o erro 404, erro 500, ou *uma página HTML*.
		{
			var data = await _studentRepository.GetAll(); // variável data passa a ser uma variável tipo lista de student.
			return View(data);
		}

>>>>>>> 90cfaff26b9265a124d05361a733fa8278246bd5
		[HttpPost]

		public async Task<IActionResult> Create(StudentCoursesViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				foreach (var c in viewModel.Courses)
				{
					if (c.IsSelected)
					{
						await _studentCoursesRepository.Create(new Models.StudentCourses { StudentID = viewModel.StudentId, CourseID = c.Id!, SignDate = DateTime.Now }); //Exclamação na frente é negação, atrás é para dizer que o parâmetro não pode ser nulo
					}
				}
			}
			return RedirectToAction("Index");
		}
	}
}
