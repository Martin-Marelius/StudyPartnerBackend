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
        Task DeleteDeadline(int deadlineId);
        Task<Deadline> GetDeadline(int deadlineId);
        Task UpdateDeadline(Deadline deadline, int deadlineId);
    }
}
