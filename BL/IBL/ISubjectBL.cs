using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IBL
{
    public interface ISubjectBL
    {
        Task AddSubject(string userId, string subjectId, Subject subject);
        Task DeleteSubject(string subjectId);
        Task<Subject> GetSubject(string subjectId);
        Task UpdateSubject(Subject subject, string subjectId);
    }
}
