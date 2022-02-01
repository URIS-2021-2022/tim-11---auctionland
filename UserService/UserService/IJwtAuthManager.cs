namespace UserService
{
    public interface IJwtAuthManager
    {
        string Authenticate(string username, string password);
    }
}
