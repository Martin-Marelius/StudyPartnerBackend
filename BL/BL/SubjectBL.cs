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
        public async Task AddSubject(string userId, string subjectId, Subject subject)
        {
            var dbContext = new AppDBContext();
            var user = await dbContext.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync() ?? throw new Exception("User not found");

            subject.UserId = user.Id;
            subject.SubjectId = subjectId;
            subject.CreatedAt = DateTime.Now;
            subject.UpdatedAt = DateTime.Now;
            subject.UpdatedBy = user.Id;

            await dbContext.Subjects.AddAsync(subject);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteSubject(string subjectId)
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

        public async Task<Subject> GetSubject(string subjectId)
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

        public async Task UpdateSubject(Subject subject, string subjectId)
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

            dbSubject.UpdatedAt = DateTime.Now;

            await dbContext.SaveChangesAsync();
        }

    }
}
