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
            serviceCollection.AddScoped<ISubjectBL, SubjectBL>();
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

    public class SubjectTests : IClassFixture<MyFixture>
    {
        public ISubjectBL _subjectBL;
        public IUserBL _userBL;

        public SubjectTests()
        {
            var serviceProvider = new ServiceCollection()
            .AddScoped<ISubjectBL, SubjectBL>()
            .AddScoped<IUserBL, UserBL>()
            .BuildServiceProvider();

            // Resolve the service
            _userBL = serviceProvider.GetRequiredService<IUserBL>();
            _subjectBL = serviceProvider.GetRequiredService<ISubjectBL>();
        }

        [Fact]
        public async Task AddSubject_SubjectDoesntExist_IsAdded()
        {
            // Arrange
            var subject = new Subject { ColorCode = "123", Description = "123", SchoolName = "123", Title = "123" };
            var user = new User { FirstName = "John", LastName = "Doe", Email = "123" };

            // variable for random uuid
            var subjectId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();

            // add user
            await _userBL.AddUser(user, userId);

            // add subject
            await _subjectBL.AddSubject(userId, subjectId, subject);

            // gets subject
            var dbSubject = await _subjectBL.GetSubject(subjectId);

            // is identical
            Assert.Equal(subject.ColorCode, dbSubject.ColorCode);
            Assert.Equal(subject.Description, dbSubject.Description);
            Assert.Equal(subject.SchoolName, dbSubject.SchoolName);
            Assert.Equal(subject.Title, dbSubject.Title);
        }
    }
}
