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
    public class UserBL : IUserBL
    {
        public async Task AddUser(User user, string userId)
        {
            var dbContext = new AppDBContext();

            if (await dbContext.Users.AnyAsync(u => u.UserId == userId))
            {
                throw new Exception("User already exists");
            }

            user.UserId = userId;
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(string userId)
        {
            var dbContext = new AppDBContext();
            var user = await dbContext.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();
            if (user != null)
            {
                dbContext.Users.Remove(user);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task<User> GetUser(string userId)
        {
            var dbContext = new AppDBContext();
            var user = await dbContext.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public async Task UpdateUser(User user, string userId)
        {
            var dbContext = new AppDBContext();

            var dbUser = await dbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId)
                            ?? throw new Exception("User not found");

            if (user.FirstName != dbUser.FirstName)
                dbUser.FirstName = user.FirstName;

            if (user.LastName != dbUser.LastName)
                dbUser.LastName = user.LastName;

            if (user.Email != dbUser.Email)
                dbUser.Email = user.Email;

            if (user.SchoolName != dbUser.SchoolName)
                dbUser.SchoolName = user.SchoolName;

            await dbContext.SaveChangesAsync();
            
        }

    }
}
