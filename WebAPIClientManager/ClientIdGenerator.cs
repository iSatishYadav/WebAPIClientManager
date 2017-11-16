using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIClientManager
{
    public class Generator
    {
        #region Get Client Id
        /// <summary>
        /// Generates a new Client Id
        /// </summary>
        /// <returns></returns>
        public static Guid GetClientId()
        {
            return ClientIdHelper();
        }
        #endregion

        #region Get New Client Id And Client Secret
        /// <summary>
        /// Generates a new Client Id and Client Secret pair. <paramref name="clientSecretSize"/> determines the size of Client Secret, default in 64.
        /// </summary>
        /// <param name="clientSecretSize">Size (in bits) of Client Secret</param>
        /// <returns></returns>
        public static ClientIdClientSecretPair GetNewClientIdAndClientSecret(int clientSecretSize = 64)
        {
            var clientId = ClientIdHelper();
            return new ClientIdClientSecretPair
            {
                ClientId = clientId,
                ClientSecret = ClientSecretHelper(clientSecretSize)
            };
        }
        #endregion

        /// <summary>
        /// Generates a new Client Secret. <paramref name="clientSecretSize"/> determines the size of Client Secret, default in 64.
        /// </summary>
        /// <param name="clientSecretSize">Size (in bits) of Client Secret</param>
        /// <returns></returns>
        public static string GetNewClientSecret(int clientSecretSize = 64)
        {
            return ClientSecretHelper(clientSecretSize);
        }

        private static Guid ClientIdHelper()
        {
            return Guid.NewGuid();
        }

        private static string ClientSecretHelper(int clientSecretSize)
        {
            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[clientSecretSize];
                cryptoProvider.GetBytes(randomBytes);
                var apiKey = Convert.ToBase64String(randomBytes);
                return apiKey;
            }
        }
    }
}
