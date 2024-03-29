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
    public class SubjectBL : ISubjectBL
    {
        public async Task AddSubject(Subject subject)
        {
            var dbContext = new AppDBContext();
            await dbContext.Subjects.AddAsync(subject);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteSubject(int subjectId)
        {
            var dbContext = new AppDBContext();
            var subject = await dbContext.Subjects.Where(s => s.SubjectId == subjectId).FirstOrDefaultAsync();
            if (subject != null)
            {
                dbContext.Subjects.Remove(subject);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Subject not found");
            }
        }

        public async Task<Subject> GetSubject(int subjectId)
        {
            var dbContext = new AppDBContext();
            var subject = await dbContext.Subjects.Where(s => s.SubjectId == subjectId).FirstOrDefaultAsync();
            if (subject != null)
            {
                return subject;
            }
            else
            {
                throw new Exception("Subject not found");
            }
        }

        public async Task UpdateSubject(Subject subject, int subjectId)
        {
            var dbContext = new AppDBContext();

            var dbSubject = await dbContext.Subjects.FirstOrDefaultAsync(s => s.SubjectId == subjectId)
                            ?? throw new Exception("Subject not found");

            if (subject.Title != dbSubject.Title)
                dbSubject.Title = subject.Title;

            if (subject.Description != dbSubject.Description)
                dbSubject.Description = subject.Description;

            if (subject.SchoolName != dbSubject.SchoolName)
                dbSubject.SchoolName = subject.SchoolName;

            if (subject.ColorCode != dbSubject.ColorCode)
                dbSubject.ColorCode = subject.ColorCode;

            if (subject.CreatedBy != dbSubject.CreatedBy)
                dbSubject.CreatedBy = subject.CreatedBy;

            if (subject.UpdatedAt != dbSubject.UpdatedAt)
                dbSubject.UpdatedAt = subject.UpdatedAt;

            await dbContext.SaveChangesAsync();
        }

    }
}
