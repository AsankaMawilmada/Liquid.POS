using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using FluentValidation;
using Liquid.API.Infrastructure.Errors;
using Liquid.Core.Services.Interfaces.Security;
using Liquid.Persistence.Contexts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Liquid.API.Features.Accounts
{
    public class LoginEnvelope
    {
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class LoginCommand : IRequest<LoginEnvelope>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    
    public class CommandValidator : AbstractValidator<LoginCommand>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }

    public class Login : EndpointBaseAsync
        .WithRequest<LoginCommand>
        .WithActionResult<LoginEnvelope>
    {
        private readonly ILiquidContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public Login(ILiquidContext context, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("api/account/login"), AllowAnonymous]
        [ProducesResponseType(typeof(LoginEnvelope), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericRestException), StatusCodes.Status400BadRequest)]
        [SwaggerOperation(
            Summary = "Creates a JWT Token",
            Description = "Creates a JWT Token for valid user",
            OperationId = "Account.LoginEndpoint")]
        public override async Task<ActionResult<LoginEnvelope>> HandleAsync([FromBody] LoginCommand request, CancellationToken cancellationToken)
        {
            const string message = "Invalid username or password.";

            var user = await _context.Users.Where(x => x.Username == request.Username && x.Active).SingleOrDefaultAsync(cancellationToken);
            if (user == null)
                throw new RestException(HttpStatusCode.BadRequest, message );

            if (!user.Hash.SequenceEqual(await _passwordHasher.Hash(request.Password ?? throw new InvalidOperationException(), user.Salt)))
                throw new RestException(HttpStatusCode.BadRequest, message);

            return new LoginEnvelope
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = _jwtTokenGenerator.CreateToken(user.Username, user.Role.ToString())
            };
        }
    }

}
