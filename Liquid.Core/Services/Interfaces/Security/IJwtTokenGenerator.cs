namespace Liquid.Core.Services.Interfaces.Security
{
    public interface IJwtTokenGenerator
    {
        string CreateToken(string username, string roleName);
    }
}
