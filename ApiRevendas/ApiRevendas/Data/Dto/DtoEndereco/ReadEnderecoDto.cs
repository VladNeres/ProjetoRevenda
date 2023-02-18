using CategoriaApi.Model;
using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Data.Dto.DtoEndereco
{
    public class ReadEnderecoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Cepo CEP é Obrigatório")]
        public string CEP { get; set; }
        public string UF { get; set; }
        public string Localidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "É necessario informar o numero da casa")]
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public Cliente Clientes { get; set; }
    }
}
