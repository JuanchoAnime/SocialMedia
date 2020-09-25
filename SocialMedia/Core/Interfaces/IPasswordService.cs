namespace SocialMedia.Core.Interfaces
{
    public interface IPasswordService
    {
        string HasPassword(string password);

        bool Check(string hash, string password);
    }
}
