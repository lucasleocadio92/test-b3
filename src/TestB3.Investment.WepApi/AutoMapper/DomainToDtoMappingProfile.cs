using AutoMapper;
using TestB3.Investment.WepApi.DTO;

namespace TestB3.Investment.WepApi.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Domain.Investment, InvestmentResponse>();
        }
    }
}
