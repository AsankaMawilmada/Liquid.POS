using AutoMapper;
using Liquid.API.Features.Customers.Commands;
using Liquid.API.Features.Customers.Envelopes;
using Liquid.Core.Entities;

namespace Liquid.API.Features.Customers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCommand, Customer>(MemberList.None);

            CreateMap<Customer, CustomerEnvelope>(MemberList.None);
        }
    }
}