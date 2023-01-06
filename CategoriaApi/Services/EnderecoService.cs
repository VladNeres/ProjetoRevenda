using AutoMapper;
using CategoriaApi.Data;
using CategoriaApi.Model;
using FluentResults;
using Newtonsoft.Json;
using RevendaApi.Data.Dto.DtoEndereco;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiRevenda.Services
{
    public class EnderecoService
    {
        private DatabaseContext _context;
        private IMapper _mapper;

        public EnderecoService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadEnderecoDto> AdicionarEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = await InserirResultadoViaCep(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            ReadEnderecoDto readEnderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return readEnderecoDto;
        }


        public async Task<Result> AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            var enderecoExiste = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (enderecoExiste == null)
            {
                return Result.Fail("Endereço não encontrado");
            }

            await InsrindoValoresViaCep(enderecoExiste);
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        private async Task InsrindoValoresViaCep(Endereco endereco)
        {
            var viaCep = await ViaCep(endereco.CEP);
            endereco.Lougradouro = viaCep.Lougradouro;
            endereco.UF = viaCep.UF;
            endereco.Localidade = viaCep.Localidade;
            endereco.Bairro = viaCep.Bairro;
        }

        public object GetEndereco()
        {
            var cliente = _context.Clientes.ToList();
            return cliente;
        }

        public Result GetEnderecoPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Id do endereço não foi encontrado");
            }
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return Result.Ok();
        }

        internal Result DeletarEnderecoPorId(int id)
        {
          Endereco enderecoId= _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(enderecoId == null)
            {
                return Result.Fail("Endereço não encontrado");
            }
            _context.Enderecos.Remove(enderecoId);
            _context.SaveChanges();
            return Result.Ok();
        }
        public async Task<Endereco> ViaCep(string cep)
        {
            HttpClient client = new HttpClient();
            var requisicao = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            var resposta = await requisicao.Content.ReadAsStringAsync();
            if (!requisicao.IsSuccessStatusCode)
            {
                throw new NullReferenceException("Cep Inexistente ou incorreto");
            }
            var endereco= JsonConvert.DeserializeObject<Endereco>(resposta);
            return endereco;
        }
        private async Task<Endereco> InserirResultadoViaCep(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            var viaCep = await ViaCep(endereco.CEP);
            endereco.Lougradouro = viaCep.Lougradouro;
            endereco.UF = viaCep.UF;
            endereco.Localidade = viaCep.Localidade;
            endereco.Bairro = viaCep.Bairro;
            return endereco;
        }
    }
}
