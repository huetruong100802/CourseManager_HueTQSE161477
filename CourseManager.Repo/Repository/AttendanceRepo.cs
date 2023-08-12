using CourseManager.Repo.Models;
using CourseManager.Repo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Repo.Repository
{
    public class AttendanceRepo : GenericRepo<Attendance>, IAttendanceRepo
    {
        public AttendanceRepo(CourseManagerDBContext context) : base(context)
        {
        }
    }
}
