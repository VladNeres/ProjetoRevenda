using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Data.Dto.ClienteDto
{
    public class UpDateClienteDto
    {
        [Required]
        public string Nome { get; set; }

    }
}
