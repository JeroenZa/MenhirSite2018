namespace MenhirSite.BusinessLogic.Helpers.AuthenticationHelpers
{
    public interface IPasswordHelper
    {
        bool ValidatePassword(string userPassword, string suppliedPassword);
        string GeneratePasswordHash(string suppliedPassword);
        string GeneratePassword(int length);
    }
}