namespace Liquid.Core.Services.Interfaces.Security
{
    public interface ICurrentUserAccessor
    {
        string? GetCurrentUsername();
    }
}
