using CategoriaApi.Model;

namespace RevendaApi.Data.Dto.DtoEndereco
{
    public class ReadEnderecoDto
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public Cliente Clientes { get; set; }
    }
}
