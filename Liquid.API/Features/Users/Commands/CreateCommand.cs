using System;
using Liquid.API.Features.Users.Envelopes;
using Liquid.Core.Enums;
using MediatR;

namespace Liquid.API.Features.Users.Commands
{
    public class CreateCommand : IRequest<UserEnvelope>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}