using Liquid.Core.Services.Interfaces.Security;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Liquid.API.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly HMACSHA512 x = new(Encoding.UTF8.GetBytes("851a535c-b742-11ec-b909-0242ac120002"));

        public Task<byte[]> Hash(string password, byte[] salt)
        {
            var bytes = Encoding.UTF8.GetBytes(password);

            var allBytes = new byte[bytes.Length + salt.Length];
            Buffer.BlockCopy(bytes, 0, allBytes, 0, bytes.Length);
            Buffer.BlockCopy(salt, 0, allBytes, bytes.Length, salt.Length);

            return x.ComputeHashAsync(new MemoryStream(allBytes));
        }

        public void Dispose() => x.Dispose();
    }
}
