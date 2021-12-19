using Autofac.Extras.Moq;
using BusinessLayer.Services.Implementations;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence;
using Moq;
using System;
using Xunit;

namespace Testing
{
    public class UserServiceTests
    {
        [Fact]
        public void Get_Username_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var testUname = "jankoh";
                var testId = 1;

                mock.Mock<IRepository<User>>()
                    .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(new User
                    {
                        Id = testId,
                        Name = "Janko",
                        Surname = "Hrasko",
                        Username = testUname,
                        PasswordHash = "abc",
                        Birthdate = DateTime.Now,
                        Gender = Gender.Male,
                        Height = 180,
                        Weight = 90
                    });

                var userService = mock.Create<UserService>();
                var foundUname = userService.GetUsernameAsync(testId).Result;

                Assert.Equal(testUname, foundUname);
            }
        }

        [Fact]
        public void Get_User_By_Id()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var testId = 1;

                mock.Mock<IRepository<User>>()
                    .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(new User
                    {
                        Id = testId,
                        Name = "Janko",
                        Surname = "Hrasko",
                        Username = "Jankoh",
                        PasswordHash = "abc",
                        Birthdate = DateTime.Now,
                        Gender = Gender.Male,
                        Height = 180,
                        Weight = 90
                    });

                var testService = mock.Create<UserService>();
                var foundUser = testService.GetAsync(1).Result;

                Assert.Equal(testId, foundUser.Id);
            }
        }
    }
}
