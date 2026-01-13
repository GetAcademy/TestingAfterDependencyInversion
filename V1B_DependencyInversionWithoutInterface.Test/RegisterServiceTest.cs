using V1B_DependencyInversionWithoutInterface.Core;
using V1B_DependencyInversionWithoutInterface.Core.Model;

namespace V1A_DependencyInjection.Test
{
    public class Tests
    {
        [Test]
        public void TestRegisterNewUsername()
        {
            // arrange
            var isTaken = false;

            // act
            var request = new RegisterRequest("terje");
            var registerResponse = RegisterService.Register(request, isTaken);

            // assert
            Assert.That(registerResponse.Success, Is.True);
            Assert.That(registerResponse.Message, Is.SameAs("User registered."));
        }

        [Test]
        public void TestRegisterExistingUsername()
        {
            // arrange
            var isTaken = true;

            // act
            var request = new RegisterRequest("terje");
            var registerResponse = RegisterService.Register(request, isTaken);

            // assert
            Assert.That(registerResponse.Success, Is.False);
            Assert.That(registerResponse.Message, Is.SameAs("Username is already taken."));
        }

        [Test]
        public void TestRegisterShortUsername()
        {
            // arrange
            var isTaken = true;

            // act
            var request = new RegisterRequest("te");
            var registerResponse = RegisterService.Register(request, isTaken);

            // assert
            Assert.That(registerResponse.Success, Is.False);
            Assert.That(registerResponse.Message, Is.SameAs("Username must be at least 3 characters."));
        }
    }
}
