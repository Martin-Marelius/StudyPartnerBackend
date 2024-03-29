using BusinessLogic.BL;
using BusinessLogic.IBL;
using Database.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.BL
{
    public class MyFixture : IDisposable
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public MyFixture()
        {
            // Set up dependency injection container
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IUserBL, UserBL>();
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public void Dispose()
        {
            // Dispose of any resources if necessary
            if (ServiceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
    public class UserTests : IClassFixture<MyFixture>
    {
        private readonly IUserBL _userBL;

        public UserTests() 
        {
            var serviceProvider = new ServiceCollection()
            .AddScoped<IUserBL, UserBL>()
            .BuildServiceProvider();

            // Resolve the service
            _userBL = serviceProvider.GetRequiredService<IUserBL>();
        }


        [Fact]
        public async Task AddUser_UserDoesntExist_IsAdded()
        {
            // Arrange
            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "123"
            };

            // variable for random uuid
            var id = Guid.NewGuid().ToString();

            // add user
            await _userBL.AddUser(user, id);

            // gets user
            var dbUser = await _userBL.GetUser(id);

            // is identical
            Assert.Equal(user.FirstName, dbUser.FirstName);
            Assert.Equal(user.LastName, dbUser.LastName);
            Assert.Equal(user.Email, dbUser.Email);
        }
    }
}
