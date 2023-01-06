using ApiRevenda.Repositorys;
using AutoMapper;
using CategoriaApi.Model;
using FluentResults;
using RevendaApi.Data.Dto.ClienteDto;

namespace ApiRevenda.Services
{
    public class ClienteService
    {

        private IMapper _mapper;
        private ClienteRepository _repository;
        public ClienteService( IMapper mapper, ClienteRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ReadClienteDto AdicionarCliente(CreateClienteDto clienteDto)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDto); 
            ReadClienteDto readDto= _mapper.Map<ReadClienteDto>(cliente);
            return readDto;
        }

        public Result AtualizarCliente(int id, UpDateClienteDto clienteDto)
        {
            Cliente cliente = _repository.RecuperaClientePorId(id); 
            if (cliente == null)
            {
                return Result.Fail("Cliente não encontrado");
            }
            _mapper.Map(clienteDto, cliente);
            _repository.Salvar();
            return Result.Ok();
        }

        public Result ExcluiCliente(int id)
        {
            Cliente excluirClienteporId = _repository.RecuperaClientePorId(id);
            if (excluirClienteporId == null)
            {
                return Result.Fail("Cliente não encontrado");
            }
            _repository.ExcluirCliente(excluirClienteporId);
            return Result.Ok();
        }

        public object PesquisarListaCliente()
        {
            var cliente = _repository.PesquisarListaCliente();
            return cliente;
        }
        public ReadClienteDto GetClientePorId(int id)
        {
            Cliente clienteporId = _repository.RecuperaClientePorId(id);
            if (clienteporId != null)
            {
                ReadClienteDto cliente = _mapper.Map<ReadClienteDto>(clienteporId);
                return cliente;
            }
            return null;
        }
    }
}
