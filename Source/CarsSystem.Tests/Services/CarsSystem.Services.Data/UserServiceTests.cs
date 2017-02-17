﻿using System;
using NUnit.Framework;
using CarsSystem.Data.Models;
using CarsSystem.Data.Repositories;
using CarsSystem.Services.Data;
using Moq;
using CarsSystem.Services.Data.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CarsSystem.Tests.Services.CarsSystem.Services.Data
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void UsersService_ShouldThrowArgumentNullException_WhenPassedRepositoryIsNull()
        {
            IRepository<User> mockedRepository = null;

            Assert.Throws<ArgumentException>(() => new UsersService(mockedRepository));
        }

        [Test]
        public void UsersService_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenPassedRepositoryIsNull()
        {
            IRepository<User> mockedRepository = null;

            var expectedMessage = Assert.Throws<ArgumentException>(() => new UsersService(mockedRepository));

            Assert.IsTrue(expectedMessage.Message.Contains("null"));
        }

        [Test]
        public void UsersService_ShouldCreateInstanceOfUsersService_WhenPassedRepositoryIsCorrectly()
        {
            var mockedRepository = new Mock<IRepository<User>>();

            var service = new UsersService(mockedRepository.Object);

            Assert.IsInstanceOf<UsersService>(service);
        }

        [Test]
        public void UsersService_ShouldImplementsInterfaceIUsersService_WhenPassedRepositoryIsCorrectly()
        {
            var mockedRepository = new Mock<IRepository<User>>();

            var service = new UsersService(mockedRepository.Object);

            Assert.IsInstanceOf<IUsersService>(service);
        }

        [Test]
        public void UserService_VerifyThehMethodGetAllCars_IsCalled_WhenPassedParametersAreCorrect()
        {
            var listOfUser = new List<User>
            {
                new User() { Id="test", FirstName="Gosho", LastName="Pochivkata" },
                new User() { Id="test1", FirstName="Monti", LastName="Picha" },
                new User() { Id="test2", FirstName="Marin", LastName="The hunter" },

            };
            var mockedRepo = new Mock<IRepository<User>>();
            mockedRepo.Setup(m => m.All()).Returns(listOfUser);
            var service = new UsersService(mockedRepo.Object);

            service.GetAllUsers();

            mockedRepo.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void UserService_VerifyThehMethodGetCarById_IsCalled_WhenPassedParametersAreCorrect()
        {
            var user = new User() { Id = "test", FirstName = "Gosho", LastName = "Pochivkata" };
            var mockedRepo = new Mock<IRepository<User>>();
            mockedRepo.Setup(c => c.GetById("test")).Returns(user);
            var service = new UsersService(mockedRepo.Object);

            service.GetUserById("test");

            mockedRepo.Verify(m => m.GetById("test"), Times.Exactly(1));
        }

        [Test]
        public void UserService_GetUserByIdWorksProperly_WhenPassedParametersAreCorrect()
        {
            var user = new User() { Id = "test", FirstName = "Gosho", LastName = "Pochivkata" };
            var mockedRepo = new Mock<IRepository<User>>();
            mockedRepo.Setup(c => c.GetById("test")).Returns(user);
            var service = new UsersService(mockedRepo.Object);

            var result = service.GetUserById("test");

            Assert.AreEqual(user.FirstName, result.FirstName);
        }

        [Test]
        public void UserService_GetAllUsersMethodWorksProperly_WhenPassedParametersAreCorrect()
        {
            var listOfUser = new List<User>
            {
                new User() { Id="test", FirstName="Gosho", LastName="Pochivkata" },
                new User() { Id="test1", FirstName="Monti", LastName="Picha" },
                new User() { Id="test2", FirstName="Marin", LastName="The hunter" },

            };
            var mockedRepo = new Mock<IRepository<User>>();
            mockedRepo.Setup(m => m.All()).Returns(listOfUser);
            var service = new UsersService(mockedRepo.Object);

            var result = service.GetAllUsers().ToList();

            Assert.AreEqual(listOfUser.Count, result.Count);
        }
    }
}
