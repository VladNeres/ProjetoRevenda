using ApiRevenda.Repositorys;
using AutoMapper;
using CategoriaApi.Data;
using CategoriaApi.Model;
using FluentResults;
using Newtonsoft.Json;
using RevendaApi.Data.Dto.DtoEndereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiRevenda.Services
{
    public class EnderecoService
    {
        private EnderecoRepository _repositoy;
        private  IMapper _mapper;

        public EnderecoService(EnderecoRepository repository, IMapper mapper)
        {
            _repositoy = repository;
            _mapper = mapper;
         
        }

        public async Task<ReadEnderecoDto> AdicionarEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = await InserirResultadoViaCep(enderecoDto);
             _repositoy.AdicionarEndereco(endereco);
            ReadEnderecoDto readEnderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return readEnderecoDto;
        }


        public async Task<Result> AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            var enderecoExiste = _repositoy.RecuperarEnderecoPorId(id);
            if (enderecoExiste == null)
            {
                return Result.Fail("Endereço não encontrado");
            }

            await InsrindoValoresViaCep(enderecoExiste);
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _repositoy.AtualizarEndereco(endereco);
            return Result.Ok();
        }

        private async Task InsrindoValoresViaCep(Endereco endereco)
        {
            var viaCep = await ViaCep(endereco.CEP);
            endereco.Logradouro = viaCep.Logradouro;
            endereco.UF = viaCep.UF;
            endereco.Localidade = viaCep.Localidade;
            endereco.Bairro = viaCep.Bairro;
            endereco.CEP = endereco.CEP;
        }

        public IEnumerable<Endereco> GetEndereco()
        {
           var enderecos= _repositoy.GetEndereco();
            return enderecos;
           
        }

        public ReadEnderecoDto  GetEnderecoPorId(int id)
        {
            Endereco endereco = _repositoy.RecuperarEnderecoPorId(id);
            if (endereco == null)
            {
                return null;
            }
            var mostranome = _repositoy.RecuperarNomeDoCliente(endereco.Id).Nome;
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return enderecoDto;
        }

        internal Result DeletarEnderecoPorId(int id)
        {
            Endereco enderecoId = _repositoy.RecuperarEnderecoPorId(id);
            if(enderecoId == null)
            {
                return Result.Fail("Endereço não encontrado");
            }
            _repositoy.DeletarEnderecoPorId(enderecoId);
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
            endereco.Logradouro = viaCep.Logradouro;
            endereco.UF = viaCep.UF;
            endereco.Localidade = viaCep.Localidade;
            endereco.Bairro = viaCep.Bairro;
            return endereco;
        }
    }
}
