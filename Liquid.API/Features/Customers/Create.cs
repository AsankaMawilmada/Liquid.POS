using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Liquid.API.Features.Customers.Commands;
using Liquid.API.Features.Customers.Envelopes;
using Liquid.Core.Entities;
using Liquid.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Liquid.API.Features.Customers
{
    public class Create : EndpointBaseAsync
        .WithRequest<CreateCommand>
        .WithActionResult<CustomerEnvelope>
    {
        private readonly ILiquidContext _context;
        private readonly IMapper _mapper;

        public Create(ILiquidContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("api/customer")]
        [ProducesResponseType(typeof(CustomerEnvelope), StatusCodes.Status201Created)]
        [SwaggerOperation(
            Summary = "Creates a customer",
            Description = "Creates a customer",
            OperationId = "Customer.CreateEndpoint")]
        public override async Task<ActionResult<CustomerEnvelope>> HandleAsync([FromBody] CreateCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);

            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Created("", _mapper.Map<CustomerEnvelope>(customer));
        }
    }
}
