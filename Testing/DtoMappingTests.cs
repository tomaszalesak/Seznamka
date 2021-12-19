using AutoMapper;
using BusinessLayer;
using BusinessLayer.DataTransferObjects;
using Domain.Entities;
using Domain.Enums;
using System;
using Xunit;

namespace Testing
{
    public class DtoMappingTests
    {
        private static readonly Mapper mapper = new Mapper(new MapperConfiguration(MappingConfig.ConfigureMap));

        [Fact]
        public void UserDto_To_UserRegDto_Mapping_Test()
        {
            var tmpDate = DateTime.Now;

            var testUserDto = new UserRegistrationDto
            {
                Name = "Janko",
                Surname = "Hrasko",
                Username = "jankoh",
                Password = "nbu123",
                Birthdate = tmpDate,
                Gender = Gender.Male
            };

            var userToMap = new UserDto
            {
                Name = "Janko",
                Surname = "Hrasko",
                Username = "jankoh",
                Birthdate = tmpDate,
                Gender = Gender.Male
            };

            var mappedUser = mapper.Map<UserDto>(userToMap);

            Assert.Equal(testUserDto.Name, mappedUser.Name);
            Assert.Equal(testUserDto.Surname, mappedUser.Surname);
            Assert.Equal(testUserDto.Username, mappedUser.Username);
            Assert.Equal(testUserDto.Birthdate, mappedUser.Birthdate);
            Assert.Equal(testUserDto.Gender, mappedUser.Gender);
        }

        [Fact]
        public void UserDto_To_User_Mapping_Test()
        {
            var tmpDate = DateTime.Now;

            var testUserDto = new User
            {
                Name = "Janko",
                Surname = "Hrasko",
                Username = "jankoh",
                Birthdate = tmpDate,
                Gender = Gender.Male
            };

            var userToMap = new UserDto
            {
                Name = "Janko",
                Surname = "Hrasko",
                Username = "jankoh",
                Birthdate = tmpDate,
                Gender = Gender.Male
            };

            var mappedUser = mapper.Map<UserDto>(userToMap);

            Assert.Equal(testUserDto.Name, mappedUser.Name);
            Assert.Equal(testUserDto.Surname, mappedUser.Surname);
            Assert.Equal(testUserDto.Username, mappedUser.Username);
            Assert.Equal(testUserDto.Birthdate, mappedUser.Birthdate);
            Assert.Equal(testUserDto.Gender, mappedUser.Gender);
        }
    }
}
