using MyApp.Data;
using MyApp.Models;

namespace MyApp.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        #region ==================== 생성자 Region
        public TeacherRepository(MyAppContext context)
        {
            _context = context;
        }

        #endregion


        #region ==================== 전역변수 Region
        private readonly MyAppContext _context;

        #endregion


        #region ==================== 함수 Region
        public IEnumerable<Teacher> GetAllTeachers()
        {
            var result = _context.Teachers.ToList();

            return result;
        }

        public Teacher GetTeacher(int id)
        {
            Teacher teacher = _context.Teachers.Find(id);

            return teacher;
        }

        #endregion
    }
}
