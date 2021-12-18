using Autofac.Extras.Moq;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Facades.FacadeImplementations;
using BusinessLayer.Facades.FacadeInterfaces;
using Domain.Enums;
using System;
using Xunit;
using Moq;

namespace Testing
{
    public class UserFacadeTests
    {
        [Fact]
        public void Register_Null_Argument_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                UserRegistrationDto? testRegUserDto = null;
                var testFacade = mock.Create<UserFacade>();

                Assert.ThrowsAsync<ArgumentNullException>(() => testFacade.RegisterAsync(testRegUserDto));
            }
        }

        [Fact]
        public void Username_Already_Exists_Test()    
        {
            using (var mock = AutoMock.GetLoose())
            {
                var testUser = new UserRegistrationDto
                {
                    Name = "Janko",
                    Surname = "Hrasko",
                    Username = "jankoh",
                    Password = "nbu123",
                    Birthdate = DateTime.Now,
                    Gender = Gender.Male,
                    Height = 180,
                    Weight = 90,
                    Bio = "",
                    Longitude = 0.5,
                    Latitude = 0.5,
                    Preferences = new PreferencesDto
                    {
                        MinAge = 18,
                        MaxAge = 30,
                        MinWeight = 50,
                        MaxWeight = 70,
                        MinHeight = 145,
                        MaxHeight = 175,
                        GpsRadius = 5
                    }
                };

                var anotherTestUser = new UserRegistrationDto
                {
                    Name = "Janko",
                    Surname = "Hrabko",
                    Username = "jankoh",
                    Password = "nbu12345453",
                    Birthdate = DateTime.Now,
                    Gender = Gender.Male,
                    Height = 189,
                    Weight = 95,
                    Bio = "",
                    Longitude = 0.5554,
                    Latitude = 0.556546,
                    Preferences = new PreferencesDto
                    {
                        MinAge = 18,
                        MaxAge = 30,
                        MinWeight = 50,
                        MaxWeight = 70,
                        MinHeight = 145,
                        MaxHeight = 175,
                        GpsRadius = 5
                    }
                };

                mock.Mock<IUserFacade>()
                    .Setup(uf => uf.RegisterAsync(testUser))
                    .ReturnsAsync("done");


                var userFacade = mock.Create<UserFacade>();
                _ = userFacade.RegisterAsync(testUser);

                Assert.ThrowsAsync<ArgumentException>(() => userFacade.RegisterAsync(anotherTestUser));
            }
        }
    }
}
