using AutoMapper;
using CategoriaApi.Model;
using RevendaApi.Data.Dto.ClienteDto;

namespace RevendaApi.Profiles
{
    public class ClienteProfile:Profile
    {

        public ClienteProfile()
        {
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<UpDateClienteDto, Cliente>();
            CreateMap<Cliente, ReadClienteDto>();
                

        }
    }
}
