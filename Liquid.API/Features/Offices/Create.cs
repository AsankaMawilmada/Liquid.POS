using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace Liquid.API.Features.Offices
{
    public class CustomerEnvelope
    {

    }

    public class CreateCommand : IRequest<CustomerEnvelope>
    {
        public string OfficeCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Territory { get; set; }
    }

    public class CommandValidator : AbstractValidator<CreateCommand>
    {
        public CommandValidator()
        {
            RuleFor(o => o.OfficeCode).NotEmpty().WithMessage("Office code cannot be empty").Length(1, 10).WithMessage("Office code too long");
            RuleFor(o => o.City).NotEmpty().WithMessage("City cannot be empty").Length(1, 50).WithMessage("City too long");
            RuleFor(o => o.Phone).NotEmpty().WithMessage("Phone cannot be empty").Length(1, 50).WithMessage("Phone too long");
            RuleFor(o => o.AddressLine1).NotEmpty().WithMessage("Address line 1 cannot be empty").Length(1, 50).WithMessage("Address line 1 too long");
            RuleFor(o => o.Country).NotEmpty().WithMessage("Country cannot be empty").Length(1, 50).WithMessage("Country too long");
            RuleFor(o => o.PostalCode).NotEmpty().WithMessage("PostalCode cannot be empty").Length(1, 10).WithMessage("PostalCode too long");
            RuleFor(o => o.Territory).NotEmpty().WithMessage("Territory cannot be empty").Length(1, 10).WithMessage("Territory too long");
        }
    }

    public class Create : EndpointBaseAsync
        .WithRequest<CreateCommand>
        .WithActionResult
    {
        //  private readonly IAsyncRepository<Office> _repository;
        private readonly IMapper _mapper;

        public Create(
            //IAsyncRepository<Office> repository,
            IMapper mapper)
        {
            //_repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new Author
        /// </summary>
        [HttpPost("api/office")]
        [SwaggerOperation(
            Summary = "Creates a new Author",
            Description = "Creates a new Author",
            OperationId = "Author.Create",
            Tags = new[] { "AuthorEndpoint" })]
        public override async Task<ActionResult> HandleAsync([FromBody] CreateCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
//
       //     var author = new Office();

            // await _repository.AddAsync(author, cancellationToken);

            // return CreatedAtRoute("Authors_Get", new {  }, request);
            return Created("", new { });
        }
    }
}
