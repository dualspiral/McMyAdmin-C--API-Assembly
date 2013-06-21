using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using McMyAdminAPI.Interfaces;
using Moq;
using NUnit.Framework;
using McMyAdminAPI.Implementations;

namespace McMyAdminAPI.NUnitTests
{
    /// <summary>
    /// Test fixture for testing the API
    /// </summary>
    [TestFixture]
    public class APITests
    {
        /// <summary>
        /// Checks that a valid login gives the expected result.
        /// </summary>
        [Test]
        public void ValidLoginGivesExpectedResult()
        {
            // Create a mock server caller.
            Mock<IServerCaller> mockServerCaller = new Mock<IServerCaller>();
            mockServerCaller
                .Setup<string>(c => c.Query("login", It.IsAny<Dictionary<string, string>>()))
                .Returns(() => "{\"authmask\":1081247,\"usermask\":0,\"MCMASESSIONID\":\"00000000-0000-0000-0000-000000000000\",\"RDTOKEN\":\"00000000-0000-0000-0000-000000000000\",\"status\":200,\"success\":true}");

            // Register the Api with the mock server caller.
            IMcmadApi api = new McmadApi(mockServerCaller.Object);

            // Call the login command, and assert that it is successful.
            Assert.True(api.Login("username", "password"), "The login method did not return true as expected");

            // Verify we called the Query method.
            mockServerCaller.Verify(c => c.Query("login", It.IsAny<Dictionary<string, string>>()), Times.Once());

            // Check the UserMask is zero
            Assert.AreEqual(0, api.UserPermissionMask.GetRawUserMask, "The UserMask was not set to what it was expected to be!");

            // Check the AuthMask is 1081247
            Assert.AreEqual(1081247, api.AuthorisationMask.GetRawAuthMask, "The AuthorisationMask was not set to what it was expected to be!");

            // Check we set the session token
            mockServerCaller.VerifySet(c => c.SessionToken = "00000000-0000-0000-0000-000000000000", "The session token was not set as expected");
        }
    }
}
