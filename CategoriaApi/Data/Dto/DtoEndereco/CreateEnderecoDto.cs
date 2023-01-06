using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Data.Dto.DtoEndereco
{
    public class CreateEnderecoDto
    {

        [Required(ErrorMessage = "O campo CEP é obrigatório")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Por favor informe o número")]
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public int ClienteId { get; set; }
    }
}
