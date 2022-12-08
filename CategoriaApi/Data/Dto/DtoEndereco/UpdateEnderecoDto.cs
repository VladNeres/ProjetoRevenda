using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Data.Dto.DtoEndereco
{
    public class UpdateEnderecoDto
    {
        [Required(ErrorMessage = "É necessario informar o nome da rua")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "É necessario informar o número")]
        public int Numero { get; set; }
        public string Complemento { get; set; }

    }
}
