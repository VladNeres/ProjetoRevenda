using CategoriaApi.Model;

namespace ApiRevenda.Interfaces
{
    public interface IRepositoryCliente
    {
        public void AdicionarCliente(Cliente cliente);
        public void ExcluirCliente(Cliente cliente);
        public void Salvar();
        public object PesquisarListaCliente();
        public Cliente RecuperaClientePorId(int id);


    }
}
