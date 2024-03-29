using BusinessLogic.IBL;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BL
{
    public class CourseBL : ICourseBL
    {
        public async Task AddCourse(Course course)
        {
            var dbContext = new AppDBContext();

            await dbContext.Courses.AddAsync(course);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteCourse(string courseId)
        {
            var dbContext = new AppDBContext();

            var course = await dbContext.Courses.Where(c => c.CourseId == courseId).FirstOrDefaultAsync();

            if(course != null)
            {
                dbContext.Courses.Remove(course);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Course not found");
            }
        }

        public async Task<Course> GetCourse(string courseId)
        {
            var dbContext = new AppDBContext();
            var course = await dbContext.Courses.Where(c => c.CourseId == courseId).FirstOrDefaultAsync();

            if(course != null)
            {
                   return course;
            }
            else
            {
                throw new Exception("Course not found");
            }
        }

        public async Task UpdateCourse(Course course, string courseId)
        {
            var dbContext = new AppDBContext();
            
            var dbCourse = await dbContext.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId)
                            ?? throw new Exception("Course not found");

            if (course.Title != dbCourse.Title)
                dbCourse.Title = course.Title;

            if (course.Description != dbCourse.Description)
                dbCourse.Description = course.Description;

            if (course.StartTime != dbCourse.StartTime)
                dbCourse.StartTime = course.StartTime;

            if (course.EndTime != dbCourse.EndTime)
                dbCourse.EndTime = course.EndTime;

            if (course.Recurring != dbCourse.Recurring)
                dbCourse.Recurring = course.Recurring;

            if (course.SubjectId != dbCourse.SubjectId)
                dbCourse.SubjectId = course.SubjectId;

            await dbContext.SaveChangesAsync();
        }
    }
}
