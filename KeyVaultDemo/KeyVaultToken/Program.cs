namespace KeyVaultToken
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Configuration;
    using Microsoft.Azure.KeyVault;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;

    /// <summary>
    /// Main Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Gets or sets the assertion cert.
        /// </summary>
        /// <value>
        /// The assertion cert.
        /// </value>
        public static ClientAssertionCertificate AssertionCert { get; set; }

        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetAccessToken));
            ////Add your key Vault URL and Secret name you want to fetch from key Vault
            var secretValue = kv.GetSecretAsync("https://YourKeyVaultURL", "SecretName").Result.Value;
            Console.Write(secretValue.ToString());
            Console.Read();
        }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        /// <param name="authority">The authority.</param>
        /// <param name="resource">The resource.</param>
        /// <param name="scope">The scope.</param>
        /// <returns>Access token</returns>
        public static async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            ////Read value from appSettings in configuration file (App.config)
            var clientId = WebConfigurationManager.AppSettings["AuthClientId"];
            var clientSecret = WebConfigurationManager.AppSettings["AuthClientSecret"];
            ClientCredential clientCredential = new ClientCredential(clientId, clientSecret);
            var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
            var result = await context.AcquireTokenAsync(resource, clientCredential);
            return result.AccessToken;
        }
    }
}
