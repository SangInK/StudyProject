using MyApp.Models;

namespace MyApp.Repositories
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteSutduent(Student student);
        IEnumerable<Student> GetAllStudent();
        Student GetStudent(int id);
        void SaveEditData();
    }
}