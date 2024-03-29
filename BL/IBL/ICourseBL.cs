using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IBL
{
    public interface ICourseBL
    {
        Task AddCourse(Course course);
        Task DeleteCourse(string courseId);
        Task<Course> GetCourse(string courseId);
        Task UpdateCourse(Course course, string courseId);
    }
}
