namespace StashNet.Contracts
{
    public interface OAuthCredentials
    {
        void Credentials(string token, string secret);
    }
}