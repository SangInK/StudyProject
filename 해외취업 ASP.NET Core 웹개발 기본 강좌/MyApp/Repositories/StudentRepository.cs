using MyApp.Data;
using MyApp.Models;

namespace MyApp.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        #region ==================== 생성자 Region
        public StudentRepository(MyAppContext context)
        {
            _context = context;
        }

        #endregion


        #region ==================== 전역변수 Region
        private readonly MyAppContext _context;

        #endregion


        #region ==================== 함수 Region
        public IEnumerable<Student> GetAllStudent()
        {
            var result = _context.Students.ToList();

            return result;
        }

        public Student GetStudent(int id)
        {
            Student student = _context.Students.Find(id);

            return student;
        }

        public void SaveEditData()
        {
            _context.SaveChanges();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
        }


        #endregion
    }
}
