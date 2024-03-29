using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IBL
{
    public interface IDeadlineBL
    {
        Task AddDeadline(Deadline deadline);
        Task DeleteDeadline(string deadlineId);
        Task<Deadline> GetDeadline(string deadlineId);
        Task UpdateDeadline(Deadline deadline, string deadlineId);
    }
}
