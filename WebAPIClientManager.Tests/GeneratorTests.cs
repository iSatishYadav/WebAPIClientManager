using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPIClientManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIClientManager.Tests
{
    [TestClass()]
    public class GeneratorTests
    {
        [TestMethod]
        public void GetClientSecret_Should_ReturnNotNullFixedCharacterSecrets_When_LengthOfSecretSpecified()
        {
            // Arrange
            // Act
            var clientSecret = Generator.GetNewClientSecret(64);

            // Assert
            Assert.IsNotNull(clientSecret);
            
        }
        [TestMethod]
        public void GetClientId_Should_ReturnNonDuplicateClientIds_When_CalledMultipleTimes()
        {
            // Arrange
            // Act

            var ids = Enumerable.Range(0, 10000).Select(x => Generator.GetClientId()).ToList();

            // Assert
            Assert.IsTrue(ids.Count == ids.Distinct().Count());
        }

        [TestMethod]
        public void GetNewClientIdClientSecret_Should_NotProvideSamePairs_When_CalledTwice()
        {
            // Arrange
            // Act

            var idSecretPair1 = Generator.GetNewClientIdAndClientSecret(64);
            var idSecretPair2 = Generator.GetNewClientIdAndClientSecret(64);

            // Assert

            Assert.AreNotEqual(idSecretPair1.ClientId, idSecretPair2.ClientId);
            Assert.AreNotEqual(idSecretPair1.ClientSecret, idSecretPair2.ClientSecret);

        }        
    }
}