using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Liquid.API.Features.Users.Commands;
using Liquid.API.Features.Users.Envelopes;
using Liquid.API.Infrastructure.Errors;
using Liquid.Core.Constants;
using Liquid.Core.Entities;
using Liquid.Core.Services.Interfaces.Security;
using Liquid.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Liquid.API.Features.Users
{
    public class Create : EndpointBaseAsync
        .WithRequest<CreateCommand>
        .WithActionResult<UserEnvelope>
    {
        private readonly ILiquidContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public Create(ILiquidContext context, IPasswordHasher passwordHasher, IMapper mapper)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        [HttpPost("api/user/create")]
        [Authorize(Policy = PolicyConstants.RequireAdministratorRole)]
        [ProducesResponseType(typeof(UserEnvelope), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(GenericRestException), StatusCodes.Status400BadRequest)]
        [SwaggerOperation(
            Summary = "Creates a user",
            Description = "Creates a user",
            OperationId = "User.Create")]
        public override async Task<ActionResult<UserEnvelope>> HandleAsync([FromBody] CreateCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Users.Where(x => x.Username == request.Username).AnyAsync(cancellationToken))
                throw new RestException(HttpStatusCode.BadRequest, new { Username = Constants.IN_USE });

            var user = _mapper.Map<User>(request);
            
            user.Salt = Guid.NewGuid().ToByteArray();
            user.Hash = await _passwordHasher.Hash(request.Password, user.Salt);

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Created("",_mapper.Map<User, UserEnvelope>(user));
        }
    }
}