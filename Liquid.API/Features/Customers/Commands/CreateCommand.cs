using Liquid.API.Features.Customers.Envelopes;
using MediatR;

namespace Liquid.API.Features.Customers.Commands
{
    public class CreateCommand : IRequest<CustomerEnvelope>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string PostalCode { get; set; }
    }
}