using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;

namespace CourseManager.Repo.Repository
{
    public class StudentInCourseRepo : GenericRepo<StudentInCourse>, IStudentInCourseRepo
    {
        public StudentInCourseRepo(CourseManagerDBContext context) : base(context)
        {
        }
    }
}
