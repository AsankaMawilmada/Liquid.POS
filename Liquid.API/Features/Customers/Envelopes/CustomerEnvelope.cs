using System;

namespace Liquid.API.Features.Customers.Envelopes
{
    public class CustomerEnvelope
    {
        public Guid CustomerGuId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string PostalCode { get; set; }
    }
}