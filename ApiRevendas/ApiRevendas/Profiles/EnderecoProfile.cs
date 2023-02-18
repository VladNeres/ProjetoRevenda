using AutoMapper;
using CategoriaApi.Model;
using RevendaApi.Data.Dto.DtoEndereco;
using System.Linq;

namespace RevendaApi.Profiles
{
    public class EnderecoProfile: Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<UpdateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
        }
    }
}
