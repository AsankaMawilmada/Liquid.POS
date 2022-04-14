using AutoMapper;
using Liquid.API.Features.Users.Commands;
using Liquid.API.Features.Users.Envelopes;
using Liquid.Core.Entities;

namespace Liquid.API.Features.Users
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCommand, User>(MemberList.None);

            CreateMap<User, UserEnvelope>(MemberList.None);
        }
    }
}
