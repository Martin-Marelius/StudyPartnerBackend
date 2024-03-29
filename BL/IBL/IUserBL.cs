using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IBL
{
    public interface IUserBL
    {
        Task AddUser(User user, string userId);
        Task DeleteUser(string userId);
        Task<User> GetUser(string userId);
        Task UpdateUser(User user, string userId);
    }
}
