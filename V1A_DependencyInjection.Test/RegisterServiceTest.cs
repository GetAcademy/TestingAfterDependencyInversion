using Moq;
using V1A_DependencyInjection.Core;
using V1A_DependencyInjection.Core.DomainService;
using V1A_DependencyInjection.Core.Model;

namespace V1A_DependencyInjection.Test
{
    public class Tests
    {
        [Test]
        public void TestRegisterNewUsername()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(ur => ur.IsTaken(It.IsAny<string>()))
                .Returns(false);

            var registerService = new RegisterService(mockUserRepository.Object);

            // act
            var registerResponse = registerService.Register(new RegisterRequest("terje"));

            // assert
            Assert.That(registerResponse.Success, Is.True);
            Assert.That(registerResponse.Message, Is.SameAs("User registered."));
        }

        [Test]
        public void TestRegisterExistingUsername()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(ur => ur.IsTaken(It.IsAny<string>()))
                .Returns(true);

            var registerService = new RegisterService(mockUserRepository.Object);

            // act
            var registerResponse = registerService.Register(new RegisterRequest("terje"));

            // assert
            Assert.That(registerResponse.Success, Is.False);
            Assert.That(registerResponse.Message, Is.SameAs("Username is already taken."));
        }

        [Test]
        public void TestRegisterShortUsername()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var registerService = new RegisterService(mockUserRepository.Object);

            // act
            var registerResponse = registerService.Register(new RegisterRequest("te"));

            // assert
            Assert.That(registerResponse.Success, Is.False);
            Assert.That(registerResponse.Message, Is.SameAs("Username must be at least 3 characters."));
        }
    }
}
