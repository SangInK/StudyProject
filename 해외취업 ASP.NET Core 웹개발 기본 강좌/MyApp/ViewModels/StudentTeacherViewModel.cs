using MyApp.Models;

namespace MyApp.ViewModels
{
    public class StudentTeacherViewModel
    {
        public Student Student { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public Teacher Teacher { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }

    }
}
