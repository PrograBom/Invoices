namespace Invoices.Handler;

using AutoMapper;
using Invoices.Dtos;
using Invoices.Model;
public class MappingProfile : Profile
{
    public MappingProfile() {
        CreateMap<User, ClientDto>();
    }
}
