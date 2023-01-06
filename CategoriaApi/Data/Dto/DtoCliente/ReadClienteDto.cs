using CategoriaApi.Model;

namespace RevendaApi.Data.Dto.ClienteDto
{
    public class ReadClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco Enderecos { get; set; }
    }
}
