namespace DevFreela.Core.Services;

public interface IAuthServices
{
    string GenerateJwtToken(string email, string role);
    string ComputeSha256Hash(string password);
}
