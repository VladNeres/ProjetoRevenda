using CategoriaApi.Model;
using FluentResults;
using RevendaApi.Data.Dto.ClienteDto;

namespace ApiRevenda.Interfaces
{
    public interface IServiceCliente
    {

        public ReadClienteDto AdicionarCliente(Cliente clienteDto);
        public Result AtualizarCliente(int id, UpDateClienteDto clienteDto);
        public Result ExcluiCliente(int id);
        public object PesquisarListaCliente();
        public ReadClienteDto GetClientePorId(int id);

    }
}
