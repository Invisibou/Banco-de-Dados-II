using System.Diagnostics;
using System.Threading.Tasks;
using EFTeste.Data;
using EFTeste.Models;
using EFTeste.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFTeste.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepository _studentRepository;
        

        public HomeController(
            ILogger<HomeController> logger,
            IStudentRepository studentRepository
        )
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _studentRepository.GetAll() );
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.Create(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentRepository.GetById(id);
            if(student == null)
            {
                return NotFound();
            }
            await _studentRepository.Delete(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(Student student)
        {
            if (ModelState.IsValid) 
            {
				await _studentRepository.Update(student);
				return RedirectToAction("Index");
			}
            return View(student);
		}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
