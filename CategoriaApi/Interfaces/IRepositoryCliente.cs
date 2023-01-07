using CategoriaApi.Model;
using System.Collections.Generic;

namespace ApiRevenda.Interfaces
{
    public interface IRepositoryCliente
    {
        public void AdicionarCliente(Cliente cliente);
        public void ExcluirCliente(Cliente cliente);
        public void Salvar();
        public List<Cliente> PesquisarListaCliente();
        public Cliente RecuperaClientePorId(int id);


    }
}
