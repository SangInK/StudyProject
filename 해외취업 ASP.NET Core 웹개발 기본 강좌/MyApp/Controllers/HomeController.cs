using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Repositories;
using MyApp.ViewModels;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        #region ==================== 생성자 Region
        public HomeController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        #endregion


        #region ==================== 전역변수 Region
        private readonly ITeacherRepository _teacherRepository;

        #endregion


        #region ==================== 함수 Region
        public IActionResult Index()
        {
            var teachers = _teacherRepository.GetAllTeachers();

            StudentTeacherViewModel viewModel = new StudentTeacherViewModel()
            {
                Teachers = teachers
            };

            return View(viewModel);
        }

        public IActionResult Student()
        {
            StudentTeacherViewModel viewModel = new StudentTeacherViewModel()
            {
                Teachers = _teacherRepository.GetAllTeachers()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Student(StudentTeacherViewModel model){
            //[Bind("Name", "Age")]Student model

            if (ModelState.IsValid)
            {

            }
            else
            {
                // 에러
            }

            return View();
        }
        #endregion
    }
}
