using AutoMapper;
using Invoices.Dtos;
using Invoices.Model;

namespace Invoices.Handler
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, ClientDto>();
        }
    }
}