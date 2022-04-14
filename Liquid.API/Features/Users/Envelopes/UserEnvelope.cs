using System;
using Liquid.Core.Enums;

namespace Liquid.API.Features.Users.Envelopes
{
    public class UserEnvelope
    {
        public Guid? UserGuId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public bool Active { get; set; }
    }
}