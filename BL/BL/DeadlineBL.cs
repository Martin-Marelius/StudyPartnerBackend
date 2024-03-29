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
    public class DeadlineBL : IDeadlineBL
    {
        public async Task AddDeadline(Deadline deadline)
        {
            var dbContext = new AppDBContext();
            await dbContext.Deadlines.AddAsync(deadline);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteDeadline(int deadlineId)
        {
            var dbContext = new AppDBContext();
            var deadline = await dbContext.Deadlines.Where(d => d.DeadlineId == deadlineId).FirstOrDefaultAsync();
            if (deadline != null)
            {
                dbContext.Deadlines.Remove(deadline);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Deadline not found");
            }
        }

        public Task<Deadline> GetDeadline(int deadlineId)
        {
            var dbContext = new AppDBContext();
            var deadline = dbContext.Deadlines.Where(d => d.DeadlineId == deadlineId).FirstOrDefaultAsync();
            if (deadline != null)
            {
                return deadline;
            }
            else
            {
                throw new Exception("Deadline not found");
            }
        }

        public async Task UpdateDeadline(Deadline deadline, int deadlineId)
        {
            var dbContext = new AppDBContext();
            
            var dbDeadline = await dbContext.Deadlines.FirstOrDefaultAsync(d => d.DeadlineId == deadlineId)
                                ?? throw new Exception("Deadline not found");

            if (deadline.Title != dbDeadline.Title)
                dbDeadline.Title = deadline.Title;

            if (deadline.Description != dbDeadline.Description)
                dbDeadline.Description = deadline.Description;

            if (deadline.DueDate != dbDeadline.DueDate)
                dbDeadline.DueDate = deadline.DueDate;

            if (deadline.SubjectId != dbDeadline.SubjectId)
                dbDeadline.SubjectId = deadline.SubjectId;

            await dbContext.SaveChangesAsync();
            
        }

    }
}
