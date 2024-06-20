namespace Application._Common.Security.Authentication;

public interface IPasswordHasher
{
    (string hashedPassword, string salt, string algorithm, short iterations) Generate(string password);
    (string password, string hashedPassword, string salt, string algorithm, short iterations) GenerateNewPassword();
    string Hash(string password, string salt, HashingSettings hashingSettings);
}