using System;
using System.Threading.Tasks;

namespace Liquid.Core.Services.Interfaces.Security
{
    public interface IPasswordHasher : IDisposable
    {
        Task<byte[]> Hash(string password, byte[] salt);
    }
}
