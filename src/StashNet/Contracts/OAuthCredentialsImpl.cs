namespace StashNet.Contracts
{
    internal class OAuthCredentialsImpl :
        OAuthCredentials
    {
        public string Token { get; private set; }
        public string Secret { get; private set; }

        public void Credentials(string token, string secret)
        {
            Token = token;
            Secret = secret;
        }
    }
}
