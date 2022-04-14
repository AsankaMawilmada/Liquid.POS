using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Liquid.API.Features.Customers.Envelopes;
using Liquid.Core.Entities;
using Liquid.Core.Models;
using Liquid.Persistence.Contexts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Liquid.API.Features.Customers
{
    public class Query : IRequest<GenericList<CustomerEnvelope>>
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }

    public class List : EndpointBaseAsync
        .WithRequest<Query>
        .WithActionResult<GenericList<CustomerEnvelope>>
    {
        private readonly ILiquidContext _context;
        private readonly IMapper _mapper;

        public List(ILiquidContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("api/customers")]
        [ProducesResponseType(typeof(GenericList<CustomerEnvelope>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "List customers",
            Description = "List customers",
            OperationId = "Customer.ListEndpoint")]
        public override async Task<ActionResult<GenericList<CustomerEnvelope>>> HandleAsync([FromBody] Query request, CancellationToken cancellationToken)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateProjection<Customer, CustomerEnvelope>());

            var queryable = _context.Customers.AsQueryable();

            var customers = await queryable
                .Skip(request.Offset ?? 0)
                .Take(request.Limit ?? 20)
                .AsNoTracking()
                .ProjectTo<CustomerEnvelope>(configuration)
                .ToListAsync(cancellationToken);

            return Ok(new GenericList<CustomerEnvelope>
            {
                Items = _mapper.Map<List<CustomerEnvelope>>(customers) ,
                Count = await queryable.CountAsync(cancellationToken)
            });
        }
    }
}