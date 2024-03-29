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
        Task AddSubject(Subject subject);
        Task DeleteSubject(int subjectId);
        Task<Subject> GetSubject(int subjectId);
        Task UpdateSubject(Subject subject, int subjectId);
    }
}
