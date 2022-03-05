using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Repositories;
using MyApp.ViewModels;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        #region ==================== 생성자 Region
        public HomeController(ITeacherRepository teacherRepository, IStudentRepository studentRepository)
        {
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
        }

        #endregion


        #region ==================== 전역변수 Region
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;

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
                Teachers = _teacherRepository.GetAllTeachers(),
                Students = _studentRepository.GetAllStudent()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Student(StudentTeacherViewModel model){
            //[Bind("Name", "Age")]Student model

            if (ModelState.IsValid)
            {
                _studentRepository.AddStudent(model.Student);
                _studentRepository.SaveEditData();

                ModelState.Clear();
            }
            else
            {
                // 에러
            }


            StudentTeacherViewModel viewModel = new StudentTeacherViewModel()
            {
                Students = _studentRepository.GetAllStudent()
            };

            return View(viewModel);
        }

        public IActionResult DetailStudent(int id)
        {
            StudentTeacherViewModel viewModel = new StudentTeacherViewModel()
            {
                Student = _studentRepository.GetStudent(id),
                Students = _studentRepository.GetAllStudent()
            };

            return View(viewModel);
        }

        public IActionResult UpdateStudent(int id)
        {
            StudentTeacherViewModel viewModel = new StudentTeacherViewModel()
            {
                Student = _studentRepository.GetStudent(id),
                Students = _studentRepository.GetAllStudent()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.UpdateStudent(student);
                _studentRepository.SaveEditData();
            }
            else
            {
                // 에러
            }

            return RedirectToAction("DetailStudent", new { id = student.Id });
        }
        #endregion
    }
}
