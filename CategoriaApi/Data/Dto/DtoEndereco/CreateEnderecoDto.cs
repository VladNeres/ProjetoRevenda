using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Data.Dto.DtoEndereco
{
    public class CreateEnderecoDto
    {
        [Required(ErrorMessage ="Por favor informe o nome da rua")]
        public string Lougradouro { get; set; }
        [Required(ErrorMessage = "Por favor informe o número")]
        public int Numero { get; set; }
        public string Complemento { get; set; }
    }
}
